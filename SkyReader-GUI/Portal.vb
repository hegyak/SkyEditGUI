Imports System.Threading
Imports Microsoft.Win32.SafeHandles

Imports SkyReader_GUI.FigureIO
Public Class Portal

    Shared outRepoBytes(32) As Byte
    Shared inRepoBytes(32) As Byte
    Public Shared blnAccess As Boolean = False
    Public Shared BlnPortalUsed As Boolean = False

    Public Shared portalHandle As SafeFileHandle
    'Connect to the Portal, using HID



    Public Shared blnPortal As Boolean = False

    Shared Sub ReadPortal()
        'reads skylander data from the portal
        Dim timeout As Integer
        Dim readBlock As Integer
        blnAccess = False

        'Reset portal
        outRepoBytes(1) = &H52 'R
        outputReport(portalHandle, outRepoBytes)
        Thread.Sleep(50)

        outRepoBytes(1) = &H41 'A
        outRepoBytes(2) = 1
        outputReport(portalHandle, outRepoBytes)
        Thread.Sleep(500)

        'set to "read first skylander" mode
        outRepoBytes(1) = &H51 'Q
        outRepoBytes(2) = &H20 'First Figure
        readBlock = 0
        Do
            'send report and flush hid queue
            outRepoBytes(3) = readBlock
            outputReport(portalHandle, outRepoBytes)
            flushHid(portalHandle)
            timeout = 0
            Do
                'read the reply from the portal, the portal replies between 1 and 2 reports later
                inputReport(portalHandle, inRepoBytes)
                timeout = timeout + 1
            Loop Until inRepoBytes(1) <> &H53 Or timeout = 4  '53 is S

            If timeout <> 4 Then
                'if we didn't time out we copy the the bytes into the array
                Array.Copy(inRepoBytes, 4, WholeFile, readBlock * 16, 16)
                readBlock = readBlock + 1
            End If
            'MessageBox.Show(AES.ByteArrayToString(inRepoBytes).ToUpper)
        Loop While readBlock <= &H3F  'Last Block
        frmMain.Save_Enc_ToolStripMenuItem.Enabled = True
        frmMain.Save_Dec_ToolStripMenuItem.Enabled = True
        MiFare.Detection()
        If blnAccess = True Then
            MessageBox.Show("Error.  Invalid Control Blocks found.")
            Exit Sub
        End If

        BlnPortalUsed = True
    End Sub

    Shared Sub Portal_Write()

        'Magic.
        'write data to skylander in portal
        Dim writeBlock As Integer
        'reset portal
        outRepoBytes(1) = &H52  'R
        outputReport(portalHandle, outRepoBytes)
        Thread.Sleep(50)

        outRepoBytes(1) = &H41  'A
        outRepoBytes(2) = 1
        outputReport(portalHandle, outRepoBytes)
        Thread.Sleep(500)

        'set to "write first skylander" mode
        outRepoBytes(1) = &H57 'W
        outRepoBytes(2) = &H20 'First Figure
        writeBlock = 5
        Do
            outRepoBytes(3) = writeBlock
            'we get the bytes from the data array and put out the report, we need to wait a bit before sending another write report too
            Array.Copy(WholeFile, writeBlock * 16, outRepoBytes, 4, 16)
            outputReport(portalHandle, outRepoBytes)
            Thread.Sleep(100)
            writeBlock = writeBlock + 1
        Loop While writeBlock <= &H3F 'Last Block
        frmMain.SaldeStatus.Text = "Save Completed to portal"
    End Sub

    Shared Sub Portal_Duo_Read()
        'Same as read from portal, but reads the second position skylander (usually the Top half of a Swap Force)
        Dim timeout As Integer
        Dim readBlock As Integer

        outRepoBytes(1) = &H52 'R
        outputReport(portalHandle, outRepoBytes)
        Thread.Sleep(50)

        outRepoBytes(1) = &H41 'A
        outRepoBytes(2) = 1
        outputReport(portalHandle, outRepoBytes)
        Thread.Sleep(500)

        outRepoBytes(1) = &H51 'Q
        outRepoBytes(2) = &H21 'Second Figure
        readBlock = 0
        Do
            outRepoBytes(3) = readBlock
            outputReport(portalHandle, outRepoBytes)
            flushHid(portalHandle)
            timeout = 0
            Do
                inputReport(portalHandle, inRepoBytes)
                timeout = timeout + 1
            Loop Until inRepoBytes(1) <> &H53 Or timeout = 4 '53 is S

            If timeout <> 4 Then
                Array.Copy(inRepoBytes, 4, WholeFile, readBlock * 16, 16)
                readBlock = readBlock + 1
            End If

        Loop While readBlock <= &H3F 'Final Block
        'Parse_Figure()

        BlnPortalUsed = True
    End Sub

    Shared Sub Portal_Duo_Write()
        'Magic.
        'write data to skylander in portal
        Dim writeBlock As Integer
        'reset portal
        outRepoBytes(1) = &H52  'R
        outputReport(portalHandle, outRepoBytes)
        Thread.Sleep(50)

        outRepoBytes(1) = &H41  'A
        outRepoBytes(2) = 1
        outputReport(portalHandle, outRepoBytes)
        Thread.Sleep(500)

        'set to "write first skylander" mode
        outRepoBytes(1) = &H57 'W
        outRepoBytes(2) = &H21 'Second Figure
        writeBlock = 5

        'I need to look into this further
        'I need to and Write ALL bytes/Blocks
        Do
            outRepoBytes(3) = writeBlock
            'we get the bytes from the data array and put out the report, we need to wait a bit before sending another write report too

            Array.Copy(WholeFile, writeBlock * 16, outRepoBytes, 4, 16)
            outputReport(portalHandle, outRepoBytes)
            Thread.Sleep(100)
            writeBlock = writeBlock + 1
        Loop While writeBlock <= &H3F 'Last Block 63

        frmMain.SaldeStatus.Text = "Save Completed to portal"
    End Sub

    Shared Sub Portal_Rainbow(Red As Byte, Green As Byte, Blue As Byte)
        blnAccess = False

        'Reset portal
        outRepoBytes(1) = &H43 'C
        outRepoBytes(2) = Red 'Red
        outRepoBytes(3) = Green 'Green
        outRepoBytes(4) = Blue 'Blue

        outputReport(portalHandle, outRepoBytes)
        Thread.Sleep(50)
    End Sub
End Class
