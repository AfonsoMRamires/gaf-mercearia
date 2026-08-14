' Add/edit form for a single Artigo, opened from the Stock tab's grid
' (double-click a row to edit, "Novo Artigo" to add). Caller sets the starting
' data via LoadArtigo, shows the dialog, and on DialogResult.OK reads the
' edited values back via GetArtigo. stockAtual is deliberately not editable
' here — it only moves via Entrada Stock / Registar Entrega / Saída de Stock.
Public Class ArtigoModal

    Private codArtigo As Integer = 0

    Public Sub LoadArtigo(ByVal a As Stock.ArtigoObj)
        codArtigo = a.codArtigo
        TBDescricao.Text = a.descricao
        TBUnidade.Text = a.unidade
        ' Clamp rather than assign directly — a stockMinimo written outside the
        ' app (raw SQL) could exceed this control's bounds and throw on open.
        NUDStockMinimo.Value = Math.Max(NUDStockMinimo.Minimum, Math.Min(NUDStockMinimo.Maximum, a.stockMinimo))
        CBAtivo.Checked = a.ativo
        TBObs.Text = a.obs
    End Sub

    Public Function GetArtigo() As Stock.ArtigoObj
        Return New Stock.ArtigoObj With {
            .codArtigo = codArtigo,
            .descricao = TBDescricao.Text.Trim(),
            .unidade = TBUnidade.Text.Trim(),
            .stockMinimo = NUDStockMinimo.Value,
            .ativo = CBAtivo.Checked,
            .obs = TBObs.Text
        }
    End Function

    Private Sub ArtigoModal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = If(codArtigo = 0, "Novo Artigo", "Editar Artigo")
        TBDescricao.Focus()
    End Sub

    Private Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles BtnGravar.Click
        If TBDescricao.Text.Trim() = String.Empty Then
            MsgBox("Preencha a descrição do artigo")
            Return
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
