Public Class DiscountOverride

    Private Sub ApplyTheme()

        pnlHead.BackColor = PanelBorderColor
        txtID.BackColor = ButtonBackColor
        txtID.ForeColor = ButtonForeColor

        txtCode.BackColor = ButtonBackColor
        txtCode.ForeColor = ButtonForeColor

        pnlID.BackColor = ButtonBackColor
        pnlPass.BackColor = ButtonBackColor

        UpdateButtonTheme(btnOverride)

    End Sub

    Private Sub GenerateID()

        SQL = "select max(id) from discountplus"
        txtID.Text = ESSA.GenerateID(SQL)

    End Sub

    Private Sub DiscountOverride_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        GenerateID()
        ApplyTheme()

    End Sub

    Private Sub btnOverride_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOverride.Click

        If txtCode.Text = "" Then
            Exit Sub
        End If

        If Val(txtCode.Text) = GenerateCode(Val(txtID.Text)) Then

            SQL = "insert into discountplus values (" _
                & Val(txtID.Text) & "," _
                & Val(txtCode.Text) & ")"

            ESSA.Execute(SQL)

            GetTheme(6)
            POS.lblHead.Text = "  Taqua POS - Discount Mode"
            DiscountLimit = 100
            Me.Close()
        Else
            DiscountLimit = iDiscountLimit
            POS.lblHead.Text = "  Taqua POS"
            btnOverride.Text = "YOUR NOT ALLOWED???"
        End If

    End Sub

    Private Function GenerateCode(ByVal id As Integer) As Long

        GenerateCode = ((id * 3) + (17 + 21))
        GenerateCode = GenerateCode * (id * 3)

    End Function

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged

        If btnOverride.Text = "YOUR NOT ALLOWED???" Then
            btnOverride.Text = "ALLOW ME..!"
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub

End Class