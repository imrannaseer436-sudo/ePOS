Imports System.Windows.Forms.VisualStyles

Public Class frmCashCounter
    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick

        If e.RowIndex = -1 Then Exit Sub

        If e.ColumnIndex = 3 Then
            setPaid(e.RowIndex)
        ElseIf e.ColumnIndex = 4 Then
            setUnPaid(e.RowIndex)
        End If

    End Sub

    Private Sub setPaid(rowIndex As Short)

        dgv.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightPink

    End Sub

    Private Sub setUnPaid(rowIndex As Short)

        If MsgBox("You want to rivert this bill to unpaid state?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        dgv.Rows(rowIndex).DefaultCellStyle.BackColor = Color.White

    End Sub

    Private Sub frmCashCounter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SQL = "SELECT BillId, BillNo, TotAmt FROM BillMaster " _
            & "WHERE BillDt='2020-10-29' AND TermID=2 " _
            & "ORDER BY BillNo DESC"

        dgv.Rows.Clear()
        With ESSA.OpenReader(SQL)
            While .Read
                dgv.Rows.Add()
                dgv.Item(0, dgv.Rows.Count - 1).Value = .Item(0)
                dgv.Item(1, dgv.Rows.Count - 1).Value = .Item(1)
                dgv.Item(2, dgv.Rows.Count - 1).Value = Format(.Item(2), "0.00")
                dgv.Item(6, dgv.Rows.Count - 1).Value = 0
            End While
            .Close()
        End With

    End Sub

End Class

Public Class DataGridViewDisableButtonCell
    Inherits DataGridViewButtonCell

    Private enabledValue As Boolean

    Public Property Enabled As Boolean
        Get
            Return enabledValue
        End Get
        Set(ByVal value As Boolean)
            enabledValue = value
        End Set
    End Property


    ' Override the Clone method so that the Enabled property is copied.
    Public Overrides Function Clone() As Object
        Dim cell As DataGridViewDisableButtonCell = CType(MyBase.Clone(), DataGridViewDisableButtonCell)
        cell.Enabled = Enabled
        Return cell
    End Function


    ' By default, enable the button cell.
    Public Sub New()
        enabledValue = True
    End Sub

    Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal elementState As DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
        ' The button cell is disabled, so paint the border,
        ' background, and disabled button for the cell.
        If Not enabledValue Then

            ' Draw the cell background, if specified.
            If (paintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
                Dim cellBackground As SolidBrush = New SolidBrush(cellStyle.BackColor)
                graphics.FillRectangle(cellBackground, cellBounds)
                cellBackground.Dispose()
            End If


            ' Draw the cell borders, if specified.
            If (paintParts And DataGridViewPaintParts.Border) = DataGridViewPaintParts.Border Then
                PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle)
            End If


            ' Calculate the area in which to draw the button.
            Dim buttonArea As Rectangle = cellBounds
            Dim buttonAdjustment As Rectangle = Me.BorderWidths(advancedBorderStyle)
            buttonArea.X += buttonAdjustment.X
            buttonArea.Y += buttonAdjustment.Y
            buttonArea.Height -= buttonAdjustment.Height
            buttonArea.Width -= buttonAdjustment.Width

            ' Draw the disabled button.
            ButtonRenderer.DrawButton(graphics, buttonArea, PushButtonState.Disabled)


            ' Draw the disabled button text.
            If TypeOf Me.FormattedValue Is String Then
                TextRenderer.DrawText(graphics, CStr(Me.FormattedValue), Me.DataGridView.Font, buttonArea, SystemColors.GrayText)
            End If
        Else
            ' The button cell is enabled, so let the base class
            ' handle the painting.
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
        End If
    End Sub
End Class
