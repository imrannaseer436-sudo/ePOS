'****************************************** Bismillah ***********************************
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Runtime.InteropServices

Public Class Login

    Private PwdLen As SByte

    Private Sub ApplyTheme()

        lblIcon.ForeColor = PanelBorderColor
        lblApp.ForeColor = PanelBorderColor
        UpdateButtonTheme(btnLogin)

    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        SQL = "select param_name,param_value from settings"

        With ESSA.OpenReader(SQL)
            While .Read
                If .GetString(0) = "BusinessDate" Then
                    BusinessDate = CDate(.GetString(1)).Date
                ElseIf .GetString(0) = "BillFormat" Then
                    BillFormat = .GetString(1)
                ElseIf .GetString(0) = "Copies" Then
                    Copies = Val(.GetString(1))
                ElseIf .GetString(0) = "EnableDiscountLimit" Then
                    EnableDiscountLimit = IIf(.GetString(1) = "1", True, False)
                ElseIf .GetString(0) = "DiscountLimitValue" Then
                    DiscountLimit = Val(.GetString(1))
                ElseIf .GetString(0) = "BeginDate" Then
                    SDate = CDate(.GetString(1)).Date
                ElseIf .GetString(0) = "EndDate" Then
                    EDate = CDate(.GetString(1)).Date
                ElseIf .GetString(0) = "NetworkPrinterAddress" Then
                    NetworkPrinterAddress = .GetString(1).Trim
                ElseIf .GetString(0) = "DosModePrinter" Then
                    DosModePrinter = IIf(.GetString(1) = "1", True, False)
                ElseIf .GetString(0) = "EnableRemarks" Then
                    EnableRemarks = IIf(.GetString(1) = "1", True, False)
                ElseIf .GetString(0) = "HideTerminal" Then
                    HideTerminal = IIf(.GetString(1) = "1", True, False)
                ElseIf .GetString(0) = "EnableBatchMode" Then
                    EnableBatchMode = IIf(.GetString(1) = "1", True, False)
                End If
            End While
            .Close()
        End With


        If ISAdmin = False Then
            If EnableDiscountLimit = False Then
                DiscountLimit = 100
            End If
        Else
            DiscountLimit = 100
        End If

        iDiscountLimit = DiscountLimit

        'If BusinessDate <> Now.Date Then
        '    MsgBox("Mismatch business date..!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        If txtUsername.Text.Trim = "" Then
            TTip.Show("Username cannot be empty..!", txtUsername, 0, 25, 2000)
            txtUsername.Focus()
            Exit Sub
        ElseIf txtPassword.Text.Trim = "" Then
            TTip.Show("Password cannot be empty..!", txtPassword, 0, 25, 2000)
            txtPassword.Focus()
            Exit Sub
        End If

        SQL = "select userid,username,isadmin from users where username='" & txtUsername.Text.Trim & "' " _
            & "and password='" & ClsEncodeDecode.Encode(txtPassword.Text) & "';"
        With ESSA.OpenReader(SQL)
            If .Read Then
                ISAdmin = IIf(.Item(2) = 1, True, False)
                UserID = .Item(0)
                UserNm = .GetString(1)
                Pwd = txtPassword.Text
                .Close()
                POS.Close()
                POS.Show()
                Me.Close()
                Exit Sub
            End If

        End With

        TTip.Show("Incorrect username or password..!", btnLogin, 0, 25, 2000)
        txtPassword.Clear()
        txtPassword.SelectAll()
        txtPassword.Focus()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Close()

    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If

    End Sub

    Private Sub Login_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

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

    Private Async Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click

        SQL = "select password from users where isadmin = 1"
        With Await ESSA.OpenReaderAsync(SQL)
            While Await .ReadAsync
                If txtPassword.Text <> ClsEncodeDecode.DCode(.Item(0)) Then
                    TTip.Show("please enter admin password..!", txtPassword, 0, 25, 2000)
                    txtPassword.Focus()
                    Exit Sub
                End If
            End While
            .Close()
        End With

        POSSettings.Show()
        Me.Close()

    End Sub

    Private Sub Login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ApplyTheme()

        lblVer.Text = "Build Version " & My.Application.AppVersion

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\POSSettings.xml") = True Then

            Dim xDoc As XmlReader = XmlReader.Create(My.Application.Info.DirectoryPath & "\POSSettings.xml")
            While xDoc.Read
                If xDoc.Name = "DBSettings" Then
                    ConStr = ClsEncodeDecode.DCode(xDoc.ReadElementString("DBSettings"))
                ElseIf xDoc.Name = "ShopCode" Then
                    ShopCd = xDoc.ReadElementString("ShopCode")
                ElseIf xDoc.Name = "TermID" Then
                    TermID = xDoc.ReadElementString("TermID")
                ElseIf xDoc.Name = "PRINTER" Then
                    PrinterName = xDoc.ReadElementString("PRINTER").Trim
                ElseIf xDoc.Name = "RICHTEXTPRINTER" Then
                    ISRichTextPrinter = IIf(xDoc.ReadElementString("RICHTEXTPRINTER").Trim = "1", True, False)
                ElseIf xDoc.Name = "ISTRAILMODE" Then
                    ISTrailMode = IIf(xDoc.ReadElementString("ISTRAILMODE") = "1", True, False)
                ElseIf xDoc.Name = "SALESCOMMISSION" Then
                    AllowSalesCommission = IIf(xDoc.ReadElementString("SALESCOMMISSION").Trim = "1", True, False)
                ElseIf xDoc.Name = "FLOORLIST" Then
                    FloorList = xDoc.ReadElementString("FLOORLIST")
                ElseIf xDoc.Name = "DIRECTPRINT" Then
                    DirectPrint = IIf(xDoc.ReadElementString("DIRECTPRINT").Trim = "1", True, False)
                End If
            End While
            xDoc.Close()

        Else

            MsgBox("Application settings not configured..!", MsgBoxStyle.Information)

        End If

    End Sub

    'Private Sub txtUsername_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.Leave

    '    PwdLen = ESSA.GetData("select len(password) from users where username='" & txtUsername.Text.Trim & "'")

    'End Sub

    'Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    '    If PwdLen > 0 Then
    '        If txtPassword.Text.Length = PwdLen Then
    '            btnLogin.PerformClick()
    '        End If
    '    End If

    'End Sub

End Class