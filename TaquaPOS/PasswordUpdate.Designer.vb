<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PasswordUpdate
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
        Me.txtRNP = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNP = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.SimpleLine2 = New simpleline.assemblies.simpleLine()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOP = New System.Windows.Forms.TextBox()
        Me.SimpleLine1 = New simpleline.assemblies.simpleLine()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.txtRNP)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtNP)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnUpdate)
        Me.Panel1.Controls.Add(Me.SimpleLine2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtOP)
        Me.Panel1.Controls.Add(Me.SimpleLine1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 363)
        Me.Panel1.TabIndex = 0
        '
        'txtRNP
        '
        Me.txtRNP.Location = New System.Drawing.Point(14, 233)
        Me.txtRNP.Name = "txtRNP"
        Me.txtRNP.Size = New System.Drawing.Size(256, 22)
        Me.txtRNP.TabIndex = 2
        Me.txtRNP.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(10, 215)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 15)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Retype New Password"
        '
        'txtNP
        '
        Me.txtNP.Location = New System.Drawing.Point(14, 176)
        Me.txtNP.Name = "txtNP"
        Me.txtNP.Size = New System.Drawing.Size(256, 22)
        Me.txtNP.TabIndex = 1
        Me.txtNP.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(11, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "New Password"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(182, 317)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(88, 28)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(88, 317)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(88, 28)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
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
        Me.SimpleLine2.Location = New System.Drawing.Point(12, 294)
        Me.SimpleLine2.Name = "SimpleLine2"
        Me.SimpleLine2.Size = New System.Drawing.Size(260, 1)
        Me.SimpleLine2.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine2.TabIndex = 18
        Me.SimpleLine2.UseGradient = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 272)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "OPTIONS"
        '
        'txtOP
        '
        Me.txtOP.Location = New System.Drawing.Point(14, 123)
        Me.txtOP.Name = "txtOP"
        Me.txtOP.Size = New System.Drawing.Size(256, 22)
        Me.txtOP.TabIndex = 0
        Me.txtOP.UseSystemPasswordChar = True
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
        Me.SimpleLine1.Location = New System.Drawing.Point(12, 90)
        Me.SimpleLine1.Name = "SimpleLine1"
        Me.SimpleLine1.Size = New System.Drawing.Size(260, 1)
        Me.SimpleLine1.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine1.TabIndex = 15
        Me.SimpleLine1.UseGradient = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(11, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Old Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 15)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "RETYPE PASSWORDS"
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
        Me.Label7.Text = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Light", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(58, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(188, 32)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Update Password"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(296, 375)
        Me.TableLayoutPanel1.TabIndex = 12
        '
        'PasswordUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 375)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PasswordUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PasswordUpdate"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents SimpleLine2 As simpleline.assemblies.simpleLine
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOP As System.Windows.Forms.TextBox
    Friend WithEvents SimpleLine1 As simpleline.assemblies.simpleLine
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtRNP As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNP As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
