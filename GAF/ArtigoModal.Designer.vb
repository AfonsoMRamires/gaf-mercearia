<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ArtigoModal
    Inherits System.Windows.Forms.Form

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
        Me.LblDescricao = New System.Windows.Forms.Label()
        Me.TBDescricao = New System.Windows.Forms.TextBox()
        Me.LblUnidade = New System.Windows.Forms.Label()
        Me.TBUnidade = New System.Windows.Forms.TextBox()
        Me.LblStockMinimo = New System.Windows.Forms.Label()
        Me.NUDStockMinimo = New System.Windows.Forms.NumericUpDown()
        Me.CBAtivo = New System.Windows.Forms.CheckBox()
        Me.LblObs = New System.Windows.Forms.Label()
        Me.TBObs = New System.Windows.Forms.TextBox()
        Me.BtnGravar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        CType(Me.NUDStockMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblDescricao
        '
        Me.LblDescricao.AutoSize = True
        Me.LblDescricao.Location = New System.Drawing.Point(15, 20)
        Me.LblDescricao.Name = "LblDescricao"
        Me.LblDescricao.Size = New System.Drawing.Size(58, 13)
        Me.LblDescricao.TabIndex = 0
        Me.LblDescricao.Text = "Descrição:"
        '
        'TBDescricao
        '
        Me.TBDescricao.Location = New System.Drawing.Point(18, 37)
        Me.TBDescricao.Name = "TBDescricao"
        Me.TBDescricao.Size = New System.Drawing.Size(370, 20)
        Me.TBDescricao.TabIndex = 1
        '
        'LblUnidade
        '
        Me.LblUnidade.AutoSize = True
        Me.LblUnidade.Location = New System.Drawing.Point(15, 65)
        Me.LblUnidade.Name = "LblUnidade"
        Me.LblUnidade.Size = New System.Drawing.Size(52, 13)
        Me.LblUnidade.TabIndex = 2
        Me.LblUnidade.Text = "Unidade:"
        '
        'TBUnidade
        '
        Me.TBUnidade.Location = New System.Drawing.Point(18, 82)
        Me.TBUnidade.Name = "TBUnidade"
        Me.TBUnidade.Size = New System.Drawing.Size(100, 20)
        Me.TBUnidade.TabIndex = 3
        Me.TBUnidade.Text = "un"
        '
        'LblStockMinimo
        '
        Me.LblStockMinimo.AutoSize = True
        Me.LblStockMinimo.Location = New System.Drawing.Point(140, 65)
        Me.LblStockMinimo.Name = "LblStockMinimo"
        Me.LblStockMinimo.Size = New System.Drawing.Size(72, 13)
        Me.LblStockMinimo.TabIndex = 4
        Me.LblStockMinimo.Text = "Stock Mínimo:"
        '
        'NUDStockMinimo
        '
        Me.NUDStockMinimo.DecimalPlaces = 2
        Me.NUDStockMinimo.Location = New System.Drawing.Point(143, 82)
        Me.NUDStockMinimo.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NUDStockMinimo.Name = "NUDStockMinimo"
        Me.NUDStockMinimo.Size = New System.Drawing.Size(100, 20)
        Me.NUDStockMinimo.TabIndex = 5
        '
        'CBAtivo
        '
        Me.CBAtivo.AutoSize = True
        Me.CBAtivo.Checked = True
        Me.CBAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBAtivo.Location = New System.Drawing.Point(270, 84)
        Me.CBAtivo.Name = "CBAtivo"
        Me.CBAtivo.Size = New System.Drawing.Size(52, 17)
        Me.CBAtivo.TabIndex = 6
        Me.CBAtivo.Text = "Ativo"
        Me.CBAtivo.UseVisualStyleBackColor = True
        '
        'LblObs
        '
        Me.LblObs.AutoSize = True
        Me.LblObs.Location = New System.Drawing.Point(15, 112)
        Me.LblObs.Name = "LblObs"
        Me.LblObs.Size = New System.Drawing.Size(75, 13)
        Me.LblObs.TabIndex = 7
        Me.LblObs.Text = "Observações:"
        '
        'TBObs
        '
        Me.TBObs.Location = New System.Drawing.Point(18, 129)
        Me.TBObs.Multiline = True
        Me.TBObs.Name = "TBObs"
        Me.TBObs.Size = New System.Drawing.Size(370, 60)
        Me.TBObs.TabIndex = 8
        '
        'BtnGravar
        '
        Me.BtnGravar.Location = New System.Drawing.Point(18, 205)
        Me.BtnGravar.Name = "BtnGravar"
        Me.BtnGravar.Size = New System.Drawing.Size(120, 32)
        Me.BtnGravar.TabIndex = 9
        Me.BtnGravar.Text = "Gravar"
        Me.BtnGravar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(146, 205)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(120, 32)
        Me.BtnCancelar.TabIndex = 10
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'ArtigoModal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(405, 255)
        Me.Controls.Add(Me.LblDescricao)
        Me.Controls.Add(Me.TBDescricao)
        Me.Controls.Add(Me.LblUnidade)
        Me.Controls.Add(Me.TBUnidade)
        Me.Controls.Add(Me.LblStockMinimo)
        Me.Controls.Add(Me.NUDStockMinimo)
        Me.Controls.Add(Me.CBAtivo)
        Me.Controls.Add(Me.LblObs)
        Me.Controls.Add(Me.TBObs)
        Me.Controls.Add(Me.BtnGravar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ArtigoModal"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Artigo"
        CType(Me.NUDStockMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblDescricao As Label
    Friend WithEvents TBDescricao As TextBox
    Friend WithEvents LblUnidade As Label
    Friend WithEvents TBUnidade As TextBox
    Friend WithEvents LblStockMinimo As Label
    Friend WithEvents NUDStockMinimo As NumericUpDown
    Friend WithEvents CBAtivo As CheckBox
    Friend WithEvents LblObs As Label
    Friend WithEvents TBObs As TextBox
    Friend WithEvents BtnGravar As Button
    Friend WithEvents BtnCancelar As Button
End Class
