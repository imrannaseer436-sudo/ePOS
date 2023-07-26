'*************************************** Bismillah *******************************
Imports System.Data.SqlClient
Public Class Remarks

    Private Sub LoadRemarks()

        TGRmks.Rows.Clear()

        SQL = "select id,remarks from remarks order by sno desc"
        With ESSA.OpenReader(SQL)
            While .Read
                TGRmks.Rows.Add()
                TGRmks.Item(0, TGRmks.Rows.Count - 1).Value = .GetString(0)
                TGRmks.Item(1, TGRmks.Rows.Count - 1).Value = .GetString(1)
            End While
            .Close()
        End With

    End Sub

    Private Sub Remarks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                POS.TGPmt.Rows.Clear()
                POS.cmbPmtType.Focus()
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Close()

        End Select

    End Sub

    Private Sub Remarks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadRemarks()

    End Sub

    Private Sub txtID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtID.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If txtID.Text.Trim = "" Then Exit Sub

            Dim NRI = ESSA.FindGridIndex(TGRmks, 0, txtID.Text.Trim)
            If NRI = -1 Then
                txtRemarks.Focus()
            Else
                POS.Remark = TGRmks.Item(1, NRI).Value
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Close()
            End If

        End If

    End Sub

    Private Sub txtRemarks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemarks.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If txtRemarks.Text.Trim = "" Then Exit Sub

            SQL = "select sno from remarks where remarks='" & txtRemarks.Text.Trim & "'"
            If ESSA.ISFound(SQL) = True Then
                MsgBox("Remarks already exists..!", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim MIdx = ESSA.GenerateID("select max(sno) from remarks")
            SQL = "insert into remarks values ('" _
                & txtID.Text.Trim & "','" _
                & txtRemarks.Text.Trim & "'," _
                & MIdx & ")"

            ESSA.Execute(SQL)

            txtID.Clear()
            txtRemarks.Clear()
            txtID.Focus()

            LoadRemarks()

        End If

    End Sub

    Private Sub TGRmks_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TGRmks.CellDoubleClick

        If e.RowIndex = -1 Then Exit Sub
        Dim id As SByte = 0

        If e.ColumnIndex = 0 Then
            id = 0
        Else
            id = 1
        End If

        Dim iRemarks = InputBox("Enter new " & IIf(id = 0, "id", "remarks") & " here..! (CAPS ONLY)" & vbCrLf & TGRmks.Item(id, e.RowIndex).Value)

        If iRemarks.Trim <> "" Then
            If id = 0 Then
                SQL = "UPDATE REMARKS SET ID='" & UCase(iRemarks.Trim) & "' WHERE ID='" & TGRmks.Item(0, e.RowIndex).Value & "'"
            Else
                SQL = "UPDATE REMARKS SET REMARKS='" & UCase(iRemarks.Trim) & "' WHERE ID='" & TGRmks.Item(0, e.RowIndex).Value & "'"
            End If

            ESSA.Execute(SQL)
            LoadRemarks()
        End If

    End Sub

    Private Sub txtID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtID.KeyUp

        If e.KeyCode <> Keys.Enter Then
            ESSA.FindAndSelect(TGRmks, 0, txtID.Text.Trim)
        End If

    End Sub


    Private Sub TGRmks_KeyUp(sender As Object, e As KeyEventArgs) Handles TGRmks.KeyUp

        If e.KeyCode = Keys.Delete Then

            If TGRmks.CurrentRow.Index = -1 Then Exit Sub
            If MsgBox("Delete Remark..!", vbQuestion + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            ESSA.Execute("delete from remarks where id='" & Trim(TGRmks.Item(0, TGRmks.CurrentRow.Index).Value) & "'")
            TGRmks.Rows.RemoveAt(TGRmks.CurrentRow.Index)

        End If

    End Sub

End Class