Imports System.Configuration

Module GAFDataBase

    ' Single source of the connection string, read from App.config
    ' <connectionStrings>. Every service method opens its own Using-scoped
    ' SqlConnection against this rather than sharing one.
    Public ReadOnly Property ConnectionString As String
        Get
            Return ConfigurationManager.ConnectionStrings("GAF.My.MySettings.GAFConnectionString").ConnectionString
        End Get
    End Property

End Module
