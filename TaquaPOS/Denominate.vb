'**************************************** Bismillah *******************************************
Imports System.Data.SqlClient
Public Class Denominate

    Private Sub Denominate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Close()
            Case Keys.Enter
                If Me.ActiveControl.Tag <> "1" Then
                    e.SuppressKeyPress = True
                    Me.ProcessTabKey(True)
                End If

        End Select

    End Sub

    Private Sub txt10_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt10.KeyDown

        If e.KeyCode = Keys.Enter Then
            POS.txtPAmt.Text = Format(Val(lblTot.Text), "0.00")
            Close()
        End If

    End Sub

    Private Sub txt1000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt1000.TextChanged, txt500.TextChanged, txt100.TextChanged, txt50.TextChanged, txt20.TextChanged, txt10.TextChanged

        GetTotal()

    End Sub

    Private Sub GetTotal()

        lbl1000.Text = Format(Val(txt1000.Text) * 1000, "0.00")
        lbl500.Text = Format(Val(txt500.Text) * 500, "0.00")
        lbl100.Text = Format(Val(txt100.Text) * 10, "0.00")
        lbl50.Text = Format(Val(txt50.Text) * 50, "0.00")
        lbl20.Text = Format(Val(txt20.Text) * 20, "0.00")
        lbl10.Text = Format(Val(txt10.Text) * 10, "0.00")

        lblDTot.Text = Val(txt1000.Text) + Val(txt500.Text) + Val(txt100.Text) + Val(txt50.Text) + Val(txt20.Text) + Val(txt10.Text)
        lblTot.Text = Format(Val(lbl1000.Text) + Val(lbl500.Text) + Val(lbl100.Text) + Val(lbl50.Text) + Val(lbl20.Text) + Val(lbl10.Text), "0.00")

    End Sub

    Private Sub ApplyTheme()

        pnlPayment.BackColor = PanelBorderColor
        lblDTot.ForeColor = ButtonBackColor
        lblTot.ForeColor = ButtonBackColor
        Label21.ForeColor = ButtonBackColor

    End Sub

    Private Sub Denominate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ApplyTheme()

    End Sub

End Class