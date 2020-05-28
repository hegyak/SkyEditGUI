Imports SkyReader_GUI.FigureIO
Imports SkyReader_GUI.frmMain
Public Class Gold
    'Remember all values are offset 1C0
    Shared Sub GetGold()
        Dim GoldArea0(1) As Byte
        Dim GoldValueArea0 As UShort
        Dim GoldArea1(1) As Byte
        Dim GoldValueArea1 As UShort

        GoldArea0(0) = WholeFile(&H83)
        GoldArea0(1) = WholeFile(&H84)

        GoldArea1(0) = WholeFile(&H243)
        GoldArea1(1) = WholeFile(&H244)

        ReDim Preserve GoldArea0(3)
        Try
            GoldValueArea0 = BitConverter.ToInt32(GoldArea0, 0)
        Catch ex As Exception
            GoldValueArea0 = 0
        End Try
        ReDim Preserve GoldArea1(3)
        Try
            GoldValueArea1 = BitConverter.ToInt32(GoldArea1, 0)
        Catch ex As Exception
            GoldValueArea1 = 0
        End Try
        If GoldValueArea0 > 65000 Then
            GoldValueArea0 = 65000
        End If
        If GoldValueArea1 > 65000 Then
            GoldValueArea1 = 65000
        End If

        If Area0 > Area1 Then
            frmMain.numGold.Value = GoldValueArea0
        ElseIf Area1 > Area0 Then
            frmMain.numGold.Value = GoldValueArea1
        ElseIf Area0 = Area1 Then
            frmMain.numGold.Value = GoldValueArea0
        End If


    End Sub
    Shared Sub WriteGold()
        Dim intGold As UShort = frmMain.numGold.Value
        Dim Gold As Byte() = BitConverter.GetBytes(intGold)
        'MessageBox.Show("G0: " & Gold(0))
        'MessageBox.Show("G1: " & Gold(1))
        'If Area0 > Area1 Then
        'Area 0 Gold
        WholeFile(&H83) = Gold(0)
        WholeFile(&H84) = Gold(1)
        'ElseIf Area1 > Area0 Then
        'Area 1 Gold
        WholeFile(&H243) = Gold(0)
        WholeFile(&H244) = Gold(1)
        'ElseIf Area0 = Area1 Then
        'Area 0 Gold
        'WholeFile(&H83) = Gold(0)
        'WholeFile(&H84) = Gold(1)
        'End If
    End Sub
End Class
