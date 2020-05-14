Imports System.IO
Imports System.Threading
Imports Microsoft.Win32.SafeHandles
Imports SkyReader_GUI.DeviceManagement
Imports System.ComponentModel
'TODO Chart
'Determine how Traps are Different.
'Edit Trap contents.

'Determine how Vehicles are Different
'Edit Vehicles

'Stop the message box for Unknown Figure from happening twice.

'Test the Imaginator Chest.  In Particular the Serial Changing like Amiibos do.  Does that allow for Endless Items?

'Crystals Editing and Cloning

'Properly set the Imaginator Figure Bytes that are required to be 0x0.


'Determine what, if anything I can do to make sure the PM3 Clone isn't a box of mess/fail.
'Dump Fig
'Clone to Magic UID
'Dump Card Pre Imaginator Repair
'Fix in Imaginator
'Dump Card Post Imaginator Repair

'Process of PM3 Clone
'Dumped Phant Cynder using PM3
'Opened into Editor.  Valid all around.
'Changed NOTHING
'Wrote Dump to MF using PM3
'Verified Clean/Good in my App.

'Verify Clone is good in Imaginators.
'Determine Real Cause for Issues.

'Test Editing with my app against SigmaDolphin Editor


'Possible TODO Chart
'Create another form that will hold all error messages.  Possibly all debug/logging information.  Write to File?
'Verify Access Control Blocks are Set Properly.



'Notes:
'Does KeyA/KeyB matter?  The KeyA values are 6 Bytes Long, then 4 Bytes Access and 6 Bytes for KeyB
'Does a wrongly set Access Byte Set break the game?  Does Imaginators unbreak this?
'Games probably don't care, at least for Items.  Chests have their Blocks set to Read only for Header, as usual.  Then all other Sectors are "Blank"
'KeyA values and KeyB values are set on Chests.
'KeyA values are set on Other Non-Chest Figures.  KeyB is not.


Public Class frmMain
    'The AES and CRC16CCIT functions have been seperated into classes for clarity.
    'The Skylander Methods were put into seperate classes for clarity.

    'We need to make BR and FS public shared so other Classes can access it
    Public Shared fs As FileStream
    Public Shared br As BinaryReader
    Public Shared WholeFile(1023) As Byte
    Public Shared blnEncrypted As Boolean = False
    Dim File As String
    'Dim frmLog As New frmLog
    Public Shared Area0 As Byte
    Public Shared Area1 As Byte

    Public Shared blnTrap As Boolean = False
    Public Shared BlnVehicle As Boolean = False

