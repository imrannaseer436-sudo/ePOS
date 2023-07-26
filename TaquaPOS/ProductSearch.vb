'******************************************* Bismillah **************************************
Imports System.Data.SqlClient
Public Class ProductSearch

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Close()

    End Sub

    Private Sub ApplyTheme()

        pnlBack.BackColor = PanelBorderColor
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

        If chkHold.Checked Then

            SQL = "SELECT DISTINCT D.TermID,D.BillId,D.BILLDT 'Date',convert(decimal(10,2),SUM(D.AMOUNT)) 'Amount' FROM BILLDETAILSHOLD D,PRODUCTMASTER P " _
            & "WHERE D.SHOPID = " & ShopID & " AND D.PLUID=P.PLUID AND P.PLUCODE LIKE '%" & txtCode.Text.Trim & "%'  GROUP BY D.TermID,D.BillId,D.BILLDT ORDER BY D.TERMID,D.BILLID"

        Else

            SQL = "SELECT DISTINCT M.TermID,M.BillNo,M.BILLDT 'Date',convert(decimal(10,2),M.TOTAMT) 'Amount' FROM BILLMASTER M,BILLDETAILS D,PRODUCTMASTER P " _
            & "WHERE M.BILLID=D.BILLID AND M.SHOPID = " & ShopID & " AND D.PLUID=P.PLUID AND P.PLUCODE LIKE '%" & txtCode.Text.Trim & "%' ORDER BY TERMID,BILLNO"

        End If

        ESSA.LoadDataGrid(TG, SQL)
        If TG.Rows.Count > 0 Then
            TG.Columns(0).Width = 60
            TG.Columns(1).Width = 85
            TG.Columns(2).Width = 80
            TG.Columns(3).Width = 80
            TG.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            TG.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            TG.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

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
End Class