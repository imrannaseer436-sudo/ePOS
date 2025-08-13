'***************************** In the name of Allah, Most Merciful, Most Compassionate ****************************
Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports System.Net.Http
Imports System.Net
Imports System.IO


Public Class POS

    Private BillNo As Long = 0
    Private BillID As Long = 0
    Private HoldID As New List(Of Short)
    Private nTermID As Byte = 0
    Private Edit As Boolean = False
    Private POSPrinter As New iPOSPrinterNew
    Private POSPrinterRT As New iPOSPrinterRichText
    Private ISAlter As Boolean = False
    Private ISSignOut As Boolean
    Private BillType As String = ""
    Private ISReturn As Boolean = False
    Private eRefNo As String = ""
    Private PluID As Long = 0
    Private PluNm As String = ""
    Private Units As String = ""
    Public Remark As String = ""
    Private BillMode As SByte = 0
    Private PrintISOn As Boolean = False
    Private Rpt As New RptHoldBill
    Private TempFilePath As String = ""
    Private IsBillSaved As Boolean = False
    Private rptSaleBill As New SaleBill
    Private rptSaleBill4inch As New SaleBill4Inch
    Public customerId As Integer = 1
    Private FreshDiscount As Boolean = False
    Private billDt As Date
    Private billTime As DateTime
    Private shopNumber As String
    Private is3InchPrinter As Boolean = True


    Public Sub LoadTheme()

        pnlMain.BackColor = PanelBorderColor
        pnlStatus.BackColor = StatusBackColor

        SimpleLine1.LineColor = LineColor
        SimpleLine2.LineColor = LineColor
        SimpleLine3.LineColor = LineColor
        SimpleLine4.LineColor = LineColor

        lblStock.BackColor = ButtonBackColor
        lblStock.ForeColor = ButtonForeColor

        lblBillAmtHead.ForeColor = PanelBorderColor
        lblBillAmt.ForeColor = PanelBorderColor

        lblQtyHead.ForeColor = PanelBorderColor
        lblQty.ForeColor = PanelBorderColor

        lblNAmtHead.ForeColor = PanelBorderColor
        lblNetAmt.ForeColor = PanelBorderColor

        lblBillAmtHead.ForeColor = PanelBorderColor
        lblBillAmt.ForeColor = PanelBorderColor

        TG.DefaultCellStyle.SelectionBackColor = PanelBorderColor
        TG.DefaultCellStyle.SelectionForeColor = ButtonForeColor

        For Each ctl As Control In pnlWindow.Controls

            If TypeOf (ctl) Is Button Then

                CType(ctl, Button).BackColor = ButtonBackColor
                CType(ctl, Button).FlatAppearance.MouseOverBackColor = PanelBorderColor
                CType(ctl, Button).FlatAppearance.MouseDownBackColor = ButtonBackColor
                CType(ctl, Button).FlatAppearance.BorderColor = ButtonBackColor
                CType(ctl, Button).ForeColor = ButtonMenuForeColor

            End If

        Next

        For Each ctl As Control In pnlStatus.Controls

            If TypeOf ctl Is Windows.Forms.Label Then
                ctl.ForeColor = StatusForeColor
            End If

        Next

        '****************************** Rate Updater Panel ````````````````````````````````````````````

        pnlRateUpdater.BackColor = PanelBorderColor
        UpdateButtonTheme(btnRUHide)
        chkIBU.ForeColor = ButtonBackColor

        '****************************** Reprint Panel ````````````````````````````````````````````

        pnlReprint.BackColor = PanelBorderColor
        UpdateButtonTheme(btnRePrintBill)
        UpdateButtonTheme(btnReprintHide)
        SimpleLine5.LineColor = PanelBorderColor

        '****************************** Alter Panel ````````````````````````````````````````````

        pnlAlter.BackColor = PanelBorderColor
        UpdateButtonThemeAll(Panel7)
        lblAlterHead.BackColor = ButtonBackColor
        lblAlterHead.ForeColor = ButtonForeColor


        UpdateGridSelectionColor(TGBills)
        UpdateGridSelectionColor(TGEdt)

        '****************************** Batch Panel ````````````````````````````````````````````

        pnlBatch.BackColor = PanelBorderColor
        UpdateGridSelectionColor(TGBatch)

        '****************************** Hold Panel ````````````````````````````````````````````

        pnlHold.BackColor = PanelBorderColor
        UpdateGridSelectionColor(TGHold)

        '****************************** Payment Panel ````````````````````````````````````````````

        pnlPayment.BackColor = PanelBorderColor
        UpdateButtonTheme(btnUpdate)
        UpdateButtonTheme(btnHide)
        UpdateButtonThemeLight(btnDenominate)
        UpdateGridSelectionColor(TGPmt)

        '****************************** PaymentNew Panel ````````````````````````````````````````````

        PnlPaymentNew.BackColor = PanelBorderColor
        UpdateButtonTheme(BtnSaveNew)
        UpdateButtonTheme(BtnHideNew)

        '****************************** Customer Panel ````````````````````````````````````````````

        PnlCustomerInfo.BackColor = PanelBorderColor
        UpdateButtonTheme(BtnCustSave)
        UpdateButtonTheme(BtnHideCustomerPnl)
        UpdateButtonTheme(BtnSkip)

        '****************************** Loading Panel ````````````````````````````````````````````

        PnlLoading.BackColor = PanelBorderColor

        '****************************** Shortcut Panel ````````````````````````````````````````````

        pnlShortcuts.BackColor = PanelBorderColor
        UpdateLableForeColor(pnlShortcuts)

        'TGHold.ColumnHeadersDefaultCellStyle.BackColor = ButtonBackColor
        'TGHold.ColumnHeadersDefaultCellStyle.ForeColor = ButtonBackColor

    End Sub

    Private Sub UpdateGridSelectionColor(ByVal grd As DataGridView)

        grd.DefaultCellStyle.SelectionBackColor = ButtonBackColor
        grd.DefaultCellStyle.SelectionForeColor = ButtonForeColor

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

            If TypeOf (ctl) Is Windows.Forms.Label Then
                ctl.ForeColor = ButtonForeColor
            End If

        Next

    End Sub

    Private Sub UpdateButtonTheme(ByVal btn As Button)

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

    Private Sub LoadProductList()

        SQL = "select pluid,plucode 'Plucode',pluname 'Product Description',RetailPrice Rate,qoh Stock,units from productmaster order by plucode"
        ESSA.LoadDataGrid(TGProd, SQL)
        TGProd.Columns(0).Visible = False
        TGProd.Columns(1).Width = 100
        TGProd.Columns(2).Width = 200
        TGProd.Columns(3).Width = 80
        TGProd.Columns(4).Width = 80
        TGProd.Columns(5).Visible = False

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ISSignOut = False
        Close()

    End Sub

    Private Sub btnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin.Click

        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub POS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        txtCode.Focus()

    End Sub

    Private Sub POS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If ISSignOut = True Then
            If MsgBox("Are you sure, do you want to sign out..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Login.Show()
            Else
                e.Cancel = True
            End If
        Else
            If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub AddQuickCash()

        If PaymentTotal() <> Val(lblBillAmt.Text) Then
            pnlPayment.Visible = True
        End If

        TGPmt.Rows.Clear()
        TGPmt.Rows.Add()
        TGPmt.Item(0, TGPmt.Rows.Count - 1).Value = 1
        TGPmt.Item(1, TGPmt.Rows.Count - 1).Value = "CASH"
        TGPmt.Item(4, TGPmt.Rows.Count - 1).Value = Val(lblBillAmt.Text)

    End Sub

    Private Sub POS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.F2
                If pnlSalesPerson.Visible Then
                    btnQuickCash.PerformClick()
                    Exit Sub
                End If
                btnStore.PerformClick()
            Case Keys.F3
                If pnlSalesPerson.Visible Then
                    btnCard.PerformClick()
                    Exit Sub
                End If
                btnHold.PerformClick()
            Case Keys.F4
                btnReprint.PerformClick()
            Case Keys.F5
                btnReset.PerformClick()
            Case Keys.F6
                btnAlter.PerformClick()
            Case Keys.F8
                If TG.Rows.Count > 0 Then
                    lblCode.Text = "Sno"
                    lblHead.Text = "  e POS (Edit Mode)"
                    txtCode.Focus()
                End If
            Case Keys.F7

                If TG.Rows.Count = 0 Then Exit Sub
                For i As Short = 0 To TG.Rows.Count - 1

                    TG.Item(7, i).Value = 0
                    TG.Item(8, i).Value = "0.00"
                    TG.Item(9, i).Value = Format(Val(TG.Item(5, i).Value) * Val(TG.Item(6, i).Value), "0.00")
                    TG.Item(11, i).Value = Format(Val(TG.Item(6, i).Value), "0.00")

                Next

                CalculateTotal()
                PercentageDiscount.Visible = False
                PercentageDiscount.Show(Me)

            Case Keys.F9
                EnableDiscountMode()
                txtDVal.Clear()
                txtAmt.Clear()
            Case Keys.F10
                If TG.Rows.Count = 0 Then Exit Sub
                AmountDiscount.Visible = False
                AmountDiscount.Show(Me)
            Case Keys.F11
                btnSearch.PerformClick()
            Case Keys.F12

                If TG.Rows.Count = 0 Then Exit Sub
                pnlDU.Visible = True
                txtDP.Focus()
                txtDP.Clear()
                txtDR.Clear()
                txtBA.Text = Val(lblBillAmt.Text)

                'Dim DVal = Val(InputBox("Enter discount percentage value for all products..!"))
                'If DVal > DiscountLimit Then
                '    MsgBox("Sorry, You are not alowed to offer discount more than " & DiscountLimit & "%", MsgBoxStyle.Information)
                '    Exit Sub
                'End If
                'If DVal >= 0 Then
                '    For i As Short = 0 To TG.Rows.Count - 1
                '        TG.Item(7, i).Value = Format(DVal, "0.0")
                '        TG.Item(8, i).Value = Format(((Val(TG.Item(5, i).Value) * Val(TG.Item(6, i).Value)) * DVal) / 100, "0.00")
                '        TG.Item(9, i).Value = Format((Val(TG.Item(5, i).Value) * Val(TG.Item(6, i).Value)) - Val(TG.Item(8, i).Value), "0.0")
                '        TG.Item(11, i).Value = Format(Val(TG.Item(6, i).Value) - ((Val(TG.Item(6, i).Value) * DVal) / 100), "0.00")
                '    Next

                '    CalculateTotal()
                'End If
            Case Keys.Escape
                If PnlPaymentNew.Visible = True Then PnlPaymentNew.Visible = False : Exit Sub
                If PnlCustomerInfo.Visible = True Then PnlCustomerInfo.Visible = False : Exit Sub
                If pnlSalesPerson.Visible = True Then pnlSalesPerson.Visible = False : Exit Sub
                If pnlDU.Visible = True Then pnlDU.Visible = False : Exit Sub
                If pnlBatch.Visible = True Then pnlBatch.Visible = False : Exit Sub
                If pnlPayment.Visible = True Then pnlPayment.Visible = False : Exit Sub
                If pnlRateUpdater.Visible = True Then btnRUHide.PerformClick() : Exit Sub
                If pnlReprint.Visible = True Then pnlReprint.Visible = False : Exit Sub
                If TGProd.Visible = True Then TGProd.Visible = False : Exit Sub
                If lblCode.Text = "Sno" Then
                    txtCode.Clear()
                    txtQty.Clear()
                    txtRate.Clear()
                    lblCode.Text = "Product Code"
                    lblHead.Text = "  e POS"
                    ShowDiscountPanel(False)
                    txtCode.Focus()
                    Exit Sub
                End If
                If pnlHold.Visible = True Then pnlHold.Visible = False : Exit Sub
                Close()
            Case Keys.Enter
                If Not Me.ActiveControl Is Nothing Then
                    If Me.ActiveControl.Tag <> "1" Then
                        e.SuppressKeyPress = True
                        Me.ProcessTabKey(True)
                    End If
                End If

        End Select

    End Sub

    Private Sub EnableDiscountMode()

        Me.Text = "  ePOS - Discount Mode"
        lblCode.Text = "Sno"
        ShowDiscountPanel(True)

    End Sub

    Private Async Sub POS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        PnlLoading.Visible = True
        PnlLoading.BringToFront()
        PnlLoading.Refresh()

        LoadTheme()

        TempFilePath = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.Machine) & "\"

        If System.IO.File.Exists(TempFilePath & "PrintFile.bat") = False Then
            CreatePrintBAT()
        End If

        SQL = "select shopid,shopname,phone from shops where shopcode='" & ShopCd & "'"
        With Await ESSA.OpenReaderAsync(SQL)
            If Await .ReadAsync Then
                ShopID = .Item(0)
                ShopNm = .GetString(1).Trim
                shopNumber = .GetString(2).Trim
            End If
            .Close()
        End With

        'For New Shop Settings

        Await UpdateShopSettings()

        Await GetShopAddress()

        lblUser.Text = "Welcome," & UserNm
        lblVer.Text = "Version 1.0 Build " & My.Application.AppVersion

        'mebDt.Text = "12/17"
        lblBillDt.Text = Format(Now.Date, "dd-MMM-yyyy")
        Label26.Text = ShopNm.ToUpper

        Await GenerateBillNo()

        SimpleLine3.Height = 130
        SimpleLine4.Height = 130

        TG.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        TG.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        TG.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        TG.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        TG.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        TGPmt.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        TGSP.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        TGSP.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight



        Await LoadHoldBills()

        SQL = "select convert(varchar,termid) termid from terminal where shopid=" & ShopID & " order by termid"
        Await ESSA.LoadComboAsync(cmbATerm, SQL, "termid", "", "All")

        SQL = "select termid from terminal where shopid=" & ShopID & " order by termid"
        Await ESSA.LoadComboAsync(cmbTerm, SQL, "termid")

        SQL = $"SELECT 1 AS CUSTOMERID, 'Default' AS CUSTOMERNAME
                UNION ALL 
                SELECT CUSTOMERID,CUSTOMERNAME 
                FROM CUSTOMERS 
                WHERE LOCATIONID = {ShopID} 
                ORDER BY CUSTOMERID"
        Await ESSA.LoadComboAsync(cmbCustomer, SQL, "CUSTOMERNAME", "CUSTOMERID")

        SQL = "SELECT PAYMENTID,PAYMENTDESC FROM PAYMENTTYPE ORDER BY PAYMENTID"
        Await ESSA.LoadComboAsync(cmbPmtType, SQL, "PAYMENTDESC", "PAYMENTID")

        cmbDType.SelectedIndex = 0

        PrintISOn = True

        If ISRichTextPrinter = True Then
            If POSPrinterRT.ConnectToPrinter() = False Then
                PrintISOn = False
            End If
        Else
            'POSPrinter.ConnectToPrinter()
        End If

        TGHold.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        'Await LoadThemeAsync()

        mebRPFrom.Value = SDate
        mebRPTo.Value = EDate

        Await LoadSalesPersons()

        Await GetSMSApiSettings()

        PnlLoading.Refresh()
        PnlLoading.Visible = False

    End Sub

    Private Async Function LoadSalesPersons() As Task

        'Adding SPID FROM SalesPersons

        SQL = "SELECT SPId,SPCode FROM SalesPersons where shopid = " & ShopID & ""
        DgvSP.Rows.Clear()
        With Await ESSA.OpenReaderAsync(SQL)
            While Await .ReadAsync()
                DgvSP.Rows.Add()
                DgvSP.Item(1, DgvSP.Rows.Count - 1).Value = .Item(0)
                DgvSP.Item(0, DgvSP.Rows.Count - 1).Value = .Item(1)
            End While
            .Close()
        End With

    End Function

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click

        pnlPayment.Visible = False

    End Sub

    Private Sub txtCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If txtCode.Text.Trim = "" Then Exit Sub

            If lblCode.Text = "Sno" Then
                txtDVal.Focus()
                If TG.Rows.Count = 0 Then Exit Sub
                txtCode.Text = TG.Item(2, TG.CurrentRow.Index).Value
                txtQty.Text = TG.Item(5, TG.CurrentRow.Index).Value
                txtSP.Text = TG.Item(16, TG.CurrentRow.Index).Value 'SPCode
                txtRate.Text = Format(Val(TG.Item(6, TG.CurrentRow.Index).Value), "0.00")
                txtDVal.Text = Format(Val(TG.Item(7, TG.CurrentRow.Index).Value), "0.0")
                DiscountLimit = Val(TG.Item(14, TG.CurrentRow.Index).Value)
                lblStock.Text = Val(TG.Item(13, TG.CurrentRow.Index).Value)
                FreshDiscount = IIf(Val(TG.Item(15, TG.CurrentRow.Index).Value) = 1, True, False)
                If Val(txtDVal.Text) > 0 Then
                    EnableDiscountMode()
                End If
                If cmbDType.Visible = True Then
                    cmbDType.Focus()
                Else
                    txtQty.SelectAll()
                End If
                'txtSP.Focus() 'For sales person entry
                txtQty.Focus()
            Else

                SQL = "select m.pluid,plucode,pluname,units,pm.retailprice,v.stock,pm.discount from productmaster m,v_stockpos v,pricemaster pm where m.pluid=v.pluid and pm.pluid = v.pluid and pm.shopid = " & ShopID & " and v.location_id = " & ShopID & " " _
                    & "and plucode='" & txtCode.Text.Trim & "'"
                With ESSA.OpenReader(SQL)
                    If .Read Then
                        PluID = .Item(0)
                        txtCode.Text = .GetString(1).Trim
                        PluNm = .GetString(2).Trim
                        Units = .GetString(3).Trim
                        txtRate.Text = Format(.Item(4), "0.00")
                        lblStock.Text = .Item(5)
                        'txtQty.Text = 1
                        'txtQty.Select()
                        'txtQty.Focus()

                        txtSP.SelectAll() ' For sales person entry 
                        txtSP.Focus()
                        'txtSP.Text = 1
                        'txtQty.Text = 1
                        'txtQty.Select()
                        'txtQty.Focus()
                        FreshDiscount = False
                        DiscountLimit = 0
                        txtDVal.Text = DiscountLimit
                        If .Item(6) > 0 Then
                            FreshDiscount = True
                            EnableDiscountMode()
                            DiscountLimit = .Item(6)
                            txtDVal.Text = .Item(6)
                            txtSP.SelectAll()
                            txtSP.Focus()
                        End If
                        If isAttributesAvailable(txtCode.Text.Trim) = False Then
                            TTip.Show("Attributes not available..!", txtCode, 0, 25, 2000)
                            Exit Sub
                        End If
                        .Close()
                    Else
                        TTip.Show("Product code not found..!", txtCode, 0, 25, 2000)
                        txtCode.SelectAll()
                        .Close()
                        Exit Sub
                    End If

                End With

                'S U S P E N D  O L D  B A T C H  C O D E
                '- - - - - - - - - - - - - - - - - - - - -

                If EnableBatchMode = True Then

                    'S H O W  A L L  B A T C H  I D
                    '- - - - - - - - - - - - - - - -

                    SQL = "SELECT B.BATCHID,P.PLUCODE,B.RATE,B.SHOPID,B.ORATE FROM PRODUCTBATCH B,PRODUCTMASTER P " _
                        & "WHERE B.PLUID=P.PLUID AND P.PLUCODE='" & txtCode.Text.Trim & "' ORDER BY B.BATCHID"

                    With ESSA.OpenReader(SQL)
                        TGBatch.Rows.Clear()
                        While .Read
                            TGBatch.Rows.Add()
                            TGBatch.Item(0, TGBatch.Rows.Count - 1).Value = .Item(0)
                            TGBatch.Item(1, TGBatch.Rows.Count - 1).Value = .GetString(1).Trim
                            TGBatch.Item(2, TGBatch.Rows.Count - 1).Value = Format(.Item(2), "0.00")
                            TGBatch.Item(3, TGBatch.Rows.Count - 1).Value = .Item(3)
                            TGBatch.Item(4, TGBatch.Rows.Count - 1).Value = Format(.Item(4), "0.00")
                        End While
                        .Close()
                    End With

                    If TGBatch.Rows.Count > 1 Then
                        pnlBatch.Visible = True
                        TGBatch.CurrentCell = TGBatch.Item(0, 0)
                        TGBatch.Focus()
                    End If

                End If

                'S U S P E N D E D  N E W  B A T C H  C O D E
                '- - - - - - - - - - - - - - - - - - - - - - -

                'If EnableBatchMode = False Then

                '    SQL = "SELECT RATE,ORATE,SHOPID FROM V_PRODUCTBATCH WHERE PLUID=" & PluID

                '    With ESSA.OpenReader(SQL)
                '        If .Read Then

                '            new_rate = Val(.Item(0))
                '            old_rate = Val(.Item(1))
                '            show_discount = .Item(2)

                '            Dim ORate As Double = .Item(0)
                '            Dim NRate As Double = .Item(0)
                '            txtRate.Text = Format(.Item(0), "0.00")

                '            'S U S P E N D E D  A U T O  R E V E R S E  D I S C O U N T

                '            'Dim ORate As Double = Val(txtRate.Text)
                '            'Dim NRate As Double = .Item(0)
                '            ''txtDVal.Text = Format(100 - ((NRate / ORate) * 100), "0.00")

                '        End If
                '        .Close()
                '    End With

                'End If

            End If

        End If

    End Sub

    Private Sub txtCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyUp

        If e.KeyCode = Keys.Down Then
            If TG.Rows.Count > 0 Then
                TG.Focus()
            End If
        ElseIf e.KeyCode <> Keys.Enter Then
            If lblCode.Text = "Sno" Then
                ESSA.FindAndSelect(TG, 1, txtCode.Text)
            End If
        End If


    End Sub

    Private Sub TGProd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TGProd.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If TGProd.CurrentCell Is Nothing Then
                TTip.Show("Please select product..!", txtCode, 0, 25, 2000)
                Exit Sub
            End If

            txtCode.Text = TGProd.Item(1, TGProd.CurrentRow.Index).Value
            txtRate.Text = Format(Val(TGProd.Item(3, TGProd.CurrentRow.Index).Value), "0.00")
            lblStock.Text = Val(TGProd.Item(4, TGProd.CurrentRow.Index).Value)
            TGProd.Visible = False
            txtQty.Focus()
        End If

    End Sub

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True

            If cmbDType.Visible = True Then
                cmbDType.Focus()
            Else
                Addrows()
            End If

        End If

    End Sub

    Private Function GetStock() As Long

        GetStock = 0

        If lblCode.Text <> "Sno" Then

            For i As Short = 0 To TG.Rows.Count - 1
                If PluID = TG.Item(0, i).Value Then
                    GetStock = Val(TG.Item(5, i).Value)
                    Exit For
                End If
            Next

        End If

    End Function

    Private Sub Addrows()

        If Val(txtQty.Text) = 0 Then
            TTip.Show("Quantity not defined..!", txtQty, 0, 25, 2000)
            Exit Sub
        ElseIf txtSP.Text.Trim = "" Then
            TTip.Show("Enter sales person number..!", txtSP, 0, 25, 2000)
            Exit Sub
        End If

        'If isAttributesAvailable(PluID) = False Then
        '    'If lblCode.Text = "Sno" Then
        '    '    TTip.Show("Attributes not available..!", txtAmt, 0, 25, 2000)
        '    '    Exit Sub
        '    'Else
        '    '    TTip.Show("Attributes not available..!", txtQty, 0, 25, 2000)
        '    '    Exit Sub
        '    'End If           
        'End If

        If ISTrailMode = False Then
            If GetStock() + Val(txtQty.Text) > Val(lblStock.Text) Then
                TTip.Show("Insufficient stock..!", txtQty, 0, 25, 2000)
                Exit Sub
            End If
        End If

        If Not ifExist(DgvSP, 0, txtSP.Text) Then
            TTip.Show("Invalid sales person number..!", txtSP, 0, 25, 2000)
            Exit Sub
        End If

        If lblCode.Text = "Sno" And FreshDiscount = False Then

            Dim DAmt As Double = (Val(txtQty.Text) * Val(txtRate.Text) * Val(txtDVal.Text)) / 100

            '// Injected code for auto discount display
            '// =======================================

            Dim discount_value As Double = 0
            Dim discount_amount As Double = 0

            Dim newrate_amount As Double = 0
            Dim oldrate_amount As Double = 0

            If show_discount = True Then

                newrate_amount = Val(txtRate.Text) * Val(txtQty.Text)
                oldrate_amount = new_rate * Val(txtQty.Text)

                discount_value = (new_rate / old_rate) * 100

            Else

                discount_value = Val(txtDVal.Text)

            End If

            TG.Item(8, TG.CurrentRow.Index).Value = Format(DAmt, "0.00")
            TG.Item(5, TG.CurrentRow.Index).Value = txtQty.Text
            TG.Item(6, TG.CurrentRow.Index).Value = Format(Val(txtRate.Text), "0.00")
            'TG.Item(7, TG.CurrentRow.Index).Value = Format(Val(txtDVal.Text), "0.0")
            TG.Item(7, TG.CurrentRow.Index).Value = Format(discount_value, "0.0")
            TG.Item(9, TG.CurrentRow.Index).Value = Format((Val(txtQty.Text) * Val(txtRate.Text)) - Val(TG.Item(8, TG.CurrentRow.Index).Value), "0.00")
            TG.Item(9, TG.CurrentRow.Index).Value = Format(Math.Round(Val(TG.Item(9, TG.CurrentRow.Index).Value)), "0.00")
            If cmbDType.SelectedIndex = 0 Then
                TG.Item(11, TG.CurrentRow.Index).Value = Format(Val(txtRate.Text) - (Val(txtRate.Text) * Val(txtDVal.Text)) / 100, "0.00")
            Else
                TG.Item(11, TG.CurrentRow.Index).Value = Format(Val(txtRate.Text) - Val(txtAmt.Text), "0.00")
            End If

            TG.Item(14, TG.CurrentRow.Index).Value = DiscountLimit
            TG.Item(15, TG.CurrentRow.Index).Value = IIf(FreshDiscount, 1, 0)
            TG.Item(16, TG.CurrentRow.Index).Value = Val(txtSP.Text)

        Else

            Dim NRI = ESSA.FindGridIndex(TG, 0, PluID)
            If NRI = -1 Then NRI = TG.Rows.Add
            TG.Item(0, NRI).Value = PluID
            TG.Item(1, NRI).Value = NRI + 1
            TG.Item(2, NRI).Value = txtCode.Text
            TG.Item(3, NRI).Value = PluNm
            TG.Item(4, NRI).Value = Units
            TG.Item(5, NRI).Value = txtQty.Text + Val(TG.Item(5, NRI).Value)

            'Disabled for EPOS
            'If Val(txtDVal.Text) > 0 Then
            '    TG.Item(5, NRI).Value = txtQty.Text
            'End If

            TG.Item(6, NRI).Value = Format(Val(txtRate.Text), "0.00")
            TG.Item(7, NRI).Value = Format(Val(txtDVal.Text), "0.0")
            TG.Item(8, NRI).Value = Format(TG.Item(8, NRI).Value + Val(txtAmt.Text), "0.00")
            TG.Item(9, NRI).Value = Format((Val(TG.Item(5, NRI).Value) * Val(TG.Item(6, NRI).Value)) - Val(TG.Item(8, NRI).Value), "0.00")

            'N E W  R O U N D  O F F  M E T H O D
            '- - - - - - - -  - - - - - - - - - -

            TG.Item(9, NRI).Value = Format(Math.Round(Val(TG.Item(9, NRI).Value)), "0.00")

            If cmbDType.SelectedIndex = 0 Then
                TG.Item(11, NRI).Value = Format(Val(txtRate.Text) - (Val(txtRate.Text) * Val(txtDVal.Text)) / 100, "0.00")
            Else
                TG.Item(11, NRI).Value = Format(Val(txtRate.Text) - Val(txtAmt.Text), "0.00")
            End If

            TG.Item(13, NRI).Value = Val(lblStock.Text)
            TG.Item(14, NRI).Value = DiscountLimit
            TG.Item(15, NRI).Value = IIf(FreshDiscount, 1, 0)

            'ADDING SPCode
            '- - - - - - - -  - - - - - - - - - -
            TG.Item(16, NRI).Value = Val(txtSP.Text)

        End If

        If cmbDType.Visible = True Then
            If FreshDiscount Then
                lblCode.Text = "Product Code"
                ResetField(False)
            Else
                ResetField(True)
            End If
        Else
            ResetField(False)
        End If

        FreshDiscount = False

        CalculateTotal()

    End Sub

    Private Sub cmbDType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbDType.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If cmbDType.SelectedIndex = 0 Then
                txtAmt.ReadOnly = True
                txtDVal.Focus()
            Else
                txtDVal.ReadOnly = True
                txtAmt.Focus()
            End If

        End If

    End Sub

    Private Sub ShowDiscountPanel(ByVal ISShow As Boolean)

        lblDType.Visible = ISShow
        lblDVal.Visible = ISShow
        lblDAmt.Visible = ISShow

        txtDVal.Visible = ISShow
        txtAmt.Visible = ISShow
        cmbDType.Visible = ISShow

    End Sub

    Private Sub txtDVal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDVal.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Val(txtDVal.Text) < 0 Then
                TTip.Show("Discount value should not less then zero..!", txtDVal, 0, 25, 2000)
                Exit Sub
            End If

            If cmbDType.SelectedIndex = 0 Then
                txtAmt_KeyDown(sender, e)
            Else
                txtAmt.Focus()
            End If

        End If

    End Sub

    Private Sub txtDVal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDVal.TextChanged

        If cmbDType.SelectedIndex = 0 Then

            If DiscountLimit > 0 And Val(txtDVal.Text) > DiscountLimit Then
                txtDVal.Text = DiscountLimit
            End If

        End If

        CalculateDiscount()

    End Sub

    Private Sub CalculateDiscount()

        Dim amt As Double = 0
        amt = Val(txtQty.Text) * Val(txtRate.Text)
        amt = (amt * Val(txtDVal.Text)) / 100
        txtAmt.Text = Format(amt, "0.00")

    End Sub

    Private Sub ResetSerial()

        For i As Short = 0 To TG.Rows.Count - 1
            TG.Item(1, i).Value = i + 1
        Next

    End Sub

    Private Sub txtAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmt.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Addrows()
        End If

    End Sub

    Public Sub CalculateTotal()

        Dim Amt As Double = 0
        Dim Qty As Double = 0
        Dim Dis As Double = 0

        For i As Short = 0 To TG.Rows.Count - 1

            If Val(TG.Item(5, i).Value) > 0 Then Qty += Val(TG.Item(5, i).Value)
            Dis += Val(TG.Item(8, i).Value)
            Amt += Val(TG.Item(9, i).Value)

        Next

        lblTotAmt.Text = Format(Amt + Dis, "0.00")
        lblQty.Text = Qty
        lblDisAmt.Text = Format(Dis, "0.00")
        lblRndOff.Text = Format(Math.Round(Amt) - Amt, "0.00")
        lblBillAmt.Text = Format(Amt + Val(lblRndOff.Text), "0.00")
        lblNetAmt.Text = Format(Val(lblBillAmt.Text), "0.00")

    End Sub

    Private Async Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        'LoadHoldBills()
        'LoadProductList()
        PnlLoading.Visible = True
        PnlLoading.Refresh()
        Await RefreshBill()
        PnlLoading.Visible = False

    End Sub

    Private Sub ResetField(Optional ByVal HideDiscountPanel As Boolean = False)

        ShowDiscountPanel(HideDiscountPanel)
        lblHead.Text = "  ePOS"
        txtAmt.ReadOnly = False
        txtDVal.ReadOnly = False
        txtCode.Clear()
        lblStock.Text = "0"
        txtRate.Clear()
        txtQty.Clear()
        txtDVal.Clear()
        txtAmt.Clear()
        txtCode.Focus()

    End Sub

    Private Async Function GenerateBillNo() As Task

        'SQL = "select max(billid) from billmaster"
        'BillID = ESSA.GenerateID(SQL)

        'BillID = Format(BillNo, TermID.ToString("00") & Now.Year.ToString("yy") & "000000")

        '/*
        ' Regular user method
        '*/

        'SQL = "select max(billno) from billmaster where termid=" & TermID & " and billdt between '" _
        '    & Format(SDate, "yyyy-MM-dd") & "' and '" & Format(EDate, "yyyy-MM-dd") & "'"
        'BillNo = ESSA.GenerateID(SQL)
        'lblBillNo.Text = TermID & "/" & BillNo

        'BillID = TermID & Format(Now, "yy") & Format(BillNo, "00000000")

        '/*
        ' New user method
        '*/

        Try

            SQL = "select max(billno) from billmaster where shopid = " & ShopID & " and termid=" & TermID & " and billdt between '" _
            & Format(SDate, "yyyy-MM-dd") & "' and '" & Format(EDate, "yyyy-MM-dd") & "'"
            BillNo = Await ESSA.GenerateIDAsync(SQL)
            lblBillNo.Text = TermID & "/" & BillNo

            Dim billCode = Format(SDate, "yy") & Format(EDate, "yy") & Format(ShopID, "00") & Format(TermID, "00") & Format(BillNo, "000000")
            BillID = CLng(billCode)

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try


    End Function

    Public Function PaymentTotal() As Double

        PaymentTotal = 0
        For i As SByte = 0 To TGPmt.Rows.Count - 1
            PaymentTotal += Val(TGPmt.Item(4, i).Value)
        Next

    End Function

    Private Async Sub HoldBill(Optional CsName As String = "")

        Dim iHoldID As Integer = 0

        ESSA.OpenConnection()
        Dim Cmd = Con.CreateCommand
        Dim Trn = Con.BeginTransaction
        Cmd.Transaction = Trn

        Try

            'iHoldID = ESSA.GenerateID("select max(billid) from billdetailshold where shopid = " & ShopID & "")
            iHoldID = ESSA.GenerateID("select max(billid) from billdetailshold")

            For i As Short = 0 To TG.Rows.Count - 1

                SQL = "insert into billdetailsHold values (" _
                    & iHoldID & ",'" _
                    & Format(Now, "yyyy-MM-dd hh:mm:ssss") & "'," _
                    & Val(TG.Item(0, i).Value) & "," _
                    & Val(TG.Item(5, i).Value) & ",0," _
                    & Val(TG.Item(11, i).Value) & "," _
                    & Val(TG.Item(9, i).Value) & "," _
                    & Val(TG.Item(7, i).Value) & "," _
                    & Val(TG.Item(8, i).Value) & "," _
                    & Val(TG.Item(6, i).Value) & "," _
                    & TermID & "," _
                    & i + 1 & ",'" _
                    & CsName & "'," _
                    & ShopID & ")"

                Cmd.CommandText = SQL
                Cmd.ExecuteNonQuery()

                SQL = "INSERT INTO BillSalePersonsHold VALUES(" _
                    & iHoldID & "," _
                    & Val(TG.Item(16, i).Value) & "," _
                    & Val(TG.Item(0, i).Value) & ", " _
                    & ShopID & ")"

                Cmd.CommandText = SQL
                Cmd.ExecuteNonQuery()

            Next

            Trn.Commit()
            Con.Close()

        Catch ex As Exception
            Trn.Rollback()
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        If MsgBox("Bill hold successfully, do you want to print estimate..!", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = vbYes Then
            'PrintHoldBill(iHoldID, "ESTIMATE")
            PrintHoldBillUsingCrystalReports(iHoldID)
        End If
        Await RefreshBill()
        Await LoadHoldBills()

    End Sub

    Public Async Function SaveBill() As Task

        Try

            If TG.Rows.Count = 0 Then
                TTip.Show("No items to generate to bill..!", btnStore, 0, 25, 2000)
                Exit Function
            End If

            If ESSA.IsDuplicateExists(TG, 0) Then
                TTip.Show("Duplicate barcode exists", btnStore, 0, 25, 2000)
                Exit Function
            End If

            ESSA.OpenConnection()
            Dim Cmd = Con.CreateCommand
            Dim Trn = Con.BeginTransaction(IsolationLevel.Serializable)
            Cmd.Transaction = Trn

            Try

                If Edit = False Then

                    nTermID = TermID

                    Await GenerateBillNo()

                    If HoldID.Count > 0 Then
                        Dim HoldIdList As String = ""
                        For Each Item In HoldID
                            HoldIdList = Item & ","
                        Next
                        HoldIdList = Mid(HoldIdList, 1, HoldIdList.Length - 1)
                        SQL = "delete from billdetailshold where shopid = " & ShopID & " and billid in (" & HoldIdList & ")"
                        Cmd.CommandText = SQL
                        Await Cmd.ExecuteNonQueryAsync()
                    End If

                Else

                    SQL = "delete from billmaster where shopid = " & ShopID & " and billid=" & BillID & ";" _
                       & "delete from billdetails where shopid = " & ShopID & " and billid=" & BillID & ";" _
                       & "delete from billpayments where shopid = " & ShopID & " and billid=" & BillID & ";" _
                       & "delete from billsalepersons where shopid = " & ShopID & " and billid=" & BillID & ";"

                    Cmd.CommandText = SQL
                    Await Cmd.ExecuteNonQueryAsync()

                End If

                SQL = "insert into billmaster values (" _
                    & BillID & "," _
                    & BillNo & ",'" _
                    & IIf(ISAdmin, IIf(BillMode = 0 AndAlso Edit = False, Format(Now.Date, "yyyy-MM-dd"), Format(billDt, "yyyy-MM-dd")), Format(Now.Date, "yyyy-MM-dd")) & "','" _
                    & IIf(ISAdmin, IIf(BillMode = 0 AndAlso Edit = False, Format(Now, "yyyy-MM-dd HH:mm:ss"), Format(billTime, "yyyy-MM-dd HH:mm:ss")), Format(Now, "yyyy-MM-dd HH:mm:ss")) & "'," _
                    & nTermID & "," _
                    & Val(lblQty.Text) & "," _
                    & Val(lblNetAmt.Text) & "," _
                    & Val(lblDisPerc.Text) & "," _
                    & Val(lblDisAmt.Text) & "," _
                    & customerId & ",'" _
                    & eRefNo & "','" _
                    & Remark & "'," _
                    & ShopID & "," _
                    & UserID & ",0,1)"

                Cmd.CommandText = SQL
                Await Cmd.ExecuteNonQueryAsync()

                For i As Short = 0 To TG.Rows.Count - 1

                    SQL = "insert into billdetails values (" _
                        & BillID & ",'" _
                        & IIf(ISAdmin, IIf(BillMode = 0 And Edit = False, Format(Now.Date, "yyyy-MM-dd"), Format(billDt, "yyyy-MM-dd")), Format(Now.Date, "yyyy-MM-dd")) & "'," _
                        & Val(TG.Item(0, i).Value) & "," _
                        & Val(TG.Item(5, i).Value) & ",0," _
                        & Val(TG.Item(11, i).Value) & "," _
                        & Val(TG.Item(9, i).Value) & "," _
                        & Val(TG.Item(7, i).Value) & "," _
                        & Val(TG.Item(8, i).Value) & "," _
                        & Val(TG.Item(6, i).Value) & "," _
                        & Val(TG.Item(12, i).Value) & "," _
                        & BillMode & "," _
                        & nTermID & "," _
                        & ShopID & "," _
                        & i + 1 & ",0,1);"

                    Cmd.CommandText = SQL
                    Await Cmd.ExecuteNonQueryAsync()

                    SQL = "INSERT INTO BillSalePersons VALUES(" _
                        & BillID & "," _
                        & Val(TG.Item(16, i).Value) & "," _
                        & Val(TG.Item(0, i).Value) & ", " _
                        & ShopID & ")"

                    Cmd.CommandText = SQL
                    Await Cmd.ExecuteNonQueryAsync()

                Next

                If NewPaymentMode And ISReturn = False Then

                    If Val(TxtCashNew.Text) > 0 Then

                        SQL = $"insert into billpayments values(
                    {BillID},
                    {ShopID},
                    1,
                    'CASH',
                    {Val(TxtCashNew.Text)},
                    {Val(LblReturnInCash.Text)},
                    '',
                    getdate(),
                    1,
                    {nTermID},
                    '{IIf(ISAdmin, IIf(BillMode = 0 And Edit = False, Format(Now.Date, "yyyy-MM-dd"), Format(billDt, "yyyy-MM-dd")), Format(Now.Date, "yyyy-MM-dd"))}',
                    0,
                    1)"

                        Cmd.CommandText = SQL
                        Await Cmd.ExecuteNonQueryAsync()

                    End If

                    If Val(TxtCardNew.Text) > 0 Then

                        SQL = $"insert into billpayments values(
                    {BillID},
                    {ShopID},
                    2,
                    'CARD',
                    {Val(TxtCardNew.Text)},
                    0,
                    '',
                    getdate(),
                    {IIf(Val(TxtCashNew.Text) > 0, 2, 1)},
                    {nTermID},
                    '{IIf(ISAdmin, IIf(BillMode = 0 And Edit = False, Format(Now.Date, "yyyy-MM-dd"), Format(billDt, "yyyy-MM-dd")), Format(Now.Date, "yyyy-MM-dd"))}',
                    0,
                    1)"

                        Cmd.CommandText = SQL
                        Await Cmd.ExecuteNonQueryAsync()

                    End If

                    If Val(TxtUpiNew.Text) > 0 Then

                        SQL = $"insert into billpayments values(
                    {BillID},
                    {ShopID},
                    3,
                    'UPI',
                    {Val(TxtUpiNew.Text)},
                    0,
                    '',
                    getdate(),
                    {IIf(Val(TxtCashNew.Text) > 0, IIf(Val(TxtCardNew.Text) > 0, 3, 2), 1)},
                    {nTermID},
                    '{IIf(ISAdmin, IIf(BillMode = 0 And Edit = False, Format(Now.Date, "yyyy-MM-dd"), Format(billDt, "yyyy-MM-dd")), Format(Now.Date, "yyyy-MM-dd"))}',
                    0,
                    1)"

                        Cmd.CommandText = SQL
                        Await Cmd.ExecuteNonQueryAsync()

                    End If

                Else

                    For j As SByte = 0 To TGPmt.Rows.Count - 1

                        SQL = "insert into billpayments values (" _
                        & BillID & "," _
                        & ShopID & "," _
                        & Val(TGPmt.Item(0, j).Value) & ",'" _
                        & TGPmt.Item(1, j).Value & "'," _
                        & Val(TGPmt.Item(4, j).Value) & "," _
                        & Val(TGPmt.Item(5, j).Value) & ",'" _
                        & TGPmt.Item(2, j).Value & "','" _
                        & Format(CDate(TGPmt.Item(3, j).Value), "yyyy-MM-dd") & "'," _
                        & j + 1 & "," _
                        & nTermID & ",'" _
                        & IIf(ISAdmin, IIf(BillMode = 0 And Edit = False, Format(Now.Date, "yyyy-MM-dd"), Format(billDt, "yyyy-MM-dd")), Format(Now.Date, "yyyy-MM-dd")) & "',0,1)"

                        Cmd.CommandText = SQL
                        Await Cmd.ExecuteNonQueryAsync()

                    Next

                End If

                Trn.Commit()
                'Trn = Nothing
                'IsBillSaved = True
                Con.Close()

                'If chkEP.Checked = True Then
                '    PrintBill(BillID, BillType)
                'End If

                'Catch ex As Exception

                '    Trn.Rollback()
                '    Con.Close()
                '    MsgBox(ex.Message, MsgBoxStyle.Critical)
                '    Exit Sub

                'End Try

            Catch ex As SqlException
                Trn.Rollback()
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Function
            Catch ex1 As Exception
                Trn.Rollback()
                MsgBox(ex1.Message, MsgBoxStyle.Critical)
                Exit Function
            Finally
                Trn?.Dispose()
                If Con IsNot Nothing AndAlso Con.State = ConnectionState.Open Then
                    Con.Close()
                End If
            End Try

            If chkEP.Checked = True Then
                'PrintBill(BillID, BillType)
                Await PrintBillUsingCrystalReport(BillID, "Original")
            End If

            If Not MobileNo.Trim = String.Empty AndAlso MobileNo.Length = 10 Then
                Await SendSmsAsync(MobileNo, ShopNm, Format(Now.Date, "dd-MM-yyyy"), shopNumber)
                MobileNo = ""
                'If Not MsgBox("Send Sms..?", MsgBoxStyle.Question + MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                '    'Await SendSmsAsync(MobileNo, ShopNm, Format(Now.Date, "dd-MM-yyyy"))
                'End If
            End If

            Await RefreshBill()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Function

    Private Async Function PrintBillUsingCrystalReport(Id As Long, type As String) As Task

        Try

            Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument = If(is3InchPrinter, rptSaleBill, rptSaleBill4inch)

            'Dim rpt As New SaleBill
            Dim ShopName As String = String.Empty
            Dim Address As String = String.Empty
            Dim ContactNo As String = String.Empty
            Dim GST As String = String.Empty
            SQL = $"select shopname,address1 + ' ' + address2 + ' ' + city + ' ' +  state address,phone,cst from shops where shopid = {ShopID}"
            With ESSA.OpenReader(SQL)
                If .Read Then
                    ShopName = .Item("shopname").trim
                    Address = .Item("address").trim
                    ContactNo = .Item("phone").trim
                    GST = .Item("cst").trim
                End If
                .Close()
            End With

            Dim SQL1 = $"select a.taxperc,sum(a.taxable) taxable,sum(tax) tax  from
                (select distinct d.pluid,
                case when d.rate > t.val 
                then t.mx 
                else t.mn end as taxperc,
                case when d.rate > t.val 
                then ROUND((100/(100+t.mx)) * d.amount,2) 
                else ROUND((100/(100+t.mn)) * d.amount,2)  end as taxable,
                case when d.rate > t.val 
                then ROUND(((100/(100+t.mx)) * d.amount)* t.mx * 0.01,2) 
                else ROUND(((100/(100+t.mn)) * d.amount)* t.mn * 0.01,2) end as tax
                from billdetails d 
                inner join billmaster m on m.billid = d.billid and m.shopid = {ShopID} and m.billid = {Id}
                inner join productmaster p on p.pluid = d.pluid
                inner join producttax t on t.hsn = p.hsncode) a
                group by a.taxperc"

            Dim task1 = Task.Run(Function() ESSA.GetDataTable(SQL1))

            Dim SQL2 = $"select distinct paymentdesc mode,sum(paid) amt,sum(refund) refund, billid 
                from billpayments p where shopid = {ShopID} and billid = {Id}
                group by paymentdesc,billid"

            Dim task2 = Task.Run(Function() ESSA.GetDataTable(SQL2))


            Dim SQLMain = $"select 
                'T' + convert(varchar,m.termid) + '-' + convert(varchar,m.billno) billno,
                m.billtime date, 
                d.sno,p.pluname description,d.qty,d.orate rate,d.disamt disc,d.amount,
                p.plucode barcode,p.hsncode hsn,
                c.customername name,c.phone mobile
                from billdetails d 
                inner join billmaster m on m.billid = d.billid and m.billid = {Id}
                inner join productmaster p on p.pluid = d.pluid
                inner join customers c on c.customerid = m.customerid
                order by d.sno"

            Dim mainTask = Task.Run(Function() ESSA.GetDataTable(SQLMain))

            Await Task.WhenAll(task1, task2, mainTask)
            rpt.Subreports.Item("TaxInfo").SetDataSource(task1.Result)
            rpt.Subreports.Item("PaymentInfo").SetDataSource(task2.Result)
            rpt.SetDataSource(mainTask.Result)
            rpt.SetParameterValue("ShopName", ShopName)
            rpt.SetParameterValue("Address", Address)
            rpt.SetParameterValue("ContactNo", ContactNo)
            rpt.SetParameterValue("GST", GST)
            rpt.PrintOptions.PrinterName = PrinterName
            'FrmReportViewer.CrystalReportViewer1.ReportSource = rpt
            'FrmReportViewer.Visible = False
            'FrmReportViewer.Show()

            Try
                If type = "Reprint" Then
                    rpt.SetParameterValue("BillType", "Duplicate")
                    For i = 1 To NewRePrintCopies
                        rpt.PrintToPrinter(1, False, 0, 0)
                    Next
                Else
                    rpt.SetParameterValue("BillType", "Original")
                    rpt.PrintToPrinter(1, False, 0, 0)
                    If NewPrintCopies = 2 Then
                        rpt.SetParameterValue("BillType", "Duplicate")
                        rpt.PrintToPrinter(1, False, 0, 0)
                    End If
                End If

                rpt.Close()
                rpt.SetDataSource(CType(Nothing, DataTable))
                rpt.Subreports.Item("TaxInfo").SetDataSource(CType(Nothing, DataTable))
                rpt.Subreports.Item("PaymentInfo").SetDataSource(CType(Nothing, DataTable))

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Function

    Private Async Sub btnStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStore.Click

        If TG.Rows.Count = 0 Then
            TTip.Show("No items to generate to bill..!", btnStore, 0, 25, 2000)
            Exit Sub
        ElseIf cmbCustomer.SelectedIndex = -1 Then
            'TTip.Show("Customer not selected..!", cmbCustomer, 0, 25, 2000)
            'cmbCustomer.Focus()
            'Exit Sub
            cmbCustomer.SelectedValue = customerId
        End If

        '// Insert Items For Sales Commission

        If AllowSalesCommission Then

            TGSP.Rows.Clear()

            For i As Short = 0 To TG.Rows.Count - 1

                If Val(TG.Item(5, i).Value) >= 0 Then

                    TGSP.Rows.Add()
                    TGSP.Item(0, TGSP.Rows.Count - 1).Value = Val(TG.Item(0, i).Value)
                    TGSP.Item(1, TGSP.Rows.Count - 1).Value = Val(TG.Item(2, i).Value)
                    TGSP.Item(2, TGSP.Rows.Count - 1).Value = Val(TG.Item(5, i).Value)
                    TGSP.Item(3, TGSP.Rows.Count - 1).Value = Format(Val(TG.Item(9, i).Value), "0.00")

                End If

            Next

        Else

            If ISReturn Then
                TGPmt.Item(4, 0).Value = Format(Val(lblBillAmt.Text), "0.00")
            End If

            If PaymentTotal() <> Val(lblBillAmt.Text) Then
                If NewPaymentMode Then
                    If Edit Or BillMode = 1 Then
                        If customerId > 1 Then
                            PnlPaymentNew.Visible = True
                            PnlPaymentNew.BringToFront()
                            TxtCashNew.Focus()
                            Exit Sub
                        End If
                    End If
                    PnlCustomerInfo.Visible = True
                    PnlCustomerInfo.BringToFront()
                    TxtCustMobile.Focus()
                    Exit Sub
                Else
                    pnlPayment.Visible = True
                    pnlPayment.BringToFront()
                    cmbPmtType.Focus()
                    Exit Sub
                End If
            End If

        End If

        'If IsBillSaved = False Then
        '    SaveBill()
        'Else
        '    pnlReprint.Show()
        '    cmbTerm.SelectedIndex = cmbTerm.FindStringExact(TermID)
        '    SQL = "SELECT BillNo FROM Billmaster WHERE BillId =" & BillID
        '    With ESSA.OpenReader(SQL)
        '        If .Read Then
        '            txtBill.Text = .Item(0)
        '        End If
        '        .Close()
        '    End With
        'End If

        Await SaveBill()

    End Sub

    Private Async Function RefreshBill() As Task

        Try
            TG.Rows.Clear()

            If lblHead.Text = "  ePOS - Discount Mode" Then
                GetTheme(2)
                LoadTheme()
                DiscountLimit = iDiscountLimit
                lblHead.Text = "  ePOS"
            End If

            cmbPmtType.SelectedIndex = 0
            BillMode = 0
            Remark = ""
            eRefNo = ""
            BillType = "ORIGINAL"
            nTermID = TermID
            ISReturn = False
            Edit = False
            pnlAlter.Visible = False
            pnlPayment.Visible = False
            PnlCustomerInfo.Visible = False
            PnlPaymentNew.Visible = False
            IsBillSaved = False
            IsPresent = False
            customerId = 1
            cmbCustomer.SelectedValue = 1
            billDt = Format(Now.Date, "yyyy-MM-dd")
            billTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
            MobileNo = ""
            message = ""

            HoldID.Clear()
            TGPmt.Rows.Clear()
            txtRefNo.Clear()
            txtAmt.Clear()
            TxtCustMobile.Clear()
            TxtCustName.Clear()
            TxtCashNew.Clear()
            TxtCardNew.Clear()
            TxtUpiNew.Clear()

            lblCode.Text = "Product Code"
            lblQty.Text = "0"
            lblNetAmt.Text = "0.00"
            lblTotAmt.Text = "0.00"
            lblDisAmt.Text = "0.00"
            lblRndOff.Text = "0.00"
            lblBillAmt.Text = "0.00"
            LblReturnInCash.Text = "0.00"
            txtSP.Clear()
            ResetField()
            txtCode.Focus()
            Await GenerateBillNo()
            'Commented For Quick reset
            'Await UpdateCustomerComboBox()
            'Await LoadSalesPersons()
            'Await UpdateShopSettings()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Function

    Private Sub cmbPmtType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbPmtType.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            cmbPmtType.SelectedIndex = cmbPmtType.FindStringExact(cmbPmtType.Text)
            If cmbPmtType.SelectedIndex = -1 Then
                TTip.Show("Incorrect payment mode..!", cmbPmtType, 0, 25, 2000)
                Exit Sub
            End If

            Dim Amt = Val(lblBillAmt.Text) - PaymentTotal()

            If cmbPmtType.SelectedIndex = 0 Then
                txtPAmt.Text = Format(Amt, "0.00")
                txtRefNo.Enabled = False
                mebDt.Enabled = False
                txtPAmt.Focus()
            Else
                txtPAmt.Text = Format(Amt, "0.00")
                txtRefNo.Enabled = True
                mebDt.Enabled = True
                txtRefNo.Focus()
            End If

        End If

    End Sub

    Private Sub txtPAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPAmt.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Val(txtPAmt.Text) <= 0 Then
                TTip.Show("Invalid payment amount..!", txtPAmt, 0, 25, 2000)
                Exit Sub
            ElseIf Val(txtPAmt.Text) + PaymentTotal() > Val(lblBillAmt.Text) Then
                If cmbPmtType.SelectedValue <> 1 Then
                    TTip.Show("Payment amount should not overflow..!", txtPAmt, 0, 25, 2000)
                    txtPAmt.Text = Format(Val(lblBillAmt.Text) - PaymentTotal(), "0.00")
                    Exit Sub
                End If
            End If

            Dim NRI = ESSA.FindGridIndex(TGPmt, 0, cmbPmtType.SelectedValue)
            If NRI = -1 Then NRI = TGPmt.Rows.Add

            TGPmt.Item(0, NRI).Value = cmbPmtType.SelectedValue
            TGPmt.Item(1, NRI).Value = cmbPmtType.Text
            TGPmt.Item(2, NRI).Value = txtRefNo.Text
            TGPmt.Item(3, NRI).Value = Format(mebDt.Value, "dd/MM/yyyy")
            TGPmt.Item(4, NRI).Value = Format(Val(txtPAmt.Text), "0.00")

            If Val(txtPAmt.Text) + PaymentTotal() > Val(lblBillAmt.Text) Then
                If cmbPmtType.SelectedValue = 1 Then
                    TGPmt.Item(5, NRI).Value = Format(PaymentTotal() - Val(lblBillAmt.Text), "0.00")
                Else
                    TGPmt.Item(5, NRI).Value = 0
                End If
            Else
                TGPmt.Item(5, NRI).Value = 0
            End If

            'If Val(txtPAmt.Text) > Val(lblBillAmt.Text) Then
            '    TGPmt.Item(5, NRI).Value = Format(Val(txtPAmt.Text) - Val(lblBillAmt.Text), "0.00")
            'Else
            '    TGPmt.Item(5, NRI).Value = 0
            'End If

            txtRefNo.Clear()
            txtPAmt.Clear()
            cmbPmtType.Focus()

            If PaymentTotal() >= Val(lblBillAmt.Text) Then
                btnUpdate.PerformClick()
            End If

        End If

    End Sub

    Private Async Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        If PaymentTotal() >= Val(lblBillAmt.Text) Then

            'Remark = ""

            'If ShopID = 3 Then
            '    If Remarks.ShowDialog(Me) <> Windows.Forms.DialogResult.Cancel Then
            '        SaveBill()
            '    End If
            'Else
            '    'Remark = InputBox("Enter remarks here..!")
            '    Remark = ""
            '    SaveBill()
            'End If

            'Remark = ""

            If EnableRemarks = True Then

                If Remarks.ShowDialog(Me) <> Windows.Forms.DialogResult.Cancel Then
                    Await SaveBill()
                End If

            Else

                PnlLoading.Visible = True
                PnlLoading.BringToFront()
                Await SaveBill()
                PnlLoading.Visible = False

            End If

            'pnlPayment.Visible = False
            'Remark = ""
            'customerId = 1
            'If PnlCustomerInfo.Visible = False Then
            '    PnlCustomerInfo.Visible = True
            '    TxtCustMobile.Focus()
            'End If

        End If

    End Sub

    Private Async Function LoadHoldBills() As Task

        SQL = "select BillID,billdt Date,CustName,sum(qty) Quantity,sum(qty*rate) Amount from billdetailshold where shopid = " & ShopID & " group by " _
            & "billid,billdt,CustName order by billid desc"

        With Await ESSA.OpenReaderAsync(SQL)
            TGHold.Rows.Clear()
            While Await .ReadAsync
                TGHold.Rows.Add()
                TGHold.Item(0, TGHold.Rows.Count - 1).Value = .Item(0)
                TGHold.Item(1, TGHold.Rows.Count - 1).Value = Format(.GetDateTime(1), "dd-MM-yyyy")
                TGHold.Item(2, TGHold.Rows.Count - 1).Value = .GetString(2).Trim
                TGHold.Item(3, TGHold.Rows.Count - 1).Value = .Item(3)
                TGHold.Item(4, TGHold.Rows.Count - 1).Value = Format(.Item(4), "0.00")
            End While
            .Close()
        End With

        If TGHold.Rows.Count > 0 Then btnHold.Text = "Hold (" & TGHold.Rows.Count + 1 & ")"

    End Function

    Private Sub AlignColumn(ByVal DGV As DataGridView, ByVal Col As SByte, ByVal Align As DataGridViewContentAlignment)

        With DGV
            .Columns(Col).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(Col).HeaderCell.Style.Alignment = Align
            .Columns(2).DefaultCellStyle.Alignment = Align
        End With

    End Sub

    Private Sub btnHold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHold.Click

        If TG.Rows.Count = 0 Then
            If TGHold.Rows.Count > 0 Then
                pnlHold.Visible = True
                TGHold.Focus()
                Exit Sub
            Else
                TTip.Show("No items to generate to bill..!", btnStore, 0, 25, 2000)
                Exit Sub
            End If
        ElseIf cmbCustomer.SelectedIndex = -1 Then
            TTip.Show("Customer not selected..!", cmbCustomer, 0, 25, 2000)
            cmbCustomer.Focus()
            Exit Sub
        End If

        Dim CName = InputBox("Enter customer name for this HOLD Bill...?")
        If CName.Trim = String.Empty Then
            TTip.Show("Please enter customer name..!", btnHold, 0, 25, 2000)
            Exit Sub
        End If


        HoldBill(CName)

    End Sub

    Private Sub ViewHoldBill(holdBillId As Long)

        'before sales person
        'SQL = "select d.pluid,d.sno,p.plucode,p.pluname,p.units,d.qty,d.orate,d.disperc,d.disamt,d.amount,0,d.rate,v.stock from billdetailshold d,productmaster p,v_stockpos v where d.pluid=v.pluid and d.pluid=p.pluid and d.billid=" & holdBillId & " order by d.sno"

        'for sales perosn
        SQL = "select a.*,isnull(b.spcode,1) from (select d.pluid,d.sno,p.plucode,p.pluname,p.units,d.qty,d.orate,d.disperc,d.disamt,d.amount,d.rate,v.stock,d.billid from billdetailshold d,productmaster p,v_stockpos v where d.pluid=v.pluid and d.pluid=p.pluid and v.location_id = " & ShopID & " and d.shopid = " & ShopID & " and d.billid=" & holdBillId & ")a left join (select h.*,s.spcode from billsalepersonshold h, salespersons s where s.spid = h.spid and h.shopid = " & ShopID & ") b on b.billid = a.billid and b.pluid = a.pluid order by a.sno"
        With ESSA.OpenReader(SQL)
            While .Read
                HoldSerialNo += 1
                TG.Rows.Add()
                TG.Item(0, TG.Rows.Count - 1).Value = .Item(0)
                TG.Item(1, TG.Rows.Count - 1).Value = HoldSerialNo
                TG.Item(2, TG.Rows.Count - 1).Value = .GetString(2)
                TG.Item(3, TG.Rows.Count - 1).Value = .GetString(3)
                TG.Item(4, TG.Rows.Count - 1).Value = .GetString(4)
                TG.Item(5, TG.Rows.Count - 1).Value = .Item(5)
                TG.Item(6, TG.Rows.Count - 1).Value = Format(.Item(6), "0.00")
                TG.Item(7, TG.Rows.Count - 1).Value = Format(.Item(7), "0.0")
                TG.Item(8, TG.Rows.Count - 1).Value = Format(.Item(8), "0.00")
                TG.Item(9, TG.Rows.Count - 1).Value = Format(.Item(9), "0.00")
                TG.Item(11, TG.Rows.Count - 1).Value = Format(.Item(10), "0.00")
                TG.Item(13, TG.Rows.Count - 1).Value = .Item(11)
                TG.Item(16, TG.Rows.Count - 1).Value = .Item(13)
            End While
            .Close()
        End With

    End Sub

    Private HoldSerialNo As Short = 0

    Private Sub ViewHoldBillSelected()

        Dim SelectedBillCount As Short = 0
        HoldSerialNo = 0

        For i As Short = 0 To TGHold.Rows.Count - 1
            If TGHold.Item(7, i).Value = 1 Then
                ViewHoldBill(TGHold.Item(0, i).Value)
                HoldID.Add(Val(TGHold.Item(0, i).Value))
                SelectedBillCount += 1
            End If
        Next

        'HoldID = TGHold.Item(0, TGHold.CurrentRow.Index).Value
        If SelectedBillCount > 0 Then
            CalculateTotal()
            pnlHold.Visible = False
            txtCode.Focus()
        Else
            MsgBox("Zero bills selected!", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub TGHold_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TGHold.CellClick

        If e.RowIndex = -1 Then Exit Sub

        If e.ColumnIndex = 5 Then
            HoldSerialNo = 0
            ViewHoldBill(TGHold.Item(0, e.RowIndex).Value)
            HoldID.Add(Val(TGHold.Item(0, e.RowIndex).Value))
            CalculateTotal()
            pnlHold.Visible = False
            txtCode.Focus()
        ElseIf e.ColumnIndex = 6 Then
            'PrintHoldBill(TGHold.Item(0, e.RowIndex).Value, "ESTIMATE")
            PrintHoldBillUsingCrystalReports(TGHold.Item(0, e.RowIndex).Value)
        End If

    End Sub

    Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click

        pnlReprint.Show()
        cmbTerm.SelectedIndex = cmbTerm.FindStringExact(TermID)
        txtBill.Focus()

    End Sub

    Private Sub btnPnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        pnlAlter.Visible = False

    End Sub

    Private Sub txtBillNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBillNo.KeyDown

        TGBills_KeyDown(sender, e)

    End Sub

    Private Sub txtBillNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBillNo.KeyUp

        If e.KeyCode <> Keys.Enter Then
            ESSA.FindAndSelect(TGBills, 1, txtBillNo.Text)
        End If

    End Sub

    Private Sub TGBills_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TGBills.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            'Dim TQty As Double = 0
            TGEdt.Rows.Clear()
            txtSno.Text = ""
            txtPlucode.Text = ""
            txtAQty.Text = ""
            txtRQty.Text = ""
            If TGBills.CurrentCell Is Nothing Then Exit Sub

            'SQL = "select v.pluid,"

            'SQL = "select sum(qty) from billdetails where obillid=" & Val(TGBills.Item(0, TGBills.CurrentRow.Index).Value)
            'lblTRtn.Text = ESSA.GetData(SQL)

            'SERVER ABU
            'SQL = "select d.pluid,d.sno,p.plucode,p.pluname,p.units,d.qty,d.rate,d.disperc,d.disamt,d.amount,d.rate from billdetails d,productmaster p where d.pluid=p.pluid and d.billid=" & TGBills.Item(0, TGBills.CurrentRow.Index).Value & " order by d.sno"

            SQL = "select a.*,isnull(b.spcode,1) from (select d.pluid,d.sno,p.plucode,p.pluname,p.units,d.qty,d.rate,d.disperc,d.disamt,d.amount,d.billid from billdetails d,productmaster p where d.pluid=p.pluid and d.billid=" & TGBills.Item(0, TGBills.CurrentRow.Index).Value & ") a left join (select sp.pluid,sp.billid,sp.spid,s.spcode from billsalepersons sp inner join salespersons s on sp.spid = s.spid and sp.shopid = " & ShopID & ") b on b.billid = a.billid and b.pluid = a.pluid order by a.sno"

            With ESSA.OpenReader(SQL)
                While .Read
                    TGEdt.Rows.Add()
                    TGEdt.Item(0, TGEdt.Rows.Count - 1).Value = .Item(0)
                    TGEdt.Item(1, TGEdt.Rows.Count - 1).Value = .Item(1)
                    TGEdt.Item(2, TGEdt.Rows.Count - 1).Value = .GetString(2)
                    TGEdt.Item(3, TGEdt.Rows.Count - 1).Value = .GetString(3)
                    TGEdt.Item(4, TGEdt.Rows.Count - 1).Value = .GetString(4)
                    TGEdt.Item(5, TGEdt.Rows.Count - 1).Value = .Item(5)
                    TGEdt.Item(6, TGEdt.Rows.Count - 1).Value = 0
                    TGEdt.Item(7, TGEdt.Rows.Count - 1).Value = Format(.Item(6), "0.00")
                    TGEdt.Item(8, TGEdt.Rows.Count - 1).Value = Format(.Item(7), "0.0")
                    TGEdt.Item(9, TGEdt.Rows.Count - 1).Value = Format(.Item(8), "0.00")
                    TGEdt.Item(10, TGEdt.Rows.Count - 1).Value = Format(.Item(9), "0.00")
                    TGEdt.Item(11, TGEdt.Rows.Count - 1).Value = ""
                    'TGEdt.Item(12, TGEdt.Rows.Count - 1).Value = Format(.Item(10), "0.00")
                    'SPID
                    TGEdt.Item(12, TGEdt.Rows.Count - 1).Value = Format(.Item(6), "0.00")
                    TGEdt.Item(13, TGEdt.Rows.Count - 1).Value = .Item(11)
                    'TQty += .Item(5)
                End While
                .Close()
            End With

            'lblTSold.Text = TQty

            txtSno.Focus()

        End If

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click

        If cmbATerm.SelectedIndex = -1 Then Exit Sub

        SQL = "select billid,BillNo,billdt 'Date',RIGHT(CONVERT(VARCHAR(30), BILLTIME, 9), 14) 'Bill Time',TermId from billmaster where shopid = " & ShopID & " and billdt between '" _
            & Format(mebFrom.Value, "yyyy-MM-dd") & "' and '" & Format(mebTo.Value, "yyyy-MM-dd") & "'"

        If cmbATerm.SelectedIndex > 0 Then
            SQL &= " and termid=" & cmbATerm.Text
        End If

        SQL &= " order by billno"

        ESSA.LoadDataGrid(TGBills, SQL)
        TGBills.Columns(0).Visible = False
        TGBills.Columns(1).Width = 60
        TGBills.Columns(2).Width = 70
        TGBills.Columns(3).Width = 100
        TGBills.Columns(4).Width = 60
        txtBillNo.Focus()

    End Sub

    Private Sub txtSno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSno.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True
            txtPlucode.Text = TGEdt.Item(2, TGEdt.CurrentRow.Index).Value
            txtAQty.Text = TGEdt.Item(5, TGEdt.CurrentRow.Index).Value
            txtRQty.Focus()

        End If

    End Sub

    Private Sub txtSno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSno.KeyUp

        If e.KeyCode = Keys.Down Then
            TGEdt.Focus()
        ElseIf e.KeyCode <> Keys.Enter Then
            ESSA.FindAndSelect(TGEdt, 1, txtSno.Text)
        End If

    End Sub

    Private Sub txtRQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRQty.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Val(txtRQty.Text) <= Val(txtAQty.Text) Then
                TGEdt.Item(6, TGEdt.CurrentRow.Index).Value = Val(txtRQty.Text)
                txtSno.Clear()
                txtPlucode.Clear()
                txtAQty.Clear()
                txtRQty.Clear()
                txtSno.Focus()
            Else
                TTip.Show("Return quantity should not more than available quantity..!", txtRQty, 0, 25, 2000)
                txtRQty.SelectAll()
            End If
        End If

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        BillMode = 0
        BillType = "ORIGINAL"

        If Not ISAdmin Then
            If CDate(TGBills.Item(2, TGBills.CurrentRow.Index).Value).Date <> Now.Date Then
                MsgBox("The alteration has been blocked to this bill..!", MsgBoxStyle.Information)
                Exit Sub
            End If

            If alterPwd <> String.Empty Then
                Dim result = AlterPassword.ShowDialog(Me)
                If result = 2 Then
                    If Not AlterPassword.isAllowed Then
                        Exit Sub
                    End If
                End If
            End If

        End If

        Edit = True

        'SERVER ABU
        'SQL = "select billid,billno,customerid,termid from billmaster where billid=" & Val(TGBills.Item(0, TGBills.CurrentRow.Index).Value) & ";" _
        '    & "select d.pluid,d.sno,p.plucode,p.pluname,p.units,d.qty,d.orate,d.disperc,d.disamt,d.amount,d.rate,(v.stock+d.qty) stk from billdetails d,productmaster p,v_stockpos v where d.pluid=v.pluid and d.pluid=p.pluid and d.billid=" & TGBills.Item(0, TGBills.CurrentRow.Index).Value & " order by d.sno"

        SQL = "select billid,billno,customerid,termid,billdt,billtime from billmaster where shopid = " & ShopID & " and billid=" & Val(TGBills.Item(0, TGBills.CurrentRow.Index).Value) & ";" _
            & "select a.*,isnull(b.spcode,1) from (select d.pluid,d.sno,p.plucode,p.pluname,p.units,d.qty,d.orate,d.disperc,d.disamt,d.amount,d.rate,(v.stock+d.qty) stk,d.billid from billdetails d,productmaster p,v_stockpos v where d.shopid = " & ShopID & " and v.location_id = " & ShopID & " and d.pluid=v.pluid and d.pluid=p.pluid and d.billid=" & TGBills.Item(0, TGBills.CurrentRow.Index).Value & ")a left join (select bsp.billid,bsp.pluid,bsp.spid,sp.spcode from billsalepersons bsp inner join salespersons sp on sp.spid = bsp.spid and bsp.shopid = " & ShopID & ") b on b.billid = a.billid and b.pluid = a.pluid order by a.sno"

        With ESSA.OpenReader(SQL)
            If .Read Then
                nTermID = .Item(3)
                BillID = .Item(0)
                BillNo = .Item(1)
                lblBillNo.Text = nTermID & "/" & BillNo
                cmbCustomer.SelectedValue = .Item(2)
                customerId = .Item(2)
                billDt = .GetDateTime(4).Date
                billTime = .GetDateTime(5)
            End If

            .NextResult()

            TG.Rows.Clear()

            While .Read
                TG.Rows.Add()
                TG.Item(0, TG.Rows.Count - 1).Value = .Item(0)
                TG.Item(1, TG.Rows.Count - 1).Value = .Item(1)
                TG.Item(2, TG.Rows.Count - 1).Value = .GetString(2)
                TG.Item(3, TG.Rows.Count - 1).Value = .GetString(3)
                TG.Item(4, TG.Rows.Count - 1).Value = .GetString(4)
                TG.Item(5, TG.Rows.Count - 1).Value = .Item(5)
                TG.Item(6, TG.Rows.Count - 1).Value = Format(.Item(6), "0.00")
                TG.Item(7, TG.Rows.Count - 1).Value = Format(.Item(7), "0.0")
                TG.Item(8, TG.Rows.Count - 1).Value = Format(.Item(8), "0.00")
                TG.Item(9, TG.Rows.Count - 1).Value = Format(.Item(9), "0.00")
                TG.Item(10, TG.Rows.Count - 1).Value = ""
                TG.Item(11, TG.Rows.Count - 1).Value = Format(.Item(10), "0.00")
                TG.Item(13, TG.Rows.Count - 1).Value = .Item(11)
                'SPID
                TG.Item(16, TG.Rows.Count - 1).Value = .Item(13)
            End While

            .Close()

        End With

        CalculateTotal()
        pnlAlter.Visible = False
        txtCode.Focus()

    End Sub

    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click

        BillMode = 2
        ISReturn = True
        BillType = "RETURN BILL"
        Edit = False
        lblHead.Text = "  ePOS - Return Mode"

        SQL = "select billid,billno,customerid,termid from billmaster where shopid = " & ShopID & " and billid=" & Val(TGBills.Item(0, TGBills.CurrentRow.Index).Value) & ";"

        With ESSA.OpenReader(SQL)
            If .Read Then
                nTermID = .Item(3)
                BillID = .Item(0)
                BillNo = .Item(1)
                lblBillNo.Text = nTermID & "/" & BillNo
                cmbCustomer.SelectedValue = .Item(2)
                customerId = .Item(2)
                billDt = Format(Now.Date, "yyyy-MM-dd")
                billTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
            End If
            .Close()
        End With

        Dim iSno As SByte = 0

        TG.Rows.Clear()

        For i As Short = 0 To TGEdt.Rows.Count - 1
            If Val(TGEdt.Item(6, i).Value) > 0 Then
                TG.Rows.Add()
                iSno += 1
                TG.Item(0, TG.Rows.Count - 1).Value = Val(TGEdt.Item(0, i).Value)
                TG.Item(1, TG.Rows.Count - 1).Value = iSno
                TG.Item(2, TG.Rows.Count - 1).Value = TGEdt.Item(2, i).Value
                TG.Item(3, TG.Rows.Count - 1).Value = TGEdt.Item(3, i).Value
                TG.Item(4, TG.Rows.Count - 1).Value = TGEdt.Item(4, i).Value
                TG.Item(5, TG.Rows.Count - 1).Value = -Val(TGEdt.Item(6, i).Value)
                TG.Item(6, TG.Rows.Count - 1).Value = Format(Val(TGEdt.Item(7, i).Value), "0.00")
                TG.Item(7, TG.Rows.Count - 1).Value = Format(Val(TGEdt.Item(8, i).Value), "0.0")
                TG.Item(8, TG.Rows.Count - 1).Value = Format(-(Val(TGEdt.Item(7, i).Value) - Val(TGEdt.Item(12, i).Value)) * Val(TGEdt.Item(6, i).Value), "0.0")
                TG.Item(9, TG.Rows.Count - 1).Value = Format(Val(TG.Item(5, TG.Rows.Count - 1).Value) * Val(TGEdt.Item(12, i).Value), "0.00")
                TG.Item(10, TG.Rows.Count - 1).Value = ""
                TG.Item(11, TG.Rows.Count - 1).Value = Format(Val(TGEdt.Item(12, i).Value), "0.00")
                TG.Item(12, TG.Rows.Count - 1).Value = BillID  'OLD BILL NUMBER
                TG.Item(16, TG.Rows.Count - 1).Value = TGEdt.Item(13, i).Value 'SPID
            End If
        Next

        CalculateTotal()

        TGPmt.Rows.Add()
        TGPmt.Item(0, 0).Value = 1
        TGPmt.Item(1, 0).Value = "CASH"
        TGPmt.Item(2, 0).Value = ""
        TGPmt.Item(3, 0).Value = Format(mebDt.Value, "dd-MM-yyyy")
        TGPmt.Item(4, 0).Value = Format(Val(lblBillAmt.Text), "0.00")
        TGPmt.Item(5, 0).Value = 0

        pnlAlter.Visible = False
        txtCode.Focus()

    End Sub

    Private Sub btnAlter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlter.Click

        pnlAlter.Visible = True
        TGEdt.Rows.Clear()

    End Sub

    Private Sub btnAHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAHide.Click

        pnlAlter.Visible = False

    End Sub

    Private Sub btnExchange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExchange.Click

        BillMode = 1
        BillType = "EXCHANGE BILL"
        eRefNo = TGBills.Item(3, TGBills.CurrentRow.Index).Value & "/" & TGBills.Item(1, TGBills.CurrentRow.Index).Value

        lblHead.Text = "  ePOS - Exchange Mode"
        Edit = False

        SQL = "select customerid from billmaster where shopid = " & ShopID & " and billid=" & Val(TGBills.Item(0, TGBills.CurrentRow.Index).Value) & ";"

        With ESSA.OpenReader(SQL)
            If .Read Then
                cmbCustomer.SelectedValue = .Item(0)
                customerId = .Item(0)
                billDt = Format(Now.Date, "yyyy-MM-dd")
                billTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
            End If
            .Close()
        End With

        Dim iSno As SByte = 0

        TG.Rows.Clear()

        For i As Short = 0 To TGEdt.Rows.Count - 1
            If Val(TGEdt.Item(6, i).Value) > 0 Then
                TG.Rows.Add()
                iSno += 1
                TG.Item(0, TG.Rows.Count - 1).Value = Val(TGEdt.Item(0, i).Value)
                TG.Item(1, TG.Rows.Count - 1).Value = iSno
                TG.Item(2, TG.Rows.Count - 1).Value = TGEdt.Item(2, i).Value
                TG.Item(3, TG.Rows.Count - 1).Value = TGEdt.Item(3, i).Value
                TG.Item(4, TG.Rows.Count - 1).Value = TGEdt.Item(4, i).Value
                TG.Item(5, TG.Rows.Count - 1).Value = -Val(TGEdt.Item(6, i).Value)
                TG.Item(6, TG.Rows.Count - 1).Value = Format(Val(TGEdt.Item(7, i).Value), "0.00")
                TG.Item(7, TG.Rows.Count - 1).Value = Format(Val(TGEdt.Item(8, i).Value), "0.0")
                TG.Item(8, TG.Rows.Count - 1).Value = Format(-(Val(TGEdt.Item(7, i).Value) - Val(TGEdt.Item(12, i).Value)) * Val(TGEdt.Item(6, i).Value), "0.0")
                TG.Item(9, TG.Rows.Count - 1).Value = Format(Val(TG.Item(5, TG.Rows.Count - 1).Value) * Val(TGEdt.Item(12, i).Value), "0.00")
                TG.Item(10, TG.Rows.Count - 1).Value = ""
                TG.Item(11, TG.Rows.Count - 1).Value = Format(Val(TGEdt.Item(12, i).Value), "0.00")
                TG.Item(12, TG.Rows.Count - 1).Value = Val(TGBills.Item(0, TGBills.CurrentRow.Index).Value)        'BillID  'OLD BILL NUMBER
                TG.Item(16, TG.Rows.Count - 1).Value = TGEdt.Item(13, i).Value 'SPID
            End If
        Next

        CalculateTotal()
        pnlAlter.Visible = False
        txtCode.Focus()

    End Sub

    Private Sub btnSignOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignOut.Click

        ISSignOut = True
        Me.Close()

    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click

        'If ISAdmin = True Then
        Settings.Show()
        'Else
        '    MsgBox("Access denied..!", MsgBoxStyle.Information)
        'End If

    End Sub

    Private Sub btnReprintHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintHide.Click

        pnlReprint.Visible = False

    End Sub

    Private Sub txtBill_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBill.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnRePrintBill.PerformClick()
        End If

    End Sub

    Private Async Function PrintBill(ByVal xBillID As Long, ByVal Sts As String, Optional ByVal isReprint As Boolean = False) As Task

        If DosModePrinter = True Then
            If isReprint = True Then
                Await PrintBillUsingCrystalReport(xBillID, "Reprint")
                'SendFileToPrinter(xBillID, 1)
            Else
                SendFileToPrinter(xBillID, Copies)
            End If
            Exit Function
        End If

        If PrintISOn = False Then
            PrintISOn = POSPrinterRT.ConnectToPrinter()
            If PrintISOn = False Then
                MsgBox("Please restart your application..!", MsgBoxStyle.Information)
                Exit Function
            End If
        End If

        If isReprint = False Then

            For i As SByte = 1 To Copies

                If ISRichTextPrinter = True Then
                    If BillFormat = "Format - TVS" Then
                        POSPrinterRT.PrintBill(xBillID, Sts)
                    ElseIf BillFormat = "Format - Epson" Then
                        POSPrinterRT.PrintBill46(xBillID, Sts)
                    End If
                Else
                    If BillFormat = "Format - TVS" Then
                        'POSPrinter.PrintBill(xBillID, Sts)
                    ElseIf BillFormat = "Format - Epson" Then
                        'POSPrinter.PrintBill46(xBillID, Sts)
                    End If
                End If

            Next

        Else

            If ISRichTextPrinter = True Then
                If BillFormat = "Format - TVS" Then
                    POSPrinterRT.PrintBill(xBillID, Sts)
                ElseIf BillFormat = "Format - Epson" Then
                    POSPrinterRT.PrintBill46(xBillID, Sts)
                End If
            Else
                If BillFormat = "Format - TVS" Then
                    'POSPrinter.PrintBill(xBillID, Sts)
                ElseIf BillFormat = "Format - Epson" Then
                    'POSPrinter.PrintBill46(xBillID, Sts)
                End If
            End If

        End If

    End Function

    Private Sub PrintHoldBill(ByVal xBillID As Long, ByVal Sts As String)

        If DosModePrinter = True Then
            SendFileToPrinter(xBillID, 1, True)
            Exit Sub
        End If

        If BillFormat = "Format - TVS" Then
            POSPrinterRT.PrintHoldBill(xBillID, Sts)
        ElseIf BillFormat = "Format - Epson" Then
            PrintHoldBillEpsonPrinter(xBillID)
            'POSPrinter.PrintHOLDBill46(xBillID, Sts)
        End If

    End Sub

    Private Sub PrintHoldBillEpsonPrinter(ByVal xBillID As Long)

        SQL = "SELECT S.SHOPNAME,S.ADDRESS1,S.ADDRESS2,S.CITY,S.VAT,B.BILLID,B.BILLDT,P.PLUCODE,B.QTY,(B.QTY*B.ORATE) AMT FROM " _
            & "SHOPS S,BILLDETAILSHOLD B,PRODUCTMASTER P WHERE B.PLUID=P.PLUID AND S.SHOPID=" & ShopID & " AND B.BILLID=" & xBillID _
            & " ORDER BY B.SNO"

        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(SQL, Con)
            Using Tbl As New DataTable
                Adp.Fill(Tbl)
                Rpt.SetDataSource(Tbl)
                Rpt.PrintToPrinter(1, False, 0, 0)
            End Using
        End Using
        Con.Close()

    End Sub

    Private Sub PrintHoldBillUsingCrystalReports(xBillId As Long)

        SQL = "SELECT S.SHOPNAME,S.ADDRESS1,S.ADDRESS2,S.CITY,S.VAT,B.BILLID,B.BILLDT,P.PLUCODE,B.QTY,(B.QTY*B.ORATE) AMT FROM " _
        & "SHOPS S,BILLDETAILSHOLD B,PRODUCTMASTER P WHERE B.PLUID=P.PLUID AND S.SHOPID=" & ShopID & " AND B.BILLID=" & xBillId _
        & " ORDER BY B.SNO"

        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(SQL, Con)
            Using Tbl As New DataTable
                Adp.Fill(Tbl)
                Rpt.SetDataSource(Tbl)
                Rpt.PrintOptions.PrinterName = PrinterName
                Rpt.PrintToPrinter(1, False, 0, 0)
            End Using
        End Using
        Con.Close()

    End Sub

    Private Async Sub btnRePrintBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRePrintBill.Click

        PnlLoading.Visible = True
        PnlLoading.BringToFront()

        SQL = "select billid from billmaster where billno=" & Val(txtBill.Text) & " and shopid = " & ShopID & " and termid=" & cmbTerm.Text _
            & " and billdt between '" & Format(mebRPFrom.Value, "yyyy-MM-dd") & "' and '" & Format(mebRPTo.Value, "yyyy-MM-dd") & "'"

        Dim BID = ESSA.GetData(SQL)
        If BID > 0 Then
            If chkEP.Checked = True Then
                Try
                    Await PrintBill(BID, "Duplicate", True)
                    PnlLoading.Visible = False
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    PnlLoading.Visible = False
                    Exit Sub
                End Try
            End If
        Else
            PnlLoading.Visible = False
            txtBill.Select()
            TTip.Show("Bill number not found..!", txtBill, 0, 25, 2000)
        End If

    End Sub

    Private Sub TG_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles TG.RowsRemoved

        CalculateTotal()
        ResetSerial()

    End Sub

    Private Sub btnHelp_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHelp.MouseEnter

        pnlShortcuts.Visible = True

    End Sub

    Private Sub btnHelp_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHelp.MouseLeave

        pnlShortcuts.Visible = False

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        ProductSearch.Show(Me)

    End Sub

    Private Sub btnDenominate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDenominate.Click

        Denominate.ShowDialog(Me)
        txtPAmt.Focus()

    End Sub

    Private Sub cmbCustomer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCustomer.Leave

        If cmbCustomer.SelectedIndex = -1 Then Exit Sub

        SQL = "select pddis from customers where customerid=" & cmbCustomer.SelectedValue
        lblCDis.Text = ESSA.GetData(SQL)

    End Sub

    Private Sub btnRUHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRUHide.Click

        txtruCode.Clear()
        txtOLDRate.Clear()
        txtNewRate.Clear()
        pnlRateUpdater.Visible = False
        txtCode.Focus()

    End Sub

    Private MaxBatchID As Short = 0

    Private Sub txtruCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtruCode.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            SQL = "select v.pluid,v.batchid,v.rate from v_productbatch v,productmaster m where v.pluid=m.pluid " _
                & "and m.plucode='" & txtruCode.Text.Trim & "'"

            MaxBatchID = 0
            With ESSA.OpenReader(SQL)
                If .Read Then
                    lblPluID.Text = .Item(0)
                    MaxBatchID = .Item(1)
                    txtOLDRate.Text = Format(.Item(2), "0.00")
                    txtNewRate.Focus()
                End If
                .Close()
            End With

            If MaxBatchID = 0 Then

                SQL = "select pluid,retailprice from productmaster where plucode='" & txtruCode.Text.Trim & "'"
                With ESSA.OpenReader(SQL)
                    If .Read Then
                        lblPluID.Text = .Item(0)
                        txtOLDRate.Text = Format(.Item(1), "0.00")
                        txtNewRate.Focus()
                    Else
                        lblPluID.Text = 0
                        TTip.Show("Sorry, Product code not found..!", txtruCode, 0, 25, 2000)
                        txtruCode.SelectAll()
                    End If
                    .Close()
                End With

            End If

        End If

    End Sub

    Private Sub txtNewRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNewRate.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True
            If Val(lblPluID.Text) > 0 Then
                UpdateRate(Val(lblPluID.Text))
                'SQL = "update productmaster set retailprice=" & Val(txtNewRate.Text) & " where plucode='" & txtruCode.Text.Trim & "'"
                'ESSA.Execute(SQL)
            End If

        End If

    End Sub

    Private Sub UpdateRate(ByVal iPluID As Long)

        ESSA.OpenConnection()
        Dim Cmd = Con.CreateCommand

        Try

            SQL = "update pricemaster set retailprice=" & Val(txtNewRate.Text) & " where shopid = " & ShopID & " and pluid = ANY (select pluid from productmaster where plucode='" & txtruCode.Text.Trim & "')"
            Cmd.CommandText = SQL
            Cmd.ExecuteNonQuery()

            Dim BID = ESSA.GenerateID("select max(batchid) from productbatch where pluid=" & iPluID)

            SQL = "insert into productbatch values (" _
                & BID & "," _
                & iPluID & "," _
                & Val(txtNewRate.Text) & "," _
                & Val(txtOLDRate.Text) & ",0,'" _
                & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'," _
                & ShopID & "," _
                & UserID & ")"

            Cmd.CommandText = SQL
            Cmd.ExecuteNonQuery()

            Con.Close()

        Catch ex As SqlException
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        btnRUHide.PerformClick()

    End Sub

    Private Sub btnRateUpdater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRateUpdater.Click

        pnlRateUpdater.Visible = True
        txtruCode.Focus()

    End Sub

    Private Sub btnDenom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDenom.Click

        'Denominate.ShowDialog(Me)
        'txtPAmt.Focus()
        StockSearch.Show(Me)

    End Sub

    Private Sub btnRemarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemarks.Click

        Remarks.ShowDialog(Me)

    End Sub

    Private Sub txtPAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPAmt.KeyUp

        If e.KeyCode = Keys.Left Then
            cmbPmtType.Focus()
        End If

    End Sub

    Private new_rate As Double = 0
    Private old_rate As Double = 0

    Private show_discount As Boolean = False

    Private Sub TGBatch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TGBatch.KeyDown

        If e.KeyCode = Keys.Enter Then

            '// add auto discount calculation

            show_discount = IIf(Val(TGBatch.Item(3, TGBatch.CurrentRow.Index).Value) = 1, True, False)

            old_rate = Val(TGBatch.Item(4, TGBatch.CurrentRow.Index).Value)
            new_rate = Val(TGBatch.Item(2, TGBatch.CurrentRow.Index).Value)

            txtRate.Text = Format(new_rate, "0.00")

            'txtRate.Text = Format(Val(TGBatch.Item(2, TGBatch.CurrentRow.Index).Value), "0.00")

            txtQty.Focus()
            pnlBatch.Visible = False

        End If

    End Sub

    Private Sub lblChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblChangePassword.Click

        PasswordUpdate.Show()

    End Sub

    Private Sub btnDisplus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplus.Click

        frmCashCounter.Show()
        Exit Sub
        DiscountOverride.Visible = False
        DiscountOverride.Show(Me)

    End Sub

    Private Sub lblRDt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRDt.Click

        mebRPFrom.Value = SDate
        mebRPTo.Value = EDate

    End Sub

    Private Sub btnUpdateDU_Click(sender As Object, e As EventArgs) Handles btnUpdateDU.Click

        'If Val(txtDP.Text) > DiscountLimit Then
        '    MsgBox("Sorry, You are not alowed to offer discount more than " & DiscountLimit & "%", MsgBoxStyle.Information)
        '    txtDP.Focus()
        '    Exit Sub
        'End If

        If Val(txtDP.Text) >= 0 Then

            For i As Short = 0 To TG.Rows.Count - 1
                '0 - Manual discounts only
                If Val(TG.Item(15, i).Value) = 0 Then
                    TG.Item(7, i).Value = Format(Val(txtDP.Text), "0.0")
                    TG.Item(8, i).Value = Format(((Val(TG.Item(5, i).Value) * Val(TG.Item(6, i).Value)) * Val(txtDP.Text)) / 100, "0.00")
                    TG.Item(9, i).Value = Format((Val(TG.Item(5, i).Value) * Val(TG.Item(6, i).Value)) - Val(TG.Item(8, i).Value), "0.0")
                    TG.Item(9, i).Value = Format(Math.Round(Val(TG.Item(9, i).Value)), "0.00")
                    TG.Item(11, i).Value = Format(Val(TG.Item(6, i).Value) - ((Val(TG.Item(6, i).Value) * Val(txtDP.Text)) / 100), "0.00")
                End If
            Next

            CalculateTotal()

        End If

        pnlDU.Visible = False
        txtCode.Focus()

    End Sub

    Private Sub btnHideDU_Click(sender As Object, e As EventArgs) Handles btnHideDU.Click

        pnlDU.Visible = False
        txtCode.Focus()

    End Sub

    Private Sub CalculateDiscountAmount()

        txtDR.Text = Format(Val(lblTotAmt.Text) * Val(txtDP.Text) / 100, "0.00")
        txtBA.Text = Format(Val(lblTotAmt.Text) - Val(txtDR.Text), "0.00")

    End Sub

    Private Sub txtDP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDP.KeyUp

        CalculateDiscountAmount()

    End Sub

    Private Sub txtDR_KeyDown1(sender As Object, e As KeyEventArgs) Handles txtDR.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnUpdateDU.PerformClick()
        End If

    End Sub

    Private Sub txtDR_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDR.KeyUp

        txtDP.Text = Format(Val(txtDR.Text) / Val(lblTotAmt.Text) * 100, "0.00")
        txtBA.Text = Format(Val(lblTotAmt.Text) - Val(txtDR.Text), "0.00")

    End Sub

#Region "PrintBillGST"

    Private SQL As String = ""
    Private Msg As String = ""

    Private pName As String = ""
    Private pAdd1 As String = ""
    Private pAdd2 As String = ""
    Private pCity As String = ""
    Private pPhon As String = ""
    Private pGSTN As String = ""

    Private Async Function GetShopAddress() As Task

        SQL = "select alias,address1,address2,city,state,phone,cst from shops where shopid=" & ShopID
        With Await ESSA.OpenReaderAsync(SQL)
            If Await .ReadAsync Then
                pName = .GetString(0).Trim
                pAdd1 = .GetString(1).Trim
                pAdd2 = .GetString(2).Trim
                pCity = .GetString(3).Trim & ", " & .GetString(4).Trim & " CODE: 33"
                pPhon = .GetString(5).Trim
                pGSTN = .GetString(6).Trim
            End If
            .Close()
        End With

    End Function

    Private PaymentDesc As String = ""
    Private CopyName As String = ""

    Private Sub PrintHOLDBILLNEW(iBillID As Long)

        FileOpen(1, TempFilePath & "PrintFile.prn", OpenMode.Output)
        'FileOpen(1, "D:\PrintFile.prn", OpenMode.Output)
        Print(1, Chr(27) & "@")
        PrintLine(1, Chr(27) & "a1" & Chr(27) & "E1 " & "" & Chr(27) & "E0")
        'PrintLine(1, Chr(27) & "a1" & Chr(27) & "E1 " & "ESSA" & Chr(27) & "E0")
        PrintLine(1, Chr(27) & "!8 " & pName)
        Print(1, Chr(27) & "@")
        PrintLine(1, Chr(27) & "a1" & pAdd1)
        If pAdd2.Length > 0 Then PrintLine(1, pAdd2)
        PrintLine(1, pCity)
        PrintLine(1, "Phone: " & pPhon)
        PrintLine(1, "GST: " & pGSTN)
        PrintLine(1, Chr(27) & "!1" & " ESTIMATE BILL")
        Print(1, Chr(27) & "@")

        'SQL = "select termid,billno,billtime from billmaster where billid=" & iBillID & ";" _
        '    & "select paymentdesc from billpayments where billid=" & iBillID & " order by sno"

        SQL = "select distinct termid,billid,billdt,custname from billdetailsHOLD where billid=" & iBillID & ";"

        With ESSA.OpenReader(SQL)
            If .Read Then
                PaymentDesc = .GetString(3).Trim
                Print(1, Chr(27) & "E1" & " Bill No: T" & .Item(0) & "-" & .Item(1))
                Msg = "Date: " & Format(.GetDateTime(2), "dd-MM-yyyy hh:mm tt")
                Print(1, TAB(73 - Msg.Length), Msg)
                Print(1, Chr(27), "E0")
            End If
            .Close()
        End With

        Print(1, Chr(27) & "@")
        PrintLine(1, " --------------------------------------------------------------------")
        Print(1, Chr(27) & "E1")
        PrintLine(1, " SNO  DESCRIPTION                      QTY     RATE    D.AMT   AMOUNT")
        Print(1, Chr(27) & "E0")
        PrintLine(1, " --------------------------------------------------------------------")

        SQL = "select p.pluname,d.qty,d.orate,d.amount,p.plucode,0 hsncode,0 utax " _
            & "from billdetailsHOLD d,productmaster p " _
            & "where d.pluid=p.pluid and d.billid=" & iBillID _
            & " order by d.sno"

        'SQL = " select p.pluname,d.qty,d.orate,d.amount,p.plucode,h.hsncode,h.utax" _
        '    & " from billdetails d,productmaster p,v_producthsn h" _
        '    & " where d.pluid=p.pluid and d.pluid=h.pluid and d.billid=" & iBillID _
        '    & " order by d.sno"

        Dim TaxTot As Double = 0
        Dim IGSTot As Double = 0
        Dim SGSTot As Double = 0

        Dim Tot As Double = 0
        Dim Sno As Short = 1
        Dim Amt As Double = 0
        Dim Per As Double = 0
        Dim Hlf As Double = 0
        Dim Tax As Double = 0
        Dim Qty As Double = 0
        Dim Msg2 As String = ""

        With ESSA.OpenReader(SQL)
            While .Read

                Print(1, TAB(2), Sno)
                Msg = Mid(.GetString(4).Trim & "/" & .GetString(0).Trim, 1, 28)

                Print(1, TAB(7), Msg)
                Msg = .Item(1)

                Print(1, TAB(43 - Msg.Length), Msg)
                Amt = .Item(1) * .Item(2)

                Msg = Format(.Item(1) * .Item(2), "0.00")
                Print(1, TAB(52 - Msg.Length), Msg)

                Msg = Format(Amt - .Item(3), "0.00")
                Print(1, TAB(61 - Msg.Length), Msg)

                Msg = Format(.Item(3), "0.00")
                PrintLine(1, TAB(70 - Msg.Length), Msg)

                'GST TAX PRINT OUT : BEGIN

                'If .Item(6) = 1 Then
                '    Per = 5.0F
                '    Hlf = 2.5F
                'Else
                '    Per = IIf(.Item(2) >= 1000, 12.0F, 5.0F)
                '    Hlf = IIf(.Item(2) >= 1000, 6.0F, 2.5F)
                'End If

                'Tax = (.Item(3) / (100 + Per)) * 100

                'TaxTot += Tax
                'IGSTot += ((Tax * Hlf) / 100)
                'SGSTot += ((Tax * Hlf) / 100)

                'Msg = Format(Tax, "0.00")
                'Msg2 = Format(Hlf, "0.00") & " %: " & Format((Tax * Hlf) / 100, "0.00")
                'PrintLine(1, TAB(7), Chr(27) & "M1" & "SALE : " & Msg, TAB(26), "CGST " & Msg2 & Chr(27) & "M0")

                'Msg = .GetString(5).Trim
                'Msg2 = Format(Hlf, "0.00") & " %: " & Format((Tax * Hlf) / 100, "0.00")
                'PrintLine(1, TAB(7), Chr(27) & "M1" & "HSN  : " & Msg, TAB(26), "SGST " & Msg2 & Chr(27) & "M0")

                'GST TAX PRINT OUT : END

                Tot += .Item(3)
                Qty += .Item(1)
                Sno += 1


            End While

            PrintLine(1, " --------------------------------------------------------------------")
            Msg = Format(Tot, "0.00")
            Msg2 = Format(Qty, "0")
            PrintLine(1, TAB(7), Chr(27) & "!1" & "TOTAL", TAB(35 - Msg2.Length), Msg2, TAB(52 - Msg.Length), Msg)
            PrintLine(1, Chr(27) & "@" & " --------------------------------------------------------------------")
            PrintLine(1, Chr(27) & "E1" & " Customer : " & PaymentDesc & Chr(27) & "E0")
            PrintLine(1)
            PrintLine(1)
            PrintLine(1, Chr(27) & "a1" & Chr(27) & "E1 " & "THANK YOU, VISIT AGAIN !" & Chr(27) & "E0")
            PrintLine(1)
            PrintLine(1)
            PrintLine(1)
            PrintLine(1)
            PrintLine(1, Chr(27) & "@" & Chr(29) & "V" + Chr(1))
            PrintLine(1)
            PrintLine(1)
            .Close()
        End With

        FileClose(1)

    End Sub

    Dim tBillNo As String = ""
    Dim pmtTable As New DataTable

    Private Sub PrintBillGSTPure(iBillID As Long, iCopies As SByte)

        FileOpen(1, TempFilePath & "PrintFile.prn", OpenMode.Output)
        For i As SByte = 1 To iCopies

            If i = 1 Then
                CopyName = "Duplicate"
            ElseIf i = 2 Then
                CopyName = "Original"
            End If

            Print(1, Chr(27) & "@")
            PrintLine(1, Chr(27) & "a1" & Chr(27) & "E1 " & "ESSA" & Chr(27) & "E0")
            PrintLine(1, Chr(27) & "!8 " & pName)
            Print(1, Chr(27) & "@")
            PrintLine(1, Chr(27) & "a1" & pAdd1)
            If pAdd2.Length > 0 Then PrintLine(1, pAdd2)
            PrintLine(1, pCity)
            PrintLine(1, "Phone: " & pPhon)
            PrintLine(1, "GSTIN: " & pGSTN)
            PrintLine(1, Chr(27) & "!1" & " TAX INVOICE")
            Print(1, Chr(27) & "@")
            PrintLine(1, Chr(27) & "a1 " & CopyName & Chr(27) & "a0")

            SQL = "select termid,billno,billtime,refno from billmaster where billid=" & iBillID

            With ESSA.OpenReader(SQL)
                If .Read Then
                    tBillNo = " Bill No: T" & .Item(0) & "-" & .Item(1) & " "
                    Print(1, Chr(27) & "E1" & " Bill No: T" & .Item(0) & "-" & .Item(1))
                    Msg = "Date: " & Format(.GetDateTime(2), "dd-MM-yyyy hh:mm tt")
                    Print(1, TAB(72 - Msg.Length), Msg)
                    Print(1, Chr(27), "E0")
                    If .GetString(3).Trim.Length > 0 Then
                        Print(1, Chr(27) & "@")
                        PrintLine(1, " Ref No:   " & .GetString(3).Trim)
                    End If
                End If
                .Close()
            End With

            SQL = "select paymentdesc,paid from billpayments where billid=" & iBillID & " order by sno"
            ESSA.OpenConnection()
            Using Adp As New SqlDataAdapter(SQL, Con)
                pmtTable.Clear()
                Adp.Fill(pmtTable)
            End Using
            Con.Close()

            Print(1, Chr(27) & "@")
            PrintLine(1, " --------------------------------------------------------------------")
            Print(1, Chr(27) & "E1")
            PrintLine(1, " SNO  DESCRIPTION                      QTY     RATE    D.AMT   AMOUNT")
            Print(1, Chr(27) & "E0")
            PrintLine(1, " --------------------------------------------------------------------")

            SQL = " select p.pluname,d.qty,d.orate,d.amount,p.plucode,h.hsncode,h.utax" _
                & " from billdetails d,productmaster p,v_producthsn h" _
                & " where d.pluid=p.pluid and d.pluid=h.pluid and d.billid=" & iBillID _
                & " order by d.sno"

            Dim TaxTot As Double = 0
            Dim IGSTot As Double = 0
            Dim SGSTot As Double = 0

            Dim Tot As Double = 0
            Dim Sno As Short = 1
            Dim Amt As Double = 0
            Dim Per As Double = 0
            Dim Hlf As Double = 0
            Dim Tax As Double = 0
            Dim Qty As Double = 0
            Dim Msg2 As String = ""

            With ESSA.OpenReader(SQL)
                While .Read

                    Print(1, TAB(2), Sno)

                    Msg = Mid(.GetString(4).Trim & "/" & .GetString(0).Trim, 1, 28)
                    Print(1, TAB(7), Msg)

                    Msg = .Item(1)
                    Print(1, TAB(43 - Msg.Length), Msg)

                    Amt = .Item(1) * .Item(2)
                    Msg = Format(.Item(2), "0.00")
                    Print(1, TAB(52 - Msg.Length), Msg)

                    Msg = Format(Amt - .Item(3), "0.00")
                    Print(1, TAB(61 - Msg.Length), Msg)

                    Msg = Format(.Item(3), "0.00")
                    PrintLine(1, TAB(70 - Msg.Length), Msg)

                    'GST TAX PRINT OUT : BEGIN

                    If .Item(6) = 1 Then
                        Per = 5.0F
                        Hlf = 2.5F
                    Else
                        Per = IIf(.Item(2) >= 1000, 12.0F, 5.0F)
                        Hlf = IIf(.Item(2) >= 1000, 6.0F, 2.5F)
                    End If

                    Tax = (.Item(3) / (100 + Per)) * 100

                    If Tax > 0 Then

                        TaxTot += Tax
                        IGSTot += ((Tax * Hlf) / 100)
                        SGSTot += ((Tax * Hlf) / 100)

                    End If

                    Msg = Format(Tax, "0.00")
                    Msg2 = Format(Hlf, "0.00") & " %: " & Format((Tax * Hlf) / 100, "0.00")
                    PrintLine(1, TAB(7), Chr(27) & "M1" & "SALE : " & Msg, TAB(26), "CGST " & Msg2 & Chr(27) & "M0")

                    Msg = .GetString(5).Trim
                    Msg2 = Format(Hlf, "0.00") & " %: " & Format((Tax * Hlf) / 100, "0.00")
                    PrintLine(1, TAB(7), Chr(27) & "M1" & "HSN  : " & Msg, TAB(26), "SGST " & Msg2 & Chr(27) & "M0")

                    'GST TAX PRINT OUT : END

                    Tot += .Item(3)
                    If .Item(1) > 0 Then
                        Qty += .Item(1)
                    End If
                    Sno += 1


                End While

                PrintLine(1, " --------------------------------------------------------------------")
                Msg = Format(Tot, "0.00")
                Msg2 = Format(Qty, "0")
                PrintLine(1, TAB(7), Chr(27) & "!1" & "TOTAL", TAB(35 - Msg2.Length), Msg2, TAB(52 - Msg.Length), Msg)
                PrintLine(1, Chr(27) & "@" & " --------------------------------------------------------------------")
                PrintLine(1, TAB(2), "SALE AMOUNT : " & Format(TaxTot, "0.00"), TAB(26), "CGST : " & Format(IGSTot, "0.00"), TAB(43), "SGST : " & Format(SGSTot, "0.00"))
                PrintLine(1)
                Print(1, TAB(2), "E.& O.E")
                Msg = PaymentDesc
                For p As SByte = 0 To pmtTable.Rows.Count - 1
                    Msg = pmtTable.Rows(p).Item(0) & " / " & Format(Val(pmtTable.Rows(p).Item(1)), "0.00")
                    PrintLine(1, TAB(70 - Msg.Length), Msg)
                Next
                'PrintLine(1)
                'PrintLine(1, Chr(27) & "a1" & Chr(27) & "E1 " & "THANK YOU, VISIT AGAIN !" & Chr(27) & "E0")
                'PrintLine(1)
                PrintLine(1, Chr(27) & "a1" & Chr(27) & "!1 " & tBillNo)
                PrintLine(1, Chr(27) & "@")
                PrintLine(1, Chr(27) & "a1" & Chr(27) & "E1 " & "THANK YOU, VISIT AGAIN !" & Chr(27) & "E0")
                PrintLine(1)
                PrintLine(1)
                PrintLine(1)
                PrintLine(1)
                PrintLine(1, Chr(27) & "@" & Chr(29) & "V" + Chr(1))
                .Close()
            End With

        Next

        FileClose(1)

    End Sub

    Private Sub PrintBillGST(iBillID As Long, iCopies As SByte)

        FileOpen(1, TempFilePath & "PrintFile.prn", OpenMode.Output)
        For i As SByte = 1 To iCopies

            If i = 1 Then
                CopyName = "Duplicate"
            ElseIf i = 2 Then
                CopyName = "Original"
            End If

            Print(1, Chr(27) & "@")
            PrintLine(1, Chr(27) & "a1" & Chr(27) & "E1 " & "" & Chr(27) & "E0")
            'PrintLine(1, Chr(27) & "a1" & Chr(27) & "E1 " & "ESSA" & Chr(27) & "E0")
            PrintLine(1, Chr(27) & "!8 " & pName)
            Print(1, Chr(27) & "@")
            PrintLine(1, Chr(27) & "a1" & pAdd1)
            If pAdd2.Length > 0 Then PrintLine(1, pAdd2)
            PrintLine(1, pCity)
            PrintLine(1, "Phone: " & pPhon)
            PrintLine(1, "GSTIN: " & pGSTN)
            PrintLine(1, Chr(27) & "!1" & " TAX INVOICE")
            Print(1, Chr(27) & "@")
            PrintLine(1, Chr(27) & "a1 " & CopyName & Chr(27) & "a0")

            SQL = "select termid,billno,billtime,refno from billmaster where billid=" & iBillID

            With ESSA.OpenReader(SQL)
                If .Read Then


                    If HideTerminal = True Then
                        tBillNo = " Bill No: " & .Item(1) & " "
                        Print(1, Chr(27) & "E1" & " Bill No: " & .Item(1))
                    Else
                        tBillNo = " Bill No: T" & .Item(0) & "-" & .Item(1) & " "
                        Print(1, Chr(27) & "E1" & " Bill No: T" & .Item(0) & "-" & .Item(1))
                    End If

                    Msg = "Date: " & Format(.GetDateTime(2), "dd-MM-yyyy hh:mm tt")
                    Print(1, TAB(72 - Msg.Length), Msg)
                    Print(1, Chr(27), "E0")
                    If .GetString(3).Trim.Length > 0 Then
                        Print(1, Chr(27) & "@")
                        PrintLine(1, " Ref No:   " & .GetString(3).Trim)
                    End If
                End If
                .Close()
            End With

            SQL = "select paymentdesc,paid from billpayments where billid=" & iBillID & " order by sno"
            ESSA.OpenConnection()
            Using Adp As New SqlDataAdapter(SQL, Con)
                pmtTable.Clear()
                Adp.Fill(pmtTable)
            End Using
            Con.Close()

            Print(1, Chr(27) & "@")
            PrintLine(1, " --------------------------------------------------------------------")
            Print(1, Chr(27) & "E1")
            PrintLine(1, " SNO  DESCRIPTION                      QTY     RATE    D.AMT   AMOUNT")
            Print(1, Chr(27) & "E0")
            PrintLine(1, " --------------------------------------------------------------------")

            'SQL = " select p.pluname,d.qty,d.orate,d.amount,p.plucode,h.hsncode,h.utax" _
            '    & " from billdetails d,productmaster p,v_producthsn h" _
            '    & " where d.pluid=p.pluid and d.pluid=h.pluid and d.billid=" & iBillID _
            '    & " order by d.sno"

            'NEW CODE : YASEEN

            'SQL = "SELECT M.Pluname,D.Qty,D.Rate,D.Amount,M.PluCode,M.HSNCode,ISNULL(T.Mn,5) Mn,ISNULL(T.Mx,5) Mx, ISNULL(T.Val,1000) Val " _
            '       & "FROM BillDetails D, ProductMaster M, ProductAttributes A,ProductTax T " _
            '       & "WHERE D.PluID = M.PluID AND M.PluID = A.PluId AND " _
            '       & "T.DeptId = A.DeptId AND T.CatId = A.CatId AND T.MatId = A.MaterialId AND D.BillId = " _
            '       & iBillID & " ORDER BY D.SNO"

            SQL = "SELECT DISTINCT M.Pluname,D.Qty,D.ORate,D.Amount,M.PluCode,M.HSNCode,ISNULL(T.Mn,5) Mn,ISNULL(T.Mx,5) Mx, ISNULL(T.Val,1000) Val,D.PluID,D.Rate,D.SNo " _
                & "FROM BillDetails D, ProductMaster M, ProductAttributes A,ProductTax T  " _
                & "WHERE D.PluID = M.PluID AND M.PluID = A.PluId AND " _
                & "T.DeptId = A.DeptId AND T.CatId = A.CatId AND T.MatId = A.MaterialId  AND D.BillID = " _
                & iBillID & " ORDER BY D.SNo"


            ' OLD CODE : ABU
            'SQL = " select p.pluname,d.qty,d.rate,d.amount,p.plucode,p.hsncode,p.utax" _
            '    & " from billdetails d,productmaster p " _
            '    & " where d.pluid=p.pluid and d.billid=" & iBillID _
            '    & " order by d.sno"

            Dim TaxTot As Double = 0
            Dim IGSTot As Double = 0
            Dim SGSTot As Double = 0

            Dim Tot As Double = 0
            Dim Sno As Short = 1
            Dim Amt As Double = 0
            Dim Per As Double = 0
            Dim Hlf As Double = 0
            Dim Tax As Double = 0
            Dim Qty As Double = 0
            Dim Msg2 As String = ""
            Dim VAR_DISCOUNT As Double = 0
            Dim VAR_SUBTOTAL As Double = 0

            With ESSA.OpenReader(SQL)
                While .Read

                    Print(1, TAB(2), Sno)

                    Msg = Mid(.GetString(4).Trim & "/" & .GetString(0).Trim, 1, 28)
                    Print(1, TAB(7), Msg)

                    Msg = .Item(1)
                    Print(1, TAB(43 - Msg.Length), Msg)

                    Amt = .Item(1) * .Item(2)
                    Msg = Format(.Item(2), "0.00")
                    Print(1, TAB(52 - Msg.Length), Msg)

                    Msg = Format(Amt - .Item(3), "0.00")
                    Print(1, TAB(61 - Msg.Length), Msg)

                    VAR_SUBTOTAL += Amt
                    VAR_DISCOUNT += (Amt - .Item(3))

                    Msg = Format(.Item(3), "0.00")
                    PrintLine(1, TAB(70 - Msg.Length), Msg)

                    'GST TAX PRINT OUT : BEGIN

                    If Val(.Item(10)) >= Val(.Item(8)) Then
                        Per = .Item(7)
                        Hlf = .Item(7) * 0.5
                    Else
                        Per = .Item(6)
                        Hlf = .Item(6) * 0.5
                    End If

                    'If .Item(6) = 1 Then
                    '    Per = 5.0F
                    '    Hlf = 2.5F
                    'Else
                    '    Per = IIf(.Item(2) >= 1000, 12.0F, 5.0F)
                    '    Hlf = IIf(.Item(2) >= 1000, 6.0F, 2.5F)
                    'End If

                    Tax = (.Item(3) / (100 + Per)) * 100

                    If Tax > 0 Then

                        TaxTot += Tax
                        IGSTot += ((Tax * Hlf) / 100)
                        SGSTot += ((Tax * Hlf) / 100)

                    End If

                    Msg = Format(Tax, "0.00")
                    Msg2 = Format(Hlf, "0.00") & " %: " & Format((Tax * Hlf) / 100, "0.00")
                    PrintLine(1, TAB(7), Chr(27) & "M1" & "SALE : " & Msg, TAB(26), "CGST " & Msg2 & Chr(27) & "M0")

                    Msg = .GetString(5).Trim
                    Msg2 = Format(Hlf, "0.00") & " %: " & Format((Tax * Hlf) / 100, "0.00")
                    PrintLine(1, TAB(7), Chr(27) & "M1" & "HSN  : " & Msg, TAB(26), "SGST " & Msg2 & Chr(27) & "M0")

                    'GST TAX PRINT OUT : END

                    Tot += .Item(3)
                    If .Item(1) > 0 Then
                        Qty += .Item(1)
                    End If
                    Sno += 1

                End While

                PrintLine(1, " --------------------------------------------------------------------" & Chr(27) & "!1")

                Msg = Format(VAR_SUBTOTAL, "0.00")
                Msg2 = Format(Qty, "0")

                If VAR_DISCOUNT > 0 Then

                    Msg = Format(VAR_DISCOUNT, "0.00")
                    PrintLine(1, " ITEMS:" & Msg2, TAB(20), "DISCOUNT", TAB(47 - Msg.Length), Msg)

                    Msg = Format(Tot, "0.00")
                    PrintLine(1, TAB(20), "BILL AMOUNT", TAB(47 - Msg.Length), Msg)

                Else

                    Msg = Format(Tot, "0.00")
                    PrintLine(1, " ITEMS:" & Msg2, TAB(20), "BILL AMOUNT", TAB(47 - Msg.Length), Msg)

                End If

                PrintLine(1, Chr(27) & "@" & " --------------------------------------------------------------------")
                PrintLine(1, TAB(2), "SALE AMOUNT : " & Format(TaxTot, "0.00"), TAB(26), "CGST : " & Format(IGSTot, "0.00"), TAB(43), "SGST : " & Format(SGSTot, "0.00"))
                PrintLine(1)
                Print(1, TAB(2), "E.& O.E")
                Msg = PaymentDesc
                For p As SByte = 0 To pmtTable.Rows.Count - 1
                    Msg = pmtTable.Rows(p).Item(0) & " / " & Format(Val(pmtTable.Rows(p).Item(1)), "0.00")
                    PrintLine(1, TAB(70 - Msg.Length), Msg)
                Next
                'PrintLine(1)
                'PrintLine(1, Chr(27) & "a1" & Chr(27) & "E1 " & "THANK YOU, VISIT AGAIN !" & Chr(27) & "E0")
                'PrintLine(1)   
                PrintLine(1)
                Dim PrintString = getBarcodeStr(iBillID) + vbCrLf
                Print(1, Chr(27) & "a1" & PrintString)

                PrintLine(1, Chr(27) & "a1" & Chr(27) & "!1 " & tBillNo)
                PrintLine(1, Chr(27) & "@")
                PrintLine(1, Chr(27) & "a1" & Chr(27) & "E1 " & "THANK YOU, VISIT AGAIN !" & Chr(27) & "E0")
                PrintLine(1)
                PrintLine(1)
                PrintLine(1)
                PrintLine(1)
                PrintLine(1, Chr(27) & "@" & Chr(29) & "V" + Chr(1))
                .Close()
            End With

        Next

        FileClose(1)

    End Sub

    Private Sub SendFileToPrinter(iBillID As Long, iCopies As SByte, Optional ISHoldBill As Boolean = False)

        If ISHoldBill = False Then
            PrintBillGST(iBillID, iCopies)
        Else
            PrintHoldBillUsingCrystalReports(iBillID)
            'PrintHOLDBILLNEW(iBillID)
        End If

        If DirectPrint Then
            RawPrinterHelper.SendFileToPrinter(PrinterName, TempFilePath & "PrintFile.prn")
        Else
            Process.Start(TempFilePath & "PrintFile.bat")
        End If

    End Sub

    Private Sub CreatePrintBAT()

        FileOpen(1, TempFilePath & "PrintFile.bat", OpenMode.Output)
        PrintLine(1, "NET USE lpt1 " & PrinterName)
        PrintLine(1, "Copy " & TempFilePath & "PrintFile.prn lpt1")
        PrintLine(1, "NET USE lpt1 /DELETE")
        FileClose(1)

    End Sub

#End Region

    Private Sub btnQuickCash_Click(sender As Object, e As EventArgs) Handles btnQuickCash.Click

        pnlSalesPerson.Hide()
        AddQuickCash()
        btnUpdate.PerformClick()

    End Sub

    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles btnCard.Click

        If PaymentTotal() <> Val(lblBillAmt.Text) Then
            pnlSalesPerson.Hide()
            pnlPayment.Visible = True
            cmbPmtType.Focus()
        End If

    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged

        If Val(txtQty.Text) <> 0 Then
            CalculateDiscount()
        End If

    End Sub

    Private Sub btnDisplaySelected_Click(sender As Object, e As EventArgs) Handles btnDisplaySelected.Click

        ViewHoldBillSelected()

    End Sub

    Private Sub TGHold_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles TGHold.CellContentClick

    End Sub

    Private Sub TGHold_KeyUp(sender As Object, e As KeyEventArgs) Handles TGHold.KeyUp

        If e.KeyCode = Keys.Delete Then
            If MsgBox("Are you sure, want to delete ..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            SQL = "DELETE FROM BillDetailsHold WHERE BillId =" & TGHold.Item(0, TGHold.CurrentRow.Index).Value
            ESSA.Execute(SQL)
            SQL = "DELETE FROM BillSalePersonsHold WHERE BillId =" & TGHold.Item(0, TGHold.CurrentRow.Index).Value
            ESSA.Execute(SQL)
            TGHold.Rows.RemoveAt(TGHold.CurrentRow.Index)
        End If

    End Sub

    Private Async Sub DeleteSelectedBillsInHold()

        Dim SelectedBillCount As Integer = 0

        For i As Short = 0 To TGHold.Rows.Count - 1

            If TGHold.Item(7, i).Value = 1 Then
                SelectedBillCount += 1
            End If

        Next

        If SelectedBillCount > 0 Then

            If MsgBox("Are you sure,want to delete..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            For i As Short = 0 To TGHold.Rows.Count - 1

                If TGHold.Item(7, i).Value = 1 Then
                    SQL = "DELETE FROM BillDetailsHold WHERE BillId = " & TGHold.Item(0, i).Value
                    ESSA.Execute(SQL)
                    SQL = "DELETE FROM BillSalePersonsHold WHERE BillId = " & TGHold.Item(0, i).Value
                    ESSA.Execute(SQL)
                End If

            Next

            Await LoadHoldBills()

        Else

            MsgBox("No bills selected..!", MsgBoxStyle.Critical)

        End If


    End Sub

    Private Sub btnDeleteSelected_Click(sender As Object, e As EventArgs) Handles btnDeleteSelected.Click

        DeleteSelectedBillsInHold()

    End Sub

    Public GS As String = Chr(&H1D)

    Public Function getBarcodeStr(ibillId As Long) As String

        getBarcodeStr = ""
        SQL = "SELECT TermId , BillNo  FROM BillMaster WHERE BillId =" & ibillId

        With ESSA.OpenReader(SQL)
            If .Read Then

                Dim billNo As String = "T" & .Item(0) & "-" & .Item(1)
                getBarcodeStr = GS & "h" & Chr(80) 'Bardcode Hieght
                getBarcodeStr = getBarcodeStr & GS & "w" & Chr(1) 'Barcode Width
                getBarcodeStr = getBarcodeStr & GS & "f" & Chr(0) 'Font for HRI characters
                getBarcodeStr = getBarcodeStr & GS & "H" & Chr(2) 'Position of HRI characters
                getBarcodeStr = getBarcodeStr & GS & "k" & Chr(69) & Chr(Len(billNo)) 'Print Barcode Smb 39
                getBarcodeStr = getBarcodeStr & billNo & Chr(0) & vbCrLf 'Print Text Under
                getBarcodeStr = getBarcodeStr & GS & "d" & Chr(3) '& vbCrLf
                'getBarcodeStr = getBarcodeStr & GS & "@"
                Return getBarcodeStr

            End If
            .Close()
        End With

    End Function

    Private Function isAttributesAvailable(Plucode As String) As Boolean

        isAttributesAvailable = False
        Dim DeptID As Integer = 0
        Dim CatId As Integer = 0
        Dim MatId As Integer = 0

        'SQL = "SELECT DISTINCT A.DeptId,A.CatId,A.MaterialId FROM " _
        '    & "ProductAttributes A WHERE EXISTS " _
        '    & "(SELECT * FROM ProductTax T " _
        '    & "WHERE A.DeptId = T.DeptId AND A.CatId = T.CatId AND A.MaterialId = T.MatId) " _
        '    & "AND A.PluID = " & pluId

        SQL = "SELECT DeptId,CatId,MaterialId FROM ProductAttributes WHERE PluId IN (SELECT PluId FROM Productmaster WHERE PluCode = '" & Plucode & "')"

        With ESSA.OpenReader(SQL)
            If .Read Then

                DeptID = .Item(0)
                CatId = .Item(1)
                MatId = .Item(2)

            End If
            .Close()
        End With

        SQL = "SELECT * FROM ProductTax WHERE DeptId = " & DeptID & " AND CatId = " & CatId & " AND MatId = " & MatId & ""

        With ESSA.OpenReader(SQL)
            If .Read Then

                isAttributesAvailable = True

            End If
            .Close()
        End With

        Return isAttributesAvailable

    End Function

    Private Sub txtSP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSP.KeyDown

        If e.KeyCode = Keys.Enter Then

            If Not ifExist(DgvSP, 0, txtSP.Text) Then
                TTip.Show("Invalid sales person number..!", txtSP, 0, 25, 2000)
                Exit Sub
            End If

            txtQty.Text = 1
            txtQty.Select()
            txtQty.Focus()

        End If

    End Sub

    Private Function ifExist(DGV As DataGridView, colIndex As Short, searchText As String) As Boolean

        ifExist = False
        For i As Short = 0 To DGV.Rows.Count - 1
            If DGV.Item(colIndex, i).Value = searchText Then
                ifExist = True
            End If
        Next
        Return ifExist

    End Function

    Private IsPresent As Boolean = False

    Private Sub GenerateCustomerID()

        SQL = "select max(customerid) from customers"
        customerId = ESSA.GenerateID(SQL)

    End Sub

    Private MobileNo As String = ""

    Private Async Sub BtnCustSave_Click(sender As Object, e As EventArgs) Handles BtnCustSave.Click

        If TxtCustMobile.Text = String.Empty Or TxtCustMobile.Text.Length <> 10 Then
            TTip.Show("Enter Valid Mobile..!", TxtCustMobile, 0, 25, 2000)
            Exit Sub
        End If

        Try

            PnlLoading.Visible = True
            PnlLoading.BringToFront()

            If Not IsPresent Then

                GenerateCustomerID()

                SQL = $"INSERT INTO 
                Customers (
                CustomerId,
                CustomerName,
                Phone,
                LocationId,
                UserId)
                VALUES(
                {customerId},
                '{TxtCustName.Text.Trim}',
                '{TxtCustMobile.Text.Trim}',
                {ShopID},
                {UserID})"

                ESSA.Execute(SQL)

            Else

                If Not customerId = 1 Then

                    SQL = $"UPDATE Customers 
                    SET CustomerName = '{TxtCustName.Text.Trim}'
                    WHERE CustomerID = {customerId}"

                    ESSA.Execute(SQL)

                End If


            End If

            MobileNo = TxtCustMobile.Text.Trim
            Await UpdateCustomerComboBox()

            PnlPaymentNew.Visible = True
            PnlPaymentNew.BringToFront()
            TxtCashNew.Focus()
            PnlCustomerInfo.Visible = False
            PnlLoading.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            PnlLoading.Visible = False
            Exit Sub
        End Try

    End Sub

    Private Async Function UpdateCustomerComboBox() As Task

        SQL = $"SELECT 1 AS CUSTOMERID, 'DEFAULT' AS CUSTOMERNAME
            UNION ALL 
            SELECT CUSTOMERID,CUSTOMERNAME 
            FROM CUSTOMERS 
            WHERE LOCATIONID = {ShopID} 
            ORDER BY CUSTOMERID"
        Await ESSA.LoadComboAsync(cmbCustomer, SQL, "CUSTOMERNAME", "CUSTOMERID")

    End Function

    Private Sub BtnHideCustomerPnl_Click(sender As Object, e As EventArgs) Handles BtnHideCustomerPnl.Click

        PnlCustomerInfo.Visible = False

    End Sub

    Private Sub TxtCustMobile_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCustMobile.KeyDown

        If e.KeyCode = Keys.Enter Then

            If TxtCustMobile.Text = String.Empty Or TxtCustMobile.Text.Length <> 10 Then
                TTip.Show("Enter Valid Mobile..!", TxtCustMobile, 0, 25, 2000)
                Exit Sub
            End If

            SQL = $"select customerid,customername 
            from customers
            where locationid = {ShopID} and phone = '{TxtCustMobile.Text.Trim}'"

            With ESSA.OpenReader(SQL)
                If .Read Then
                    IsPresent = True
                    customerId = .Item("CustomerID")
                    TxtCustName.Text = .Item("CustomerName").trim()
                End If
                TxtCustName.Focus()
            End With

        End If

    End Sub

    Private Sub TxtCashNew_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCashNew.KeyDown

        If e.KeyCode = Keys.Enter Then
            If CalculateTotalNew() >= Val(lblBillAmt.Text) Then
                BtnSaveNew.PerformClick()
            Else
                TxtCardNew.Focus()
            End If
        End If

    End Sub

    Private Function CalculateTotalNew() As Double

        Dim total As Double = Val(TxtCashNew.Text) + Val(TxtCardNew.Text) + Val(TxtUpiNew.Text)
        Return total

    End Function

    Private Async Sub BtnSaveNew_Click(sender As Object, e As EventArgs) Handles BtnSaveNew.Click

        Try

            If CalculateTotalNew() < Val(lblBillAmt.Text) Then
                TTip.Show("Bill value is higher .!", TxtCashNew, 0, 25, 2000)
                Exit Sub
            ElseIf CalculateUpiAndCard() > Val(lblBillAmt.Text) Then
                TTip.Show("Card value should not be higher than required amount..!", TxtCardNew, 0, 25, 2000)
                Exit Sub
            ElseIf CalculateUpiAndCard() > Val(lblBillAmt.Text) Then
                TTip.Show("UPI value should not be higher than required amount..!", TxtUpiNew, 0, 25, 2000)
                Exit Sub
            End If
            BtnSaveNew.Enabled = False
            PnlLoading.Visible = True
            PnlLoading.BringToFront()
            Await SaveBillNew()
            PnlLoading.Visible = False
            BtnSaveNew.Enabled = True
        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

    End Sub

    Private Sub TxtCardNew_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCardNew.KeyDown

        If e.KeyCode = Keys.Enter Then

            If CalculateUpiAndCard() > Val(lblBillAmt.Text) Then
                'MsgBox("Card and Upi Value should not be higher than required amount..!", MsgBoxStyle.Critical)
                TTip.Show("Card value should not be higher than required amount..!", TxtCardNew, 0, 25, 2000)
                Exit Sub
            ElseIf CalculateTotalNew() >= Val(lblBillAmt.Text) Then
                BtnSaveNew.PerformClick()
            Else
                TxtUpiNew.Focus()
            End If

        End If

    End Sub

    Private Sub TxtUpiNew_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUpiNew.KeyDown

        If e.KeyCode = Keys.Enter Then

            If CalculateUpiAndCard() > Val(lblBillAmt.Text) Then
                'MsgBox("Card and UPI Value should not be higher than required amount", MsgBoxStyle.Critical)
                TTip.Show("UPI value should not be higher than required amount..!", TxtUpiNew, 0, 25, 2000)
                Exit Sub
            ElseIf CalculateTotalNew() >= Val(lblBillAmt.Text) Then
                BtnSaveNew.PerformClick()
            Else
                TxtCashNew.Focus()
            End If

        End If

    End Sub

    Private Sub BtnHideNew_Click(sender As Object, e As EventArgs) Handles BtnHideNew.Click

        PnlPaymentNew.Visible = False

    End Sub

    Private Sub TxtCashNew_TextChanged(sender As Object, e As EventArgs) Handles TxtCashNew.TextChanged

        LblReturnInCash.Text = Format(CalculateTotalNew() - Val(lblBillAmt.Text), "0.00")

    End Sub

    Private Sub TxtCardNew_TextChanged(sender As Object, e As EventArgs) Handles TxtCardNew.TextChanged

        LblReturnInCash.Text = Format(CalculateTotalNew() - Val(lblBillAmt.Text), "0.00")

    End Sub

    Private Sub TxtUpiNew_TextChanged(sender As Object, e As EventArgs) Handles TxtUpiNew.TextChanged

        LblReturnInCash.Text = Format(CalculateTotalNew() - Val(lblBillAmt.Text), "0.00")

    End Sub

    Private Function CalculateUpiAndCard() As Double

        Dim total As Double = Val(TxtCardNew.Text) + Val(TxtUpiNew.Text)
        Return total

    End Function

    Private Sub TxtCustName_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCustName.KeyDown

        If e.KeyCode = Keys.Enter Then
            BtnCustSave.PerformClick()
        End If

    End Sub

    Private Sub BtnSkip_Click(sender As Object, e As EventArgs) Handles BtnSkip.Click

        customerId = 1
        PnlPaymentNew.Visible = True
        PnlPaymentNew.BringToFront()
        TxtCashNew.Focus()
        PnlCustomerInfo.Visible = False
        PnlLoading.Visible = False

    End Sub

    Private Async Function UpdateShopSettings() As Task

        SQL = $"SELECT * FROM ShopSettings WHERE ShopID = {ShopID}"
        With Await ESSA.OpenReaderAsync(SQL)
            If Await .ReadAsync Then
                NewPrintCopies = .Item(1)
                NewRePrintCopies = .Item(2)
                NewPrinterName = .GetString(3)
                NewBusinessDate = .GetDateTime(4).Date
                NewPaymentMode = .Item(5)
                is3InchPrinter = .Item(6)
                alterPwd = .GetString(7).Trim
            End If
            .Close()
        End With

    End Function

    Private SmsApiUrl As String = ""
    Private messageTemplate As String = ""
    Private message As String = ""

    Private Async Function SendSmsAsync(CustMobileNo As String, ShopName As String, Billdate As String, ShopNumber As String) As Task(Of String)

        Try

            Dim httpClient As New HttpClient()

            message = Replace(messageTemplate, "@shop", ShopName)
            message = Replace(message, "@date", Billdate)
            message = Replace(message, "@mobile", ShopNumber)

            Dim url As String = SmsApiUrl.Replace("@PhNo", CustMobileNo)
            Dim finalURL As String = url.Replace("@Text", message)

            Dim response As HttpResponseMessage = Await httpClient.GetAsync(finalURL)
            'Dim responseContent As String = Await response.Content.ReadAsStringAsync()
            'MessageBox.Show("Message Sent Successfully. API Response: " & responseContent)

            If response.IsSuccessStatusCode Then
                CustMobileNo = ""
                Return "Sent Successfully"
            Else
                Return "Failed"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return "Failed"
        End Try
    End Function

    Private Async Function GetSMSApiSettings() As Task

        Dim Username As String = ""
        Dim Password As String = ""

        Username = Await ESSA.GenerateData("select param_value from settings where param_name='SMSApiUN'")
        Password = Await ESSA.GenerateData("select param_value from settings where param_name='SMSApiPW'")
        messageTemplate = Await ESSA.GenerateData("select template from sms_templates where purpose = 'BILL'")
        SmsApiUrl = Await ESSA.GenerateData("select param_value from settings where param_name='SMSApi'")

        SmsApiUrl = Replace(SmsApiUrl, "@ID", Username)
        SmsApiUrl = Replace(SmsApiUrl, "@Pwd", Password)

    End Function

    Private Sub SendSms(MobileNo As String, ShopName As String, Billdate As String)

        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim url As String

        Dim message As String = Replace(messageTemplate, "@shop", ShopName)
        message = Replace(messageTemplate, "@date", Billdate)
        Replace(messageTemplate, "@mobile", MobileNo)

        Try

            SmsApiUrl = Replace(SmsApiUrl, "@PhNo", MobileNo)
            url = Replace(SmsApiUrl, "@Text", message)

            request = DirectCast(WebRequest.Create(url), HttpWebRequest)
            response = DirectCast(request.GetResponse(), HttpWebResponse)

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub

        End Try

        If response.StatusCode = HttpStatusCode.OK Then
            MsgBox("Message Sent Successfully..!")
        End If

        response.Close()

    End Sub

    Private Async Function SendSmsAsync2(MobileNo As String, ShopName As String, Billdate As String) As Task(Of String)


        Dim url As String = ""

        Dim message As String = $"Dear Customer, Thank you for your purchase at {ShopName} on {Billdate}, " &
                            "We hope you enjoy your new purchase! -ESSA GARMENTS PRIVATE LIMITED"

        Try

            SmsApiUrl = Replace(SmsApiUrl, "@PhNo", MobileNo)
            url = Replace(SmsApiUrl, "@Text", message)

            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "GET"

            Using response As HttpWebResponse = CType(Await request.GetResponseAsync(), HttpWebResponse)
                Dim responseStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(responseStream)
                Dim responseContent As String = Await reader.ReadToEndAsync()

                If response.StatusCode = HttpStatusCode.OK Then
                    MessageBox.Show("Message Sent Successfully. API Response: " & responseContent)
                    Return "Sent Successfully"
                Else
                    MessageBox.Show("Message Sending Failed. API Response: " & responseContent)
                    Return "Failed"
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return "Failed"
        End Try
    End Function

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click

        'StockSearch.Show(Me)

    End Sub

    Private Async Function SaveBillNew() As Task

        Try

            If TG.Rows.Count = 0 Then
                TTip.Show("No items to generate to bill..!", btnStore, 0, 25, 2000)
                Exit Function
            End If

            If ESSA.IsDuplicateExists(TG, 0) Then
                TTip.Show("Duplicate barcode exists", btnStore, 0, 25, 2000)
                Exit Function
            End If

            ESSA.OpenConnection()
            Dim Cmd = Con.CreateCommand()
            Dim Trn = Con.BeginTransaction(IsolationLevel.Serializable)
            Cmd.Transaction = Trn
            Cmd.CommandType = CommandType.StoredProcedure

            Try

                If Not Edit Then
                    nTermID = TermID
                    Await GenerateBillNo()
                    If HoldID.Count > 0 Then
                        Dim holdList = String.Join(",", HoldID)
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = $"DELETE FROM billdetailshold WHERE shopid = {ShopID} AND billid IN ({holdList})"
                        Await Cmd.ExecuteNonQueryAsync()
                        Cmd.CommandType = CommandType.StoredProcedure
                    End If
                Else
                    Cmd.CommandText = "sp_DeleteBillById"
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@BillId", BillID)
                    Cmd.Parameters.AddWithValue("@ShopId", ShopID)
                    Await Cmd.ExecuteNonQueryAsync()
                End If

                Cmd.CommandText = "sp_InsertBillMaster"
                Cmd.Parameters.Clear()
                Cmd.Parameters.AddWithValue("@BillID", BillID)
                Cmd.Parameters.AddWithValue("@BillNo", BillNo)
                Cmd.Parameters.AddWithValue("@BillDt", IIf(ISAdmin,
                                                           IIf(BillMode = 0 AndAlso Edit = False,
                                                               Format(Now.Date, "yyyy-MM-dd"),
                                                               Format(billDt, "yyyy-MM-dd")),
                                                           Format(Now.Date, "yyyy-MM-dd")))
                Cmd.Parameters.AddWithValue("@BillTime", IIf(ISAdmin,
                                                             IIf(BillMode = 0 AndAlso Edit = False,
                                                                 Format(Now, "yyyy-MM-dd HH:mm:ss"),
                                                                 Format(billTime, "yyyy-MM-dd HH:mm:ss")),
                                                             Format(Now, "yyyy-MM-dd HH:mm:ss")))
                Cmd.Parameters.AddWithValue("@TermID", nTermID)
                Cmd.Parameters.AddWithValue("@TotQty", Val(lblQty.Text))
                Cmd.Parameters.AddWithValue("@TotAmt", Val(lblNetAmt.Text))
                Cmd.Parameters.AddWithValue("@DisPerc", Val(lblDisPerc.Text))
                Cmd.Parameters.AddWithValue("@DisAmt", Val(lblDisAmt.Text))
                Cmd.Parameters.AddWithValue("@CustomerID", customerId)
                Cmd.Parameters.AddWithValue("@RefNo", eRefNo)
                Cmd.Parameters.AddWithValue("@Remarks", Remark)
                Cmd.Parameters.AddWithValue("@ShopID", ShopID)
                Cmd.Parameters.AddWithValue("@UserID", UserID)
                Cmd.Parameters.AddWithValue("@ISUpdated", 0)
                Cmd.Parameters.AddWithValue("@WHID", 1)
                'Dim paramDetails As String = "Parameter Type Info:" & vbCrLf

                'For Each param As SqlParameter In Cmd.Parameters
                '    paramDetails &= $"{param.ParameterName} - {param.Value} ({param.Value?.GetType()?.FullName}){vbCrLf}"
                'Next

                'MsgBox(paramDetails, MsgBoxStyle.Information)
                Await Cmd.ExecuteNonQueryAsync()

                Cmd.CommandText = "sp_InsertBillDetails"
                Cmd.Parameters.Clear()
                Cmd.Parameters.AddWithValue("@Details", BuildBillDetailsTable())
                Await Cmd.ExecuteNonQueryAsync()

                Cmd.CommandText = "sp_InsertBillSalePersons"
                Cmd.Parameters.Clear()
                Cmd.Parameters.AddWithValue("@Details", BuildSalePersonsTable())
                Await Cmd.ExecuteNonQueryAsync()

                Cmd.CommandText = "sp_InsertBillPayments"
                Cmd.Parameters.Clear()
                Cmd.Parameters.AddWithValue("@Payments", BuildPaymentsTable())
                Await Cmd.ExecuteNonQueryAsync()

                Trn.Commit()
                Con.Close()

                Dim tasks As New List(Of Task)()
                If chkEP.Checked Then
                    tasks.Add(PrintBillUsingCrystalReport(BillID, "Original"))
                End If

                If Not String.IsNullOrWhiteSpace(MobileNo) AndAlso MobileNo.Length = 10 Then
                    tasks.Add(SendSmsAsync(MobileNo, ShopNm, Format(Now.Date, "dd-MM-yyyy"), shopNumber))
                    MobileNo = ""
                End If

                Await Task.WhenAll(tasks)
                Await RefreshBill()

            Catch ex As SqlException
                Trn.Rollback()
                Con.Close()
                MsgBox("SQL Error: " & ex.Message, MsgBoxStyle.Critical)
            Catch ex1 As Exception
                Trn.Rollback()
                Con.Close()
                MsgBox("Application Error: " & ex1.Message, MsgBoxStyle.Critical)
            Finally
                Trn?.Dispose()
                If Con.State = ConnectionState.Open Then Con.Close()
            End Try
        Catch ex As Exception
            MsgBox("Unhandled Error: " & ex.Source, MsgBoxStyle.Critical)
        End Try

    End Function

    Private Function BuildBillDetailsTable() As DataTable
        Dim dt As New DataTable()
        dt.Columns.AddRange({
            New DataColumn("BillID", GetType(Long)),
            New DataColumn("BillDt", GetType(DateTime)),
            New DataColumn("PluID", GetType(Integer)),
            New DataColumn("Qty", GetType(Double)),
            New DataColumn("RQty", GetType(Double)),
            New DataColumn("Rate", GetType(Decimal)),
            New DataColumn("Amount", GetType(Decimal)),
            New DataColumn("DisPerc", GetType(Double)),
            New DataColumn("DisAmt", GetType(Decimal)),
            New DataColumn("ORate", GetType(Decimal)),
            New DataColumn("OBillID", GetType(Long)),
            New DataColumn("BillMode", GetType(Byte)),
            New DataColumn("TermID", GetType(Byte)),
            New DataColumn("ShopID", GetType(Byte)),
            New DataColumn("Sno", GetType(Short)),
            New DataColumn("ISUpdated", GetType(Byte)),
            New DataColumn("WHID", GetType(Byte))
        })

        For i As Integer = 0 To TG.Rows.Count - 1
            dt.Rows.Add(
                BillID,
                IIf(ISAdmin,
                    IIf(BillMode = 0 And Edit = False,
                        Format(Now.Date, "yyyy-MM-dd"),
                        Format(billDt, "yyyy-MM-dd")),
                    Format(Now.Date, "yyyy-MM-dd")),        ' BillDt
                Val(TG.Item(0, i).Value),                   ' PluID
                Val(TG.Item(5, i).Value),                   ' Qty
                0,                                          ' RQty (default 0)
                Val(TG.Item(11, i).Value),                  ' Rate
                Val(TG.Item(9, i).Value),                   ' Amount
                Val(TG.Item(7, i).Value),                   ' DisPerc
                Val(TG.Item(8, i).Value),                   ' DisAmt
                Val(TG.Item(6, i).Value),                   ' ORate
                Val(TG.Item(12, i).Value),                  ' OBILLID
                BillMode,
                nTermID,
                ShopID,
                i + 1,                                      ' Sno
                0,                                          ' ISUpdated
                1                                           ' WHID (default 1)
            )
        Next

        Return dt
    End Function

    Private Function BuildPaymentsTable() As DataTable
        Dim dt As New DataTable()
        dt.Columns.AddRange({
        New DataColumn("BillID", GetType(Long)),
        New DataColumn("ShopID", GetType(Byte)),
        New DataColumn("PaymentID", GetType(Byte)),
        New DataColumn("PaymentDesc", GetType(String)),
        New DataColumn("Paid", GetType(Decimal)),
        New DataColumn("Refund", GetType(Decimal)),
        New DataColumn("RefNo", GetType(String)),
        New DataColumn("RefDt", GetType(DateTime)),
        New DataColumn("Sno", GetType(Byte)),
        New DataColumn("TermID", GetType(Byte)),
        New DataColumn("BillDt", GetType(DateTime)),
        New DataColumn("IsUpdated", GetType(Byte)),
        New DataColumn("WHID", GetType(Byte))
    })

        Dim orderNo As Byte = 1
        If NewPaymentMode Then
            If Val(TxtCashNew.Text) > 0 Then
                dt.Rows.Add(BillID, ShopID, 1, "CASH", Val(TxtCashNew.Text), Val(LblReturnInCash.Text), "", Now, orderNo, nTermID, IIf(ISAdmin,
                    IIf(BillMode = 0 And Edit = False,
                        Format(Now.Date, "yyyy-MM-dd"),
                        Format(billDt, "yyyy-MM-dd")),
                    Format(Now.Date, "yyyy-MM-dd")), 0, 1)
                orderNo += 1
            End If
            If Val(TxtCardNew.Text) > 0 Then
                dt.Rows.Add(BillID, ShopID, 2, "CARD", Val(TxtCardNew.Text), 0, "", Now, orderNo, nTermID, IIf(ISAdmin,
                    IIf(BillMode = 0 And Edit = False,
                        Format(Now.Date, "yyyy-MM-dd"),
                        Format(billDt, "yyyy-MM-dd")),
                    Format(Now.Date, "yyyy-MM-dd")), 0, 1)
                orderNo += 1
            End If
            If Val(TxtUpiNew.Text) > 0 Then
                dt.Rows.Add(BillID, ShopID, 3, "UPI", Val(TxtUpiNew.Text), 0, "", Now, orderNo, nTermID, IIf(ISAdmin,
                    IIf(BillMode = 0 And Edit = False,
                        Format(Now.Date, "yyyy-MM-dd"),
                        Format(billDt, "yyyy-MM-dd")),
                    Format(Now.Date, "yyyy-MM-dd")), 0, 1)
            End If
        Else
            For j As Integer = 0 To TGPmt.Rows.Count - 1
                dt.Rows.Add(
                BillID,
                ShopID,
                Val(TGPmt.Item(0, j).Value),            'PaymentId
                TGPmt.Item(1, j).Value.ToString(),      'PaymentDesc    
                Val(TGPmt.Item(4, j).Value),            'Paid
                Val(TGPmt.Item(5, j).Value),            'Refund
                TGPmt.Item(2, j).Value.ToString(),      'Ref No
                CDate(TGPmt.Item(3, j).Value),          'Ref Date
                j + 1,                                  'S No
                nTermID,
                IIf(ISAdmin,
                    IIf(BillMode = 0 And Edit = False,
                        Format(Now.Date, "yyyy-MM-dd"),
                        Format(billDt, "yyyy-MM-dd")),
                    Format(Now.Date, "yyyy-MM-dd")),    'Bill Date
                0,                                      'IsUpdated
                1                                       'WHID
            )
            Next
        End If

        Return dt
    End Function

    Private Function BuildSalePersonsTable() As DataTable
        Dim dt As New DataTable()
        dt.Columns.AddRange({
        New DataColumn("BillID", GetType(Long)),
        New DataColumn("SPID", GetType(Short)),
        New DataColumn("PluID", GetType(Integer)),
        New DataColumn("ShopID", GetType(Byte))
    })

        For i As Integer = 0 To TG.Rows.Count - 1
            dt.Rows.Add(
            BillID,
            Val(TG.Item(16, i).Value), 'SPID
            Val(TG.Item(0, i).Value),  'PLUID
            ShopID
        )
        Next

        Return dt
    End Function

End Class