#Region " File Read/Write "
    Sub Load_File()
        'AES.HexMath()
        'AES.Header()
        'Exit Sub
        BlnVehicle = False
        blnTrap = False
        lblWebCode.Text = ""
        'Let's test Decryption
        Dim result As DialogResult = ofdSky.ShowDialog()
        If result = DialogResult.OK Then
            ' Test result.
            File = ofdSky.FileName
        Else
            'Do Nothing
            Exit Sub
        End If

        Try
            fs = New FileStream(File, FileMode.Open)
        Catch ex As Exception
            'frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & "Unable to Open " & File
            'frmLog.Show()
            Exit Sub
        End Try

        If fs.Length = 1024 Then
        ElseIf fs.Length = 2048 Then
            'SWAP
            'MessageBox.Show("Sorry, this program does not handle a Maxlander Swap Force Dump.")
            'frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & "Sorry, this program does not handle a Maxlander Swap Force Dump."
            'frmLog.Show()
            Exit Sub
        Else
            'frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & "The Figure must be 1 Kilobyte."
            'frmLog.Show()
            fs.Close()
            Exit Sub
        End If
        'Reset the Form, Just in Case
        cmbGame.SelectedIndex = 0
        cmbHat.SelectedIndex = 0
        br = New BinaryReader(fs)
        'Put the whole file into an array.
        WholeFile = br.ReadBytes(1024)
        br.Close() 'close the Binary Reader
        fs.Close() ' close the FileStream
        blnEncrypted = False
        'Get Nickname
        'We also verify if Encrypted or not.
        Nickname.GetNickname()


        If blnEncrypted = True Then
            Decrypt()
        End If

        'Calculate the Checksums
        CRC16CCITT.Checksums()

        'Get Figure ID and Alter Ego/Variant
        Figures.GetFigureID_AlterEgo_Variant()

        'Determine if we are going to use Area 0 or Area 1
        Figures.Area0orArea1()

        'We break here if Vehicle, Crystal, Item or Trap

        If blnVehicle = True Then
            Dim frmVehicles As New frmVehicles
            frmVehicles.Show()
            Hide()
            Exit Sub
        End If
        If blnTrap = True Then
            Application.DoEvents()
            Dim frmTraps As New frmTraps
            frmTraps.Show()
            Hide()
            Exit Sub
        End If
        'Get the Current Skill Path.
        Skills.GetSkillPath()

        'Get the Current Hero Points value for Areas A and B.  Show the Larger Value.
        Hero.GetHero()

        'Get the Current Gold values for Areas A and B.  Show the Larger Value.
        Gold.GetGold()

        'Get EXP
        Exp.GetEXP()

        'Get the Current Heroic Challenges value for Areas A and B.  Show the Larger Value.
        Challenges.GetChallenges()

        'Show us what Figure we got.
        'Show us the Figures ID and Variant ID
        'Figures.ShowID()

        'Mostly complete Detection
        Figures.FigureItOut()

        'Select the Hat
        Hats.ReadHats()
        'btnSaveAs.Enabled = True
        'btnWrite.Enabled = True

        Web_Code.Load()
        'btnSaveAs.Enabled = True
        'btnWrite.Enabled = True

        System_ID.ReadSystem_ID()

    End Sub
    Sub LoadData()
        blnEncrypted = False
        'Get Nickname
        'We also verify if Encrypted or not.
        Nickname.GetNickname()

        If blnEncrypted = True Then
            Decrypt()
        End If
        cmbHat.SelectedIndex = 0

        'Calculate the Checksums
        CRC16CCITT.Checksums()

        'Determine if we are going to use Area 0 or Area 1
        Figures.Area0orArea1()

        'Get the Current Skill Path.
        Skills.GetSkillPath()



        'Get the Current Hero Points value for Areas A and B.  Show the Larger Value.
        Hero.GetHero()

        'Get the Current Gold values for Areas A and B.  Show the Larger Value.
        Gold.GetGold()

        'Get EXP
        Exp.GetEXP()

        'Get the Current Heroic Challenges value for Areas A and B.  Show the Larger Value.
        Challenges.GetChallenges()

        'Get Figure ID and Alter Ego/Variant
        Figures.GetFigureID_AlterEgo_Variant()

        'Show us what Figure we got.
        'Show us the Figures ID and Variant ID
        'Figures.ShowID()

        'Mostly complete Detection
        Figures.FigureItOut()

        'Select the Hat
        Hats.ReadHats()
        'btnSaveAs.Enabled = True
        'btnWrite.Enabled = True
        Web_Code.Load()

        System_ID.ReadSystem_ID()
    End Sub
    Sub ReEncrypt()
        'Get Header Bytes
        AES.Header()

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

        'Offsets that are Encrypted: (All 16 Bytes in Length)
        '0x080 '128 'Need 08
        '0x090 '144 'Need 09
        '0x0A0 'Nickname A '160 'Need 0A Not A0  '150 Diff

        '0x0C0 '192
        '0x0D0 '208
        '0x0E0 '224

        '0x100 '256
        '0x110 '272
        '0x120 '288

        '0x140 '320
        '0x150 '336
        '0x160 '352

        '0x180 '384
        '0x190 '400
        '0x1A0 '416

        '0x1C0 '448
        '0x1D0 '464
        '0x1E0 '480

        '0x200 '512
        '0x210 '528
        '0x220 '544

        '0x240 '576
        '0x250 '592
        '0x260 'Nickname B  '608

        '0x280 '640
        '0x290 '656
        '0x2A0 '672

        '0x2C0 '704
        '0x2D0 '720
        '0x2E0 '736

        '0x300 '768
        '0x310 '784
        '0x320 '800

        '0x340 '832
        '0x350 '848
        '0x360 '864

        '0x380 '896
        '0x390 '912
        '0x3A0 '928

        '0x3C0 '960
        '0x3D0 '976
        '0x3E0 '992

        Dim Offsets = New Integer() {128, 144, 160, 192, 208, 224, 256, 272, 288, 320, 336, 352, 384, 400, 416, 448, 464, 480, 512, 528, 544, 576, 592, 608, 640, 656, 672, 704, 720, 736, 768, 784, 800, 832, 848, 864, 896, 912, 928, 960, 976, 992}
        Dim AreaKey = New Byte() {&H8, &H9, &HA, &HC, &HD, &HE, &H10, &H11, &H12, &H14, &H15, &H16, &H18, &H19, &H1A, &H1C, &H1D, &H1E, &H20, &H21, &H22, &H24, &H25, &H26, &H28, &H29, &H2A, &H2C, &H2D, &H2E, &H30, &H31, &H32, &H34, &H35, &H36, &H38, &H39, &H3A, &H3C, &H3D, &H3E}
        'MessageBox.Show(AreaKey.Length)
        Dim AreaBytes(15) As Byte

        'MessageBox.Show(Offsets.Length) '42

        Dim OffsetCounter As Integer = 0

        Dim Counter As Integer = 0  'Necessary to add one to the Byte array Offset
        Dim HeadByteCounter As Integer = 0 '= 160 'Use Integer, FTW!
        Do Until OffsetCounter = 42
            HeadByteCounter = Offsets(OffsetCounter)
            'MessageBox.Show(HeadByteCounter)
            'Get Bytes from the Encrypted Offset
            Do Until Counter = 16
                'Fill areaBytes, with WholeFile.
                'AreaBytes(0-15) = WholeFile(HeadByteCounter)
                AreaBytes(Counter) = WholeFile(HeadByteCounter)
                HeadByteCounter += 1
                Counter += 1
            Loop

            'MessageBox.Show("ValueBytes " & BitConverter.ToString(AreaBytes))
            'MessageBox.Show("AreaKey " & AreaKey(OffsetCounter))
            AES.GetKey(AreaKey(OffsetCounter))

            Dim Output As Byte() = AES.AESE(AreaBytes, AES.FullKey)

            'Fillback Loop
            Counter = 0
            HeadByteCounter = Offsets(OffsetCounter) 'Use Integer, FTW!
            'Data back in
            Do Until Counter = 16
                WholeFile(HeadByteCounter) = Output(Counter)
                HeadByteCounter += 1
                Counter += 1
            Loop

            'MessageBox.Show("Output " & BitConverter.ToString(Output))

            Counter = 0
            OffsetCounter += 1
        Loop
    End Sub
    Sub Decrypt()
        'Get Header Bytes
        AES.Header()

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

        'Offsets that are Encrypted: (All 16 Bytes in Length)
        '0x080 '128 'Need 08
        '0x090 '144 'Need 09
        '0x0A0 'Nickname A '160 'Need 0A Not A0  '150 Diff

        '0x0C0 '192
        '0x0D0 '208
        '0x0E0 '224

        '0x100 '256
        '0x110 '272
        '0x120 '288

        '0x140 '320
        '0x150 '336
        '0x160 '352

        '0x180 '384
        '0x190 '400
        '0x1A0 '416

        '0x1C0 '448
        '0x1D0 '464
        '0x1E0 '480

        '0x200 '512
        '0x210 '528
        '0x220 '544

        '0x240 '576
        '0x250 '592
        '0x260 'Nickname B  '608

        '0x280 '640
        '0x290 '656
        '0x2A0 '672

        '0x2C0 '704
        '0x2D0 '720
        '0x2E0 '736

        '0x300 '768
        '0x310 '784
        '0x320 '800

        '0x340 '832
        '0x350 '848
        '0x360 '864

        '0x380 '896
        '0x390 '912
        '0x3A0 '928

        '0x3C0 '960
        '0x3D0 '976
        '0x3E0 '992

        Dim Offsets = New Integer() {128, 144, 160, 192, 208, 224, 256, 272, 288, 320, 336, 352, 384, 400, 416, 448, 464, 480, 512, 528, 544, 576, 592, 608, 640, 656, 672, 704, 720, 736, 768, 784, 800, 832, 848, 864, 896, 912, 928, 960, 976, 992}
        Dim AreaKey = New Byte() {&H8, &H9, &HA, &HC, &HD, &HE, &H10, &H11, &H12, &H14, &H15, &H16, &H18, &H19, &H1A, &H1C, &H1D, &H1E, &H20, &H21, &H22, &H24, &H25, &H26, &H28, &H29, &H2A, &H2C, &H2D, &H2E, &H30, &H31, &H32, &H34, &H35, &H36, &H38, &H39, &H3A, &H3C, &H3D, &H3E}
        'MessageBox.Show(AreaKey.Length)
        Dim AreaBytes(15) As Byte

        'MessageBox.Show(Offsets.Length) '42

        Dim OffsetCounter As Integer = 0

        Dim Counter As Integer = 0  'Necessary to add one to the Byte array Offset
        Dim HeadByteCounter As Integer = 0 '= 160 'Use Integer, FTW!
        Do Until OffsetCounter = 42
            HeadByteCounter = Offsets(OffsetCounter)
            'MessageBox.Show(HeadByteCounter)
            'Get Bytes from the Encrypted Offset
            Do Until Counter = 16
                'Fill areaBytes, with WholeFile.
                'AreaBytes(0-15) = WholeFile(HeadByteCounter)
                AreaBytes(Counter) = WholeFile(HeadByteCounter)
                HeadByteCounter += 1
                Counter += 1
            Loop

            'MessageBox.Show("ValueBytes " & BitConverter.ToString(AreaBytes))
            'MessageBox.Show("AreaKey " & AreaKey(OffsetCounter))
            AES.GetKey(AreaKey(OffsetCounter))

            Dim Output As Byte() = AES.AESD(AreaBytes, AES.FullKey)

            'Fillback Loop
            Counter = 0
            HeadByteCounter = Offsets(OffsetCounter) 'Use Integer, FTW!
            'Data back in
            Do Until Counter = 16
                WholeFile(HeadByteCounter) = Output(Counter)
                HeadByteCounter += 1
                Counter += 1
            Loop

            'MessageBox.Show("Output " & BitConverter.ToString(Output))

            Counter = 0
            OffsetCounter += 1
        Loop
        'MessageBox.Show("Nickname")
        Nickname.GetNickname()
    End Sub

    Sub Write_Data()
        If BlnVehicle = False And blnTrap = False Then
            'Set Data that changed.
            Figures.EditCharacterIDVariant()
            Challenges.WriteChallenges()
            Exp.WriteEXP()
            Gold.WriteGold()
            Hero.WriteHero()
            Nickname.SetNickname()
            Hats.WriteHats()

            If numLevel.Value >= 10 Then
                Skills.WriteSkillPath()
            End If
        End If
        'Fix Read/Write Blocks
        Figures.Fixing_Bytes()
        'In theory, this will fix any issues with the Edited Dumps.
        Figures.SetArea0AndArea1()
        'Fix the Checksums.
        CRC16CCITT.WriteCheckSums()
    End Sub
    Sub Write_Vehicle()

    End Sub
    Sub Write_File()
        Write_Data()
        fs = New FileStream(File, FileMode.OpenOrCreate)
        fs.Write(WholeFile, 0, WholeFile.Length)
        fs.Flush()
        fs.Close()
    End Sub
