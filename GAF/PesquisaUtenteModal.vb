Public Class PesquisaUtenteModal

    Dim returnCode As Boolean = False
    Dim Message As String = String.Empty
    Dim Utentes As Utentes = New Utentes

    Private Sub BtnProcurarUtente_Click(sender As Object, e As EventArgs) Handles BtnProcurarUtente.Click

        DGVUtentes.Rows.Clear()

        Dim dt As DataTable = Utentes.FindUtenteByName(TBNome.Text, TBAutorizado.Text, returnCode, Message)
        If returnCode = True Then
            BtnSelecionar.Enabled = True
            For Each linha As DataRow In dt.Rows
                DGVUtentes.Rows.Add(linha("codUtente").ToString, linha("nome").ToString, linha("autorizado").ToString)
            Next
        Else
            BtnSelecionar.Enabled = False
            MsgBox(Message)
        End If

    End Sub

    Private Sub PesquisaUtenteModal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearFields()

        Dim toolTip As ToolTip = New ToolTip
        toolTip.SetToolTip(BtnProcurarUtente, "Procurar Utente")
        toolTip.SetToolTip(BtnLimpar, "Limpar Campos")
    End Sub

    Private Sub clearFields()
        TBNome.Text = String.Empty
        TBAutorizado.Text = String.Empty
        DGVUtentes.Rows.Clear()
        BtnSelecionar.Enabled = False
        TBNome.Focus()
    End Sub

    Private Sub BtnSelecionar_Click(sender As Object, e As EventArgs) Handles BtnSelecionar.Click
        My.Forms.UtentesScreen.setCodUtente(DGVUtentes.SelectedRows(0).Cells(0).Value.ToString)
        Close()
    End Sub

    Private Sub BtnLimpar_Click(sender As Object, e As EventArgs) Handles BtnLimpar.Click
        clearFields()
    End Sub
End Class