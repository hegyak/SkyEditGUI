Imports System.Security.Cryptography
Imports System.Text
Imports SkyReader_GUI.FigureIO
Public Class AES
    'Public Shared HeaderBytes() As Byte = Nothing
    'Encryption Notes
    'So for 24 block it will be-
    '<first 0x20 bytes of sector 0> <24> <0x35-byte constant>

    '<first 0x20 bytes of sector 0> <1-byte block index> <0x35-byte constant>
    'The First 20 Bytes is 32 Decimal Values
    'Why is the Middle Block 24 as Hex?
    'The Constant is: 53 Values Decimal

    'THEN, MD5 Hash the above bytes.
    'Encryption/Decryption Code

    'The Following blocks (Offsets) are NOT encrypted
    'All Offsets are in Hex and counted as such.
    '0x000 Through 0x70
    '0x0B0
    '0x0F0
    '0x130
    '0x170
    '0x1B0
    '0x1F0
    '0x230
    '0x270
    '0x2B0
    '0x2F0
    '0x330
    '0x370
    '0x3B0
    '0X3F0

    Shared HeaderBytes(31) As Byte
    Public Shared FullKey(85) As Byte
    Shared AES As New RijndaelManaged
    Public Shared Magic() As Byte = {&H20, &H43, &H6F, &H70, &H79, &H72, &H69, &H67, &H68, &H74, &H20, &H28, &H43, &H29, &H20, &H32, &H30, &H31, &H30, &H20, &H41, &H63, &H74, &H69, &H76, &H69, &H73, &H69, &H6F, &H6E, &H2E, &H20, &H41, &H6C, &H6C, &H20, &H52, &H69, &H67, &H68, &H74, &H73, &H20, &H52, &H65, &H73, &H65, &H72, &H76, &H65, &H64, &H2E, &H20}


    'Get the Header
    Shared Sub Header()
		AES.Padding = PaddingMode.Zeros
		AES.Mode = CipherMode.ECB

		Dim Counter As Integer = 0  'Necessary to add one to the Byte array Offset
        'Dim HeadByteCounter As Integer = 0
        'Go up to 0x21 to get all 32 Bytes of Header
        Do Until Counter = 32
            HeaderBytes(Counter) = WholeFile(Counter)
            'HeadByteCounter += &H1
            Counter += 1
        Loop
        'MessageBox.Show(BitConverter.ToString(HeaderBytes), "Head")
    End Sub

    '#TODO:
    'Get 16 Bytes read in to Byte array for Encryption/Decryption

    Shared Sub GetKey(ByVal AreaKey As Byte)
        ReDim FullKey(85) 'Reset and don't preserve
        HeaderBytes.CopyTo(FullKey, 0)
        'MessageBox.Show(BitConverter.ToString(FullKey), "Header into FullKey")
        FullKey(32) = AreaKey
        'MessageBox.Show(BitConverter.ToString(FullKey), "Header and Area into FullKey")
        Magic.CopyTo(FullKey, 33)

        'FullKey now has the Correct Data.
    End Sub
    'Encrypt
    Shared Function AESE(ByVal input As Byte(), ByVal key As Byte()) As Byte()
        Dim AES As New RijndaelManaged
        AES.Padding = PaddingMode.Zeros
        AES.Key = CalculateMD5Hash(key)
        AES.Mode = CipherMode.ECB
        Dim DESEncrypter As ICryptoTransform = AES.CreateEncryptor
        Dim Buffer As Byte() = input
        Return DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
    End Function
    'Decrypt
    Shared Function AESD(ByVal input As Byte(), ByVal key As Byte()) As Byte()
        Dim AES As New RijndaelManaged
        AES.Padding = PaddingMode.Zeros
        AES.Key = CalculateMD5Hash(key)
        AES.Mode = CipherMode.ECB
        Dim DESDecrypter As ICryptoTransform = AES.CreateDecryptor
        Dim Buffer As Byte() = input
        Return DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
    End Function

    'Calculate MD5
    Public Shared Function CalculateMD5Hash(ByVal input As Byte()) As Byte()
		Dim md5 As MD5 = MD5.Create()
		Dim hash As Byte() = md5.ComputeHash(input)
		Return hash
	End Function

	'Return a Hex String from Byte Array.
	Public Shared Function ByteArrayToString(ba As Byte()) As String
		Dim hex As New StringBuilder(ba.Length * 2)
		For Each b As Byte In ba
			hex.AppendFormat("{0:x2}", b)
		Next
		Return hex.ToString()
	End Function

    'This Generates the Bytes from the Hex String.
    Public Shared Function StringToByteArray(s As String) As Byte()
        ' remove any spaces from, e.g. "A0 20 34 34"
        's = s.Replace(" "c, "")
        ' make sure we have an even number of digits
        If (s.Length And 1) = 1 Then
            Throw New FormatException("Odd string length when even string length is required.")
        End If

        ' calculate the length of the byte array and dim an array to that
        Dim nBytes = s.Length \ 2
        Dim a(nBytes - 1) As Byte

        ' pick out every two bytes and convert them from hex representation
        For i = 0 To nBytes - 1
            a(i) = Convert.ToByte(s.Substring(i * 2, 2), 16)
        Next

        Return a
    End Function
End Class