#End Region


#Region " Selections "
    'Set the Bytes here.
    'NOTE:
    'This is missing all the Creation Crystals, Some of Imaginators, and a few other characters
    Private Sub lstCharacters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCharacters.SelectedIndexChanged
        If blnClear = True Then
            blnClear = False
            Exit Sub
        End If
        If lstCharacters.SelectedItem.ToString.StartsWith("--") Then
            lstCharacters.SelectedIndex += 1
            Exit Sub
        End If
        Figures.SelectFigure()
    End Sub
    'Set the Bytes here, whenever I figure it out.
    Private Sub cmbHat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHat.SelectedIndexChanged
        Hats.SelectHat()
    End Sub
    Private Sub cmbGame_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGame.SelectedIndexChanged
        lstCharacters.Items.Clear()
        chkSerial.Enabled = True
        Enable_Controls()
        lblArea1Type4.Text = "Area 0 Type 4"
        lblArea2Type4.Text = "Area 1 Type 4"
        'cmbHat.Items.Clear()
        'btnWrite.Enabled = True
        If cmbGame.SelectedIndex = 0 Then
            'Spyro's Adventure
            Figures.SpyroAdventure()
            'Hats.SpyroAdventureHats()
        ElseIf cmbGame.SelectedIndex = 1 Then
            'Giants
            Figures.Giants()
            'Hats.GiantsHats()
        ElseIf cmbGame.SelectedIndex = 2 Then
            'Swap Force
            Figures.SwapForce()
            'Hats.SwapForceHats()
        ElseIf cmbGame.SelectedIndex = 3 Then
            'Trap Team
            Figures.TrapTeam()
            'Hats.TrapTeamHats()
        ElseIf cmbGame.SelectedIndex = 4 Then
            'SuperChargers
            Figures.SuperChargers()
            'Hats.TrapTeamHats()
        ElseIf cmbGame.SelectedIndex = 5 Then
            'Imaginators
            'Partially Disabled due to issues and complications.
            'lstCharacters.Items.Clear()
            Figures.Imaginators()
            'Hats.TrapTeamHats()
            'btnWrite.Enabled = False
            chkSerial.Checked = False
            chkSerial.Enabled = False
            'Exit Sub
        ElseIf cmbGame.SelectedIndex = 6 Then
            'Items
            'We don't populate the Hats since items and Traps can't wear them.
            Figures.Items()
            Disable_Controls()
        ElseIf cmbGame.SelectedIndex = 7 Then
            'Traps
            Disable_Controls()
            Figures.Traps()
            'Traps, do not use Type 4 CRC
            lblArea1Type4.Text = "Area 0 Trap CRC"
            lblArea2Type4.Text = "Area 1 Trap CRC"
        ElseIf cmbGame.SelectedIndex = 8 Then
            'Adventure Packs
            Disable_Controls()
            Figures.AdventurePacks()
        End If
        'Only the main games get Hats.
        If cmbGame.SelectedIndex < 6 Then
            'cmbHat.SelectedIndex = 0
        End If

        'lstCharacters.SelectedIndex = 0
    End Sub
    'Hats don't need these Controls.
    Sub Disable_Controls()
        numGold.Enabled = False
        numLevel.Enabled = False
        numHeroicChallenges.Enabled = False
        numHero.Enabled = False
        radLeft.Enabled = False
        radNone.Enabled = False
        radRight.Enabled = False
        cmbHat.Enabled = False
        txtName.Text = ""
        txtName.Enabled = False
    End Sub
    Sub Enable_Controls()
        numGold.Enabled = True
        numLevel.Enabled = True
        numHeroicChallenges.Enabled = True
        numHero.Enabled = True
        radLeft.Enabled = True
        radNone.Enabled = True
        radRight.Enabled = True
        cmbHat.Enabled = True
        txtName.Enabled = True
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SaldeStatus.Text = "Ready"
        cmbGame.SelectedIndex = 0
        radNone.Checked = True
        ' cmbHat.SelectedIndex = 0
        Dim frmLog As New frmLog
        Hats.cmbHatFill()
        cmbSystem.SelectedIndex = 0
    End Sub
