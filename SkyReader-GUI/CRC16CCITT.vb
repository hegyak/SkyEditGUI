Imports SkyReader_GUI.frmMain
Public Class CRC16CCITT

	'Our Checksum that will be generated.

	Public Shared Bytes() As Byte = Nothing
	Public Shared Counter As Integer = 0

	Public Shared Area0Type4CRC As String
	Public Shared Area1Type4CRC As String

	Public Shared Area0Type3CRC As String
	Public Shared Area1Type3CRC As String

	Public Shared Area0Type2CRC As String
	Public Shared Area1Type2CRC As String

	Public Shared Area0Type1CRC As String
	Public Shared Area1Type1CRC As String

	Public Shared Area0Type0CRC As String

	'Type 0 Checksum is all the bytes from 0x000 to 0x01D.
	'Type 1 Checksum is The Bytes from 0x080 to 0x08F, with the Bytes 0x08E and 0x08F being set to 05 and 00 respectively.
	'Type 2 Checksum is The NEXT Four Blocks (Though we are only reading three of them), Excluding the Block 0x0B if we are going from Offset 0x08 and block 0x270 if we are going from Block 0x240.
	'Type 3 Checksum is Like Type 2, but add 14 BLOCKS of Zero at the end of the Array.
	'Type 4 Checksum is The NEXT Four Blocks, after Type 2's Block.  It is like Type 2 except that the Inital Two bytes must be set to 06 and 01 respectively.

	'Yes, Type 3 and Type 2 must be done first before we can do Type 1

	Public Shared Function GetCrc() As String
		Dim crc As Integer = &HFFFF ' Starting value 
		Dim Polynom As Integer = &H1021 ' As in X^16 + X^12 + X^5 + 1 

		Dim bit As Boolean
		Dim c15 As Boolean
		Dim i As Integer

		' Calculate the CRC: 
		For Each b As Byte In Bytes
			For i = 0 To 7
				bit = ((b >> (7 - i) And 1)) '= 1) 
				c15 = ((crc >> 15 And 1)) '= 1) 
				crc <<= 1
				If c15 Xor bit Then
					crc = crc Xor Polynom
				End If
			Next
		Next

		crc = crc And &HFFFF

		' De crc-variable is a decimal value. We return a Hex-value, so we need to convert this to hex. 
		' The 16 in the Convert-method means the Hex-base. 
		Dim retVal As String = Convert.ToString(crc, 16)

		If retVal.Length <> 4 Then
			Do Until retVal.Length = 4
				retVal = "0" & retVal
			Loop
		End If
		'MessageBox.Show(retVal)
		Return retVal

	End Function

	Shared Sub WriteCheckSums()
		Dim NewChecksumType0(1) As Byte
		Dim NewChecksumArea0Type1(1) As Byte
		Dim NewChecksumArea0Type2(1) As Byte
		Dim NewChecksumArea0Type3(1) As Byte
		Dim NewChecksumArea0Type4(1) As Byte

		Dim NewChecksumArea1Type1(1) As Byte
		Dim NewChecksumArea1Type2(1) As Byte
		Dim NewChecksumArea1Type3(1) As Byte
		Dim NewChecksumArea1Type4(1) As Byte


        'Since we are getting back a String value, I use the Function to convert that String back to a Byte Array.
        'Type 0

        CalculateSerialXOR()
        NewChecksumType0 = AES.StringToByteArray(CalculateType0)

		'Type 3
		NewChecksumArea0Type3 = AES.StringToByteArray(CalculateArea0Type3)
		NewChecksumArea1Type3 = AES.StringToByteArray(CalculateArea1Type3)

		'Type 2
		NewChecksumArea0Type2 = AES.StringToByteArray(CalculateArea0Type2)
		NewChecksumArea1Type2 = AES.StringToByteArray(CalculateArea1Type2)

		'Type 4
		NewChecksumArea0Type4 = AES.StringToByteArray(CalculateArea0Type4)
		NewChecksumArea1Type4 = AES.StringToByteArray(CalculateArea1Type4)
		'We Seek after we Generate the Checksum to set our position
		'We do this because we have been ALL over this file.

		'Type 0
		WholeFile(&H1E) = NewChecksumType0(0)
		WholeFile(&H1F) = NewChecksumType0(1)

		'Type 3
		WholeFile(&H8A) = NewChecksumArea0Type3(0)
		WholeFile(&H8B) = NewChecksumArea0Type3(1)

		WholeFile(&H24A) = NewChecksumArea1Type3(0)
		WholeFile(&H24B) = NewChecksumArea1Type3(1)

		'Type 2
		WholeFile(&H8C) = NewChecksumArea0Type2(0)
		WholeFile(&H8D) = NewChecksumArea0Type2(1)

		WholeFile(&H24C) = NewChecksumArea1Type2(0)
		WholeFile(&H24D) = NewChecksumArea1Type2(1)

		'Type 4
		WholeFile(&H110) = NewChecksumArea0Type4(0)
		WholeFile(&H111) = NewChecksumArea0Type4(1)

		WholeFile(&H2D0) = NewChecksumArea1Type4(0)
		WholeFile(&H2D1) = NewChecksumArea1Type4(1)

		'We calculate Type 1 last because of it's reliance on the other checksums
		'Type 1
		NewChecksumArea0Type1 = AES.StringToByteArray(CalculateArea0Type1)
		NewChecksumArea1Type1 = AES.StringToByteArray(CalculateArea1Type1)

		WholeFile(&H8E) = NewChecksumArea0Type1(0)
		WholeFile(&H8F) = NewChecksumArea0Type1(1)

		WholeFile(&H24E) = NewChecksumArea1Type1(0)
        WholeFile(&H24F) = NewChecksumArea1Type1(1)


    End Sub

	Shared Sub Checksums()
		'Get Type 0 Checksum
		VerifyArea0Type0()
        VerifySerialXOR()
        'Get Type 3 Checksum
        VerifyArea0Type3()
		VerifyArea1Type3()

		'Get Type 2 Checksum
		VerifyArea0Type2()
		VerifyArea1Type2()

		'Get Type 1 Checksum
		VerifyArea0Type1()
		VerifyArea1Type1()

		'Get Type 4 Checksum
		VerifyArea0Type4()
		VerifyArea1Type4()
	End Sub

