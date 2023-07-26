'********************************************* Bismillah ***********************************
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Public Class iPOSPrinter

    Private Prn As New Printer
    Private iShopName As String
    Private iAddress1 As String
    Private iAddress2 As String
    Private iCity As String
    Private iTIN As String
    Private iPhone As String
    Private BillFooter As String
    Private tQty As Double = 0
    Private tAmt As Double = 0
    Private Msg As String

    Public Enum TextAlign As Byte

        Left = 0

        Center = 1

        Right = 2

    End Enum

    Public Sub InitializeShopHeader()

        SQL = "select alias,address1,address2,city,vat,phone from shops where shopid=" & ShopID & ";" _
            & "select param_value from settings where param_name='BillFooter'"
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
                BillFooter = .GetString(0).Trim
            End If
            .Close()
        End With

        SetPrinterName("TVS Electronics RP 4150", My.Application.Info.DirectoryPath)
        Prn.FontName = "Tahoma"

    End Sub

    Private Sub PrintBillStatus(ByVal iText)

        SetTextFont(9.0F, True)
        WriteLine(iText, TextAlign.Center)

    End Sub

    Private Sub PrintHeader(ByVal nBillID As Integer, ByVal CopyStatus As String)

        SQL = "select m.billno,m.billtime,m.termid,u.username from billmaster m,users u where " _
            & "m.userid=u.userid and m.billid=" & nBillID

        With ESSA.OpenReader(SQL)
            If .Read Then

                SetTextFont(11.0F, True)
                WriteLine(iShopName, TextAlign.Center)
                SetTextFont(9.0F, True)
                WriteLine(iAddress1, TextAlign.Center)
                If iAddress2.Trim.Length > 0 Then WriteLine(iAddress2, TextAlign.Center)
                WriteLine(iCity, TextAlign.Center)
                WriteLine("TIN : " & iTIN, TextAlign.Center)
                If iPhone.Trim.Length > 0 Then WriteLine("PH:" & iPhone, TextAlign.Center)
                SetTextFont(9.0F, True)
                WriteLine(CopyStatus, TextAlign.Center)
                WriteLine("", TextAlign.Left)
                Prn.Write("Bill No :")
                SetTextFont(12.0F, True)
                Prn.Write(.Item(2) & "/" & .Item(0))
                SetTextFont(9.0F, True)
                Prn.CurrentX = 3200
                Prn.Print("Bill Time:" & Format(.GetDateTime(1), "dd-MM-yyyy hh:mm"))

            End If
            .Close()
        End With

        SetTextFont(9.0F, True)
        Prn.Print("")
        DrawLine()
        Prn.Print("")
        GotoCol(0)
        Prn.Write("Sno")
        GotoCol(4)
        Prn.Write("Particulars")
        GotoCol(18)
        Prn.Write("Qty")
        GotoCol(23)
        Prn.Write("Rate")
        GotoCol(30)
        Prn.Write("Discount")
        GotoCol(38)
        Prn.Print("Amount")
        Prn.Print("")
        DrawLine()

    End Sub

    Private Sub PrintDetails(ByVal nBillID As Integer)

        Prn.Print("")
        SetTextFont(9.0F, False)
        SQL = "select d.sno,p.pluname,d.qty,d.orate,d.disperc,d.disamt,d.amount from billdetails d,productmaster p " _
            & "where p.pluid=d.pluid and d.billid=" & nBillID & " order by sno"

        With ESSA.OpenReader(SQL)
            While .Read

                If .Item(2) > 0 Then
                    tQty += .Item(2)
                End If
                tAmt += .Item(6)

                GotoCol(0)
                Prn.Write(.Item(0))

                Msg = Mid(.GetString(1).Trim, 1, 13)
                GotoCol(4)
                Prn.Write(Msg)

                Msg = .Item(2)
                If .Item(2) < 0 Then
                    GotoCol(21 - Msg.Length)
                Else
                    GotoCol(20 - Msg.Length)
                End If

                Prn.Write(.Item(2))

                Msg = Format(.Item(3), "0.00")
                GotoCol(28 - Msg.Length)
                Prn.Write(Msg)

                If .Item(4) > 0 Then
                    Msg = Format(.Item(4), "0") & "%" & Format(.Item(5), "0.00")
                Else
                    Msg = Format(.Item(5), "0.00")
                End If

                GotoCol(37 - Msg.Length)
                Prn.Write(Msg)

                Msg = Format(.Item(6), "0.00")
                If .Item(6) < 0 Then
                    GotoCol(46 - Msg.Length)
                Else
                    GotoCol(45 - Msg.Length)
                End If

                Prn.Print(Msg)

            End While
            .Close()
        End With

        Prn.Print("")

    End Sub

    Private Sub PrintPayments(ByVal nBillID As Integer)

        SQL = "select paymentdesc,refno,paid,refund from billpayments where billid=" & nBillID & " order by sno"
        With ESSA.OpenReader(SQL)
            If .HasRows Then

                SetTextFont(10.0F, False)
                Prn.Print("")
                While .Read
                    GotoCol(2)
                    Prn.Write(.GetString(0) & "/" & .GetString(1))
                    If .Item(0) = "CASH" Then
                        If .Item(2) > 0 Then
                            GotoCol(25)
                            Prn.Write("Tendered")
                            Msg = Format(.Item(2), "0.00")
                            GotoCol(36)
                            Prn.Print(Msg)
                        End If

                        If .Item(3) <> 0 Then
                            GotoCol(25)
                            Prn.Write("Refund")
                            Msg = Format(.Item(3), "0.00")
                            GotoCol(36)
                            Prn.Print(Msg)
                        End If
                    End If
                End While
            End If
            .Close()
        End With

        Prn.Print("")
        SetTextFont(9.0F, False)
        GotoCol(1)
        Prn.Write("E.& O.E")
        WriteLine(BillFooter, TextAlign.Center)

    End Sub

    Private Sub PrintFooters()

        SetTextFont(14.0F, True)
        DrawLine()
        Prn.Print("")

        GotoCol(2)
        Prn.Write("TOTAL")

        Msg = Format(tQty, "0")
        GotoCol(20 - Msg.Length)
        Prn.Write(Msg)

        Msg = Format(tAmt, "0.00")
        GotoCol(42 - Msg.Length)
        Prn.Print(Msg)

        Prn.Print("")
        DrawLine()

    End Sub

    Private Sub GotoCol(Optional ByVal ColNumber As Integer = 0)

        Dim ColWidth As Single = Prn.Width / 48
        Prn.CurrentX = ColWidth * ColNumber

    End Sub

    Public Sub PrintInvoice(ByVal nBillID As Integer, ByVal CopyStatus As String)

        tQty = 0
        tAmt = 0
        PrintHeader(nBillID, CopyStatus)
        PrintDetails(nBillID)
        PrintFooters()
        PrintPayments(nBillID)
        Prn.EndDoc()

    End Sub

    Private Sub SetTextFont(ByVal Size As Single, Optional ByVal ISBold As Boolean = False)

        Prn.FontSize = Size
        Prn.FontBold = ISBold

    End Sub

    Private Sub WriteLine(ByVal iText As String, ByVal Align As TextAlign)

        If Align = TextAlign.Left Then
            Prn.CurrentX = 0
        ElseIf Align = TextAlign.Center Then
            Prn.CurrentX = (Prn.Width - Prn.TextWidth(iText)) / 2
        ElseIf Align = TextAlign.Right Then
            Prn.CurrentX = (Prn.Width - Prn.TextWidth(iText)) + 25
        End If

        Prn.Print(iText)

    End Sub

    Private Sub DrawLine()

        Prn.DrawWidth = 2
        Prn.Line(Prn.Width, Prn.CurrentY)

    End Sub

    Private Sub AlighCenter(ByVal iText As String)

        Prn.CurrentX = (Prn.Width - Prn.TextWidth(iText)) / 2

    End Sub

    Private Sub SetFont(ByVal Size As Single)

        Prn.FontSize = Size

    End Sub

    Private Sub SetPrinterName(ByVal PrinterName As String, ByVal AppPath As String)

        Dim prnPrinter As Printer
        For Each prnPrinter In Printers
            If prnPrinter.DeviceName = PrinterName Then
                Prn = prnPrinter
                Exit For
            End If
        Next

        Prn.DocumentName = "ERP System"
        Prn.PrintAction = Printing.PrintAction.PrintToPrinter

    End Sub

End Class