#End Region

#Region " Menu "
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Load_File()
    End Sub

    Private Sub Save_Enc_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Save_Enc_ToolStripMenuItem.Click
        'Save As
        Dim dialog As New SaveFileDialog With {
                .Filter = "Dump File (*.bin)|*.bin|All files (*.*)|*.*",
                .FilterIndex = 1,
                .RestoreDirectory = True,
                .Title = "Save Encrypted Dump"
            }
        If (dialog.ShowDialog = DialogResult.OK) Then
            Dim NewFile As String = dialog.FileName

            If chkSerial.Checked = True Then
                CRC16CCITT.GenerateNewSerial()
            End If
            Figures.EditCharacterIDVariant()
            'We need to not break Traps if Saving a trap.
            If blnTrap = False Then
                Challenges.WriteChallenges()
                Exp.WriteEXP()
                Gold.WriteGold()
                Hero.WriteHero()
                Nickname.SetNickname()
                Hats.WriteHats()
                If numLevel.Value >= 10 Then
                    Skills.WriteSkillPath()
                End If
            End If

            System_ID.WriteSystem()

            'In theory, this will fix any issues with the Edited Dumps.
            Figures.SetArea0AndArea1()
            'This corrects the Access Control Blocks and the Imaginator Byte checks
            Figures.Fixing_Bytes()
            'Fix the Checksums.
            CRC16CCITT.WriteCheckSums()
            'I need to Calculate Trap Checksums differently.
            'And Gen 6 Crystals too.
            ReEncrypt()
            fs = New FileStream(NewFile, FileMode.OpenOrCreate)
            fs.Write(WholeFile, 0, WholeFile.Length)
            fs.Flush()
            fs.Close()
        End If

        'Write_File()
    End Sub
    Private Sub SaveDecryptedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Save_Dec_ToolStripMenuItem.Click
        'Save As
        Dim dialog As New SaveFileDialog With {
                .Filter = "Dump File (*.bin)|*.bin|All files (*.*)|*.*",
                .FilterIndex = 1,
                .RestoreDirectory = True,
                .Title = "Save Decrypted Dump",
                .FileName = lstCharacters.SelectedItem
            }
        If (dialog.ShowDialog = DialogResult.OK) Then
            Dim NewFile As String = dialog.FileName
            'DO NOT FORGET THIS
            If chkSerial.Checked = True Then
                CRC16CCITT.GenerateNewSerial()
            End If
            Figures.EditCharacterIDVariant()
            'We need to not break Traps if Saving a trap.
            If blnTrap = False Then
                Challenges.WriteChallenges()
                Exp.WriteEXP()
                Gold.WriteGold()
                Hero.WriteHero()
                Nickname.SetNickname()
                Hats.WriteHats()
                If numLevel.Value >= 10 Then
                    Skills.WriteSkillPath()
                End If
            End If

            System_ID.WriteSystem()

            'In theory, this will fix any issues with the Edited Dumps.
            Figures.SetArea0AndArea1()
            'This corrects the Access Control Blocks and the Imaginator Byte checks
            Figures.Fixing_Bytes()
            'Fix the Checksums.
            CRC16CCITT.WriteCheckSums()
            'ReEncrypt()

            fs = New FileStream(NewFile, FileMode.OpenOrCreate)
            fs.Write(WholeFile, 0, WholeFile.Length)
            fs.Flush()
            fs.Close()
        End If
    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub
