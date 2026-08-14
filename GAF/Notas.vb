Imports System.Data.SqlClient

''' <summary>
''' Free-text annotations against a Utente (Anotações tab). Append-only —
''' there is no edit/delete, just a growing timestamped history.
''' </summary>
Public Class Notas

    Public Class NotaObj
        Public codNota As Integer = 0
        Public codUtente As String = String.Empty
        Public texto As String = String.Empty
        Public dtCriacao As Date = DateTime.Now
        Public utilizador As String = String.Empty
    End Class

    Public Function AddNota(ByVal n As NotaObj, ByRef Message As String) As Boolean
        Try
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand(
                    "INSERT INTO Notas (codUtente, texto, dtCriacao, utilizador) " &
                    "VALUES (@codUtente, @texto, @dtCriacao, @utilizador)", conn)
                    cmd.Parameters.AddWithValue("@codUtente", n.codUtente)
                    cmd.Parameters.AddWithValue("@texto", n.texto)
                    cmd.Parameters.AddWithValue("@dtCriacao", n.dtCriacao)
                    cmd.Parameters.AddWithValue("@utilizador", n.utilizador)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Message = "Nota adicionada com sucesso"
            AppLogger.Info("AddNota", "Utente=" & n.codUtente)
            Return True
        Catch ex As Exception
            Message = "Erro Método AddNota: " & ex.Message
            AppLogger.Error("AddNota", ex)
            Return False
        End Try
    End Function

    Public Function GetNotasByUtente(ByVal codUtente As String, ByRef returnCode As Boolean, ByRef Message As String) As DataTable
        Dim dt As New DataTable
        Try
            Using conn As New SqlConnection(GAFDataBase.ConnectionString)
                Using cmd As New SqlCommand(
                    "SELECT texto, dtCriacao, utilizador FROM Notas " &
                    "WHERE codUtente = @codUtente ORDER BY dtCriacao DESC", conn)
                    cmd.Parameters.AddWithValue("@codUtente", codUtente)
                    conn.Open()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
            returnCode = True
        Catch ex As Exception
            Message = "Erro Método GetNotasByUtente: " & ex.Message
            AppLogger.Error("GetNotasByUtente", ex)
            returnCode = False
        End Try
        Return dt
    End Function

End Class
