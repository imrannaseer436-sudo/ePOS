''************************************** Bismillah ****************************************
'Imports Microsoft.PointOfService
Public Class iPOSPrinterNew

    '#Region "I N I T I A L Z E R"

    '    Private POSPrn As PosPrinter = Nothing
    '    Private iShopName As String
    '    Private iAddress1 As String
    '    Private iAddress2 As String
    '    Private iCity As String
    '    Private iTIN As String
    '    Private iPhone As String
    '    Private iFooter As String
    '    Private iStr As String = ""
    '    Private Msg As String = ""
    '    Private ESC As String = Chr(&H1B)
    '    Private tQty As Double = 0
    '    Private dAmt As Double = 0
    '    Private tAmt As Double = 0
    '    Private nAmt As Double = 0
    '    Private IsClaimSuccessfull As Boolean

    '#End Region

    '#Region "C O M M O N  D A T A"

    '    Private Sub InitializeShopHeader()

    '        SQL = "select alias,address1,address2,city,vat,phone from shops where shopid=" & ShopID & ";" _
    '            & "select param_value from settings where param_name='BillFooter'"
    '        With ESSA.OpenReader(SQL)
    '            If .Read Then
    '                iShopName = .GetString(0).Trim
    '                iAddress1 = .GetString(1).Trim
    '                iAddress2 = .GetString(2).Trim
    '                iCity = .GetString(3).Trim
    '                iTIN = .GetString(4).Trim
    '                iPhone = .GetString(5).Trim
    '            End If
    '            .NextResult()
    '            If .Read Then
    '                iFooter = .GetString(0).Trim
    '            End If
    '            .Close()
    '        End With

    '    End Sub

    '    Public Function ConnectToPrinter() As Boolean

    '        Dim i As SByte = 1

    '        ConnectToPrinter = False

    '        Dim POSExp As New PosExplorer
    '        Dim POSDvs As DeviceInfo = Nothing

    '        Try

    '            If PrinterName = "" Then

    '                POSDvs = POSExp.GetDevice("PosPrinter")

    '            Else

    '                Dim DCol As DeviceCollection = POSExp.GetDevices("PosPrinter")
    '                For Each di As DeviceInfo In DCol

    '                    If di.ServiceObjectName.Contains(PrinterName) Then
    '                        POSDvs = di
    '                        Exit For
    '                    End If

    '                Next

    '            End If

    '            POSPrn = POSExp.CreateInstance(POSDvs)

    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical)
    '            Exit Function
    '        End Try

    '        Try

    'rt:
    '            POSPrn.Open()
    '            POSPrn.Claim(2000)
    '            POSPrn.DeviceEnabled = True
    '            ConnectToPrinter = True
    '            IsClaimSuccessfull = True

    '        Catch ex As PosControlException

    '            IsClaimSuccessfull = False

    '            If ex.Message.Contains("Claim") Then
    '                If i = 3 Then
    '                    MsgBox("Unable to calim printer device..!" & vbCrLf _
    '                           & "Resons :" & vbCrLf _
    '                           & "1. Check your printer turned on..!" & vbCrLf, vbCritical)
    '                    POSPrn.Close()
    '                Else
    '                    POSPrn.Close()
    '                    i += 1
    '                    GoTo rt
    '                End If
    '            Else
    '                MsgBox(ex.Message, MsgBoxStyle.Critical)
    '            End If

    '            Exit Function

    '        End Try

    '        InitializeShopHeader()

    '    End Function

    '    Public Sub RealsePrinter()

    '        If IsClaimSuccessfull = True Then

    '            Try
    '                POSPrn.DeviceEnabled = False
    '                POSPrn.Release()
    '                POSPrn.Close()
    '            Catch ex As Exception
    '                MsgBox(ex.Message, MsgBoxStyle.Critical)
    '            End Try

    '        End If


    '    End Sub

    '#End Region

    '#Region "P R I N T  F O R M A T - A"


    '    Public Sub PrintBill(ByVal iBillID As Integer, ByVal CopyStatus As String)

    '        PrintHeader(iBillID, CopyStatus)
    '        PrintDetails(iBillID)
    '        PrintFooters()
    '        PrintPayments(iBillID)

    '    End Sub

    '    Private Sub PrintHeader(ByVal iBillID As Integer, ByVal CopyStatus As String)

    '        Try

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|2C" + ESC + "|bC" + iShopName + vbCrLf)
    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + iAddress1 + vbCrLf)
    '            If iAddress2.Trim.Length > 0 Then
    '                POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + iAddress2 + vbCrLf)
    '            End If

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + iCity + vbCrLf)

    '            If iPhone.Trim.Length > 0 Then
    '                POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + "PH:" + iPhone + vbCrLf)
    '            End If

    '            If iTIN.Trim.Length > 0 Then
    '                POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + "TIN:" + iTIN + vbCrLf)
    '            End If

    '            SQL = "select m.billno,m.billtime,m.termid,u.username,m.refno from billmaster m,users u where " _
    '                & "m.userid=u.userid and m.billid=" & iBillID

    '            With ESSA.OpenReader(SQL)
    '                If .Read Then

    '                    POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + CopyStatus + vbCrLf)
    '                    POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|bC" + "Bill No : " + ESC + "|2C" & .Item(2) & "/" & .Item(0) & ESC + "|N" + ESC + "|bC" + "                   Bill Time : " & Format(.GetDateTime(1), "g") + vbCrLf)
    '                    If Not .Item(4) = "" Then
    '                        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|bC" + "ORef No : " & .GetString(4) + vbCrLf)
    '                    End If

    '                End If
    '                .Close()
    '            End With

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                                                    " + vbCrLf + vbCrLf)
    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|bC" + "Sno  Particulars           Qty      Rate   Dis%   D.Amt     Amount  " + vbCrLf)
    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                                                    " + vbCrLf + vbCrLf)

    '        Catch ex As PosControlException
    '            RealsePrinter()
    '            ConnectToPrinter()
    '            PrintHeader(iBillID, CopyStatus)
    '        End Try

    '    End Sub

    '    Private Sub PrintDetails(ByVal iBillID As Integer)

    '        SQL = "select d.sno,p.pluname,d.qty,d.orate,d.disperc,d.disamt,d.amount,(d.qty*d.orate) stot from billdetails d,productmaster p " _
    '            & "where p.pluid=d.pluid and d.billid=" & iBillID & " order by sno"

    '        tQty = 0
    '        tAmt = 0
    '        dAmt = 0
    '        nAmt = 0

    '        With ESSA.OpenReader(SQL)
    '            While .Read

    '                tQty += IIf(.Item(2) > 0, .Item(2), 0)
    '                nAmt += .Item(6)
    '                tAmt += .Item(7)
    '                dAmt += .Item(5)
    '                Msg = .Item(0)
    '                iStr = .Item(0) & Space(5 - Msg.Length)
    '                Msg = Space(13 - Mid(.GetString(1), 1, 13).Trim.Length)
    '                iStr &= Mid(.GetString(1), 1, 13).Trim + Msg
    '                Msg = .Item(2)
    '                iStr &= Space(12 - Msg.Length) & Msg
    '                Msg = Format(.Item(3), "0.00")
    '                iStr &= Space(10 - Msg.Length) & Msg
    '                Msg = Format(.Item(4), "0.0")
    '                iStr &= Space(7 - Msg.Length) & Msg
    '                Msg = Format(.Item(5), "0.00")
    '                iStr &= Space(8 - Msg.Length) & Msg
    '                Msg = Format(.Item(7), "0.00")
    '                iStr &= Space(11 - Msg.Length) & Msg
    '                POSPrn.PrintNormal(PrinterStation.Receipt, iStr & vbCrLf)

    '            End While
    '            .Close()
    '        End With

    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                                                    " + vbCrLf + vbCrLf)

    '    End Sub

    '    Private Sub PrintFooters()

    '        If dAmt > 0 Then

    '            iStr = "SubTotal"
    '            Msg = Format(tAmt, "0.00")
    '            iStr &= Space(59 - Msg.Length) & Msg
    '            POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)

    '            iStr = "Discount"
    '            Msg = Format(dAmt, "0.00")
    '            iStr &= Space(59 - Msg.Length) & Msg
    '            POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)

    '            Dim Roff As Double = Math.Round(nAmt) - nAmt
    '            If Roff <> 0 Then
    '                iStr = "Round Off"
    '                Msg = Format(Roff, "0.00")
    '                iStr &= Space(58 - Msg.Length) & Msg
    '                POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)
    '            End If

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                                                    " + vbCrLf + vbCrLf)

    '        End If

    '        iStr = "TOTAL"
    '        Msg = tQty
    '        iStr &= Space(10 - Msg.Length) & Msg

    '        nAmt += Math.Round(nAmt) - nAmt
    '        Msg = Format(nAmt, "0.00")
    '        iStr &= Space(19 - Msg.Length) & Msg


    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2C" + ESC + "|bC" + iStr + vbCrLf)
    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                                                    " + vbCrLf)

    '    End Sub

    '    Private Sub PrintPayments(ByVal iBillID As Integer)

    '        SQL = "select paymentdesc,refno,paid,refund from billpayments where billid=" & iBillID & " order by sno"
    '        With ESSA.OpenReader(SQL)
    '            If .HasRows Then

    '                While .Read

    '                    If .GetString(0).Trim = "CASH" Then
    '                        iStr = .GetString(0)
    '                    Else
    '                        Msg = .GetString(0) & "/" & .GetString(1)
    '                        iStr = .GetString(0) & "/" & .GetString(1) + Space(20 - Msg.Length)
    '                    End If

    '                    If .Item(0) = "CASH" Then

    '                        If .Item(2) > 0 Then
    '                            iStr &= Space(28) + "Customer Payment"
    '                            Msg = Format(.Item(2), "0.00")
    '                            iStr &= Space(19 - Msg.Length) + Msg
    '                            POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)
    '                        ElseIf .Item(2) < 0 Then
    '                            iStr &= Space(28) + "Refund          "
    '                            Msg = Format(.Item(2), "0.00")
    '                            iStr &= Space(19 - Msg.Length) + Msg
    '                            POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)
    '                        End If

    '                        If .Item(3) < 0 Then
    '                            iStr = Space(32) + "Refund"
    '                            Msg = Format(-.Item(3), "0.00")
    '                            iStr &= Space(29 - Msg.Length) + Msg
    '                            POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)
    '                        ElseIf .Item(3) > 0 Then
    '                            iStr = Space(32) + "Change"
    '                            Msg = Format(.Item(3), "0.00")
    '                            iStr &= Space(29 - Msg.Length) + Msg
    '                            POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)
    '                        End If

    '                    Else
    '                        Msg = Format(.Item(2), "0.00")
    '                        iStr &= Space(47 - Msg.Length) + Msg
    '                        POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)
    '                    End If

    '                End While
    '            End If
    '            .Close()
    '        End With
    '        POSPrn.PrintNormal(PrinterStation.Receipt, vbCrLf)
    '        iStr = "E.& O.E"
    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + iFooter + vbCrLf)
    '        POSPrn.PrintNormal(PrinterStation.Receipt, iStr + ESC + "|fP")

    '    End Sub


    '#End Region

    '#Region "P R I N T F O R M A T - B"


    '    Public Sub PrintBill46(ByVal iBillID As Integer, ByVal CopyStatus As String)

    '        PrintHeader46(iBillID, CopyStatus)
    '        PrintDetails46(iBillID)
    '        PrintFooters46()
    '        PrintPayments46(iBillID)

    '    End Sub

    '    Private Sub PrintHeader46(ByVal iBillID As Integer, ByVal CopyStatus As String)

    '        'POSPrn.SetBitmap(1, PrinterStation.Receipt, "c:\logo.bmp", 800, PosPrinter.PrinterBitmapCenter)
    '        'POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|1B")

    '        Try

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|2C" + ESC + "|bC" + iShopName + vbCrLf)
    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + iAddress1 + vbCrLf)
    '            If iAddress2.Trim.Length > 0 Then
    '                POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + iAddress2 + vbCrLf)
    '            End If

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + iCity + vbCrLf)

    '            If iPhone.Trim.Length > 0 Then
    '                POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + "PH:" + iPhone + vbCrLf)
    '            End If

    '            If iTIN.Trim.Length > 0 Then
    '                POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + "TIN:" + iTIN + vbCrLf)
    '            End If

    '            SQL = "select m.billno,m.billtime,m.termid,u.username,m.refno from billmaster m,users u where " _
    '                & "m.userid=u.userid and m.billid=" & iBillID

    '            With ESSA.OpenReader(SQL)
    '                If .Read Then

    '                    POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + CopyStatus + vbCrLf)
    '                    POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|bC" + "Bill No   : " + ESC + "|2C" & .Item(2) & "/" & .Item(0) & ESC + "|N" + vbCrLf)
    '                    POSPrn.PrintNormal(PrinterStation.Receipt, "Bill Time : " & Format(.GetDateTime(1), "g") + vbCrLf)

    '                    If Not .Item(4) = "" Then
    '                        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|bC" + "ORef No : " & .GetString(4) + vbCrLf)
    '                    End If

    '                End If
    '                .Close()
    '            End With

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                          " + vbCrLf + vbCrLf)
    '            'POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|bC" + "Sno  Particulars           Qty      Rate        Discount     Amount  " + vbCrLf)
    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|bC" + "Particulars       Qty     Rate     Amount  " + vbCrLf)
    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                          " + vbCrLf + vbCrLf)

    '        Catch ex As PosControlException
    '            RealsePrinter()
    '            ConnectToPrinter()
    '            PrintHeader46(iBillID, CopyStatus)
    '        End Try

    '    End Sub

    '    Private Sub PrintDetails46(ByVal iBillID As Integer)

    '        SQL = "select p.pluname,d.qty,d.orate,(d.qty*d.orate) stot,d.amount,d.disamt from billdetails d,productmaster p " _
    '            & "where p.pluid=d.pluid and d.billid=" & iBillID & " order by sno"

    '        tQty = 0
    '        tAmt = 0
    '        dAmt = 0
    '        nAmt = 0

    '        With ESSA.OpenReader(SQL)
    '            While .Read

    '                tQty += IIf(.Item(1) > 0, .Item(1), 0)
    '                tAmt += .Item(3)
    '                nAmt += .Item(4)
    '                dAmt += .Item(5)
    '                Msg = Space(13 - Mid(.GetString(0), 1, 13).Trim.Length)
    '                iStr = Mid(.GetString(0), 1, 13).Trim + Msg
    '                Msg = .Item(1)
    '                iStr &= Space(8 - Msg.Length) & Msg
    '                Msg = Format(.Item(2), "0.00")
    '                iStr &= Space(9 - Msg.Length) & Msg
    '                Msg = Format(.Item(3), "0.00")
    '                iStr &= Space(11 - Msg.Length) & Msg
    '                POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)

    '            End While
    '            .Close()
    '        End With

    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                          " + vbCrLf + vbCrLf)

    '    End Sub

    '    Private Sub PrintFooters46()

    '        If dAmt > 0 Then

    '            iStr = "SubTotal"
    '            Msg = Format(tAmt, "0.00")
    '            iStr &= Space(33 - Msg.Length) & Msg
    '            POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)

    '            iStr = "Discount"
    '            Msg = Format(dAmt, "0.00")
    '            iStr &= Space(33 - Msg.Length) & Msg
    '            POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)

    '            Dim Roff As Double = Math.Round(nAmt) - nAmt
    '            If Roff <> 0 Then
    '                iStr = "Round Off"
    '                Msg = Format(Roff, "0.00")
    '                iStr &= Space(32 - Msg.Length) & Msg
    '                POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)
    '            End If

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                          " + vbCrLf + vbCrLf)

    '        End If

    '        iStr = "TOTAL"

    '        Msg = tQty
    '        iStr &= Space(6 - Msg.Length) & Msg

    '        nAmt += Math.Round(nAmt) - nAmt
    '        Msg = Format(nAmt, "0.00")
    '        iStr &= Space(10 - Msg.Length) & Msg

    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2C" + ESC + "|bC" + iStr + vbCrLf)
    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                          " + vbCrLf)

    '    End Sub

    '    Private Sub PrintPayments46(ByVal iBillID As Integer)

    '        SQL = "select paymentdesc,refno,paid,refund from billpayments where billid=" & iBillID & " order by sno"
    '        With ESSA.OpenReader(SQL)
    '            If .HasRows Then

    '                While .Read

    '                    If .GetString(0).Trim = "CASH" Then
    '                        iStr = .GetString(0)
    '                    Else
    '                        Msg = .GetString(0) & "/" & .GetString(1)
    '                        iStr = .GetString(0) & "/" & .GetString(1) + Space(20 - Msg.Length)
    '                    End If

    '                    If .Item(0) = "CASH" Then

    '                        If .Item(2) > 0 Then
    '                            iStr &= Space(16) + "Tender"
    '                            Msg = Format(.Item(2), "0.00")
    '                            iStr &= Space(15 - Msg.Length) + Msg
    '                            POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)
    '                        End If

    '                        If .Item(3) < 0 Then
    '                            iStr = Space(20) + "Refund"
    '                            Msg = Format(-.Item(3), "0.00")
    '                            iStr &= Space(15 - Msg.Length) + Msg
    '                            POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)
    '                        ElseIf .Item(3) > 0 Then
    '                            iStr = Space(20) + "Change"
    '                            Msg = Format(.Item(3), "0.00")
    '                            iStr &= Space(15 - Msg.Length) + Msg
    '                            POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)
    '                        End If

    '                    Else
    '                        Msg = Format(.Item(2), "0.00")
    '                        iStr &= Space(21 - Msg.Length) + Msg
    '                        POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)
    '                    End If

    '                End While
    '            End If
    '            .Close()
    '        End With
    '        POSPrn.PrintNormal(PrinterStation.Receipt, vbCrLf)
    '        iStr = "E.& O.E"
    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + iFooter + vbCrLf)
    '        POSPrn.PrintNormal(PrinterStation.Receipt, iStr + ESC + "|fP")

    '    End Sub

    '#End Region

    '#Region "P R I N T F O R M A T - HOLD (A)"

    '    Public Sub PrintHOLDBill46(ByVal iBillID As Integer, ByVal CopyStatus As String)

    '        PrintHOLDHeader46(iBillID, CopyStatus)
    '        PrintHOLDDetails46(iBillID)
    '        PrintHoldFooters46()

    '    End Sub

    '    Private Sub PrintHOLDHeader46(ByVal iBillID As Integer, ByVal CopyStatus As String)

    '        Try

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|2C" + ESC + "|bC" + iShopName + vbCrLf)
    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + iAddress1 + vbCrLf)
    '            If iAddress2.Trim.Length > 0 Then
    '                POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + iAddress2 + vbCrLf)
    '            End If

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + iCity + vbCrLf)

    '            If iPhone.Trim.Length > 0 Then
    '                POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + "PH:" + iPhone + vbCrLf)
    '            End If

    '            If iTIN.Trim.Length > 0 Then
    '                POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + "TIN:" + iTIN + vbCrLf)
    '            End If

    '            SQL = "select distinct billid,billdt from BillDetailsHold where " _
    '                & "billid=" & iBillID

    '            With ESSA.OpenReader(SQL)
    '                If .Read Then

    '                    POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + CopyStatus + vbCrLf)
    '                    POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|bC" + "Estm No   : " + ESC + "|2C" & .Item(0) & ESC + "|N" + vbCrLf)
    '                    POSPrn.PrintNormal(PrinterStation.Receipt, "Estm Time : " & Format(.GetDateTime(1), "g") + vbCrLf)

    '                End If
    '                .Close()
    '            End With

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                          " + vbCrLf + vbCrLf)
    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|bC" + "Particulars       Qty     Rate     Amount  " + vbCrLf)
    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                          " + vbCrLf + vbCrLf)

    '        Catch ex As PosControlException
    '            RealsePrinter()
    '            ConnectToPrinter()
    '            PrintHOLDHeader46(iBillID, CopyStatus)
    '        End Try

    '    End Sub

    '    Private Sub PrintHOLDDetails46(ByVal iBillID As Integer)

    '        SQL = "select p.pluname,d.qty,d.orate,(d.qty*d.orate) stot,d.amount,d.disamt from billdetailshold d,productmaster p " _
    '            & "where p.pluid=d.pluid and d.billid=" & iBillID & " order by sno"

    '        tQty = 0
    '        tAmt = 0
    '        dAmt = 0
    '        nAmt = 0

    '        With ESSA.OpenReader(SQL)
    '            While .Read

    '                tQty += IIf(.Item(1) > 0, .Item(1), 0)
    '                tAmt += .Item(3)
    '                nAmt += .Item(4)
    '                dAmt += .Item(5)
    '                Msg = Space(13 - Mid(.GetString(0), 1, 13).Trim.Length)
    '                iStr = Mid(.GetString(0), 1, 13).Trim + Msg
    '                Msg = .Item(1)
    '                iStr &= Space(8 - Msg.Length) & Msg
    '                Msg = Format(.Item(2), "0.00")
    '                iStr &= Space(9 - Msg.Length) & Msg
    '                Msg = Format(.Item(3), "0.00")
    '                iStr &= Space(11 - Msg.Length) & Msg
    '                POSPrn.PrintNormal(PrinterStation.Receipt, iStr + vbCrLf)

    '            End While
    '            .Close()
    '        End With

    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                          " + vbCrLf + vbCrLf)

    '    End Sub

    '    Private Sub PrintHoldFooters46()

    '        iStr = "TOTAL"

    '        Msg = tQty
    '        iStr &= Space(6 - Msg.Length) & Msg

    '        nAmt += Math.Round(nAmt) - nAmt
    '        Msg = Format(nAmt, "0.00")
    '        iStr &= Space(10 - Msg.Length) & Msg

    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2C" + ESC + "|bC" + iStr + vbCrLf)
    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                          " + vbCrLf)
    '        POSPrn.PrintNormal(PrinterStation.Receipt, "" + ESC + "|fP")

    '    End Sub


    '#End Region

    '#Region "P R I N T  F O R M A T - HOLD (B)"

    '    Public Sub PrintBillHOLD(ByVal iBillID As Integer, ByVal CopyStatus As String)

    '        PrintHeaderHOLD(iBillID, CopyStatus)
    '        PrintDetailsHOLD(iBillID)
    '        PrintFootersHold()

    '    End Sub

    '    Private Sub PrintHeaderHOLD(ByVal iBillID As Integer, ByVal CopyStatus As String)

    '        Try

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|2C" + ESC + "|bC" + iShopName + vbCrLf)
    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + iAddress1 + vbCrLf)
    '            If iAddress2.Trim.Length > 0 Then
    '                POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + iAddress2 + vbCrLf)
    '            End If

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + iCity + vbCrLf)

    '            If iPhone.Trim.Length > 0 Then
    '                POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + "PH:" + iPhone + vbCrLf)
    '            End If

    '            If iTIN.Trim.Length > 0 Then
    '                POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + ESC + "|bC" + "TIN:" + iTIN + vbCrLf)
    '            End If

    '            SQL = "select distinct billid,billdt from BillDetailsHold where " _
    '                & "billid=" & iBillID

    '            With ESSA.OpenReader(SQL)
    '                If .Read Then

    '                    POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + CopyStatus + vbCrLf)
    '                    POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|bC" + "Estm No : " + ESC + "|2C" & .Item(0) & ESC + "|N" + ESC + "|bC" + "                   Estm Time : " & Format(.GetDateTime(1), "g") + vbCrLf)

    '                End If
    '                .Close()
    '            End With

    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                                                    " + vbCrLf + vbCrLf)
    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|bC" + "Sno  Particulars           Qty      Rate        Discount     Amount  " + vbCrLf)
    '            POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                                                    " + vbCrLf + vbCrLf)

    '        Catch ex As PosControlException
    '            RealsePrinter()
    '            ConnectToPrinter()
    '            PrintHeader(iBillID, CopyStatus)
    '        End Try

    '    End Sub

    '    Private Sub PrintDetailsHOLD(ByVal iBillID As Integer)

    '        SQL = "select d.sno,p.pluname,d.qty,d.orate,d.disperc,d.disamt,d.amount,(d.qty*d.orate) stot from billdetailshold d,productmaster p " _
    '            & "where p.pluid=d.pluid and d.billid=" & iBillID & " order by sno"

    '        tQty = 0
    '        tAmt = 0
    '        dAmt = 0
    '        nAmt = 0

    '        With ESSA.OpenReader(SQL)
    '            While .Read

    '                tQty += IIf(.Item(2) > 0, .Item(2), 0)
    '                nAmt += .Item(6)
    '                tAmt += .Item(7)
    '                dAmt += .Item(5)
    '                Msg = .Item(0)
    '                iStr = .Item(0) & Space(5 - Msg.Length)
    '                Msg = Space(13 - Mid(.GetString(1), 1, 13).Trim.Length)
    '                iStr &= Mid(.GetString(1), 1, 13).Trim + Msg
    '                Msg = .Item(2)
    '                iStr &= Space(12 - Msg.Length) & Msg
    '                Msg = Format(.Item(3), "0.00")
    '                iStr &= Space(10 - Msg.Length) & Msg
    '                If .Item(5) > 0 Then
    '                    Msg = Format(.Item(4), "0.0") & "%" & Format(.Item(5), "0.00")
    '                Else
    '                    Msg = Format(.Item(5), "0.00")
    '                End If
    '                iStr &= Space(16 - Msg.Length) & Msg
    '                Msg = Format(.Item(7), "0.00")
    '                iStr &= Space(11 - Msg.Length) & Msg
    '                POSPrn.PrintNormal(PrinterStation.Receipt, iStr & vbCrLf)

    '            End While
    '            .Close()
    '        End With

    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                                                    " + vbCrLf + vbCrLf)

    '    End Sub

    '    Private Sub PrintFootersHold()

    '        iStr = "TOTAL"
    '        Msg = tQty
    '        iStr &= Space(10 - Msg.Length) & Msg

    '        nAmt += Math.Round(nAmt) - nAmt
    '        Msg = Format(nAmt, "0.00")
    '        iStr &= Space(19 - Msg.Length) & Msg

    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2C" + ESC + "|bC" + iStr + vbCrLf)
    '        POSPrn.PrintNormal(PrinterStation.Receipt, ESC + "|2uC" + "                                                                    " + vbCrLf)
    '        POSPrn.PrintNormal(PrinterStation.Receipt, "" + ESC + "|fP")

    '    End Sub

    '#End Region



End Class
