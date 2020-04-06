Imports SkyReader_GUI.frmMain
'WARNING:
'We don't Try and Catch here.  Due to complexity of the values
Public Class Exp
	Shared Sub GetEXP()
		'00000-00999 is Level 1
		'01000-02199 is Level 2
		'02200-03799 is Level 3
		'03800-05999 is Level 4
		'06000-08999 is Level 5
		'09000-12999 is Level 6
		'13000-18199 is Level 7
		'18200-24799 is Level 8
		'24800-32999 is Level 9
		'33000-42699 is Level 10
		'42700-53899 is Level 11
		'53900-66599 is Level 12
		'66600-80799 is Level 13
		'80800-96499 is Level 14
		'96500-113699 is Level 15
		'113700-132399 is Level 16
		'132400-152599 is Level 17
		'152600-174299 is Level 18
		'174300-197499 is Level 19
		'197500 is Level 20
		Dim EXPArea0(3) As Byte
        Dim EXPArea0Value As ULong
        Dim EXPArea0Offset113Value As ULong
        Dim EXPArea1Offset113(3) As Byte
        Dim EXPArea0Offset118Value As ULong
        Dim EXPArea0Offset118(3) As Byte

        Dim EXPArea1(3) As Byte
		Dim EXPArea1Value As ULong
		Dim EXPArea1Offset2D3Value As ULong
		Dim EXPArea1Offset2D3(3) As Byte
		Dim EXPArea1Offset2D8Value As ULong
		Dim EXPArea1Offset2D8(3) As Byte

		Dim TotalEXP As ULong

        'Remember all values are offset 1C0
        Dim Counter As Integer = 0
        Do Until Counter = 2
            EXPArea0(Counter) = WholeFile(&H80 + Counter)
            Counter += 1
        Loop

        'EXPArea0(2) = 0
        'EXPArea0(3) = 0
        'UInt32 must be 4 bytes.
        EXPArea0Value = BitConverter.ToUInt32(EXPArea0, 0)

        Counter = 0
        Do Until Counter = 2
            EXPArea1Offset113(Counter) = WholeFile(&H113 + Counter)
            Counter += 1
        Loop
        'EXPArea1(2) = 0
        'EXPArea1(3) = 0
        EXPArea0Offset113Value = BitConverter.ToUInt32(EXPArea1Offset113, 0)

        Counter = 0
        Do Until Counter = 3
            EXPArea0Offset118(Counter) = WholeFile(&H118 + Counter)
            Counter += 1
        Loop
        'EXPArea1Offset2D3(2) = 0
        'EXPArea1Offset2D3(3) = 0
        EXPArea0Offset118Value = BitConverter.ToUInt32(EXPArea0Offset118, 0)



        'Area1
        Counter = 0
		Do Until Counter = 2
			EXPArea1(Counter) = WholeFile(&H240 + Counter)
			Counter += 1
		Loop
        'EXPArea1(2) = 0
        'EXPArea1(3) = 0
        EXPArea1Value = BitConverter.ToUInt32(EXPArea1, 0)


		Counter = 0
		Do Until Counter = 2
			EXPArea1Offset2D3(Counter) = WholeFile(&H2D3 + Counter)
			Counter += 1
		Loop
        'EXPArea1Offset2D3(2) = 0
        'EXPArea1Offset2D3(3) = 0
        EXPArea1Offset2D3Value = BitConverter.ToUInt32(EXPArea1Offset2D3, 0)


		Counter = 0
        Do Until Counter = 3
            EXPArea1Offset2D8(Counter) = WholeFile(&H2D8 + Counter)
            Counter += 1
        Loop
        'EXPArea1Offset2D8(3) = 0
        EXPArea1Offset2D8Value = BitConverter.ToUInt32(EXPArea1Offset2D8, 0)

        If Area0 > Area1 Then
            TotalEXP = EXPArea0Value + EXPArea0Offset113Value + EXPArea0Offset118Value
        ElseIf Area1 > Area0 Then
            TotalEXP = EXPArea1Value + EXPArea1Offset2D3Value + EXPArea1Offset2D8Value
        ElseIf Area0 = Area1 Then
            TotalEXP = EXPArea0Value + EXPArea0Offset113Value + EXPArea0Offset118Value
        End If

        Select Case TotalEXP
			Case 0 To 999
				frmMain.numLevel.Value = 1
			Case 1000 To 2199
				frmMain.numLevel.Value = 2
			Case 2200 To 3799
				' Is Level 3
				frmMain.numLevel.Value = 3
			Case 3800 To 5999
				' Is Level 4
				frmMain.numLevel.Value = 4
			Case 6000 To 8999
				'Is Level 5
				frmMain.numLevel.Value = 5
			Case 9000 To 12999
				'Is Level 6
				frmMain.numLevel.Value = 6
			Case 13000 To 18199
				'Is Level 7
				frmMain.numLevel.Value = 7
			Case 18200 To 24799
				'Is Level 8
				frmMain.numLevel.Value = 8
			Case 24800 To 32999
				'Is Level 9
				frmMain.numLevel.Value = 9
			Case 33000 To 42699
				'Is Level 10
				frmMain.numLevel.Value = 10
			Case 42700 To 53899
				'Is Level 11
				frmMain.numLevel.Value = 11
			Case 53900 To 66599
				'Is Level 12
				frmMain.numLevel.Value = 12
			Case 66600 To 80799
				'Is Level 13
				frmMain.numLevel.Value = 13
			Case 80800 To 96499
				'Is Level 14
				frmMain.numLevel.Value = 14
			Case 96500 To 113699
				'Is Level 15
				frmMain.numLevel.Value = 15
			Case 113700 To 132399
				'Is Level 16
				frmMain.numLevel.Value = 16
			Case 132400 To 152599
				'Is Level 17
				frmMain.numLevel.Value = 17
			Case 152600 To 174299
				'Is Level 18
				frmMain.numLevel.Value = 18
			Case 174300 To 197499
				'Is Level 19
				frmMain.numLevel.Value = 19
			Case 197500
				'Is Level 20
				frmMain.numLevel.Value = 20
		End Select
		'MessageBox.Show(TotalEXP)
	End Sub
	Shared Sub WriteEXP()
		'We need to setup THREE Byte arrays
		Dim EXP1 As Byte()
		Dim EXP2 As Byte()
		Dim EXP3 As Byte()
		ReDim Preserve EXP1(1) 'Correct
		ReDim Preserve EXP2(1) 'Correct
		ReDim Preserve EXP3(2) 'The third EXP Offset is Three Bytes in size.
		'For Fun, we could in theory write a random value between the two min/max
		Select Case frmMain.numLevel.Value
            Case 1
                '00000-00999 is Level 1
                EXP1 = BitConverter.GetBytes(0)
                EXP2 = BitConverter.GetBytes(0)
				EXP3 = BitConverter.GetBytes(0)
			Case 2
				'01000-02199 is Level 2
				EXP1 = BitConverter.GetBytes(1000)
				EXP2 = BitConverter.GetBytes(0)
				EXP3 = BitConverter.GetBytes(0)
			Case 3
				'02200-03799 is Level 3
				EXP1 = BitConverter.GetBytes(2200)
				EXP2 = BitConverter.GetBytes(0)
				EXP3 = BitConverter.GetBytes(0)
			Case 4
				'03800-05999 is Level 4
				EXP1 = BitConverter.GetBytes(3800)
				EXP2 = BitConverter.GetBytes(0)
				EXP3 = BitConverter.GetBytes(0)
			Case 5
				'06000-08999 is Level 5
				EXP1 = BitConverter.GetBytes(6000)
				EXP2 = BitConverter.GetBytes(0)
				EXP3 = BitConverter.GetBytes(0)
			Case 6
				'09000-12999 is Level 6
				EXP1 = BitConverter.GetBytes(9000)
				EXP2 = BitConverter.GetBytes(0)
				EXP3 = BitConverter.GetBytes(0)
			Case 7
				'13000-18199 is Level 7
				EXP1 = BitConverter.GetBytes(13000)
				EXP2 = BitConverter.GetBytes(0)
				EXP3 = BitConverter.GetBytes(0)
			Case 8
				'18200-24799 is Level 8
				EXP1 = BitConverter.GetBytes(18200)
				EXP2 = BitConverter.GetBytes(0)
				EXP3 = BitConverter.GetBytes(0)
			Case 9
				'24800-32999 is Level 9
				EXP1 = BitConverter.GetBytes(24800)
				EXP2 = BitConverter.GetBytes(0)
				EXP3 = BitConverter.GetBytes(0)
			Case 10
				'33000-42699 is Level 10
				EXP1 = BitConverter.GetBytes(33000)
				EXP2 = BitConverter.GetBytes(0)
				EXP3 = BitConverter.GetBytes(0)
			Case 11
				'42700-53899 is Level 11
				EXP1 = BitConverter.GetBytes(33000)
				EXP2 = BitConverter.GetBytes(9700)
				EXP3 = BitConverter.GetBytes(0)
			Case 12
				'53900-66599 is Level 12
				EXP1 = BitConverter.GetBytes(33000)
				EXP2 = BitConverter.GetBytes(20900)
				EXP3 = BitConverter.GetBytes(0)
			Case 13
				'66600-80799 is Level 13
				EXP1 = BitConverter.GetBytes(33000)
				EXP2 = BitConverter.GetBytes(33000)
				EXP3 = BitConverter.GetBytes(0)
			Case 14
				'80800-96499 is Level 14
				EXP1 = BitConverter.GetBytes(33000)
				EXP2 = BitConverter.GetBytes(47800)
				EXP3 = BitConverter.GetBytes(0)
			Case 15
				'96500-113699 is Level 15
				EXP1 = BitConverter.GetBytes(33000)
				EXP2 = BitConverter.GetBytes(63500)
				EXP3 = BitConverter.GetBytes(0)
			Case 16
				'113700-132399 is Level 16
				EXP1 = BitConverter.GetBytes(33000)
				EXP2 = BitConverter.GetBytes(63500)
				EXP3 = BitConverter.GetBytes(17200)
			Case 17
				'132400-152599 is Level 17
				EXP1 = BitConverter.GetBytes(33000)
				EXP2 = BitConverter.GetBytes(63500)
				EXP3 = BitConverter.GetBytes(35900)
			Case 18
				'152600-174299 is Level 18
				EXP1 = BitConverter.GetBytes(33000)
				EXP2 = BitConverter.GetBytes(63500)
				EXP3 = BitConverter.GetBytes(56100)
			Case 19
				'174300-197499 is Level 19
				EXP1 = BitConverter.GetBytes(33000)
				EXP2 = BitConverter.GetBytes(63500)
				EXP3 = BitConverter.GetBytes(77800)
			Case 20
				'197500 is Level 20
				EXP1 = BitConverter.GetBytes(33000)
				EXP2 = BitConverter.GetBytes(63500)
				EXP3 = BitConverter.GetBytes(101000)
		End Select

        'Expermential Edit.  Should pass future checks?
        'Area 0 Exp
        'Exit Sub
        WholeFile(&H80) = EXP1(0)
        WholeFile(&H81) = EXP1(1)
        If frmMain.numLevel.Value > 10 Then
            WholeFile(&H113) = EXP2(0)
            WholeFile(&H114) = EXP2(1)
            If frmMain.numLevel.Value > 15 Then
                WholeFile(&H118) = EXP3(0)
                WholeFile(&H119) = EXP3(1)
                WholeFile(&H11A) = EXP3(2)
                'MessageBox.Show("Area0")
            End If
        Else
            WholeFile(&H113) = &H0
            WholeFile(&H114) = &H0
            WholeFile(&H118) = &H0
            WholeFile(&H119) = &H0
            WholeFile(&H11A) = &H0
        End If

        'MessageBox.Show("EXP0: " & EXP1 + EXP2 + EXP3
        'MessageBox.Show("EXP1: " & EXPArea1Value + EXPArea1Offset2D3Value + EXPArea1Offset2D8Value)
        'Area 1 EXP
        WholeFile(&H240) = EXP1(0)
        WholeFile(&H241) = EXP1(1)
        If frmMain.numLevel.Value > 10 Then
            WholeFile(&H2D3) = EXP2(0)
            WholeFile(&H2D4) = EXP2(1)
            If frmMain.numLevel.Value > 15 Then
                WholeFile(&H2D8) = EXP3(0)
                WholeFile(&H2D9) = EXP3(1)
                WholeFile(&H2DA) = EXP3(2)
            End If
        Else
            WholeFile(&H2D3) = &H0
            WholeFile(&H2D4) = &H0
            WholeFile(&H2D8) = &H0
            WholeFile(&H2D9) = &H0
            WholeFile(&H2DA) = &H0
        End If
		'If Area0 > Area1 Then

		'ElseIf Area1 > Area0 Then

		'ElseIf Area0 = Area1 Then

		'End If
	End Sub
End Class

