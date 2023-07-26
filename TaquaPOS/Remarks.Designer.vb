<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Remarks
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlRemarks = New System.Windows.Forms.Panel()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.TGRmks = New System.Windows.Forms.DataGridView()
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlRemarks.SuspendLayout()
        CType(Me.TGRmks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlRemarks
        '
        Me.pnlRemarks.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRemarks.Controls.Add(Me.Label1)
        Me.pnlRemarks.Controls.Add(Me.Label65)
        Me.pnlRemarks.Controls.Add(Me.Label63)
        Me.pnlRemarks.Controls.Add(Me.txtRemarks)
        Me.pnlRemarks.Controls.Add(Me.txtID)
        Me.pnlRemarks.Controls.Add(Me.Label60)
        Me.pnlRemarks.Controls.Add(Me.TGRmks)
        Me.pnlRemarks.Location = New System.Drawing.Point(1, 0)
        Me.pnlRemarks.Name = "pnlRemarks"
        Me.pnlRemarks.Size = New System.Drawing.Size(318, 361)
        Me.pnlRemarks.TabIndex = 8
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.ForeColor = System.Drawing.Color.DimGray
        Me.Label65.Location = New System.Drawing.Point(90, 5)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(136, 15)
        Me.Label65.TabIndex = 15
        Me.Label65.Text = "PREDEFINED REMARKS"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(61, 31)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(50, 13)
        Me.Label63.TabIndex = 14
        Me.Label63.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(64, 49)
        Me.txtRemarks.MaxLength = 50
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(250, 22)
        Me.txtRemarks.TabIndex = 1
        Me.txtRemarks.Tag = "1"
        '
        'txtID
        '
        Me.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Location = New System.Drawing.Point(3, 49)
        Me.txtID.MaxLength = 10
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(55, 22)
        Me.txtID.TabIndex = 0
        Me.txtID.Tag = "1"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(2, 31)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(18, 13)
        Me.Label60.TabIndex = 11
        Me.Label60.Text = "ID"
        '
        'TGRmks
        '
        Me.TGRmks.AllowUserToAddRows = False
        Me.TGRmks.AllowUserToResizeColumns = False
        Me.TGRmks.AllowUserToResizeRows = False
        Me.TGRmks.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.TGRmks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.TGRmks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TGRmks.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.TGRmks.ColumnHeadersHeight = 25
        Me.TGRmks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.TGRmks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column27, Me.Column28})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(71, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TGRmks.DefaultCellStyle = DataGridViewCellStyle4
        Me.TGRmks.EnableHeadersVisualStyles = False
        Me.TGRmks.GridColor = System.Drawing.Color.Gainsboro
        Me.TGRmks.Location = New System.Drawing.Point(3, 76)
        Me.TGRmks.MultiSelect = False
        Me.TGRmks.Name = "TGRmks"
        Me.TGRmks.ReadOnly = True
        Me.TGRmks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.TGRmks.RowHeadersVisible = False
        Me.TGRmks.RowTemplate.Height = 25
        Me.TGRmks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TGRmks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.TGRmks.Size = New System.Drawing.Size(311, 260)
        Me.TGRmks.TabIndex = 2
        Me.TGRmks.Tag = "1"
        '
        'Column27
        '
        Me.Column27.HeaderText = "ID"
        Me.Column27.Name = "Column27"
        Me.Column27.ReadOnly = True
        Me.Column27.Width = 60
        '
        'Column28
        '
        Me.Column28.HeaderText = "Remarks"
        Me.Column28.Name = "Column28"
        Me.Column28.ReadOnly = True
        Me.Column28.Width = 250
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 341)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "PRESS DELETE REMOVE REMARKS"
        '
        'Remarks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 362)
        Me.Controls.Add(Me.pnlRemarks)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Remarks"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Remarks"
        Me.pnlRemarks.ResumeLayout(False)
        Me.pnlRemarks.PerformLayout()
        CType(Me.TGRmks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlRemarks As System.Windows.Forms.Panel
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents TGRmks As System.Windows.Forms.DataGridView
    Friend WithEvents Column27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
