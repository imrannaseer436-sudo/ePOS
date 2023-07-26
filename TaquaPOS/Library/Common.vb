'****************************************** Bismillah *******************************************
Imports System.Data.SqlClient
Module Common

    Public ISAdmin As Boolean = False
    Public SQL As String
    Public Con As SqlConnection
    Public ConStr As String = "Data Source=192.168.0.100;user id=sa;password=sa#999s%5;initial catalog=eWarehouse1213"
    Public UserID As SByte = 0
    Public BusinessDate As Date
    Public UserNm As String = ""
    Public ShopID As SByte = 0
    Public ShopCd As String = ""
    Public ShopNm As String = ""
    Public TermID As SByte = 0
    Public PrinterName As String = ""
    Public NetworkPrinterAddress As String = ""
    Public DosModePrinter As Boolean = False
    Public BillFormat As String = ""
    Public Copies As SByte = 1
    Public ISRichTextPrinter As Boolean = False
    Public EnableDiscountLimit As Boolean = False
    Public HideTerminal As Boolean = False
    Public EnableRemarks As Boolean = False
    Public DiscountLimit As Double = 0
    Public iDiscountLimit As Double = 0
    Public VersionPath As String = ""
    Public Pwd As String = ""
    Public SDate As Date
    Public EDate As Date
    Public ISTrailMode As Boolean = False
    Public EnableBatchMode As Boolean = False
    Public AllowSalesCommission As Boolean = False
    Public FloorList As String = ""
    Public DirectPrint As Boolean = False
    Public NewPrintCopies As Short = 1
    Public NewRePrintCopies As Short = 1
    Public NewPrinterName As String = ""
    Public NewBusinessDate As Date
    Public NewPaymentMode As Boolean = True

End Module
