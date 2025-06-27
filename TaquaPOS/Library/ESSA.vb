'*********************** In the name of Allah, Most Merciful, Most Compassionate ****************
Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Microsoft.VisualBasic.Compatibility
Public Class ESSA

    Public Shared Sub LoadDataGrid(ByVal DGV As DataGridView, ByVal Qry As String)

        Using nCon As New SqlConnection(ConStr)

            nCon.Open()

            Try
                Using Adp As New SqlDataAdapter(Qry, nCon)
                    Using Tbl As New DataTable
                        Adp.Fill(Tbl)
                        DGV.DataSource = Nothing
                        DGV.DataSource = Tbl
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

            nCon.Close()

        End Using

    End Sub

    Public Shared Sub AlignHeader(ByVal DGV As DataGridView, ByVal Col As SByte, ByVal Align As DataGridViewContentAlignment, Optional ByVal iWidth As Integer = 0)

        With DGV
            If iWidth > 0 Then
                .Columns(Col).Width = iWidth
            End If
            .Columns(Col).HeaderCell.Style.Alignment = Align
            .Columns(Col).DefaultCellStyle.Alignment = Align
            .Columns(Col).SortMode = DataGridViewColumnSortMode.NotSortable
        End With

    End Sub

    Public Shared Sub LoadStore(ByVal cmb As ComboBox, Optional ByVal Header As String = "")

        SQL = "select gdnid,gdnname from godown order by gdnname"
        ESSA.LoadCombo(cmb, SQL, "gdnname", "gdnid", Header)

    End Sub

    Public Shared Sub LoadVendors(ByVal cmb As ComboBox, Optional ByVal Header As String = "")

        SQL = "select vendorid,vendorname from vendors order by vendorname"
        ESSA.LoadCombo(cmb, SQL, "vendorname", "vendorid", Header)

    End Sub

    Public Shared Sub MoveNextCell(ByVal DGV As DataGridView, ByVal FirstCol As Integer, ByVal LastCol As Integer, ByVal Addrows As Boolean)

        If DGV.CurrentRow.Index = DGV.Rows.Count - 1 Then 'If it is last row 

            If DGV.CurrentCell.ColumnIndex = LastCol Then

                If Addrows = True Then
                    DGV.Rows.Add()
                    DGV.CurrentCell = DGV.Item(FirstCol, DGV.Rows.Count - 1)
                End If

            Else
                SendKeys.Send("{Tab}")
            End If

        Else

            If DGV.CurrentCell.ColumnIndex = LastCol Then
                DGV.CurrentCell = DGV.Item(FirstCol, DGV.CurrentRow.Index)
            Else
                SendKeys.Send("{Up}")
                SendKeys.Send("{Tab}")
            End If

        End If

    End Sub

    Public Shared Sub OpenConnection()

        Try
            Con = New SqlConnection(ConStr)
            Con.Open()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Public Shared Async Function OpenConnectionAsync() As Task

        Try
            Con = New SqlConnection(ConStr)
            Await Con.OpenAsync()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Function

    Public Shared Function FindGridIndex(ByVal DGV As DataGridView, ByVal FindCol As Byte, ByVal FindValue As String) As Integer

        FindGridIndex = -1
        For i As Integer = 0 To DGV.Rows.Count - 1
            If DGV.Item(FindCol, i).Value = FindValue Then
                FindGridIndex = i
                Exit For
            End If
        Next

    End Function

    Public Shared Function FindGridIndex(ByVal DGV As DataGridView, ByVal FindCol As SByte, ByVal FindValue As String, ByVal FindCol2 As SByte, ByVal FindValue2 As String) As Integer

        FindGridIndex = -1
        For i As Integer = 0 To DGV.Rows.Count - 1
            If DGV.Item(FindCol, i).Value = FindValue And DGV.Item(FindCol2, i).Value = FindValue2 Then
                FindGridIndex = i
                Exit For
            End If
        Next

    End Function

    Public Shared Sub FindAndSelect(ByVal DGV As DataGridView, ByVal FindCol As Integer, ByVal Findvalue As String)

        For i As Integer = 0 To DGV.Rows.Count - 1
            If Mid(DGV.Item(FindCol, i).Value, 1, Len(Findvalue)) = Findvalue Then
                DGV.CurrentCell = DGV.Item(DGV.FirstDisplayedCell.ColumnIndex, i)
                DGV.FirstDisplayedScrollingRowIndex = i
                Exit For
            End If
        Next

    End Sub

    Public Shared Function FindAndSelectReturnStatus(ByVal DGV As DataGridView, ByVal FindCol As Integer, ByVal Findvalue As String) As Boolean

        FindAndSelectReturnStatus = False

        For i As Integer = 0 To DGV.Rows.Count - 1
            If Mid(DGV.Item(FindCol, i).Value, 1, Len(Findvalue)) = Findvalue Then
                DGV.CurrentCell = DGV.Item(DGV.FirstDisplayedCell.ColumnIndex, i)
                DGV.FirstDisplayedScrollingRowIndex = i
                FindAndSelectReturnStatus = True
                Exit For
            End If
        Next

    End Function

    Public Shared Function OpenReader(ByVal Qry As String) As SqlDataReader

        OpenConnection()
        OpenReader = Nothing
        Try
            Using Cmd As New SqlCommand(Qry, Con)
                OpenReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            End Using
        Catch ex As SqlException
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Function

    Public Shared Function GenerateID(ByVal Qry As String) As Integer

        GenerateID = 1
        Try
            OpenConnection()
            Using Cmd As New SqlCommand(Qry, Con)
                Dim Tmp = Cmd.ExecuteScalar
                If IsDBNull(Tmp) = False Then
                    GenerateID = CInt(Tmp) + 1
                Else
                    GenerateID = 1
                End If
            End Using
            Con.Close()
        Catch ex As Exception
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Function

    Public Shared Sub ClearTextBox(ByVal BaseControl As Control)

        For Each ctl As Control In BaseControl.Controls
            If TypeOf ctl Is TextBox Then
                CType(ctl, TextBox).Clear()
            End If
        Next

    End Sub

    Public Shared Sub ClearTextBox(ByVal BaseControl As Control, ByVal ExcludeTag As String)

        For Each ctl As Control In BaseControl.Controls
            If ctl.Tag <> ExcludeTag Then
                If TypeOf ctl Is TextBox Then
                    CType(ctl, TextBox).Clear()
                End If
            End If
        Next

    End Sub

    Public Shared Function ISFound(ByVal Qry As String) As Boolean
        ISFound = False
        Try

            OpenConnection()
            Using Cmd As New SqlCommand(Qry, Con)
                Dim Tmp = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If Tmp.HasRows Then
                    ISFound = True
                End If
                Tmp.Close()
            End Using

        Catch ex As SqlException
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    Public Shared Function Execute(ByVal Qry As String) As Integer

        Execute = 0

        Try
            Using nCon As New SqlConnection(ConStr)
                nCon.Open()
                Using Cmd As New SqlCommand(Qry, nCon)
                    Execute = Cmd.ExecuteNonQuery
                End Using
                nCon.Close()
            End Using
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Function

    Public Shared Function GetData(ByVal Qry As String) As Double

        GetData = 0

        Using nCon As New SqlConnection(ConStr)
            Try
                nCon.Open()
                Using Cmd As New SqlCommand(Qry, nCon)
                    Dim Tmp = Cmd.ExecuteScalar
                    If IsDBNull(Tmp) = False Then
                        GetData = CType(Tmp, Double)
                    End If
                End Using
                nCon.Close()
            Catch ex As SqlException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End Using

    End Function

    'Public Shared Function GetData(ByVal Qry As String) As Double

    '    GetData = 0
    '    OpenConnection()
    '    Dim Cmd As New SqlCommand(Qry, Con)
    '    Dim Tmp = Cmd.ExecuteScalar
    '    If IsDBNull(Tmp) = False Then
    '        GetData = CDbl(Tmp)
    '    End If
    '    Cmd.Dispose()
    '    Con.Close()

    '    'Try
    '    '    Using nCon As New SqlConnection(ConStr)
    '    '        nCon.Open()
    '    '        Using Cmd As New SqlCommand(Qry, nCon)
    '    '            Dim Tmp = Cmd.ExecuteScalar
    '    '            If IsDBNull(Tmp) = False Then
    '    '                GetData = CType(Tmp, Double)
    '    '            End If
    '    '        End Using
    '    '        nCon.Close()
    '    '    End Using
    '    'Catch ex As SqlException
    '    '    MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    'End Try

    'End Function

    Public Shared Sub LoadList(ByVal Lst As ListBox, ByVal Qry As String, ByVal Name As String, Optional ByVal ID As String = "")

        Using nCon As New SqlConnection(ConStr)
            nCon.Open()
            Using Adp As New SqlDataAdapter(Qry, nCon)
                Using Tbl As New DataSet
                    Adp.Fill(Tbl)
                    Lst.DataSource = Nothing
                    Lst.DataSource = Tbl.Tables(0)
                    Lst.DisplayMember = Name
                    Lst.ValueMember = ID
                End Using
            End Using
            nCon.Close()
        End Using

    End Sub

    Public Shared Sub LoadCombo(ByVal Cmb As ComboBox, ByVal Qry As String, ByVal Name As String, Optional ByVal ID As String = "", Optional ByVal Header As String = "")

        Cmb.DataSource = Nothing
        Using nCon As New SqlConnection(ConStr)
            nCon.Open()
            Using Adp As New SqlDataAdapter(Qry, nCon)
                Using Tbl As New DataSet
                    Adp.Fill(Tbl)

                    If Header <> "" Then
                        Dim Tr As DataRow
                        Tr = Tbl.Tables(0).NewRow
                        Tr(Name) = Header
                        Tbl.Tables(0).Rows.InsertAt(Tr, 0)
                    End If

                    Cmb.DataSource = Tbl.Tables(0)
                    Cmb.DisplayMember = Name
                    Cmb.ValueMember = ID
                End Using
            End Using
            nCon.Close()
        End Using

    End Sub

    Public Shared Function DeleteData(ByVal Table1 As String, ByVal Feild1 As String, ByVal Value1 As String) As String

        DeleteData = "delete from " & Table1 & " where " & Feild1 & "=" & Value1

    End Function

    Public Shared Function DeleteData(ByVal Table1 As String, ByVal Feild1 As String, ByVal Value1 As String, ByVal Table2 As String, ByVal Feild2 As String, ByVal Value2 As String) As String

        DeleteData = "delete from " & Table1 & " where " & Feild1 & "=" & Value1 & ";" _
                    & "delete from " & Table2 & " where " & Feild2 & "=" & Value2
    End Function

    Public Shared Sub LoadComboSimple(ByVal Cmb As ComboBox, ByVal SQL As String, ByVal Name As String, Optional ByVal ID As String = "", Optional ByVal Header As String = "")

        Cmb.Text = ""
        Cmb.Items.Clear()
        With OpenReader(SQL)
            If .HasRows Then
                While .Read
                    Cmb.Items.Add(New VB6.ListBoxItem(.Item(Name), IIf(ID <> "", .Item(ID), 0)))
                End While
            End If
            If Header <> "" Then
                Cmb.Items.Insert(0, Header)
            End If
            If Cmb.Items.Count > 0 Then Cmb.SelectedIndex = 0
            .Close()
        End With

    End Sub

    Public Shared Function GetItemValue(ByVal Cmb As ComboBox) As Integer

        If Cmb.SelectedIndex = -1 Then
            GetItemValue = -1
        Else
            GetItemValue = VB6.GetItemData(Cmb, Cmb.SelectedIndex)
        End If

    End Function

    Public Shared Function GetColTotal(ByVal DGV As DataGridView, ByVal FindCol As SByte) As Double

        GetColTotal = 0
        For i As Integer = 0 To DGV.Rows.Count - 1
            GetColTotal += Val(DGV.Item(FindCol, i).Value)
        Next

    End Function

    Public Shared Async Function GenerateData(ByVal iSQL As String) As Threading.Tasks.Task(Of Object)

        Await ESSA.OpenConnectionAsync()
        Using Cmd As New SqlCommand(iSQL, Con)
            Return Await Cmd.ExecuteScalarAsync
        End Using
        Con.Close()

    End Function

    Public Shared Async Function OpenReaderAsync(ByVal Qry As String) As Task(Of SqlDataReader)

        OpenConnection()

        Try
            Using Cmd As New SqlCommand(Qry, Con)
                Return Await Cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection)
            End Using
        Catch ex As SqlException
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Public Shared Async Function LoadComboAsync(ByVal Cmb As ComboBox, ByVal Qry As String, ByVal Name As String, Optional ByVal ID As String = "", Optional ByVal Header As String = "") As Task

        Cmb.DataSource = Nothing
        Using nCon As New SqlConnection(ConStr)
            nCon.Open()
            Using Adp As New SqlDataAdapter(Qry, nCon)
                Using Tbl As New DataSet
                    Await Task.Run(Sub() Adp.Fill(Tbl))

                    If Header <> "" Then
                        Dim Tr As DataRow
                        Tr = Tbl.Tables(0).NewRow
                        Tr(Name) = Header
                        Tbl.Tables(0).Rows.InsertAt(Tr, 0)
                    End If

                    Cmb.DataSource = Tbl.Tables(0)
                    Cmb.DisplayMember = Name
                    Cmb.ValueMember = ID
                End Using
            End Using
            nCon.Close()
        End Using

    End Function

    Public Shared Async Function GenerateIDAsync(ByVal Qry As String) As Task(Of Integer)

        Try
            OpenConnection()
            Using Cmd As New SqlCommand(Qry, Con)
                Dim Tmp = Await Cmd.ExecuteScalarAsync
                If IsDBNull(Tmp) = False Then
                    Return CInt(Tmp) + 1
                Else
                    Return 1
                End If
            End Using
            Con.Close()
        Catch ex As Exception
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Public Shared Function IsDuplicateExists(ByVal DGV As DataGridView, ByVal Column As Integer) As Boolean
        Dim valueSet As New HashSet(Of String)()

        For Each row As DataGridViewRow In DGV.Rows
            If Not row.IsNewRow Then
                Dim cellValue As String = Convert.ToString(row.Cells(Column).Value)

                If valueSet.Contains(cellValue) Then
                    Return True
                Else
                    valueSet.Add(cellValue)
                End If
            End If
        Next

        Return False
    End Function

    Public Shared Function GetDataTable(sql As String) As DataTable
        Dim dt As New DataTable
        Using con As New SqlConnection(ConStr)
            Using cmd As New SqlCommand(sql, con)
                con.Open()
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function



End Class
