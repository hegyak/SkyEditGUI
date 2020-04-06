Imports SkyReader_GUI.frmMain
Imports System.Text

Public Class Nickname

	Public Shared Function IsUnicode(input As String) As Boolean
		Dim asciiBytesCount = Encoding.ASCII.GetByteCount(input)
		Dim unicodBytesCount = Encoding.UTF8.GetByteCount(input)
		Return asciiBytesCount <> unicodBytesCount
	End Function

	Shared Sub GetNickname()
		Dim Name1 As String
		Dim Name2 As String

		Dim BadName0 As Boolean
		Dim BadName1 As Boolean

		Dim FullName0 As String
		Dim FullName1 As String
		Dim NameBytes(15) As Byte
		'Area0 Name
		Dim Counter As Integer = 0
        Do Until Counter = 16
            NameBytes(Counter) = WholeFile(&HA0 + Counter)
            Counter += 1
        Loop
        Counter = 0

        Name1 = Encoding.Unicode.GetString(NameBytes)
        ReDim NameBytes(13) 'Don't preserve.  We are going to overwrite it.
		Counter = 0
		Do Until Counter = 14
			NameBytes(Counter) = WholeFile(&HC0 + Counter)
			Counter += 1
		Loop

		Name2 = Encoding.Unicode.GetString(NameBytes)
		FullName0 = Name1 & Name2
		BadName0 = IsUnicode(FullName0)

		Counter = 0
		ReDim NameBytes(15) 'Don't preserve.  We are going to overwrite it.
		Do Until Counter = 16
			NameBytes(Counter) = WholeFile(&H260 + Counter)
			Counter += 1
		Loop
		Name1 = Encoding.Unicode.GetString(NameBytes)


		ReDim NameBytes(13) 'Don't preserve.  We are going to overwrite it.
		Counter = 0
		Do Until Counter = 14
			NameBytes(Counter) = WholeFile(&H280 + Counter)
			Counter += 1
		Loop
		Name2 = Encoding.Unicode.GetString(NameBytes)
		FullName1 = Name1 & Name2
		BadName1 = IsUnicode(FullName1)

		If BadName1 = True And BadName0 = True Then
            'MessageBox.Show("Loaded Encrypted Figure")
            blnEncrypted = True
		End If

        If Area0 > Area1 Then
            frmMain.txtName.Text = FullName0
        ElseIf Area1 > Area0 Then
            frmMain.txtName.Text = FullName1
        ElseIf Area0 = Area1 Then
            frmMain.txtName.Text = FullName0
        End If
    End Sub
	Shared Sub SetNickname()
		'Area 0
		'0x0A0 to 0x0AF
		'0x0C0 to 0x0CC

		'Area 1
		'0x260 to 0x26F
		'0x280 to 0x28C

		Dim Bytes1(16) As Byte
		Dim Bytes2(14) As Byte
		Dim Name1 As String
		Dim Name2 As String
		If frmMain.txtName.Text.Length > 8 Then
			'Split string at 8 Bytes
			Name1 = frmMain.txtName.Text.Remove(8, frmMain.txtName.Text.Length - 8)
			Name2 = frmMain.txtName.Text.Remove(0, 8)
			Bytes1 = Encoding.Unicode.GetBytes(Name1)
			Bytes2 = Encoding.Unicode.GetBytes(Name2)
		Else
			Bytes1 = Encoding.Unicode.GetBytes(frmMain.txtName.Text)
		End If
		'I need this array to be 16 bytes.
		ReDim Preserve Bytes1(16)
		'I need this array to be 14 bytes
		ReDim Preserve Bytes2(14)

		Dim Counter As Integer = 0
		'If Area0 > Area1 Then
		'Area 0 Nickname
		Do Until Counter = 17
			WholeFile(&HA0 + Counter) = Bytes1(Counter)
			Counter += 1
		Loop

		Counter = 0
		Do Until Counter = 14
			WholeFile(&HC0 + Counter) = Bytes2(Counter)
			Counter += 1
		Loop
		'ElseIf Area1 > Area0 Then
		'Area 1 Nickname
		Counter = 0
		Do Until Counter = 17
			WholeFile(&H260 + Counter) = Bytes1(Counter)
			Counter += 1
		Loop

		Counter = 0
		Do Until Counter = 14
			WholeFile(&H280 + Counter) = Bytes2(Counter)
			Counter += 1
		Loop

	End Sub
End Class
