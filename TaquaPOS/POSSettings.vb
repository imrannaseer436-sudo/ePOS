'*************************************** Bismillah **********************************************
Imports System.Xml
Imports System.Data.SqlClient
Public Class POSSettings

    Private Sub ApplyTheme()

        pnlMain.BackColor = PanelBorderColor
        UpdateButtonTheme(btnUpdate)

    End Sub

    Private Function GetFloorList() As String

        GetFloorList = ""

        For i As SByte = 0 To TGFS.Rows.Count - 1

            If TGFS.Item(0, i).Value = 1 Then

                GetFloorList &= Trim(TGFS.Item(1, i).Value) & ","

            End If

        Next

        If GetFloorList.Length > 0 Then
            GetFloorList = Mid(GetFloorList, 1, GetFloorList.Length - 1)
        End If

    End Function

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Dim nFloorList As String = ""

        If chkSalesComm.Checked Then

            nFloorList = GetFloorList()

            If nFloorList = "" Then
                MsgBox("Unable to save, You must select atlease one floor in the list..!", MsgBoxStyle.Critical)
                Exit Sub
            End If

        End If

        Dim ConnectionString As String = "Data Source=" & txtSqlserver.Text.Trim & ";" _
                                       & "Initial Catalog=" & txtDatabase.Text.Trim & ";" _
                                       & "User ID=" & txtUsername.Text.Trim & ";" _
                                       & "Password=" & txtPassword.Text & ";"

        Dim XTag As String = "<POSSettings>" & vbCrLf _
                           & "<DBSettings>" & ClsEncodeDecode.Encode(ConnectionString) & "</DBSettings>" & vbCrLf _
                           & "<ShopCode>" & txtShopCode.Text.Trim & "</ShopCode>" & vbCrLf _
                           & "<TermID>" & txtTermID.Text.Trim & "</TermID>" & vbCrLf _
                           & "<VersionPath>" & txtVersionPath.Text.Trim & "</VersionPath>" & vbCrLf _
                           & "<SQLSERVER>" & txtSqlserver.Text.Trim & "</SQLSERVER>" & vbCrLf _
                           & "<USERID>" & txtUsername.Text.Trim & "</USERID>" & vbCrLf _
                           & "<PASSWORD>" & ClsEncodeDecode.Encode(txtPassword.Text) & "</PASSWORD>" & vbCrLf _
                           & "<DATABASE>" & txtDatabase.Text.Trim & "</DATABASE>" & vbCrLf _
                           & "<PRINTER>" & txtPrinter.Text.Trim & "</PRINTER>" & vbCrLf _
                           & "<RICHTEXTPRINTER>" & IIf(chkRichTextPrinter.Checked = True, "1", "0") & "</RICHTEXTPRINTER>" & vbCrLf _
                           & "<ISTRAILMODE>" & IIf(chkITM.Checked = True, "1", "0") & "</ISTRAILMODE>" & vbCrLf _
                           & "<SALESCOMMISSION>" & IIf(chkSalesComm.Checked = True, "1", "0") & "</SALESCOMMISSION>" & vbCrLf _
                           & "<FLOORLIST>" & nFloorList.Trim & "</FLOORLIST>" & vbCrLf _
                           & "<DIRECTPRINT>" & IIf(chkDirectPrint.Checked = True, "1", "0") & "</DIRECTPRINT>" & vbCrLf _
                           & "</POSSettings>"

        Dim nCon As New SqlConnection(ConnectionString)
        Try
            nCon.Open()
            If nCon.State = ConnectionState.Open Then
                nCon.Close()
            End If
            nCon.Dispose()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            nCon.Dispose()
            Exit Sub
        End Try

        Dim xDoc As New XmlDocument
        xDoc.LoadXml(XTag)
        xDoc.Save(My.Application.Info.DirectoryPath & "\POSSettings.xml")
        MsgBox("Congratulations, Settings updated successfully..!", vbExclamation)

    End Sub

    Private Sub POSSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ApplyTheme()

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\POSSettings.xml") = True Then

            Dim xDoc As XmlReader = XmlReader.Create(My.Application.Info.DirectoryPath & "\POSSettings.xml")
            While xDoc.Read
                If xDoc.Name = "SQLSERVER" Then
                    txtSqlserver.Text = xDoc.ReadElementString("SQLSERVER")
                ElseIf xDoc.Name = "USERID" Then
                    txtUsername.Text = xDoc.ReadElementString("USERID")
                ElseIf xDoc.Name = "PASSWORD" Then
                    txtPassword.Text = ClsEncodeDecode.DCode(xDoc.ReadElementString("PASSWORD"))
                ElseIf xDoc.Name = "DATABASE" Then
                    txtDatabase.Text = xDoc.ReadElementString("DATABASE")
                ElseIf xDoc.Name = "VersionPath" Then
                    txtVersionPath.Text = xDoc.ReadElementString("VersionPath")
                ElseIf xDoc.Name = "ShopCode" Then
                    txtShopCode.Text = xDoc.ReadElementString("ShopCode")
                ElseIf xDoc.Name = "TermID" Then
                    txtTermID.Text = xDoc.ReadElementString("TermID")
                ElseIf xDoc.Name = "PRINTER" Then
                    txtPrinter.Text = xDoc.ReadElementString("PRINTER")
                ElseIf xDoc.Name = "RICHTEXTPRINTER" Then
                    chkRichTextPrinter.Checked = IIf(xDoc.ReadElementString("RICHTEXTPRINTER").Trim = "1", True, False)
                ElseIf xDoc.Name = "ISTRAILMODE" Then
                    chkITM.Checked = True
                ElseIf xDoc.Name = "SALESCOMMISSION" Then
                    chkSalesComm.Checked = IIf(xDoc.ReadElementString("SALESCOMMISSION").Trim = "1", True, False)
                ElseIf xDoc.Name = "FLOORLIST" Then
                    FloorList = xDoc.ReadElementString("FLOORLIST")
                ElseIf xDoc.Name = "DIRECTPRINT" Then
                    chkDirectPrint.Checked = IIf(xDoc.ReadElementString("DIRECTPRINT").Trim = "1", True, False)
                End If
            End While
            xDoc.Close()

        End If

        TGFS.ColumnHeadersDefaultCellStyle.Font = New Font(TGFS.Font, FontStyle.Bold)
        ESSA.AlignHeader(TGFS, 1, DataGridViewContentAlignment.MiddleCenter)
        ESSA.AlignHeader(TGFS, 2, DataGridViewContentAlignment.MiddleCenter)

        'LoadFloorList()
        'SetFloorList()

    End Sub

    Private Sub SetFloorList()

        Dim str = FloorList.Split(",")

        For Each lst In str

            For i As SByte = 0 To TGFS.Rows.Count - 1

                If lst = Trim(TGFS.Item(1, i).Value) Then
                    TGFS.Item(0, i).Value = 1
                End If

            Next

        Next

    End Sub

    Private Sub LoadFloorList()

        SQL = "select distinct floor,count(*) nos from SalesPersons group by floor order by floor"
        With ESSA.OpenReader(SQL)
            TGFS.Rows.Clear()
            While .Read
                TGFS.Rows.Add()
                TGFS.Item(1, TGFS.Rows.Count - 1).Value = .GetString(0).Trim
                TGFS.Item(2, TGFS.Rows.Count - 1).Value = .Item(1)
            End While
            .Close()
        End With

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Close()

    End Sub

    Private Sub btnLoadFloorList_Click(sender As Object, e As EventArgs) Handles btnLoadFloorList.Click

        LoadFloorList()

    End Sub

    Private Sub chkDirectPrint_CheckedChanged(sender As Object, e As EventArgs) Handles chkDirectPrint.CheckedChanged

        'If chkDirectPrint.Checked Then
        '    MsgBox("Dear user, to work direct print properly" & vbCrLf & "1. You need to specify full printer name" & vbCrLf & "2. Right Click -> Properties -> Copy Printer Name")
        'End If

    End Sub

End Class