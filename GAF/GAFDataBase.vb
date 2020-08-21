Imports System.Data.SqlClient

Module GAFDataBase
    Public Const strConnection As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavi\source\repos\GAF\GAF\GAF.mdf;Integrated Security=True;Connect Timeout=30"
    Public strInstruction As String = String.Empty
    Public objConnection As New SqlConnection(strConnection)
    Public objCommand As New SqlCommand(strInstruction, objConnection)
End Module
