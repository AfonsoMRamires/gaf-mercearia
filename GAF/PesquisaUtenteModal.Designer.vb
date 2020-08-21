<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PesquisaUtenteModal
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
        Me.GBUtente = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBAutorizado = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBNome = New System.Windows.Forms.TextBox()
        Me.DGVUtentes = New System.Windows.Forms.DataGridView()
        Me.codUtente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Autorizado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnSelecionar = New System.Windows.Forms.Button()
        Me.BtnLimpar = New System.Windows.Forms.Button()
        Me.BtnProcurarUtente = New System.Windows.Forms.Button()
        Me.GBUtente.SuspendLayout()
        CType(Me.DGVUtentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GBUtente
        '
        Me.GBUtente.Controls.Add(Me.BtnLimpar)
        Me.GBUtente.Controls.Add(Me.BtnProcurarUtente)
        Me.GBUtente.Controls.Add(Me.Label2)
        Me.GBUtente.Controls.Add(Me.TBAutorizado)
        Me.GBUtente.Controls.Add(Me.Label1)
        Me.GBUtente.Controls.Add(Me.TBNome)
        Me.GBUtente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBUtente.Location = New System.Drawing.Point(11, 11)
        Me.GBUtente.Margin = New System.Windows.Forms.Padding(2)
        Me.GBUtente.Name = "GBUtente"
        Me.GBUtente.Padding = New System.Windows.Forms.Padding(2)
        Me.GBUtente.Size = New System.Drawing.Size(778, 93)
        Me.GBUtente.TabIndex = 14
        Me.GBUtente.TabStop = False
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
        'DGVUtentes
        '
        Me.DGVUtentes.AllowUserToAddRows = False
        Me.DGVUtentes.AllowUserToDeleteRows = False
        Me.DGVUtentes.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGVUtentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVUtentes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codUtente, Me.Nome, Me.Autorizado})
        Me.DGVUtentes.Location = New System.Drawing.Point(13, 119)
        Me.DGVUtentes.MultiSelect = False
        Me.DGVUtentes.Name = "DGVUtentes"
        Me.DGVUtentes.ReadOnly = True
        Me.DGVUtentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVUtentes.ShowCellErrors = False
        Me.DGVUtentes.ShowCellToolTips = False
        Me.DGVUtentes.ShowEditingIcon = False
        Me.DGVUtentes.ShowRowErrors = False
        Me.DGVUtentes.Size = New System.Drawing.Size(776, 279)
        Me.DGVUtentes.TabIndex = 15
        '
        'codUtente
        '
        Me.codUtente.Frozen = True
        Me.codUtente.HeaderText = "Código"
        Me.codUtente.MaxInputLength = 4
        Me.codUtente.Name = "codUtente"
        Me.codUtente.ReadOnly = True
        '
        'Nome
        '
        Me.Nome.HeaderText = "Nome"
        Me.Nome.MaxInputLength = 80
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        Me.Nome.Width = 400
        '
        'Autorizado
        '
        Me.Autorizado.HeaderText = "Autorizado(a)"
        Me.Autorizado.MaxInputLength = 80
        Me.Autorizado.Name = "Autorizado"
        Me.Autorizado.ReadOnly = True
        Me.Autorizado.Width = 400
        '
        'BtnSelecionar
        '
        Me.BtnSelecionar.Location = New System.Drawing.Point(12, 414)
        Me.BtnSelecionar.Name = "BtnSelecionar"
        Me.BtnSelecionar.Size = New System.Drawing.Size(135, 24)
        Me.BtnSelecionar.TabIndex = 12
        Me.BtnSelecionar.Text = "Selecionar Utente"
        Me.BtnSelecionar.UseVisualStyleBackColor = True
        '
        'BtnLimpar
        '
        Me.BtnLimpar.Image = Global.GAF.My.Resources.Resource1.icons8_broom_24
        Me.BtnLimpar.Location = New System.Drawing.Point(717, 24)
        Me.BtnLimpar.Name = "BtnLimpar"
        Me.BtnLimpar.Size = New System.Drawing.Size(56, 45)
        Me.BtnLimpar.TabIndex = 12
        Me.BtnLimpar.UseVisualStyleBackColor = True
        '
        'BtnProcurarUtente
        '
        Me.BtnProcurarUtente.Image = Global.GAF.My.Resources.Resource1.icons8_find_user_male_24
        Me.BtnProcurarUtente.Location = New System.Drawing.Point(607, 24)
        Me.BtnProcurarUtente.Name = "BtnProcurarUtente"
        Me.BtnProcurarUtente.Size = New System.Drawing.Size(104, 45)
        Me.BtnProcurarUtente.TabIndex = 11
        Me.BtnProcurarUtente.UseVisualStyleBackColor = True
        '
        'PesquisaUtenteModal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.BtnSelecionar)
        Me.Controls.Add(Me.DGVUtentes)
        Me.Controls.Add(Me.GBUtente)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PesquisaUtenteModal"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procurar Utente por Nome"
        Me.GBUtente.ResumeLayout(False)
        Me.GBUtente.PerformLayout()
        CType(Me.DGVUtentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GBUtente As GroupBox
    Friend WithEvents BtnProcurarUtente As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TBAutorizado As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TBNome As TextBox
    Friend WithEvents DGVUtentes As DataGridView
    Friend WithEvents codUtente As DataGridViewTextBoxColumn
    Friend WithEvents Nome As DataGridViewTextBoxColumn
    Friend WithEvents Autorizado As DataGridViewTextBoxColumn
    Friend WithEvents BtnSelecionar As Button
    Friend WithEvents BtnLimpar As Button
End Class
