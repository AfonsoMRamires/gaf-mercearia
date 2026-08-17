<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TCStock = New System.Windows.Forms.TabControl()
        Me.TPSaida = New System.Windows.Forms.TabPage()
        Me.TPHistorico = New System.Windows.Forms.TabPage()
        Me.LblCodUtenteHist = New System.Windows.Forms.Label()
        Me.TBCodUtenteHist = New System.Windows.Forms.TextBox()
        Me.BtnProcurarHist = New System.Windows.Forms.Button()
        Me.DGVHistorico = New System.Windows.Forms.DataGridView()
        Me.LblUtenteSaida = New System.Windows.Forms.Label()
        Me.TBUtenteSaida = New System.Windows.Forms.TextBox()
        Me.BtnProcurarUtenteSaida = New System.Windows.Forms.Button()
        Me.LblNomeUtenteSaida = New System.Windows.Forms.Label()
        Me.LblArtigoSaida = New System.Windows.Forms.Label()
        Me.CBArtigoSaida = New System.Windows.Forms.ComboBox()
        Me.LblQuantidadeSaida = New System.Windows.Forms.Label()
        Me.NUDQuantidadeSaida = New System.Windows.Forms.NumericUpDown()
        Me.LblMotivoSaida = New System.Windows.Forms.Label()
        Me.TBMotivoSaida = New System.Windows.Forms.TextBox()
        Me.BtnRegistarSaida = New System.Windows.Forms.Button()
        Me.LblDataDeHist = New System.Windows.Forms.Label()
        Me.DTPDataDeHist = New System.Windows.Forms.DateTimePicker()
        Me.LblDataAteHist = New System.Windows.Forms.Label()
        Me.DTPDataAteHist = New System.Windows.Forms.DateTimePicker()
        Me.LblDescricaoHist = New System.Windows.Forms.Label()
        Me.TBDescricaoHist = New System.Windows.Forms.TextBox()
        Me.LblTipoHist = New System.Windows.Forms.Label()
        Me.CBTipoHist = New System.Windows.Forms.ComboBox()
        Me.BtnFiltrarHist = New System.Windows.Forms.Button()
        Me.TCStock.SuspendLayout()
        Me.TPSaida.SuspendLayout()
        Me.TPHistorico.SuspendLayout()
        CType(Me.DGVHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDQuantidadeSaida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TCStock
        '
        Me.TCStock.Controls.Add(Me.TPSaida)
        Me.TCStock.Controls.Add(Me.TPHistorico)
        Me.TCStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCStock.Location = New System.Drawing.Point(0, 0)
        Me.TCStock.Name = "TCStock"
        Me.TCStock.SelectedIndex = 0
        Me.TCStock.Size = New System.Drawing.Size(884, 561)
        Me.TCStock.TabIndex = 0
        '
        'TPSaida
        '
        Me.TPSaida.Controls.Add(Me.LblUtenteSaida)
        Me.TPSaida.Controls.Add(Me.TBUtenteSaida)
        Me.TPSaida.Controls.Add(Me.BtnProcurarUtenteSaida)
        Me.TPSaida.Controls.Add(Me.LblNomeUtenteSaida)
        Me.TPSaida.Controls.Add(Me.LblArtigoSaida)
        Me.TPSaida.Controls.Add(Me.CBArtigoSaida)
        Me.TPSaida.Controls.Add(Me.LblQuantidadeSaida)
        Me.TPSaida.Controls.Add(Me.NUDQuantidadeSaida)
        Me.TPSaida.Controls.Add(Me.LblMotivoSaida)
        Me.TPSaida.Controls.Add(Me.TBMotivoSaida)
        Me.TPSaida.Controls.Add(Me.BtnRegistarSaida)
        Me.TPSaida.Location = New System.Drawing.Point(4, 22)
        Me.TPSaida.Name = "TPSaida"
        Me.TPSaida.Padding = New System.Windows.Forms.Padding(3)
        Me.TPSaida.Size = New System.Drawing.Size(876, 535)
        Me.TPSaida.TabIndex = 0
        Me.TPSaida.Text = "Saída de Stock"
        Me.TPSaida.UseVisualStyleBackColor = True
        '
        'LblUtenteSaida
        '
        Me.LblUtenteSaida.AutoSize = True
        Me.LblUtenteSaida.Location = New System.Drawing.Point(20, 25)
        Me.LblUtenteSaida.Name = "LblUtenteSaida"
        Me.LblUtenteSaida.Size = New System.Drawing.Size(120, 13)
        Me.LblUtenteSaida.TabIndex = 0
        Me.LblUtenteSaida.Text = "Cód. Utente:"
        '
        'TBUtenteSaida
        '
        Me.TBUtenteSaida.Location = New System.Drawing.Point(23, 41)
        Me.TBUtenteSaida.Name = "TBUtenteSaida"
        Me.TBUtenteSaida.Size = New System.Drawing.Size(100, 20)
        Me.TBUtenteSaida.TabIndex = 1
        '
        'BtnProcurarUtenteSaida
        '
        Me.BtnProcurarUtenteSaida.Location = New System.Drawing.Point(129, 40)
        Me.BtnProcurarUtenteSaida.Name = "BtnProcurarUtenteSaida"
        Me.BtnProcurarUtenteSaida.Size = New System.Drawing.Size(90, 22)
        Me.BtnProcurarUtenteSaida.TabIndex = 2
        Me.BtnProcurarUtenteSaida.Text = "Procurar..."
        Me.BtnProcurarUtenteSaida.UseVisualStyleBackColor = True
        '
        'LblNomeUtenteSaida
        '
        Me.LblNomeUtenteSaida.AutoSize = True
        Me.LblNomeUtenteSaida.Location = New System.Drawing.Point(240, 45)
        Me.LblNomeUtenteSaida.Name = "LblNomeUtenteSaida"
        Me.LblNomeUtenteSaida.Size = New System.Drawing.Size(0, 13)
        Me.LblNomeUtenteSaida.TabIndex = 3
        '
        'LblArtigoSaida
        '
        Me.LblArtigoSaida.AutoSize = True
        Me.LblArtigoSaida.Location = New System.Drawing.Point(20, 85)
        Me.LblArtigoSaida.Name = "LblArtigoSaida"
        Me.LblArtigoSaida.Size = New System.Drawing.Size(40, 13)
        Me.LblArtigoSaida.TabIndex = 4
        Me.LblArtigoSaida.Text = "Artigo:"
        '
        'CBArtigoSaida
        '
        Me.CBArtigoSaida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBArtigoSaida.FormattingEnabled = True
        Me.CBArtigoSaida.Location = New System.Drawing.Point(23, 101)
        Me.CBArtigoSaida.Name = "CBArtigoSaida"
        Me.CBArtigoSaida.Size = New System.Drawing.Size(300, 21)
        Me.CBArtigoSaida.TabIndex = 5
        '
        'LblQuantidadeSaida
        '
        Me.LblQuantidadeSaida.AutoSize = True
        Me.LblQuantidadeSaida.Location = New System.Drawing.Point(20, 140)
        Me.LblQuantidadeSaida.Name = "LblQuantidadeSaida"
        Me.LblQuantidadeSaida.Size = New System.Drawing.Size(66, 13)
        Me.LblQuantidadeSaida.TabIndex = 6
        Me.LblQuantidadeSaida.Text = "Quantidade:"
        '
        'NUDQuantidadeSaida
        '
        Me.NUDQuantidadeSaida.DecimalPlaces = 2
        Me.NUDQuantidadeSaida.Location = New System.Drawing.Point(23, 156)
        Me.NUDQuantidadeSaida.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NUDQuantidadeSaida.Name = "NUDQuantidadeSaida"
        Me.NUDQuantidadeSaida.Size = New System.Drawing.Size(120, 20)
        Me.NUDQuantidadeSaida.TabIndex = 7
        '
        'LblMotivoSaida
        '
        Me.LblMotivoSaida.AutoSize = True
        Me.LblMotivoSaida.Location = New System.Drawing.Point(20, 195)
        Me.LblMotivoSaida.Name = "LblMotivoSaida"
        Me.LblMotivoSaida.Size = New System.Drawing.Size(45, 13)
        Me.LblMotivoSaida.TabIndex = 8
        Me.LblMotivoSaida.Text = "Motivo:"
        '
        'TBMotivoSaida
        '
        Me.TBMotivoSaida.Location = New System.Drawing.Point(23, 211)
        Me.TBMotivoSaida.Multiline = True
        Me.TBMotivoSaida.Name = "TBMotivoSaida"
        Me.TBMotivoSaida.Size = New System.Drawing.Size(400, 50)
        Me.TBMotivoSaida.TabIndex = 9
        '
        'BtnRegistarSaida
        '
        Me.BtnRegistarSaida.Location = New System.Drawing.Point(23, 280)
        Me.BtnRegistarSaida.Name = "BtnRegistarSaida"
        Me.BtnRegistarSaida.Size = New System.Drawing.Size(160, 35)
        Me.BtnRegistarSaida.TabIndex = 10
        Me.BtnRegistarSaida.Text = "Registar Saída"
        Me.BtnRegistarSaida.UseVisualStyleBackColor = True
        '
        'TPHistorico
        '
        Me.TPHistorico.Controls.Add(Me.LblCodUtenteHist)
        Me.TPHistorico.Controls.Add(Me.TBCodUtenteHist)
        Me.TPHistorico.Controls.Add(Me.BtnProcurarHist)
        Me.TPHistorico.Controls.Add(Me.LblDataDeHist)
        Me.TPHistorico.Controls.Add(Me.DTPDataDeHist)
        Me.TPHistorico.Controls.Add(Me.LblDataAteHist)
        Me.TPHistorico.Controls.Add(Me.DTPDataAteHist)
        Me.TPHistorico.Controls.Add(Me.LblDescricaoHist)
        Me.TPHistorico.Controls.Add(Me.TBDescricaoHist)
        Me.TPHistorico.Controls.Add(Me.LblTipoHist)
        Me.TPHistorico.Controls.Add(Me.CBTipoHist)
        Me.TPHistorico.Controls.Add(Me.BtnFiltrarHist)
        Me.TPHistorico.Controls.Add(Me.DGVHistorico)
        Me.TPHistorico.Location = New System.Drawing.Point(4, 22)
        Me.TPHistorico.Name = "TPHistorico"
        Me.TPHistorico.Padding = New System.Windows.Forms.Padding(3)
        Me.TPHistorico.Size = New System.Drawing.Size(876, 535)
        Me.TPHistorico.TabIndex = 1
        Me.TPHistorico.Text = "Histórico Utente"
        Me.TPHistorico.UseVisualStyleBackColor = True
        '
        'LblCodUtenteHist
        '
        Me.LblCodUtenteHist.AutoSize = True
        Me.LblCodUtenteHist.Location = New System.Drawing.Point(20, 20)
        Me.LblCodUtenteHist.Name = "LblCodUtenteHist"
        Me.LblCodUtenteHist.Size = New System.Drawing.Size(70, 13)
        Me.LblCodUtenteHist.TabIndex = 0
        Me.LblCodUtenteHist.Text = "Cód. Utente:"
        '
        'TBCodUtenteHist
        '
        Me.TBCodUtenteHist.Location = New System.Drawing.Point(96, 17)
        Me.TBCodUtenteHist.Name = "TBCodUtenteHist"
        Me.TBCodUtenteHist.Size = New System.Drawing.Size(100, 20)
        Me.TBCodUtenteHist.TabIndex = 1
        '
        'BtnProcurarHist
        '
        Me.BtnProcurarHist.Location = New System.Drawing.Point(202, 15)
        Me.BtnProcurarHist.Name = "BtnProcurarHist"
        Me.BtnProcurarHist.Size = New System.Drawing.Size(90, 23)
        Me.BtnProcurarHist.TabIndex = 2
        Me.BtnProcurarHist.Text = "Procurar"
        Me.BtnProcurarHist.UseVisualStyleBackColor = True
        '
        'LblDataDeHist
        '
        Me.LblDataDeHist.AutoSize = True
        Me.LblDataDeHist.Location = New System.Drawing.Point(20, 55)
        Me.LblDataDeHist.Name = "LblDataDeHist"
        Me.LblDataDeHist.Size = New System.Drawing.Size(23, 13)
        Me.LblDataDeHist.TabIndex = 4
        Me.LblDataDeHist.Text = "De:"
        '
        'DTPDataDeHist
        '
        Me.DTPDataDeHist.Checked = False
        Me.DTPDataDeHist.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DTPDataDeHist.Location = New System.Drawing.Point(50, 52)
        Me.DTPDataDeHist.Name = "DTPDataDeHist"
        Me.DTPDataDeHist.ShowCheckBox = True
        Me.DTPDataDeHist.Size = New System.Drawing.Size(115, 20)
        Me.DTPDataDeHist.TabIndex = 5
        '
        'LblDataAteHist
        '
        Me.LblDataAteHist.AutoSize = True
        Me.LblDataAteHist.Location = New System.Drawing.Point(175, 55)
        Me.LblDataAteHist.Name = "LblDataAteHist"
        Me.LblDataAteHist.Size = New System.Drawing.Size(27, 13)
        Me.LblDataAteHist.TabIndex = 6
        Me.LblDataAteHist.Text = "Até:"
        '
        'DTPDataAteHist
        '
        Me.DTPDataAteHist.Checked = False
        Me.DTPDataAteHist.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DTPDataAteHist.Location = New System.Drawing.Point(206, 52)
        Me.DTPDataAteHist.Name = "DTPDataAteHist"
        Me.DTPDataAteHist.ShowCheckBox = True
        Me.DTPDataAteHist.Size = New System.Drawing.Size(115, 20)
        Me.DTPDataAteHist.TabIndex = 7
        '
        'LblDescricaoHist
        '
        Me.LblDescricaoHist.AutoSize = True
        Me.LblDescricaoHist.Location = New System.Drawing.Point(331, 55)
        Me.LblDescricaoHist.Name = "LblDescricaoHist"
        Me.LblDescricaoHist.Size = New System.Drawing.Size(63, 13)
        Me.LblDescricaoHist.TabIndex = 8
        Me.LblDescricaoHist.Text = "Descrição:"
        '
        'TBDescricaoHist
        '
        Me.TBDescricaoHist.Location = New System.Drawing.Point(400, 52)
        Me.TBDescricaoHist.Name = "TBDescricaoHist"
        Me.TBDescricaoHist.Size = New System.Drawing.Size(150, 20)
        Me.TBDescricaoHist.TabIndex = 9
        '
        'LblTipoHist
        '
        Me.LblTipoHist.AutoSize = True
        Me.LblTipoHist.Location = New System.Drawing.Point(561, 55)
        Me.LblTipoHist.Name = "LblTipoHist"
        Me.LblTipoHist.Size = New System.Drawing.Size(33, 13)
        Me.LblTipoHist.TabIndex = 10
        Me.LblTipoHist.Text = "Tipo:"
        '
        'CBTipoHist
        '
        Me.CBTipoHist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTipoHist.FormattingEnabled = True
        Me.CBTipoHist.Items.AddRange(New Object() {"Todos", "Entrega", "Saída"})
        Me.CBTipoHist.Location = New System.Drawing.Point(600, 52)
        Me.CBTipoHist.Name = "CBTipoHist"
        Me.CBTipoHist.Size = New System.Drawing.Size(90, 21)
        Me.CBTipoHist.TabIndex = 11
        '
        'BtnFiltrarHist
        '
        Me.BtnFiltrarHist.Location = New System.Drawing.Point(700, 50)
        Me.BtnFiltrarHist.Name = "BtnFiltrarHist"
        Me.BtnFiltrarHist.Size = New System.Drawing.Size(90, 24)
        Me.BtnFiltrarHist.TabIndex = 12
        Me.BtnFiltrarHist.Text = "Filtrar"
        Me.BtnFiltrarHist.UseVisualStyleBackColor = True
        '
        'DGVHistorico
        '
        Me.DGVHistorico.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVHistorico.AllowUserToAddRows = False
        Me.DGVHistorico.AllowUserToDeleteRows = False
        Me.DGVHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVHistorico.ColumnHeadersHeight = 30
        Me.DGVHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGVHistorico.Location = New System.Drawing.Point(6, 85)
        Me.DGVHistorico.Name = "DGVHistorico"
        Me.DGVHistorico.ReadOnly = True
        Me.DGVHistorico.RowHeadersVisible = False
        Me.DGVHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVHistorico.Size = New System.Drawing.Size(864, 444)
        Me.DGVHistorico.TabIndex = 13
        '
        'StockScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TCStock)
        Me.Name = "StockScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Text = "Histórico / Saída de Stock"
        Me.TCStock.ResumeLayout(False)
        Me.TPSaida.ResumeLayout(False)
        Me.TPSaida.PerformLayout()
        Me.TPHistorico.ResumeLayout(False)
        Me.TPHistorico.PerformLayout()
        CType(Me.DGVHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDQuantidadeSaida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents TCStock As TabControl
    Friend WithEvents TPSaida As TabPage
    Friend WithEvents TPHistorico As TabPage
    Friend WithEvents LblCodUtenteHist As Label
    Friend WithEvents TBCodUtenteHist As TextBox
    Friend WithEvents BtnProcurarHist As Button
    Friend WithEvents DGVHistorico As DataGridView
    Friend WithEvents LblUtenteSaida As Label
    Friend WithEvents TBUtenteSaida As TextBox
    Friend WithEvents BtnProcurarUtenteSaida As Button
    Friend WithEvents LblNomeUtenteSaida As Label
    Friend WithEvents LblArtigoSaida As Label
    Friend WithEvents CBArtigoSaida As ComboBox
    Friend WithEvents LblQuantidadeSaida As Label
    Friend WithEvents NUDQuantidadeSaida As NumericUpDown
    Friend WithEvents LblMotivoSaida As Label
    Friend WithEvents TBMotivoSaida As TextBox
    Friend WithEvents BtnRegistarSaida As Button
    Friend WithEvents LblDataDeHist As Label
    Friend WithEvents DTPDataDeHist As DateTimePicker
    Friend WithEvents LblDataAteHist As Label
    Friend WithEvents DTPDataAteHist As DateTimePicker
    Friend WithEvents LblDescricaoHist As Label
    Friend WithEvents TBDescricaoHist As TextBox
    Friend WithEvents LblTipoHist As Label
    Friend WithEvents CBTipoHist As ComboBox
    Friend WithEvents BtnFiltrarHist As Button
End Class
