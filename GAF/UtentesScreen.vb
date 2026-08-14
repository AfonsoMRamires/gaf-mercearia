Imports System.Drawing.Printing

Public Class UtentesScreen

    Dim Utentes As Utentes = New Utentes
    Dim Stock As Stock = New Stock
    Dim Notas As Notas = New Notas
    Dim returnCode As Boolean = False
    Dim Message As String = String.Empty
    Dim UtentesObj As Utentes.UtentesObj = New Utentes.UtentesObj
    Dim mode As Char = "I"

    Private Const EM_SETCUEBANNER As Integer = &H1501

    <System.Runtime.InteropServices.DllImport("user32.dll", CharSet:=System.Runtime.InteropServices.CharSet.Unicode)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As String) As IntPtr
    End Function

    Private Sub SetDateFormatHint(tb As TextBox)
        SendMessage(tb.Handle, EM_SETCUEBANNER, IntPtr.Zero, "dd/mm/aaaa")
    End Sub

    Private Sub UtentesScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim toolTip As ToolTip = New ToolTip
        toolTip.SetToolTip(BtnPesquisarUtentes, "Procurar Utente por Nome")

        SetDateFormatHint(TBDataNasc)
        SetDateFormatHint(TBDtEntrada)
        SetDateFormatHint(TBDtSaida)

        AppLogger.Info("UtentesScreen", "Aplicação iniciada")
        Stock.EnsureSchema()

        LoadTodosUtentes()
        LoadArtigosMain()
        LoadArtigosEntregaComboMain()
        DTPEntregaMain.Value = Date.Today

        setScreen("I")
    End Sub

    ' ── Left menu navigation (Ficha Utente / Todos os Utentes / Stock) ──────────
    ' Ficha Utente's own controls stay on the form as-is; these two overlay
    ' panels just cover them (Dock=Fill, topmost) when shown.
    Private Sub ShowFicha()
        PnlTodosUtentes.Visible = False
        PnlStock.Visible = False
    End Sub

    Private Sub BtnNavFicha_Click(sender As Object, e As EventArgs) Handles BtnNavFicha.Click
        ShowFicha()
    End Sub

    Private Sub BtnNavTodosUtentes_Click(sender As Object, e As EventArgs) Handles BtnNavTodosUtentes.Click
        LoadTodosUtentes()
        PnlStock.Visible = False
        PnlTodosUtentes.Visible = True
        PnlTodosUtentes.BringToFront()
    End Sub

    Private Sub BtnNavStock_Click(sender As Object, e As EventArgs) Handles BtnNavStock.Click
        LoadArtigosMain()
        LoadArtigosEntregaComboMain()
        PnlTodosUtentes.Visible = False
        PnlStock.Visible = True
        PnlStock.BringToFront()
    End Sub

    ' ── Todos os Utentes overlay ──────────────────────────────────────────────────
    Private Sub LoadTodosUtentes()
        Dim dt As DataTable = Utentes.GetAllUtentes(returnCode, Message)
        If returnCode Then
            DGVTodosUtentes.DataSource = dt
        Else
            MsgBox(Message)
        End If
    End Sub

    Private Sub DGVTodosUtentes_DoubleClick(sender As Object, e As EventArgs) Handles DGVTodosUtentes.DoubleClick
        If DGVTodosUtentes.SelectedRows.Count = 0 Then Return
        Dim codUtenteSel As String = DGVTodosUtentes.SelectedRows(0).Cells("codUtente").Value.ToString()
        setCodUtente(codUtenteSel)
        ShowFicha()
    End Sub

    ' ── Stock overlay (manage articles + receive stock; no delivery/saída here) ─
    Private Sub LoadArtigosMain()
        Dim dt As DataTable = Stock.GetArtigos(returnCode, Message)
        If returnCode Then
            DGVArtigosMain.DataSource = dt
            HighlightLowStockMain()
        Else
            MsgBox(Message)
        End If
    End Sub

    Private Sub HighlightLowStockMain()
        For Each row As DataGridViewRow In DGVArtigosMain.Rows
            Dim stockAtual As Decimal = CDec(row.Cells("stockAtual").Value)
            Dim stockMinimo As Decimal = CDec(row.Cells("stockMinimo").Value)
            If stockAtual < stockMinimo Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220)
            End If
        Next
    End Sub

    ' Returns 0 if no row is selected.
    Private Function GetSelectedArtigoMain() As Stock.ArtigoObj
        If DGVArtigosMain.SelectedRows.Count = 0 Then Return New Stock.ArtigoObj
        Dim row As DataGridViewRow = DGVArtigosMain.SelectedRows(0)
        If row.IsNewRow OrElse row.Cells("codArtigo").Value Is Nothing Then Return New Stock.ArtigoObj

        Return New Stock.ArtigoObj With {
            .codArtigo = CInt(row.Cells("codArtigo").Value),
            .descricao = row.Cells("descricao").Value.ToString(),
            .unidade = row.Cells("unidade").Value.ToString(),
            .stockMinimo = CDec(row.Cells("stockMinimo").Value),
            .ativo = CBool(row.Cells("ativo").Value),
            .obs = row.Cells("obs").Value.ToString()
        }
    End Function

    Private Sub DGVArtigosMain_DoubleClick(sender As Object, e As EventArgs) Handles DGVArtigosMain.DoubleClick
        Dim a As Stock.ArtigoObj = GetSelectedArtigoMain()
        If a.codArtigo = 0 Then Return
        OpenArtigoModal(a)
    End Sub

    Private Sub BtnNovoArtigoMain_Click(sender As Object, e As EventArgs) Handles BtnNovoArtigoMain.Click
        OpenArtigoModal(New Stock.ArtigoObj)
    End Sub

    Private Sub OpenArtigoModal(ByVal a As Stock.ArtigoObj)
        Dim frm As New ArtigoModal()
        frm.LoadArtigo(a)
        If frm.ShowDialog() = DialogResult.OK Then
            Dim result As Stock.ArtigoObj = frm.GetArtigo()
            Dim ok As Boolean
            If a.codArtigo = 0 Then
                ok = Stock.AddArtigo(result, Message)
            Else
                ok = Stock.ModArtigo(result, Message)
            End If
            MsgBox(Message)
            If ok Then
                LoadArtigosMain()
                LoadArtigosEntregaComboMain()
            End If
        End If
    End Sub

    Private Sub BtnEliminarArtigoMain_Click(sender As Object, e As EventArgs) Handles BtnEliminarArtigoMain.Click
        Dim a As Stock.ArtigoObj = GetSelectedArtigoMain()
        If a.codArtigo = 0 Then
            MsgBox("Selecione um artigo na lista")
            Return
        End If

        If MsgBox("Eliminar o artigo '" & a.descricao & "'?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Confirmar") <> MsgBoxResult.Yes Then
            Return
        End If

        If Stock.DeleteArtigo(a.codArtigo, Message) Then
            LoadArtigosMain()
            LoadArtigosEntregaComboMain()
        End If
        MsgBox(Message)
    End Sub

    Private Sub BtnEntradaStockMain_Click(sender As Object, e As EventArgs) Handles BtnEntradaStockMain.Click
        Dim a As Stock.ArtigoObj = GetSelectedArtigoMain()
        If a.codArtigo = 0 Then
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

        If Stock.EntradaStock(a.codArtigo, qtd, Message) Then
            LoadArtigosMain()
        End If
        MsgBox(Message)
    End Sub

    ' ── Stock overlay: Registar Entrega (operator-managed delivery) ─────────────
    Private Sub LoadArtigosEntregaComboMain()
        Dim dt As DataTable = Stock.GetArtigos(returnCode, Message)
        If returnCode Then
            CBArtigoEntregaMain.DataSource = dt
            CBArtigoEntregaMain.DisplayMember = "descricao"
            CBArtigoEntregaMain.ValueMember = "codArtigo"
            CBArtigoEntregaMain.SelectedIndex = -1
        End If
    End Sub

    Private Sub LookupNomeUtenteEntregaMain(ByVal codUtente As String)
        If codUtente.Trim() = String.Empty Then
            LblNomeUtenteEntregaMain.Text = String.Empty
            Return
        End If
        Dim u As Utentes.UtentesObj = New Utentes().ReadUtente(codUtente, returnCode, Message)
        If returnCode Then
            LblNomeUtenteEntregaMain.Text = u.nome
        Else
            LblNomeUtenteEntregaMain.Text = "(não encontrado)"
        End If
    End Sub

    Private Sub BtnProcurarUtenteEntregaMain_Click(sender As Object, e As EventArgs) Handles BtnProcurarUtenteEntregaMain.Click
        LookupNomeUtenteEntregaMain(TBCodUtenteEntregaMain.Text)
    End Sub

    Private Sub BtnRegistarEntregaMain_Click(sender As Object, e As EventArgs) Handles BtnRegistarEntregaMain.Click
        If CBArtigoEntregaMain.SelectedValue Is Nothing Then
            MsgBox("Selecione um artigo")
            Return
        End If
        If NUDQuantidadeEntregaMain.Value <= 0 Then
            MsgBox("Quantidade tem de ser maior que zero")
            Return
        End If

        Dim codUtenteEntrega As String = TBCodUtenteEntregaMain.Text.Trim()
        If codUtenteEntrega <> String.Empty Then
            ' Utente is optional here, but if one was given it must be real.
            LookupNomeUtenteEntregaMain(codUtenteEntrega)
            If Not returnCode Then
                MsgBox("Utente não encontrado")
                Return
            End If
        End If

        Dim ent As New Stock.EntregaObj With {
            .codUtente = codUtenteEntrega,
            .codArtigo = CInt(CBArtigoEntregaMain.SelectedValue),
            .quantidade = NUDQuantidadeEntregaMain.Value,
            .dtEntrega = DTPEntregaMain.Value.Date,
            .utilizador = Environment.UserName,
            .obs = TBObsEntregaMain.Text
        }

        If Stock.RegistarEntrega(ent, Message) Then
            NUDQuantidadeEntregaMain.Value = 0
            TBObsEntregaMain.Text = String.Empty
            LoadArtigosMain()
            LoadArtigosEntregaComboMain()
        End If
        MsgBox(Message)
    End Sub

    Private Sub UtentesScreen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        AppLogger.Info("UtentesScreen", "Aplicação encerrada")
        AppLogger.Close()
    End Sub

    Private Sub BtnVerStock_Click(sender As Object, e As EventArgs) Handles BtnVerStock.Click
        Dim frm As New StockScreen()
        If UtentesObj.codUtente <> String.Empty Then
            frm.SetCodUtente(UtentesObj.codUtente)
        End If
        frm.ShowDialog()
    End Sub

    Public Sub setCodUtente(ByVal codUtente As String)
        TBCodUtente.Text = codUtente
        selecionarUtente(codUtente)
    End Sub

    Public Function validateScreenValues(ByRef Message As String) As Boolean

        Dim UtentesObjLocal As Utentes.UtentesObj = New Utentes.UtentesObj

        UtentesObjLocal.codUtente = TBCodUtente.Text
        UtentesObjLocal.nome = TBNome.Text
        UtentesObjLocal.autorizado = TBAutorizado.Text
        UtentesObjLocal.morada = TBMorada.Text
        UtentesObjLocal.complemento = TBComplemento.Text
        UtentesObjLocal.nif = TBNif.Text
        UtentesObjLocal.id = TBId.Text
        UtentesObjLocal.ss = TBNiss.Text
        UtentesObjLocal.pais = TBPais.Text
        If TBDataNasc.Text = String.Empty Then
            TBDataNasc.Text = "01/01/1900"
        End If
        Dim dataNascVal As Date
        If Not Date.TryParseExact(TBDataNasc.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, dataNascVal) Then
            Message = "Data de Nascimento inválida (use dd/mm/aaaa)"
            Return False
        End If
        UtentesObjLocal.dataNasc = dataNascVal
        UtentesObjLocal.telefone = TBTelefone.Text
        UtentesObjLocal.telemovel = TBTelemovel.Text
        UtentesObjLocal.estCivil = CBEstCivil.SelectedItem
        UtentesObjLocal.sexo = CBGenero.SelectedItem
        UtentesObjLocal.codFamilia = Math.Max(CBTipoFamilia.SelectedIndex, 0)

        Dim receitaVal As Decimal
        Dim despesaVal As Decimal
        If TBReceita.Text.Trim() = String.Empty Then TBReceita.Text = "0"
        If TBDespesa.Text.Trim() = String.Empty Then TBDespesa.Text = "0"
        If Not Decimal.TryParse(TBReceita.Text, receitaVal) Then
            Message = "Receita inválida"
            Return False
        End If
        If Not Decimal.TryParse(TBDespesa.Text, despesaVal) Then
            Message = "Despesa inválida"
            Return False
        End If
        UtentesObjLocal.receita = receitaVal
        UtentesObjLocal.despesa = despesaVal
        If TBDtEntrada.Text = String.Empty Then
            TBDtEntrada.Text = Format(DateTime.Now, "dd/MM/yyyy")
        End If
        Dim dataEntradaVal As Date
        If Not Date.TryParseExact(TBDtEntrada.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, dataEntradaVal) Then
            Message = "Data de Entrada inválida (use dd/mm/aaaa)"
            Return False
        End If
        UtentesObjLocal.dataEntrada = dataEntradaVal
        If TBDtSaida.Text = String.Empty Then
            TBDtSaida.Text = "31/12/9999"
        End If
        Dim dataSaidaVal As Date
        If Not Date.TryParseExact(TBDtSaida.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, dataSaidaVal) Then
            Message = "Data de Saída inválida (use dd/mm/aaaa)"
            Return False
        End If
        UtentesObjLocal.dataSaida = dataSaidaVal
        UtentesObjLocal.foto = PBFoto.Image
        UtentesObjLocal.fotoAut = PBFotoAut.Image

        setScreenFields(UtentesObjLocal)

        Return True

    End Function

    Public Sub FillScreenFields(ByVal UtentesObj As Utentes.UtentesObj)

        setScreenFields(UtentesObj)

        TBCodUtente.Text = UtentesObj.codUtente
        TBNome.Text = UtentesObj.nome
        TBAutorizado.Text = UtentesObj.autorizado
        TBMorada.Text = UtentesObj.morada
        TBComplemento.Text = UtentesObj.complemento
        TBNif.Text = UtentesObj.nif
        TBId.Text = UtentesObj.id
        TBNiss.Text = UtentesObj.ss
        TBPais.Text = UtentesObj.pais
        If UtentesObj.dataNasc = Nothing Then
            TBDataNasc.Text = String.Empty
        Else
            TBDataNasc.Text = Format(UtentesObj.dataNasc, "dd/MM/yyyy")
        End If
        TBTelefone.Text = UtentesObj.telefone
        TBTelemovel.Text = UtentesObj.telemovel
        CBEstCivil.SelectedItem = UtentesObj.estCivil
        CBGenero.SelectedItem = UtentesObj.sexo
        If UtentesObj.codFamilia >= 0 AndAlso UtentesObj.codFamilia < CBTipoFamilia.Items.Count Then
            CBTipoFamilia.SelectedIndex = UtentesObj.codFamilia
        Else
            CBTipoFamilia.SelectedIndex = 0
        End If
        TBReceita.Text = UtentesObj.receita
        TBDespesa.Text = UtentesObj.despesa
        If UtentesObj.dataEntrada = Nothing Then
            TBDtEntrada.Text = String.Empty
        Else
            TBDtEntrada.Text = Format(UtentesObj.dataEntrada, "dd/MM/yyyy")
        End If

        If UtentesObj.dataSaida = Nothing Then
            TBDtSaida.Text = String.Empty
        Else
            TBDtSaida.Text = Format(UtentesObj.dataSaida, "dd/MM/yyyy")
        End If


        PBFoto.Image = UtentesObj.foto
        PBFotoAut.Image = UtentesObj.fotoAut

        TBCodUtente.Focus()

    End Sub


    Public Sub ClearScreenFields()
        FillScreenFields(New Utentes.UtentesObj)
        TBNotasContainer.Text = String.Empty
        TBNota.Text = String.Empty
    End Sub

    ' ── Anotações tab ────────────────────────────────────────────────────────────
    Private Sub LoadNotas(ByVal codUtente As String)
        If codUtente.Trim() = String.Empty Then
            TBNotasContainer.Text = String.Empty
            Return
        End If
        Dim dt As DataTable = Notas.GetNotasByUtente(codUtente, returnCode, Message)
        If Not returnCode Then
            TBNotasContainer.Text = String.Empty
            Return
        End If

        Dim sb As New System.Text.StringBuilder
        For Each row As DataRow In dt.Rows
            sb.AppendLine("[" & CDate(row("dtCriacao")).ToString("dd/MM/yyyy HH:mm") & "] " & row("utilizador").ToString())
            sb.AppendLine(row("texto").ToString())
            sb.AppendLine()
        Next
        TBNotasContainer.Text = sb.ToString()
    End Sub

    Private Sub BtnAddNota_Click(sender As Object, e As EventArgs) Handles BtnAddNota.Click
        If TBNota.Text.Trim() = String.Empty Then
            MsgBox("Escreva uma nota antes de adicionar")
            Return
        End If
        If UtentesObj.codUtente = String.Empty Then
            MsgBox("Carregue um utente antes de adicionar uma nota")
            Return
        End If

        Dim n As New Notas.NotaObj With {
            .codUtente = UtentesObj.codUtente,
            .texto = TBNota.Text.Trim(),
            .dtCriacao = DateTime.Now,
            .utilizador = Environment.UserName
        }

        If Notas.AddNota(n, Message) Then
            TBNota.Text = String.Empty
            LoadNotas(UtentesObj.codUtente)
        End If
        MsgBox(Message)
    End Sub

    Private Sub BtnFoto_Click(sender As Object, e As EventArgs) Handles BtnFoto.Click
        If OPDFoto.ShowDialog = DialogResult.OK Then
            PBFoto.Image = Image.FromFile(OPDFoto.FileName)
        End If
    End Sub

    Private Sub BtnFotoAut_Click(sender As Object, e As EventArgs) Handles BtnFotoAut.Click
        If OPDFotoAut.ShowDialog = DialogResult.OK Then
            PBFotoAut.Image = Image.FromFile(OPDFotoAut.FileName)
        End If
    End Sub

    Private Sub BtnLimpar_Click_1(sender As Object, e As EventArgs) Handles BtnLimpar.Click
        ClearScreenFields()
        setScreen("I")
        TBCodUtente.Focus()
    End Sub

    Private Sub TBCodUtente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBCodUtente.KeyPress
        If AscW(e.KeyChar) = 13 Then
            selecionarUtente(TBCodUtente.Text)
        End If
    End Sub

    Private Sub selecionarUtente(ByVal codUtente)
        UtentesObj = Utentes.ReadUtente(codUtente, returnCode, Message)
        If returnCode = True Then
            FillScreenFields(UtentesObj)
            LoadNotas(UtentesObj.codUtente)
            setScreen("R")
        Else
            ClearScreenFields()
            setScreen("I")
            MsgBox(Message)
        End If
    End Sub

    Private Sub setScreenFields(UtentesObjIn As Utentes.UtentesObj)
        UtentesObj = UtentesObjIn
    End Sub

    Private Function getScreenFields() As Utentes.UtentesObj
        Return UtentesObj
    End Function

    Public Sub setMode(modeIn As Char)
        mode = modeIn
    End Sub

    Public Function getMode() As Char
        Return mode
    End Function

    Public Sub setScreen(mode As Char)

        setMode(mode)

        Dim codUtente As Boolean = True
        Dim campos_geral As Boolean = False
        Dim botoes_geral As Boolean = True
        Dim botao_novo As Boolean = True
        Dim botao_gravar As Boolean = False
        Dim botao_alterar As Boolean = False
        Dim botao_imprimir As Boolean = False

        Select Case mode

            Case "I"

                codUtente = True
                campos_geral = False
                botoes_geral = False
                botao_novo = True
                botao_gravar = False
                botao_alterar = False
                botao_imprimir = False

            Case "R"

                codUtente = False
                campos_geral = False
                botoes_geral = False
                botao_novo = True
                botao_gravar = False
                botao_alterar = True
                botao_imprimir = True

            Case "C"

                codUtente = False
                campos_geral = True
                botoes_geral = True
                botao_novo = False
                botao_gravar = True
                botao_alterar = False
                botao_imprimir = False

            Case "M"

                codUtente = False
                campos_geral = True
                botoes_geral = True
                botao_novo = False
                botao_gravar = True
                botao_alterar = False
                botao_imprimir = False

            Case Else

        End Select


        ' Campos

        TBCodUtente.Enabled = codUtente
        TBNome.Enabled = campos_geral
        TBAutorizado.Enabled = campos_geral
        TBMorada.Enabled = campos_geral
        TBComplemento.Enabled = campos_geral
        TBDataNasc.Enabled = campos_geral
        TBNif.Enabled = campos_geral
        TBNiss.Enabled = campos_geral
        TBId.Enabled = campos_geral
        TBReceita.Enabled = campos_geral
        TBDespesa.Enabled = campos_geral
        TBTelefone.Enabled = campos_geral
        TBTelemovel.Enabled = campos_geral
        TBPais.Enabled = campos_geral
        TBDtEntrada.Enabled = campos_geral
        TBDtSaida.Enabled = campos_geral
        CBEstCivil.Enabled = campos_geral
        CBGenero.Enabled = campos_geral
        CBTipoFamilia.Enabled = campos_geral

        'Botões
        BtnNovo.Enabled = botao_novo
        BtnAlterar.Enabled = botao_alterar
        BtnGravar.Enabled = botao_gravar
        BtnImprimirCartao.Enabled = botao_imprimir
        BtnFoto.Enabled = botoes_geral
        BtnFotoAut.Enabled = botoes_geral
        ' Notes attach to an already-saved Utente (FK), so they're available
        ' while viewing/editing an existing record, not while creating one.
        TBNota.Enabled = (mode = "R" OrElse mode = "M")
        BtnAddNota.Enabled = (mode = "R" OrElse mode = "M")
        BtnPesquisarUtentes.Enabled = codUtente
        BtnVerStock.Enabled = (mode = "R")
        BtnEliminarUtente.Enabled = (mode = "R")

    End Sub

    Private Sub BtnAlterar_Click(sender As Object, e As EventArgs) Handles BtnAlterar.Click
        setScreen("M")
    End Sub

    Private Sub BtnNovo_Click(sender As Object, e As EventArgs) Handles BtnNovo.Click

        ClearScreenFields()
        TBCodUtente.Text = Utentes.GetNewCodUtente(returnCode, Message)
        If returnCode = True Then
            setScreen("C")
            TBNome.Focus()
        Else
            MsgBox(Message)
        End If

    End Sub

    Private Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles BtnGravar.Click

        If validateScreenValues(Message) Then

            Select Case getMode()
                Case "C"
                    If Utentes.AddUtente(getScreenFields(), Message) Then
                        setScreen("R")
                        LoadTodosUtentes()
                        LoadNotas(getScreenFields().codUtente)
                    End If
                Case "M"
                    If Utentes.ModUtente(getScreenFields(), Message) Then
                        setScreen("R")
                        LoadTodosUtentes()
                    End If
                Case Else

            End Select

            MsgBox(Message)

        Else
            MsgBox(Message)
        End If


    End Sub

    Private Sub BtnPesquisarUtentes_Click(sender As Object, e As EventArgs) Handles BtnPesquisarUtentes.Click
        PesquisaUtenteModal.ShowDialog()
    End Sub

    Private Sub BtnEliminarUtente_Click(sender As Object, e As EventArgs) Handles BtnEliminarUtente.Click
        If UtentesObj.codUtente = String.Empty Then
            MsgBox("Carregue um utente antes de eliminar")
            Return
        End If

        If MsgBox("Eliminar o utente '" & UtentesObj.nome & "' (" & UtentesObj.codUtente & ")?",
                  MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Confirmar") <> MsgBoxResult.Yes Then
            Return
        End If

        If Utentes.DelUtente(UtentesObj, Message) Then
            ClearScreenFields()
            setScreen("I")
            LoadTodosUtentes()
        End If
        MsgBox(Message)
    End Sub

    ' ── Imprimir Cartão ──────────────────────────────────────────────────────────
    Private Sub BtnImprimirCartao_Click(sender As Object, e As EventArgs) Handles BtnImprimirCartao.Click
        If UtentesObj.codUtente = String.Empty Then
            MsgBox("Carregue um utente antes de imprimir o cartão")
            Return
        End If

        Dim pd As New PrintDocument()
        AddHandler pd.PrintPage, AddressOf DesenharCartaoUtente

        Using preview As New PrintPreviewDialog() With {
            .Document = pd,
            .Width = 650,
            .Height = 750
        }
            preview.ShowDialog()
        End Using
    End Sub

    Private Sub DesenharCartaoUtente(sender As Object, e As PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim x As Integer = 60
        Dim y As Integer = 60

        Using fontTitulo As New Font("Arial", 16, FontStyle.Bold)
            g.DrawString("Cartão GAF", fontTitulo, Brushes.Black, x, y)
        End Using
        y += 50

        If PBFoto.Image IsNot Nothing Then
            g.DrawImage(PBFoto.Image, x, y, 120, 140)
        End If

        Dim xTexto As Integer = x + 150
        Dim yTexto As Integer = y

        Using fontNormal As New Font("Arial", 12)
            g.DrawString("Código: " & TBCodUtente.Text, fontNormal, Brushes.Black, xTexto, yTexto)
            yTexto += 28
            g.DrawString("Nome: " & TBNome.Text, fontNormal, Brushes.Black, xTexto, yTexto)
            yTexto += 28
            g.DrawString("Autorizado(a): " & TBAutorizado.Text, fontNormal, Brushes.Black, xTexto, yTexto)
        End Using

        e.HasMorePages = False
    End Sub
End Class
