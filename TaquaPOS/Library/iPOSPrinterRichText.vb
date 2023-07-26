'********************************* In the name of Allah, Most Merciful, Most Compassionate ********************
Imports System.Data
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Public Class iPOSPrinterRichText

#Region "I N I T I A L I Z E R"

    Private POSPrn As Printer
    Private iShopName As String = ""
    Private iAddress1 As String = ""
    Private iAddress2 As String = ""
    Private iCity As String = ""
    Private iTIN As String = ""
    Private iPhone As String = ""
    Private iFooter As String = ""
    Private iFooter2 As String = ""
    Private iStr As String = ""
    Private Msg As String = ""
    Private tQty As Double = 0
    Private dAmt As Double = 0
    Private tAmt As Double = 0
    Private nAmt As Double = 0
    Private gAmt As Double = 0 'GST Tax Value
    Private gAmt2 As Double = 0

#End Region

#Region "C O M M O N  F U N C T I O N"

    Private Function SetPrinterName(ByVal PrinterName As String, ByVal AppPath As String) As Boolean

        SetPrinterName = True

        Dim prnPrinter As Printer
        For Each prnPrinter In Printers
            If prnPrinter.DeviceName = PrinterName Then
                POSPrn = prnPrinter
                Exit For
            End If
        Next

        If POSPrn Is Nothing Then
            MsgBox("Please check your printer turned on..!", MsgBoxStyle.Critical)
            SetPrinterName = False
            Exit Function
        End If

        POSPrn.DocumentName = "ERP System"
        POSPrn.PrintAction = Printing.PrintAction.PrintToPrinter

        InitializeShopHeader()

    End Function

    Private Sub InitializeShopHeader()

        SQL = "select alias,address1,address2,city,vat,phone from shops where shopid=" & ShopID & ";" _
            & "select param_value from settings where param_name='BillFooter';" _
            & "select param_value from settings where param_name='BillFooter2'"

        With ESSA.OpenReader(SQL)
            If .Read Then
                iShopName = .GetString(0).Trim
                iAddress1 = .GetString(1).Trim
                iAddress2 = .GetString(2).Trim
                iCity = .GetString(3).Trim
                iTIN = .GetString(4).Trim
                iPhone = .GetString(5).Trim
            End If
            .NextResult()
            If .Read Then
                iFooter = .GetString(0).Trim
            End If
            .NextResult()
            If .Read Then
                iFooter2 = .GetString(0).Trim
            End If
            .Close()
        End With

    End Sub

    Public Function ConnectToPrinter() As Boolean

        ConnectToPrinter = SetPrinterName(PrinterName, My.Application.Info.DirectoryPath)

    End Function

    Private Sub DrawLine()

        POSPrn.DrawWidth = 2
        POSPrn.Line(POSPrn.Width, POSPrn.CurrentY)

    End Sub

    Private Sub SetPOSFont(ByVal Size As Single, Optional ByVal Name As String = "Consolas", Optional ByVal ISBold As Boolean = False)

        POSPrn.FontName = Name
        POSPrn.FontSize = Size
        POSPrn.FontBold = ISBold

    End Sub

    Private Sub PrintText(ByVal iText As String, ByVal ISCenterAlign As Boolean)

        If ISCenterAlign = True Then
            POSPrn.CurrentX = (POSPrn.Width - POSPrn.TextWidth(iText)) / 2
        End If

        POSPrn.Print(iText)

    End Sub

#End Region

