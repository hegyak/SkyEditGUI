Imports SkyReader_GUI.frmMain
Public Class System_ID
    Shared System_One(1) As Byte
    Shared System_Two(1) As Byte
    Shared Sub ReadSystem_ID()

        'Add 1C0
        System_One(0) = WholeFile(&H93)
        System_One(1) = WholeFile(&H253)
        System_Two(0) = WholeFile(&H97)
        System_Two(1) = WholeFile(&H257)
        'The question is, how can I tell which System to use, neatly?
        If Area0 > Area1 Then
            System_One(0) = System_One(0)
            System_Two(0) = System_Two(0)
        ElseIf Area1 > Area0 Then
            System_One(0) = System_One(1)
            System_Two(0) = System_Two(1)
        ElseIf Area0 = Area1 Then
            System_One(0) = System_One(0)
            System_Two(0) = System_Two(0)
        End If

        If System_One(0) <= 4 Then
            System1()
        ElseIf System_Two(0) <= 3 Then
            System2()
        End If
    End Sub
    Shared Sub System1()
        'MessageBox.Show("One: " & System_One(0))
        Select Case System_One(0)
            Case 0
                frmMain.cmbSystem.SelectedItem = "Wii"
                Exit Select
            Case 1
                frmMain.cmbSystem.SelectedItem = "Xbox 360"
                Exit Select
            Case 2
                frmMain.cmbSystem.SelectedItem = "PS3"
                Exit Select
            Case 3
                frmMain.cmbSystem.SelectedItem = "PC"
                Exit Select
            Case 4
                frmMain.cmbSystem.SelectedItem = "3DS"
                Exit Select
        End Select
    End Sub
    Shared Sub System2()
        'We are using System 2's value
        'MessageBox.Show("Two: " & System_Two(0))
        Select Case System_Two(0)
            Case 0
                frmMain.cmbSystem.SelectedItem = "Wii U"
                Exit Select
            Case 1
                frmMain.cmbSystem.SelectedItem = "Xbox One"
                Exit Select
            Case 2
                frmMain.cmbSystem.SelectedItem = "PS4"
                Exit Select
            Case 3
                frmMain.cmbSystem.SelectedItem = "Tablet"
                Exit Select
        End Select
    End Sub
    Shared Sub WriteSystem()
        Select Case frmMain.cmbSystem.SelectedIndex
            Case 0
                'Wii
                WholeFile(&H93) = &H0
                WholeFile(&H253) = &H0
                WholeFile(&H97) = &H4
                WholeFile(&H257) = &H4
                Exit Select
            Case 1
                'Xbox 360
                WholeFile(&H93) = &H1
                WholeFile(&H253) = &H1
                WholeFile(&H97) = &H4
                WholeFile(&H257) = &H4
                Exit Select
            Case 2
                'PS3
                WholeFile(&H93) = &H2
                WholeFile(&H253) = &H2
                WholeFile(&H97) = &H4
                WholeFile(&H257) = &H4
                Exit Select
            Case 3
                'PC
                WholeFile(&H93) = &H3
                WholeFile(&H253) = &H3
                WholeFile(&H97) = &H4
                WholeFile(&H257) = &H4
                Exit Select
            Case 4
                '3DS
                WholeFile(&H93) = &H4
                WholeFile(&H253) = &H4
                WholeFile(&H97) = &H4
                WholeFile(&H257) = &H4
                Exit Select
            Case 5
                'Wii U
                WholeFile(&H93) = &H5
                WholeFile(&H253) = &H5
                WholeFile(&H97) = &H0
                WholeFile(&H257) = &H0
                Exit Select
            Case 6
                'Xbox One
                WholeFile(&H93) = &H5
                WholeFile(&H253) = &H5
                WholeFile(&H97) = &H1
                WholeFile(&H257) = &H1
                Exit Select
            Case 7
                'PS4
                WholeFile(&H93) = &H5
                WholeFile(&H253) = &H5
                WholeFile(&H97) = &H2
                WholeFile(&H257) = &H2
                Exit Select
            Case 8
                'Tablet
                WholeFile(&H93) = &H5
                WholeFile(&H253) = &H5
                WholeFile(&H97) = &H3
                WholeFile(&H257) = &H3
                Exit Select
        End Select
    End Sub
End Class