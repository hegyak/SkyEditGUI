Imports System.IO
Imports SkyReader_GUI.frmMain
'This Class will Handle all the Figure Input and Output Functionality.  And will call the Portal I/O as well.
Public Class FigureIO
    'Shared Variables
    'We need to make BR and FS public shared so other Classes can access it
    Public Shared fs As FileStream
    Public Shared br As BinaryReader
    Public Shared WholeFile(1023) As Byte
    Public Shared blnEncrypted As Boolean = False
    Public Shared File As String


    'These three are the Unique trio.  They are not like other figures
    Public Shared blnTrap As Boolean = False
    Public Shared BlnVehicle As Boolean = False
    Public Shared blnCrystal As Boolean = False

    'Call all the Functions for the Figure, when relevant.
    'TODO:
    'Improve Figure Identification and Handling.

    Public Shared Sub Load_File()
        Dim result As DialogResult = frmMain.ofdSky.ShowDialog()
        If result = DialogResult.OK Then
            ' Test result.
            File = frmMain.ofdSky.FileName
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
            frmMain.SaldeStatus.Text = "Sorry, this program does not handle a Maxlander Swap Force Dump."
            'frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & "Sorry, this program does not handle a Maxlander Swap Force Dump."
            'frmLog.Show()
            Exit Sub
        Else
            'frmLog.rtxLog.Text = frmLog.rtxLog.Text & Date.Now & "The Figure must be 1 Kilobyte."
            'frmLog.Show()
            frmMain.SaldeStatus.Text = "The Figure must be 1 Kilobyte."
            fs.Close()
            Exit Sub
        End If
        'Reset the Form, Just in Case
        frmMain.cmbGame.SelectedIndex = 0
        frmMain.cmbHat.SelectedIndex = 0
        br = New BinaryReader(fs)
        'Put the whole file into an array.
        WholeFile = br.ReadBytes(1024)
        br.Close() 'close the Binary Reader
        fs.Close() ' close the FileStream

        Parse_Figure()
    End Sub
    Public Shared Sub Parse_Figure()
        'We set the Decrypted Flag here
        blnEncrypted = False
        'We set the Unique Trio Booleans to False.
        BlnVehicle = False
        blnTrap = False
        blnCrystal = False
        'We Reset WebCode here and early.
        frmMain.lblWebCode.Text = ""
        'We can get the Figure's ID and Variant ID without Needing Encryption/Decryption
        'Get Figure ID and Alter Ego/Variant
        Figures.GetFigureID_AlterEgo_Variant()

        'Because Traps, Vehciles and Crystals are writing bytes to where the Nickname would normally show up, we Do NOT attempt to Decrypt here.
        'Though, Crystals may write here?
        If blnTrap = False And blnCrystal = False And BlnVehicle = False Then
            blnEncrypted = Enc_Fig()
        ElseIf blnTrap = True Then
            blnEncrypted = Enc_Trap()
        ElseIf BlnVehicle = True Then
            blnEncrypted = Enc_Veh()
        ElseIf blnCrystal = True Then
            'Not Implimented Yet.
        End If
        If blnEncrypted = True Then
            Decrypt()
        End If

        'Calculate the Checksums
        'Does NOT handle Traps or Crystals, yet.
        CRC16CCITT.Checksums()
        'Determine if we are going to use Area 0 or Area 1
        Figures.Area0orArea1()
        frmArea.Area0_1()

        'We break here if Vehicle, Crystal, Item or Trap
        If BlnVehicle = True Then
            Application.DoEvents()
            Dim frmVehicles As New frmVehicles
            frmVehicles.Show()
            frmMain.Hide()
            Exit Sub
        ElseIf blnTrap = True Then
            Application.DoEvents()
            Dim frmTraps As New frmTraps
            frmTraps.Show()
            frmMain.Hide()
            Exit Sub
        ElseIf blnCrystal = True Then
#If DEBUG Then
            Application.DoEvents()
            Dim FrmCrystals As New frmCrystals
            FrmCrystals.Show()
            frmMain.Hide()
            Exit Sub
#Else
            frmMain.SaldeStatus.Text = "Crystals are not supported, yet."
            Exit Sub
