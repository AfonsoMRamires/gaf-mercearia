Imports System.Data.SqlClient
Imports System.IO

Public Class Utentes
    Public Class UtentesObj
        Public codUtente As String = String.Empty
        Public nome As String = String.Empty
        Public morada As String = String.Empty
        Public complemento As String = String.Empty
        Public autorizado As String = String.Empty
        Public telefone As String = String.Empty
        Public telemovel As String = String.Empty
        Public nif As String = String.Empty
        Public ss As String = String.Empty
        Public id As String = String.Empty
        Public dataNasc As Date = Nothing
        Public dataEntrada As Date = Nothing
        Public ativo As Boolean = True
        Public codFamilia As Integer = 0
        Public utilizador As String = String.Empty
        Public dtCriacao As Date = Nothing
        Public hrCriacao As Date = Nothing
        Public obs As String = String.Empty
        Public foto As Image = My.Resources.Resource1.foto_default
        Public pais As String = String.Empty
        Public estCivil As String = String.Empty
        Public sexo As String = String.Empty
        Public fotoAut As Image = My.Resources.Resource1.foto_default
        Public receita As Decimal = 0
        Public despesa As Decimal = 0
        Public codPostal As String = String.Empty
        Public dataSaida As Date = Nothing
        Public ultimaEntrega As Date = Nothing
    End Class

    ' Formats a date as yyyy-MM-dd, falling back to 1900-01-01 for empty/out-of-range
    ' dates. An unset Date is 0001-01-01 (Date.MinValue), which SQL datetime rejects
    ' (min 1753-01-01), so guard on the year rather than on an empty string.
    Private Shared Function DateOrDefault(ByVal d As Date) As String
        If d = Nothing OrElse d.Year < 1900 Then Return "1900-01-01"
        Return Format(d, "yyyy-MM-dd")
    End Function

    Public Function AddUtente(ByVal Utentes As UtentesObj, ByRef Message As String) As Boolean

        Try
            Dim sql As String = "INSERT INTO Utentes VALUES (@codUtente, @nome, @morada, @complemento, @autorizado, @telefone, @telemovel, @nif, @ss, @id, @dataNasc, @dataEntrada, @ativo, @codFamilia, @utilizador, @dtCriacao, @hrCriacao, @obs, @foto, @pais, @estCivil, @sexo, @fotoAut, @receita, @despesa, @codPostal, @dataSaida, @ultimaEntrega)"

            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@codUtente", Utentes.codUtente)
                    cmd.Parameters.AddWithValue("@nome", Utentes.nome)
                    cmd.Parameters.AddWithValue("@morada", Utentes.morada)
                    cmd.Parameters.AddWithValue("@complemento", Utentes.complemento)
                    cmd.Parameters.AddWithValue("@autorizado", Utentes.autorizado)
                    cmd.Parameters.AddWithValue("@telefone", Utentes.telefone)
                    cmd.Parameters.AddWithValue("@telemovel", Utentes.telemovel)
                    cmd.Parameters.AddWithValue("@nif", Utentes.nif)
                    cmd.Parameters.AddWithValue("@ss", Utentes.ss)
                    cmd.Parameters.AddWithValue("@id", Utentes.id)
                    cmd.Parameters.AddWithValue("@dataNasc", DateOrDefault(Utentes.dataNasc))
                    cmd.Parameters.AddWithValue("@dataEntrada", DateOrDefault(Utentes.dataEntrada))
                    cmd.Parameters.AddWithValue("@ativo", Utentes.ativo)
                    cmd.Parameters.AddWithValue("@codFamilia", Utentes.codFamilia)
                    cmd.Parameters.AddWithValue("@utilizador", Utentes.utilizador)
                    cmd.Parameters.AddWithValue("@dtCriacao", DateOrDefault(Utentes.dtCriacao))
                    cmd.Parameters.AddWithValue("@hrCriacao", Format(Utentes.hrCriacao, "HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@obs", Utentes.obs)

                    Dim ms As New IO.MemoryStream
                    Utentes.foto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    cmd.Parameters.AddWithValue("@foto", ms.ToArray)

                    cmd.Parameters.AddWithValue("@pais", Utentes.pais)
                    cmd.Parameters.AddWithValue("@estCivil", Utentes.estCivil)
                    cmd.Parameters.AddWithValue("@sexo", Utentes.sexo)

                    Dim msAut As New IO.MemoryStream
                    Utentes.fotoAut.Save(msAut, System.Drawing.Imaging.ImageFormat.Jpeg)
                    cmd.Parameters.AddWithValue("@fotoAut", msAut.ToArray)

                    cmd.Parameters.AddWithValue("@receita", Utentes.receita)
                    cmd.Parameters.AddWithValue("@despesa", Utentes.despesa)
                    cmd.Parameters.AddWithValue("@codPostal", Utentes.codPostal)
                    cmd.Parameters.AddWithValue("@dataSaida", DateOrDefault(Utentes.dataSaida))
                    cmd.Parameters.AddWithValue("@ultimaEntrega", DateOrDefault(Utentes.ultimaEntrega))

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Message = "Erro Método AddUtente: " + ex.Message
            AppLogger.Error("AddUtente", ex)
            Return False
        End Try

        Message = "Registo inserido com sucesso"
        AppLogger.Info("AddUtente", "Inserido: " & Utentes.codUtente)
        Return True
    End Function

    Public Function DelUtente(ByVal Utentes As UtentesObj, ByRef Message As String) As Boolean

        Try
            'TODO
            'Inserir validações nas demais tabelas para impedir inconsistência de dados
            'Inserir confirmação antes de eliminar o registo

            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand("DELETE FROM Utentes WHERE codUtente = @codUtente", conn)
                    cmd.Parameters.AddWithValue("@codUtente", Utentes.codUtente)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Message = "Erro Método DelUtente: " + ex.Message
            AppLogger.Error("DelUtente", ex)
            Return False
        End Try

        Message = "Registo removido com sucesso"
        AppLogger.Info("DelUtente", "Removido: " & Utentes.codUtente)
        Return True
    End Function

    Public Function ModUtente(ByVal Utentes As UtentesObj, ByRef Message As String) As Boolean

        Try
            Dim sql As String = "UPDATE Utentes SET codUtente=@codUtente, nome=@nome, morada=@morada, complemento=@complemento, autorizado=@autorizado, " &
                "telefone=@telefone, telemovel=@telemovel, nif=@nif, ss=@ss, id=@id, dataNasc=@dataNasc, dataEntrada=@dataEntrada, ativo=@ativo, " &
                "codFamilia=@codFamilia, utilizador=@utilizador, dtCriacao=@dtCriacao, hrCriacao=@hrCriacao, obs=@obs, foto=@foto, pais=@pais, estCivil=@estCivil, " &
                "sexo=@sexo, fotoAut=@fotoAut, receita=@receita, despesa=@despesa, codPostal=@codPostal, dataSaida=@dataSaida, ultimaEntrega=@ultimaEntrega " &
                "WHERE codUtente = @codUtente"

            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@codUtente", Utentes.codUtente)
                    cmd.Parameters.AddWithValue("@nome", Utentes.nome)
                    cmd.Parameters.AddWithValue("@morada", Utentes.morada)
                    cmd.Parameters.AddWithValue("@complemento", Utentes.complemento)
                    cmd.Parameters.AddWithValue("@autorizado", Utentes.autorizado)
                    cmd.Parameters.AddWithValue("@telefone", Utentes.telefone)
                    cmd.Parameters.AddWithValue("@telemovel", Utentes.telemovel)
                    cmd.Parameters.AddWithValue("@nif", Utentes.nif)
                    cmd.Parameters.AddWithValue("@ss", Utentes.ss)
                    cmd.Parameters.AddWithValue("@id", Utentes.id)
                    cmd.Parameters.AddWithValue("@dataNasc", DateOrDefault(Utentes.dataNasc))
                    cmd.Parameters.AddWithValue("@dataEntrada", DateOrDefault(Utentes.dataEntrada))
                    cmd.Parameters.AddWithValue("@ativo", Utentes.ativo)
                    cmd.Parameters.AddWithValue("@codFamilia", Utentes.codFamilia)
                    cmd.Parameters.AddWithValue("@utilizador", Utentes.utilizador)
                    cmd.Parameters.AddWithValue("@dtCriacao", DateOrDefault(Utentes.dtCriacao))
                    cmd.Parameters.AddWithValue("@hrCriacao", Format(Utentes.hrCriacao, "HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@obs", Utentes.obs)

                    Dim ms As New IO.MemoryStream
                    Utentes.foto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    cmd.Parameters.AddWithValue("@foto", ms.ToArray)

                    cmd.Parameters.AddWithValue("@pais", Utentes.pais)
                    cmd.Parameters.AddWithValue("@estCivil", Utentes.estCivil)
                    cmd.Parameters.AddWithValue("@sexo", Utentes.sexo)

                    Dim msAut As New IO.MemoryStream
                    Utentes.fotoAut.Save(msAut, System.Drawing.Imaging.ImageFormat.Jpeg)
                    cmd.Parameters.AddWithValue("@fotoAut", msAut.ToArray)

                    cmd.Parameters.AddWithValue("@receita", Utentes.receita)
                    cmd.Parameters.AddWithValue("@despesa", Utentes.despesa)
                    cmd.Parameters.AddWithValue("@codPostal", Utentes.codPostal)
                    cmd.Parameters.AddWithValue("@dataSaida", DateOrDefault(Utentes.dataSaida))
                    cmd.Parameters.AddWithValue("@ultimaEntrega", DateOrDefault(Utentes.ultimaEntrega))

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Message = "Erro Método ModUtente: " + ex.Message
            AppLogger.Error("ModUtente", ex)
            Return False
        End Try

        Message = "Registo alterado com sucesso"
        AppLogger.Info("ModUtente", "Alterado: " & Utentes.codUtente)
        Return True
    End Function

    Public Function FindUtenteByName(ByVal nome As String, ByVal autorizado As String, ByRef returnCode As Boolean, ByRef Message As String) As DataTable

        Dim dt As New DataTable

        Try
            Dim hasNome As Boolean = (nome <> String.Empty)
            Dim hasAut As Boolean = (autorizado <> String.Empty)

            If Not hasNome AndAlso Not hasAut Then
                Message = "Para realizar a pesquisa, preencha pelo menos um dos campos"
                returnCode = False
                Return dt
            End If

            Dim sql As String = "SELECT codUtente, nome, autorizado, ativo FROM Utentes WHERE 1=1"
            If hasNome Then sql &= " AND nome LIKE @nome"
            If hasAut Then sql &= " AND autorizado LIKE @autorizado"

            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand(sql, conn)
                    If hasNome Then cmd.Parameters.AddWithValue("@nome", "%" & nome & "%")
                    If hasAut Then cmd.Parameters.AddWithValue("@autorizado", "%" & autorizado & "%")
                    conn.Open()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            If dt.Rows.Count > 0 Then
                returnCode = True
            Else
                Message = "Nenhum registo encontrado"
                returnCode = False
            End If

        Catch ex As Exception
            Message = "Erro Método FindUtenteByName: " + ex.Message
            AppLogger.Error("FindUtenteByName", ex)
            returnCode = False
        End Try

        Return dt
    End Function

    Public Function ReadUtente(ByVal codUtente As String, ByRef returnCode As Boolean, ByRef Message As String) As UtentesObj

        Dim UtentesOut As UtentesObj = New UtentesObj
        Try
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand("SELECT * FROM Utentes WHERE codUtente = @codUtente", conn)
                    cmd.Parameters.AddWithValue("@codUtente", codUtente)
                    conn.Open()
                    Using sdr As SqlDataReader = cmd.ExecuteReader()
                        While sdr.Read()
                            UtentesOut.codUtente = sdr("codUtente").ToString
                            UtentesOut.nome = sdr("nome").ToString
                            UtentesOut.autorizado = sdr("autorizado").ToString
                            UtentesOut.morada = sdr("morada").ToString
                            UtentesOut.complemento = sdr("complemento").ToString
                            UtentesOut.nif = sdr("nif").ToString
                            UtentesOut.ss = sdr("ss").ToString
                            UtentesOut.id = sdr("id").ToString
                            UtentesOut.pais = sdr("pais").ToString
                            UtentesOut.telefone = sdr("telefone").ToString
                            UtentesOut.telemovel = sdr("telemovel").ToString
                            UtentesOut.dataNasc = sdr("dataNasc").ToString
                            UtentesOut.dataEntrada = sdr("dataEntrada").ToString
                            UtentesOut.dataSaida = sdr("dataSaida").ToString
                            UtentesOut.receita = sdr("receita").ToString
                            UtentesOut.despesa = sdr("despesa").ToString
                            UtentesOut.estCivil = sdr("estCivil").ToString
                            UtentesOut.sexo = sdr("sexo").ToString
                            UtentesOut.codPostal = sdr("codPostal").ToString
                            UtentesOut.utilizador = sdr("utilizador").ToString
                            UtentesOut.obs = sdr("obs").ToString
                            If Not IsDBNull(sdr("ativo")) Then UtentesOut.ativo = CBool(sdr("ativo"))
                            If Not IsDBNull(sdr("codFamilia")) Then UtentesOut.codFamilia = CInt(sdr("codFamilia"))
                            ' Preserve creation stamp and last-delivery cache across an edit;
                            ' otherwise ModUtente would overwrite them with the 1900 default.
                            If Not IsDBNull(sdr("dtCriacao")) Then UtentesOut.dtCriacao = CDate(sdr("dtCriacao"))
                            If Not IsDBNull(sdr("hrCriacao")) Then UtentesOut.hrCriacao = CDate(sdr("hrCriacao"))
                            If Not IsDBNull(sdr("ultimaEntrega")) Then UtentesOut.ultimaEntrega = CDate(sdr("ultimaEntrega"))

                            Dim bits As Byte() = CType(sdr("foto"), Byte())
                            Dim memorybits As New MemoryStream(bits)
                            UtentesOut.foto = New Bitmap(memorybits)

                            Dim bitsAut As Byte() = CType(sdr("fotoAut"), Byte())
                            Dim memorybitsAut As New MemoryStream(bitsAut)
                            UtentesOut.fotoAut = New Bitmap(memorybitsAut)
                        End While
                    End Using
                End Using
            End Using

            If UtentesOut.codUtente <> "" Then
                returnCode = True
            Else
                returnCode = False
                Message = "Registo não encontrado"
            End If

        Catch ex As Exception
            returnCode = False
            Message = "Erro Método ReadUtente: " + ex.Message
            AppLogger.Error("ReadUtente", ex)
        End Try

        Return UtentesOut
    End Function

    Public Function GetNewCodUtente(ByRef returnCode As Boolean, ByRef Message As String) As String

        Dim newCodUtente As String = String.Empty
        Dim letra As Char = "U"

        returnCode = True

        Try
            ' The prefix sequence is U, A, B, C, ... so plain MAX(codUtente) is wrong:
            ' lexically "U999" > "A001", meaning after a U->A rollover MAX would keep
            ' returning the old U-code forever and regenerate a duplicate. Rank the
            ' prefix in sequence order, then by the numeric suffix, and take the top.
            Dim sql As String =
                "SELECT TOP 1 codUtente FROM Utentes " &
                "ORDER BY CASE LEFT(codUtente,1) " &
                "WHEN 'U' THEN 0 WHEN 'A' THEN 1 WHEN 'B' THEN 2 WHEN 'C' THEN 3 " &
                "WHEN 'D' THEN 4 WHEN 'E' THEN 5 WHEN 'F' THEN 6 WHEN 'G' THEN 7 " &
                "WHEN 'H' THEN 8 ELSE 99 END DESC, " &
                "CAST(RIGHT(codUtente,3) AS INT) DESC"

            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand(sql, conn)
                    conn.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    newCodUtente = If(result Is Nothing OrElse result Is DBNull.Value, "", result.ToString())
                End Using
            End Using

            If newCodUtente = "" Then
                newCodUtente = "U001"
            Else
                Dim codeString As String = Right$(newCodUtente, 3)
                If codeString = "999" Then
                    codeString = "000"
                    Select Case Left$(newCodUtente, 1)
                        Case "U"
                            letra = "A"
                        Case "A"
                            letra = "B"
                        Case "B"
                            letra = "C"
                        Case "C"
                            letra = "D"
                        Case "D"
                            letra = "E"
                        Case "E"
                            letra = "F"
                        Case "F"
                            letra = "G"
                        Case "G"
                            letra = "H"
                        Case Else
                            letra = "Z"
                    End Select
                Else
                    letra = CChar(Left$(newCodUtente, 1))
                End If
                ' Integer increment (was string concatenation under Option Strict Off).
                Dim codeInt As Integer = Integer.Parse(codeString) + 1
                codeString = codeInt.ToString().PadLeft(3, "0"c)
                newCodUtente = letra & codeString
            End If

        Catch ex As Exception
            returnCode = False
            Message = "Erro Método GetNewCodUtente: " + ex.Message
            AppLogger.Error("GetNewCodUtente", ex)
        End Try

        Return newCodUtente
    End Function

End Class