#End Region


#Region " Portal Handling "
    Dim outRepoBytes(32) As Byte
    Dim inRepoBytes(32) As Byte
    Public Shared blnAccess As Boolean = False
    Public Shared BlnPortalUsed As Boolean = False
    Private Sub ReadSkylanderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadSkylanderToolStripMenuItem.Click
        bgReadPortal.RunWorkerAsync()
    End Sub
    Private Sub BgReadPortal_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgReadPortal.DoWork
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
        Save_Enc_ToolStripMenuItem.Enabled = True
        Save_Dec_ToolStripMenuItem.Enabled = True
        MiFare.Detection()
        If blnAccess = True Then
            MessageBox.Show("Error.  Invalid Control Blocks found.")
            Exit Sub
        End If

        BlnPortalUsed = True
    End Sub
    Private Sub bgReadPortal_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgReadPortal.RunWorkerCompleted
        SaldeStatus.Text = "Figure Read from Portal"
        LoadData()
    End Sub
    Private Sub WriteSkylanderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WriteSkylanderToolStripMenuItem.Click
        '
        bgWritePortal.RunWorkerAsync()
    End Sub

    Private Sub BgWritePortal_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWritePortal.DoWork
        SaldeStatus.Text = "Writing to Portal"
        If bgWritePortal.IsBusy Then
            SaldeStatus.Text = "Still Writing to Portal"
            Exit Sub
        End If
        'write data to skylander in portal
        Portal_Write()
    End Sub
    Sub Portal_Write()
        If lstCharacters.SelectedIndex = -1 Then
            SaldeStatus.Text = "No figure Selected"
            Exit Sub
        End If
        'We actually need to SET Data here
        Write_Data()
        'We need to Encrypt the Array Before we write
        ReEncrypt()
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
        SaldeStatus.Text = "Save Completed to portal"
    End Sub

    Private Sub bgWritePortal_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgWritePortal.RunWorkerCompleted
        SaldeStatus.Text = "Figure written to Portal"
        'We Decrypt the Figure's data again because it had to be written encrypted but we edit decrypted data.
        Decrypt()
    End Sub

    'I may want see/check for a Swap Force Figure.
    Private Sub ReadSwapperOtherHalfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadSwapperOtherHalfToolStripMenuItem.Click
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
        LoadData()
    End Sub
    Private Sub WriteSwapperOtherHalfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WriteSwapperOtherHalfToolStripMenuItem.Click
        'write data to skylander in portal
        Dim writeBlock As Integer
        'We actually need to SET Data here
        Write_Data()
        'We need to Encrypt the Array Before we write
        ReEncrypt()
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
        Loop While writeBlock <= &H3F 'Last Block

        Decrypt()
        SaldeStatus.Text = "Save Completed to portal"
    End Sub
    Dim portalHandle As SafeFileHandle
    'Connect to the Portal, using HID
    Private Sub ConnectToPortalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToPortalToolStripMenuItem.Click
        portalHandle = FindThePortal()
    End Sub

    'Disable the Portal Menu Controls except for Connect.
    'This is done when the Portal is Removed
    Public Sub lockPortalControls()
        DisablePortalControls()
    End Sub
    Sub DisableControls()
        'btnClearData.Enabled = False
        'btnReset.Enabled = False
        Save_Enc_ToolStripMenuItem.Enabled = False
        DisablePortalControls()
    End Sub
    Sub DisablePortalControls()
        ReadSkylanderToolStripMenuItem.Enabled = False
        WriteSkylanderToolStripMenuItem.Enabled = False
        ReadSwapperOtherHalfToolStripMenuItem.Enabled = False
        WriteSwapperOtherHalfToolStripMenuItem.Enabled = False
    End Sub

    Public Sub unlockPortalControls()
        'SaldeStatus.Text = "Unlocked"
        ReadSkylanderToolStripMenuItem.Enabled = True
        WriteSkylanderToolStripMenuItem.Enabled = True
        ReadSwapperOtherHalfToolStripMenuItem.Enabled = True
        WriteSwapperOtherHalfToolStripMenuItem.Enabled = True
    End Sub
    Public Shared blnPortal As Boolean = False
    'This is to catch if the portal is removed
    Protected Overrides Sub WndProc(ByRef m As Message)

        If m.Msg = WM_DEVICECHANGE Then
            If (m.WParam.ToInt32 = DBT_DEVICEREMOVECOMPLETE) Then

                ' If WParam contains DBT_DEVICEREMOVAL, a device has been removed.
                ' Find out if it's the device we're communicating with.

                If checkDevice(m) Then
                    lockPortalControls()
                    SaldeStatus.Text = "Portal Removed!"
                    DisablePortalControls()
                    blnPortal = False
                    tmrPortal.Enabled = True
                End If

            End If
        End If
        MyBase.WndProc(m)
    End Sub
