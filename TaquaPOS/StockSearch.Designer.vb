<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockSearch
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlBack = New System.Windows.Forms.TableLayoutPanel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkName = New System.Windows.Forms.CheckBox()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.TG = New System.Windows.Forms.DataGridView()
        Me.SimpleLine2 = New simpleline.assemblies.simpleLine()
        Me.SimpleLine1 = New simpleline.assemblies.simpleLine()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PnlLoading = New System.Windows.Forms.Panel()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.pnlBack.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlLoading.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBack
        '
        Me.pnlBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.pnlBack.ColumnCount = 3
        Me.pnlBack.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.pnlBack.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlBack.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.pnlBack.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlBack.Controls.Add(Me.btnClose, 2, 0)
        Me.pnlBack.Controls.Add(Me.Label1, 1, 0)
        Me.pnlBack.Controls.Add(Me.Panel1, 1, 1)
        Me.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBack.Location = New System.Drawing.Point(0, 0)
        Me.pnlBack.Name = "pnlBack"
        Me.pnlBack.RowCount = 3
        Me.pnlBack.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.pnlBack.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlBack.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.pnlBack.Size = New System.Drawing.Size(346, 501)
        Me.pnlBack.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Webdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(310, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(33, 24)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "r"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Stock Search"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.pnlBack.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.PnlLoading)
        Me.Panel1.Controls.Add(Me.chkName)
        Me.Panel1.Controls.Add(Me.btnGo)
        Me.Panel1.Controls.Add(Me.TG)
        Me.Panel1.Controls.Add(Me.SimpleLine2)
        Me.Panel1.Controls.Add(Me.SimpleLine1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtCode)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(339, 464)
        Me.Panel1.TabIndex = 0
        '
        'chkName
        '
        Me.chkName.AutoSize = True
        Me.chkName.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkName.Location = New System.Drawing.Point(283, 10)
        Me.chkName.Name = "chkName"
        Me.chkName.Size = New System.Drawing.Size(56, 17)
        Me.chkName.TabIndex = 8
        Me.chkName.Text = "Name"
        Me.chkName.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.btnGo.FlatAppearance.BorderSize = 0
        Me.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGo.ForeColor = System.Drawing.Color.White
        Me.btnGo.Location = New System.Drawing.Point(134, 58)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(33, 23)
        Me.btnGo.TabIndex = 3
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = False
        '
        'TG
        '
        Me.TG.AllowUserToAddRows = False
        Me.TG.AllowUserToDeleteRows = False
        Me.TG.AllowUserToResizeColumns = False
        Me.TG.AllowUserToResizeRows = False
        Me.TG.BackgroundColor = System.Drawing.Color.White
        Me.TG.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TG.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.TG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(236, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(82, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.TG.ColumnHeadersHeight = 25
        Me.TG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(162, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TG.DefaultCellStyle = DataGridViewCellStyle2
        Me.TG.EnableHeadersVisualStyles = False
        Me.TG.GridColor = System.Drawing.Color.WhiteSmoke
        Me.TG.Location = New System.Drawing.Point(11, 119)
        Me.TG.Name = "TG"
        Me.TG.ReadOnly = True
        Me.TG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.TG.RowHeadersVisible = False
        Me.TG.RowTemplate.Height = 25
        Me.TG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TG.Size = New System.Drawing.Size(317, 340)
        Me.TG.TabIndex = 4
        '
        'SimpleLine2
        '
        Me.SimpleLine2.Enabled = False
        Me.SimpleLine2.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine2.FitToParent = False
        Me.SimpleLine2.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine2.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine2.LineColor = System.Drawing.Color.WhiteSmoke
        Me.SimpleLine2.LineWidth = 1
        Me.SimpleLine2.Location = New System.Drawing.Point(4, 112)
        Me.SimpleLine2.Name = "SimpleLine2"
        Me.SimpleLine2.Size = New System.Drawing.Size(330, 1)
        Me.SimpleLine2.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine2.TabIndex = 7
        Me.SimpleLine2.UseGradient = False
        '
        'SimpleLine1
        '
        Me.SimpleLine1.Enabled = False
        Me.SimpleLine1.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine1.FitToParent = False
        Me.SimpleLine1.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine1.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine1.LineColor = System.Drawing.Color.WhiteSmoke
        Me.SimpleLine1.LineWidth = 1
        Me.SimpleLine1.Location = New System.Drawing.Point(4, 29)
        Me.SimpleLine1.Name = "SimpleLine1"
        Me.SimpleLine1.Size = New System.Drawing.Size(330, 1)
        Me.SimpleLine1.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine1.TabIndex = 6
        Me.SimpleLine1.UseGradient = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 15)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "SEARCH RESULT"
        '
        'txtCode
        '
        Me.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCode.Location = New System.Drawing.Point(11, 58)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(117, 23)
        Me.txtCode.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Product Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "PRODUCT FILTER"
        '
        'PnlLoading
        '
        Me.PnlLoading.BackColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.PnlLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlLoading.Controls.Add(Me.Label81)
        Me.PnlLoading.Location = New System.Drawing.Point(69, 195)
        Me.PnlLoading.Name = "PnlLoading"
        Me.PnlLoading.Size = New System.Drawing.Size(200, 74)
        Me.PnlLoading.TabIndex = 14
        Me.PnlLoading.Visible = False
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.White
        Me.Label81.Location = New System.Drawing.Point(39, 26)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(121, 21)
        Me.Label81.TabIndex = 0
        Me.Label81.Text = "Loading, Wait..."
        '
        'StockSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 501)
        Me.Controls.Add(Me.pnlBack)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "StockSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProductSearch"
        Me.pnlBack.ResumeLayout(False)
        Me.pnlBack.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlLoading.ResumeLayout(False)
        Me.PnlLoading.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBack As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SimpleLine2 As simpleline.assemblies.simpleLine
    Friend WithEvents SimpleLine1 As simpleline.assemblies.simpleLine
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TG As System.Windows.Forms.DataGridView
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents chkName As CheckBox
    Friend WithEvents PnlLoading As Panel
    Friend WithEvents Label81 As Label
End Class
