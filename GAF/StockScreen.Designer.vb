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
        Me.TPArtigos = New System.Windows.Forms.TabPage()
        Me.TPEntrega = New System.Windows.Forms.TabPage()
        Me.TPHistorico = New System.Windows.Forms.TabPage()
        Me.DGVArtigos = New System.Windows.Forms.DataGridView()
        Me.LblDescricao = New System.Windows.Forms.Label()
        Me.TBDescricao = New System.Windows.Forms.TextBox()
        Me.LblUnidade = New System.Windows.Forms.Label()
        Me.TBUnidade = New System.Windows.Forms.TextBox()
        Me.LblStockMinimo = New System.Windows.Forms.Label()
        Me.NUDStockMinimo = New System.Windows.Forms.NumericUpDown()
        Me.CBAtivo = New System.Windows.Forms.CheckBox()
        Me.LblObsArtigo = New System.Windows.Forms.Label()
        Me.TBObsArtigo = New System.Windows.Forms.TextBox()
        Me.BtnNovoArtigo = New System.Windows.Forms.Button()
        Me.BtnGravarArtigo = New System.Windows.Forms.Button()
        Me.BtnEntradaStock = New System.Windows.Forms.Button()
        Me.BtnLimparArtigo = New System.Windows.Forms.Button()
        Me.LblCodUtenteEntrega = New System.Windows.Forms.Label()
        Me.TBCodUtenteEntrega = New System.Windows.Forms.TextBox()
        Me.BtnProcurarUtenteEntrega = New System.Windows.Forms.Button()
        Me.LblNomeUtente = New System.Windows.Forms.Label()
        Me.LblArtigo = New System.Windows.Forms.Label()
        Me.CBArtigo = New System.Windows.Forms.ComboBox()
        Me.LblQuantidade = New System.Windows.Forms.Label()
        Me.NUDQuantidade = New System.Windows.Forms.NumericUpDown()
        Me.LblDtEntrega = New System.Windows.Forms.Label()
        Me.DTPEntrega = New System.Windows.Forms.DateTimePicker()
        Me.LblObsEntrega = New System.Windows.Forms.Label()
        Me.TBObsEntrega = New System.Windows.Forms.TextBox()
        Me.BtnRegistarEntrega = New System.Windows.Forms.Button()
        Me.LblCodUtenteHist = New System.Windows.Forms.Label()
        Me.TBCodUtenteHist = New System.Windows.Forms.TextBox()
        Me.BtnProcurarHist = New System.Windows.Forms.Button()
        Me.DGVHistorico = New System.Windows.Forms.DataGridView()
        Me.TCStock.SuspendLayout()
        Me.TPArtigos.SuspendLayout()
        Me.TPEntrega.SuspendLayout()
        Me.TPHistorico.SuspendLayout()
        CType(Me.DGVArtigos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDStockMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TCStock
        '
        Me.TCStock.Controls.Add(Me.TPArtigos)
        Me.TCStock.Controls.Add(Me.TPEntrega)
        Me.TCStock.Controls.Add(Me.TPHistorico)
        Me.TCStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCStock.Location = New System.Drawing.Point(0, 0)
        Me.TCStock.Name = "TCStock"
        Me.TCStock.SelectedIndex = 0
        Me.TCStock.Size = New System.Drawing.Size(884, 561)
        Me.TCStock.TabIndex = 0
        '
        'TPArtigos
        '
        Me.TPArtigos.Controls.Add(Me.DGVArtigos)
        Me.TPArtigos.Controls.Add(Me.LblDescricao)
        Me.TPArtigos.Controls.Add(Me.TBDescricao)
        Me.TPArtigos.Controls.Add(Me.LblUnidade)
        Me.TPArtigos.Controls.Add(Me.TBUnidade)
        Me.TPArtigos.Controls.Add(Me.LblStockMinimo)
        Me.TPArtigos.Controls.Add(Me.NUDStockMinimo)
        Me.TPArtigos.Controls.Add(Me.CBAtivo)
        Me.TPArtigos.Controls.Add(Me.LblObsArtigo)
        Me.TPArtigos.Controls.Add(Me.TBObsArtigo)
        Me.TPArtigos.Controls.Add(Me.BtnNovoArtigo)
        Me.TPArtigos.Controls.Add(Me.BtnGravarArtigo)
        Me.TPArtigos.Controls.Add(Me.BtnEntradaStock)
        Me.TPArtigos.Controls.Add(Me.BtnLimparArtigo)
        Me.TPArtigos.Location = New System.Drawing.Point(4, 22)
        Me.TPArtigos.Name = "TPArtigos"
        Me.TPArtigos.Padding = New System.Windows.Forms.Padding(3)
        Me.TPArtigos.Size = New System.Drawing.Size(876, 535)
        Me.TPArtigos.TabIndex = 0
        Me.TPArtigos.Text = "Artigos"
        Me.TPArtigos.UseVisualStyleBackColor = True
        '
        'DGVArtigos
        '
        Me.DGVArtigos.AllowUserToAddRows = False
        Me.DGVArtigos.AllowUserToDeleteRows = False
        Me.DGVArtigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArtigos.Location = New System.Drawing.Point(6, 6)
        Me.DGVArtigos.MultiSelect = False
        Me.DGVArtigos.Name = "DGVArtigos"
        Me.DGVArtigos.ReadOnly = True
        Me.DGVArtigos.RowHeadersVisible = False
        Me.DGVArtigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVArtigos.Size = New System.Drawing.Size(864, 300)
        Me.DGVArtigos.TabIndex = 0
        '
        'LblDescricao
        '
        Me.LblDescricao.AutoSize = True
        Me.LblDescricao.Location = New System.Drawing.Point(6, 320)
        Me.LblDescricao.Name = "LblDescricao"
        Me.LblDescricao.Size = New System.Drawing.Size(58, 13)
        Me.LblDescricao.TabIndex = 1
        Me.LblDescricao.Text = "Descrição:"
        '
        'TBDescricao
        '
        Me.TBDescricao.Location = New System.Drawing.Point(9, 336)
        Me.TBDescricao.Name = "TBDescricao"
        Me.TBDescricao.Size = New System.Drawing.Size(300, 20)
        Me.TBDescricao.TabIndex = 2
        '
        'LblUnidade
        '
        Me.LblUnidade.AutoSize = True
        Me.LblUnidade.Location = New System.Drawing.Point(325, 320)
        Me.LblUnidade.Name = "LblUnidade"
        Me.LblUnidade.Size = New System.Drawing.Size(52, 13)
        Me.LblUnidade.TabIndex = 3
        Me.LblUnidade.Text = "Unidade:"
        '
        'TBUnidade
        '
        Me.TBUnidade.Location = New System.Drawing.Point(328, 336)
        Me.TBUnidade.Name = "TBUnidade"
        Me.TBUnidade.Size = New System.Drawing.Size(80, 20)
        Me.TBUnidade.TabIndex = 4
        Me.TBUnidade.Text = "un"
        '
        'LblStockMinimo
        '
        Me.LblStockMinimo.AutoSize = True
        Me.LblStockMinimo.Location = New System.Drawing.Point(425, 320)
        Me.LblStockMinimo.Name = "LblStockMinimo"
        Me.LblStockMinimo.Size = New System.Drawing.Size(72, 13)
        Me.LblStockMinimo.TabIndex = 5
        Me.LblStockMinimo.Text = "Stock Mínimo:"
        '
        'NUDStockMinimo
        '
        Me.NUDStockMinimo.DecimalPlaces = 2
        Me.NUDStockMinimo.Location = New System.Drawing.Point(428, 336)
        Me.NUDStockMinimo.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NUDStockMinimo.Name = "NUDStockMinimo"
        Me.NUDStockMinimo.Size = New System.Drawing.Size(100, 20)
        Me.NUDStockMinimo.TabIndex = 6
        '
        'CBAtivo
        '
        Me.CBAtivo.AutoSize = True
        Me.CBAtivo.Checked = True
        Me.CBAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBAtivo.Location = New System.Drawing.Point(545, 338)
        Me.CBAtivo.Name = "CBAtivo"
        Me.CBAtivo.Size = New System.Drawing.Size(52, 17)
        Me.CBAtivo.TabIndex = 7
        Me.CBAtivo.Text = "Ativo"
        Me.CBAtivo.UseVisualStyleBackColor = True
        '
        'LblObsArtigo
        '
        Me.LblObsArtigo.AutoSize = True
        Me.LblObsArtigo.Location = New System.Drawing.Point(6, 362)
        Me.LblObsArtigo.Name = "LblObsArtigo"
        Me.LblObsArtigo.Size = New System.Drawing.Size(75, 13)
        Me.LblObsArtigo.TabIndex = 8
        Me.LblObsArtigo.Text = "Observações:"
        '
        'TBObsArtigo
        '
        Me.TBObsArtigo.Location = New System.Drawing.Point(9, 378)
        Me.TBObsArtigo.Multiline = True
        Me.TBObsArtigo.Name = "TBObsArtigo"
        Me.TBObsArtigo.Size = New System.Drawing.Size(519, 60)
        Me.TBObsArtigo.TabIndex = 9
        '
        'BtnNovoArtigo
        '
        Me.BtnNovoArtigo.Location = New System.Drawing.Point(9, 460)
        Me.BtnNovoArtigo.Name = "BtnNovoArtigo"
        Me.BtnNovoArtigo.Size = New System.Drawing.Size(120, 30)
        Me.BtnNovoArtigo.TabIndex = 10
        Me.BtnNovoArtigo.Text = "Novo Artigo"
        Me.BtnNovoArtigo.UseVisualStyleBackColor = True
        '
        'BtnGravarArtigo
        '
        Me.BtnGravarArtigo.Location = New System.Drawing.Point(135, 460)
        Me.BtnGravarArtigo.Name = "BtnGravarArtigo"
        Me.BtnGravarArtigo.Size = New System.Drawing.Size(120, 30)
        Me.BtnGravarArtigo.TabIndex = 11
        Me.BtnGravarArtigo.Text = "Gravar"
        Me.BtnGravarArtigo.UseVisualStyleBackColor = True
        '
        'BtnEntradaStock
        '
        Me.BtnEntradaStock.Location = New System.Drawing.Point(261, 460)
        Me.BtnEntradaStock.Name = "BtnEntradaStock"
        Me.BtnEntradaStock.Size = New System.Drawing.Size(120, 30)
        Me.BtnEntradaStock.TabIndex = 12
        Me.BtnEntradaStock.Text = "Entrada Stock"
        Me.BtnEntradaStock.UseVisualStyleBackColor = True
        '
        'BtnLimparArtigo
        '
        Me.BtnLimparArtigo.Location = New System.Drawing.Point(387, 460)
        Me.BtnLimparArtigo.Name = "BtnLimparArtigo"
        Me.BtnLimparArtigo.Size = New System.Drawing.Size(120, 30)
        Me.BtnLimparArtigo.TabIndex = 13
        Me.BtnLimparArtigo.Text = "Limpar"
        Me.BtnLimparArtigo.UseVisualStyleBackColor = True
        '
        'TPEntrega
        '
        Me.TPEntrega.Controls.Add(Me.LblCodUtenteEntrega)
        Me.TPEntrega.Controls.Add(Me.TBCodUtenteEntrega)
        Me.TPEntrega.Controls.Add(Me.BtnProcurarUtenteEntrega)
        Me.TPEntrega.Controls.Add(Me.LblNomeUtente)
        Me.TPEntrega.Controls.Add(Me.LblArtigo)
        Me.TPEntrega.Controls.Add(Me.CBArtigo)
        Me.TPEntrega.Controls.Add(Me.LblQuantidade)
        Me.TPEntrega.Controls.Add(Me.NUDQuantidade)
        Me.TPEntrega.Controls.Add(Me.LblDtEntrega)
        Me.TPEntrega.Controls.Add(Me.DTPEntrega)
        Me.TPEntrega.Controls.Add(Me.LblObsEntrega)
        Me.TPEntrega.Controls.Add(Me.TBObsEntrega)
        Me.TPEntrega.Controls.Add(Me.BtnRegistarEntrega)
        Me.TPEntrega.Location = New System.Drawing.Point(4, 22)
        Me.TPEntrega.Name = "TPEntrega"
        Me.TPEntrega.Padding = New System.Windows.Forms.Padding(3)
        Me.TPEntrega.Size = New System.Drawing.Size(876, 535)
        Me.TPEntrega.TabIndex = 1
        Me.TPEntrega.Text = "Registar Entrega"
        Me.TPEntrega.UseVisualStyleBackColor = True
        '
        'LblCodUtenteEntrega
        '
        Me.LblCodUtenteEntrega.AutoSize = True
        Me.LblCodUtenteEntrega.Location = New System.Drawing.Point(20, 25)
        Me.LblCodUtenteEntrega.Name = "LblCodUtenteEntrega"
        Me.LblCodUtenteEntrega.Size = New System.Drawing.Size(70, 13)
        Me.LblCodUtenteEntrega.TabIndex = 0
        Me.LblCodUtenteEntrega.Text = "Cód. Utente:"
        '
        'TBCodUtenteEntrega
        '
        Me.TBCodUtenteEntrega.Location = New System.Drawing.Point(23, 41)
        Me.TBCodUtenteEntrega.Name = "TBCodUtenteEntrega"
        Me.TBCodUtenteEntrega.Size = New System.Drawing.Size(100, 20)
        Me.TBCodUtenteEntrega.TabIndex = 1
        '
        'BtnProcurarUtenteEntrega
        '
        Me.BtnProcurarUtenteEntrega.Location = New System.Drawing.Point(129, 40)
        Me.BtnProcurarUtenteEntrega.Name = "BtnProcurarUtenteEntrega"
        Me.BtnProcurarUtenteEntrega.Size = New System.Drawing.Size(90, 22)
        Me.BtnProcurarUtenteEntrega.TabIndex = 2
        Me.BtnProcurarUtenteEntrega.Text = "Procurar..."
        Me.BtnProcurarUtenteEntrega.UseVisualStyleBackColor = True
        '
        'LblNomeUtente
        '
        Me.LblNomeUtente.AutoSize = True
        Me.LblNomeUtente.Location = New System.Drawing.Point(240, 45)
        Me.LblNomeUtente.Name = "LblNomeUtente"
        Me.LblNomeUtente.Size = New System.Drawing.Size(0, 13)
        Me.LblNomeUtente.TabIndex = 3
        '
        'LblArtigo
        '
        Me.LblArtigo.AutoSize = True
        Me.LblArtigo.Location = New System.Drawing.Point(20, 85)
        Me.LblArtigo.Name = "LblArtigo"
        Me.LblArtigo.Size = New System.Drawing.Size(40, 13)
        Me.LblArtigo.TabIndex = 4
        Me.LblArtigo.Text = "Artigo:"
        '
        'CBArtigo
        '
        Me.CBArtigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBArtigo.FormattingEnabled = True
        Me.CBArtigo.Location = New System.Drawing.Point(23, 101)
        Me.CBArtigo.Name = "CBArtigo"
        Me.CBArtigo.Size = New System.Drawing.Size(300, 21)
        Me.CBArtigo.TabIndex = 5
        '
        'LblQuantidade
        '
        Me.LblQuantidade.AutoSize = True
        Me.LblQuantidade.Location = New System.Drawing.Point(20, 140)
        Me.LblQuantidade.Name = "LblQuantidade"
        Me.LblQuantidade.Size = New System.Drawing.Size(66, 13)
        Me.LblQuantidade.TabIndex = 6
        Me.LblQuantidade.Text = "Quantidade:"
        '
        'NUDQuantidade
        '
        Me.NUDQuantidade.DecimalPlaces = 2
        Me.NUDQuantidade.Location = New System.Drawing.Point(23, 156)
        Me.NUDQuantidade.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NUDQuantidade.Name = "NUDQuantidade"
        Me.NUDQuantidade.Size = New System.Drawing.Size(120, 20)
        Me.NUDQuantidade.TabIndex = 7
        '
        'LblDtEntrega
        '
        Me.LblDtEntrega.AutoSize = True
        Me.LblDtEntrega.Location = New System.Drawing.Point(20, 195)
        Me.LblDtEntrega.Name = "LblDtEntrega"
        Me.LblDtEntrega.Size = New System.Drawing.Size(80, 13)
        Me.LblDtEntrega.TabIndex = 8
        Me.LblDtEntrega.Text = "Data Entrega:"
        '
        'DTPEntrega
        '
        Me.DTPEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DTPEntrega.Location = New System.Drawing.Point(23, 211)
        Me.DTPEntrega.Name = "DTPEntrega"
        Me.DTPEntrega.Size = New System.Drawing.Size(120, 20)
        Me.DTPEntrega.TabIndex = 9
        '
        'LblObsEntrega
        '
        Me.LblObsEntrega.AutoSize = True
        Me.LblObsEntrega.Location = New System.Drawing.Point(20, 250)
        Me.LblObsEntrega.Name = "LblObsEntrega"
        Me.LblObsEntrega.Size = New System.Drawing.Size(75, 13)
        Me.LblObsEntrega.TabIndex = 10
        Me.LblObsEntrega.Text = "Observações:"
        '
        'TBObsEntrega
        '
        Me.TBObsEntrega.Location = New System.Drawing.Point(23, 266)
        Me.TBObsEntrega.Multiline = True
        Me.TBObsEntrega.Name = "TBObsEntrega"
        Me.TBObsEntrega.Size = New System.Drawing.Size(400, 60)
        Me.TBObsEntrega.TabIndex = 11
        '
        'BtnRegistarEntrega
        '
        Me.BtnRegistarEntrega.Location = New System.Drawing.Point(23, 345)
        Me.BtnRegistarEntrega.Name = "BtnRegistarEntrega"
        Me.BtnRegistarEntrega.Size = New System.Drawing.Size(160, 35)
        Me.BtnRegistarEntrega.TabIndex = 12
        Me.BtnRegistarEntrega.Text = "Registar Entrega"
        Me.BtnRegistarEntrega.UseVisualStyleBackColor = True
        '
        'TPHistorico
        '
        Me.TPHistorico.Controls.Add(Me.LblCodUtenteHist)
        Me.TPHistorico.Controls.Add(Me.TBCodUtenteHist)
        Me.TPHistorico.Controls.Add(Me.BtnProcurarHist)
        Me.TPHistorico.Controls.Add(Me.DGVHistorico)
        Me.TPHistorico.Location = New System.Drawing.Point(4, 22)
        Me.TPHistorico.Name = "TPHistorico"
        Me.TPHistorico.Padding = New System.Windows.Forms.Padding(3)
        Me.TPHistorico.Size = New System.Drawing.Size(876, 535)
        Me.TPHistorico.TabIndex = 2
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
        'DGVHistorico
        '
        Me.DGVHistorico.AllowUserToAddRows = False
        Me.DGVHistorico.AllowUserToDeleteRows = False
        Me.DGVHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVHistorico.Location = New System.Drawing.Point(6, 50)
        Me.DGVHistorico.Name = "DGVHistorico"
        Me.DGVHistorico.ReadOnly = True
        Me.DGVHistorico.RowHeadersVisible = False
        Me.DGVHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVHistorico.Size = New System.Drawing.Size(864, 479)
        Me.DGVHistorico.TabIndex = 3
        '
        'StockScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TCStock)
        Me.Name = "StockScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestão de Stock / Entregas"
        Me.TCStock.ResumeLayout(False)
        Me.TPArtigos.ResumeLayout(False)
        Me.TPArtigos.PerformLayout()
        Me.TPEntrega.ResumeLayout(False)
        Me.TPEntrega.PerformLayout()
        Me.TPHistorico.ResumeLayout(False)
        Me.TPHistorico.PerformLayout()
        CType(Me.DGVArtigos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDStockMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents TCStock As TabControl
    Friend WithEvents TPArtigos As TabPage
    Friend WithEvents TPEntrega As TabPage
    Friend WithEvents TPHistorico As TabPage
    Friend WithEvents DGVArtigos As DataGridView
    Friend WithEvents LblDescricao As Label
    Friend WithEvents TBDescricao As TextBox
    Friend WithEvents LblUnidade As Label
    Friend WithEvents TBUnidade As TextBox
    Friend WithEvents LblStockMinimo As Label
    Friend WithEvents NUDStockMinimo As NumericUpDown
    Friend WithEvents CBAtivo As CheckBox
    Friend WithEvents LblObsArtigo As Label
    Friend WithEvents TBObsArtigo As TextBox
    Friend WithEvents BtnNovoArtigo As Button
    Friend WithEvents BtnGravarArtigo As Button
    Friend WithEvents BtnEntradaStock As Button
    Friend WithEvents BtnLimparArtigo As Button
    Friend WithEvents LblCodUtenteEntrega As Label
    Friend WithEvents TBCodUtenteEntrega As TextBox
    Friend WithEvents BtnProcurarUtenteEntrega As Button
    Friend WithEvents LblNomeUtente As Label
    Friend WithEvents LblArtigo As Label
    Friend WithEvents CBArtigo As ComboBox
    Friend WithEvents LblQuantidade As Label
    Friend WithEvents NUDQuantidade As NumericUpDown
    Friend WithEvents LblDtEntrega As Label
    Friend WithEvents DTPEntrega As DateTimePicker
    Friend WithEvents LblObsEntrega As Label
    Friend WithEvents TBObsEntrega As TextBox
    Friend WithEvents BtnRegistarEntrega As Button
    Friend WithEvents LblCodUtenteHist As Label
    Friend WithEvents TBCodUtenteHist As TextBox
    Friend WithEvents BtnProcurarHist As Button
    Friend WithEvents DGVHistorico As DataGridView
End Class
