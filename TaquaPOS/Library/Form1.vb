Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ShopID = 3
        PrinterName = "TVS Electronics RP 4150"
        Dim POS As New iPOSPrinterRichText
        POS.ConnectToPrinter()
        POS.PrintBill(8597, "ORIGINAL")

    End Sub

End Class