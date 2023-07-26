'********************************************* Bismillah *****************************************
Imports System.Data.SqlClient
Public Class Settings

    Private Sub ApplyTheme()

        pnlBack.BackColor = PanelBorderColor

        UpdateButtonTheme(btnClose)
        UpdateButtonTheme(btnUpdate)

        Label8.ForeColor = PanelBorderColor
        Label7.ForeColor = PanelBorderColor

        btnPWC.FlatAppearance.BorderColor = PanelBorderColor
        btnPWC.ForeColor = ButtonBackColor

    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        SQL = "update settings set param_value='" & txtBillFooter.Text & "' where param_name='BillFooter';" _
            & "update settings set param_value='" & cmbBillFormat.Text & "' where param_name='BillFormat';" _
            & "update settings set param_value='" & txtBillFooter2.Text & "' where param_name='BillFooter2';" _
            & "update settings set param_value='" & txtCopies.Text & "' where param_name='Copies'" _
            & "update settings set param_value='" & IIf(chkEDL.Checked = True, 1, 0) & "' where param_name='EnableDiscountLimit';" _
            & "update settings set param_value='" & Val(txtDis.Text) & "' where param_name='DiscountLimitValue';" _
            & "update settings set param_value='" & txtNPA.Text.Trim & "' where param_name='NetworkPrinterAddress';" _
            & "update settings set param_value='" & IIf(chkDMP.Checked = True, 1, 0) & "' where param_name='DosModePrinter';" _
            & "update settings set param_value='" & IIf(chkEnableRemarks.Checked = True, 1, 0) & "' where param_name='EnableRemarks';" _
            & "update settings set param_value='" & IIf(chkHideTerminal.Checked = True, 1, 0) & "' where param_name='HideTerminal';" _
            & "update settings set param_value='" & IIf(chkEnableBatch.Checked = True, 1, 0) & "' where param_name='EnableBatchMode';"

        ESSA.Execute(SQL)
        MsgBox("Settings updated successfully..!", MsgBoxStyle.Information)

    End Sub

    Private Sub Settings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ApplyTheme()

        cmbBillFormat.SelectedIndex = 0

        SQL = "select * from settings order by param_name"
        With ESSA.OpenReader(SQL)
            While .Read
                If .Item(0) = "BillFooter" Then
                    txtBillFooter.Text = .GetString(1)
                ElseIf .Item(0) = "BillFooter2" Then
                    txtBillFooter2.Text = .GetString(1).Trim
                ElseIf .Item(0) = "BillFormat" Then
                    cmbBillFormat.SelectedIndex = cmbBillFormat.FindStringExact(.GetString(1))
                ElseIf .Item(0) = "Copies" Then
                    txtCopies.Text = .GetString(1)
                ElseIf .Item(0) = "EnableDiscountLimit" Then
                    chkEDL.Checked = IIf(.GetString(1) = 1, True, False)
                ElseIf .Item(0) = "DiscountLimitValue" Then
                    txtDis.Text = Format(Val(.GetString(1)), "0.0")
                ElseIf .Item(0) = "NetworkPrinterAddress" Then
                    txtNPA.Text = .GetString(1).Trim
                ElseIf .Item(0) = "DosModePrinter" Then
                    chkDMP.Checked = IIf(.GetString(1) = 1, True, False)
                ElseIf .Item(0) = "EnableRemarks" Then
                    chkEnableRemarks.Checked = IIf(.GetString(1) = 1, True, False)
                ElseIf .Item(0) = "HideTerminal" Then
                    chkHideTerminal.Checked = IIf(.GetString(1) = 1, True, False)
                ElseIf .Item(0) = "EnableBatchMode" Then
                    chkEnableBatch.Checked = IIf(.GetString(1) = 1, True, False)
                End If
            End While
            .Close()
        End With

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPWC.Click

        PasswordUpdate.Show()

    End Sub

End Class