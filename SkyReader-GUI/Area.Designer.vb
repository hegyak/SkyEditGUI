<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArea
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picB = New System.Windows.Forms.PictureBox()
        Me.picA = New System.Windows.Forms.PictureBox()
        CType(Me.picB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(70, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "B"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "A"
        '
        'picB
        '
        Me.picB.Location = New System.Drawing.Point(61, 27)
        Me.picB.Name = "picB"
        Me.picB.Size = New System.Drawing.Size(32, 29)
        Me.picB.TabIndex = 17
        Me.picB.TabStop = False
        '
        'picA
        '
        Me.picA.Location = New System.Drawing.Point(12, 27)
        Me.picA.Name = "picA"
        Me.picA.Size = New System.Drawing.Size(32, 29)
        Me.picA.TabIndex = 16
        Me.picA.TabStop = False
        '
        'frmArea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(120, 87)
        Me.Controls.Add(Me.picA)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.picB)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmArea"
        Me.Text = "Area?"
        CType(Me.picB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents picB As PictureBox
    Friend WithEvents picA As PictureBox
End Class
