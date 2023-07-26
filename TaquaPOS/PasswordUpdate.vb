Public Class PasswordUpdate

    Private Sub ApplyTheme()

        TableLayoutPanel1.BackColor = PanelBorderColor
        Label7.ForeColor = ButtonBackColor
        Label8.ForeColor = ButtonBackColor

        UpdateButtonTheme(btnUpdate)
        UpdateButtonTheme(btnClose)

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        SQL = "SELECT USERID FROM USERS WHERE PASSWORD='" & ClsEncodeDecode.Encode(txtOP.Text) & "'"
        If ESSA.ISFound(SQL) = True Then

            If txtNP.Text.Trim = "" Then
                MsgBox("Password should not be empty..!", MsgBoxStyle.Critical)
                txtNP.Focus()
                Exit Sub
            ElseIf txtNP.Text <> txtRNP.Text Then
                MsgBox("Incorrect retype password..!", MsgBoxStyle.Critical)
                txtRNP.Focus()
                txtRNP.Clear()
                Exit Sub
            End If

            SQL = "update users set password='" & ClsEncodeDecode.Encode(txtRNP.Text) & "' where " _
                & "userid=" & UserID

            ESSA.Execute(SQL)
            MsgBox("Password updated successfully..!", MsgBoxStyle.Information)
            End

        Else

            MsgBox("Incorrect current password..!", MsgBoxStyle.Critical)
            txtNP.Clear()
            txtOP.Clear()
            txtRNP.Clear()
            txtOP.Focus()

        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Close()

    End Sub

    Private Sub PasswordUpdate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ApplyTheme()

    End Sub

End Class