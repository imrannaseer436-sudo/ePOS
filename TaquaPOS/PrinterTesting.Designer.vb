<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrinterTesting
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
        Me.btnConnectPrinter = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnConnectPrinter
        '
        Me.btnConnectPrinter.Location = New System.Drawing.Point(72, 41)
        Me.btnConnectPrinter.Name = "btnConnectPrinter"
        Me.btnConnectPrinter.Size = New System.Drawing.Size(186, 45)
        Me.btnConnectPrinter.TabIndex = 0
        Me.btnConnectPrinter.Text = "Connect Printer"
        Me.btnConnectPrinter.UseVisualStyleBackColor = True
        '
        'PrinterTesting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 127)
        Me.Controls.Add(Me.btnConnectPrinter)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PrinterTesting"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PrinterTesting"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnConnectPrinter As System.Windows.Forms.Button
End Class
