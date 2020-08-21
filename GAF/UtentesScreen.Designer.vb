<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UtentesScreen
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TBCodUtente = New System.Windows.Forms.TextBox()
        Me.LblCodUtente = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBNome = New System.Windows.Forms.TextBox()
        Me.LblMorada = New System.Windows.Forms.Label()
        Me.TBMorada = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBAutorizado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TPDadosPessoais = New System.Windows.Forms.TabPage()
        Me.TBDespesa = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TBReceita = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CBGenero = New System.Windows.Forms.ComboBox()
        Me.CBEstCivil = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TBTelemovel = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TBTelefone = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TBDataNasc = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TBPais = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TBNiss = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TBId = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TBNif = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TBComplemento = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TPAnotacoes = New System.Windows.Forms.TabPage()
        Me.TBNotasContainer = New System.Windows.Forms.TextBox()
        Me.BtnAddNota = New System.Windows.Forms.Button()
        Me.TBNota = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TPAgregado = New System.Windows.Forms.TabPage()
        Me.TPOutrosDados = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TBDtSaida = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TBDtEntrada = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GBUtente = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnFoto = New System.Windows.Forms.Button()
        Me.BtnFotoAut = New System.Windows.Forms.Button()
        Me.OPDFoto = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TSBotoes = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CBTipoFamilia = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.OPDFotoAut = New System.Windows.Forms.OpenFileDialog()
        Me.BtnPesquisarUtentes = New System.Windows.Forms.Button()
        Me.BtnNovo = New System.Windows.Forms.ToolStripButton()
        Me.BtnAlterar = New System.Windows.Forms.ToolStripButton()
        Me.BtnGravar = New System.Windows.Forms.ToolStripButton()
        Me.BtnLimpar = New System.Windows.Forms.ToolStripButton()
        Me.BtnImprimirCartao = New System.Windows.Forms.ToolStripButton()
        Me.PBFotoAut = New System.Windows.Forms.PictureBox()
        Me.PBFoto = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.TPDadosPessoais.SuspendLayout()
        Me.TPAnotacoes.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GBUtente.SuspendLayout()
        Me.TSBotoes.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PBFotoAut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TBCodUtente
        '
        Me.TBCodUtente.AcceptsReturn = True
        Me.TBCodUtente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBCodUtente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCodUtente.Location = New System.Drawing.Point(147, 50)
        Me.TBCodUtente.Margin = New System.Windows.Forms.Padding(2)
        Me.TBCodUtente.MaxLength = 4
        Me.TBCodUtente.Name = "TBCodUtente"
        Me.TBCodUtente.Size = New System.Drawing.Size(51, 21)
        Me.TBCodUtente.TabIndex = 0
        '
        'LblCodUtente
        '
        Me.LblCodUtente.AutoSize = True
        Me.LblCodUtente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodUtente.Location = New System.Drawing.Point(62, 55)
        Me.LblCodUtente.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblCodUtente.Name = "LblCodUtente"
        Me.LblCodUtente.Size = New System.Drawing.Size(71, 15)
        Me.LblCodUtente.TabIndex = 1
        Me.LblCodUtente.Text = "Cód. Utente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nome"
        '
        'TBNome
        '
        Me.TBNome.AcceptsReturn = True
        Me.TBNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBNome.Location = New System.Drawing.Point(98, 24)
        Me.TBNome.Margin = New System.Windows.Forms.Padding(2)
        Me.TBNome.MaxLength = 80
        Me.TBNome.Name = "TBNome"
        Me.TBNome.Size = New System.Drawing.Size(504, 21)
        Me.TBNome.TabIndex = 2
        '
        'LblMorada
        '
        Me.LblMorada.AutoSize = True
        Me.LblMorada.Location = New System.Drawing.Point(11, 21)
        Me.LblMorada.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblMorada.Name = "LblMorada"
        Me.LblMorada.Size = New System.Drawing.Size(50, 15)
        Me.LblMorada.TabIndex = 6
        Me.LblMorada.Text = "Morada"
        '
        'TBMorada
        '
        Me.TBMorada.AcceptsReturn = True
        Me.TBMorada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBMorada.Location = New System.Drawing.Point(84, 18)
        Me.TBMorada.Margin = New System.Windows.Forms.Padding(2)
        Me.TBMorada.MaxLength = 80
        Me.TBMorada.Name = "TBMorada"
        Me.TBMorada.Size = New System.Drawing.Size(514, 21)
        Me.TBMorada.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 51)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Autorizado(a)"
        '
        'TBAutorizado
        '
        Me.TBAutorizado.AcceptsReturn = True
        Me.TBAutorizado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBAutorizado.Location = New System.Drawing.Point(99, 48)
        Me.TBAutorizado.Margin = New System.Windows.Forms.Padding(2)
        Me.TBAutorizado.MaxLength = 80
        Me.TBAutorizado.Name = "TBAutorizado"
        Me.TBAutorizado.Size = New System.Drawing.Size(503, 21)
        Me.TBAutorizado.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(729, 22)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Titular"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TPDadosPessoais)
        Me.TabControl1.Controls.Add(Me.TPAnotacoes)
        Me.TabControl1.Controls.Add(Me.TPAgregado)
        Me.TabControl1.Controls.Add(Me.TPOutrosDados)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(49, 187)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(628, 218)
        Me.TabControl1.TabIndex = 12
        '
        'TPDadosPessoais
        '
        Me.TPDadosPessoais.Controls.Add(Me.TBDespesa)
        Me.TPDadosPessoais.Controls.Add(Me.Label20)
        Me.TPDadosPessoais.Controls.Add(Me.TBReceita)
        Me.TPDadosPessoais.Controls.Add(Me.Label19)
        Me.TPDadosPessoais.Controls.Add(Me.CBGenero)
        Me.TPDadosPessoais.Controls.Add(Me.CBEstCivil)
        Me.TPDadosPessoais.Controls.Add(Me.Label14)
        Me.TPDadosPessoais.Controls.Add(Me.TBTelemovel)
        Me.TPDadosPessoais.Controls.Add(Me.Label13)
        Me.TPDadosPessoais.Controls.Add(Me.TBTelefone)
        Me.TPDadosPessoais.Controls.Add(Me.Label12)
        Me.TPDadosPessoais.Controls.Add(Me.Label11)
        Me.TPDadosPessoais.Controls.Add(Me.TBDataNasc)
        Me.TPDadosPessoais.Controls.Add(Me.Label9)
        Me.TPDadosPessoais.Controls.Add(Me.TBPais)
        Me.TPDadosPessoais.Controls.Add(Me.Label8)
        Me.TPDadosPessoais.Controls.Add(Me.TBNiss)
        Me.TPDadosPessoais.Controls.Add(Me.Label7)
        Me.TPDadosPessoais.Controls.Add(Me.TBId)
        Me.TPDadosPessoais.Controls.Add(Me.Label6)
        Me.TPDadosPessoais.Controls.Add(Me.TBNif)
        Me.TPDadosPessoais.Controls.Add(Me.Label5)
        Me.TPDadosPessoais.Controls.Add(Me.TBComplemento)
        Me.TPDadosPessoais.Controls.Add(Me.Label4)
        Me.TPDadosPessoais.Controls.Add(Me.TBMorada)
        Me.TPDadosPessoais.Controls.Add(Me.LblMorada)
        Me.TPDadosPessoais.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPDadosPessoais.Location = New System.Drawing.Point(4, 24)
        Me.TPDadosPessoais.Margin = New System.Windows.Forms.Padding(2)
        Me.TPDadosPessoais.Name = "TPDadosPessoais"
        Me.TPDadosPessoais.Padding = New System.Windows.Forms.Padding(2)
        Me.TPDadosPessoais.Size = New System.Drawing.Size(620, 190)
        Me.TPDadosPessoais.TabIndex = 1
        Me.TPDadosPessoais.Text = "Dados Pessoais"
        Me.TPDadosPessoais.UseVisualStyleBackColor = True
        '
        'TBDespesa
        '
        Me.TBDespesa.AcceptsReturn = True
        Me.TBDespesa.Location = New System.Drawing.Point(270, 143)
        Me.TBDespesa.Margin = New System.Windows.Forms.Padding(2)
        Me.TBDespesa.MaxLength = 10
        Me.TBDespesa.Name = "TBDespesa"
        Me.TBDespesa.Size = New System.Drawing.Size(92, 21)
        Me.TBDespesa.TabIndex = 31
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(204, 146)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(62, 15)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "Despesas"
        '
        'TBReceita
        '
        Me.TBReceita.AcceptsReturn = True
        Me.TBReceita.Location = New System.Drawing.Point(84, 143)
        Me.TBReceita.Margin = New System.Windows.Forms.Padding(2)
        Me.TBReceita.MaxLength = 10
        Me.TBReceita.Name = "TBReceita"
        Me.TBReceita.Size = New System.Drawing.Size(92, 21)
        Me.TBReceita.TabIndex = 29
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(11, 146)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 15)
        Me.Label19.TabIndex = 30
        Me.Label19.Text = "Receitas"
        '
        'CBGenero
        '
        Me.CBGenero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGenero.FormattingEnabled = True
        Me.CBGenero.Items.AddRange(New Object() {"", "Masculino", "Feminino"})
        Me.CBGenero.Location = New System.Drawing.Point(506, 118)
        Me.CBGenero.Name = "CBGenero"
        Me.CBGenero.Size = New System.Drawing.Size(92, 21)
        Me.CBGenero.TabIndex = 28
        '
        'CBEstCivil
        '
        Me.CBEstCivil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBEstCivil.FormattingEnabled = True
        Me.CBEstCivil.Items.AddRange(New Object() {"", "Casado(a)", "Solteiro(a)", "Viúvo(a)", "Divorciado(a)", "Outro(a)"})
        Me.CBEstCivil.Location = New System.Drawing.Point(84, 93)
        Me.CBEstCivil.Name = "CBEstCivil"
        Me.CBEstCivil.Size = New System.Drawing.Size(128, 21)
        Me.CBEstCivil.TabIndex = 27
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(453, 121)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 15)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Género"
        '
        'TBTelemovel
        '
        Me.TBTelemovel.AcceptsReturn = True
        Me.TBTelemovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBTelemovel.Location = New System.Drawing.Point(470, 93)
        Me.TBTelemovel.Margin = New System.Windows.Forms.Padding(2)
        Me.TBTelemovel.MaxLength = 15
        Me.TBTelemovel.Name = "TBTelemovel"
        Me.TBTelemovel.Size = New System.Drawing.Size(128, 21)
        Me.TBTelemovel.TabIndex = 23
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(402, 96)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 15)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Telemóvel"
        '
        'TBTelefone
        '
        Me.TBTelefone.AcceptsReturn = True
        Me.TBTelefone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBTelefone.Location = New System.Drawing.Point(270, 93)
        Me.TBTelefone.Margin = New System.Windows.Forms.Padding(2)
        Me.TBTelefone.MaxLength = 15
        Me.TBTelefone.Name = "TBTelefone"
        Me.TBTelefone.Size = New System.Drawing.Size(128, 21)
        Me.TBTelefone.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(216, 96)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 15)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Telefone"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 96)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 15)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Estado Civil"
        '
        'TBDataNasc
        '
        Me.TBDataNasc.AcceptsReturn = True
        Me.TBDataNasc.Location = New System.Drawing.Point(84, 118)
        Me.TBDataNasc.Margin = New System.Windows.Forms.Padding(2)
        Me.TBDataNasc.MaxLength = 10
        Me.TBDataNasc.Name = "TBDataNasc"
        Me.TBDataNasc.Size = New System.Drawing.Size(92, 21)
        Me.TBDataNasc.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 121)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 15)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Data Nasc."
        '
        'TBPais
        '
        Me.TBPais.AcceptsReturn = True
        Me.TBPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBPais.Location = New System.Drawing.Point(270, 118)
        Me.TBPais.Margin = New System.Windows.Forms.Padding(2)
        Me.TBPais.MaxLength = 50
        Me.TBPais.Name = "TBPais"
        Me.TBPais.Size = New System.Drawing.Size(161, 21)
        Me.TBPais.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(206, 121)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "País Nasc."
        '
        'TBNiss
        '
        Me.TBNiss.AcceptsReturn = True
        Me.TBNiss.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBNiss.Location = New System.Drawing.Point(470, 68)
        Me.TBNiss.Margin = New System.Windows.Forms.Padding(2)
        Me.TBNiss.MaxLength = 11
        Me.TBNiss.Name = "TBNiss"
        Me.TBNiss.Size = New System.Drawing.Size(128, 21)
        Me.TBNiss.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(431, 71)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "NISS"
        '
        'TBId
        '
        Me.TBId.AcceptsReturn = True
        Me.TBId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBId.Location = New System.Drawing.Point(270, 68)
        Me.TBId.Margin = New System.Windows.Forms.Padding(2)
        Me.TBId.MaxLength = 15
        Me.TBId.Name = "TBId"
        Me.TBId.Size = New System.Drawing.Size(128, 21)
        Me.TBId.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(229, 71)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "BI/CC"
        '
        'TBNif
        '
        Me.TBNif.AcceptsReturn = True
        Me.TBNif.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBNif.Location = New System.Drawing.Point(84, 68)
        Me.TBNif.Margin = New System.Windows.Forms.Padding(2)
        Me.TBNif.MaxLength = 9
        Me.TBNif.Name = "TBNif"
        Me.TBNif.Size = New System.Drawing.Size(128, 21)
        Me.TBNif.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 72)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "NIF"
        '
        'TBComplemento
        '
        Me.TBComplemento.AcceptsReturn = True
        Me.TBComplemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBComplemento.Location = New System.Drawing.Point(84, 43)
        Me.TBComplemento.Margin = New System.Windows.Forms.Padding(2)
        Me.TBComplemento.MaxLength = 80
        Me.TBComplemento.Name = "TBComplemento"
        Me.TBComplemento.Size = New System.Drawing.Size(514, 21)
        Me.TBComplemento.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 45)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Compl."
        '
        'TPAnotacoes
        '
        Me.TPAnotacoes.Controls.Add(Me.TBNotasContainer)
        Me.TPAnotacoes.Controls.Add(Me.BtnAddNota)
        Me.TPAnotacoes.Controls.Add(Me.TBNota)
        Me.TPAnotacoes.Controls.Add(Me.Label17)
        Me.TPAnotacoes.Location = New System.Drawing.Point(4, 24)
        Me.TPAnotacoes.Margin = New System.Windows.Forms.Padding(2)
        Me.TPAnotacoes.Name = "TPAnotacoes"
        Me.TPAnotacoes.Padding = New System.Windows.Forms.Padding(2)
        Me.TPAnotacoes.Size = New System.Drawing.Size(620, 190)
        Me.TPAnotacoes.TabIndex = 0
        Me.TPAnotacoes.Text = "Anotações"
        Me.TPAnotacoes.UseVisualStyleBackColor = True
        '
        'TBNotasContainer
        '
        Me.TBNotasContainer.Location = New System.Drawing.Point(17, 54)
        Me.TBNotasContainer.Multiline = True
        Me.TBNotasContainer.Name = "TBNotasContainer"
        Me.TBNotasContainer.ReadOnly = True
        Me.TBNotasContainer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBNotasContainer.Size = New System.Drawing.Size(580, 116)
        Me.TBNotasContainer.TabIndex = 10
        '
        'BtnAddNota
        '
        Me.BtnAddNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddNota.Location = New System.Drawing.Point(526, 18)
        Me.BtnAddNota.Name = "BtnAddNota"
        Me.BtnAddNota.Size = New System.Drawing.Size(72, 21)
        Me.BtnAddNota.TabIndex = 9
        Me.BtnAddNota.Text = "Adicionar"
        Me.BtnAddNota.UseVisualStyleBackColor = True
        '
        'TBNota
        '
        Me.TBNota.AcceptsReturn = True
        Me.TBNota.Location = New System.Drawing.Point(84, 18)
        Me.TBNota.Margin = New System.Windows.Forms.Padding(2)
        Me.TBNota.MaxLength = 80
        Me.TBNota.Name = "TBNota"
        Me.TBNota.Size = New System.Drawing.Size(437, 21)
        Me.TBNota.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 21)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 15)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Nota"
        '
        'TPAgregado
        '
        Me.TPAgregado.Location = New System.Drawing.Point(4, 24)
        Me.TPAgregado.Margin = New System.Windows.Forms.Padding(2)
        Me.TPAgregado.Name = "TPAgregado"
        Me.TPAgregado.Size = New System.Drawing.Size(620, 190)
        Me.TPAgregado.TabIndex = 2
        Me.TPAgregado.Text = "Agregado"
        Me.TPAgregado.UseVisualStyleBackColor = True
        '
        'TPOutrosDados
        '
        Me.TPOutrosDados.Location = New System.Drawing.Point(4, 24)
        Me.TPOutrosDados.Margin = New System.Windows.Forms.Padding(2)
        Me.TPOutrosDados.Name = "TPOutrosDados"
        Me.TPOutrosDados.Size = New System.Drawing.Size(620, 190)
        Me.TPOutrosDados.TabIndex = 3
        Me.TPOutrosDados.Text = "Outros Dados"
        Me.TPOutrosDados.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TBDtSaida)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.TBDtEntrada)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(691, 370)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(230, 99)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Registo GAF"
        '
        'TBDtSaida
        '
        Me.TBDtSaida.AcceptsReturn = True
        Me.TBDtSaida.Location = New System.Drawing.Point(106, 56)
        Me.TBDtSaida.Margin = New System.Windows.Forms.Padding(2)
        Me.TBDtSaida.MaxLength = 10
        Me.TBDtSaida.Name = "TBDtSaida"
        Me.TBDtSaida.Size = New System.Drawing.Size(92, 21)
        Me.TBDtSaida.TabIndex = 32
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(18, 59)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 15)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Data Saída"
        '
        'TBDtEntrada
        '
        Me.TBDtEntrada.AcceptsReturn = True
        Me.TBDtEntrada.Location = New System.Drawing.Point(106, 32)
        Me.TBDtEntrada.Margin = New System.Windows.Forms.Padding(2)
        Me.TBDtEntrada.MaxLength = 10
        Me.TBDtEntrada.Name = "TBDtEntrada"
        Me.TBDtEntrada.Size = New System.Drawing.Size(92, 21)
        Me.TBDtEntrada.TabIndex = 30
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(18, 35)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 15)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Data Entrada"
        '
        'GBUtente
        '
        Me.GBUtente.Controls.Add(Me.Label2)
        Me.GBUtente.Controls.Add(Me.TBAutorizado)
        Me.GBUtente.Controls.Add(Me.Label1)
        Me.GBUtente.Controls.Add(Me.TBNome)
        Me.GBUtente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBUtente.Location = New System.Drawing.Point(49, 75)
        Me.GBUtente.Margin = New System.Windows.Forms.Padding(2)
        Me.GBUtente.Name = "GBUtente"
        Me.GBUtente.Padding = New System.Windows.Forms.Padding(2)
        Me.GBUtente.Size = New System.Drawing.Size(624, 93)
        Me.GBUtente.TabIndex = 13
        Me.GBUtente.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(836, 42)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Autorizado(a)"
        '
        'BtnFoto
        '
        Me.BtnFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFoto.Location = New System.Drawing.Point(725, 172)
        Me.BtnFoto.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnFoto.Name = "BtnFoto"
        Me.BtnFoto.Size = New System.Drawing.Size(49, 20)
        Me.BtnFoto.TabIndex = 16
        Me.BtnFoto.Text = "Carregar"
        Me.BtnFoto.UseVisualStyleBackColor = True
        '
        'BtnFotoAut
        '
        Me.BtnFotoAut.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFotoAut.Location = New System.Drawing.Point(848, 172)
        Me.BtnFotoAut.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnFotoAut.Name = "BtnFotoAut"
        Me.BtnFotoAut.Size = New System.Drawing.Size(49, 20)
        Me.BtnFotoAut.TabIndex = 17
        Me.BtnFotoAut.Text = "Carregar"
        Me.BtnFotoAut.UseVisualStyleBackColor = True
        '
        'OPDFoto
        '
        Me.OPDFoto.Filter = "Image Files|*.jpg;*.png;*.bmp"
        '
        'GroupBox2
        '
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(691, 211)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(230, 144)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Última Entrega"
        '
        'TSBotoes
        '
        Me.TSBotoes.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.TSBotoes.Dock = System.Windows.Forms.DockStyle.Left
        Me.TSBotoes.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.TSBotoes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNovo, Me.ToolStripSeparator4, Me.BtnAlterar, Me.ToolStripSeparator1, Me.BtnGravar, Me.ToolStripSeparator2, Me.BtnLimpar, Me.ToolStripSeparator3, Me.BtnImprimirCartao})
        Me.TSBotoes.Location = New System.Drawing.Point(0, 0)
        Me.TSBotoes.Name = "TSBotoes"
        Me.TSBotoes.Size = New System.Drawing.Size(37, 529)
        Me.TSBotoes.TabIndex = 21
        Me.TSBotoes.Text = "ToolStrip2"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(34, 6)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(34, 6)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(34, 6)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(34, 6)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(13, 22)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 15)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "Tipo Família"
        '
        'CBTipoFamilia
        '
        Me.CBTipoFamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTipoFamilia.FormattingEnabled = True
        Me.CBTipoFamilia.Items.AddRange(New Object() {"", "Casado(a)", "Solteiro(a)", "Viúvo(a)", "Divorciado(a)", "Outro(a)"})
        Me.CBTipoFamilia.Location = New System.Drawing.Point(98, 19)
        Me.CBTipoFamilia.Name = "CBTipoFamilia"
        Me.CBTipoFamilia.Size = New System.Drawing.Size(302, 23)
        Me.CBTipoFamilia.TabIndex = 29
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CBTipoFamilia)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Location = New System.Drawing.Point(49, 416)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(623, 53)
        Me.GroupBox4.TabIndex = 30
        Me.GroupBox4.TabStop = False
        '
        'OPDFotoAut
        '
        Me.OPDFotoAut.Filter = "Image Files|*.jpg;*.png;*.bmp"
        '
        'BtnPesquisarUtentes
        '
        Me.BtnPesquisarUtentes.Image = Global.GAF.My.Resources.Resource1.icons8_search_16
        Me.BtnPesquisarUtentes.Location = New System.Drawing.Point(203, 50)
        Me.BtnPesquisarUtentes.Name = "BtnPesquisarUtentes"
        Me.BtnPesquisarUtentes.Size = New System.Drawing.Size(31, 21)
        Me.BtnPesquisarUtentes.TabIndex = 31
        Me.BtnPesquisarUtentes.UseVisualStyleBackColor = True
        '
        'BtnNovo
        '
        Me.BtnNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNovo.Image = Global.GAF.My.Resources.Resource1.icons8_new_copy_48
        Me.BtnNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNovo.Name = "BtnNovo"
        Me.BtnNovo.Size = New System.Drawing.Size(34, 36)
        Me.BtnNovo.Text = "ToolStripButton1"
        Me.BtnNovo.ToolTipText = "Novo Utente"
        '
        'BtnAlterar
        '
        Me.BtnAlterar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnAlterar.Image = Global.GAF.My.Resources.Resource1.icons8_edit_file_48
        Me.BtnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAlterar.Name = "BtnAlterar"
        Me.BtnAlterar.Size = New System.Drawing.Size(34, 36)
        Me.BtnAlterar.Text = "ToolStripButton1"
        Me.BtnAlterar.ToolTipText = "Alterar"
        '
        'BtnGravar
        '
        Me.BtnGravar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnGravar.Image = Global.GAF.My.Resources.Resource1.icons8_save_48
        Me.BtnGravar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGravar.Name = "BtnGravar"
        Me.BtnGravar.Size = New System.Drawing.Size(34, 36)
        Me.BtnGravar.Text = "ToolStripButton2"
        Me.BtnGravar.ToolTipText = "Gravar"
        '
        'BtnLimpar
        '
        Me.BtnLimpar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLimpar.Image = Global.GAF.My.Resources.Resource1.icons8_broom_48
        Me.BtnLimpar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLimpar.Name = "BtnLimpar"
        Me.BtnLimpar.Size = New System.Drawing.Size(34, 36)
        Me.BtnLimpar.Text = "ToolStripButton3"
        Me.BtnLimpar.ToolTipText = "Limpar Campos"
        '
        'BtnImprimirCartao
        '
        Me.BtnImprimirCartao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnImprimirCartao.Image = Global.GAF.My.Resources.Resource1.icons8_identification_documents_48
        Me.BtnImprimirCartao.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImprimirCartao.Name = "BtnImprimirCartao"
        Me.BtnImprimirCartao.Size = New System.Drawing.Size(34, 36)
        Me.BtnImprimirCartao.Text = "ToolStripButton4"
        Me.BtnImprimirCartao.ToolTipText = "Imprimir Cartão"
        '
        'PBFotoAut
        '
        Me.PBFotoAut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBFotoAut.Image = Global.GAF.My.Resources.Resource1.foto_default
        Me.PBFotoAut.InitialImage = Global.GAF.My.Resources.Resource1.foto_default
        Me.PBFotoAut.Location = New System.Drawing.Point(826, 57)
        Me.PBFotoAut.Margin = New System.Windows.Forms.Padding(2)
        Me.PBFotoAut.Name = "PBFotoAut"
        Me.PBFotoAut.Size = New System.Drawing.Size(95, 111)
        Me.PBFotoAut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBFotoAut.TabIndex = 14
        Me.PBFotoAut.TabStop = False
        '
        'PBFoto
        '
        Me.PBFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBFoto.Image = Global.GAF.My.Resources.Resource1.foto_default
        Me.PBFoto.InitialImage = Global.GAF.My.Resources.Resource1.foto_default
        Me.PBFoto.Location = New System.Drawing.Point(691, 37)
        Me.PBFoto.Margin = New System.Windows.Forms.Padding(2)
        Me.PBFoto.Name = "PBFoto"
        Me.PBFoto.Size = New System.Drawing.Size(116, 131)
        Me.PBFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBFoto.TabIndex = 8
        Me.PBFoto.TabStop = False
        '
        'UtentesScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 529)
        Me.Controls.Add(Me.BtnPesquisarUtentes)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.TSBotoes)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnFotoAut)
        Me.Controls.Add(Me.BtnFoto)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.PBFotoAut)
        Me.Controls.Add(Me.GBUtente)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PBFoto)
        Me.Controls.Add(Me.LblCodUtente)
        Me.Controls.Add(Me.TBCodUtente)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "UtentesScreen"
        Me.Text = "Utentes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TPDadosPessoais.ResumeLayout(False)
        Me.TPDadosPessoais.PerformLayout()
        Me.TPAnotacoes.ResumeLayout(False)
        Me.TPAnotacoes.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GBUtente.ResumeLayout(False)
        Me.GBUtente.PerformLayout()
        Me.TSBotoes.ResumeLayout(False)
        Me.TSBotoes.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PBFotoAut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TBCodUtente As TextBox
    Friend WithEvents LblCodUtente As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TBNome As TextBox
    Friend WithEvents LblMorada As Label
    Friend WithEvents TBMorada As TextBox
    Friend WithEvents PBFoto As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TBAutorizado As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TPAnotacoes As TabPage
    Friend WithEvents TPDadosPessoais As TabPage
    Friend WithEvents TPAgregado As TabPage
    Friend WithEvents TPOutrosDados As TabPage
    Friend WithEvents TBId As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TBNif As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TBComplemento As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TBPais As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TBNiss As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GBUtente As GroupBox
    Friend WithEvents TBDataNasc As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents PBFotoAut As PictureBox
    Friend WithEvents BtnFoto As Button
    Friend WithEvents BtnFotoAut As Button
    Friend WithEvents OPDFoto As OpenFileDialog
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TSBotoes As ToolStrip
    Friend WithEvents BtnAlterar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BtnGravar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BtnLimpar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BtnImprimirCartao As ToolStripButton
    Friend WithEvents TBTelemovel As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TBTelefone As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents CBGenero As ComboBox
    Friend WithEvents CBEstCivil As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents BtnNovo As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents TBNotasContainer As TextBox
    Friend WithEvents BtnAddNota As Button
    Friend WithEvents TBNota As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TBDtSaida As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TBDtEntrada As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents CBTipoFamilia As ComboBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TBDespesa As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TBReceita As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents OPDFotoAut As OpenFileDialog
    Friend WithEvents BtnPesquisarUtentes As Button
End Class
