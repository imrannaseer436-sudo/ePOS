<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DiscountOverride
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlID = New System.Windows.Forms.Panel()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnOverride = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlPass = New System.Windows.Forms.Panel()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.pnlHead.SuspendLayout()
        Me.pnlID.SuspendLayout()
        Me.pnlPass.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlHead)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.pnlID)
        Me.Panel1.Controls.Add(Me.btnOverride)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.pnlPass)
        Me.Panel1.Location = New System.Drawing.Point(10, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(327, 417)
        Me.Panel1.TabIndex = 0
        '
        'pnlHead
        '
        Me.pnlHead.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlHead.Controls.Add(Me.btnClose)
        Me.pnlHead.Controls.Add(Me.Label2)
        Me.pnlHead.Controls.Add(Me.Label1)
        Me.pnlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHead.Location = New System.Drawing.Point(0, 0)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(327, 62)
        Me.pnlHead.TabIndex = 10
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Black
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Webdings", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnClose.Location = New System.Drawing.Point(266, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(61, 62)
        Me.btnClose.TabIndex = 17
        Me.btnClose.Text = "r"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(139, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "+"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Discount"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 52)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = ""
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 52)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = ""
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlID
        '
        Me.pnlID.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlID.Controls.Add(Me.txtID)
        Me.pnlID.Location = New System.Drawing.Point(83, 120)
        Me.pnlID.Name = "pnlID"
        Me.pnlID.Size = New System.Drawing.Size(227, 52)
        Me.pnlID.TabIndex = 15
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtID.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.ForeColor = System.Drawing.Color.White
        Me.txtID.Location = New System.Drawing.Point(23, 12)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(198, 28)
        Me.txtID.TabIndex = 0
        '
        'btnOverride
        '
        Me.btnOverride.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOverride.FlatAppearance.BorderSize = 0
        Me.btnOverride.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOverride.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOverride.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnOverride.Location = New System.Drawing.Point(19, 264)
        Me.btnOverride.Name = "btnOverride"
        Me.btnOverride.Size = New System.Drawing.Size(291, 57)
        Me.btnOverride.TabIndex = 12
        Me.btnOverride.Text = "ALLOW ME..!"
        Me.btnOverride.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "ENTER DISCOUNT+ CODE"
        '
        'pnlPass
        '
        Me.pnlPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlPass.Controls.Add(Me.txtCode)
        Me.pnlPass.Location = New System.Drawing.Point(83, 185)
        Me.pnlPass.Name = "pnlPass"
        Me.pnlPass.Size = New System.Drawing.Size(227, 52)
        Me.pnlPass.TabIndex = 16
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCode.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.ForeColor = System.Drawing.Color.White
        Me.txtCode.Location = New System.Drawing.Point(23, 8)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(198, 28)
        Me.txtCode.TabIndex = 1
        '
        'DiscountOverride
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(346, 435)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DiscountOverride"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Discount Override"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlHead.ResumeLayout(False)
        Me.pnlHead.PerformLayout()
        Me.pnlID.ResumeLayout(False)
        Me.pnlID.PerformLayout()
        Me.pnlPass.ResumeLayout(False)
        Me.pnlPass.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlHead As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlID As System.Windows.Forms.Panel
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents btnOverride As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlPass As System.Windows.Forms.Panel
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
