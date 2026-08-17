Imports System.Data.SqlClient

''' <summary>
''' Stock/inventory service. Manages the item catalog (Artigos) and per-item
''' deliveries to clients (Entregas). Follows the same ByRef Message error pattern
''' as the Utentes service. All DB access uses local Using-scoped connections.
''' </summary>
Public Class Stock

    ' Raised for the guarded-decrement "not enough stock" business rule, so callers
    ' can tell it apart from a real DB/connection failure and skip logging it as an
    ' error — it's an expected, user-facing rejection, not a fault.
    Private Class StockInsuficienteException
        Inherits Exception
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
    End Class

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

    ' Stock a Utente leaves with, registered without going through a formal
    ' Entrega. codUtente is required — who took it must always be on record.
    Public Class SaidaObj
        Public codSaida As Integer = 0
        Public codArtigo As Integer = 0
        Public quantidade As Decimal = 0
        Public dtSaida As Date = Date.Today
        Public motivo As String = String.Empty
        Public utilizador As String = String.Empty
        Public codUtente As String = String.Empty
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
                    "codUtente CHAR(4) NULL, " &
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

                Using cmd As New SqlCommand(
                    "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='SaidasStock') " &
                    "BEGIN " &
                    "CREATE TABLE SaidasStock (" &
                    "codSaida INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " &
                    "codArtigo INT NOT NULL, " &
                    "quantidade DECIMAL(10,2) NOT NULL, " &
                    "dtSaida DATE NOT NULL DEFAULT GETDATE(), " &
                    "motivo NVARCHAR(200) NOT NULL DEFAULT '', " &
                    "utilizador NVARCHAR(50) NOT NULL DEFAULT '', " &
                    "codUtente CHAR(4) NULL, " &
                    "CONSTRAINT FK_SaidasStock_Artigos FOREIGN KEY (codArtigo) REFERENCES Artigos(codArtigo), " &
                    "CONSTRAINT FK_SaidasStock_Utentes FOREIGN KEY (codUtente) REFERENCES Utentes(codUtente)) " &
                    "END", conn)
                    cmd.ExecuteNonQuery()
                End Using

                Using cmd As New SqlCommand(
                    "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Notas') " &
                    "BEGIN " &
                    "CREATE TABLE Notas (" &
                    "codNota INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " &
                    "codUtente CHAR(4) NOT NULL, " &
                    "texto NVARCHAR(1000) NOT NULL, " &
                    "dtCriacao DATETIME NOT NULL DEFAULT GETDATE(), " &
                    "utilizador NVARCHAR(50) NOT NULL DEFAULT '', " &
                    "CONSTRAINT FK_Notas_Utentes FOREIGN KEY (codUtente) REFERENCES Utentes(codUtente)) " &
                    "END", conn)
                    cmd.ExecuteNonQuery()
                End Using

                ' ── Self-heal for schema drift introduced after a DB was already created ──
                ' EnsureSchema only ever creates missing tables, never alters existing
                ' ones, so a DB from before Entregas/SaidasStock allowed an optional
                ' Utente needs these two idempotent patches applied on every startup.
                Using cmd As New SqlCommand(
                    "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS " &
                    "WHERE TABLE_NAME='Entregas' AND COLUMN_NAME='codUtente' AND IS_NULLABLE='NO') " &
                    "BEGIN " &
                    "ALTER TABLE Entregas ALTER COLUMN codUtente CHAR(4) NULL " &
                    "END", conn)
                    cmd.ExecuteNonQuery()
                End Using

                Using cmd As New SqlCommand(
                    "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='SaidasStock') " &
                    "AND NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS " &
                    "WHERE TABLE_NAME='SaidasStock' AND COLUMN_NAME='codUtente') " &
                    "BEGIN " &
                    "ALTER TABLE SaidasStock ADD codUtente CHAR(4) NULL " &
                    "END", conn)
                    cmd.ExecuteNonQuery()
                End Using

                Using cmd As New SqlCommand(
                    "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='SaidasStock') " &
                    "AND EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS " &
                    "WHERE TABLE_NAME='SaidasStock' AND COLUMN_NAME='codUtente') " &
                    "AND NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_SaidasStock_Utentes') " &
                    "BEGIN " &
                    "ALTER TABLE SaidasStock ADD CONSTRAINT FK_SaidasStock_Utentes " &
                    "FOREIGN KEY (codUtente) REFERENCES Utentes(codUtente) " &
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

    ' Hard delete. Blocked by the FK constraints on Entregas/SaidasStock if the
    ' artigo already has movements — caller should mark it inactive instead.
    Public Function DeleteArtigo(ByVal codArtigo As Integer, ByRef Message As String) As Boolean
        Try
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand("DELETE FROM Artigos WHERE codArtigo = @codArtigo", conn)
                    cmd.Parameters.AddWithValue("@codArtigo", codArtigo)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Message = "Artigo eliminado com sucesso"
            AppLogger.Info("DeleteArtigo", "Eliminado cod=" & codArtigo)
            Return True
        Catch ex As SqlException When ex.Number = 547
            Message = "Não é possível eliminar: este artigo já tem entradas, entregas ou saídas registadas. Torne-o inativo em vez de eliminar."
            Return False
        Catch ex As Exception
            Message = "Erro Método DeleteArtigo: " & ex.Message
            AppLogger.Error("DeleteArtigo", ex)
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
                    "FROM Artigos ORDER BY ativo DESC, descricao", conn)
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

    ' Records a delivery atomically: insert Entregas row, decrement item stock,
    ' and (when a Utente is given — it's optional) update their ultimaEntrega
    ' cache. All-or-nothing.
    Public Function RegistarEntrega(ByVal e As EntregaObj, ByRef Message As String) As Boolean
        Try
            Dim temUtente As Boolean = e.codUtente.Trim() <> String.Empty
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                conn.Open()
                Using tx As SqlTransaction = conn.BeginTransaction()
                    Try
                        Using cmd As New SqlCommand(
                            "INSERT INTO Entregas (codUtente, codArtigo, quantidade, dtEntrega, utilizador, obs) " &
                            "VALUES (@codUtente, @codArtigo, @quantidade, @dtEntrega, @utilizador, @obs)", conn, tx)
                            If temUtente Then
                                cmd.Parameters.AddWithValue("@codUtente", e.codUtente.Trim())
                            Else
                                cmd.Parameters.AddWithValue("@codUtente", DBNull.Value)
                            End If
                            cmd.Parameters.AddWithValue("@codArtigo", e.codArtigo)
                            cmd.Parameters.AddWithValue("@quantidade", e.quantidade)
                            cmd.Parameters.AddWithValue("@dtEntrega", e.dtEntrega.ToString("yyyy-MM-dd"))
                            cmd.Parameters.AddWithValue("@utilizador", e.utilizador)
                            cmd.Parameters.AddWithValue("@obs", e.obs)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Entrega = goods coming IN (from a supplier/donor), so this adds
                        ' to on-hand stock - the opposite direction from RegistarSaida.
                        Using cmd As New SqlCommand(
                            "UPDATE Artigos SET stockAtual = stockAtual + @quantidade " &
                            "WHERE codArtigo = @codArtigo", conn, tx)
                            cmd.Parameters.AddWithValue("@quantidade", e.quantidade)
                            cmd.Parameters.AddWithValue("@codArtigo", e.codArtigo)
                            cmd.ExecuteNonQuery()
                        End Using

                        If temUtente Then
                            Using cmd As New SqlCommand(
                                "UPDATE Utentes SET ultimaEntrega = @dtEntrega WHERE codUtente = @codUtente", conn, tx)
                                cmd.Parameters.AddWithValue("@dtEntrega", e.dtEntrega.ToString("yyyy-MM-dd"))
                                cmd.Parameters.AddWithValue("@codUtente", e.codUtente.Trim())
                                cmd.ExecuteNonQuery()
                            End Using
                        End If

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

    ' ── Saídas de stock (sem entrega a Utente) ─────────────────────────────────
    ' Records stock leaving for a reason other than a delivery (perda, consumo
    ' interno, correção de inventário, etc.). Guarded decrement, same shape as
    ' RegistarEntrega's insert-then-update transaction but the opposite direction.
    Public Function RegistarSaida(ByVal s As SaidaObj, ByRef Message As String) As Boolean
        If s.codUtente.Trim() = String.Empty Then
            Message = "Código de utente é obrigatório numa Saída de Stock"
            Return False
        End If
        Try
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                conn.Open()
                Using tx As SqlTransaction = conn.BeginTransaction()
                    Try
                        Using cmd As New SqlCommand(
                            "INSERT INTO SaidasStock (codArtigo, quantidade, dtSaida, motivo, utilizador, codUtente) " &
                            "VALUES (@codArtigo, @quantidade, @dtSaida, @motivo, @utilizador, @codUtente)", conn, tx)
                            cmd.Parameters.AddWithValue("@codArtigo", s.codArtigo)
                            cmd.Parameters.AddWithValue("@quantidade", s.quantidade)
                            cmd.Parameters.AddWithValue("@dtSaida", s.dtSaida.ToString("yyyy-MM-dd"))
                            cmd.Parameters.AddWithValue("@motivo", s.motivo)
                            cmd.Parameters.AddWithValue("@utilizador", s.utilizador)
                            cmd.Parameters.AddWithValue("@codUtente", s.codUtente.Trim())
                            cmd.ExecuteNonQuery()
                        End Using

                        Using cmd As New SqlCommand(
                            "UPDATE Artigos SET stockAtual = stockAtual - @quantidade " &
                            "WHERE codArtigo = @codArtigo AND stockAtual >= @quantidade", conn, tx)
                            cmd.Parameters.AddWithValue("@quantidade", s.quantidade)
                            cmd.Parameters.AddWithValue("@codArtigo", s.codArtigo)
                            If cmd.ExecuteNonQuery() = 0 Then
                                Throw New StockInsuficienteException("Stock insuficiente para a quantidade indicada")
                            End If
                        End Using

                        tx.Commit()
                    Catch exInner As Exception
                        tx.Rollback()
                        Throw
                    End Try
                End Using
            End Using
            Message = "Saída de stock registada"
            AppLogger.Info("RegistarSaida", "Artigo=" & s.codArtigo & " Qtd=" & s.quantidade.ToString() & " Motivo=" & s.motivo)
            Return True
        Catch ex As StockInsuficienteException
            Message = ex.Message
            Return False
        Catch ex As Exception
            Message = "Erro Método RegistarSaida: " & ex.Message
            AppLogger.Error("RegistarSaida", ex)
            Return False
        End Try
    End Function

    ' ── Histórico combinado (Entregas + Saídas) ─────────────────────────────────
    ' Both movement types, tagged with Tipo so the caller can filter by date /
    ' descrição / tipo over a single in-memory DataTable. A blank codUtente
    ' returns movements for every Utente (with CodUtente/NomeUtente columns so
    ' the caller can filter/sort/group by client); a non-blank codUtente scopes
    ' the result to just that Utente, as before.
    Public Function GetHistoricoUtente(ByVal codUtente As String,
                                       ByRef returnCode As Boolean,
                                       ByRef Message As String) As DataTable
        Dim dt As New DataTable
        Dim todos As Boolean = codUtente.Trim() = String.Empty
        Try
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Dim sql As String =
                    "SELECT 'Entrega' AS Tipo, e.dtEntrega AS Data, a.descricao AS Descricao, " &
                    "a.unidade AS Unidade, e.quantidade AS Quantidade, e.obs AS Motivo, e.utilizador AS Utilizador, " &
                    "e.codUtente AS CodUtente, u.nome AS NomeUtente " &
                    "FROM Entregas e INNER JOIN Artigos a ON e.codArtigo = a.codArtigo " &
                    "LEFT JOIN Utentes u ON e.codUtente = u.codUtente "
                If Not todos Then sql &= "WHERE e.codUtente = @codUtente "
                sql &=
                    "UNION ALL " &
                    "SELECT 'Saída' AS Tipo, s.dtSaida AS Data, a.descricao AS Descricao, " &
                    "a.unidade AS Unidade, s.quantidade AS Quantidade, s.motivo AS Motivo, s.utilizador AS Utilizador, " &
                    "s.codUtente AS CodUtente, u.nome AS NomeUtente " &
                    "FROM SaidasStock s INNER JOIN Artigos a ON s.codArtigo = a.codArtigo " &
                    "LEFT JOIN Utentes u ON s.codUtente = u.codUtente "
                If Not todos Then sql &= "WHERE s.codUtente = @codUtente "
                sql &= "ORDER BY Data DESC"

                Using cmd As New SqlCommand(sql, conn)
                    If Not todos Then cmd.Parameters.AddWithValue("@codUtente", codUtente)
                    conn.Open()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
            returnCode = True
        Catch ex As Exception
            Message = "Erro Método GetHistoricoUtente: " & ex.Message
            AppLogger.Error("GetHistoricoUtente", ex)
            returnCode = False
        End Try
        Return dt
    End Function

End Class
