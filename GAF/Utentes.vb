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

    Public Function AddUtente(ByVal Utentes As UtentesObj, ByRef Message As String) As Boolean

        Try

            strInstruction = "INSERT INTO Utentes VALUES (@codUtente, @nome, @morada, @complemento, @autorizado, @telefone, @telemovel, @nif, @ss, @id, @dataNasc, @dataEntrada, @ativo, @codFamilia, @utilizador, @dtCriacao, @hrCriacao, @obs, @foto, @pais, @estCivil, @sexo, @fotoAut, @receita, @despesa, @codPostal, @dataSaida, @ultimaEntrega)"
            objCommand.CommandText = strInstruction
            objCommand.Connection = objConnection
            objCommand.Parameters.Clear()

            objCommand.Parameters.AddWithValue("@codUtente", Utentes.codUtente)
            objCommand.Parameters.AddWithValue("@nome", Utentes.nome)
            objCommand.Parameters.AddWithValue("@morada", Utentes.morada)
            objCommand.Parameters.AddWithValue("@complemento", Utentes.complemento)
            objCommand.Parameters.AddWithValue("@autorizado", Utentes.autorizado)
            objCommand.Parameters.AddWithValue("@telefone", Utentes.telefone)
            objCommand.Parameters.AddWithValue("@telemovel", Utentes.telemovel)
            objCommand.Parameters.AddWithValue("@nif", Utentes.nif)
            objCommand.Parameters.AddWithValue("@ss", Utentes.ss)
            objCommand.Parameters.AddWithValue("@id", Utentes.id)

            Dim convertDate As String
            convertDate = Format(Utentes.dataNasc, "yyyy-MM-dd")
            If convertDate = String.Empty Then
                convertDate = "1900-01-01"
            End If
            objCommand.Parameters.AddWithValue("@dataNasc", convertDate)

            convertDate = Format(Utentes.dataEntrada, "yyyy-MM-dd")
            If convertDate = String.Empty Then
                convertDate = "1900-01-01"
            End If
            objCommand.Parameters.AddWithValue("@dataEntrada", convertDate)

            objCommand.Parameters.AddWithValue("@ativo", Utentes.ativo)
            objCommand.Parameters.AddWithValue("@codFamilia", Utentes.codFamilia)
            objCommand.Parameters.AddWithValue("@utilizador", Utentes.utilizador)

            convertDate = Format(Utentes.dtCriacao, "yyyy-MM-dd")
            If convertDate = String.Empty Then
                convertDate = "1900-01-01"
            End If
            objCommand.Parameters.AddWithValue("@dtCriacao", convertDate)

            convertDate = Format(Utentes.hrCriacao, "hh:mm:ss")
            objCommand.Parameters.AddWithValue("@hrCriacao", convertDate)

            objCommand.Parameters.AddWithValue("@obs", Utentes.obs)

            Dim ms As New IO.MemoryStream
            Utentes.foto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim byteArray = ms.ToArray
            objCommand.Parameters.AddWithValue("@foto", byteArray)

            objCommand.Parameters.AddWithValue("@pais", Utentes.pais)
            objCommand.Parameters.AddWithValue("@estCivil", Utentes.estCivil)
            objCommand.Parameters.AddWithValue("@sexo", Utentes.sexo)

            Dim msAut As New IO.MemoryStream
            Utentes.fotoAut.Save(msAut, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim byteArrayAut = msAut.ToArray
            objCommand.Parameters.AddWithValue("@fotoAut", byteArrayAut)

            objCommand.Parameters.AddWithValue("@receita", Utentes.receita)
            objCommand.Parameters.AddWithValue("@despesa", Utentes.despesa)
            objCommand.Parameters.AddWithValue("@codPostal", Utentes.codPostal)

            convertDate = Format(Utentes.dataSaida, "yyyy-MM-dd")
            If convertDate = String.Empty Then
                convertDate = "1900-01-01"
            End If
            objCommand.Parameters.AddWithValue("@dataSaida", convertDate)

            convertDate = Format(Utentes.ultimaEntrega, "yyyy-MM-dd")
            If convertDate = String.Empty Then
                convertDate = "1900-01-01"
            End If
            objCommand.Parameters.AddWithValue("@ultimaEntrega", convertDate)

            objConnection.Open()
            objCommand.ExecuteNonQuery()
            objConnection.Close()
        Catch ex As Exception
            Message = "Erro Método AddUtente: " + ex.Message
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
            Return False
        End Try

        Message = "Registo inserido com sucesso"
        Return True
    End Function

    Public Function DelUtente(ByVal Utentes As UtentesObj, ByRef Message As String) As Boolean

        Try

            'TODO
            'Inserir validações nas demais tabelas para impedir inconsistência de dados
            'Inserir confirmação antes de eliminar o registo

            strInstruction = "DELETE FROM Utentes WHERE codUtente = @codUtente"
            objCommand.CommandText = strInstruction
            objCommand.Connection = objConnection
            objCommand.Parameters.Clear()
            objCommand.Parameters.AddWithValue("@codUtente", Utentes.codUtente)

            objConnection.Open()
            objCommand.ExecuteNonQuery()
            objConnection.Close()

        Catch ex As Exception
            Message = "Erro Método DelUtente: " + ex.Message
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
            Return False
        End Try

        Message = "Registo removido com sucesso"
        Return True
    End Function

    Public Function ModUtente(ByVal Utentes As UtentesObj, ByRef Message As String) As Boolean

        Try
            strInstruction = "UPDATE Utentes SET codUtente=@codUtente, nome=@nome, morada=@morada, complemento=@complemento, autorizado=@autorizado, "
            strInstruction += "telefone=@telefone, telemovel=@telemovel, nif=@nif, ss=@ss, id=@id, dataNasc=@dataNasc, dataEntrada=@dataEntrada, ativo=@ativo, "
            strInstruction += "codFamilia=@codFamilia, utilizador=@utilizador, dtCriacao=@dtCriacao, hrCriacao=@hrCriacao, obs=@obs, foto=@foto, pais=@pais, estCivil=@estCivil, "
            strInstruction += "sexo=@sexo, fotoAut=@fotoAut, receita=@receita, despesa=@despesa, codPostal=@codPostal, dataSaida=@dataSaida, ultimaEntrega=@ultimaEntrega "
            strInstruction += "WHERE codUtente = @codUtente"
            objCommand.CommandText = strInstruction
            objCommand.Connection = objConnection
            objCommand.Parameters.Clear()

            objCommand.Parameters.AddWithValue("@codUtente", Utentes.codUtente)
            objCommand.Parameters.AddWithValue("@nome", Utentes.nome)
            objCommand.Parameters.AddWithValue("@morada", Utentes.morada)
            objCommand.Parameters.AddWithValue("@complemento", Utentes.complemento)
            objCommand.Parameters.AddWithValue("@autorizado", Utentes.autorizado)
            objCommand.Parameters.AddWithValue("@telefone", Utentes.telefone)
            objCommand.Parameters.AddWithValue("@telemovel", Utentes.telemovel)
            objCommand.Parameters.AddWithValue("@nif", Utentes.nif)
            objCommand.Parameters.AddWithValue("@ss", Utentes.ss)
            objCommand.Parameters.AddWithValue("@id", Utentes.id)

            Dim convertDate As String
            convertDate = Format(Utentes.dataNasc, "yyyy-MM-dd")
            If convertDate = String.Empty Then
                convertDate = "1900-01-01"
            End If
            objCommand.Parameters.AddWithValue("@dataNasc", convertDate)

            convertDate = Format(Utentes.dataEntrada, "yyyy-MM-dd")
            If convertDate = String.Empty Then
                convertDate = "1900-01-01"
            End If
            objCommand.Parameters.AddWithValue("@dataEntrada", convertDate)

            objCommand.Parameters.AddWithValue("@ativo", Utentes.ativo)
            objCommand.Parameters.AddWithValue("@codFamilia", Utentes.codFamilia)
            objCommand.Parameters.AddWithValue("@utilizador", Utentes.utilizador)

            convertDate = Format(Utentes.dtCriacao, "yyyy-MM-dd")
            If convertDate = String.Empty Then
                convertDate = "1900-01-01"
            End If
            objCommand.Parameters.AddWithValue("@dtCriacao", convertDate)

            convertDate = Format(Utentes.hrCriacao, "hh:mm:ss")
            objCommand.Parameters.AddWithValue("@hrCriacao", convertDate)

            objCommand.Parameters.AddWithValue("@obs", Utentes.obs)

            Dim ms As New IO.MemoryStream
            Utentes.foto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim byteArray = ms.ToArray
            objCommand.Parameters.AddWithValue("@foto", byteArray)

            objCommand.Parameters.AddWithValue("@pais", Utentes.pais)
            objCommand.Parameters.AddWithValue("@estCivil", Utentes.estCivil)
            objCommand.Parameters.AddWithValue("@sexo", Utentes.sexo)

            Dim msAut As New IO.MemoryStream
            Utentes.fotoAut.Save(msAut, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim byteArrayAut = msAut.ToArray
            objCommand.Parameters.AddWithValue("@fotoAut", byteArrayAut)

            objCommand.Parameters.AddWithValue("@receita", Utentes.receita)
            objCommand.Parameters.AddWithValue("@despesa", Utentes.despesa)
            objCommand.Parameters.AddWithValue("@codPostal", Utentes.codPostal)

            convertDate = Format(Utentes.dataSaida, "yyyy-MM-dd")
            If convertDate = String.Empty Then
                convertDate = "1900-01-01"
            End If
            objCommand.Parameters.AddWithValue("@dataSaida", convertDate)

            convertDate = Format(Utentes.ultimaEntrega, "yyyy-MM-dd")
            If convertDate = String.Empty Then
                convertDate = "1900-01-01"
            End If
            objCommand.Parameters.AddWithValue("@ultimaEntrega", convertDate)

            objConnection.Open()
            objCommand.ExecuteNonQuery()
            objConnection.Close()
        Catch ex As Exception
            Message = "Erro Método ModUtente " + ex.Message
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
            Return False
        End Try

        Message = "Registo alterado com sucesso"
        Return True
    End Function

    Public Function FindUtenteByName(ByVal nome As String, ByVal autorizado As String, ByRef returnCode As Boolean, ByRef Message As String) As DataTable

        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim bsource As New BindingSource()

        Try
            strInstruction = "SELECT codUtente, nome, autorizado, ativo FROM Utentes WHERE "

            If nome <> String.Empty Then
                If autorizado <> String.Empty Then
                    strInstruction += "nome LIKE '%" & nome & "%' AND autorizado LIKE '%" & autorizado & "%'"
                Else
                    strInstruction += "nome LIKE '%" & nome & "%'"
                End If
            ElseIf autorizado <> String.Empty Then
                strInstruction += "autorizado LIKE '%" & autorizado & "%'"
            Else
                Message = "Para realizar a pesquisa, preencha pelo menos um dos campos"
                returnCode = False
                Return dt
            End If

            objCommand.CommandText = strInstruction
            objCommand.Connection = objConnection

            objConnection.Open()
            Dim da As New SqlDataAdapter(objCommand)
            da.Fill(ds)
            dt = ds.Tables(0)
            objConnection.Close()

            If dt.Rows.Count > 0 Then
                returnCode = True
            Else
                Message = "Nenhum registo encontrado"
                returnCode = False
            End If

        Catch ex As Exception
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
            Message = "Erro Método FindUtenteByName " + ex.Message
            returnCode = False
        End Try

        Return dt
    End Function


    Public Function ReadUtente(ByVal codUtente As String, ByRef returnCode As Boolean, ByRef Message As String) As UtentesObj

        Dim UtentesOut As UtentesObj = New UtentesObj
        Try

            strInstruction = "SELECT * FROM Utentes WHERE codUtente = @codUtente"
            objCommand.CommandText = strInstruction
            objCommand.Connection = objConnection
            objCommand.Parameters.Clear()
            objCommand.Parameters.AddWithValue("@codUtente", codUtente)

            objConnection.Open()
            Dim sdr As SqlDataReader = objCommand.ExecuteReader()
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

                Dim bits As Byte() = CType(sdr("foto"), Byte())
                Dim memorybits As New MemoryStream(bits)
                Dim bitmap As New Bitmap(memorybits)
                UtentesOut.foto = bitmap

                Dim bitsAut As Byte() = CType(sdr("fotoAut"), Byte())
                Dim memorybitsAut As New MemoryStream(bitsAut)
                Dim bitmapAut As New Bitmap(memorybitsAut)
                UtentesOut.fotoAut = bitmapAut
            End While

            If UtentesOut.codUtente <> "" Then
                returnCode = True
            Else
                returnCode = False
                Message = "Registo não encontrado"
            End If

            objConnection.Close()

        Catch ex As Exception
            returnCode = False
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
            Message = "Erro Método ReadUtente: " + ex.Message
        End Try

        Return UtentesOut
    End Function

    Public Function GetNewCodUtente(ByRef returnCode As Boolean, ByRef Message As String) As String

        Dim newCodUtente As String = String.Empty
        Dim letra As Char = "U"

        returnCode = True

        Try

            strInstruction = "SELECT MAX( codUtente ) FROM Utentes"
            objCommand.CommandText = strInstruction
            objCommand.Connection = objConnection

            objConnection.Open()

            newCodUtente = objCommand.ExecuteScalar().ToString()

            objConnection.Close()

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
                End If
                codeString += 1
                codeString = codeString.PadLeft(3, "0")
                newCodUtente = letra + codeString
            End If

        Catch ex As Exception
            returnCode = False
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
            Message = "Erro Método GetNewCodUtente: " + ex.Message
        End Try

        Return newCodUtente
    End Function

End Class
