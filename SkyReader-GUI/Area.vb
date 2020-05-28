Imports SkyReader_GUI.frmMain
Public Class frmArea
    Private Sub frmArea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Sub Clear()
        picA.BackColor = Color.Gray
        picB.BackColor = Color.Gray
    End Sub
    Sub Area0_1()
        Application.DoEvents()
        If Area0 > Area1 Then
            picA.BackColor = Color.Green
            picB.BackColor = Color.Gray
        ElseIf Area1 > Area0 Then
            picA.BackColor = Color.Gray
            picB.BackColor = Color.Green
        ElseIf Area0 = Area1 Then
            picA.BackColor = Color.Green
            picB.BackColor = Color.Gray
        End If
    End Sub
    Private Sub frmArea_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        picA.BackColor = Color.Gray
        picB.BackColor = Color.Gray
        'Hide Form
        Hide()
        'Don't actually close this Form.
        e.Cancel = True
    End Sub
End Class