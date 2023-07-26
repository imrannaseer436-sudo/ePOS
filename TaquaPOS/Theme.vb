'******************************************** in the name of Lord *****************************************
Module Theme

    Public PanelBorderColor As Color = Color.FromArgb(115, 163, 212)
    Public ButtonBackColor As Color = Color.FromArgb(59, 126, 193)
    Public ButtonBordColor As Color = Color.FromArgb(59, 126, 193)
    Public ButtonForeColor As Color = Color.White
    Public ButtonMenuForeColor As Color = Color.White

    Public StatusBackColor As Color = Color.FromArgb(59, 126, 193)
    Public StatusForeColor As Color = Color.White

    Public LineColor As Color = Color.FromArgb(59, 126, 193)

    Private Sub ThemeDefault()

        PanelBorderColor = Color.FromArgb(84, 130, 53)
        ButtonBackColor = Color.FromArgb(226, 240, 217)
        ButtonBordColor = Color.FromArgb(226, 240, 217)
        ButtonForeColor = Color.Black
        ButtonMenuForeColor = Color.Black

        StatusBackColor = Color.FromArgb(226, 240, 217)
        StatusForeColor = Color.Black

        LineColor = Color.FromArgb(226, 240, 217)

    End Sub

    Private Sub ThemeSteal()

        PanelBorderColor = Color.FromArgb(39, 119, 169)
        ButtonBackColor = Color.FromArgb(165, 188, 202)
        ButtonBordColor = Color.FromArgb(165, 188, 202)
        ButtonForeColor = Color.White
        ButtonMenuForeColor = Color.White

        StatusBackColor = Color.FromArgb(165, 188, 202)
        StatusForeColor = Color.White

        LineColor = Color.FromArgb(165, 188, 202)

    End Sub


    Private Sub ThemeRed()

        PanelBorderColor = Color.FromArgb(224, 92, 89)
        ButtonBackColor = Color.FromArgb(199, 165, 165)
        ButtonBordColor = Color.FromArgb(199, 165, 165)
        ButtonForeColor = Color.White
        ButtonMenuForeColor = Color.White

        StatusBackColor = Color.FromArgb(199, 165, 165)
        StatusForeColor = Color.White

        LineColor = Color.FromArgb(199, 165, 165)

    End Sub


    Private Sub ThemeOrange()

        PanelBorderColor = Color.FromArgb(252, 185, 76)
        ButtonBackColor = Color.FromArgb(157, 202, 73)
        ButtonBordColor = Color.FromArgb(157, 202, 73)
        ButtonForeColor = Color.White
        ButtonMenuForeColor = Color.White

        StatusBackColor = Color.FromArgb(157, 202, 73)
        StatusForeColor = Color.White

        LineColor = Color.FromArgb(157, 202, 73)

    End Sub


    Private Sub ThemeBlue()

        PanelBorderColor = Color.FromArgb(115, 163, 212)
        ButtonBackColor = Color.FromArgb(59, 126, 193)
        ButtonBordColor = Color.FromArgb(59, 126, 193)
        ButtonForeColor = Color.White

        StatusBackColor = Color.FromArgb(59, 126, 193)
        StatusForeColor = Color.White

        LineColor = Color.FromArgb(59, 126, 193)

    End Sub


    Private Sub ThemeBlueNew()

        PanelBorderColor = Color.FromArgb(59, 126, 193)
        ButtonBackColor = Color.FromArgb(115, 163, 212)
        ButtonBordColor = Color.FromArgb(115, 163, 212)
        ButtonForeColor = Color.White

        StatusBackColor = Color.FromArgb(115, 163, 212)
        StatusForeColor = Color.White

        LineColor = Color.FromArgb(115, 163, 212)

    End Sub


    Public Sub GetTheme(ByVal ThemeID As SByte)

        Select Case ThemeID

            Case 1
                ThemeDefault()
            Case 2
                ThemeBlue()
            Case 3
                ThemeBlueNew()
            Case 4
                ThemeOrange()
            Case 5
                ThemeSteal()
            Case 6
                ThemeRed()

        End Select

    End Sub


    Public Sub UpdateGridSelectionColor(ByVal grd As DataGridView)

        grd.DefaultCellStyle.SelectionBackColor = ButtonBackColor
        grd.DefaultCellStyle.SelectionBackColor = ButtonForeColor

    End Sub


    Private Sub UpdateButtonThemeAll(ByVal pnl As Control)

        For Each ctl As Control In pnl.Controls

            If TypeOf (ctl) Is Button Then
                UpdateButtonTheme(CType(ctl, Button))
            End If

        Next

    End Sub


    Private Sub UpdateLableForeColor(ByVal pnl As Control)

        For Each ctl As Control In pnl.Controls

            If TypeOf (ctl) Is Label Then
                ctl.ForeColor = ButtonForeColor
            End If

        Next

    End Sub


    Public Sub UpdateButtonTheme(ByVal btn As Button)

        btn.BackColor = ButtonBackColor
        btn.FlatAppearance.MouseOverBackColor = PanelBorderColor
        btn.FlatAppearance.MouseDownBackColor = PanelBorderColor
        btn.FlatAppearance.BorderColor = PanelBorderColor
        btn.ForeColor = ButtonForeColor

    End Sub


    Private Sub UpdateButtonThemeLight(ByVal btn As Button)

        btn.BackColor = PanelBorderColor
        btn.FlatAppearance.MouseOverBackColor = PanelBorderColor
        btn.FlatAppearance.MouseDownBackColor = PanelBorderColor
        btn.FlatAppearance.BorderColor = PanelBorderColor
        btn.ForeColor = ButtonForeColor

    End Sub

End Module