#Region " Type 4 "
	Public Shared Function CalculateArea0Type4() As String
		'Generate Type 1 Checksum
		Counter = 0
		Dim LoopCounter As Integer = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(63)
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H110 + LoopCounter)

			Counter += 1
			LoopCounter += 1
		Loop
		'MessageBox.Show(Hex(Bytes(31)))
		LoopCounter = 0
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H140 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		'MessageBox.Show(Hex(Bytes(63)))
		'We manually set these two bytes
		Bytes(0) = &H6
		Bytes(1) = &H1
		'Get CRC based on the bytes.
		Area0Type4CRC = GetCrc().ToUpper
		Area0Type4CRC = Area0Type4CRC.Remove(0, 2) & Area0Type4CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area0Type4CRC
	End Function

	Public Shared Function VerifyArea0Type4()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H110).ToString("X2") & WholeFile(&H111).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum <> CalculateArea0Type4() Then
			frmMain.picArea0Type4.BackColor = Color.Red
		Else
			frmMain.picArea0Type4.BackColor = Color.Green
		End If
		Return ""
	End Function

	Public Shared Function CalculateArea1Type4() As String
		'Generate Type 1 Checksum
		Counter = 0
		Dim LoopCounter As Integer = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(63)
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H2D0 + LoopCounter)

			Counter += 1
			LoopCounter += 1
		Loop

		LoopCounter = 0
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H300 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		'We manually set these two bytes
		Bytes(0) = &H6
		Bytes(1) = &H1
		'Get CRC based on the bytes.
		Area1Type4CRC = GetCrc().ToUpper
		Area1Type4CRC = Area1Type4CRC.Remove(0, 2) & Area1Type4CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area1Type4CRC
	End Function

	Public Shared Function VerifyArea1Type4()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H2D0).ToString("X2") & WholeFile(&H2D1).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum <> CalculateArea1Type4() Then
			frmMain.picArea1Type4.BackColor = Color.Red
		Else
			frmMain.picArea1Type4.BackColor = Color.Green
		End If
		Return ""
	End Function
#End Region