#End If

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

    'Write_Data write's Data to the Figures.
    'Note that Traps, Vehicles and Crystals do NOT use this because they have their own Editor that is used.
    Public Shared Sub Write_Data()
        If BlnVehicle = False And blnTrap = False And blnCrystal = False Then
            'Set Data that changed.
            Challenges.WriteChallenges()
            Exp.WriteEXP()
            Gold.WriteGold()
            Hero.WriteHero()
            Nickname.SetNickname()
            Hats.WriteHats()
            If frmMain.numLevel.Value >= 10 Then
                Skills.WriteSkillPath()
            End If
        End If
        If blnTrap = True Then
            'Special Byte Data Writes
            Dim ZeroTrap As Integer = 0
            'Add 13 to reach End of Block
            '194 = 0C2
            '258 = 102
            '322 = 142
            '386 = 182
            '450 = 1C2
            '515 = 202

            'Then we do Area 2
            '+1C0
            '642 = 282
            '706 = 2C2
            '770 = 302
            '834 = 342
            '898 = 382
            '962 = 3C2

            Dim Trap_Name() As Integer = {194, 258, 322, 386, 450, 515, 642, 706, 770, 834, 898, 962}
            Dim TrapCounter As Integer = 0

            Do Until TrapCounter = 12
                WholeFile(Trap_Name(TrapCounter) + ZeroTrap) = &H0
                If ZeroTrap = 13 Then
                    ZeroTrap = 0
                    TrapCounter += 1
                Else
                    ZeroTrap += 1
                End If
            Loop
        ElseIf BlnVehicle = True Then
            'Special Byte Data Writes
            Dim ZeroVehicle As Integer = 0
            '192 = 0C0
            '+1C0
            '640 = 280
            Do Until ZeroVehicle = 14
                WholeFile(192 + ZeroVehicle) = &H0
                ZeroVehicle += 1
            Loop
            ZeroVehicle = 0
            Do Until ZeroVehicle = 14
                WholeFile(640 + ZeroVehicle) = &H0
                ZeroVehicle += 1
            Loop
        ElseIf blnCrystal = True Then
            'Special Byte Data Writes
            'Not Implimented, Yet.
        End If
        'All Figures need these Functions still.
        'Write the System ID
        System_ID.WriteSystem()
        'Fix Read/Write Blocks
        Figures.Fixing_Bytes()
        'In theory, this will fix any issues with the Edited Dumps.
        Figures.SetArea0AndArea1()
        'Fix the Checksums.
        CRC16CCITT.WriteCheckSums()
    End Sub
    Public Shared Sub Write_Decrypted_Figure()
        'Save As
        Dim dialog As New SaveFileDialog With {
                .Filter = "Dump File (*.bin)|*.bin|All files (*.*)|*.*",
                .FilterIndex = 1,
                .RestoreDirectory = True,
                .Title = "Save Decrypted Dump",
                .FileName = frmMain.lstCharacters.SelectedItem
            }
        If (dialog.ShowDialog = DialogResult.OK) Then
            Dim NewFile As String = dialog.FileName

            If frmMain.chkSerial.Checked = True Then
                CRC16CCITT.GenerateNewSerial()
            End If
            Figures.EditCharacterIDVariant()
            Write_Data()
            'Now we write the file.
            fs = New FileStream(NewFile, FileMode.OpenOrCreate)
            fs.Write(WholeFile, 0, WholeFile.Length)
            fs.Flush()
            fs.Close()
        End If
    End Sub

    Public Shared Sub Write_Encrypted_Figure()
        'Save As
        Dim dialog As New SaveFileDialog With {
                .Filter = "Dump File (*.bin)|*.bin|All files (*.*)|*.*",
                .FilterIndex = 1,
                .RestoreDirectory = True,
                .Title = "Save Encrypted Dump",
                .FileName = frmMain.lstCharacters.SelectedItem
            }
        If (dialog.ShowDialog = DialogResult.OK) Then
            Dim NewFile As String = dialog.FileName

            If frmMain.chkSerial.Checked = True Then
                CRC16CCITT.GenerateNewSerial()
            End If
            Figures.EditCharacterIDVariant()
            Write_Data()
            'Since we are Writing an Encrypted Figure, I need to Re-Encrypt it.
            Encrypt()
            'Now we write the file.
            fs = New FileStream(NewFile, FileMode.OpenOrCreate)
            fs.Write(WholeFile, 0, WholeFile.Length)
            fs.Flush()
            fs.Close()
            'We Decrypt after we are done.
            Decrypt()
        End If
    End Sub

    Public Shared Sub Raw_Write()
        'Save As
        Dim dialog As New SaveFileDialog With {
                .Filter = "Dump File (*.bin)|*.bin|All files (*.*)|*.*",
                .FilterIndex = 1,
                .RestoreDirectory = True,
                .Title = "Save Decrypted Dump",
                .FileName = frmMain.lstCharacters.SelectedItem
            }

        If (dialog.ShowDialog = DialogResult.OK) Then
            Dim NewFile As String = dialog.FileName
            fs = New FileStream(NewFile, FileMode.OpenOrCreate)
            fs.Write(WholeFile, 0, WholeFile.Length)
            fs.Flush()
            fs.Close()
        End If
    End Sub
    'We Put Decryption and Encrytion in this Module due to being Relevant to Figure I/O

    Public Shared Sub Decrypt()
        'Get Header Bytes
        AES.Header()
