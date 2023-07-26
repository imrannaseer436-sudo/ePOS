'************************************** In the name of Allah, Most Merciful, Most Compassionate *****************************
Imports System.Data.SqlClient
Public Class PercentageDiscount

    Private Sub AmountDiscount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.F3
                btnDone.PerformClick()
            Case Keys.Escape
                Me.Close()

        End Select

    End Sub

    Private Sub AmountDiscount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'ApplyTheme()

        With TG

            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With

        For i As Short = 0 To POS.TG.Rows.Count - 1

            TG.Rows.Add()
            TG.Item(0, TG.Rows.Count - 1).Value = POS.TG.Item(0, i).Value
            TG.Item(1, TG.Rows.Count - 1).Value = POS.TG.Item(1, i).Value
            TG.Item(2, TG.Rows.Count - 1).Value = POS.TG.Item(2, i).Value
            TG.Item(3, TG.Rows.Count - 1).Value = POS.TG.Item(9, i).Value
            TG.Item(6, TG.Rows.Count - 1).Value = POS.TG.Item(5, i).Value

        Next

        LBLTAMT.Text = Format(Val(POS.lblNetAmt.Text), "0.00")
        LBLNAMT.Text = Format(Val(POS.lblNetAmt.Text), "0.00")
        If TG.Rows.Count > 0 Then
            TG.CurrentCell = TG.Item(4, 0)
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Close()

    End Sub

    Private Sub TG_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TG.CellEndEdit

        If e.ColumnIndex = 4 Then
            TG.Item(5, e.RowIndex).Value = Format((Val(TG.Item(3, e.RowIndex).Value) * Val(TG.Item(4, e.RowIndex).Value)) / 100, "0.00")
        ElseIf e.ColumnIndex = 5 Then
            TG.Item(4, e.RowIndex).Value = Format((Val(TG.Item(5, e.RowIndex).Value) / Val(TG.Item(3, e.RowIndex).Value)) * 100, "0.0")
        End If
        GetColTotal()

        'If Val(TG.Item(4, e.RowIndex).Value) <= Val(TG.Item(3, e.RowIndex).Value) Then
        '    GetColTotal()
        '    LBLNAMT.Text = Format(Val(LBLTAMT.Text) - Val(LBLTOTDIS.Text), "0.00")
        'Else
        '    TG.Item(4, e.RowIndex).Value = Format(Val(TG.Item(3, e.RowIndex).Value), "0.00")
        '    GetColTotal()
        'End If

    End Sub

    Private Sub GetColTotal()

        Dim Tot As Double

        For i As Short = 0 To TG.Rows.Count - 1
            Tot += Val(TG.Item(5, i).Value)
        Next

        LBLTOTDIS.Text = Format(Tot, "0.00")
        LBLNAMT.Text = Format(Val(LBLTAMT.Text) - Val(LBLTOTDIS.Text), "0.00")

    End Sub

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click

        If Val(LBLTOTDIS.Text) <= 0 Then
            MsgBox("Sorry, Discount amount not found..!", MsgBoxStyle.Critical)
            TG.Focus()
        Else

            Dim Amt As Double = 0

            For i As Short = 0 To TG.Rows.Count - 1

                If Val(TG.Item(3, i).Value) > 0 Then

                    Amt = Format(Val(TG.Item(3, i).Value) / Val(TG.Item(6, i).Value), "0.00")
                    Amt -= (Amt * Val(TG.Item(4, i).Value)) / 100

                    POS.TG.Item(7, i).Value = Format(Val(TG.Item(4, i).Value), "0.0")
                    POS.TG.Item(8, i).Value = Format(Val(TG.Item(5, i).Value), "0.00")
                    POS.TG.Item(9, i).Value = Format(Val(TG.Item(3, i).Value) - Val(TG.Item(5, i).Value), "0.00")
                    POS.TG.Item(11, i).Value = Format(Amt, "0.00")

                End If

            Next

            POS.CalculateTotal()
            TG.Rows.Clear()
            LBLTOTDIS.Text = "0.00"
            Me.Close()

        End If

    End Sub

    Private Sub ApplyTheme()

        pnlBack.BackColor = PanelBorderColor
        TG.ColumnHeadersDefaultCellStyle.BackColor = ButtonBackColor
        TG.ColumnHeadersDefaultCellStyle.ForeColor = ButtonForeColor
        TG.DefaultCellStyle.SelectionBackColor = PanelBorderColor
        TG.DefaultCellStyle.SelectionBackColor = ButtonForeColor


    End Sub

End Class