#Region "P R I N T  F O R M A T - A"

    Public Sub PrintBill(ByVal iBillID As Integer, ByVal BillHeader As String)

        PrintHeader(iBillID, BillHeader)
        PrintDetails(iBillID)
        PrintFooters()
        PrintPayments(iBillID)
        'PrintExchange(iBillID)
        POSPrn.EndDoc()

    End Sub

    Private Sub PrintHeader(ByVal iBillID As Integer, ByVal CopyStatus As String)

        SetPOSFont(13, , True)
        PrintText(iShopName, True)
        SetPOSFont(10, , False)
        PrintText(iAddress1, True)
        If iAddress2.Trim.Length > 0 Then
            PrintText(iAddress2, True)
        End If
        PrintText(iCity, True)

        If iPhone.Trim.Length > 0 Then
            PrintText("PH:" + iPhone, True)
        End If

        If iTIN.Trim.Length > 0 Then
            PrintText("GST:" + iTIN, True)
        End If

        SQL = "select m.billno,m.billtime,m.termid,u.username,m.refno from billmaster m,users u where " _
            & "m.userid=u.userid and m.billid=" & iBillID & " and m.shopid=" & ShopID

        With ESSA.OpenReader(SQL)
            If .Read Then

                PrintText(CopyStatus, True)
                POSPrn.Write(Space(1) & "Bill No :  ")
                SetPOSFont(12, , True)
                Msg = .Item(2) & "/" & .Item(0) & Space(10 - Msg.Length)
                POSPrn.Write(Msg)

                SetPOSFont(10, , False)
                POSPrn.Print(Space(6) & "Bill Time : " & Format(.GetDateTime(1), "g"))
                If Not .Item(4) = "" Then
                    POSPrn.Print(Space(1) + "ORef No :" & .GetString(4))
                End If

            End If
            .Close()
        End With

        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")
        SetPOSFont(10, , True)
        POSPrn.Print(" Sno  Particulars  Qty    Rate  Dis%   D.Amt   Amount")
        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")

    End Sub

    Private Function CalculatedGST(A As Double, B As Double) As Double

        Dim C As Double = 0
        Dim D As Double = 0
        Dim F As Double = 0
        Dim G As Double = 0

        C = A - ((A / 100) * B)
        D = ((C / 100) * B)
        F = C + D
        G = A - F
        CalculatedGST = C + G

    End Function

    Private Sub PrintDetails(ByVal iBillID As Integer)

        SetPOSFont(9, "Consolas", False)

        SQL = "select d.sno,p.plucode,d.qty,d.orate,d.disperc,d.disamt,d.amount,(d.qty*d.orate) stot from billdetails d,productmaster p " _
            & "where p.pluid=d.pluid and d.billid=" & iBillID & " and d.shopid=" & ShopID & " order by sno"

        tQty = 0
        tAmt = 0
        dAmt = 0
        nAmt = 0

        With ESSA.OpenReader(SQL)

            While .Read

                tQty += IIf(.Item(2) > 0, .Item(2), 0)
                nAmt += .Item(6)
                tAmt += .Item(7)
                dAmt += .Item(5)
                Msg = .Item(0)
                iStr = Space(1) & .Item(0) & Space(5 - Msg.Length)
                Msg = Space(11 - Mid(.GetString(1), 1, 10).Trim.Length)
                iStr &= Mid(.GetString(1), 1, 10).Trim + Msg
                Msg = .Item(2)
                iStr &= Space(7 - Msg.Length) & Msg
                Msg = Format(.Item(3), "0.00")
                iStr &= Space(9 - Msg.Length) & Msg
                Msg = Format(.Item(4), "0.0")
                iStr &= Space(7 - Msg.Length) & Msg
                Msg = Format(.Item(5), "0.00")
                iStr &= Space(9 - Msg.Length) & Msg
                Msg = Format(.Item(6), "0.00")
                iStr &= Space(10 - Msg.Length) & Msg
                POSPrn.Print(iStr)

            End While
            .Close()

        End With

        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")

    End Sub

    Private Sub PrintFooters()

        If dAmt > 0 Then

            iStr = " SubTotal"
            Msg = Format(tAmt, "0.00")
            iStr &= Space(50 - Msg.Length) & Msg
            POSPrn.Print(iStr)

            iStr = " Discount"
            Msg = Format(dAmt, "0.00")
            iStr &= Space(50 - Msg.Length) & Msg
            POSPrn.Print(iStr)

            Dim Roff As Double = Math.Round(nAmt) - nAmt
            If Roff <> 0 Then
                iStr = " Round Off"
                Msg = Format(Roff, "0.00")
                iStr &= Space(49 - Msg.Length) & Msg
                POSPrn.Print(iStr)
            End If

            POSPrn.Print("")
            DrawLine()
            POSPrn.Print("")

        End If

        'GST Calculation
        POSPrn.Print("")
        SetPOSFont(9, "Consolas", True)
        POSPrn.Print("HSN : 6108")

        gAmt = CalculatedGST(nAmt, 5)
        gAmt2 = ((gAmt / 100) * 2.5)

        iStr = "Sale :" & Format(gAmt, "0.00")
        POSPrn.Print(iStr)
        iStr = "Tax : CGST 2.50% : " & Format(gAmt2, "0.00")
        POSPrn.Print(iStr)
        iStr = "Tax : SGST 2.50% : " & Format(gAmt2, "0.00")
        POSPrn.Print(iStr)
        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")

        SetPOSFont(13, "Consolas", True)

        iStr = " TOTAL"
        Msg = tQty
        iStr &= Space(11 - Msg.Length) & Msg

        nAmt += Math.Round(nAmt) - nAmt
        Msg = Format(nAmt, "0.00")
        iStr &= Space(24 - Msg.Length) & Msg

        POSPrn.Print(iStr)
        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")

    End Sub

    Private Sub PrintPayments(ByVal iBillID As Integer)

        SetPOSFont(9)

        SQL = "select paymentdesc,refno,paid,refund from billpayments where billid=" & iBillID & " and shopid=" & ShopID & " order by sno"
        With ESSA.OpenReader(SQL)
            If .HasRows Then

                While .Read

                    If .GetString(0).Trim = "CASH" Then
                        iStr = Space(1) & .GetString(0)
                    Else
                        Msg = Space(1) & .GetString(0) & "/" & .GetString(1)
                        iStr = .GetString(0) & "/" & .GetString(1) + Space(20 - Msg.Length)
                    End If

                    If .Item(0) = "CASH" Then

                        If .Item(2) > 0 Then
                            iStr &= Space(19) + "Customer Payment"
                            Msg = Format(.Item(2), "0.00")
                            iStr &= Space(19 - Msg.Length) + Msg
                            POSPrn.Print(iStr)
                        ElseIf .Item(2) < 0 Then
                            iStr &= Space(19) + "Refund          "
                            Msg = Format(-.Item(2), "0.00")
                            iStr &= Space(19 - Msg.Length) + Msg
                            POSPrn.Print(iStr)
                        End If

                        If .Item(3) < 0 Then
                            iStr = Space(24) + "Refund"
                            Msg = Format(-.Item(3), "0.00")
                            iStr &= Space(29 - Msg.Length) + Msg
                            POSPrn.Print(iStr)
                        ElseIf .Item(3) > 0 Then
                            iStr = Space(24) + "Change"
                            Msg = Format(.Item(3), "0.00")
                            iStr &= Space(29 - Msg.Length) + Msg
                            POSPrn.Print(iStr)
                        End If

                    Else
                        Msg = Format(.Item(2), "0.00")
                        iStr &= Space(40 - Msg.Length) + Msg
                        POSPrn.Print(iStr)
                    End If

                End While
            End If
            .Close()
        End With

        iStr = " E.& O.E"
        POSPrn.Write(iStr)
        PrintText(iFooter, True)
        PrintText(iFooter2, True)

    End Sub

    Private Sub PrintExchange(ByVal iBillID As Integer)

        Dim Sno As SByte = 1

        POSPrn.Print("")
        POSPrn.Print(" Exchange Product Details")
        POSPrn.Print(" -----------------------------")

        SQL = "select p.plucode,d.qty,d.rate,d.amount from productmaster p,billdetails d where " _
            & "p.pluid=d.pluid and d.obillid=" & iBillID & " order by d.sno"

        With ESSA.OpenReader(SQL)

            While .Read

                POSPrn.Write(Space(1) & Sno)
                POSPrn.Write(Space(2) & .GetString(0).Trim)
                Msg = Space(15 - .GetString(0).Trim.Length)
                POSPrn.Print(Space(15 - Msg.Length) & .Item(2))
                Sno += 1

            End While

            .Close()

        End With

    End Sub

