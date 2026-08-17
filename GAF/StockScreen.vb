Public Class StockScreen

    Private ReadOnly Stock As Stock = New Stock
    Private returnCode As Boolean = False
    Private Message As String = String.Empty

    ' Set by SetCodUtente before the dialog is shown; applied once the form's
    ' handle actually exists (Load), since TabPages other than the initially
    ' selected one don't get their child controls' handles created until first
    ' shown — setting .Text on them any earlier is unreliable.
    Private pendingCodUtente As String = String.Empty

    ' Full (unfiltered) combined Entregas+Saídas rows for whichever Utente is
    ' currently loaded in Histórico Utente; filters are applied over this via
    ' a DataView rather than re-querying the DB each time.
    Private historicoDt As DataTable = Nothing

    Private Sub StockScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CBTipoHist.SelectedIndex = 0
        LoadArtigosSaidaCombo()

        If pendingCodUtente <> String.Empty Then
            TBCodUtenteHist.Text = pendingCodUtente
            LoadHistorico(pendingCodUtente)
            TBUtenteSaida.Text = pendingCodUtente
            LookupNomeUtenteSaida(pendingCodUtente)
        End If
    End Sub

    ' Called by UtentesScreen to pre-fill the currently displayed client.
    Public Sub SetCodUtente(ByVal codUtente As String)
        pendingCodUtente = codUtente
    End Sub

    ' ── Saída de Stock tab ───────────────────────────────────────────────────────
    Private Sub LoadArtigosSaidaCombo()
        Dim dt As DataTable = Stock.GetArtigos(returnCode, Message)
        If returnCode Then
            CBArtigoSaida.DataSource = dt
            CBArtigoSaida.DisplayMember = "descricao"
            CBArtigoSaida.ValueMember = "codArtigo"
            CBArtigoSaida.SelectedIndex = -1
        End If
    End Sub

    Private Sub LookupNomeUtenteSaida(ByVal codUtente As String)
        If codUtente.Trim() = String.Empty Then
            LblNomeUtenteSaida.Text = String.Empty
            Return
        End If
        Dim u As Utentes.UtentesObj = New Utentes().ReadUtente(codUtente, returnCode, Message)
        If returnCode Then
            LblNomeUtenteSaida.Text = u.nome
        Else
            LblNomeUtenteSaida.Text = "(não encontrado)"
        End If
    End Sub

    Private Sub BtnProcurarUtenteSaida_Click(sender As Object, e As EventArgs) Handles BtnProcurarUtenteSaida.Click
        LookupNomeUtenteSaida(TBUtenteSaida.Text)
    End Sub

    Private Sub BtnRegistarSaida_Click(sender As Object, e As EventArgs) Handles BtnRegistarSaida.Click
        If CBArtigoSaida.SelectedValue Is Nothing Then
            MsgBox("Selecione um artigo")
            Return
        End If
        If NUDQuantidadeSaida.Value <= 0 Then
            MsgBox("Quantidade tem de ser maior que zero")
            Return
        End If

        Dim codUtenteSaida As String = TBUtenteSaida.Text.Trim()
        If codUtenteSaida = String.Empty Then
            MsgBox("Indique o código do utente")
            Return
        End If
        LookupNomeUtenteSaida(codUtenteSaida)
        If Not returnCode Then
            MsgBox("Utente não encontrado")
            Return
        End If

        Dim s As New Stock.SaidaObj With {
            .codArtigo = CInt(CBArtigoSaida.SelectedValue),
            .quantidade = NUDQuantidadeSaida.Value,
            .dtSaida = Date.Today,
            .motivo = TBMotivoSaida.Text.Trim(),
            .utilizador = Environment.UserName,
            .codUtente = codUtenteSaida
        }

        If Stock.RegistarSaida(s, Message) Then
            NUDQuantidadeSaida.Value = 0
            TBMotivoSaida.Text = String.Empty
            LoadArtigosSaidaCombo()
            LoadHistorico(codUtenteSaida)
        End If
        MsgBox(Message)
    End Sub

    ' ── Histórico tab ────────────────────────────────────────────────────────────
    ' Combined Entregas + Saídas for the given codUtente, or for every Utente
    ' when codUtente is blank. Resets the filter row on every fresh load.
    Private Sub LoadHistorico(ByVal codUtente As String)
        If codUtente.Trim() = String.Empty Then Return
        Dim dt As DataTable = Stock.GetHistoricoUtente(codUtente, returnCode, Message)
        If returnCode Then
            historicoDt = dt
            DTPDataDeHist.Checked = False
            DTPDataAteHist.Checked = False
            TBDescricaoHist.Text = String.Empty
            CBTipoHist.SelectedIndex = 0
            ApplyHistoricoFilter()
        Else
            MsgBox(Message)
        End If
    End Sub

    Private Sub ApplyHistoricoFilter()
        If historicoDt Is Nothing Then Return

        Dim filters As New List(Of String)
        If DTPDataDeHist.Checked Then
            filters.Add("Data >= #" & DTPDataDeHist.Value.ToString("MM/dd/yyyy") & "#")
        End If
        If DTPDataAteHist.Checked Then
            filters.Add("Data <= #" & DTPDataAteHist.Value.ToString("MM/dd/yyyy") & "#")
        End If
        If TBDescricaoHist.Text.Trim() <> String.Empty Then
            filters.Add("Descricao LIKE '%" & EscapeRowFilterLiteral(TBDescricaoHist.Text.Trim()) & "%'")
        End If
        If CBTipoHist.SelectedIndex > 0 Then
            filters.Add("Tipo = '" & Filtering.EscapeRowFilterLiteral(CBTipoHist.SelectedItem.ToString()) & "'")
        End If

        Dim dv As DataView = historicoDt.DefaultView
        Try
            dv.RowFilter = String.Join(" AND ", filters)
        Catch ex As Exception
            MsgBox("Filtro inválido: " & ex.Message)
            dv.RowFilter = String.Empty
        End Try
        DGVHistorico.DataSource = dv
        Filtering.SetColumnFillWeights(DGVHistorico, New Dictionary(Of String, Integer) From {
            {"Tipo", 8}, {"Data", 10}, {"Descricao", 22}, {"Unidade", 6}, {"Quantidade", 8},
            {"Motivo", 18}, {"Utilizador", 10}, {"CodUtente", 8}, {"NomeUtente", 14}})
    End Sub

    Private Sub BtnProcurarHist_Click(sender As Object, e As EventArgs) Handles BtnProcurarHist.Click
        LoadHistorico(TBCodUtenteHist.Text)
    End Sub

    Private Sub BtnFiltrarHist_Click(sender As Object, e As EventArgs) Handles BtnFiltrarHist.Click
        ApplyHistoricoFilter()
    End Sub

End Class
