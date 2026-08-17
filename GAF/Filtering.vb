Module Filtering

    ' DataView.RowFilter has its own expression syntax (not SQL): '*', '%' and '['
    ' are wildcard/escape characters there, not just the quote we already handle.
    ' Bracket-escape them so free-typed text can't break the filter expression.
    Public Function EscapeRowFilterLiteral(ByVal s As String) As String
        Return s.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]")
    End Function

    ' Grids use AutoGenerateColumns, so columns only exist once a DataSource is
    ' bound; call this right after assigning DataSource to bias AutoSizeColumnsMode
    ' = Fill toward the free-text columns (descrição/obs/nome/...) instead of every
    ' column getting an equal share of the grid's width.
    Public Sub SetColumnFillWeights(ByVal dgv As DataGridView, ByVal weights As Dictionary(Of String, Integer))
        For Each kv As KeyValuePair(Of String, Integer) In weights
            If dgv.Columns.Contains(kv.Key) Then
                dgv.Columns(kv.Key).FillWeight = kv.Value
            End If
        Next
    End Sub

End Module
