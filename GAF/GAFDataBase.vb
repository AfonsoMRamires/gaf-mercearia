Imports System.Data.SqlClient
Imports System.Configuration

Module GAFDataBase

    ' Reads the connection string from App.config <connectionStrings>.
    ' No hardcoded paths — uses the |DataDirectory| token already configured there.
    Public ReadOnly Property ConnectionString As String
        Get
            Return ConfigurationManager.ConnectionStrings("GAF.My.MySettings.GAFConnectionString").ConnectionString
        End Get
    End Property

    ' Factory: each caller gets a fresh, closed connection to use inside a Using block.
    Public Function NewConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function

End Module