#End Region

#Region "P R I N T  F O R M A T - B"

    Private Sub PrintHeader46(ByVal iBillID As Integer, ByVal CopyStatus As String)

        SetPOSFont(13, , True)
        PrintText(iShopName, True)
        SetPOSFont(10, , False)
        PrintText(iAddress1, True)
        If iAddress2.Trim.Length > 0 Then
            PrintText(iAddress2, True)
        End If
        PrintText(iCity, True)

        If iPhone.Trim.Length > 0 Then
            PrintText("PH:" + iPhone, True)
        End If

        If iTIN.Trim.Length > 0 Then
            PrintText("TIN:" + iTIN, True)
        End If

        SQL = "select m.billno,m.billtime,m.termid,u.username,m.refno from billmaster m,users u where " _
            & "m.userid=u.userid and m.billid=" & iBillID

        With ESSA.OpenReader(SQL)
            If .Read Then

                PrintText(CopyStatus, True)
                POSPrn.Write("Bill No   :  ")
                SetPOSFont(12, , True)
                Msg = .Item(2) & "/" & .Item(0) & Space(10 - Msg.Length)
                POSPrn.Print(Msg)

                SetPOSFont(10, , False)
                POSPrn.Print("Bill Time :" & Format(.GetDateTime(1), "g"))
                If Not .Item(4) = "" Then
                    POSPrn.Print(Space(1) + "ORef No :" & .GetString(4))
                End If

            End If
            .Close()
        End With

        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")
        SetPOSFont(9.5, , True)
        POSPrn.Print("Particulars   Qty   Rate    Amount")
        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")

    End Sub

    Private Sub PrintDetails46(ByVal iBillID As Integer)

        SetPOSFont(9, , False)

        SQL = "select p.pluname,d.qty,d.orate,(d.qty*d.orate) stot,d.amount,d.disamt from billdetails d,productmaster p " _
            & "where p.pluid=d.pluid and d.billid=" & iBillID & " order by sno"

        tQty = 0
        tAmt = 0
        dAmt = 0
        nAmt = 0

        With ESSA.OpenReader(SQL)
            While .Read

                tQty += IIf(.Item(1) > 0, .Item(1), 0)
                tAmt += .Item(3)
                nAmt += .Item(4)
                dAmt += .Item(5)
                Msg = Space(10 - Mid(.GetString(0), 1, 10).Trim.Length)
                iStr = Mid(.GetString(0), 1, 10).Trim + Msg
                Msg = .Item(1)
                iStr &= Space(8 - Msg.Length) & Msg
                Msg = Format(.Item(2), "0.00")
                iStr &= Space(8 - Msg.Length) & Msg
                Msg = Format(.Item(4), "0.00")
                iStr &= Space(9 - Msg.Length) & Msg
                POSPrn.Print(iStr)

            End While
            .Close()
        End With

        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")

    End Sub

    Private Sub PrintFooters46()

        If dAmt > 0 Then

            iStr = "SubTotal"
            Msg = Format(tAmt, "0.00")
            iStr &= Space(27 - Msg.Length) & Msg
            POSPrn.Print(iStr)

            iStr = "Discount"
            Msg = Format(dAmt, "0.00")
            iStr &= Space(27 - Msg.Length) & Msg
            POSPrn.Print(iStr)

            Dim Roff As Double = Math.Round(nAmt) - nAmt
            If Roff <> 0 Then
                iStr = "Round Off"
                Msg = Format(Roff, "0.00")
                iStr &= Space(26 - Msg.Length) & Msg
                POSPrn.Print(iStr)
            End If

            POSPrn.Print("")
            DrawLine()
            POSPrn.Print("")

        End If

        SetPOSFont(13, "Consolas", True)

        iStr = "TOTAL"

        Msg = tQty
        iStr &= Space(8 - Msg.Length) & Msg

        nAmt += Math.Round(nAmt) - nAmt
        Msg = Format(nAmt, "0.00")
        iStr &= Space(11 - Msg.Length) & Msg

        POSPrn.Print(iStr)
        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")

    End Sub

    Public Sub PrintBill46(ByVal iBillID As Integer, ByVal BillHeader As String)

        PrintHeader46(iBillID, BillHeader)
        PrintDetails46(iBillID)
        PrintFooters46()
        PrintPayments46(iBillID)
        POSPrn.EndDoc()

    End Sub

    Private Sub PrintPayments46(ByVal iBillID As Integer)

        SetPOSFont(9, "Consolas", False)

        SQL = "select paymentdesc,refno,paid,refund from billpayments where billid=" & iBillID & " order by sno"
        With ESSA.OpenReader(SQL)
            If .HasRows Then

                While .Read

                    If .GetString(0).Trim = "CASH" Then
                        iStr = .GetString(0)
                    Else
                        Msg = .GetString(0) & "/" & .GetString(1)
                        iStr = .GetString(0) & "/" & .GetString(1) + Space(20 - Msg.Length)
                    End If

                    If .Item(0) = "CASH" Then

                        If .Item(2) > 0 Then
                            iStr &= Space(10) + "Tender"
                            Msg = Format(.Item(2), "0.00")
                            iStr &= Space(15 - Msg.Length) + Msg
                            POSPrn.Print(iStr)
                        End If

                        If .Item(3) < 0 Then
                            iStr = Space(14) + "Refund"
                            Msg = Format(-.Item(3), "0.00")
                            iStr &= Space(15 - Msg.Length) + Msg
                            POSPrn.Print(iStr)
                        ElseIf .Item(3) > 0 Then
                            iStr = Space(14) + "Change"
                            Msg = Format(.Item(3), "0.00")
                            iStr &= Space(15 - Msg.Length) + Msg
                            POSPrn.Print(iStr)
                        End If

                    Else
                        Msg = Format(.Item(2), "0.00")
                        iStr &= Space(15 - Msg.Length) + Msg
                        POSPrn.Print(iStr)
                    End If

                End While
            End If
            .Close()
        End With

        iStr = "E.& O.E"
        POSPrn.Write(iStr)
        PrintText(iFooter, True)
        PrintText(iFooter2, True)

    End Sub

