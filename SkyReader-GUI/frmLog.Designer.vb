<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLog
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
		Me.rtxLog = New System.Windows.Forms.RichTextBox()
		Me.SuspendLayout()
		'
		'rtxLog
		'
		Me.rtxLog.Dock = System.Windows.Forms.DockStyle.Fill
		Me.rtxLog.Location = New System.Drawing.Point(0, 0)
		Me.rtxLog.Margin = New System.Windows.Forms.Padding(4)
		Me.rtxLog.Name = "rtxLog"
		Me.rtxLog.Size = New System.Drawing.Size(737, 634)
		Me.rtxLog.TabIndex = 0
		Me.rtxLog.Text = ""
		'
		'frmLog
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(737, 634)
		Me.ControlBox = False
		Me.Controls.Add(Me.rtxLog)
		Me.Margin = New System.Windows.Forms.Padding(4)
		Me.MaximizeBox = False
		Me.Name = "frmLog"
		Me.Text = "frmLog"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents rtxLog As RichTextBox
End Class
