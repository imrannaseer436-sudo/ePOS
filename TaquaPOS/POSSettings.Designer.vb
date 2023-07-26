<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POSSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlMain = New System.Windows.Forms.TableLayoutPanel()
        Me.txtSqlserver = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtShopCode = New System.Windows.Forms.TextBox()
        Me.txtTermID = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtVersionPath = New System.Windows.Forms.TextBox()
        Me.txtPrinter = New System.Windows.Forms.TextBox()
        Me.chkRichTextPrinter = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkITM = New System.Windows.Forms.CheckBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.chkSalesComm = New System.Windows.Forms.CheckBox()
        Me.TGFS = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnLoadFloorList = New System.Windows.Forms.Label()
        Me.chkDirectPrint = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TGFS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.pnlMain.ColumnCount = 3
        Me.pnlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.pnlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.pnlMain.Controls.Add(Me.Panel1, 1, 1)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.RowCount = 3
        Me.pnlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.pnlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.pnlMain.Size = New System.Drawing.Size(643, 525)
        Me.pnlMain.TabIndex = 10
        '
        'txtSqlserver
        '
        Me.txtSqlserver.BackColor = System.Drawing.Color.White
        Me.txtSqlserver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSqlserver.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSqlserver.ForeColor = System.Drawing.Color.Black
        Me.txtSqlserver.Location = New System.Drawing.Point(19, 85)
        Me.txtSqlserver.Name = "txtSqlserver"
        Me.txtSqlserver.Size = New System.Drawing.Size(373, 29)
        Me.txtSqlserver.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 21)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Username"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(15, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SQL Server"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(14, 247)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Database"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Black
        Me.txtPassword.Location = New System.Drawing.Point(19, 210)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(373, 29)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.White
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.Black
        Me.txtUsername.Location = New System.Drawing.Point(19, 148)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(373, 29)
        Me.txtUsername.TabIndex = 1
        '
        'txtDatabase
        '
        Me.txtDatabase.BackColor = System.Drawing.Color.White
        Me.txtDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDatabase.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatabase.ForeColor = System.Drawing.Color.Black
        Me.txtDatabase.Location = New System.Drawing.Point(19, 272)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(373, 29)
        Me.txtDatabase.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Light", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(55, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 45)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Settings"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(14, 385)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 17)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Shop code"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(91, 385)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 17)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Term ID"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(149, 385)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 17)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Printer Name"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 309)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 21)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "FTP Version"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Symbol", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(6, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 45)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = ""
        '
        'txtShopCode
        '
        Me.txtShopCode.BackColor = System.Drawing.Color.White
        Me.txtShopCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShopCode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShopCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.txtShopCode.Location = New System.Drawing.Point(19, 405)
        Me.txtShopCode.Name = "txtShopCode"
        Me.txtShopCode.Size = New System.Drawing.Size(69, 25)
        Me.txtShopCode.TabIndex = 5
        Me.txtShopCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTermID
        '
        Me.txtTermID.BackColor = System.Drawing.Color.White
        Me.txtTermID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTermID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTermID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.txtTermID.Location = New System.Drawing.Point(94, 405)
        Me.txtTermID.Name = "txtTermID"
        Me.txtTermID.Size = New System.Drawing.Size(52, 25)
        Me.txtTermID.TabIndex = 6
        Me.txtTermID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Webdings", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.DimGray
        Me.btnClose.Location = New System.Drawing.Point(589, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(36, 31)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "r"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtVersionPath
        '
        Me.txtVersionPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVersionPath.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVersionPath.ForeColor = System.Drawing.Color.Black
        Me.txtVersionPath.Location = New System.Drawing.Point(19, 335)
        Me.txtVersionPath.Name = "txtVersionPath"
        Me.txtVersionPath.Size = New System.Drawing.Size(373, 29)
        Me.txtVersionPath.TabIndex = 4
        '
        'txtPrinter
        '
        Me.txtPrinter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrinter.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrinter.ForeColor = System.Drawing.Color.Black
        Me.txtPrinter.Location = New System.Drawing.Point(152, 405)
        Me.txtPrinter.Name = "txtPrinter"
        Me.txtPrinter.Size = New System.Drawing.Size(240, 25)
        Me.txtPrinter.TabIndex = 7
        '
        'chkRichTextPrinter
        '
        Me.chkRichTextPrinter.AutoSize = True
        Me.chkRichTextPrinter.Location = New System.Drawing.Point(262, 436)
        Me.chkRichTextPrinter.Name = "chkRichTextPrinter"
        Me.chkRichTextPrinter.Size = New System.Drawing.Size(130, 19)
        Me.chkRichTextPrinter.TabIndex = 14
        Me.chkRichTextPrinter.Text = "Use RichText Printer"
        Me.chkRichTextPrinter.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.btnUpdate)
        Me.Panel2.Controls.Add(Me.chkITM)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 463)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(631, 50)
        Me.Panel2.TabIndex = 16
        '
        'chkITM
        '
        Me.chkITM.AutoSize = True
        Me.chkITM.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkITM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkITM.Location = New System.Drawing.Point(19, 18)
        Me.chkITM.Name = "chkITM"
        Me.chkITM.Size = New System.Drawing.Size(200, 17)
        Me.chkITM.TabIndex = 15
        Me.chkITM.Text = "IS Trail Mode (Stock not consider)"
        Me.chkITM.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(492, 10)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(108, 31)
        Me.btnUpdate.TabIndex = 7
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'chkSalesComm
        '
        Me.chkSalesComm.AutoSize = True
        Me.chkSalesComm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSalesComm.Location = New System.Drawing.Point(426, 77)
        Me.chkSalesComm.Name = "chkSalesComm"
        Me.chkSalesComm.Size = New System.Drawing.Size(166, 25)
        Me.chkSalesComm.TabIndex = 18
        Me.chkSalesComm.Text = "Sales Commission"
        Me.chkSalesComm.UseVisualStyleBackColor = True
        '
        'TGFS
        '
        Me.TGFS.AllowUserToAddRows = False
        Me.TGFS.AllowUserToDeleteRows = False
        Me.TGFS.AllowUserToResizeColumns = False
        Me.TGFS.AllowUserToResizeRows = False
        Me.TGFS.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.TGFS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.TGFS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.TGFS.EnableHeadersVisualStyles = False
        Me.TGFS.Location = New System.Drawing.Point(426, 108)
        Me.TGFS.Name = "TGFS"
        Me.TGFS.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.TGFS.RowHeadersVisible = False
        Me.TGFS.Size = New System.Drawing.Size(174, 294)
        Me.TGFS.TabIndex = 19
        '
        'Column3
        '
        Me.Column3.HeaderText = "Count"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 60
        '
        'Column2
        '
        Me.Column2.HeaderText = "Floor"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 60
        '
        'Column1
        '
        Me.Column1.FalseValue = "0"
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.TrueValue = "1"
        Me.Column1.Width = 50
        '
        'btnLoadFloorList
        '
        Me.btnLoadFloorList.AutoSize = True
        Me.btnLoadFloorList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoadFloorList.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadFloorList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnLoadFloorList.Location = New System.Drawing.Point(516, 409)
        Me.btnLoadFloorList.Name = "btnLoadFloorList"
        Me.btnLoadFloorList.Size = New System.Drawing.Size(84, 15)
        Me.btnLoadFloorList.TabIndex = 20
        Me.btnLoadFloorList.Text = "Load Floor List"
        '
        'chkDirectPrint
        '
        Me.chkDirectPrint.AutoSize = True
        Me.chkDirectPrint.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDirectPrint.ForeColor = System.Drawing.Color.Red
        Me.chkDirectPrint.Location = New System.Drawing.Point(152, 436)
        Me.chkDirectPrint.Name = "chkDirectPrint"
        Me.chkDirectPrint.Size = New System.Drawing.Size(91, 19)
        Me.chkDirectPrint.TabIndex = 21
        Me.chkDirectPrint.Text = "Direct Print"
        Me.chkDirectPrint.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.chkDirectPrint)
        Me.Panel1.Controls.Add(Me.btnLoadFloorList)
        Me.Panel1.Controls.Add(Me.TGFS)
        Me.Panel1.Controls.Add(Me.chkSalesComm)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.chkRichTextPrinter)
        Me.Panel1.Controls.Add(Me.txtPrinter)
        Me.Panel1.Controls.Add(Me.txtVersionPath)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.txtTermID)
        Me.Panel1.Controls.Add(Me.txtShopCode)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtDatabase)
        Me.Panel1.Controls.Add(Me.txtUsername)
        Me.Panel1.Controls.Add(Me.txtPassword)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtSqlserver)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(631, 513)
        Me.Panel1.TabIndex = 0
        '
        'POSSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 525)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "POSSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POSSettings"
        Me.pnlMain.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.TGFS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chkDirectPrint As CheckBox
    Friend WithEvents btnLoadFloorList As Label
    Friend WithEvents TGFS As DataGridView
    Friend WithEvents Column1 As DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents chkSalesComm As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnUpdate As Button
    Friend WithEvents chkITM As CheckBox
    Friend WithEvents chkRichTextPrinter As CheckBox
    Friend WithEvents txtPrinter As TextBox
    Friend WithEvents txtVersionPath As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents txtTermID As TextBox
    Friend WithEvents txtShopCode As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDatabase As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSqlserver As TextBox
End Class