#End Region

#Region "P R I N T  F O R M A T - HOLD (A)"

    Public Sub PrintHoldBill(ByVal iBillID As Integer, ByVal BillHeader As String)

        PrintHOLDHeader(iBillID, BillHeader)
        PrintHOLDDetails(iBillID)
        PrintHoldFooters()
        POSPrn.EndDoc()

    End Sub

    Private Sub PrintHOLDHeader(ByVal iBillID As Integer, ByVal CopyStatus As String)

        SetPOSFont(13, , True)
        PrintText(iShopName, True)
        SetPOSFont(10, , False)
        PrintText(iAddress1, True)
        If iAddress2.Trim.Length > 0 Then
            PrintText(iAddress2, True)
        End If
        PrintText(iCity, True)

        If iPhone.Trim.Length > 0 Then
            PrintText("PH:" + iPhone, True)
        End If

        If iTIN.Trim.Length > 0 Then
            PrintText("TIN:" + iTIN, True)
        End If

        SQL = "select distinct billid,billdt,termid from billdetailshold where billid=" & iBillID

        'SQL = "select m.billno,m.billtime,m.termid,u.username,m.refno from billmaster m,users u where " _
        '    & "m.userid=u.userid and m.billid=" & iBillID & " and m.shopid=" & ShopID

        With ESSA.OpenReader(SQL)
            If .Read Then

                PrintText(CopyStatus, True)
                POSPrn.Write(Space(1) & "Est No :   ")
                SetPOSFont(12, , True)
                Msg = .Item(2) & "/" & .Item(0) & Space(10 - Msg.Length)
                POSPrn.Write(Msg)

                SetPOSFont(10, , False)
                POSPrn.Print(Space(6) & "Est Time :  " & Format(.GetDateTime(1), "g"))

            End If
            .Close()
        End With

        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")
        SetPOSFont(10, , True)
        POSPrn.Print(" Sno  Particulars  Qty    Rate  Dis%   D.Amt   Amount")
        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")

    End Sub

    Private Sub PrintHOLDDetails(ByVal iBillID As Integer)

        SetPOSFont(9, "Consolas", False)

        SQL = "select d.sno,p.plucode,d.qty,d.orate,d.disperc,d.disamt,d.amount,(d.qty*d.orate) stot from billdetailshold d,productmaster p " _
            & "where p.pluid=d.pluid and d.billid=" & iBillID & " order by sno"

        tQty = 0
        tAmt = 0
        dAmt = 0
        nAmt = 0

        With ESSA.OpenReader(SQL)
            While .Read

                tQty += IIf(.Item(2) > 0, .Item(2), 0)
                nAmt += .Item(6)
                tAmt += .Item(7)
                dAmt += .Item(5)
                Msg = .Item(0)
                iStr = Space(1) & .Item(0) & Space(5 - Msg.Length)
                Msg = Space(11 - Mid(.GetString(1), 1, 10).Trim.Length)
                iStr &= Mid(.GetString(1), 1, 10).Trim + Msg
                Msg = .Item(2)
                iStr &= Space(7 - Msg.Length) & Msg
                Msg = Format(.Item(3), "0.00")
                iStr &= Space(9 - Msg.Length) & Msg
                Msg = Format(.Item(4), "0.0")
                iStr &= Space(7 - Msg.Length) & Msg
                Msg = Format(.Item(5), "0.00")
                iStr &= Space(9 - Msg.Length) & Msg
                Msg = Format(.Item(6), "0.00")
                iStr &= Space(10 - Msg.Length) & Msg
                POSPrn.Print(iStr)

            End While
            .Close()
        End With

        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")

    End Sub

    Private Sub PrintHoldFooters()

        SetPOSFont(13, "Consolas", True)

        iStr = " TOTAL"
        Msg = tQty
        iStr &= Space(11 - Msg.Length) & Msg

        nAmt += Math.Round(nAmt) - nAmt
        Msg = Format(nAmt, "0.00")
        iStr &= Space(24 - Msg.Length) & Msg

        POSPrn.Print(iStr)
        POSPrn.Print("")
        DrawLine()
        POSPrn.Print("")

    End Sub

#End Region

End Class