#Region " Blocks "
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
#End Region

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
        'We get Nickname here, to see if it's still Encrypted.
        Nickname.GetNickname()
    End Sub
    Public Shared Sub Encrypt()
        'Get Header Bytes
        AES.Header()
#Region " Blocks "
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
#End Region

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

    Public Shared Function Enc_Fig()
        'We do a special Check for Bytes Being Set in the wrong places.
        'Check 0x150 through 0x15F
        'Check 0x310 through 0x31F
        '336 = 150
        '784 = 310
        Dim ZeroFigure As Integer = 0
        Do Until ZeroFigure = 16
            If WholeFile(336 + ZeroFigure) <> &H0 Then
                Return True
            Else
                ZeroFigure += 1
            End If
        Loop
        ZeroFigure = 0
        Do Until ZeroFigure = 16
            If WholeFile(784 + ZeroFigure) <> &H0 Then
                Return True
            Else
                ZeroFigure += 1
            End If
        Loop
        Return False
    End Function
    Public Shared Function Enc_Trap()
        'We do a Clean Check for If the Trap is Encrypted, by checking places we KNOW should be blank.
        'Special Byte Data Writes
        Dim ZeroTrap As Integer = 0
        'Add 13 to reach End of Block
        '194 = 0C2
        '258 = 102
        '322 = 142
        '386 = 182
        '450 = 1C2
        '515 = 202

        'Then we do Area 2
        '+1C0
        '642 = 282
        '706 = 2C2
        '770 = 302
        '834 = 342
        '898 = 382
        '962 = 3C2

        Dim Trap_Name() As Integer = {194, 258, 322, 386, 450, 515, 642, 706, 770, 834, 898, 962}
        Dim TrapCounter As Integer = 0
        Do Until TrapCounter = 12
            If WholeFile(Trap_Name(TrapCounter) + ZeroTrap) <> &H0 Then
                Return True
            Else
                If ZeroTrap = 13 Then
                    ZeroTrap = 0
                    TrapCounter += 1
                Else
                    ZeroTrap += 1
                End If
            End If

        Loop
        Return False
    End Function
    Public Shared Function Enc_Veh()
        'We do a Clean Check for If the Vehicle is Encrypted, by checking places we KNOW should be blank.
        'Special Byte Data Checks
        Dim ZeroVehicle As Integer = 0
        '192 = 0C0
        '+1C0
        '640 = 280
        Do Until ZeroVehicle = 14
            'WholeFile(192 + ZeroVehicle) = &H0
            If WholeFile(192 + ZeroVehicle) <> &H0 Then
                Return True
            Else
                ZeroVehicle += 1
            End If
        Loop
        ZeroVehicle = 0
        Do Until ZeroVehicle = 14
            'WholeFile(640 + ZeroVehicle) = &H0
            If WholeFile(640 + ZeroVehicle) <> &H0 Then
                blnEncrypted = True
            Else
                ZeroVehicle += 1
            End If
        Loop
        'Default Action
        Return False
    End Function
End Class
