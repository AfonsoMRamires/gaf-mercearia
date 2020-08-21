
Public Class UtentesScreen

    Dim Utentes As Utentes = New Utentes
    Dim returnCode As Boolean = False
    Dim Message As String = String.Empty
    Dim UtentesObj As Utentes.UtentesObj = New Utentes.UtentesObj
    Dim mode As Char = "I"

    Private Sub UtentesScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim toolTip As ToolTip = New ToolTip
        toolTip.SetToolTip(BtnPesquisarUtentes, "Procurar Utente por Nome")

        setScreen("I")
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
        UtentesObjLocal.dataNasc = TBDataNasc.Text
        UtentesObjLocal.telefone = TBTelefone.Text
        UtentesObjLocal.telemovel = TBTelemovel.Text
        UtentesObjLocal.estCivil = CBEstCivil.SelectedItem
        UtentesObjLocal.sexo = CBGenero.SelectedItem
        UtentesObjLocal.receita = TBReceita.Text
        UtentesObjLocal.despesa = TBDespesa.Text
        If TBDtEntrada.Text = String.Empty Then
            TBDtEntrada.Text = Format(DateTime.Now, "dd/MM/yyyy")
        End If
        UtentesObjLocal.dataEntrada = TBDtEntrada.Text
        If TBDtSaida.Text = String.Empty Then
            TBDtSaida.Text = "31/12/9999"
        End If
        UtentesObjLocal.dataSaida = TBDtSaida.Text
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
            TBDataNasc.Text = UtentesObj.dataNasc
        End If
        TBTelefone.Text = UtentesObj.telefone
        TBTelemovel.Text = UtentesObj.telemovel
        CBEstCivil.SelectedItem = UtentesObj.estCivil
        CBGenero.SelectedItem = UtentesObj.sexo
        TBReceita.Text = UtentesObj.receita
        TBDespesa.Text = UtentesObj.despesa
        If UtentesObj.dataEntrada = Nothing Then
            TBDtEntrada.Text = String.Empty
        Else
            TBDtEntrada.Text = UtentesObj.dataEntrada
        End If

        If UtentesObj.dataSaida = Nothing Then
            TBDtSaida.Text = String.Empty
        Else
            TBDtSaida.Text = UtentesObj.dataSaida
        End If


        PBFoto.Image = UtentesObj.foto
        PBFotoAut.Image = UtentesObj.fotoAut

        TBCodUtente.Focus()

    End Sub


    Public Sub ClearScreenFields()
        FillScreenFields(New Utentes.UtentesObj)
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
        TBNota.Enabled = campos_geral
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
        BtnAddNota.Enabled = botoes_geral
        BtnPesquisarUtentes.Enabled = codUtente

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
                    End If
                Case "M"
                    If Utentes.ModUtente(getScreenFields(), Message) Then
                        setScreen("R")
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
End Class