#Region " Type 3 "
	Public Shared Function CalculateArea0Type3() As String
		'Generate Type 1 Checksum
		Counter = 0
		Dim LoopCounter As Integer = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(271)
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &HD0 + LoopCounter)

			Counter += 1
			LoopCounter += 1
		Loop
		LoopCounter = 0
		Do Until LoopCounter = 16
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H100 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		'Get CRC based on the bytes.
		Area0Type3CRC = GetCrc().ToUpper
		Area0Type3CRC = Area0Type3CRC.Remove(0, 2) & Area0Type3CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area0Type3CRC
	End Function

	Public Shared Function VerifyArea0Type3()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H8A).ToString("X2") & WholeFile(&H8B).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum <> CalculateArea0Type3() Then
			'MessageBox.Show(OldCheckSum & " is Not " & CalculateArea0Type3())
			frmMain.picArea0Type3.BackColor = Color.Red
		Else
			frmMain.picArea0Type3.BackColor = Color.Green
		End If
		Return ""
	End Function

	Public Shared Function CalculateArea1Type3() As String
		'Generate Type 1 Checksum
		Counter = 0
		Dim LoopCounter As Integer = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(271)
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H290 + LoopCounter)

			Counter += 1
			LoopCounter += 1
		Loop
		LoopCounter = 0
		Do Until LoopCounter = 16
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H2C0 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		'Get CRC based on the bytes.
		Area1Type3CRC = GetCrc().ToUpper
		Area1Type3CRC = Area1Type3CRC.Remove(0, 2) & Area1Type3CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area1Type3CRC
	End Function

	Public Shared Function VerifyArea1Type3()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H24A).ToString("X2") & WholeFile(&H24B).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum <> CalculateArea1Type3() Then
			'MessageBox.Show(OldCheckSum & " is Not " & CalculateArea1Type3())
			frmMain.picArea1Type3.BackColor = Color.Red
		Else
			frmMain.picArea1Type3.BackColor = Color.Green
		End If
		Return ""
	End Function
#End Region

#Region " Type 2 "
	Public Shared Function CalculateArea0Type2() As String
		'Generate Type 1 Checksum
		Counter = 0
		Dim LoopCounter As Integer = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(47)
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H90 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		LoopCounter = 0
		Do Until LoopCounter = 16
			Bytes(Counter) = Buffer.GetByte(WholeFile, &HC0 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		'Get CRC based on the bytes.
		Area0Type2CRC = GetCrc().ToUpper
		Area0Type2CRC = Area0Type2CRC.Remove(0, 2) & Area0Type2CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area0Type2CRC
	End Function

	Public Shared Function VerifyArea0Type2()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H8C).ToString("X2") & WholeFile(&H8D).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum <> CalculateArea0Type2() Then
			'MessageBox.Show(OldCheckSum & " is Not " & CalculateArea0Type2())
			frmMain.picArea0Type2.BackColor = Color.Red
		Else
			frmMain.picArea0Type2.BackColor = Color.Green
		End If
		Return ""
	End Function

	Public Shared Function CalculateArea1Type2() As String
		'Generate Type 1 Checksum
		Counter = 0
		Dim LoopCounter As Integer = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(47)
		Do Until LoopCounter = 32
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H250 + LoopCounter)

			Counter += 1
			LoopCounter += 1
		Loop
		LoopCounter = 0
		Do Until LoopCounter = 16
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H280 + LoopCounter)
			Counter += 1
			LoopCounter += 1
		Loop
		'Get CRC based on the bytes.
		Area1Type2CRC = GetCrc().ToUpper
		Area1Type2CRC = Area1Type2CRC.Remove(0, 2) & Area1Type2CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area1Type2CRC
	End Function

	Public Shared Function VerifyArea1Type2()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H24C).ToString("X2") & WholeFile(&H24D).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum <> CalculateArea1Type2() Then
			'MessageBox.Show(OldCheckSum & " is Not " & CalculateArea1Type2())
			frmMain.picArea1Type2.BackColor = Color.Red
		Else
			frmMain.picArea1Type2.BackColor = Color.Green
		End If
		Return ""
	End Function
#End Region

