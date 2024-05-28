'******************************************* Bismillah **************************************
Imports System.Data.SqlClient
Public Class StockSearch

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Close()

    End Sub

    Private Sub ApplyTheme()

        pnlBack.BackColor = PanelBorderColor
        PnlLoading.BackColor = PanelBorderColor
        UpdateButtonTheme(btnGo)
        TG.ColumnHeadersDefaultCellStyle.BackColor = ButtonBackColor
        TG.ColumnHeadersDefaultCellStyle.ForeColor = ButtonForeColor
        TG.DefaultCellStyle.SelectionBackColor = PanelBorderColor


        'pnlBack.BackColor = ButtonBackColor
        'UpdateButtonTheme(btnGo)
        'TG.ColumnHeadersDefaultCellStyle.BackColor = PanelBorderColor
        'TG.ColumnHeadersDefaultCellStyle.ForeColor = ButtonForeColor
        'TG.DefaultCellStyle.SelectionBackColor = ButtonBackColor

    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click

        PnlLoading.Visible = True
        PnlLoading.Refresh()
        If chkName.Checked Then

            SQL = $"select p.plucode [Barcode],p.id [Size],a.catalog [Product], s.stock [Stock]
            from v_stockpos s
            inner join productmaster p on p.pluid =  s.pluid and s.location_id = {ShopID} 
            inner join productattributes a on a.pluid = s.pluid and a.catalog like '%{txtCode.Text.Trim}%'"

        Else

            SQL = $"select p.plucode [Barcode],p.id [Size],a.catalog [Product], s.stock [Stock]
            from v_stockpos s
            inner join productmaster p on p.pluid =  s.pluid and s.location_id = {ShopID}
            inner join productattributes a on a.pluid = s.pluid 
            and a.catalog = (select a.catalog 
            from productmaster p
            inner join productattributes a on p.pluid = a.pluid and p.plucode like '{txtCode.Text.Trim}')"

        End If

        ESSA.LoadDataGrid(TG, SQL)
        If TG.Rows.Count > 0 Then
            TG.Columns(0).Width = 60
            TG.Columns(1).Width = 40
            TG.Columns(2).Width = 145
            TG.Columns(3).Width = 50
            TG.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            TG.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            TG.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TG.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            TG.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            For i As Integer = 0 To TG.Rows.Count - 1
                If Val(TG.Item(3, i).Value) <= 0 Then
                    TG.Rows(i).DefaultCellStyle.BackColor = Color.Crimson
                    TG.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If
            Next

        End If
        PnlLoading.Visible = False

    End Sub

    Private Sub ProductSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub txtCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnGo.PerformClick()
        End If

    End Sub

    Private Sub ProductSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ApplyTheme()

    End Sub

    Private Sub chkName_CheckStateChanged(sender As Object, e As EventArgs) Handles chkName.CheckStateChanged

        txtCode.Text = ""
        txtCode.Focus()
        Label6.Text = IIf(chkName.Checked, "Product Name", "Product Code")

    End Sub
End Class