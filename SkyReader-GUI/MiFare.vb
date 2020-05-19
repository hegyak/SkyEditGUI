Imports System.IO
Imports SkyReader_GUI.frmMain
Public Class MiFare
    Shared Sub Detection()
        'As such this will only work so far.
        'Offsets for Checking
        'TODO:
        'Determine what I am checking and why I am getting what I get.
        '0x030
        '0x070
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
        '0x3F0

        'Five Bytes Read
        Dim AccessControl01(4) As Byte
        Dim AccessControl02(4) As Byte
        Dim AccessControl03(4) As Byte
        Dim AccessControl04(4) As Byte
        Dim AccessControl05(4) As Byte
        Dim AccessControl06(4) As Byte
        Dim AccessControl07(4) As Byte
        Dim AccessControl08(4) As Byte
        Dim AccessControl09(4) As Byte
        Dim AccessControl10(4) As Byte
        Dim AccessControl11(4) As Byte
        Dim AccessControl12(4) As Byte
        Dim AccessControl13(4) As Byte
        Dim AccessControl14(4) As Byte
        Dim AccessControl15(4) As Byte
        Dim AccessControl16(4) As Byte

        'I need to read in Six Bytes from the WholeFile array at the Offset
        Dim Counter As Long = 0  'Necessary to add one to the Byte array Offset
        Do Until Counter = 5
            AccessControl01(Counter) = WholeFile(&H36 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl02(Counter) = WholeFile(&H76 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl03(Counter) = WholeFile(&HB6 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl04(Counter) = WholeFile(&HF6 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl05(Counter) = WholeFile(&H136 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl06(Counter) = WholeFile(&H176 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl07(Counter) = WholeFile(&H1B6 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl08(Counter) = WholeFile(&H1F6 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl09(Counter) = WholeFile(&H236 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl10(Counter) = WholeFile(&H276 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl11(Counter) = WholeFile(&H2B6 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl12(Counter) = WholeFile(&H2F6 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl13(Counter) = WholeFile(&H336 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl14(Counter) = WholeFile(&H376 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl15(Counter) = WholeFile(&H3B6 + Hex(Counter))
            Counter += 1
        Loop
        Counter = 0
        Do Until Counter = 5
            AccessControl16(Counter) = WholeFile(&H3F6 + Hex(Counter))
            Counter += 1
        Loop
        If AES.ByteArrayToString(AccessControl01) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 01 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl02) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 02 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl03) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 03 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl04) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 04 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl05) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 05 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl06) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 06 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl07) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 07 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl08) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 08 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl09) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 09 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl10) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 10 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl11) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 11 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl12) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 12 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl13) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 13 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl14) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 14 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl15) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 15 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If
        If AES.ByteArrayToString(AccessControl16) = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 16 Invalid" & vbNewLine
            Portal.blnAccess = True
        End If

        'Be Tidy
        'br.Close()
        'fs.Close()
    End Sub
    Shared Sub MiFareBlocks(_FileName As String)
        frmLog.Show()
        'Detect if the Access Control Blocks are set to Read Only or not.
        fs = New FileStream(_FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        br = New BinaryReader(fs)
        'Four Bytes Read
        Dim AccessControl01(3) As Byte
        Dim AccessControl02(3) As Byte
        Dim AccessControl03(3) As Byte
        Dim AccessControl04(3) As Byte
        Dim AccessControl05(3) As Byte
        Dim AccessControl06(3) As Byte
        Dim AccessControl07(3) As Byte
        Dim AccessControl08(3) As Byte
        Dim AccessControl09(3) As Byte
        Dim AccessControl10(3) As Byte
        Dim AccessControl11(3) As Byte
        Dim AccessControl12(3) As Byte
        Dim AccessControl13(3) As Byte
        Dim AccessControl14(3) As Byte
        Dim AccessControl15(3) As Byte
        Dim AccessControl16(3) As Byte
        br.BaseStream.Seek(&H36, SeekOrigin.Begin)
        AccessControl01 = br.ReadBytes(4)
        br.BaseStream.Seek(&H76, SeekOrigin.Begin)
        AccessControl02 = br.ReadBytes(4)
        br.BaseStream.Seek(&HB6, SeekOrigin.Begin)
        AccessControl03 = br.ReadBytes(4)
        br.BaseStream.Seek(&HF6, SeekOrigin.Begin)
        AccessControl04 = br.ReadBytes(4)
        br.BaseStream.Seek(&H136, SeekOrigin.Begin)
        AccessControl05 = br.ReadBytes(4)
        br.BaseStream.Seek(&H176, SeekOrigin.Begin)
        AccessControl06 = br.ReadBytes(4)
        br.BaseStream.Seek(&H1B6, SeekOrigin.Begin)
        AccessControl07 = br.ReadBytes(4)
        br.BaseStream.Seek(&H1F6, SeekOrigin.Begin)
        AccessControl08 = br.ReadBytes(4)
        br.BaseStream.Seek(&H236, SeekOrigin.Begin)
        AccessControl09 = br.ReadBytes(4)
        br.BaseStream.Seek(&H276, SeekOrigin.Begin)
        AccessControl10 = br.ReadBytes(4)
        br.BaseStream.Seek(&H2B6, SeekOrigin.Begin)
        AccessControl11 = br.ReadBytes(4)
        br.BaseStream.Seek(&H2F6, SeekOrigin.Begin)
        AccessControl12 = br.ReadBytes(4)
        br.BaseStream.Seek(&H336, SeekOrigin.Begin)
        AccessControl13 = br.ReadBytes(4)
        br.BaseStream.Seek(&H376, SeekOrigin.Begin)
        AccessControl14 = br.ReadBytes(4)
        br.BaseStream.Seek(&H3B6, SeekOrigin.Begin)
        AccessControl15 = br.ReadBytes(4)
        br.BaseStream.Seek(&H3F6, SeekOrigin.Begin)
        AccessControl16 = br.ReadBytes(4)

        'This is Dupe Code?
        'Probably can be imporved?
        If AES.ByteArrayToString(AccessControl01).ToUpper = "0F0F0F69" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Access Block 01 Valid" & vbNewLine
        Else
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Access Block 01 Invalid" & vbNewLine
            MessageBox.Show(AES.ByteArrayToString(AccessControl01))
        End If
        If AES.ByteArrayToString(AccessControl02).ToUpper = "" Then

        End If
        If AES.ByteArrayToString(AccessControl02).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 02 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl03).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 03 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl04).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 04 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl05).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 05 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl06).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 06 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl07).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 07 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl08).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 08 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl09).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 09 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl10).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 10 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl11).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 11 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl12).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 12 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl13).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 13 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl14).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 14 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl15).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 15 Invalid" & vbNewLine
        End If
        If AES.ByteArrayToString(AccessControl16).ToUpper = "000000000000" Then
            frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & " Data Access Block 16 Invalid" & vbNewLine
        End If
        br.Close()
        fs.Close()
    End Sub

End Class