#Region " Type 1 "
	Public Shared Function CalculateArea0Type1() As String
		'Generate Type 1 Checksum
		Counter = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(15)
		Do Until Counter = 15
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H80 + Counter)
			Counter += 1
		Loop
		'We manually set these two bytes
		Bytes(14) = &H5
		Bytes(15) = &H0
		'Get CRC based on the bytes.
		Area0Type1CRC = GetCrc().ToUpper
		Area0Type1CRC = Area0Type1CRC.Remove(0, 2) & Area0Type1CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area0Type1CRC
	End Function

	Public Shared Function VerifyArea0Type1()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H8E).ToString("X2") & WholeFile(&H8F).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum <> CalculateArea0Type1() Then
			frmMain.picArea0Type1.BackColor = Color.Red
		Else
			frmMain.picArea0Type1.BackColor = Color.Green
		End If
		Return ""
	End Function

	Public Shared Function CalculateArea1Type1() As String
		'Generate Type 1 Checksum
		Counter = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(15)
		Do Until Counter = 15
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H240 + Counter)
			Counter += 1
		Loop
		'We manually set these two bytes
		Bytes(14) = &H5
		Bytes(15) = &H0
		'Get CRC based on the bytes.
		Area1Type1CRC = GetCrc().ToUpper
		Area1Type1CRC = Area1Type1CRC.Remove(0, 2) & Area1Type1CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area1Type1CRC
	End Function

	Public Shared Function VerifyArea1Type1()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H24E).ToString("X2") & WholeFile(&H24F).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum <> CalculateArea1Type1() Then
			frmMain.picArea1Type1.BackColor = Color.Red
		Else
			frmMain.picArea1Type1.BackColor = Color.Green
		End If
		Return ""
	End Function
#End Region

#Region " Type 0 "
    Public Shared Sub GenerateNewSerial()
        Dim Serial(3) As Byte
        Dim rnd As Random = New Random()

        rnd.NextBytes(Serial)
        WholeFile(0) = Serial(0)
        WholeFile(1) = Serial(1)
        WholeFile(2) = Serial(2)
        WholeFile(3) = Serial(3)

    End Sub
    Public Shared Sub CalculateSerialXOR()
        'Serial is first four bytes, and the XOR of them at Byte 5 0x4
        Dim Serial(3) As Byte
        Serial(0) = WholeFile(&H0)
        Serial(1) = WholeFile(&H1)
        Serial(2) = WholeFile(&H2)
        Serial(3) = WholeFile(&H3)
        Dim SerialXOR(0) As Byte
        SerialXOR(0) = Serial(0) Xor Serial(1) Xor Serial(2) Xor Serial(3)
        WholeFile(&H4) = SerialXOR(0)
    End Sub
    Public Shared Sub VerifySerialXOR()
        'This generally should be good.
        ReDim Bytes(3)
        Counter = 0
        Do Until Counter = 4
            Bytes(Counter) = Buffer.GetByte(WholeFile, &H0 + Counter)
            Counter += 1
        Loop
        Dim SerialXOR(0) As Byte
        SerialXOR(0) = Bytes(0) Xor Bytes(1) Xor Bytes(2) Xor Bytes(3)
        Dim XORValue As Byte = Buffer.GetByte(WholeFile, &H0 + Counter)
        If SerialXOR(0) = XORValue Then
            frmMain.picSerial.BackColor = Color.Green
        Else
            frmMain.picSerial.BackColor = Color.Red
        End If
    End Sub
    Public Shared Function CalculateType0() As String
		'Generate Type 0 Checksum
		'Read in Thirty Bytes.  Which gives us the headers, and not the checksum.
		Counter = 0
		'We ReDim to resize our Bytes Array
		ReDim Bytes(29)
		Do Until Counter = 30
			Bytes(Counter) = Buffer.GetByte(WholeFile, &H0 + Counter)
			Counter += 1
		Loop
		'Get CRC based on the bytes.
		Area0Type0CRC = GetCrc().ToUpper
		Area0Type0CRC = Area0Type0CRC.Remove(0, 2) & Area0Type0CRC.Remove(2, 2)
		'Give back our Checksum
		Return Area0Type0CRC
	End Function

	Public Shared Function VerifyArea0Type0()
		Dim OldCheckSum As String
		OldCheckSum = WholeFile(&H1E).ToString("X2") & WholeFile(&H1F).ToString("X2")
		'Now I need to get the Checksum
		If OldCheckSum <> CalculateType0() Then
			frmMain.picHeader.BackColor = Color.Red
		Else
			frmMain.picHeader.BackColor = Color.Green
		End If
		Return ""
	End Function
#End Region
End Class