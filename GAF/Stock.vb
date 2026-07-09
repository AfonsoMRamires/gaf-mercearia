Imports System.Data.SqlClient

''' <summary>
''' Stock/inventory service. Manages the item catalog (Artigos) and per-item
''' deliveries to clients (Entregas). Follows the same ByRef Message error pattern
''' as the Utentes service. All DB access uses local Using-scoped connections.
''' </summary>
Public Class Stock

    ' ── Data objects ─────────────────────────────────────────────────────────
    Public Class ArtigoObj
        Public codArtigo As Integer = 0
        Public descricao As String = String.Empty
        Public unidade As String = "un"
        Public stockAtual As Decimal = 0
        Public stockMinimo As Decimal = 0
        Public ativo As Boolean = True
        Public obs As String = String.Empty
    End Class

    Public Class EntregaObj
        Public codEntrega As Integer = 0
        Public codUtente As String = String.Empty
        Public codArtigo As Integer = 0
        Public quantidade As Decimal = 0
        Public dtEntrega As Date = Date.Today
        Public utilizador As String = String.Empty
        Public obs As String = String.Empty
    End Class

    ' ── Schema bootstrap ──────────────────────────────────────────────────────
    ' Idempotent: creates Artigos and Entregas tables if they do not yet exist.
    ' Called on application startup.
    Public Shared Sub EnsureSchema()
        Try
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                conn.Open()

                Using cmd As New SqlCommand(
                    "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Artigos') " &
                    "BEGIN " &
                    "CREATE TABLE Artigos (" &
                    "codArtigo INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " &
                    "descricao NVARCHAR(100) NOT NULL, " &
                    "unidade NVARCHAR(20) NOT NULL DEFAULT 'un', " &
                    "stockAtual DECIMAL(10,2) NOT NULL DEFAULT 0, " &
                    "stockMinimo DECIMAL(10,2) NOT NULL DEFAULT 0, " &
                    "ativo BIT NOT NULL DEFAULT 1, " &
                    "obs NVARCHAR(500) NOT NULL DEFAULT '') " &
                    "END", conn)
                    cmd.ExecuteNonQuery()
                End Using

                Using cmd As New SqlCommand(
                    "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Entregas') " &
                    "BEGIN " &
                    "CREATE TABLE Entregas (" &
                    "codEntrega INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " &
                    "codUtente CHAR(4) NOT NULL, " &
                    "codArtigo INT NOT NULL, " &
                    "quantidade DECIMAL(10,2) NOT NULL, " &
                    "dtEntrega DATE NOT NULL DEFAULT GETDATE(), " &
                    "utilizador NVARCHAR(50) NOT NULL DEFAULT '', " &
                    "obs NVARCHAR(500) NOT NULL DEFAULT '', " &
                    "CONSTRAINT FK_Entregas_Utentes FOREIGN KEY (codUtente) REFERENCES Utentes(codUtente), " &
                    "CONSTRAINT FK_Entregas_Artigos FOREIGN KEY (codArtigo) REFERENCES Artigos(codArtigo)) " &
                    "END", conn)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            AppLogger.Info("EnsureSchema", "Schema de stock verificado")
        Catch ex As Exception
            AppLogger.Error("EnsureSchema", ex)
        End Try
    End Sub

    ' ── Artigos CRUD ──────────────────────────────────────────────────────────
    Public Function AddArtigo(ByVal a As ArtigoObj, ByRef Message As String) As Boolean
        Try
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand(
                    "INSERT INTO Artigos (descricao, unidade, stockAtual, stockMinimo, ativo, obs) " &
                    "VALUES (@descricao, @unidade, @stockAtual, @stockMinimo, @ativo, @obs)", conn)
                    cmd.Parameters.AddWithValue("@descricao", a.descricao)
                    cmd.Parameters.AddWithValue("@unidade", a.unidade)
                    cmd.Parameters.AddWithValue("@stockAtual", a.stockAtual)
                    cmd.Parameters.AddWithValue("@stockMinimo", a.stockMinimo)
                    cmd.Parameters.AddWithValue("@ativo", a.ativo)
                    cmd.Parameters.AddWithValue("@obs", a.obs)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Message = "Artigo inserido com sucesso"
            AppLogger.Info("AddArtigo", "Inserido: " & a.descricao)
            Return True
        Catch ex As Exception
            Message = "Erro Método AddArtigo: " & ex.Message
            AppLogger.Error("AddArtigo", ex)
            Return False
        End Try
    End Function

    Public Function ModArtigo(ByVal a As ArtigoObj, ByRef Message As String) As Boolean
        Try
            ' Note: stockAtual is deliberately NOT updated here. On-hand quantity
            ' only moves via EntradaStock (goods in) and RegistarEntrega (goods out),
            ' so editing an article's details never disturbs its real stock.
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand(
                    "UPDATE Artigos SET descricao=@descricao, unidade=@unidade, " &
                    "stockMinimo=@stockMinimo, ativo=@ativo, obs=@obs " &
                    "WHERE codArtigo=@codArtigo", conn)
                    cmd.Parameters.AddWithValue("@codArtigo", a.codArtigo)
                    cmd.Parameters.AddWithValue("@descricao", a.descricao)
                    cmd.Parameters.AddWithValue("@unidade", a.unidade)
                    cmd.Parameters.AddWithValue("@stockMinimo", a.stockMinimo)
                    cmd.Parameters.AddWithValue("@ativo", a.ativo)
                    cmd.Parameters.AddWithValue("@obs", a.obs)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Message = "Artigo alterado com sucesso"
            AppLogger.Info("ModArtigo", "Alterado cod=" & a.codArtigo)
            Return True
        Catch ex As Exception
            Message = "Erro Método ModArtigo: " & ex.Message
            AppLogger.Error("ModArtigo", ex)
            Return False
        End Try
    End Function

    Public Function GetArtigos(ByRef returnCode As Boolean, ByRef Message As String) As DataTable
        Dim dt As New DataTable
        Try
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand(
                    "SELECT codArtigo, descricao, unidade, stockAtual, stockMinimo, ativo, obs " &
                    "FROM Artigos ORDER BY descricao", conn)
                    conn.Open()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
            returnCode = True
        Catch ex As Exception
            Message = "Erro Método GetArtigos: " & ex.Message
            AppLogger.Error("GetArtigos", ex)
            returnCode = False
        End Try
        Return dt
    End Function

    ' ── Stock movements ───────────────────────────────────────────────────────
    ' Adds quantity to an item's current stock (goods received).
    Public Function EntradaStock(ByVal codArtigo As Integer, ByVal quantidade As Decimal,
                                 ByRef Message As String) As Boolean
        Try
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand(
                    "UPDATE Artigos SET stockAtual = stockAtual + @quantidade WHERE codArtigo = @codArtigo", conn)
                    cmd.Parameters.AddWithValue("@quantidade", quantidade)
                    cmd.Parameters.AddWithValue("@codArtigo", codArtigo)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Message = "Entrada de stock registada"
            AppLogger.Info("EntradaStock", "Artigo=" & codArtigo & " Entrada=" & quantidade.ToString())
            Return True
        Catch ex As Exception
            Message = "Erro Método EntradaStock: " & ex.Message
            AppLogger.Error("EntradaStock", ex)
            Return False
        End Try
    End Function

    ' Records a delivery to a client atomically: insert Entregas row, decrement
    ' item stock, and update the client's ultimaEntrega cache. All-or-nothing.
    Public Function RegistarEntrega(ByVal e As EntregaObj, ByRef Message As String) As Boolean
        Try
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                conn.Open()
                Using tx As SqlTransaction = conn.BeginTransaction()
                    Try
                        Using cmd As New SqlCommand(
                            "INSERT INTO Entregas (codUtente, codArtigo, quantidade, dtEntrega, utilizador, obs) " &
                            "VALUES (@codUtente, @codArtigo, @quantidade, @dtEntrega, @utilizador, @obs)", conn, tx)
                            cmd.Parameters.AddWithValue("@codUtente", e.codUtente)
                            cmd.Parameters.AddWithValue("@codArtigo", e.codArtigo)
                            cmd.Parameters.AddWithValue("@quantidade", e.quantidade)
                            cmd.Parameters.AddWithValue("@dtEntrega", e.dtEntrega.ToString("yyyy-MM-dd"))
                            cmd.Parameters.AddWithValue("@utilizador", e.utilizador)
                            cmd.Parameters.AddWithValue("@obs", e.obs)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Guarded decrement: only succeeds if there is enough on-hand
                        ' stock. Zero rows affected => insufficient stock => abort.
                        Using cmd As New SqlCommand(
                            "UPDATE Artigos SET stockAtual = stockAtual - @quantidade " &
                            "WHERE codArtigo = @codArtigo AND stockAtual >= @quantidade", conn, tx)
                            cmd.Parameters.AddWithValue("@quantidade", e.quantidade)
                            cmd.Parameters.AddWithValue("@codArtigo", e.codArtigo)
                            If cmd.ExecuteNonQuery() = 0 Then
                                Throw New Exception("Stock insuficiente para a quantidade indicada")
                            End If
                        End Using

                        Using cmd As New SqlCommand(
                            "UPDATE Utentes SET ultimaEntrega = @dtEntrega WHERE codUtente = @codUtente", conn, tx)
                            cmd.Parameters.AddWithValue("@dtEntrega", e.dtEntrega.ToString("yyyy-MM-dd"))
                            cmd.Parameters.AddWithValue("@codUtente", e.codUtente)
                            cmd.ExecuteNonQuery()
                        End Using

                        tx.Commit()
                    Catch exInner As Exception
                        tx.Rollback()
                        Throw
                    End Try
                End Using
            End Using
            Message = "Entrega registada com sucesso"
            AppLogger.Info("RegistarEntrega", "Utente=" & e.codUtente & " Artigo=" & e.codArtigo & " Qtd=" & e.quantidade.ToString())
            Return True
        Catch ex As Exception
            Message = "Erro Método RegistarEntrega: " & ex.Message
            AppLogger.Error("RegistarEntrega", ex)
            Return False
        End Try
    End Function

    Public Function GetEntregasByUtente(ByVal codUtente As String,
                                        ByRef returnCode As Boolean,
                                        ByRef Message As String) As DataTable
        Dim dt As New DataTable
        Try
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand(
                    "SELECT e.codEntrega, a.descricao, a.unidade, e.quantidade, e.dtEntrega, e.utilizador, e.obs " &
                    "FROM Entregas e INNER JOIN Artigos a ON e.codArtigo = a.codArtigo " &
                    "WHERE e.codUtente = @codUtente ORDER BY e.dtEntrega DESC", conn)
                    cmd.Parameters.AddWithValue("@codUtente", codUtente)
                    conn.Open()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
            returnCode = True
        Catch ex As Exception
            Message = "Erro Método GetEntregasByUtente: " & ex.Message
            AppLogger.Error("GetEntregasByUtente", ex)
            returnCode = False
        End Try
        Return dt
    End Function

End Class