#End Region
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnReset.Click

        Dim result As Integer = MessageBox.Show("Are you sure you want to Reset this Figure?", "Reset Figure?", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            'Do nothing
        ElseIf result = DialogResult.Yes Then
            cmbHat.SelectedIndex = 0
            numGold.Value = 0
            numLevel.Value = 1
            numHeroicChallenges.Value = 0
            numHero.Value = 0
            radNone.Checked = True
            Write_Data()
        End If
    End Sub
    Dim tmrFail As Integer = 0
    Private Sub TmrPortal_Tick(sender As Object, e As EventArgs) Handles tmrPortal.Tick

        If blnPortal = False Then
            portalHandle = FindThePortal()
        ElseIf blnPortal = True Then
            tmrPortal.Enabled = False
            tmrFail += 1
        End If
        If tmrFail = 10 Then
            tmrPortal.Enabled = False
        End If
    End Sub

    Dim blnClear As Boolean = False
    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        blnClear = True
        Array.Clear(WholeFile, 0, WholeFile.Length)
        'LoadData()
        lstCharacters.SelectedIndex = -1
        cmbGame.SelectedIndex = 0
        cmbHat.SelectedIndex = 0
        numGold.Value = 0
        numHero.Value = 0
        numHeroicChallenges.Value = 0
        numLevel.Value = 1
        radNone.Checked = True
        txtName.Text = ""
        cmbSystem.SelectedIndex = 0

        picHeader.BackColor = Color.Yellow
        picSerial.BackColor = Color.Yellow
        picArea0Type1.BackColor = Color.Yellow
        picArea0Type2.BackColor = Color.Yellow
        picArea0Type3.BackColor = Color.Yellow
        picArea0Type4.BackColor = Color.Yellow
        picArea1Type1.BackColor = Color.Yellow
        picArea1Type2.BackColor = Color.Yellow
        picArea1Type3.BackColor = Color.Yellow
        picArea1Type4.BackColor = Color.Yellow
        lblWebCode.Text = ""
    End Sub

    Private Sub btnShowData_Click(sender As Object, e As EventArgs) Handles btnShowData.Click
        'Figures.Figure()
        'MessageBox.Show("Header Bytes: " & WholeFile(&H10).ToString("X2") + WholeFile(&H11).ToString("X2"))
        'MessageBox.Show("Variant Bytes: " & WholeFile(&H1C).ToString("X2") + WholeFile(&H1D).ToString("X2"))
        lblData.Text = "Head: " & WholeFile(&H10).ToString("X2") + WholeFile(&H11).ToString("X2") & " Variant: " & WholeFile(&H1C).ToString("X2") + WholeFile(&H1D).ToString("X2")
    End Sub



    Private Sub btnClearData_Click(sender As Object, e As EventArgs) Handles btnClearData.Click
        lblData.Text = "Data: "
    End Sub


    Private Sub tmrSkyKey_Tick(sender As Object, e As EventArgs) Handles tmrSkyKey.Tick
        DisableControls()
    End Sub

    Private Sub btnWebCode_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnTraps_Click(sender As Object, e As EventArgs) Handles btnTraps.Click
        Dim frmTraps As New frmTraps
        frmTraps.Show()
        Hide()
    End Sub


    Private Sub btnVehicles_Click(sender As Object, e As EventArgs) Handles btnVehicles.Click
        Dim frmVehicles As New frmVehicles
        Hide()
        frmVehicles.Show()

    End Sub

    Private Sub btnRaw_Click(sender As Object, e As EventArgs) Handles btnRaw.Click
        'Save As
        Dim dialog As New SaveFileDialog With {
                .Filter = "Dump File (*.bin)|*.bin|All files (*.*)|*.*",
                .FilterIndex = 1,
                .RestoreDirectory = True,
                .Title = "Save Decrypted Dump",
                .FileName = lstCharacters.SelectedItem
            }
        If (dialog.ShowDialog = DialogResult.OK) Then
            Dim NewFile As String = dialog.FileName
            fs = New FileStream(NewFile, FileMode.OpenOrCreate)
            fs.Write(WholeFile, 0, WholeFile.Length)
            fs.Flush()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show(lstCharacters.SelectedIndex)
    End Sub
End Class