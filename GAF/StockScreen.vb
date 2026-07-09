Public Class StockScreen

    Private ReadOnly Stock As Stock = New Stock
    Private returnCode As Boolean = False
    Private Message As String = String.Empty

    ' 0 = inserting a new artigo; >0 = editing the artigo with this code.
    Private currentCodArtigo As Integer = 0

    Private Sub StockScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTPEntrega.Value = Date.Today
        LoadArtigos()
        LoadArtigosCombo()
        ClearArtigoFields()
    End Sub

    ' Called by UtentesScreen to pre-fill the currently displayed client.
    Public Sub SetCodUtente(ByVal codUtente As String)
        TBCodUtenteEntrega.Text = codUtente
        TBCodUtenteHist.Text = codUtente
        LookupNomeUtente(codUtente)
        LoadHistorico(codUtente)
    End Sub

    ' ── Artigos tab ────────────────────────────────────────────────────────────
    Private Sub LoadArtigos()
        Dim dt As DataTable = Stock.GetArtigos(returnCode, Message)
        If returnCode Then
            DGVArtigos.DataSource = dt
        Else
            MsgBox(Message)
        End If
    End Sub

    Private Sub LoadArtigosCombo()
        Dim dt As DataTable = Stock.GetArtigos(returnCode, Message)
        If returnCode Then
            CBArtigo.DataSource = dt
            CBArtigo.DisplayMember = "descricao"
            CBArtigo.ValueMember = "codArtigo"
            CBArtigo.SelectedIndex = -1
        End If
    End Sub

    Private Sub ClearArtigoFields()
        currentCodArtigo = 0
        TBDescricao.Text = String.Empty
        TBUnidade.Text = "un"
        NUDStockMinimo.Value = 0
        CBAtivo.Checked = True
        TBObsArtigo.Text = String.Empty
        TBDescricao.Focus()
    End Sub

    Private Sub DGVArtigos_SelectionChanged(sender As Object, e As EventArgs) Handles DGVArtigos.SelectionChanged
        If DGVArtigos.SelectedRows.Count = 0 Then Return
        Dim row As DataGridViewRow = DGVArtigos.SelectedRows(0)
        If row.IsNewRow OrElse row.Cells("codArtigo").Value Is Nothing Then Return

        currentCodArtigo = CInt(row.Cells("codArtigo").Value)
        TBDescricao.Text = row.Cells("descricao").Value.ToString()
        TBUnidade.Text = row.Cells("unidade").Value.ToString()
        NUDStockMinimo.Value = CDec(row.Cells("stockMinimo").Value)
        CBAtivo.Checked = CBool(row.Cells("ativo").Value)
        TBObsArtigo.Text = row.Cells("obs").Value.ToString()
    End Sub

    Private Sub BtnNovoArtigo_Click(sender As Object, e As EventArgs) Handles BtnNovoArtigo.Click
        ClearArtigoFields()
    End Sub

    Private Sub BtnGravarArtigo_Click(sender As Object, e As EventArgs) Handles BtnGravarArtigo.Click
        If TBDescricao.Text.Trim() = String.Empty Then
            MsgBox("Preencha a descrição do artigo")
            Return
        End If

        Dim a As New Stock.ArtigoObj With {
            .codArtigo = currentCodArtigo,
            .descricao = TBDescricao.Text.Trim(),
            .unidade = TBUnidade.Text.Trim(),
            .stockMinimo = NUDStockMinimo.Value,
            .ativo = CBAtivo.Checked,
            .obs = TBObsArtigo.Text
        }

        Dim ok As Boolean
        If currentCodArtigo = 0 Then
            ok = Stock.AddArtigo(a, Message)
        Else
            ok = Stock.ModArtigo(a, Message)
        End If

        MsgBox(Message)
        If ok Then
            LoadArtigos()
            LoadArtigosCombo()
            ClearArtigoFields()
        End If
    End Sub

    Private Sub BtnEntradaStock_Click(sender As Object, e As EventArgs) Handles BtnEntradaStock.Click
        If currentCodArtigo = 0 Then
            MsgBox("Selecione um artigo na lista para dar entrada de stock")
            Return
        End If

        Dim resposta As String = InputBox("Quantidade a dar entrada:", "Entrada de Stock", "0")
        If resposta = String.Empty Then Return

        Dim qtd As Decimal
        If Not Decimal.TryParse(resposta, qtd) OrElse qtd <= 0 Then
            MsgBox("Quantidade inválida")
            Return
        End If

        If Stock.EntradaStock(currentCodArtigo, qtd, Message) Then
            LoadArtigos()
            LoadArtigosCombo()
        End If
        MsgBox(Message)
    End Sub

    Private Sub BtnLimparArtigo_Click(sender As Object, e As EventArgs) Handles BtnLimparArtigo.Click
        ClearArtigoFields()
    End Sub

    ' ── Registar Entrega tab ─────────────────────────────────────────────────────
    Private Sub LookupNomeUtente(ByVal codUtente As String)
        If codUtente.Trim() = String.Empty Then
            LblNomeUtente.Text = String.Empty
            Return
        End If
        Dim u As Utentes.UtentesObj = New Utentes().ReadUtente(codUtente, returnCode, Message)
        If returnCode Then
            LblNomeUtente.Text = u.nome
        Else
            LblNomeUtente.Text = "(não encontrado)"
        End If
    End Sub

    Private Sub BtnProcurarUtenteEntrega_Click(sender As Object, e As EventArgs) Handles BtnProcurarUtenteEntrega.Click
        LookupNomeUtente(TBCodUtenteEntrega.Text)
    End Sub

    Private Sub BtnRegistarEntrega_Click(sender As Object, e As EventArgs) Handles BtnRegistarEntrega.Click
        If TBCodUtenteEntrega.Text.Trim() = String.Empty Then
            MsgBox("Indique o código do utente")
            Return
        End If
        If CBArtigo.SelectedValue Is Nothing Then
            MsgBox("Selecione um artigo")
            Return
        End If
        If NUDQuantidade.Value <= 0 Then
            MsgBox("Quantidade tem de ser maior que zero")
            Return
        End If

        ' Confirm the client exists before recording.
        LookupNomeUtente(TBCodUtenteEntrega.Text)
        If Not returnCode Then
            MsgBox("Utente não encontrado")
            Return
        End If

        Dim ent As New Stock.EntregaObj With {
            .codUtente = TBCodUtenteEntrega.Text.Trim(),
            .codArtigo = CInt(CBArtigo.SelectedValue),
            .quantidade = NUDQuantidade.Value,
            .dtEntrega = DTPEntrega.Value.Date,
            .utilizador = Environment.UserName,
            .obs = TBObsEntrega.Text
        }

        If Stock.RegistarEntrega(ent, Message) Then
            NUDQuantidade.Value = 0
            TBObsEntrega.Text = String.Empty
            LoadArtigos()
            LoadArtigosCombo()
            LoadHistorico(ent.codUtente)
        End If
        MsgBox(Message)
    End Sub

    ' ── Histórico tab ────────────────────────────────────────────────────────────
    Private Sub LoadHistorico(ByVal codUtente As String)
        If codUtente.Trim() = String.Empty Then Return
        Dim dt As DataTable = Stock.GetEntregasByUtente(codUtente, returnCode, Message)
        If returnCode Then
            DGVHistorico.DataSource = dt
        Else
            MsgBox(Message)
        End If
    End Sub

    Private Sub BtnProcurarHist_Click(sender As Object, e As EventArgs) Handles BtnProcurarHist.Click
        LoadHistorico(TBCodUtenteHist.Text)
    End Sub

End Class
