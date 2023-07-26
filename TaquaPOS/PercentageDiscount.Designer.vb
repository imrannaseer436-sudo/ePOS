<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PercentageDiscount
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlBack = New System.Windows.Forms.TableLayoutPanel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LBLNAMT = New System.Windows.Forms.Label()
        Me.SimpleLine3 = New simpleline.assemblies.simpleLine()
        Me.LBLTOTDIS = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LBLTAMT = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SimpleLine1 = New simpleline.assemblies.simpleLine()
        Me.TG = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SimpleLine2 = New simpleline.assemblies.simpleLine()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlBack.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBack
        '
        Me.pnlBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
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
        Me.pnlBack.Size = New System.Drawing.Size(351, 482)
        Me.pnlBack.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Webdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(315, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(33, 24)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "r"
        Me.btnClose.UseVisualStyleBackColor = True
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
        Me.Label1.Text = "Bill Discount"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.pnlBack.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.btnDone)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.LBLNAMT)
        Me.Panel1.Controls.Add(Me.SimpleLine3)
        Me.Panel1.Controls.Add(Me.LBLTOTDIS)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.LBLTAMT)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.SimpleLine1)
        Me.Panel1.Controls.Add(Me.TG)
        Me.Panel1.Controls.Add(Me.SimpleLine2)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(344, 445)
        Me.Panel1.TabIndex = 0
        '
        'btnDone
        '
        Me.btnDone.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnDone.FlatAppearance.BorderSize = 0
        Me.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDone.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDone.ForeColor = System.Drawing.Color.Black
        Me.btnDone.Location = New System.Drawing.Point(267, 7)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(70, 22)
        Me.btnDone.TabIndex = 15
        Me.btnDone.Text = "DONE - F3"
        Me.btnDone.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 409)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "NETT AMOUNT"
        '
        'LBLNAMT
        '
        Me.LBLNAMT.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNAMT.ForeColor = System.Drawing.Color.Blue
        Me.LBLNAMT.Location = New System.Drawing.Point(223, 409)
        Me.LBLNAMT.Name = "LBLNAMT"
        Me.LBLNAMT.Size = New System.Drawing.Size(99, 13)
        Me.LBLNAMT.TabIndex = 13
        Me.LBLNAMT.Text = "0.00"
        Me.LBLNAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SimpleLine3
        '
        Me.SimpleLine3.Enabled = False
        Me.SimpleLine3.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine3.FitToParent = False
        Me.SimpleLine3.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine3.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine3.LineColor = System.Drawing.Color.WhiteSmoke
        Me.SimpleLine3.LineWidth = 1
        Me.SimpleLine3.Location = New System.Drawing.Point(183, 394)
        Me.SimpleLine3.Name = "SimpleLine3"
        Me.SimpleLine3.Size = New System.Drawing.Size(150, 1)
        Me.SimpleLine3.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine3.TabIndex = 12
        Me.SimpleLine3.UseGradient = False
        '
        'LBLTOTDIS
        '
        Me.LBLTOTDIS.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTDIS.ForeColor = System.Drawing.Color.Blue
        Me.LBLTOTDIS.Location = New System.Drawing.Point(223, 369)
        Me.LBLTOTDIS.Name = "LBLTOTDIS"
        Me.LBLTOTDIS.Size = New System.Drawing.Size(99, 13)
        Me.LBLTOTDIS.TabIndex = 10
        Me.LBLTOTDIS.Text = "0.00"
        Me.LBLTOTDIS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 369)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "TOTAL DISCOUNT"
        '
        'LBLTAMT
        '
        Me.LBLTAMT.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTAMT.ForeColor = System.Drawing.Color.Blue
        Me.LBLTAMT.Location = New System.Drawing.Point(223, 348)
        Me.LBLTAMT.Name = "LBLTAMT"
        Me.LBLTAMT.Size = New System.Drawing.Size(99, 13)
        Me.LBLTAMT.TabIndex = 9
        Me.LBLTAMT.Text = "0.00"
        Me.LBLTAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 348)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "TOTAL AMOUNT"
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
        Me.SimpleLine1.Location = New System.Drawing.Point(8, 334)
        Me.SimpleLine1.Name = "SimpleLine1"
        Me.SimpleLine1.Size = New System.Drawing.Size(329, 1)
        Me.SimpleLine1.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine1.TabIndex = 8
        Me.SimpleLine1.UseGradient = False
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
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(82, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.TG.ColumnHeadersHeight = 25
        Me.TG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.TG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column6, Me.Column7, Me.Column5, Me.Column4})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TG.DefaultCellStyle = DataGridViewCellStyle3
        Me.TG.EnableHeadersVisualStyles = False
        Me.TG.GridColor = System.Drawing.Color.WhiteSmoke
        Me.TG.Location = New System.Drawing.Point(8, 35)
        Me.TG.Name = "TG"
        Me.TG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.TG.RowHeadersVisible = False
        Me.TG.RowTemplate.Height = 25
        Me.TG.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.TG.Size = New System.Drawing.Size(329, 293)
        Me.TG.TabIndex = 4
        '
        'Column1
        '
        Me.Column1.HeaderText = "PLUID"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "SNO"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 40
        '
        'Column3
        '
        Me.Column3.HeaderText = "CODE"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column6
        '
        Me.Column6.HeaderText = "AMOUNT"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 80
        '
        'Column7
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column7.HeaderText = "PERC %"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 50
        '
        'Column5
        '
        Me.Column5.HeaderText = "D.AMOUNT"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 80
        '
        'Column4
        '
        Me.Column4.HeaderText = "Qty"
        Me.Column4.Name = "Column4"
        Me.Column4.Visible = False
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
        Me.SimpleLine2.Location = New System.Drawing.Point(7, 28)
        Me.SimpleLine2.Name = "SimpleLine2"
        Me.SimpleLine2.Size = New System.Drawing.Size(329, 1)
        Me.SimpleLine2.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine2.TabIndex = 7
        Me.SimpleLine2.UseGradient = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 15)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "LIST OF ITEMS"
        '
        'PercentageDiscount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 482)
        Me.Controls.Add(Me.pnlBack)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "PercentageDiscount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PercentageDiscount"
        Me.pnlBack.ResumeLayout(False)
        Me.pnlBack.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBack As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LBLNAMT As System.Windows.Forms.Label
    Friend WithEvents SimpleLine3 As simpleline.assemblies.simpleLine
    Friend WithEvents LBLTOTDIS As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LBLTAMT As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SimpleLine1 As simpleline.assemblies.simpleLine
    Friend WithEvents TG As System.Windows.Forms.DataGridView
    Friend WithEvents SimpleLine2 As simpleline.assemblies.simpleLine
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
