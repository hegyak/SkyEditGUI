Imports SkyReader_GUI.FigureIO
Imports SkyReader_GUI.frmMain
Public Class Figures
    'This handles all the Figure data
    Public Shared Var As String
    Public Shared Fig As String
    Public Shared MyAddress As Short
    Public Shared CharacterID(1) As Byte
    Public Shared CharacterVariant(1) As Byte


    Shared Sub Area0orArea1()
        '"Use Area 0" Marker &H089
        '"Use Area 1" Marker &H249
        Area0 = WholeFile(&H89)
        Area1 = WholeFile(&H249)
    End Sub
    Shared Sub SetArea0AndArea1()

        If Area0 <> &HFF Then
            Area0 += &H1
        Else
            Area0 = &H0
        End If
        If Area1 <> &HFF Then
            Area1 += &H1
        Else
            Area1 = &H0
        End If
        'Debug Code
        'Area0 = &H0
        'Area1 = &H1
        WholeFile(&H89) = Area0
        WholeFile(&H249) = Area1
        WholeFile(&H112) = Area0
        WholeFile(&H2D2) = Area1
    End Sub
    Shared blnNoCode As Boolean = False
    Shared Sub DetermineWrite()
        If blnNoCode = True Then
            DisableWrite()
        Else
            EnableWrite()
        End If
    End Sub
    Shared blnBottomFigure As Boolean = False
    Shared Sub BottomFigure()
        If blnBottomFigure = True Then

        End If
    End Sub

    Shared Sub DisableWrite()
        frmMain.SaldeStatus.Text = "Error.  Character ID and Variant ID Unavailable."
        frmMain.Save_Enc_ToolStripMenuItem.Enabled = False
        frmMain.Save_Dec_ToolStripMenuItem.Enabled = False
        frmMain.WriteSkylanderToolStripMenuItem.Enabled = False
        frmMain.WriteSecondFigureToolStripMenuItem.Enabled = False
    End Sub
    Shared Sub EnableWrite()
        frmMain.SaldeStatus.Text = "Ready"
        frmMain.Save_Enc_ToolStripMenuItem.Enabled = True
        frmMain.Save_Dec_ToolStripMenuItem.Enabled = True
        If Portal.blnPortal = True Then
            frmMain.WriteSkylanderToolStripMenuItem.Enabled = True
            frmMain.WriteSecondFigureToolStripMenuItem.Enabled = True
        End If
    End Sub
#Region " Write Methods "
    Shared Sub EditCharacterIDVariant()
        'MessageBox.Show("CharID0: " & CharacterID(0))
        'MessageBox.Show("CharID1: " & CharacterID(1))
        'MessageBox.Show("CharVar0: " & CharacterVariant(0))
        'MessageBox.Show("CharVar1: " & CharacterVariant(1))
        'Character ID
        WholeFile(&H10) = CharacterID(0)
        WholeFile(&H11) = CharacterID(1)

        'Variant ID
        WholeFile(&H1C) = CharacterVariant(0)
        WholeFile(&H1D) = CharacterVariant(1)
    End Sub
    Shared Sub Fixing_Bytes()
        'This is Special Byte Writing Stuff.
        Dim Counter As Integer = 0

        'Set the Header Bytes to Read Only
        WholeFile(&H36) = &HF
        WholeFile(&H37) = &HF
        WholeFile(&H38) = &HF
        WholeFile(&H39) = &H69
        'First Read/Write Block
        WholeFile(&H76) = &H7F
        WholeFile(&H77) = &HF
        WholeFile(&H78) = &H8
        WholeFile(&H79) = &H69

        'Second Read/Write Block
        WholeFile(&HB6) = &H7F
        WholeFile(&HB7) = &HF
        WholeFile(&HB8) = &H8
        WholeFile(&HB9) = &H69

        'Third Read/Write Block
        WholeFile(&HF6) = &H7F
        WholeFile(&HF7) = &HF
        WholeFile(&HF8) = &H8
        WholeFile(&HF9) = &H69

        'Foruth Read/Write Block
        WholeFile(&H136) = &H7F
        WholeFile(&H137) = &HF
        WholeFile(&H138) = &H8
        WholeFile(&H139) = &H69

        'Fifth Read/Write Block
        WholeFile(&H176) = &H7F
        WholeFile(&H177) = &HF
        WholeFile(&H178) = &H8
        WholeFile(&H179) = &H69

        'Sixth Read/Write Block
        WholeFile(&H1B6) = &H7F
        WholeFile(&H1B7) = &HF
        WholeFile(&H1B8) = &H8
        WholeFile(&H1B9) = &H69

        'Seventh Read/Write Block
        WholeFile(&H1F6) = &H7F
        WholeFile(&H1F7) = &HF
        WholeFile(&H1F8) = &H8
        WholeFile(&H1F9) = &H69

        'Eigth Read/Write Block
        WholeFile(&H236) = &H7F
        WholeFile(&H237) = &HF
        WholeFile(&H238) = &H8
        WholeFile(&H239) = &H69

        'Nineth Read/Write Block
        WholeFile(&H276) = &H7F
        WholeFile(&H277) = &HF
        WholeFile(&H278) = &H8
        WholeFile(&H279) = &H69

        'Tenth Read/Write Block
        WholeFile(&H2B6) = &H7F
        WholeFile(&H2B7) = &HF
        WholeFile(&H2B8) = &H8
        WholeFile(&H2B9) = &H69

        'Eleventh Read/Write Block
        WholeFile(&H2F6) = &H7F
        WholeFile(&H2F7) = &HF
        WholeFile(&H2F8) = &H8
        WholeFile(&H2F9) = &H69

        'Twelth Read/Write Block
        WholeFile(&H336) = &H7F
        WholeFile(&H337) = &HF
        WholeFile(&H338) = &H8
        WholeFile(&H339) = &H69

        'Thireenth Read/Write Block
        WholeFile(&H376) = &H7F
        WholeFile(&H377) = &HF
        WholeFile(&H378) = &H8
        WholeFile(&H379) = &H69

        'Fourteenth Read/Write Block
        WholeFile(&H3B6) = &H7F
        WholeFile(&H3B7) = &HF
        WholeFile(&H3B8) = &H8
        WholeFile(&H3B9) = &H69

        'Fifteenth Read/Write Block
        WholeFile(&H3F6) = &H7F
        WholeFile(&H3F7) = &HF
        WholeFile(&H3F8) = &H8
        WholeFile(&H3F9) = &H69

        'Read/Write Bytes
        '7F0F0869




    End Sub
    Shared Sub SelectFigure()
        blnNoCode = False
        'MessageBox.Show("Var: " & Figures.Var)
        'MessageBox.Show("Fig: " & Figures.Fig)
        'Exit Sub
        'frmMain.SaldeStatus.Text = ""
        Select Case frmMain.cmbGame.SelectedIndex
            Case 0
                'Adventures
                'All Adventures characters should have their Variant ID set to 0000 Except for Legendary Figures
                '0000

                CharacterVariant(0) = &H0
                CharacterVariant(1) = &H0
                CharacterID(1) = &H0
                If frmMain.lstCharacters.SelectedItem Is "Bash" Then
                    '0400
                    CharacterID(0) = &H4
                ElseIf frmMain.lstCharacters.SelectedItem Is "Boomer" Then
                    '1600
                    CharacterID(0) = &H16
                ElseIf frmMain.lstCharacters.SelectedItem Is "Camo" Then
                    '1800
                    CharacterID(0) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Chop Chop" Then
                    '1E00
                    CharacterID(0) = &H1E
                ElseIf frmMain.lstCharacters.SelectedItem Is "Cynder" Then
                    '2000
                    CharacterID(0) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Spyro" Then
                    '1C00
                    CharacterID(0) = &H1C
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dino-Rang" Then
                    '0600
                    CharacterID(0) = &H6
                ElseIf frmMain.lstCharacters.SelectedItem Is "Double Trouble" Then
                    '1200
                    CharacterID(0) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "Drill Sergeant" Then
                    '1500
                    CharacterID(0) = &H15
                ElseIf frmMain.lstCharacters.SelectedItem Is "Drobot" Then
                    '1400
                    CharacterID(0) = &H14
                ElseIf frmMain.lstCharacters.SelectedItem Is "Eruptor" Then
                    '0900
                    CharacterID(0) = &H9
                ElseIf frmMain.lstCharacters.SelectedItem Is "Flameslinger" Then
                    '0B00
                    CharacterID(0) = &HB
                ElseIf frmMain.lstCharacters.SelectedItem Is "Ghost Roaster" Then
                    '1F00
                    CharacterID(0) = &H1F
                ElseIf frmMain.lstCharacters.SelectedItem Is "Gill Grunt" Then
                    '0E00
                    CharacterID(0) = &HE
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hex" Then
                    '1D00
                    CharacterID(0) = &H1D
                ElseIf frmMain.lstCharacters.SelectedItem Is "Ignitor" Then
                    '0A00
                    CharacterID(0) = &HA
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Bash" Then
                    '9401
                    CharacterID(0) = &H94
                    CharacterID(1) = &H1
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Chop Chop" Then
                    'AE01
                    CharacterID(0) = &HAE
                    CharacterID(1) = &H1
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Spyro" Then
                    'A001
                    CharacterID(0) = &HA0
                    CharacterID(1) = &H1
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Trigger Happy" Then
                    'A301
                    CharacterID(0) = &HA3
                    CharacterID(1) = &H1
                ElseIf frmMain.lstCharacters.SelectedItem Is "Lightning Rod" Then
                    '0300
                    CharacterID(0) = &H3
                ElseIf frmMain.lstCharacters.SelectedItem Is "Prism Break" Then
                    '0700
                    CharacterID(0) = &H7
                ElseIf frmMain.lstCharacters.SelectedItem Is "Slam Bam" Then
                    '0F00
                    CharacterID(0) = &HF
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sonic Boom" Then
                    '0100
                    CharacterID(0) = &H1
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spyro" Then
                    '1000
                    CharacterID(0) = &H10
                ElseIf frmMain.lstCharacters.SelectedItem Is "Stealth Elf" Then
                    '1A00
                    CharacterID(0) = &H1A
                ElseIf frmMain.lstCharacters.SelectedItem Is "Stump Smash" Then
                    '1B00
                    CharacterID(0) = &H1B
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sunburn" Then
                    '0800
                    CharacterID(0) = &H8
                ElseIf frmMain.lstCharacters.SelectedItem Is "Terrafin" Then
                    '0500
                    CharacterID(0) = &H5
                ElseIf frmMain.lstCharacters.SelectedItem Is "Trigger Happy" Then
                    '1300
                    CharacterID(0) = &H13
                ElseIf frmMain.lstCharacters.SelectedItem Is "Voodood" Then
                    '1100
                    CharacterID(0) = &H11
                ElseIf frmMain.lstCharacters.SelectedItem Is "Warnado" Then
                    '0200
                    CharacterID(0) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Wham-Shell" Then
                    '0D00
                    CharacterID(0) = &HD
                ElseIf frmMain.lstCharacters.SelectedItem Is "Whirlwind" Then
                    '0000
                    CharacterID(0) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "Wrecking Ball" Then
                    '1700
                    CharacterID(0) = &H17
                ElseIf frmMain.lstCharacters.SelectedItem Is "Zap" Then
                    '0C00
                    CharacterID(0) = &HC
                ElseIf frmMain.lstCharacters.SelectedItem Is "Zook" Then
                    '1900
                    CharacterID(0) = &H19
                End If
            Case 1
                'Giants
                If frmMain.lstCharacters.SelectedItem Is "Bouncer" Then
                    '6E00
                    '0612
                    CharacterID(0) = &H6E
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "Chill" Then
                    '6A00
                    '0010
                    CharacterID(0) = &H6A
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H10
                ElseIf frmMain.lstCharacters.SelectedItem Is "Crusher" Then
                    '6600
                    '0612
                    CharacterID(0) = &H66
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "Eye-Brawl" Then
                    '7200
                    '0612
                    CharacterID(0) = &H72
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "Flashwing" Then
                    '6700
                    '0010
                    CharacterID(0) = &H67
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H10
                ElseIf frmMain.lstCharacters.SelectedItem Is "Fright Rider" Then
                    '7300
                    '0010
                    CharacterID(0) = &H73
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H10
                ElseIf frmMain.lstCharacters.SelectedItem Is "Gnarly Tree Rex" Then
                    '7000
                    '0216
                    CharacterID(0) = &H70
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H16
                ElseIf frmMain.lstCharacters.SelectedItem Is "Granite Crusher" Then
                    '6600
                    '0216
                    CharacterID(0) = &H66
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H16
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hot Dog" Then
                    '6900
                    '0010
                    CharacterID(0) = &H69
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H10
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hot Head" Then
                    '6800
                    '0612
                    CharacterID(0) = &H68
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "Jade Flashwing" Then
                    '6700
                    '0214
                    CharacterID(0) = &H67
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H14
                ElseIf frmMain.lstCharacters.SelectedItem Is "Jet-Vac" Then
                    '6400
                    '0010
                    CharacterID(0) = &H64
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H10
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Bouncer" Then
                    '6E00
                    '0316
                    CharacterID(0) = &H6E
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H16
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Chill" Then
                    '6A00
                    '0316
                    CharacterID(0) = &H6A
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H16
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Ignitor" Then
                    '0A00
                    '0316
                    CharacterID(0) = &HA
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H16
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Jet-Vac" Then
                    '6400
                    '0314
                    CharacterID(0) = &H64
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H14
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Slam Bam" Then
                    '0F00
                    '031C
                    CharacterID(0) = &HF
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H1C
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Stealth Elf" Then
                    '1A00
                    '031C
                    CharacterID(0) = &H1A
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H1C
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Chill" Then
                    '6A00
                    '0612
                    CharacterID(0) = &H6A
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Drobot" Then
                    '1400
                    '0612
                    CharacterID(0) = &H14
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Eruptor" Then
                    '0900
                    '0612
                    CharacterID(0) = &H9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Hex" Then
                    '1D00
                    '0612
                    CharacterID(0) = &H1D
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Jet-Vac" Then
                    '6400
                    '0612
                    CharacterID(0) = &H64
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Pop Fizz" Then
                    '6C00
                    '0612
                    CharacterID(0) = &H6C
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Prism Break" Then
                    '0700
                    '0612
                    CharacterID(0) = &H7
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Shroomboom" Then
                    '7100
                    '0612
                    CharacterID(0) = &H71
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "Molten Hot Dog" Then
                    '6900
                    '0214
                    CharacterID(0) = &H69
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H14
                ElseIf frmMain.lstCharacters.SelectedItem Is "Ninjini" Then
                    '6D00
                    '0612
                    CharacterID(0) = &H6D
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "Polar Whirlwind" Then
                    '0000
                    '0216
                    CharacterID(0) = &H0
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H16
                ElseIf frmMain.lstCharacters.SelectedItem Is "Pop Fizz" Then
                    '6C00
                    '0010
                    CharacterID(0) = &H6C
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H10
                ElseIf frmMain.lstCharacters.SelectedItem Is "Punch Pop Fizz" Then
                    '6C00
                    '0214
                    CharacterID(0) = &H6C
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H14
                ElseIf frmMain.lstCharacters.SelectedItem Is "Royal Double Trouble" Then
                    '1200
                    '021C
                    CharacterID(0) = &H12
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H1C
                ElseIf frmMain.lstCharacters.SelectedItem Is "Scarlet Ninjini" Then
                    '6D00
                    '0216
                    CharacterID(0) = &H6D
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H16
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Bash" Then
                    '0400
                    '0118
                    CharacterID(0) = &H4
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Chop Chop" Then
                    '1E00
                    '0118
                    CharacterID(0) = &H1E
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Cynder" Then
                    '2000
                    '0118
                    CharacterID(0) = &H20
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Double Trouble" Then
                    '1200
                    '0118
                    CharacterID(0) = &H12
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Drill Sergeant" Then
                    '1500
                    '0118
                    CharacterID(0) = &H15
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Drobot" Then
                    '1400
                    '0118
                    CharacterID(0) = &H14
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Eruptor" Then
                    '0900
                    '0118
                    CharacterID(0) = &H9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Flameslinger" Then
                    '0B00
                    '0118
                    CharacterID(0) = &HB
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Gill Grunt" Then
                    '0E00
                    '0118
                    CharacterID(0) = &HE
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Hex" Then
                    '1D00
                    '0118
                    CharacterID(0) = &H1D
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Ignitor" Then
                    '0A00
                    '0118
                    CharacterID(0) = &HA
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Lightning Rod" Then
                    '0300
                    '0118
                    CharacterID(0) = &H3
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Prism Break" Then
                    '0700
                    '0118
                    CharacterID(0) = &H7
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Slam Bam" Then
                    '0F00
                    '0118
                    CharacterID(0) = &HF
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Sonic Boom" Then
                    '0100
                    '0118
                    CharacterID(0) = &H1
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Spyro" Then
                    '0100
                    '0118
                    CharacterID(0) = &H1
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Stealth Elf" Then
                    '1A00
                    '0118
                    CharacterID(0) = &H1A
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Stump Smash" Then
                    '1B00
                    '0118
                    CharacterID(0) = &H1B
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Terrafin" Then
                    '0500
                    '0118
                    CharacterID(0) = &H5
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Trigger Happy" Then
                    '1300
                    '0118
                    CharacterID(0) = &H13
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Whirlwind" Then
                    '0000
                    '0118
                    CharacterID(0) = &H0
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Wrecking Ball" Then
                    '1700
                    '0118
                    CharacterID(0) = &H17
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Zap" Then
                    '0C00
                    '0118
                    CharacterID(0) = &HC
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Series 2 Zook" Then
                    '1900
                    '0118
                    CharacterID(0) = &H19
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H18
                ElseIf frmMain.lstCharacters.SelectedItem Is "Shroomboom" Then
                    '7100
                    '0010
                    CharacterID(0) = &H71
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H10
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sprocket" Then
                    '6F00
                    '0010
                    CharacterID(0) = &H6F
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H10
                ElseIf frmMain.lstCharacters.SelectedItem Is "Swarm" Then
                    '6500
                    '0612
                    CharacterID(0) = &H65
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "Thumpback" Then
                    '6B00
                    '0612
                    CharacterID(0) = &H6B
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tree Rex" Then
                    '7000
                    '0612
                    CharacterID(0) = &H70
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                End If
            Case 2
                'Swap Force
                If frmMain.lstCharacters.SelectedItem Is "Anchors Away Gill Grunt" Then
                    '0E00
                    '0528
                    CharacterID(0) = &HE
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Big Bang Trigger Happy" Then
                    '1300
                    '0528
                    CharacterID(0) = &H13
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Blast Zone (Bottom)" Then
                    'Swap Character
                    'EC03
                    '0020
                    CharacterID(0) = &HEC
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Blast Zone (Top)" Then
                    'Swap Character
                    'D407
                    '0020
                    CharacterID(0) = &HD4
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Blizzard Chill" Then
                    '6A00
                    '0528
                    CharacterID(0) = &H6A
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Boom Jet (Bottom)" Then
                    'Swap Character
                    'E803
                    '0020
                    CharacterID(0) = &HE8
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Boom Jet (Top)" Then
                    'Swap Character
                    'D007
                    '0020
                    CharacterID(0) = &HD0
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Bumble Blast" Then
                    'BE0B
                    '0020
                    CharacterID(0) = &HBE
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Countdown" Then
                    'C20B
                    '0020
                    CharacterID(0) = &HC2
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Blast Zone (Bottom)" Then
                    'Swap Character
                    'EC03
                    '0224
                    CharacterID(0) = &HEC
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Blast Zone (Top)" Then
                    'Swap Character
                    'D407
                    '0224
                    CharacterID(0) = &HD4
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Mega Ram Spyro" Then
                    '1000
                    '0528
                    CharacterID(0) = &H10
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Slobber Tooth" Then
                    'BA0B
                    '0224
                    CharacterID(0) = &HBA
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Stealth Elf" Then
                    '1A00
                    '022C
                    CharacterID(0) = &H1A
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H2C
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Wash Buckler (Bottom)" Then
                    'Swap Character
                    'F703
                    '0224
                    CharacterID(0) = &HF7
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Wash Buckler (Top)" Then
                    'Swap Character
                    'DF07
                    '0224
                    CharacterID(0) = &HDF
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Doom Stone (Bottom)" Then
                    'Swap Character
                    'EB03
                    '0020
                    CharacterID(0) = &HEB
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Doom Stone (Top)" Then
                    'Swap Character
                    'D307
                    '0020
                    CharacterID(0) = &HD3
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dune Bug" Then
                    'C00B
                    '0020
                    CharacterID(0) = &HC0
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Enchanted Hoot Loop (Bottom)" Then
                    'Swap Character
                    'F003
                    '0224
                    CharacterID(0) = &HF0
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Enchanted Hoot Loop (Top)" Then
                    'Swap Character
                    'D807
                    '0224
                    CharacterID(0) = &HD8
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Enchanted Star Strike" Then
                    'LightCore
                    'C10B
                    '0226
                    CharacterID(0) = &HC1
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H26
                ElseIf frmMain.lstCharacters.SelectedItem Is "Fire Bone Hot Dog" Then
                    '0069
                    '0528
                    CharacterID(0) = &H0
                    CharacterID(1) = &H69
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Fire Kraken (Bottom)" Then
                    'Swap Character
                    'ED03
                    '0020
                    CharacterID(0) = &HED
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Fire Kraken (Top)" Then
                    'Swap Character
                    'D507
                    '0020
                    CharacterID(0) = &HD5
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Free Ranger (Bottom)" Then
                    'Swap Character
                    'E903
                    '0020
                    CharacterID(0) = &HE9
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Free Ranger (Top)" Then
                    'Swap Character
                    'D107
                    '0020
                    CharacterID(0) = &HD1
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Freeze Blade (Bottom)" Then
                    'Swap Character
                    'F603
                    '0020
                    CharacterID(0) = &HF6
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Freeze Blade (Top)" Then
                    'Swap Character
                    'DE07
                    '0020
                    CharacterID(0) = &HDE
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Fryno" Then
                    'BC0B
                    '0020
                    CharacterID(0) = &HBC
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Grilla Drilla (Bottom)" Then
                    'Swap Character
                    'EF03
                    '0020
                    CharacterID(0) = &HEF
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20

                ElseIf frmMain.lstCharacters.SelectedItem Is "Grilla Drilla (Top)" Then
                    'Swap Character
                    'D707
                    '0020
                    CharacterID(0) = &HD7
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Grim Creeper" Then
                    'C50B
                    '0020
                    CharacterID(0) = &HC5
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Heavy Duty Sprocket" Then
                    '6F00
                    '0528
                    CharacterID(0) = &H6F
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hoot Loop (Bottom)" Then
                    'Swap Character
                    'F003
                    '0020
                    CharacterID(0) = &HF0
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hoot Loop (Top)" Then
                    'Swap Character
                    'D807
                    '0020
                    CharacterID(0) = &HD8
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Horn Blast Whirlwind" Then
                    '0000
                    '0528
                    CharacterID(0) = &H0
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hyper Beam Prism Break" Then
                    '0700
                    '0528
                    CharacterID(0) = &H7
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Jade Fire Kraken (Bottom)" Then
                    'Swap Character
                    'ED03
                    '0224
                    CharacterID(0) = &HED
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Jade Fire Kraken (Top)" Then
                    'Swap Character
                    'D507
                    '0224
                    CharacterID(0) = &HD5
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Jolly Bumble Blast" Then
                    'BE0B
                    '0224
                    CharacterID(0) = &HBE
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Kickoff Countdown" Then
                    'C20B
                    '0224
                    CharacterID(0) = &HC2
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Knockout Terrafin" Then
                    '0500
                    '0528
                    CharacterID(0) = &H5
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Lava Barf Eruptor" Then
                    '0900
                    '0528
                    CharacterID(0) = &H9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Free Ranger (Bottom)" Then
                    'Swap Character
                    'E903
                    '0324
                    CharacterID(0) = &HE9
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Free Ranger (Top)" Then
                    'Swap Character
                    'D1 07
                    '03 24
                    CharacterID(0) = &HD1
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Grim Creeper" Then
                    'C50B
                    '0326
                    CharacterID(0) = &HC5
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H26
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Night Shift (Bottom)" Then
                    'Swap Character
                    'F403
                    '0304
                    CharacterID(0) = &HF4
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H4
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Night Shift (Top)" Then
                    'Swap Character
                    'DC07
                    '0324
                    CharacterID(0) = &HDC
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Zoo Lou" Then
                    'BF0B
                    '0324
                    CharacterID(0) = &HBF
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Bumble Blast" Then
                    'BE0B
                    '0622
                    CharacterID(0) = &HBE
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H22
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Countdown" Then
                    'C20B
                    '0622
                    CharacterID(0) = &HC2
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H22
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Flashwing" Then
                    '6700
                    '0622
                    CharacterID(0) = &H67
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H22
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Grim Creeper" Then
                    'C50B
                    '0622
                    CharacterID(0) = &HC5
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H22
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Smolderdash" Then
                    'BD0B
                    '0622
                    CharacterID(0) = &HDB
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H22
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Star Strike" Then
                    'C10B
                    '0622
                    CharacterID(0) = &HC1
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H22
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Warnado" Then
                    '0200
                    '0622
                    CharacterID(0) = &H2
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H22
                ElseIf frmMain.lstCharacters.SelectedItem Is "LightCore Wham-Shell" Then
                    '0D00
                    '0622
                    CharacterID(0) = &HD
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H22
                ElseIf frmMain.lstCharacters.SelectedItem Is "Magna Charge (Bottom)" Then
                    'Swap Character
                    'F203
                    '0020
                    CharacterID(0) = &HF2
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Magna Charge (Top)" Then
                    'Swap Character
                    'DA07
                    '0020
                    CharacterID(0) = &HDA
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Mega Ram Spyro" Then
                    '1000
                    '0528
                    CharacterID(0) = &H10
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Night Shift (Bottom)" Then
                    'Swap Character
                    'F403
                    '0020
                    CharacterID(0) = &HF4
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Night Shift (Top)" Then
                    'Swap Character
                    'DC07
                    '0020
                    CharacterID(0) = &HDC
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Ninja Stealth Elf" Then
                    '1A00
                    '0528
                    CharacterID(0) = &H1A
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Nitro Freeze Blade (Bottom)" Then
                    'Swap Character
                    'F603
                    '0224
                    CharacterID(0) = &HF6
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Nitro Freeze Blade (Top)" Then
                    'Swap Character
                    'DE07
                    '0224
                    CharacterID(0) = &HDE
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Nitro Magna Charge (Bottom)" Then
                    'Swap Character
                    'F203
                    '0224
                    CharacterID(0) = &HF2
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Nitro Magna Charge (Top)" Then
                    'Swap Character
                    'DA07
                    '0224
                    CharacterID(0) = &HDA
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Phantom Cynder" Then
                    '2000
                    '0528
                    CharacterID(0) = &H20
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Pop Thorn" Then
                    'B90B
                    '0020
                    CharacterID(0) = &HB9
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Punk Shock" Then
                    'C70B
                    '0020
                    CharacterID(0) = &HC7
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Quickdraw Rattle Shake (Bottom)" Then
                    'Swap Character
                    'F5 03
                    '02 24
                    CharacterID(0) = &HF5
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Quickdraw Rattle Shake (Top)" Then
                    'Swap Character
                    'DD07
                    '0224
                    CharacterID(0) = &HDD
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H24
                ElseIf frmMain.lstCharacters.SelectedItem Is "Rattle Shake (Bottom)" Then
                    'Swap Character
                    'F503
                    '0020
                    CharacterID(0) = &HF5
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Rattle Shake (Top)" Then
                    'Swap Character
                    'DD07
                    '0020
                    CharacterID(0) = &HDD
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Rip Tide" Then
                    '6C0B
                    '0020
                    CharacterID(0) = &H6C
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Roller Brawl" Then
                    'C40B
                    '0020
                    CharacterID(0) = &HC4
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Rubble Rouser (Bottom)" Then
                    'Swap Character
                    'EA03
                    '0020
                    CharacterID(0) = &HEA
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Rubble Rouser (Top)" Then
                    'Swap Character
                    'D207
                    '0020
                    CharacterID(0) = &HD2
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Scorp" Then
                    'BB0B
                    '0020
                    CharacterID(0) = &HBB
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Scratch" Then
                    'B80B
                    '0020
                    CharacterID(0) = &HB8
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Slobber Tooth" Then
                    'BA0B
                    '0020
                    CharacterID(0) = &HBA
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Smolderdash" Then
                    'BD0B
                    '0020
                    CharacterID(0) = &HBD
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Springtime Trigger Happy" Then
                    '1300
                    '022C
                    CharacterID(0) = &H13
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H2C
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spy Rise (Bottom)" Then
                    'Swap Character
                    'F303
                    '0020
                    CharacterID(0) = &HF3
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spy Rise (Top)" Then
                    'Swap Character
                    'DB07
                    '0020
                    CharacterID(0) = &HDB
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Star Strike" Then
                    'C10B
                    '0020
                    CharacterID(0) = &HC1
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Stink Bomb (Bottom)" Then
                    'Swap Character
                    'EE03
                    '0020
                    CharacterID(0) = &HEE
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Stink Bomb (Top)" Then
                    'Swap Character
                    'D607
                    '0020
                    CharacterID(0) = &HD6
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Super Gulp Pop Fizz" Then
                    '6C00
                    '0528
                    CharacterID(0) = &H6C
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Thorn Horn Camo" Then
                    '1800
                    '0528
                    CharacterID(0) = &H18
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Trap Shadow (Bottom)" Then
                    'Swap Character
                    'F103
                    '0020
                    CharacterID(0) = &HF1
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Trap Shadow (Top)" Then
                    'Swap Character
                    'D907
                    '0020
                    CharacterID(0) = &HD9
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Turbo Jet-Vac" Then
                    '6400
                    '0528
                    CharacterID(0) = &H64
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Twin Blade Chop Chop" Then
                    '1E00
                    '0528
                    CharacterID(0) = &H1E
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H28
                ElseIf frmMain.lstCharacters.SelectedItem Is "Volcanic Eruptor" Then
                    '0900
                    '022C
                    CharacterID(0) = &H9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H2C
                ElseIf frmMain.lstCharacters.SelectedItem Is "Wash Buckler (Bottom)" Then
                    'Swap Character
                    'F703
                    '0020
                    CharacterID(0) = &HF7
                    CharacterID(1) = &H3
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Wash Buckler (Top)" Then
                    'Swap Character
                    'DF07
                    '0020
                    CharacterID(0) = &HDF
                    CharacterID(1) = &H7
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Wind-Up" Then
                    'C30B
                    '0020
                    CharacterID(0) = &HC3
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Zoo Lou" Then
                    'BF0B
                    '0020
                    CharacterID(0) = &HBF
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                End If
            Case 3
                'Trap Team
                If frmMain.lstCharacters.SelectedItem Is "Barkley" Then
                    '1C02
                    '0030
                    CharacterID(0) = &H1C
                    CharacterID(1) = &H2
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Bat Spin" Then
                    'E001
                    '0030
                    CharacterID(0) = &HE0
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Blackout" Then
                    'E501
                    '0030
                    CharacterID(0) = &HE5
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Blades" Then
                    'C501
                    '0030
                    CharacterID(0) = &HC5
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Blastermind" Then
                    'D201
                    '0030
                    CharacterID(0) = &HD2
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Bop" Then
                    'F601
                    '0030
                    CharacterID(0) = &HF6
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Breeze" Then
                    'FA01
                    '0030
                    CharacterID(0) = &HFA
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Bushwhack" Then
                    'DA01
                    '0030
                    CharacterID(0) = &HDA
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Chopper" Then
                    'D801
                    '0030
                    CharacterID(0) = &HD8
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Clear Thunderbolt" Then
                    'C301
                    '1D30
                    CharacterID(0) = &HC3
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H1D
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Cobra Cadabra" Then
                    'D501
                    '0030
                    CharacterID(0) = &HD5
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Food Fight" Then
                    'DC01
                    '0234
                    CharacterID(0) = &HDC
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Snap Shot" Then
                    'CE01
                    '0234
                    CharacterID(0) = &HCE
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Wildfire" Then
                    'CA01
                    '0234
                    CharacterID(0) = &HCA
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Drobit" Then
                    'FE01
                    '0030
                    CharacterID(0) = &HFE
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Déjà Vu" Then
                    'D401
                    '0030
                    CharacterID(0) = &HD4
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Echo" Then
                    'D101
                    '0030
                    CharacterID(0) = &HD1
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Eggsellent Weeruptor" Then
                    'FB01
                    '0234
                    CharacterID(0) = &HFB
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Chop Chop" Then
                    '1E00
                    '1038
                    CharacterID(0) = &H1E
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Eruptor" Then
                    '0900
                    '1038
                    CharacterID(0) = &H9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Gill Grunt" Then
                    '0E00
                    '1038
                    CharacterID(0) = &HE
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Spyro" Then
                    '1000
                    '1038
                    CharacterID(0) = &H10
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Stealth Elf" Then
                    '1A00
                    '1038
                    CharacterID(0) = &H1A
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Terrafin" Then
                    '0500
                    '1038
                    CharacterID(0) = &H5
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Trigger Happy" Then
                    '1300
                    '1038
                    CharacterID(0) = &H13
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Whirlwind" Then
                    '0000
                    '1038
                    CharacterID(0) = &H0
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Enigma" Then
                    'D301
                    '0030
                    CharacterID(0) = &HD3
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Eye-Small" Then
                    '1F02
                    '0030
                    CharacterID(0) = &H1F
                    CharacterID(1) = &H2
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Fist Bump" Then
                    'C801
                    '0030
                    CharacterID(0) = &HC8
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Fizzy Frenzy Pop Fizz" Then
                    '6C00
                    '0538
                    CharacterID(0) = &H6C
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Fling Kong" Then
                    'C401
                    '0030
                    CharacterID(0) = &HC4
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Flip Wreck" Then
                    'D001
                    '0030
                    CharacterID(0) = &HD0
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Food Fight" Then
                    'DC01
                    '0030
                    CharacterID(0) = &HDC
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Full Blast Jet-Vac" Then
                    '6400
                    '0538
                    CharacterID(0) = &H64
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Funny Bone" Then
                    'E101
                    '0030
                    CharacterID(0) = &HE1
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Gearshift" Then
                    'D701
                    '0030
                    CharacterID(0) = &HD7
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Gill Runt" Then
                    '0202
                    '0030
                    CharacterID(0) = &H2
                    CharacterID(1) = &H2
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Gnarly Barkley" Then
                    '1C02
                    '0234
                    CharacterID(0) = &H1C
                    CharacterID(1) = &H2
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Gusto" Then
                    'C201
                    '0030
                    CharacterID(0) = &HC2
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Head Rush" Then
                    'C701
                    '0030
                    CharacterID(0) = &HC7
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "High Five" Then
                    'DD01
                    '0030
                    CharacterID(0) = &HDD
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hijinx" Then
                    'F801
                    '0030
                    CharacterID(0) = &HF8
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hog Wild Fryno" Then
                    'BC0B
                    '0138
                    CharacterID(0) = &HBC
                    CharacterID(1) = &HB
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Instant Food Fight" Then

                    blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Instant Snap Shot" Then

                    blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Jawbreaker" Then
                    'D601
                    '0030
                    CharacterID(0) = &HD6
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Ka-Boom" Then
                    'CB01
                    '0030
                    CharacterID(0) = &HCB
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "King Cobra Cadabra" Then
                    'D501
                    '0234
                    CharacterID(0) = &HD5
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Knight Light" Then
                    'E201
                    '0030
                    CharacterID(0) = &HE2
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Knight Mare" Then
                    'E401
                    '0030
                    CharacterID(0) = &HE4
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Krypt King" Then
                    'DE01
                    '0030
                    CharacterID(0) = &HDE
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Blades" Then
                    'C501
                    '0334
                    CharacterID(0) = &HC5
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Bushwhack" Then
                    'DA01
                    '0334
                    CharacterID(0) = &HDA
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Déjà Vu" Then
                    'D401
                    '0334
                    CharacterID(0) = &HD4
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Jawbreaker" Then
                    'D601
                    '0334
                    CharacterID(0) = &HD6
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Lob-Star" Then
                    'CF01
                    '0030
                    CharacterID(0) = &HCF
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Love Potion Pop Fizz" Then
                    '6C00
                    '023C
                    CharacterID(0) = &H6C
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H3C
                ElseIf frmMain.lstCharacters.SelectedItem Is "Mini-Jini" Then
                    '1E02
                    '0030
                    CharacterID(0) = &H1E
                    CharacterID(1) = &H2
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Nitro Head Rush" Then
                    'C701
                    '0234
                    CharacterID(0) = &HC7
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Nitro Krypt King" Then
                    'DE01
                    '0234
                    CharacterID(0) = &HDE
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Pet-Vac" Then
                    'FC01
                    '0030
                    CharacterID(0) = &HFC
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Power Punch Pet-Vac" Then
                    'FC01
                    '0234
                    CharacterID(0) = &HFC
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Rocky Roll" Then
                    'C901
                    '0030
                    CharacterID(0) = &HC9
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Short Cut" Then
                    'DF01
                    '0030
                    CharacterID(0) = &HDF
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Small Fry" Then
                    'FD01
                    '0030
                    CharacterID(0) = &HFD
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Snap Shot" Then
                    'CE01
                    '0030
                    CharacterID(0) = &HCE
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spotlight" Then
                    'E301
                    '0030
                    CharacterID(0) = &HE3
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spry" Then
                    'F701
                    '0030
                    CharacterID(0) = &HF7
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sure Shot Shroomboom" Then
                    '7100
                    '0138
                    CharacterID(0) = &H71
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Terrabite" Then
                    'F901
                    '0030
                    CharacterID(0) = &HF9
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Thumpling" Then
                    '1D02
                    '0030
                    CharacterID(0) = &H1D
                    CharacterID(1) = &H2
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Thunderbolt" Then
                    'C301
                    '0030
                    CharacterID(0) = &HC3
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tidal Wave Gill Grunt" Then
                    '0E00
                    '0938
                    CharacterID(0) = &HE
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H9
                    CharacterVariant(1) = &H38
                ElseIf frmMain.lstCharacters.SelectedItem Is "Torch" Then
                    'CD01
                    '0030
                    CharacterID(0) = &HCD
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Trail Blazer" Then
                    'CC01
                    '0030
                    CharacterID(0) = &HCC
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tread Head" Then
                    'D901
                    '0030
                    CharacterID(0) = &HD9
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Trigger Snappy" Then
                    '0702
                    '0030
                    CharacterID(0) = &H7
                    CharacterID(1) = &H2
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tuff Luck" Then
                    'DB01
                    '0030
                    CharacterID(0) = &HDB
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Wallop" Then
                    'C601
                    '0030
                    CharacterID(0) = &HC6
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Weeruptor" Then
                    'FB01
                    '0030
                    CharacterID(0) = &HFB
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Whisper Elf" Then
                    '0E02
                    '0030
                    CharacterID(0) = &HE
                    CharacterID(1) = &H2
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Wildfire" Then
                    'CA01
                    '0030
                    CharacterID(0) = &HCA
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Winterfest Lob-Star" Then
                    'CF01
                    '0234
                    CharacterID(0) = &HCF
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H34
                End If
            Case 4
                'Superchargers
                If frmMain.lstCharacters.SelectedItem Is "Astroblast" Then
                    '620D
                    '0041
                    CharacterID(0) = &H62
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Barrel Blaster" Then
                    'A80C
                    '0040
                    CharacterID(0) = &HA8
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Big Bubble Pop Fizz" Then
                    '5C0D
                    '0041
                    CharacterID(0) = &H5C
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Birthday Bash Big Bubble Pop Fizz" Then
                    '5C0D
                    '0E45
                    CharacterID(0) = &H5C
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &HE
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Bone Bash Roller Brawl" Then
                    '590D
                    '0041
                    CharacterID(0) = &H59
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Burn-Cycle" Then
                    '970C
                    '0040
                    CharacterID(0) = &H97
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Buzz Wing" Then
                    'A909
                    '0040
                    CharacterID(0) = &HA9
                    CharacterID(1) = &H9
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Clown Cruiser" Then
                    'A10C
                    '0040
                    CharacterID(0) = &HA1
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Crypt Crusher" Then
                    '9B0C
                    '0040
                    CharacterID(0) = &H9B
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Barrel Blaster" Then
                    'A80C
                    '0244
                    CharacterID(0) = &HA8
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H44
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Clown Cruiser" Then
                    'A10C
                    '0244
                    CharacterID(0) = &HA1
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H44
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Hammer Slam Bowser" Then
                    '600D
                    '0245
                    CharacterID(0) = &H60
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Hot Streak" Then
                    '980C
                    '0244
                    CharacterID(0) = &H98
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H44
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Sea Shadow" Then
                    'A50C
                    '0244
                    CharacterID(0) = &HA5
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H44
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Spitfire" Then
                    '540D
                    '0245
                    CharacterID(0) = &H54
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Super Shot Stealth Elf" Then
                    '570D
                    '0245
                    CharacterID(0) = &H57
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Turbo Charge Donkey Kong" Then
                    '5F0D
                    '0245
                    CharacterID(0) = &H5F
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Deep Dive Gill Grunt" Then
                    '5E0D
                    '0041
                    CharacterID(0) = &H5E
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dive Bomber" Then
                    '9F0C
                    '0040
                    CharacterID(0) = &H9F
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dive-Clops" Then
                    '610D
                    '0041
                    CharacterID(0) = &H61
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Double Dare Trigger Happy" Then
                    '560D
                    '0041
                    CharacterID(0) = &H56
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "E3 Hot Streak" Then
                    '970C
                    '0440
                    CharacterID(0) = &H97
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H4
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Eggcited Thrillipede" Then
                    '640D
                    '0D45
                    CharacterID(0) = &H64
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &HD
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Boomer" Then
                    '1600
                    '1048
                    CharacterID(0) = &H16
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H48
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Dino-Rang" Then
                    '0600
                    '1048
                    CharacterID(0) = &H6
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H48
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Ghost Roaster" Then
                    '1F00
                    '1048
                    CharacterID(0) = &H1F
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H48
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Slam Bam" Then
                    '0f00
                    '1048
                    CharacterID(0) = &HF
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H48
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Voodood" Then
                    '1100
                    '1148
                    CharacterID(0) = &H11
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H11
                    CharacterVariant(1) = &H48
                ElseIf frmMain.lstCharacters.SelectedItem Is "Elite Zook" Then
                    '1900
                    '1048
                    CharacterID(0) = &H19
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H48
                ElseIf frmMain.lstCharacters.SelectedItem Is "Fiesta" Then
                    '480D
                    '0041
                    CharacterID(0) = &H48
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Frightful Fiesta" Then
                    '480D
                    '1545
                    CharacterID(0) = &H48
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H15
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Gold Rusher" Then
                    'A20C
                    '0040
                    CharacterID(0) = &HA2
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Golden Hot Streak" Then
                    '980C
                    '1E44
                    CharacterID(0) = &H98
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H1E
                    CharacterVariant(1) = &H44
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hammer Slam Bowser" Then
                    '600D
                    '0041
                    CharacterID(0) = &H60
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "High Volt" Then
                    '490D
                    '0041
                    CharacterID(0) = &H49
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hot Streak" Then
                    '980C
                    '0440
                    CharacterID(0) = &H98
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H4
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hurricane Jet-Vac" Then
                    '550D
                    '0041
                    CharacterID(0) = &H55
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Instant Dive Bomber" Then

                    blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Instant Dive-Clops" Then

                    blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Instant Hot Streak" Then

                    blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Instant Spitfire" Then

                    blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Instant Stealth Stinger" Then

                    blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Instant Super Shot Stealth Elf" Then

                    blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Jet Stream" Then
                    '940C
                    '0040
                    CharacterID(0) = &H94
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Kaos Trophy" Then
                    'AF0D
                    '0040
                    CharacterID(0) = &HAF
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Land Trophy" Then
                    'AD0D
                    '0040
                    CharacterID(0) = &HAD
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Lava Lance Eruptor" Then
                    '5D0D
                    '0041
                    CharacterID(0) = &H5D
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Astroblast" Then
                    '620D
                    '0345
                    CharacterID(0) = &H62
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Bone Bash Roller Brawl" Then
                    '590D
                    '0345
                    CharacterID(0) = &H59
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Hurricane Jet-Vac" Then
                    '550D
                    '0345
                    CharacterID(0) = &H55
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Sun Runner" Then
                    'A40C
                    '0344
                    CharacterID(0) = &HA4
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H44
                ElseIf frmMain.lstCharacters.SelectedItem Is "Missile-Tow Dive-Clops" Then
                    '610D
                    '0E45
                    CharacterID(0) = &H61
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &HE
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Nightfall" Then
                    '630D
                    '0041
                    CharacterID(0) = &H63
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Nitro Soda Skimmer" Then
                    'A70C
                    '0244
                    CharacterID(0) = &HA7
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H44
                ElseIf frmMain.lstCharacters.SelectedItem Is "Nitro Stealth Stinger" Then
                    '9C0C
                    '0244
                    CharacterID(0) = &H9C
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H44
                ElseIf frmMain.lstCharacters.SelectedItem Is "Power Blue Gold Rusher" Then
                    'A20C
                    '0244
                    CharacterID(0) = &HA2
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H44
                ElseIf frmMain.lstCharacters.SelectedItem Is "Power Blue Splat" Then
                    '4A0D
                    '0245
                    CharacterID(0) = &H4A
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Power Blue Splatter Splasher" Then
                    'A60C
                    '0244
                    CharacterID(0) = &HA6
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H44
                ElseIf frmMain.lstCharacters.SelectedItem Is "Power Blue Trigger Happy" Then
                    '560D
                    '0245
                    CharacterID(0) = &H56
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Reef Ripper" Then
                    '960C
                    '0040
                    CharacterID(0) = &H96
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sea Shadow" Then
                    'A50C
                    '0040
                    CharacterID(0) = &HA5
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sea Trophy" Then
                    'AE0D
                    '0040
                    CharacterID(0) = &HAE
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Shark Shooter Terrafin" Then
                    '580D
                    '0041
                    CharacterID(0) = &H58
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Shark Tank" Then
                    '990C
                    '0040
                    CharacterID(0) = &H99
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Shield Striker" Then
                    'A30C
                    '0040
                    CharacterID(0) = &HA3
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sky Slicer" Then
                    'A00C
                    '0040
                    CharacterID(0) = &HA0
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sky Trophy" Then
                    'AC0D
                    '0040
                    CharacterID(0) = &HAC
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Smash Hit" Then
                    '530D
                    '0041
                    CharacterID(0) = &H53
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Soda Skimmer" Then
                    'A70C
                    '0040
                    CharacterID(0) = &HA7
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spitfire" Then
                    '540D
                    '0041
                    CharacterID(0) = &H54
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Splat" Then
                    '4A0D
                    '0041
                    CharacterID(0) = &H4A
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Splatter Splasher" Then
                    'A60C
                    '0040
                    CharacterID(0) = &HA6
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spring Ahead Dive Bomber" Then
                    '9F0C
                    '0244
                    CharacterID(0) = &H9F
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H44
                ElseIf frmMain.lstCharacters.SelectedItem Is "Stealth Stinger" Then
                    '9C0C
                    '0040
                    CharacterID(0) = &H9C
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Steel Plated Smash Hit" Then
                    '530D
                    '0245
                    CharacterID(0) = &H53
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H45
                ElseIf frmMain.lstCharacters.SelectedItem Is "Stormblade" Then
                    '4e0d
                    '0041
                    CharacterID(0) = &H4E
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sun Runner" Then
                    'A40C
                    '0040
                    CharacterID(0) = &HA4
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Super Shot Stealth Elf" Then
                    '570D
                    '0041
                    CharacterID(0) = &H57
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Thrillipede" Then
                    '640D
                    '0041
                    CharacterID(0) = &H64
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                ElseIf frmMain.lstCharacters.SelectedItem Is "Thump Truck" Then
                    '9A0C
                    '0040
                    CharacterID(0) = &H9A
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tomb Buggy" Then
                    '950C
                    '0040
                    CharacterID(0) = &H95
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Turbo Charge Donkey Kong" Then
                    '5F0D
                    '0041
                    CharacterID(0) = &H5F
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H41
                End If
            Case 5
                'Imaginators
                CharacterVariant(0) = &H0
                CharacterVariant(1) = &H50
                If frmMain.lstCharacters.SelectedItem Is "Air Strike" Then
                    '5F02
                    CharacterID(0) = &H5F
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Ambush" Then
                    '6102
                    CharacterID(0) = &H61
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Aurora" Then
                    '6B02
                    'Aurora
                    CharacterID(0) = &H6B
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Bad Juju" Then
                    '6E02
                    'Bad Juju
                    CharacterID(0) = &H6E
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Barbella" Then
                    'Barbella
                    '5E02
                    CharacterID(0) = &H5E
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Blaster-Tron" Then
                    '7002
                    'Blaster-Tron
                    CharacterID(0) = &H70
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Boom Bloom" Then
                    '5C02
                    'Boom Bloom
                    CharacterID(0) = &H5C
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Buckshot" Then
                    '6A02
                    'Buckshot
                    CharacterID(0) = &H6A
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Candy-Coated Chopscotch" Then
                    '5B02
                    CharacterVariant(0) = &H15
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H5B
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Chain Reaction" Then
                    '7202
                    'Chain Reaction
                    CharacterID(0) = &H72
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Chompy Mage" Then
                    '6D02
                    'Chompy Mage
                    CharacterID(0) = &H6D
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Chopscotch" Then
                    '5B02
                    'Chopscotch
                    CharacterID(0) = &H5B
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Crash Bandicoot" Then
                    '7602
                    'Crash Bandicoot
                    CharacterID(0) = &H76
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Golden Queen" Then
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H65
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark King Pen" Then
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H59
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Wolfgang" Then
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H66
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dr. Krankcase" Then
                    '6202
                    'Dr.Krankcase
                    CharacterID(0) = &H62
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dr. Neo Cortex" Then
                    '7702
                    'Dr.Neo Cortex
                    CharacterID(0) = &H77
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Egg Bomber Air Strike" Then
                    CharacterVariant(0) = &HD
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H5F
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Ember" Then
                    '6002
                    'Ember
                    CharacterID(0) = &H60
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Flare Wolf" Then
                    '6C02
                    'Flarewolf
                    CharacterID(0) = &H6C
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Golden Queen" Then
                    '6502
                    'Golden Queen
                    CharacterID(0) = &H65
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Grave Clobber" Then
                    '6F02
                    'Grave Clobber
                    CharacterID(0) = &H6F
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hard-Boiled Flare Wolf" Then
                    CharacterVariant(0) = &HD
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H6C
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Heartbreaker Buckshot" Then
                    CharacterVariant(0) = &HD
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H6A
                    CharacterID(1) = &H2
                    frmMain.SaldeStatus.Text = "WARNING: Expermential"
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hood Sickle" Then
                    '6302
                    'Hood Sickle
                    CharacterID(0) = &H63
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Jingle Bell Chompy Mage" Then
                    CharacterVariant(0) = &HE
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H6D
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Kaos" Then
                    '7302
                    CharacterID(0) = &H73
                    CharacterID(0) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "King Pen" Then
                    '5902
                    'King Pen
                    CharacterID(0) = &H59
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Pit Boss" Then
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &HD
                    CharacterID(1) = &H25
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Tri-Tip" Then
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H5A
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Mystical Bad Juju" Then
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H6E
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Mystical Tae Kwon Crow" Then
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H64
                    CharacterID(1) = &H2
                    'blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Mysticat" Then
                    '6802
                    'Mysticat
                    CharacterID(0) = &H68
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Pain-Yatta" Then
                    '6702
                    'Pain-Yatta
                    CharacterID(0) = &H67
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Pit Boss" Then
                    '0D25
                    CharacterID(0) = &HD
                    CharacterID(1) = &H25
                    blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Ro-Bow" Then
                    '7102
                    'Ro-Bow
                    CharacterID(0) = &H71
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Solar Flare Aurora" Then
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H6B
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Starcast" Then
                    '6902
                    'Starcast
                    CharacterID(0) = &H69
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Steel Plated Hood Sickle" Then
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H54
                    CharacterID(0) = &H63
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tae Kwon Crow" Then
                    '6402
                    'Tae Kwon Crow
                    CharacterID(0) = &H64
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tidepool" Then
                    '7502
                    'Tidepool
                    CharacterID(0) = &H75
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tri-Tip" Then
                    '5A02
                    'Tri-Tip
                    CharacterID(0) = &H5A
                    CharacterID(1) = &H2
                ElseIf frmMain.lstCharacters.SelectedItem Is "Wild Storm" Then
                    '7402
                    CharacterID(0) = &H74
                    CharacterID(1) = &H2
                    'Wild Storm
                ElseIf frmMain.lstCharacters.SelectedItem Is "Wolfgang" Then
                    '6602
                    'Wolfgang
                    CharacterID(0) = &H66
                    CharacterID(1) = &H2
                    'Chests
                End If
            Case 6
                'Items
                If frmMain.lstCharacters.SelectedItem Is "Anvil Rain" Then
                    'C800
                    '0020
                    CharacterID(0) = &HC8
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Arkeyan Crossbow" Then
                    'E70C
                    '0622
                    CharacterID(0) = &HE7
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H22
                ElseIf frmMain.lstCharacters.SelectedItem Is "Battle Hammer" Then
                    '800C
                    '0020
                    CharacterID(0) = &H80
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dragonfire Cannon" Then
                    'D000
                    '0612
                    CharacterID(0) = &HD0
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "Golden Dragonfire Cannon" Then
                    'D000
                    '0216
                    CharacterID(0) = &HD0
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H16
                ElseIf frmMain.lstCharacters.SelectedItem Is "Ghost Pirate Swords" Then
                    'CB00
                    '0020
                    CharacterID(0) = &HCB
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Groove Machine" Then
                    '830C
                    '0020
                    CharacterID(0) = &H83
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hand of Fate" Then
                    'E600
                    '0000
                    CharacterID(0) = &HE6
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Hand of Fate" Then
                    'E600
                    '0334
                    CharacterID(0) = &HE6
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Healing Elixir" Then
                    'CA00
                    '0000
                    CharacterID(0) = &HCA
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "Hidden Treasure" Then
                    'C900
                    '0020
                    CharacterID(0) = &HC9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Platinum Hidden Treasure" Then
                    'C900
                    '0000
                    CharacterID(0) = &HC9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "Blue Imaginite Mystery Chest" Then
                    'Figure: EB00
                    'Variant: 1750
                    'Blue Mystery Chest
                    CharacterID(0) = &HEB
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H17
                    CharacterVariant(1) = &H50
                ElseIf frmMain.lstCharacters.SelectedItem Is "Bronze Imaginite Mystery Chest" Then
                    'Figure: EB00
                    'Variant: 0150
                    'Blue Mystery Chest
                    CharacterID(0) = &HEB
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H50
                ElseIf frmMain.lstCharacters.SelectedItem Is "Gold Imaginite Mystery Chest" Then
                    'Figure: EB00
                    'Variant: 0350
                    'Blue Mystery Chest
                    CharacterID(0) = &HEB
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H50
                ElseIf frmMain.lstCharacters.SelectedItem Is "Silver Imaginite Mystery Chest" Then
                    'Figure: EB00
                    'Variant: 0250
                    'Blue Mystery Chest
                    CharacterID(0) = &HEB
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H50
                ElseIf frmMain.lstCharacters.SelectedItem Is "Platnium Imaginite Mystery Chest" Then
                    'Figure: EB00
                    'Variant: 1950
                    'Blue Mystery Chest
                    CharacterID(0) = &HEB
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H19
                    CharacterVariant(1) = &H50
                ElseIf frmMain.lstCharacters.SelectedItem Is "Kaos Trophy" Then
                    'AF0D
                    '0040
                    CharacterID(0) = &HAF
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Land Trophy" Then
                    'AD0D
                    '0040
                    CharacterID(0) = &HAD
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Piggy Bank" Then
                    'E700
                    '0000
                    CharacterID(0) = &HE7
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "Platinum Sheep" Then
                    '820C
                    '0020
                    CharacterID(0) = &H82
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Rocket Ram" Then
                    'E800
                    '0000
                    CharacterID(0) = &HE8
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "Scorpion Striker" Then
                    'D100
                    '0612
                    CharacterID(0) = &HD1
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H12
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sea Trophy" Then
                    'AE0D
                    '0040
                    CharacterID(0) = &HAE
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sky Diamond" Then
                    '810C
                    '0020
                    CharacterID(0) = &H81
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sky Trophy" Then
                    'AC0D
                    '0040
                    CharacterID(0) = &HAC
                    CharacterID(1) = &HD
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H40
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sky-Iron Shield" Then
                    'CD00
                    '0020
                    CharacterID(0) = &HCD
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sparx the Dragonfly" Then
                    'CF00
                    '0000
                    CharacterID(0) = &HCF
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tiki Speaky" Then
                    'E900
                    '0000
                    CharacterID(0) = &HE9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "Time Twister Hourglass" Then
                    'CC00
                    '0000
                    CharacterID(0) = &HCC
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "UFO Hat" Then
                    '840C
                    CharacterID(0) = &H84
                    CharacterID(1) = &HC
                    '0020
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Winged Boots" Then
                    'CE00
                    '0000
                    CharacterID(0) = &HCE
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H0
                End If
            Case 7
                'Traps
                'Not sure if these are the right Byte Values
                'CharacterID(1) = &H0
                'CharacterVariant(1) = &H30
                '--Air--
                If frmMain.lstCharacters.SelectedItem Is "Breezy Bird (Toucan)" Then
                    '0330
                    'D400
                    CharacterID(0) = &HD4
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &HD4
                    CharacterVariant(1) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "Cloudy Cobra (Snake)" Then
                    '1030
                    'D400
                    CharacterID(0) = &HD4
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Cyclone Sabre (Sword)" Then
                    '1830
                    'D400
                    CharacterID(0) = &HD4
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H18
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Drafty Decanter (Jughead)" Then
                    '0630
                    'D400
                    CharacterID(0) = &HD4
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Storm Warning (Screamer)" Then
                    '1130
                    'D400
                    CharacterID(0) = &HD4
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H11
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tempest Timer (Hourglass)" Then
                    '0E30
                    'D400
                    CharacterID(0) = &HD4
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &HE
                    CharacterVariant(1) = &H30

                    '--Dark--
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dark Dagger (Sword)" Then
                    '1830
                    'DA00
                    CharacterID(0) = &HDA
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H18
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Ghastly Grimace (Handstand)" Then
                    '1A30
                    'DA00
                    CharacterID(0) = &HDA
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1A
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Shadow Spider (Spider)" Then
                    '1430
                    'DA00
                    CharacterID(0) = &HDA
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H14
                    CharacterVariant(1) = &H30

                    '--Earth--
                ElseIf frmMain.lstCharacters.SelectedItem Is "Banded Boulder (Orb)" Then
                    '0430
                    'D800
                    CharacterID(0) = &HD8
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H4
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dust of Time (Hourglass)" Then
                    '0E30
                    'D800
                    CharacterID(0) = &HD8
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &HE
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Rock Hawk (Toucan)" Then
                    '0330
                    'D800
                    CharacterID(0) = &HD8
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Rubble Trouble (Handstand)" Then
                    '1A30
                    'D800
                    CharacterID(0) = &HD8
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1A
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Slag Hammer (Hammer)" Then
                    '0A30
                    'D800
                    CharacterID(0) = &HD8
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &HA
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spinning Sandstorm (Totem)" Then
                    '1230
                    'D800
                    CharacterID(0) = &HD8
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H12
                    CharacterVariant(1) = &H30

                    '--Fire--
                ElseIf frmMain.lstCharacters.SelectedItem Is "Blazing Belch (Yawn)" Then
                    '1B30
                    'D700
                    CharacterID(0) = &HD7
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1B
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Eternal Flame (Torch)" Then
                    '0530
                    'D700
                    CharacterID(0) = &HD7
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Fire Flower (Scepter)" Then
                    '0130
                    'D700                    
                    CharacterID(0) = &HD7
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Scorching Stopper (Screamer)" Then
                    '1130
                    'D700
                    CharacterID(0) = &HD7
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H11
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Searing Spinner (Totem)" Then
                    '1230
                    'D700
                    CharacterID(0) = &HD7
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H12
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spark Spear (Captain's Hat)" Then
                    '1730
                    'D700
                    CharacterID(0) = &HD7
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H17
                    CharacterVariant(1) = &H30

                    '--Life--
                ElseIf frmMain.lstCharacters.SelectedItem Is "Emerald Energy (Torch)" Then
                    '0530
                    'D900
                    CharacterID(0) = &HD9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H5
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Jade Blade (Sword)" Then
                    '1830
                    'D900
                    CharacterID(0) = &HD9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H18
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Oak Eagle (Toucan)" Then
                    '0330
                    'D900
                    CharacterID(0) = &HD9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H3
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Seed Serpent (Snake)" Then
                    '1030
                    'D900
                    CharacterID(0) = &HD9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Shrub Shrieker (Yawn)" Then
                    '1B30
                    'D900
                    CharacterID(0) = &HD9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1B
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Weed Whacker (Hammer)" Then
                    '0A30
                    'D900
                    CharacterID(0) = &HD9
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &HA
                    CharacterVariant(1) = &H30

                    '--Light--
                ElseIf frmMain.lstCharacters.SelectedItem Is "Beam Scream (Yawn)" Then
                    '1B30
                    'DB00
                    CharacterID(0) = &HDB
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1B
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Heavenly Hawk (Hawk)" Then
                    '0F30
                    'DB00
                    CharacterID(0) = &HF
                    CharacterID(1) = &H30
                    CharacterVariant(0) = &HDB
                    CharacterVariant(1) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "Shining Ship (Rocket)" Then
                    '1530
                    'DB00
                    CharacterID(0) = &HDB
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H15
                    CharacterVariant(1) = &H30

                    '--Magic--
                ElseIf frmMain.lstCharacters.SelectedItem Is "Arcane Hourglass (Hourglass)" Then
                    '0E30
                    'D200                    
                    CharacterID(0) = &HD2
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &HE
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Axe of Illusion (Axe)" Then
                    '0B30
                    'D200
                    CharacterID(0) = &HD2
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &HB
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Biter's Bane (Log Holder)" Then
                    '0130
                    'D200
                    CharacterID(0) = &HD2
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Rune Rocket (Rocket)" Then
                    '1530
                    'D200
                    CharacterID(0) = &HD2
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H15
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sorcerous Skull (Skull)" Then
                    '0830
                    'D200
                    CharacterID(0) = &HD2
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H8
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spell Slapper (Totem)" Then
                    '1230
                    'D100
                    CharacterID(0) = &HD1
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H12
                    CharacterVariant(1) = &H30

                    '--Tech--
                ElseIf frmMain.lstCharacters.SelectedItem Is "Automatic Angel (Angel)" Then
                    '0730
                    'D600
                    CharacterID(0) = &HD6
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H7
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Factory Flower (Scepter)" Then
                    '0930
                    'D600
                    CharacterID(0) = &HD6
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H9
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Grabbing Gadget (Hand)" Then
                    '0C30
                    'D600
                    CharacterID(0) = &HD6
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &HC
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Makers Mana (Flying Helmet)" Then
                    '1630
                    'D600
                    CharacterID(0) = &HD6
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H16
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tech Totem (Tiki)" Then
                    '0130
                    'D600
                    CharacterID(0) = &HD6
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Topsy Techy (Handstand)" Then
                    '1A30
                    'D600
                    CharacterID(0) = &HD6
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1A
                    CharacterVariant(1) = &H30

                    '--Undead--
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dream Piercer (Captain's Hat)" Then
                    '1730
                    'D500
                    CharacterID(0) = &HD5
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H17
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Grim Gripper (Hand)" Then
                    '0C30
                    'D600
                    CharacterID(0) = &HD5
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &HC
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Haunted Hatchet (Axe)" Then
                    '0B30
                    'D500
                    CharacterID(0) = &HD5
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &HB
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spectral Skull (Skull)" Then
                    '0830
                    'D500
                    CharacterID(0) = &HD5
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H8
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spirit Sphere (Orb)" Then
                    '0430
                    'D500
                    CharacterID(0) = &HD5
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H4
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Spooky Snake (Snake)" Then
                    '1030
                    'D500
                    CharacterID(0) = &HD5
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H10
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Spirit Sphere (Orb)" Then
                    '0434
                    '0434
                    CharacterID(0) = &H4
                    CharacterID(1) = &H34
                    CharacterVariant(0) = &H4
                    CharacterVariant(1) = &H34
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Spectral Skull (Skull)" Then
                    '0834
                    'D500
                    CharacterID(0) = &HD5
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H8
                    CharacterVariant(1) = &H34

                    '--Water--
                ElseIf frmMain.lstCharacters.SelectedItem Is "Aqua Axe (Axe)" Then
                    '0B30
                    'D300
                    CharacterID(0) = &HD3
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &HB
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Flood Flask (Jughead)" Then
                    '0630
                    'D300
                    CharacterID(0) = &HD3
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Frost Helm (Flying Helmet)" Then
                    '1630
                    'D300
                    CharacterID(0) = &HD3
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H16
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Soaking Staff (Angel)" Then
                    '0730
                    'D300
                    CharacterID(0) = &HD3
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H7
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tidal Tiki (Tiki)" Then
                    '0130
                    'D300
                    CharacterID(0) = &HD3
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Wet Walter (Log Holder)" Then
                    '0230
                    'D300
                    CharacterID(0) = &HD3
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H2
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Legendary Flood Flask (Jughead)" Then
                    '0634
                    'D300
                    CharacterID(0) = &HD3
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H34

                    '--Kaos--
                ElseIf frmMain.lstCharacters.SelectedItem Is "The Kaos Trap" Then
                    '1E30
                    'DC00
                    CharacterID(0) = &HDC
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1E
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Ultimate Kaos Trap" Then
                    '1F35
                    'DC00
                    CharacterID(0) = &HDC
                    CharacterID(1) = &H0
                    CharacterVariant(0) = &H1F
                    CharacterVariant(1) = &H35
                End If
            Case 8
                'Adventure Packs
                If frmMain.lstCharacters.SelectedItem Is "Cursed Tiki Temple" Then

                    blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Darklight Crypt" Then
                    '2F01
                    '0000
                    CharacterID(0) = &H2F
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "Dragon's Peak" Then
                    '2C01
                    '0000
                    CharacterID(0) = &H2C
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H0
                ElseIf frmMain.lstCharacters.SelectedItem Is "Empire of Ice" Then
                    '2D01
                    '0020
                    CharacterID(0) = &H2D
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Enchanted Elven Forest" Then
                    CharacterID(0) = &H37
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H50
                ElseIf frmMain.lstCharacters.SelectedItem Is "Fiery Forge" Then
                    'E60C
                    '0622
                    CharacterID(0) = &HE6
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H22
                ElseIf frmMain.lstCharacters.SelectedItem Is "Gryphon Park Observatory" Then
                    CharacterID(0) = &H36
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H50
                ElseIf frmMain.lstCharacters.SelectedItem Is "Lost Imaginite Mines" Then

                    blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Midnight Museum" Then
                    '3401
                    '0030
                    'Alt Variant
                    '0632
                    CharacterID(0) = &H34
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Mirror of Mystery" Then
                    '3101
                    '0030
                    CharacterID(0) = &H31
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Nightmare Express" Then
                    '3201
                    '0030
                    CharacterID(0) = &H32
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H30
                ElseIf frmMain.lstCharacters.SelectedItem Is "Pirate Seas" Then
                    '2E01
                    '0020
                    CharacterID(0) = &H2E
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sheep Wreck Island" Then
                    'E40C
                    '0020
                    CharacterID(0) = &HE4
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Sunscraper Spire" Then
                    '3301
                    '0632
                    CharacterID(0) = &H33
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H6
                    CharacterVariant(1) = &H32
                ElseIf frmMain.lstCharacters.SelectedItem Is "Thumpin' Wumpa Islands" Then
                    blnNoCode = True
                ElseIf frmMain.lstCharacters.SelectedItem Is "Tower of Time" Then
                    'E50C
                    '0020
                    CharacterID(0) = &HE5
                    CharacterID(1) = &HC
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                ElseIf frmMain.lstCharacters.SelectedItem Is "Volcanic Vault" Then
                    '3001
                    '0020
                    CharacterID(0) = &H30
                    CharacterID(1) = &H1
                    CharacterVariant(0) = &H0
                    CharacterVariant(1) = &H20
                End If
            Case Else
                blnNoCode = True
        End Select
        DetermineWrite()
    End Sub
#End Region

#Region " Determine Figure's ID and Variant"
    'Mostly Complete.  Missing Imaginators, Items, Traps and Adventure Packs

    Public Shared Sub FigureItOut()
        'MessageBox.Show(Var & " " & Fig)
        If Var = "0000" Then
            frmMain.cmbGame.SelectedItem = "Spyro's Adventure"
            ''Application.DoEvents()
            Select Case Fig
                Case "0400"
                    'Bash
                    frmMain.lstCharacters.SelectedIndex = 0
                Case "1600"
                    'Boomer
                    frmMain.lstCharacters.SelectedIndex = 1
                Case "1800"
                    'Camo
                    frmMain.lstCharacters.SelectedIndex = 2
                Case "1E00"
                    'Chop Chop
                    frmMain.lstCharacters.SelectedIndex = 3
                Case "2000"
                    'Cynder
                    frmMain.lstCharacters.SelectedIndex = 4
                Case "1C00"
                    'Dark Spyro
                    frmMain.lstCharacters.SelectedIndex = 5
                Case "0600"
                    'Dino-Rang
                    frmMain.lstCharacters.SelectedIndex = 6
                Case "1200"
                    'Double Trouble
                    frmMain.lstCharacters.SelectedIndex = 7
                Case "1500"
                    'Drill Sergeant
                    frmMain.lstCharacters.SelectedIndex = 8
                Case "1400"
                    'Drobot
                    frmMain.lstCharacters.SelectedIndex = 9
                Case "0900"
                    'Eruptor
                    frmMain.lstCharacters.SelectedIndex = 10
                Case "0B00"
                    'Flameslinger
                    frmMain.lstCharacters.SelectedIndex = 11
                Case "1F00"
                    'Ghost Roaster
                    frmMain.lstCharacters.SelectedIndex = 12
                Case "0E00"
                    'Gill Grunt
                    frmMain.lstCharacters.SelectedIndex = 13
                Case "1D00"
                    'Hex
                    frmMain.lstCharacters.SelectedIndex = 14
                Case "0A00"
                    'Ignitor
                    frmMain.lstCharacters.SelectedIndex = 15
                Case "9401"
                    'Legendary Bash
                    frmMain.lstCharacters.SelectedIndex = 16
                Case "AE01"
                    'Legendary Chop Chop
                    frmMain.lstCharacters.SelectedIndex = 17
                Case "A001"
                    'Legendary Spyro
                    frmMain.lstCharacters.SelectedIndex = 18
                Case "A301"
                    'Legendary Trigger Happy
                    frmMain.lstCharacters.SelectedIndex = 19
                Case "0300"
                    'Lightning Rod
                    frmMain.lstCharacters.SelectedIndex = 20
                Case "0700"
                    'Prism Break
                    frmMain.lstCharacters.SelectedIndex = 21
                Case "0F00"
                    'Slam Bam
                    frmMain.lstCharacters.SelectedIndex = 22
                Case "0100"
                    'Sonic Boom
                    frmMain.lstCharacters.SelectedIndex = 23
                Case "1000"
                    'Spyro
                    frmMain.lstCharacters.SelectedIndex = 24
                Case "1A00"
                    'Stealth Elf
                    frmMain.lstCharacters.SelectedIndex = 25
                Case "1B00"
                    'Stump Smash
                    frmMain.lstCharacters.SelectedIndex = 26
                Case "0800"
                    'Sunburn
                    frmMain.lstCharacters.SelectedIndex = 27
                Case "0500"
                    'Terrafin
                    frmMain.lstCharacters.SelectedIndex = 28
                Case "1300"
                    'Trigger Happy
                    frmMain.lstCharacters.SelectedIndex = 29
                Case "1100"
                    'Voodood
                    frmMain.lstCharacters.SelectedIndex = 30
                Case "0200"
                    'Warnado
                    frmMain.lstCharacters.SelectedIndex = 31
                Case "0D00"
                    'Wham-Shell
                    frmMain.lstCharacters.SelectedIndex = 32
                Case "0000"
                    'Whirlwind
                    frmMain.lstCharacters.SelectedIndex = 33
                Case "1700"
                    'Wrecking Ball
                    frmMain.lstCharacters.SelectedIndex = 34
                Case "0C00"
                    'Zap
                    frmMain.lstCharacters.SelectedIndex = 35
                Case "1900"
                    'Zook
                    frmMain.lstCharacters.SelectedIndex = 36
                Case "2F01"
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    'Darklight Crypt
                    frmMain.lstCharacters.SelectedItem = "Darklight Crypt"
                Case "2C01"
                    'Dragon's Peak
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Dragon's Peak"
                Case "F901"
                    'Terrabite
                    frmMain.cmbGame.SelectedItem = "Trap Team"
                    frmMain.lstCharacters.SelectedItem = "Terrabite"
                Case "0E02"
                    'Whisper Elf
                    frmMain.cmbGame.SelectedItem = "Trap Team"
                    frmMain.lstCharacters.SelectedItem = "Whisper Elf"
                Case "0202"
                    'Gill Runt
                    frmMain.cmbGame.SelectedItem = "Trap Team"
                    frmMain.lstCharacters.SelectedItem = "Gill Runt"
                Case "0702"
                    'Trigger Snappy
                    frmMain.cmbGame.SelectedItem = "Trap Team"
                    frmMain.lstCharacters.SelectedItem = "Trigger Snappy"
                Case "E700"
                    'Piggy Bank
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Piggy Bank"
                Case "E800"
                    'Rocket Ram
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Rocket Ram"
                Case "E900"
                    'Tiki Speaky
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Tiki Speaky"
                Case "E600"
                    'Hand of Fate
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Hand of Fate"
                Case "C900"
                    'Hidden Treasure (Platinum)
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Platinum Hidden Treasure"
                Case "CE00"
                    'Winged Boots
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Winged Boots"
                Case "CA00"
                    'Healing Elixir
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Healing Elixir"
                Case "CF00"
                    'Sparks the Dragonfly
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Sparx the Dragonfly"
                Case "CC00"
                    'Time Twister
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Time Twister Hourglass"
            End Select
        ElseIf Var = "0010" Then
            frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "1C02"
                    'Barkley
                    frmMain.cmbGame.SelectedItem = "Trap Team"
                    frmMain.lstCharacters.SelectedItem = "Barkley"
                Case "6A00"
                    'Chill
                    frmMain.lstCharacters.SelectedItem = "Chill"
                Case "6700"
                    'Flashwing
                    frmMain.lstCharacters.SelectedItem = "Flashwing"
                Case "7300"
                    'Fright Rider
                    frmMain.lstCharacters.SelectedItem = "Fright Rider"
                Case "6900"
                    'Hot Dog
                    frmMain.lstCharacters.SelectedItem = "Hot Dog"
                Case "6400"
                    'Jet-Vac
                    frmMain.lstCharacters.SelectedItem = "Jet-Vac"
                Case "6C00"
                    'Pop Fizz
                    frmMain.lstCharacters.SelectedItem = "Pop Fizz"
                Case "7100"
                    'Shroomboom
                    frmMain.lstCharacters.SelectedItem = "Shroomboom"
                Case "6F00"
                    'Sprocket
                    frmMain.lstCharacters.SelectedItem = "Sprocket"
            End Select
        ElseIf Var = "0118" Then
            frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "0400"
                    'Series 2 Bash
                    frmMain.lstCharacters.SelectedItem = "Series 2 Bash"
                Case "1E00"
                    'Series 2 Chop Chop
                    frmMain.lstCharacters.SelectedItem = "Series 2 Chop Chop"
                Case "2000"
                    'Series 2 Cynder
                    frmMain.lstCharacters.SelectedItem = "Series 2 Cynder"
                Case "1200"
                    'Series 2 Double Trouble
                    frmMain.lstCharacters.SelectedItem = "Series 2 Double Trouble"
                Case "1500"
                    'Series 2 Drill Sergeant
                    frmMain.lstCharacters.SelectedItem = "Series 2 Drill Sergeant"
                Case "1400"
                    'Series 2 Drobot
                    frmMain.lstCharacters.SelectedItem = "Series 2 Drobot"
                Case "0900"
                    'Series 2 Eruptor
                    frmMain.lstCharacters.SelectedItem = "Series 2 Eruptor"
                Case "0B00"
                    'Series 2 Flameslinger
                    frmMain.lstCharacters.SelectedItem = "Series 2 Flameslinger"
                Case "0E00"
                    'Series 2 Gill Grunt
                    frmMain.lstCharacters.SelectedItem = "Series 2 Gill Grunt"
                Case "1D00"
                    'Series 2 Hex
                    frmMain.lstCharacters.SelectedItem = "Series 2 Hex"
                Case "0A00"
                    'Series 2 Ignitor
                    frmMain.lstCharacters.SelectedItem = "Series 2 Ignitor"
                Case "0300"
                    'Series 2 Lightning Rod
                    frmMain.lstCharacters.SelectedItem = "Series 2 Lightning Rod"
                Case "0700"
                    'Series 2 Prism Break
                    frmMain.lstCharacters.SelectedItem = "Series 2 Prism Break"
                Case "0F00"
                    'Series 2 Slam Bam
                    frmMain.lstCharacters.SelectedItem = "Series 2 Slam Bam"
                Case "0100"
                    'Series 2 Sonic Boom
                    frmMain.lstCharacters.SelectedItem = "Series 2 Sonic Boom"
                Case "1000"
                    'Series 2 Spyro
                    frmMain.lstCharacters.SelectedItem = "Series 2 Spyro"
                Case "1A00"
                    'Series 2 Stealth Elf
                    frmMain.lstCharacters.SelectedItem = "Series 2 Stealth Elf"
                Case "1B00"
                    'Series 2 Stump Smash
                    frmMain.lstCharacters.SelectedItem = "Series 2 Stump Smash"
                Case "0500"
                    'Series 2 Terrafin
                    frmMain.lstCharacters.SelectedItem = "Series 2 Terrafin"
                Case "1300"
                    'Series 2 Trigger Happy
                    frmMain.lstCharacters.SelectedItem = "Series 2 Trigger Happy"
                Case "0000"
                    'Series 2 Whirlwind
                    frmMain.lstCharacters.SelectedItem = "Series 2 Whirlwind"
                Case "1700"
                    'Series 2 Wrecking Ball
                    frmMain.lstCharacters.SelectedItem = "Series 2 Wrecking Ball"
                Case "0C00"
                    'Series 2 Zap
                    frmMain.lstCharacters.SelectedItem = "Series 2 Zap"
                Case "1900"
                    'Series 2 Zook
                    frmMain.lstCharacters.SelectedItem = "Series 2 Zook"
            End Select
        ElseIf Var = "021C" Then
            frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "1200"
                    'Royal Double Trouble
                    frmMain.lstCharacters.SelectedItem = "Royal Double Trouble"
            End Select
        ElseIf Var = "0214" Then
            frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "6700"
                    'Jade Flashwing
                    frmMain.lstCharacters.SelectedItem = "Jade Flashwing"
                Case "6900"
                    'Molten Hot Dog
                    frmMain.lstCharacters.SelectedItem = "Molten Hot Dog"
                Case "6C00"
                    'Punch Pop Fizz
                    frmMain.lstCharacters.SelectedItem = "Punch Pop Fizz"
            End Select
        ElseIf Var = "0216" Then
            frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "7000"
                    'Gnarly Tree Rex
                    frmMain.lstCharacters.SelectedItem = "Gnarly Tree Rex"
                Case "6600"
                    'Granite Crusher
                    frmMain.lstCharacters.SelectedItem = "Granite Crusher"
                Case "0000"
                    'Polar Whirlwind
                    frmMain.lstCharacters.SelectedItem = "Polar Whirlwind"
                Case "6D00"
                    'Scarlet Ninjini
                    frmMain.lstCharacters.SelectedItem = "Scarlet Ninjini"
                Case "D000"
                    'Golden Dragonfire Cannon
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Golden Dragonfire Cannon"
            End Select
        ElseIf Var = "0354" Then
            frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "5D02"
                    frmMain.lstCharacters.SelectedItem = "Legendary Pit Boss"
                Case "5A02"
                    frmMain.lstCharacters.SelectedItem = "Legendary Tri-Tip"
            End Select
        ElseIf Var = "031C" Then
            frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "0F00"
                    'Legendary Slam Bam
                    frmMain.lstCharacters.SelectedItem = "Legendary Slam Bam"
                Case "1A00"
                    'Legendary Stealth Elf
                    frmMain.lstCharacters.SelectedItem = "Legendary Stealth Elf"
            End Select
        ElseIf Var = "0314" Then
            frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "6400"
                    'Legendary Jet-Vac
                    frmMain.lstCharacters.SelectedItem = "Legendary Jet-Vac"
            End Select
        ElseIf Var = "0316" Then
            frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "6E00"
                    'Legendary Bouncer
                    frmMain.lstCharacters.SelectedItem = "Legendary Bouncer"
                Case "6A00"
                    'Legendary Chill
                    frmMain.lstCharacters.SelectedItem = "Legendary Chill"
                Case "0A00"
                    'Legendary Ignitor
                    frmMain.lstCharacters.SelectedItem = "Legendary Ignitor"
            End Select
        ElseIf Var = "0612" Then
            frmMain.cmbGame.SelectedItem = "Giants"
            Select Case Fig
                Case "D100"
                    'Scorpion Striker
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Scorpion Striker"
                Case "D000"
                    'Dragonfire Cannon
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Dragonfire Cannon"
                Case "6E00"
                    frmMain.lstCharacters.SelectedItem = "Bouncer"
                Case "6600"
                    'Crusher
                    frmMain.lstCharacters.SelectedItem = "Crusher"
                Case "7200"
                    'Eye-Brawl
                    frmMain.lstCharacters.SelectedItem = "Eye-Brawl"
                Case "6800"
                    'Hot Head
                    frmMain.lstCharacters.SelectedItem = "Hot Head"
                Case "6A00"
                    'LightCore Chill
                    frmMain.lstCharacters.SelectedItem = "LightCore Chill"
                Case "1400"
                    'LightCore Drobot
                    frmMain.lstCharacters.SelectedItem = "LightCore Drobot"
                Case "0900"
                    'LightCore Eruptor
                    frmMain.lstCharacters.SelectedItem = "LightCore Eruptor"
                Case "1D00"
                    'LightCore Hex
                    frmMain.lstCharacters.SelectedItem = "LightCore Hex"
                Case "6400"
                    'LightCore Jet-Vac
                    frmMain.lstCharacters.SelectedItem = "LightCore Jet-Vac"
                Case "6C00"
                    'LightCore Pop Fizz
                    frmMain.lstCharacters.SelectedItem = "LightCore Pop Fizz"
                Case "0700"
                    'LightCore Prism Break
                    frmMain.lstCharacters.SelectedItem = "LightCore Prism Break"
                Case "7100"
                    'LightCore Shroomboom
                    frmMain.lstCharacters.SelectedItem = "LightCore Shroomboom"
                Case "6D00"
                    'Ninjini
                    frmMain.lstCharacters.SelectedItem = "Ninjini"
                Case "6500"
                    'Swarm
                    frmMain.lstCharacters.SelectedItem = "Swarm"
                Case "6B00"
                    'Thumpback
                    frmMain.lstCharacters.SelectedItem = "Thumpback"
                Case "7000"
                    'Tree Rex
                    frmMain.lstCharacters.SelectedItem = "Tree Rex"
            End Select
        ElseIf Var = "0020" Then
            frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "E40C"
                    'Sheep Wreck Island
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    'Application.DoEvents()
                    frmMain.lstCharacters.SelectedItem = "Sheep Wreck Island"
                Case "E50C"
                    'Tower of Time
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    'Application.DoEvents()
                    frmMain.lstCharacters.SelectedItem = "Tower of Time"
                Case "830C"
                    'Groove Machine
                    frmMain.cmbGame.SelectedItem = "Items"
                    'Application.DoEvents()
                    frmMain.lstCharacters.SelectedItem = "Groove Machine"
                Case "820C"
                    'Platinum Sheep
                    frmMain.cmbGame.SelectedItem = "Items"
                    'Application.DoEvents()
                    frmMain.lstCharacters.SelectedItem = "Platinum Sheep"
                Case "810C"
                    'Sky Diamond
                    frmMain.cmbGame.SelectedItem = "Items"
                    'Application.DoEvents()
                    frmMain.lstCharacters.SelectedItem = "Sky Diamond"
                Case "840C"
                    'UFO Hat
                    frmMain.cmbGame.SelectedItem = "Items"
                    'Application.DoEvents()
                    frmMain.lstCharacters.SelectedItem = "UFO Hat"
                Case "EC03"
                    'Blast Zone (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Blast Zone (Bottom)"
                Case "D407"
                    'Blast Zone (Top)
                    frmMain.lstCharacters.SelectedItem = "Blast Zone (Top)"
                Case "E803"
                    'Boom Jet (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Boom Jet (Bottom)"
                Case "D007"
                    'Boom Jet (Top)
                    frmMain.lstCharacters.SelectedItem = "Boom Jet (Top)"
                Case "BE0B"
                    'Bumble Blast
                    frmMain.lstCharacters.SelectedItem = "Bumble Blast"
                Case "C20B"
                    'Countdown
                    frmMain.lstCharacters.SelectedItem = "Countdown"
                Case "EB03"
                    'Doom Stone (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Doom Stone (Bottom)"
                Case "D307"
                    'Doom Stone (Top)
                    frmMain.lstCharacters.SelectedItem = "Doom Stone (Top)"
                Case "C00B"
                    'Dune Bug
                    frmMain.lstCharacters.SelectedItem = "Dune Bug"
                Case "ED03"
                    'Fire Kraken (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Fire Kraken (Bottom)"
                Case "D507"
                    'Fire Kraken (Top)
                    frmMain.lstCharacters.SelectedItem = "Fire Kraken (Top)"
                Case "E903"
                    'Free Ranger (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Free Ranger (Bottom)"
                Case "D107"
                    'Free Ranger (Top)
                    frmMain.lstCharacters.SelectedItem = "Free Ranger (Top)"
                Case "F603"
                    'Freeze Blade (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Freeze Blade (Bottom)"
                Case "DE07"
                    'Freeze Blade (Top)
                    frmMain.lstCharacters.SelectedItem = "Freeze Blade (Top)"
                Case "BC0B"
                    'Fryno
                    frmMain.lstCharacters.SelectedItem = "Fryno"
                Case "EF03"
                    'Grilla Drilla (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Grilla Drilla (Bottom)"
                Case "D707"
                    'Grilla Drilla (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Grilla Drilla (Top)"
                Case "C50B"
                    'Grim Creeper
                    frmMain.lstCharacters.SelectedItem = "Grim Creeper"
                Case "F003"
                    'Hoot Loop (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Hoot Loop (Bottom)"
                Case "D807"
                    'Hoot Loop (Top)
                    frmMain.lstCharacters.SelectedItem = "Hoot Loop (Top)"
                Case "F203"
                    'Magna Charge (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Magna Charge (Bottom)"
                Case "DA07"
                    'Magna Charge (Top)
                    frmMain.lstCharacters.SelectedItem = "Magna Charge (Top)"
                Case "F403"
                    'Night Shift (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Night Shift (Bottom)"
                Case "DC07"
                    'Night Shift (Top)
                    frmMain.lstCharacters.SelectedItem = "Night Shift (Top)"
                Case "B90B"
                    'Pop Thorn
                    frmMain.lstCharacters.SelectedItem = "Pop Thorn"
                Case "C70B"
                    'Punk Shock
                    frmMain.lstCharacters.SelectedItem = "Punk Shock"
                Case "F503"
                    'Rattle Shake (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Rattle Shake (Bottom)"
                Case "DD07"
                    'Rattle Shake (Top)
                    frmMain.lstCharacters.SelectedItem = "Rattle Shake (Top)"
                Case "6C0B"
                    'Rip Tide
                    frmMain.lstCharacters.SelectedItem = "Rip Tide"
                Case "C40B"
                    'Roller Brawl
                    frmMain.lstCharacters.SelectedItem = "Roller Brawl"
                Case "EA03"
                    'Rubble Rouser (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Rubble Rouser (Bottom)"
                Case "D207"
                    'Rubble Rouser (Top)
                    frmMain.lstCharacters.SelectedItem = "Rubble Rouser (Top)"
                Case "BB0B"
                    'Scorp
                    frmMain.lstCharacters.SelectedItem = "Scorp"
                Case "B80B"
                    'Scratch
                    frmMain.lstCharacters.SelectedItem = "Scratch"
                Case "BA0B"
                    'Slobber Tooth
                    frmMain.lstCharacters.SelectedItem = "Slobber Tooth"
                Case "BD0B"
                    'Smolderdash
                    frmMain.lstCharacters.SelectedItem = "Smolderdash"
                Case "F303"
                    'Spy Rise (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Spy Rise (Bottom)"
                Case "DB07"
                    'Spy Rise (Top)
                    frmMain.lstCharacters.SelectedItem = "Spy Rise (Top)"
                Case "C10B"
                    'Star Strike
                    frmMain.lstCharacters.SelectedItem = "Star Strike"
                Case "EE03"
                    'Stink Bomb (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Stink Bomb (Bottom)"
                Case "D607"
                    'Stink Bomb (Top)
                    frmMain.lstCharacters.SelectedItem = "Stink Bomb (Top)"
                Case "F103"
                    'Trap Shadow (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Trap Shadow (Bottom)"
                Case "D907"
                    'Trap Shadow (Top)
                    frmMain.lstCharacters.SelectedItem = "Trap Shadow (Top)"
                Case "F703"
                    'Wash Buckler (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Wash Buckler (Bottom)"
                Case "DF07"
                    'Wash Buckler (Top)
                    frmMain.lstCharacters.SelectedItem = "Wash Buckler (Top)"
                Case "C30B"
                    'Wind-Up
                    frmMain.lstCharacters.SelectedItem = "Wind-Up"
                Case "BF0B"
                    'Zoo Lou
                    frmMain.lstCharacters.SelectedItem = "Zoo Lou"
                Case "2D01"
                    'Empire of Ice
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Empire of Ice"
                Case "2E01"
                    'Pirate Seas
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Pirate Seas"
                Case "C800"
                    'Anvil Rain
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Anvil Rain"
                Case "3001"
                    'Volcanic Vault
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Volcanic Vault"
                Case "800C"
                    'Battle Hammer
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Battle Hammer"
                Case "C900"
                    'Hidden Treasure
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Hidden Treasure"
                Case "CB00"
                    'Ghost Swords
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Ghost Pirate Swords"
                Case "CD00"
                    'Sky Iron Shield
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Sky-Iron Shield"
            End Select
        ElseIf Var = "022C" Then
            frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "1A00"
                    'Dark Stealth Elf
                    frmMain.lstCharacters.SelectedItem = "Dark Stealth Elf"
                Case "1300"
                    'Springtime Trigger Happy
                    frmMain.lstCharacters.SelectedItem = "Springtime Trigger Happy"
                Case "0900"
                    'Volcanic Eruptor
                    frmMain.lstCharacters.SelectedItem = "Volcanic Eruptor"
            End Select
        ElseIf Var = "0224" Then
            frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "EC03"
                    'Dark Blast Zone (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Dark Blast Zone (Bottom)"
                Case "D407"
                    'Dark Blast Zone (Top)
                    frmMain.lstCharacters.SelectedItem = "Dark Blast Zone (Top)"
                Case "BA0B"
                    'Dark Slobber Tooth
                    frmMain.lstCharacters.SelectedItem = "Dark Slobber Tooth"
                Case "F703"
                    'Dark Wash Buckler (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Dark Wash Buckler (Bottom)"
                Case "DF07"
                    'Dark Wash Buckler (Top)
                    frmMain.lstCharacters.SelectedItem = "Dark Wash Buckler (Top)"
                Case "F003"
                    'Enchanted Hoot Loop (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Enchanted Hoot Loop (Bottom)"
                Case "D807"
                    'Enchanted Hoot Loop (Top)
                    frmMain.lstCharacters.SelectedItem = "Enchanted Hoot Loop (Top)"
                Case "ED03"
                    'Jade Fire Kraken (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Jade Fire Kraken (Bottom)"
                Case "D507"
                    'Jade Fire Kraken (Top)
                    frmMain.lstCharacters.SelectedItem = "Jade Fire Kraken (Top)"
                Case "BE0B"
                    'Jolly Bumble Blast
                    frmMain.lstCharacters.SelectedItem = "Jolly Bumble Blast"
                Case "C20B"
                    'Kickoff Countdown
                    frmMain.lstCharacters.SelectedItem = "Kickoff Countdown"
                Case "F603"
                    'Nitro Freeze Blade (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Nitro Freeze Blade (Bottom)"
                Case "DE07"
                    'Nitro Freeze Blade (Top)
                    frmMain.lstCharacters.SelectedItem = "Nitro Freeze Blade (Top)"
                Case "F203"
                    'Nitro Magna Charge (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Nitro Magna Charge (Bottom)"
                Case "DA07"
                    'Nitro Magna Charge (Top)
                    frmMain.lstCharacters.SelectedItem = "Nitro Magna Charge (Top)"
                Case "F503"
                    'Quickdraw Rattle Shake (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Quickdraw Rattle Shake (Bottom)"
                Case "DD07"
                    'Quickdraw Rattle Shake (Top)
                    frmMain.lstCharacters.SelectedItem = "Quickdraw Rattle Shake (Top)"
            End Select
        ElseIf Var = "0226" Then
            frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "C10B"
                    'Enchanted Star Strike
                    frmMain.lstCharacters.SelectedItem = "Enchanted Star Strike"
            End Select
        ElseIf Var = "0324" Then
            frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "E903"
                    'Legendary Free Ranger (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Legendary Free Ranger (Bottom)"
                Case "D107"
                    'Legendary Free Ranger (Top)
                    frmMain.lstCharacters.SelectedItem = "Legendary Free Ranger (Top)"
                Case "F403"
                    'Legendary Night Shift (Bottom)
                    frmMain.lstCharacters.SelectedItem = "Legendary Night Shift (Bottom)"
                Case "DC07"
                    'Legendary Night Shift (Top)
                    frmMain.lstCharacters.SelectedItem = "Legendary Night Shift (Top)"
                Case "BF0B"
                    'Legendary Zoo Lou
                    frmMain.lstCharacters.SelectedItem = "Legendary Zoo Lou"
            End Select
        ElseIf Var = "0326" Then
            frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "C50B"
                    'Legendary Grim Creeper
                    frmMain.lstCharacters.SelectedItem = "Legendary Grim Creeper"
            End Select
        ElseIf Var = "0528" Then
            frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "0E00"
                    'Anchors Away Gill Grunt
                    frmMain.lstCharacters.SelectedItem = "Anchors Away Gill Grunt"
                Case "1300"
                    'Big Bang Trigger Happy
                    frmMain.lstCharacters.SelectedItem = "Big Bang Trigger Happy"
                Case "6A00"
                    'Blizzard Chill
                    frmMain.lstCharacters.SelectedItem = "Blizzard Chill"
                Case "1000"
                    'Dark Mega Ram Spyro
                    frmMain.lstCharacters.SelectedItem = "Dark Mega Ram Spyro"
                Case "0069"
                    'Fire Bone Hot Dog
                    frmMain.lstCharacters.SelectedItem = "Fire Bone Hot Dog"
                Case "6F00"
                    'Heavy Duty Sprocket
                    frmMain.lstCharacters.SelectedItem = "Heavy Duty Sprocket"
                Case "0000"
                    'Horn Blast Whirlwind
                    frmMain.lstCharacters.SelectedItem = "Horn Blast Whirlwind"
                Case "0700"
                    'Hyper Beam Prism Break
                    frmMain.lstCharacters.SelectedItem = "Hyper Beam Prism Break"
                Case "0500"
                    'Knockout Terrafin
                    frmMain.lstCharacters.SelectedItem = "Knockout Terrafin"
                Case "0900"
                    'Lava Barf Eruptor
                    frmMain.lstCharacters.SelectedItem = "Lava Barf Eruptor"
                Case "1000"
                    'Mega Ram Spyro
                    frmMain.lstCharacters.SelectedItem = "Mega Ram Spyro"
                Case "1A00"
                    'Ninja Stealth Elf
                    frmMain.lstCharacters.SelectedItem = "Ninja Stealth Elf"
                Case "2000"
                    'Phantom Cynder
                    frmMain.lstCharacters.SelectedItem = "Phantom Cynder"
                Case "6C00"
                    'Super Gulp Pop Fizz
                    frmMain.lstCharacters.SelectedItem = "Super Gulp Pop Fizz"
                Case "1800"
                    'Thorn Horn Camo
                    frmMain.lstCharacters.SelectedItem = "Thorn Horn Camo"
                Case "6400"
                    'Turbo Jet-Vac
                    frmMain.lstCharacters.SelectedItem = "Turbo Jet-Vac"
                Case "1E00"
                    'Twin Blade Chop Chop
                    frmMain.lstCharacters.SelectedItem = "Twin Blade Chop Chop"
            End Select
        ElseIf Var = "0622" Then
            frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "BE0B"
                    'LightCore Bumble Blast
                    frmMain.lstCharacters.SelectedItem = "LightCore Bumble Blast"
                Case "C20B"
                    'LightCore Countdown
                    frmMain.lstCharacters.SelectedItem = "LightCore Countdown"
                Case "6700"
                    'LightCore Flashwing
                    frmMain.lstCharacters.SelectedItem = "LightCore Flashwing"
                Case "C50B"
                    'LightCore Grim Creeper
                    frmMain.lstCharacters.SelectedItem = "LightCore Grim Creeper"
                Case "DB0B"
                    'LightCore Smolderdash
                    frmMain.lstCharacters.SelectedItem = "LightCore Smolderdash"
                Case "C10B"
                    'LightCore Star Strike
                    frmMain.lstCharacters.SelectedItem = "LightCore Star Strike"
                Case "0200"
                    'LightCore Warnado
                    frmMain.lstCharacters.SelectedItem = "LightCore Warnado"
                Case "0D00"
                    'LightCore Wham-Shell
                    frmMain.lstCharacters.SelectedItem = "LightCore Wham-Shell"
                Case "E70C"
                    'Arkeyan Crossbow
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Arkeyan Crossbow"
                Case "E60C"
                    'Fiery Forge
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Fiery Forge"
            End Select
        ElseIf Var = "0030" Then
            frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "1C02"
                    'Barkley
                    frmMain.lstCharacters.SelectedItem = "Barkley"
                Case "E001"
                    'Bat Spin
                    frmMain.lstCharacters.SelectedItem = "Bat Spin"
                Case "E501"
                    'Blackout
                    frmMain.lstCharacters.SelectedItem = "Blackout"
                Case "C501"
                    'Blades
                    frmMain.lstCharacters.SelectedItem = "Blades"
                Case "D201"
                    'Blastermind
                    frmMain.lstCharacters.SelectedItem = "Blastermind"
                Case "F601"
                    'Bop
                    frmMain.lstCharacters.SelectedItem = "Bop"
                Case "FA01"
                    'Breeze
                    frmMain.lstCharacters.SelectedItem = "Breeze"
                Case "DA01"
                    'Bushwhack
                    frmMain.lstCharacters.SelectedItem = "Bushwhack"
                Case "D801"
                    'Chopper
                    frmMain.lstCharacters.SelectedItem = "Chopper"
                Case "D501"
                    'Cobra Cadabra
                    frmMain.lstCharacters.SelectedItem = "Cobra Cadabra"
                Case "FE01"
                    'Drobit
                    frmMain.lstCharacters.SelectedItem = "Drobit"
                Case "D401"
                    'Déjà Vu
                    frmMain.lstCharacters.SelectedItem = "Déjà Vu"
                Case "D101"
                    'Echo
                    frmMain.lstCharacters.SelectedItem = "Echo"
                Case "D301"
                    'Enigma
                    frmMain.lstCharacters.SelectedItem = "Enigma"
                Case "1F02"
                    'Eye-Small
                    frmMain.lstCharacters.SelectedItem = "Eye-Small"
                Case "C801"
                    'Fist Bump
                    frmMain.lstCharacters.SelectedItem = "Fist Bump"
                Case "C401"
                    'Fling Kong
                    frmMain.lstCharacters.SelectedItem = "Fling Kong"
                Case "D001"
                    'Flip Wreck
                    frmMain.lstCharacters.SelectedItem = "Flip Wreck"
                Case "DC01"
                    'Food Fight
                    frmMain.lstCharacters.SelectedItem = "Food Fight"
                Case "E101"
                    'Funny Bone
                    frmMain.lstCharacters.SelectedItem = "Funny Bone"
                Case "D701"
                    'Gearshift
                    frmMain.lstCharacters.SelectedItem = "Gearshift"
                Case "0202"
                    'Gill Runt
                    frmMain.lstCharacters.SelectedItem = "Gill Runt"
                Case "C201"
                    'Gusto
                    frmMain.lstCharacters.SelectedItem = "Gusto"
                Case "C701"
                    'Head Rush
                    frmMain.lstCharacters.SelectedItem = "Head Rush"
                Case "DD01"
                    'High Five
                    frmMain.lstCharacters.SelectedItem = "High Five"
                Case "F801"
                    'Hijinx
                    frmMain.lstCharacters.SelectedItem = "Hijinx"
                Case "D601"
                    'Jawbreaker
                    frmMain.lstCharacters.SelectedItem = "Jawbreaker"
                Case "CB01"
                    'Ka-Boom
                    frmMain.lstCharacters.SelectedItem = "Ka-Boom"
                Case "E201"
                    'Knight Light
                    frmMain.lstCharacters.SelectedItem = "Knight Light"
                Case "E401"
                    'Knight Mare
                    frmMain.lstCharacters.SelectedItem = "Knight Mare"
                Case "DE01"
                    'Krypt King
                    frmMain.lstCharacters.SelectedItem = "Krypt King"
                Case "CF01"
                    'Lob-Star
                    frmMain.lstCharacters.SelectedItem = "Lob-Star"
                Case "1E02"
                    'Mini-Jini
                    frmMain.lstCharacters.SelectedItem = "Mini-Jini"
                Case "FC01"
                    'Pet-Vac
                    frmMain.lstCharacters.SelectedItem = "Pet-Vac"
                Case "C901"
                    'Rocky Roll
                    frmMain.lstCharacters.SelectedItem = "Rocky Roll"
                Case "DF01"
                    'Short Cut
                    frmMain.lstCharacters.SelectedItem = "Short Cut"
                Case "FD01"
                    'Small Fry
                    frmMain.lstCharacters.SelectedItem = "Small Fry"
                Case "CE01"
                    'Snap Shot
                    frmMain.lstCharacters.SelectedItem = "Snap Shot"
                Case "E301"
                    'Spotlight
                    frmMain.lstCharacters.SelectedItem = "Spotlight"
                Case "F701"
                    'Spry
                    frmMain.lstCharacters.SelectedItem = "Spry"
                Case "F901"
                    'Terrabite
                    frmMain.lstCharacters.SelectedItem = "Terrabite"
                Case "1D02"
                    'Thumpling
                    frmMain.lstCharacters.SelectedItem = "Thumpling"
                Case "C301"
                    'Thunderbolt
                    frmMain.lstCharacters.SelectedItem = "Thunderbolt"
                Case "CD01"
                    'Torch
                    frmMain.lstCharacters.SelectedItem = "Torch"
                Case "CC01"
                    'Trail Blazer
                    frmMain.lstCharacters.SelectedItem = "Trail Blazer"
                Case "D901"
                    'Tread Head
                    frmMain.lstCharacters.SelectedItem = "Tread Head"
                Case "0702"
                    'Trigger Snappy
                    frmMain.lstCharacters.SelectedItem = "Trigger Snappy"
                Case "DB01"
                    'Tuff Luck
                    frmMain.lstCharacters.SelectedItem = "Tuff Luck"
                Case "C601"
                    'Wallop
                    frmMain.lstCharacters.SelectedItem = "Wallop"
                Case "FB01"
                    'Weeruptor
                    frmMain.lstCharacters.SelectedItem = "Weeruptor"
                Case "0E02"
                    'Whisper Elf
                    frmMain.lstCharacters.SelectedItem = "Whisper Elf"
                Case "CA01"
                    'Wildfire
                    frmMain.lstCharacters.SelectedItem = "Wildfire"
                Case "3401"
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Midnight Museum"
                Case "3101"
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Mirror of Mystery"
                Case "3201"
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Nightmare Express"
            End Select
        ElseIf Var = "1D30" Then
            Select Case Fig
                Case "C301"
                    'Clear Thunderbolt
                    frmMain.lstCharacters.SelectedItem = "Clear Thunderbolt"
            End Select
        ElseIf Var = "0138" Then
            frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "BC0B"
                    'Hog Wild Fryno
                    frmMain.lstCharacters.SelectedItem = "Hog Wild Fryno"
                Case "7100"
                    'Sure Shot Shroomboom
                    frmMain.lstCharacters.SelectedItem = "Sure Shot Shroomboom"
            End Select
        ElseIf Var = "023C" Then
            frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "6C00"
                    'Love Potion Pop Fizz
                    frmMain.lstCharacters.SelectedItem = "Love Potion Pop Fizz"
            End Select
        ElseIf Var = "0234" Then
            frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "DC01"
                    'Dark Food Fight
                    frmMain.lstCharacters.SelectedItem = "Dark Food Fight"
                Case "CE01"
                    'Dark Snap Shot
                    frmMain.lstCharacters.SelectedItem = "Dark Snap Shot"
                Case "CA01"
                    'Dark Wildfire
                    frmMain.lstCharacters.SelectedItem = "Dark Wildfire"
                Case "FB01"
                    'Eggsellent Weeruptor
                    frmMain.lstCharacters.SelectedItem = "Eggsellent Weeruptor"
                Case "1C02"
                    'Gnarly Barkley
                    frmMain.lstCharacters.SelectedItem = "Gnarly Barkley"
                Case "D501"
                    'King Cobra Cadabra
                    frmMain.lstCharacters.SelectedItem = "King Cobra Cadabra"
                Case "C701"
                    'Nitro Head Rush
                    frmMain.lstCharacters.SelectedItem = "Nitro Head Rush"
                Case "DE01"
                    'Nitro Krypt King
                    frmMain.lstCharacters.SelectedItem = "Nitro Krypt King"
                Case "FC01"
                    'Power Punch Pet-Vac
                    frmMain.lstCharacters.SelectedItem = "Power Punch Pet-Vac"
                Case "CF01"
                    'Winterfest Lob-Star
                    frmMain.lstCharacters.SelectedItem = "Winterfest Lob-Star"
            End Select
        ElseIf Var = "0334" Then
            frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "C501"
                    'Legendary Blades
                    frmMain.lstCharacters.SelectedItem = "Legendary Blades"
                Case "DA01"
                    'Legendary Bushwhack
                    frmMain.lstCharacters.SelectedItem = "Legendary Bushwhack"
                Case "D401"
                    'Legendary Déjà Vu
                    frmMain.lstCharacters.SelectedItem = "Legendary Déjà Vu"
                Case "D601"
                    'Legendary Jawbreaker
                    frmMain.lstCharacters.SelectedItem = "Legendary Jawbreaker"
                Case "E600"
                    ' MessageBox.Show("L. Hand")
                    'Legendary Hand of Fate
                    frmMain.cmbGame.SelectedItem = "Items"
                    frmMain.lstCharacters.SelectedItem = "Legendary Hand of Fate"
            End Select
        ElseIf Var = "0538" Then
            frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "6C00"
                    'Fizzy Frenzy Pop Fizz
                    frmMain.lstCharacters.SelectedItem = "Fizzy Frenzy Pop Fizz"
                Case "6400"
                    'Full Blast Jet-Vac
                    frmMain.lstCharacters.SelectedItem = "Full Blast Jet-Vac"
            End Select
        ElseIf Var = "0632" Then
            frmMain.cmbGame.SelectedItem = "Adventure Packs"
            Select Case Fig
                Case "3401"
                    'Midnight Museum (Proper?)
                    frmMain.lstCharacters.SelectedItem = "Midnight Museum"
                Case "3301"
                    'Sunscraper Spire
                    frmMain.lstCharacters.SelectedItem = "Sunscraper Spire"
            End Select
        ElseIf Var = "0938" Then
            frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "0E00"
                    'Tidal Wave Gill Grunt
                    frmMain.lstCharacters.SelectedItem = "Tidal Wave Gill Grunt"
            End Select
        ElseIf Var = "1038" Then
            frmMain.cmbGame.SelectedItem = "Trap Team"
            Select Case Fig
                Case "1E00"
                    'Elite Chop Chop
                    frmMain.lstCharacters.SelectedItem = "Elite Chop Chop"
                Case "0900"
                    'Elite Eruptor
                    frmMain.lstCharacters.SelectedItem = "Elite Eruptor"
                Case "0E00"
                    'Elite Gill Grunt
                    frmMain.lstCharacters.SelectedItem = "Elite Gill Grunt"
                Case "1000"
                    'Elite Spyro
                    frmMain.lstCharacters.SelectedItem = "Elite Spyro"
                Case "1A00"
                    'Elite Stealth Elf
                    frmMain.lstCharacters.SelectedItem = "Elite Stealth Elf"
                Case "0500"
                    'Elite Terrafin
                    frmMain.lstCharacters.SelectedItem = "Elite Terrafin"
                Case "1300"
                    'Elite Trigger Happy
                    frmMain.lstCharacters.SelectedItem = "Elite Trigger Happy"
                Case "0000"
                    'Elite Whirlwind
                    frmMain.lstCharacters.SelectedItem = "Elite Whirlwind"
            End Select
        ElseIf Var = "0041" Then
            frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "620D"
                    frmMain.lstCharacters.SelectedItem = "Astroblast"
                Case "5C0D"
                    frmMain.lstCharacters.SelectedItem = "Big Bubble Pop Fizz"
                Case "590D"
                    frmMain.lstCharacters.SelectedItem = "Bone Bash Roller Brawl"
                Case "5E0D"
                    frmMain.lstCharacters.SelectedItem = "Deep Dive Gill Grunt"
                Case "610D"
                    frmMain.lstCharacters.SelectedItem = "Dive-Clops"
                Case "560D"
                    frmMain.lstCharacters.SelectedItem = "Double Dare Trigger Happy"
                Case "480D"
                    frmMain.lstCharacters.SelectedItem = "Fiesta"
                Case "600D"
                    frmMain.lstCharacters.SelectedItem = "Hammer Slam Bowser"
                Case "490D"
                    frmMain.lstCharacters.SelectedItem = "High Volt"
                Case "550D"
                    frmMain.lstCharacters.SelectedItem = "Hurricane Jet-Vac"
                Case "5D0D"
                    frmMain.lstCharacters.SelectedItem = "Lava Lance Eruptor"
                Case "630D"
                    frmMain.lstCharacters.SelectedItem = "Nightfall"
                Case "580D"
                    frmMain.lstCharacters.SelectedItem = "Shark Shooter Terrafin"
                Case "530D"
                    frmMain.lstCharacters.SelectedItem = "Smash Hit"
                Case "540D"
                    frmMain.lstCharacters.SelectedItem = "Spitfire"
                Case "4A0D"
                    frmMain.lstCharacters.SelectedItem = "Splat"
                Case "4E0D"
                    frmMain.lstCharacters.SelectedItem = "Stormblade"
                Case "570D"
                    frmMain.lstCharacters.SelectedItem = "Super Shot Stealth Elf"
                Case "640D"
                    frmMain.lstCharacters.SelectedItem = "Thrillipede"
                Case "5F0D"
                    frmMain.lstCharacters.SelectedItem = "Turbo Charge Donkey Kong"
            End Select
        ElseIf Var = "0040" Then
            frmMain.cmbGame.SelectedItem = "Vehicles"
            BlnVehicle = True
            Select Case Fig
                Case "A80C"
                    frmMain.lstCharacters.SelectedItem = "Barrel Blaster"
                Case "970C"
                    frmMain.lstCharacters.SelectedItem = "Burn-Cycle"
                Case "A909"
                    frmMain.lstCharacters.SelectedItem = "Buzz Wing"
                Case "A90C"
                    'Buzz Wing
                    frmMain.lstCharacters.SelectedItem = "Buzz Wing"
                Case "A10C"
                    frmMain.lstCharacters.SelectedItem = "Clown Cruiser"
                Case "9B0C"
                    frmMain.lstCharacters.SelectedItem = "Crypt Crusher"
                Case "9F0C"
                    frmMain.lstCharacters.SelectedItem = "Dive Bomber"
                Case "A20C"
                    frmMain.lstCharacters.SelectedItem = "Gold Rusher"
                Case "940C"
                    frmMain.lstCharacters.SelectedItem = "Jet Stream"
                Case "AF0D"
                    frmMain.lstCharacters.SelectedItem = "Kaos Trophy"
                Case "AD0D"
                    frmMain.lstCharacters.SelectedItem = "Land Trophy"
                Case "960C"
                    frmMain.lstCharacters.SelectedItem = "Reef Ripper"
                Case "A50C"
                    frmMain.lstCharacters.SelectedItem = "Sea Shadow"
                Case "AE0D"
                    frmMain.lstCharacters.SelectedItem = "Sea Trophy"
                Case "990C"
                    frmMain.lstCharacters.SelectedItem = "Shark Tank"
                Case "A30C"
                    frmMain.lstCharacters.SelectedItem = "Shield Striker"
                Case "A00C"
                    frmMain.lstCharacters.SelectedItem = "Sky Slicer"
                Case "AC0D"
                    frmMain.lstCharacters.SelectedItem = "Sky Trophy"
                Case "A70C"
                    frmMain.lstCharacters.SelectedItem = "Soda Skimmer"
                Case "A60C"
                    frmMain.lstCharacters.SelectedItem = "Splatter Splasher"
                Case "9C0C"
                    frmMain.lstCharacters.SelectedItem = "Stealth Stinger"
                Case "A40C"
                    frmMain.lstCharacters.SelectedItem = "Sun Runner"
                Case "9A0C"
                    frmMain.lstCharacters.SelectedItem = "Thump Truck"
                Case "950C"
                    frmMain.lstCharacters.SelectedItem = "Tomb Buggy"
            End Select
        ElseIf Var = "0E45" Then
            frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "5C0D"
                    frmMain.lstCharacters.SelectedItem = "Birthday Bash Big Bubble Pop Fizz"
                Case "610D"
                    frmMain.lstCharacters.SelectedItem = "Missile-Tow Dive-Clops"
            End Select
        ElseIf Var = "0244" Then
            frmMain.cmbGame.SelectedItem = "SuperChargers"
            BlnVehicle = True
            Select Case Fig
                Case "A80C"
                    frmMain.lstCharacters.SelectedItem = "Dark Barrel Blaster"
                Case "A10C"
                    frmMain.lstCharacters.SelectedItem = "Dark Clown Cruiser"
                Case "980C"
                    frmMain.lstCharacters.SelectedItem = "Dark Hot Streak"
                Case "A50C"
                    frmMain.lstCharacters.SelectedItem = "Dark Sea Shadow"
                Case "A70C"
                    frmMain.lstCharacters.SelectedItem = "Nitro Soda Skimmer"
                Case "9C0C"
                    frmMain.lstCharacters.SelectedItem = "Nitro Stealth Stinger"
                Case "A20C"
                    frmMain.lstCharacters.SelectedItem = "Power Blue Gold Rusher"
                Case "A60C"
                    frmMain.lstCharacters.SelectedItem = "Power Blue Splatter Splasher"
                Case "9F0C"
                    frmMain.lstCharacters.SelectedItem = "Spring Ahead Dive Bomber"
            End Select
        ElseIf Var = "0245" Then
            frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "600D"
                    frmMain.lstCharacters.SelectedItem = "Dark Hammer Slam Bowser"
                Case "540D"
                    frmMain.lstCharacters.SelectedItem = "Dark Spitfire"
                Case "570D"
                    frmMain.lstCharacters.SelectedItem = "Dark Super Shot Stealth Elf"
                Case "5F0D"
                    frmMain.lstCharacters.SelectedItem = "Dark Turbo Charge Donkey Kong"
                Case "4A0D"
                    frmMain.lstCharacters.SelectedItem = "Power Blue Splat"
                Case "560D"
                    frmMain.lstCharacters.SelectedItem = "Power Blue Trigger Happy"
                Case "530D"
                    frmMain.lstCharacters.SelectedItem = "Steel Plated Smash Hit"
            End Select
        ElseIf Var = "0440" Then
            frmMain.cmbGame.SelectedItem = "SuperChargers"
            BlnVehicle = True
            Select Case Fig
                Case "970C"
                    frmMain.lstCharacters.SelectedItem = "E3 Hot Streak"
                Case "980C"
                    frmMain.lstCharacters.SelectedItem = "Hot Streak"
            End Select
        ElseIf Var = "0D45" Then
            frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "640D"
                    frmMain.lstCharacters.SelectedItem = "Eggcited Thrillipede"
            End Select
        ElseIf Var = "1048" Then
            frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "1600"
                    frmMain.lstCharacters.SelectedItem = "Elite Boomer"
                Case "0600"
                    frmMain.lstCharacters.SelectedItem = "Elite Dino-Rang"
                Case "1F00"
                    frmMain.lstCharacters.SelectedItem = "Elite Ghost Roaster"
                Case "0F00"
                    frmMain.lstCharacters.SelectedItem = "Elite Slam Bam"
                Case "1900"
                    frmMain.lstCharacters.SelectedItem = "Elite Zook"
            End Select
        ElseIf Var = "1138" Then
            frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "1100"
                    frmMain.lstCharacters.SelectedItem = "Elite Voodood"
            End Select
        ElseIf Var = "1545" Then
            frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "480D"
                    frmMain.lstCharacters.SelectedItem = "Frightful Fiesta"
            End Select
        ElseIf Var = "1E44" Then
            frmMain.cmbGame.SelectedItem = "Vehicle"
            BlnVehicle = True
            Select Case Fig
                Case "980C"
                    frmMain.lstCharacters.SelectedItem = "Golden Hot Streak"
            End Select
        ElseIf Var = "0345" Then
            frmMain.cmbGame.SelectedItem = "SuperChargers"
            Select Case Fig
                Case "620D"
                    frmMain.lstCharacters.SelectedItem = "Legendary Astroblast"
                Case "590D"
                    frmMain.lstCharacters.SelectedItem = "Legendary Bone Bash Roller Brawl"
                Case "550D"
                    frmMain.lstCharacters.SelectedItem = "Legendary Hurricane Jet-Vac"
            End Select
        ElseIf Var = "0344" Then
            frmMain.cmbGame.SelectedItem = "Vehicle"
            BlnVehicle = True
            Select Case Fig
                Case "A40C"
                    frmMain.lstCharacters.SelectedItem = "Legendary Sun Runner"
            End Select
            'Imaginators
        ElseIf Var = "0050" Then
            frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "5F02"
                    frmMain.lstCharacters.SelectedItem = "Air Strike"
                Case "6102"
                    frmMain.lstCharacters.SelectedItem = "Ambush"
                Case "6B02"
                    frmMain.lstCharacters.SelectedItem = "Aurora"
                Case "6E02"
                    frmMain.lstCharacters.SelectedItem = "Bad Juju"
                Case "5E02"
                    frmMain.lstCharacters.SelectedItem = "Barbella"
                Case "7002"
                    frmMain.lstCharacters.SelectedItem = "Blaster-Tron"
                Case "5C02"
                    frmMain.lstCharacters.SelectedItem = "Boom Bloom"
                Case "6A02"
                    frmMain.lstCharacters.SelectedItem = "Buckshot"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Candy-Coated Chopscotch"
                Case "7202"
                    frmMain.lstCharacters.SelectedItem = "Chain Reaction"
                Case "6D02"
                    frmMain.lstCharacters.SelectedItem = "Chompy Mage"
                Case "5B02"
                    frmMain.lstCharacters.SelectedItem = "Chopscotch"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Clear Starcast"
                Case "7602"
                    frmMain.lstCharacters.SelectedItem = "Crash Bandicoot"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Dark Golden Queen"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Dark King Pen"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Dark Wolfgang"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Dec-Ember"
                Case "6202"
                    frmMain.lstCharacters.SelectedItem = "Dr. Krankcase"
                Case "7702"
                    frmMain.lstCharacters.SelectedItem = "Dr. Neo Cortex"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Egg Bomber Air Strike"
                Case "6002"
                    frmMain.lstCharacters.SelectedItem = "Ember"
                Case "6C02"
                    frmMain.lstCharacters.SelectedItem = "Flarewolf"
                Case "6502"
                    frmMain.lstCharacters.SelectedItem = "Golden Queen"
                Case "6F02"
                    frmMain.lstCharacters.SelectedItem = "Grave Clobber"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Hard-Boiled Flarewolf"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Heartbreaker Buckshot"
                Case "6302"
                    frmMain.lstCharacters.SelectedItem = "Hood Sickle"
                Case "6D02"
                    frmMain.lstCharacters.SelectedItem = "Jingle Bell Chompy Mage"
                Case "7302"
                    frmMain.lstCharacters.SelectedItem = "Kaos"
                Case "5902"
                    frmMain.lstCharacters.SelectedItem = "King Pen"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Mystical Bad Juju"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Mystical Tae Kwon Crow"
                Case "6802"
                    frmMain.lstCharacters.SelectedItem = "Mysticat"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Orange Chain Reaction"
                Case "6702"
                    frmMain.lstCharacters.SelectedItem = "Pain-Yatta"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Pink Barbella"
                Case "5D02"
                    frmMain.lstCharacters.SelectedItem = "Pit Boss"
                Case "7102"
                    frmMain.lstCharacters.SelectedItem = "Ro-Bow"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Rock Candy Pain-Yatta"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Solar Flare Aurora"
                Case "6902"
                    frmMain.lstCharacters.SelectedItem = "Starcast"
                    'Case ""
                    'frmMain.lstCharacters.SelectedItem = "Steel Plated Hood Sickle"
                Case "6402"
                    frmMain.lstCharacters.SelectedItem = "Tae Kwon Crow"
                Case "7502"
                    frmMain.lstCharacters.SelectedItem = "Tidepool"
                Case "5A02"
                    frmMain.lstCharacters.SelectedItem = "Tri-Tip"
                Case "7402"
                    frmMain.lstCharacters.SelectedItem = "Wild Storm"
                Case "6602"
                    frmMain.lstCharacters.SelectedItem = "Wolfgang"

                Case "3601"
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Gryphon Park Observatory"
                Case "3701"
                    frmMain.cmbGame.SelectedItem = "Adventure Packs"
                    frmMain.lstCharacters.SelectedItem = "Enchanted Elven Forest"
            End Select
        ElseIf Var = "0330" Then
            'Toucan Trap Vars
            frmMain.cmbGame.SelectedItem = "Traps"
            blnTrap = True
            Select Case Fig
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Breezy Bird (Toucan)"
                Case "D800"
                    frmMain.lstCharacters.SelectedItem = "Rock Hawk (Toucan)"
                Case "D900"
                    frmMain.lstCharacters.SelectedItem = "Oak Eagle (Toucan)"
            End Select
        ElseIf Var = "1030" Then
            'Snake Trap Vars
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Cloudy Cobra (Snake)"
                Case "D900"
                    frmMain.lstCharacters.SelectedItem = "Seed Serpent (Snake)"
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Spooky Snake (Snake)"
            End Select
        ElseIf Var = "1830" Then
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                'Sword Trap Vars
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Cyclone Sabre (Sword)"
                Case "DA00"
                    frmMain.lstCharacters.SelectedItem = "Dark Dagger (Sword)"
                Case "D900"
                    frmMain.lstCharacters.SelectedItem = "Jade Blade (Sword)"
            End Select
        ElseIf Var = "0630" Then
            frmMain.cmbGame.SelectedItem = "Traps"
            'Jughead Trap Vars
            blnTrap = True
            Select Case Fig
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Drafty Decanter (Jughead)"
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Flood Flask (Jughead)"
            End Select
        ElseIf Var = "1130" Then
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"
            'Screamer Trap Vars
            Select Case Fig
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Storm Warning (Screamer)"
                Case "D700"
                    frmMain.lstCharacters.SelectedItem = "Scorching Stopper (Screamer)"
            End Select
        ElseIf Var = "0E30" Then
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                'Hourglas Trap Vars
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Tempest Timer (Hourglass)"
                Case "D800"
                    frmMain.lstCharacters.SelectedItem = "Dust of Time (Hourglass)"
                Case "D200"
                    frmMain.lstCharacters.SelectedItem = "Arcane Hourglass (Hourglass)"
            End Select
        ElseIf Var = "1A30" Then
            'Handstand Trap Vars
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "DA00"
                    frmMain.lstCharacters.SelectedItem = "Ghastly Grimace (Handstand)"
                Case "D800"
                    frmMain.lstCharacters.SelectedItem = "Rubble Trouble (Handstand)"
                Case "D600"
                    frmMain.lstCharacters.SelectedItem = "Topsy Techy (Handstand)"
            End Select
        ElseIf Var = "1430" Then
            'Spider Trap Vars
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "DA00"
                    frmMain.lstCharacters.SelectedItem = "Shadow Spider (Spider)"
            End Select
        ElseIf Var = "0430" Then
            'Orb Trap Vars
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D800"
                    frmMain.lstCharacters.SelectedItem = "Banded Boulder (Orb)"
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Spirit Sphere (Orb)"
            End Select
        ElseIf Var = "0434" Then
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "0434"
                    frmMain.lstCharacters.SelectedItem = "Legendary Spirit Sphere (Orb)"
            End Select
        ElseIf Var = "0A30" Then
            blnTrap = True
            'Hammer Trap Figures
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D800"
                    frmMain.lstCharacters.SelectedItem = "Slag Hammer (Hammer)"
                Case "D900"
                    frmMain.lstCharacters.SelectedItem = "Weed Whacker (Hammer)"
            End Select
        ElseIf Var = "1230" Then
            blnTrap = True
            'Totem Trap Figures
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D800"
                    frmMain.lstCharacters.SelectedItem = "Spinning Sandstorm (Totem)"
                Case "D700"
                    frmMain.lstCharacters.SelectedItem = "Searing Spinner (Totem)"
                Case "D100"
                    frmMain.lstCharacters.SelectedItem = "Spell Slapper (Totem)"
            End Select
        ElseIf Var = "1B30" Then
            'Yawn Trap Figures
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"
            'Application.DoEvents()

            Select Case Fig
                Case "D700"
                    frmMain.lstCharacters.SelectedItem = "Blazing Belch (Yawn)"
                Case "D900"
                    frmMain.lstCharacters.SelectedItem = "Shrub Shrieker (Yawn)"
                Case "DB00"
                    frmMain.lstCharacters.SelectedItem = "Beam Scream (Yawn)"
            End Select
        ElseIf Var = "0530" Then
            'Torch Trap Figures
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D700"
                    frmMain.lstCharacters.SelectedItem = "Eternal Flame (Torch)"
                Case "D900"
                    frmMain.lstCharacters.SelectedItem = "Emerald Energy (Torch)"
            End Select
        ElseIf Var = "0130" Then
            'Septer/Log Holder/Tiki Trap Figures
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D700"
                    frmMain.lstCharacters.SelectedItem = "Fire Flower (Scepter)"
                Case "D200"
                    frmMain.lstCharacters.SelectedItem = "Biter's Bane (Log Holder)"
                Case "D600"
                    frmMain.lstCharacters.SelectedItem = "Tech Totem (Tiki)"
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Tidal Tiki (Tiki)"
            End Select
        ElseIf Var = "1730" Then
            'Captain's Hat Trap Figures
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D700"
                    frmMain.lstCharacters.SelectedItem = "Spark Spear (Captain's Hat)"
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Dream Piercer (Captain's Hat)"
            End Select
        ElseIf Var = "0F30" Then
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "DB00"
                    frmMain.lstCharacters.SelectedItem = "Heavenly Hawk (Hawk)"
            End Select
        ElseIf Var = "1530" Then
            'Rocket Trap Figures
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "DB00"
                    frmMain.lstCharacters.SelectedItem = "Shining Ship (Rocket)"
                Case "D200"
                    frmMain.lstCharacters.SelectedItem = "Rune Rocket (Rocket)"
            End Select
        ElseIf Var = "0B30" Then
            'Axe Trap Figures
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D200"
                    frmMain.lstCharacters.SelectedItem = "Axe of Illusion (Axe)"
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Haunted Hatchet (Axe)"
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Aqua Axe (Axe)"
            End Select
        ElseIf Var = "0830" Then
            blnTrap = True
            'Skull Trap Figures
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D200"
                    frmMain.lstCharacters.SelectedItem = "Sorcerous Skull (Skull)"
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Spectral Skull (Skull)"
            End Select
        ElseIf Var = "0C30" Then
            'Hand Trap Figures
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D600"
                    frmMain.lstCharacters.SelectedItem = "Grabbing Gadget (Hand)"
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Grim Gripper (Hand)"
            End Select
        ElseIf Var = "1630" Then
            'Flying Helmet Trap Figures
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D600"
                    frmMain.lstCharacters.SelectedItem = "Makers Mana (Flying Helmet)"
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Frost Helm (Flying Helmet)"
            End Select
        ElseIf Var = "0730" Then
            blnTrap = True
            'Angel Trap Figures
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D600"
                    frmMain.lstCharacters.SelectedItem = "Automatic Angel (Angel)"
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Soaking Staff (Angel)"
            End Select
        ElseIf Var = "0230" Then
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Wet Walter (Log Holder)"
            End Select
        ElseIf Var = "0930" Then
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D600"
                    frmMain.lstCharacters.SelectedItem = "Factory Flower (Scepter)"
            End Select
        ElseIf Var = "0634" Then
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D300"
                    frmMain.lstCharacters.SelectedItem = "Legendary Flood Flask (Jughead)"
            End Select
        ElseIf Var = "0834" Then
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "D500"
                    frmMain.lstCharacters.SelectedItem = "Legendary Spectral Skull (Skull)"
            End Select
        ElseIf Var = "1E30" Then
            blnTrap = True
            frmMain.cmbGame.SelectedItem = "Traps"

            Select Case Fig
                Case "DC00"
                    frmMain.lstCharacters.SelectedItem = "The Kaos Trap"
            End Select
        ElseIf Var = "1F35" Then
            frmMain.cmbGame.SelectedItem = "Traps"
            blnTrap = True
            Select Case Fig
                Case "DC00"
                    frmMain.lstCharacters.SelectedItem = "Ultimate Kaos Trap"
            End Select
        ElseIf Var = "D800" Then
            frmMain.cmbGame.SelectedItem = "Traps"
            blnTrap = True
            Select Case Fig
                Case "1B30"
                    frmMain.lstCharacters.SelectedItem = "Beam Scream (Yawn)"
                Case "0F30"
                    frmMain.lstCharacters.SelectedItem = "Heavenly Hawk (Hawk)"
            End Select
        ElseIf Var = "1750" Then
            frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "EB00"
                    frmMain.lstCharacters.SelectedItem = "Blue Mystery Chest"
            End Select
        ElseIf Var = "0150" Then
            frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "EB00"
                    frmMain.lstCharacters.SelectedItem = "Bronze Mystery Chest"
            End Select
        ElseIf Var = "0250" Then
            frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "EB00"
                    frmMain.lstCharacters.SelectedItem = "Silver Mystery Chest"
            End Select
        ElseIf Var = "D400" Then
            frmMain.cmbGame.SelectedItem = "Traps"
            blnTrap = True
            Select Case Fig
                Case "D400"
                    frmMain.lstCharacters.SelectedItem = "Breezy Bird (Toucan)"
            End Select
        ElseIf Var = "0304" Then
            frmMain.cmbGame.SelectedItem = "Swap Force"
            Select Case Fig
                Case "F403"
                    frmMain.lstCharacters.SelectedItem = "Legendary Night Shift (Bottom)"
            End Select
        ElseIf Var = "0350" Then
            frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "EB00"
                    frmMain.lstCharacters.SelectedItem = "Gold Mystery Chest"
            End Select
        ElseIf Var = "1950" Then
            frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "EB00"
                    frmMain.lstCharacters.SelectedItem = "Platnium Mystery Chest"
            End Select
        ElseIf Var = "0752" Then
            frmMain.cmbGame.SelectedItem = "Imaginators"
            blnCrystal = True
            Select Case Fig
                Case "AA02"
                    frmMain.lstCharacters.SelectedItem = "Air Crystal"
            End Select
        ElseIf Var = "0652" Then
            frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "B002"
                    frmMain.lstCharacters.SelectedItem = "Dark Crystal"
            End Select
        ElseIf Var = "1D52" Then
            frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "AE02"
                    frmMain.lstCharacters.SelectedItem = "Earth Crystal"
            End Select
        ElseIf Var = "0F52" Then
            frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "AD02"
                    frmMain.lstCharacters.SelectedItem = "Fire Crystal"
            End Select
        ElseIf Var = "1E52" Then
            frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "AF02"
                    frmMain.lstCharacters.SelectedItem = "Life Crystal"
            End Select
        ElseIf Var = "0B52" Then
            frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "B102"
                    frmMain.lstCharacters.SelectedItem = "Light Crystal"
            End Select
        ElseIf Var = "0852" Then
            frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "A802"
                    frmMain.lstCharacters.SelectedItem = "Magic Crystal"
            End Select
        ElseIf Var = "1552" Then
            frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "AC02"
                    frmMain.lstCharacters.SelectedItem = "Tech Crystal"
            End Select
        ElseIf Var = "0952" Then
            frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "AB02"
                    frmMain.lstCharacters.SelectedItem = "Undead Crystal"
            End Select
        ElseIf Var = "1C52" Then
            frmMain.cmbGame.SelectedItem = "Imaginators Crystals"
            blnCrystal = True
            Select Case Fig
                Case "A902"
                    frmMain.lstCharacters.SelectedItem = "Water Crystal"
            End Select
        ElseIf Var = "1554" Then
            frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "5B02"
                    frmMain.lstCharacters.SelectedItem = "Candy-Coated Chopscotch"
            End Select
        ElseIf Var = "0254" Then
            frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "6502"
                    frmMain.lstCharacters.SelectedItem = "Dark Golden Queen"
                Case "5902"
                    frmMain.lstCharacters.SelectedItem = "Dark King Pen"
                Case "6602"
                    frmMain.lstCharacters.SelectedItem = "Dark Wolfgang"
                Case "6E02"
                    frmMain.lstCharacters.SelectedItem = "Mystical Bad Juju"
                Case "6402"
                    frmMain.lstCharacters.SelectedItem = "Mystical Tae Kwon Crow"
                Case "6B02"
                    frmMain.lstCharacters.SelectedItem = "Solar Flare Aurora"
                Case "6302"
                    frmMain.lstCharacters.SelectedItem = "Steel Plated Hood Sickle"
                Case "6602"
                    frmMain.lstCharacters.SelectedItem = "WolfGang Dark"
            End Select
        ElseIf Var = "0D54" Then
            frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "5F02"
                    frmMain.lstCharacters.SelectedItem = "Egg Bomber Air Strike"
                Case "6C02"
                    frmMain.lstCharacters.SelectedItem = "Hard-Boiled Flarewolf"
            End Select
        ElseIf Var = "0E54" Then
            frmMain.cmbGame.SelectedItem = "Imaginators"
            Select Case Fig
                Case "6D02"
                    frmMain.lstCharacters.SelectedItem = "Jingle Bell Chompy Mage"
            End Select
        Else
            MessageBox.Show("Error.  Figure not Recognized.")
            'MessageBox.Show(Fig)
        End If
        'Else frmMain.lstCharacters.SelectedIndex = -1
        'End If
    End Sub
    Shared Sub GetFigureID_AlterEgo_Variant()
        Fig = WholeFile(&H10).ToString("X2") + WholeFile(&H11).ToString("X2")
        Var = WholeFile(&H1C).ToString("X2") + WholeFile(&H1D).ToString("X2")
        FigureItOut()
    End Sub
    Shared Sub Figure()
        MessageBox.Show(Fig & " Figure " & Var & " Variant")
        'MessageBox.Show(Var & " Variant")
    End Sub
#End Region

#Region " List Fill Methods "
    'Sorted Alphabetically
    Shared Sub SpyroAdventure()
        frmMain.lstCharacters.Items.Add("Bash")
        frmMain.lstCharacters.Items.Add("Boomer")
        frmMain.lstCharacters.Items.Add("Camo")
        frmMain.lstCharacters.Items.Add("Chop Chop")
        frmMain.lstCharacters.Items.Add("Cynder")
        frmMain.lstCharacters.Items.Add("Dark Spyro")
        frmMain.lstCharacters.Items.Add("Dino-Rang")
        frmMain.lstCharacters.Items.Add("Double Trouble")
        frmMain.lstCharacters.Items.Add("Drill Sergeant")
        frmMain.lstCharacters.Items.Add("Drobot")
        frmMain.lstCharacters.Items.Add("Eruptor")
        frmMain.lstCharacters.Items.Add("Flameslinger")
        frmMain.lstCharacters.Items.Add("Ghost Roaster")
        frmMain.lstCharacters.Items.Add("Gill Grunt")
        frmMain.lstCharacters.Items.Add("Hex")
        frmMain.lstCharacters.Items.Add("Ignitor")
        frmMain.lstCharacters.Items.Add("Legendary Bash")
        frmMain.lstCharacters.Items.Add("Legendary Chop Chop")
        frmMain.lstCharacters.Items.Add("Legendary Spyro")
        frmMain.lstCharacters.Items.Add("Legendary Trigger Happy")
        frmMain.lstCharacters.Items.Add("Lightning Rod")
        frmMain.lstCharacters.Items.Add("Prism Break")
        frmMain.lstCharacters.Items.Add("Slam Bam")
        frmMain.lstCharacters.Items.Add("Sonic Boom")
        frmMain.lstCharacters.Items.Add("Spyro")
        frmMain.lstCharacters.Items.Add("Stealth Elf")
        frmMain.lstCharacters.Items.Add("Stump Smash")
        frmMain.lstCharacters.Items.Add("Sunburn")
        frmMain.lstCharacters.Items.Add("Terrafin")
        frmMain.lstCharacters.Items.Add("Trigger Happy")
        frmMain.lstCharacters.Items.Add("Voodood")
        frmMain.lstCharacters.Items.Add("Warnado")
        frmMain.lstCharacters.Items.Add("Wham-Shell")
        frmMain.lstCharacters.Items.Add("Whirlwind")
        frmMain.lstCharacters.Items.Add("Wrecking Ball")
        frmMain.lstCharacters.Items.Add("Zap")
        frmMain.lstCharacters.Items.Add("Zook")
    End Sub
    Shared Sub Giants()
        frmMain.lstCharacters.Items.Add("Bouncer")
        frmMain.lstCharacters.Items.Add("Chill")
        frmMain.lstCharacters.Items.Add("Crusher")
        frmMain.lstCharacters.Items.Add("Eye-Brawl")
        frmMain.lstCharacters.Items.Add("Flashwing")
        frmMain.lstCharacters.Items.Add("Fright Rider")
        frmMain.lstCharacters.Items.Add("Gnarly Tree Rex")
        frmMain.lstCharacters.Items.Add("Granite Crusher")
        frmMain.lstCharacters.Items.Add("Hot Dog")
        frmMain.lstCharacters.Items.Add("Hot Head")
        frmMain.lstCharacters.Items.Add("Jade Flashwing")
        frmMain.lstCharacters.Items.Add("Jet-Vac")
        frmMain.lstCharacters.Items.Add("Legendary Bouncer")
        frmMain.lstCharacters.Items.Add("Legendary Chill")
        frmMain.lstCharacters.Items.Add("Legendary Ignitor")
        frmMain.lstCharacters.Items.Add("Legendary Jet-Vac")
        frmMain.lstCharacters.Items.Add("Legendary Slam Bam")
        frmMain.lstCharacters.Items.Add("Legendary Stealth Elf")
        frmMain.lstCharacters.Items.Add("LightCore Chill")
        frmMain.lstCharacters.Items.Add("LightCore Drobot")
        frmMain.lstCharacters.Items.Add("LightCore Eruptor")
        frmMain.lstCharacters.Items.Add("LightCore Hex")
        frmMain.lstCharacters.Items.Add("LightCore Jet-Vac")
        frmMain.lstCharacters.Items.Add("LightCore Pop Fizz")
        frmMain.lstCharacters.Items.Add("LightCore Prism Break")
        frmMain.lstCharacters.Items.Add("LightCore Shroomboom")
        frmMain.lstCharacters.Items.Add("Molten Hot Dog")
        frmMain.lstCharacters.Items.Add("Ninjini")
        frmMain.lstCharacters.Items.Add("Polar Whirlwind")
        frmMain.lstCharacters.Items.Add("Pop Fizz")
        frmMain.lstCharacters.Items.Add("Punch Pop Fizz")
        frmMain.lstCharacters.Items.Add("Royal Double Trouble")
        frmMain.lstCharacters.Items.Add("Scarlet Ninjini")
        frmMain.lstCharacters.Items.Add("Series 2 Bash")
        frmMain.lstCharacters.Items.Add("Series 2 Chop Chop")
        frmMain.lstCharacters.Items.Add("Series 2 Cynder")
        frmMain.lstCharacters.Items.Add("Series 2 Double Trouble")
        frmMain.lstCharacters.Items.Add("Series 2 Drill Sergeant")
        frmMain.lstCharacters.Items.Add("Series 2 Drobot")
        frmMain.lstCharacters.Items.Add("Series 2 Eruptor")
        frmMain.lstCharacters.Items.Add("Series 2 Flameslinger")
        frmMain.lstCharacters.Items.Add("Series 2 Gill Grunt")
        frmMain.lstCharacters.Items.Add("Series 2 Hex")
        frmMain.lstCharacters.Items.Add("Series 2 Ignitor")
        frmMain.lstCharacters.Items.Add("Series 2 Lightning Rod")
        frmMain.lstCharacters.Items.Add("Series 2 Prism Break")
        frmMain.lstCharacters.Items.Add("Series 2 Slam Bam")
        frmMain.lstCharacters.Items.Add("Series 2 Sonic Boom")
        frmMain.lstCharacters.Items.Add("Series 2 Spyro")
        frmMain.lstCharacters.Items.Add("Series 2 Stealth Elf")
        frmMain.lstCharacters.Items.Add("Series 2 Stump Smash")
        frmMain.lstCharacters.Items.Add("Series 2 Terrafin")
        frmMain.lstCharacters.Items.Add("Series 2 Trigger Happy")
        frmMain.lstCharacters.Items.Add("Series 2 Whirlwind")
        frmMain.lstCharacters.Items.Add("Series 2 Wrecking Ball")
        frmMain.lstCharacters.Items.Add("Series 2 Zap")
        frmMain.lstCharacters.Items.Add("Series 2 Zook")
        frmMain.lstCharacters.Items.Add("Shroomboom")
        frmMain.lstCharacters.Items.Add("Sprocket")
        frmMain.lstCharacters.Items.Add("Swarm")
        frmMain.lstCharacters.Items.Add("Thumpback")
        frmMain.lstCharacters.Items.Add("Tree Rex")
    End Sub
    Shared Sub SwapForce()
        frmMain.lstCharacters.Items.Add("Anchors Away Gill Grunt")
        frmMain.lstCharacters.Items.Add("Boom Jet (Bottom)")
        frmMain.lstCharacters.Items.Add("Boom Jet (Top)")
        frmMain.lstCharacters.Items.Add("Big Bang Trigger Happy")
        frmMain.lstCharacters.Items.Add("Blast Zone (Bottom)")
        frmMain.lstCharacters.Items.Add("Blast Zone (Top)")
        frmMain.lstCharacters.Items.Add("Blizzard Chill")
        frmMain.lstCharacters.Items.Add("Bumble Blast")
        frmMain.lstCharacters.Items.Add("Countdown")
        frmMain.lstCharacters.Items.Add("Dark Blast Zone (Bottom)")
        frmMain.lstCharacters.Items.Add("Dark Blast Zone (Top)")
        frmMain.lstCharacters.Items.Add("Dark Mega Ram Spyro")
        frmMain.lstCharacters.Items.Add("Dark Slobber Tooth")
        frmMain.lstCharacters.Items.Add("Dark Stealth Elf")
        frmMain.lstCharacters.Items.Add("Dark Wash Buckler (Bottom)")
        frmMain.lstCharacters.Items.Add("Dark Wash Buckler (Top)")
        frmMain.lstCharacters.Items.Add("Doom Stone (Bottom)")
        frmMain.lstCharacters.Items.Add("Doom Stone (Top)")
        frmMain.lstCharacters.Items.Add("Dune Bug")
        frmMain.lstCharacters.Items.Add("Enchanted Hoot Loop (Bottom)")
        frmMain.lstCharacters.Items.Add("Enchanted Hoot Loop (Top)")
        frmMain.lstCharacters.Items.Add("Enchanted Star Strike")
        frmMain.lstCharacters.Items.Add("Fire Bone Hot Dog")
        frmMain.lstCharacters.Items.Add("Fire Kraken (Bottom)")
        frmMain.lstCharacters.Items.Add("Fire Kraken (Top)")
        frmMain.lstCharacters.Items.Add("Free Ranger (Bottom)")
        frmMain.lstCharacters.Items.Add("Free Ranger (Top)")
        frmMain.lstCharacters.Items.Add("Freeze Blade (Bottom)")
        frmMain.lstCharacters.Items.Add("Freeze Blade (Top)")
        frmMain.lstCharacters.Items.Add("Fryno")
        frmMain.lstCharacters.Items.Add("Grilla Drilla (Bottom)")
        frmMain.lstCharacters.Items.Add("Grilla Drilla (Top)")
        frmMain.lstCharacters.Items.Add("Grim Creeper")
        frmMain.lstCharacters.Items.Add("Heavy Duty Sprocket")
        frmMain.lstCharacters.Items.Add("Hoot Loop (Bottom)")
        frmMain.lstCharacters.Items.Add("Hoot Loop (Top)")
        frmMain.lstCharacters.Items.Add("Horn Blast Whirlwind")
        frmMain.lstCharacters.Items.Add("Hyper Beam Prism Break")
        frmMain.lstCharacters.Items.Add("Jade Fire Kraken (Bottom)")
        frmMain.lstCharacters.Items.Add("Jade Fire Kraken (Top)")
        frmMain.lstCharacters.Items.Add("Jolly Bumble Blast")
        frmMain.lstCharacters.Items.Add("Kickoff Countdown")
        frmMain.lstCharacters.Items.Add("Knockout Terrafin")
        frmMain.lstCharacters.Items.Add("Lava Barf Eruptor")
        frmMain.lstCharacters.Items.Add("Legendary Free Ranger (Bottom)")
        frmMain.lstCharacters.Items.Add("Legendary Free Ranger (Top)")
        frmMain.lstCharacters.Items.Add("Legendary Grim Creeper")
        frmMain.lstCharacters.Items.Add("Legendary Night Shift (Bottom)")
        frmMain.lstCharacters.Items.Add("Legendary Night Shift (Top)")
        frmMain.lstCharacters.Items.Add("Legendary Zoo Lou")
        frmMain.lstCharacters.Items.Add("LightCore Bumble Blast")
        frmMain.lstCharacters.Items.Add("LightCore Countdown")
        frmMain.lstCharacters.Items.Add("LightCore Flashwing")
        frmMain.lstCharacters.Items.Add("LightCore Grim Creeper")
        frmMain.lstCharacters.Items.Add("LightCore Smolderdash")
        frmMain.lstCharacters.Items.Add("LightCore Star Strike")
        frmMain.lstCharacters.Items.Add("LightCore Warnado")
        frmMain.lstCharacters.Items.Add("LightCore Wham-Shell")
        frmMain.lstCharacters.Items.Add("Magna Charge (Bottom)")
        frmMain.lstCharacters.Items.Add("Magna Charge (Top)")
        frmMain.lstCharacters.Items.Add("Mega Ram Spyro")
        frmMain.lstCharacters.Items.Add("Night Shift (Bottom)")
        frmMain.lstCharacters.Items.Add("Night Shift (Top)")
        frmMain.lstCharacters.Items.Add("Ninja Stealth Elf")
        frmMain.lstCharacters.Items.Add("Nitro Freeze Blade (Bottom)")
        frmMain.lstCharacters.Items.Add("Nitro Freeze Blade (Top)")
        frmMain.lstCharacters.Items.Add("Nitro Magna Charge (Bottom)")
        frmMain.lstCharacters.Items.Add("Nitro Magna Charge (Top)")
        frmMain.lstCharacters.Items.Add("Phantom Cynder")
        frmMain.lstCharacters.Items.Add("Pop Thorn")
        frmMain.lstCharacters.Items.Add("Punk Shock")
        frmMain.lstCharacters.Items.Add("Quickdraw Rattle Shake (Bottom)")
        frmMain.lstCharacters.Items.Add("Quickdraw Rattle Shake (Top)")
        frmMain.lstCharacters.Items.Add("Rattle Shake (Bottom)")
        frmMain.lstCharacters.Items.Add("Rattle Shake (Top)")
        frmMain.lstCharacters.Items.Add("Rip Tide")
        frmMain.lstCharacters.Items.Add("Roller Brawl")
        frmMain.lstCharacters.Items.Add("Rubble Rouser (Bottom)")
        frmMain.lstCharacters.Items.Add("Rubble Rouser (Top)")
        frmMain.lstCharacters.Items.Add("Scorp")
        frmMain.lstCharacters.Items.Add("Scratch")
        frmMain.lstCharacters.Items.Add("Slobber Tooth")
        frmMain.lstCharacters.Items.Add("Smolderdash")
        frmMain.lstCharacters.Items.Add("Springtime Trigger Happy")
        frmMain.lstCharacters.Items.Add("Spy Rise (Bottom)")
        frmMain.lstCharacters.Items.Add("Spy Rise (Top)")
        frmMain.lstCharacters.Items.Add("Star Strike")
        frmMain.lstCharacters.Items.Add("Stink Bomb (Bottom)")
        frmMain.lstCharacters.Items.Add("Stink Bomb (Top)")
        frmMain.lstCharacters.Items.Add("Super Gulp Pop Fizz")
        frmMain.lstCharacters.Items.Add("Thorn Horn Camo")
        frmMain.lstCharacters.Items.Add("Trap Shadow (Bottom)")
        frmMain.lstCharacters.Items.Add("Trap Shadow (Top)")
        frmMain.lstCharacters.Items.Add("Turbo Jet-Vac")
        frmMain.lstCharacters.Items.Add("Twin Blade Chop Chop")
        frmMain.lstCharacters.Items.Add("Volcanic Eruptor")
        frmMain.lstCharacters.Items.Add("Wash Buckler (Bottom)")
        frmMain.lstCharacters.Items.Add("Wash Buckler (Top)")
        frmMain.lstCharacters.Items.Add("Wind-Up")
        frmMain.lstCharacters.Items.Add("Zoo Lou")
    End Sub
    Shared Sub TrapTeam()
        frmMain.lstCharacters.Items.Add("Barkley")
        frmMain.lstCharacters.Items.Add("Bat Spin")
        frmMain.lstCharacters.Items.Add("Blackout")
        frmMain.lstCharacters.Items.Add("Blades")
        frmMain.lstCharacters.Items.Add("Blastermind")
        frmMain.lstCharacters.Items.Add("Bop")
        frmMain.lstCharacters.Items.Add("Breeze")
        frmMain.lstCharacters.Items.Add("Bushwhack")
        frmMain.lstCharacters.Items.Add("Chopper")
        frmMain.lstCharacters.Items.Add("Clear Thunderbolt")
        frmMain.lstCharacters.Items.Add("Cobra Cadabra")
        frmMain.lstCharacters.Items.Add("Dark Food Fight")
        frmMain.lstCharacters.Items.Add("Dark Snap Shot")
        frmMain.lstCharacters.Items.Add("Dark Wildfire")
        frmMain.lstCharacters.Items.Add("Drobit")
        frmMain.lstCharacters.Items.Add("Déjà Vu")
        frmMain.lstCharacters.Items.Add("Echo")
        frmMain.lstCharacters.Items.Add("Eggsellent Weeruptor")
        frmMain.lstCharacters.Items.Add("Elite Chop Chop")
        frmMain.lstCharacters.Items.Add("Elite Eruptor")
        frmMain.lstCharacters.Items.Add("Elite Gill Grunt")
        frmMain.lstCharacters.Items.Add("Elite Spyro")
        frmMain.lstCharacters.Items.Add("Elite Stealth Elf")
        frmMain.lstCharacters.Items.Add("Elite Terrafin")
        frmMain.lstCharacters.Items.Add("Elite Trigger Happy")
        frmMain.lstCharacters.Items.Add("Elite Whirlwind")
        frmMain.lstCharacters.Items.Add("Enigma")
        frmMain.lstCharacters.Items.Add("Eye-Small")
        frmMain.lstCharacters.Items.Add("Fist Bump")
        frmMain.lstCharacters.Items.Add("Fizzy Frenzy Pop Fizz")
        frmMain.lstCharacters.Items.Add("Fling Kong")
        frmMain.lstCharacters.Items.Add("Flip Wreck")
        frmMain.lstCharacters.Items.Add("Food Fight")
        frmMain.lstCharacters.Items.Add("Full Blast Jet-Vac")
        frmMain.lstCharacters.Items.Add("Funny Bone")
        frmMain.lstCharacters.Items.Add("Gearshift")
        frmMain.lstCharacters.Items.Add("Gill Runt")
        frmMain.lstCharacters.Items.Add("Gnarly Barkley")
        frmMain.lstCharacters.Items.Add("Gusto")
        frmMain.lstCharacters.Items.Add("Head Rush")
        frmMain.lstCharacters.Items.Add("High Five")
        frmMain.lstCharacters.Items.Add("Hijinx")
        frmMain.lstCharacters.Items.Add("Hog Wild Fryno")
        frmMain.lstCharacters.Items.Add("Instant Food Fight")
        frmMain.lstCharacters.Items.Add("Instant Snap Shot")
        frmMain.lstCharacters.Items.Add("Jawbreaker")
        frmMain.lstCharacters.Items.Add("Ka-Boom")
        frmMain.lstCharacters.Items.Add("King Cobra Cadabra")
        frmMain.lstCharacters.Items.Add("Knight Light")
        frmMain.lstCharacters.Items.Add("Knight Mare")
        frmMain.lstCharacters.Items.Add("Krypt King")
        frmMain.lstCharacters.Items.Add("Legendary Blades")
        frmMain.lstCharacters.Items.Add("Legendary Bushwhack")
        frmMain.lstCharacters.Items.Add("Legendary Déjà Vu")
        frmMain.lstCharacters.Items.Add("Legendary Jawbreaker")
        frmMain.lstCharacters.Items.Add("Lob-Star")
        frmMain.lstCharacters.Items.Add("Love Potion Pop Fizz")
        frmMain.lstCharacters.Items.Add("Mini-Jini")
        frmMain.lstCharacters.Items.Add("Nitro Head Rush")
        frmMain.lstCharacters.Items.Add("Nitro Krypt King")
        frmMain.lstCharacters.Items.Add("Pet-Vac")
        frmMain.lstCharacters.Items.Add("Power Punch Pet-Vac")
        frmMain.lstCharacters.Items.Add("Rocky Roll")
        frmMain.lstCharacters.Items.Add("Short Cut")
        frmMain.lstCharacters.Items.Add("Small Fry")
        frmMain.lstCharacters.Items.Add("Snap Shot")
        frmMain.lstCharacters.Items.Add("Spotlight")
        frmMain.lstCharacters.Items.Add("Spry")
        frmMain.lstCharacters.Items.Add("Sure Shot Shroomboom")
        frmMain.lstCharacters.Items.Add("Terrabite")
        frmMain.lstCharacters.Items.Add("Thumpling")
        frmMain.lstCharacters.Items.Add("Thunderbolt")
        frmMain.lstCharacters.Items.Add("Tidal Wave Gill Grunt")
        frmMain.lstCharacters.Items.Add("Torch")
        frmMain.lstCharacters.Items.Add("Trail Blazer")
        frmMain.lstCharacters.Items.Add("Tread Head")
        frmMain.lstCharacters.Items.Add("Trigger Snappy")
        frmMain.lstCharacters.Items.Add("Tuff Luck")
        frmMain.lstCharacters.Items.Add("Wallop")
        frmMain.lstCharacters.Items.Add("Weeruptor")
        frmMain.lstCharacters.Items.Add("Whisper Elf")
        frmMain.lstCharacters.Items.Add("Wildfire")
        frmMain.lstCharacters.Items.Add("Winterfest Lob-Star")
    End Sub
    Shared Sub SuperChargers()
        frmMain.lstCharacters.Items.Add("--Characters--")
        frmMain.lstCharacters.Items.Add("Astroblast")
        frmMain.lstCharacters.Items.Add("Big Bubble Pop Fizz")
        frmMain.lstCharacters.Items.Add("Birthday Bash Big Bubble Pop Fizz")
        frmMain.lstCharacters.Items.Add("Bone Bash Roller Brawl")
        frmMain.lstCharacters.Items.Add("Dark Hammer Slam Bowser")
        frmMain.lstCharacters.Items.Add("Dark Spitfire")
        frmMain.lstCharacters.Items.Add("Dark Super Shot Stealth Elf")
        frmMain.lstCharacters.Items.Add("Dark Turbo Charge Donkey Kong")
        frmMain.lstCharacters.Items.Add("Deep Dive Gill Grunt")
        frmMain.lstCharacters.Items.Add("Dive-Clops")
        frmMain.lstCharacters.Items.Add("Double Dare Trigger Happy")
        frmMain.lstCharacters.Items.Add("Eggcited Thrillipede")
        frmMain.lstCharacters.Items.Add("Elite Boomer")
        frmMain.lstCharacters.Items.Add("Elite Dino-Rang")
        frmMain.lstCharacters.Items.Add("Elite Ghost Roaster")
        frmMain.lstCharacters.Items.Add("Elite Slam Bam")
        frmMain.lstCharacters.Items.Add("Elite Voodood")
        frmMain.lstCharacters.Items.Add("Elite Zook")
        frmMain.lstCharacters.Items.Add("Fiesta")
        frmMain.lstCharacters.Items.Add("Frightful Fiesta")
        frmMain.lstCharacters.Items.Add("Hammer Slam Bowser")
        frmMain.lstCharacters.Items.Add("High Volt")
        frmMain.lstCharacters.Items.Add("Hurricane Jet-Vac")
        frmMain.lstCharacters.Items.Add("Lava Lance Eruptor")
        frmMain.lstCharacters.Items.Add("Legendary Astroblast")
        frmMain.lstCharacters.Items.Add("Legendary Bone Bash Roller Brawl")
        frmMain.lstCharacters.Items.Add("Legendary Hurricane Jet-Vac")
        frmMain.lstCharacters.Items.Add("Legendary Sun Runner")
        frmMain.lstCharacters.Items.Add("Missile-Tow Dive-Clops")
        frmMain.lstCharacters.Items.Add("Nightfall")
        frmMain.lstCharacters.Items.Add("Power Blue Splat")
        frmMain.lstCharacters.Items.Add("Power Blue Trigger Happy")
        frmMain.lstCharacters.Items.Add("Shark Shooter Terrafin")
        frmMain.lstCharacters.Items.Add("Smash Hit")
        frmMain.lstCharacters.Items.Add("Spitfire")
        frmMain.lstCharacters.Items.Add("Splat")
        frmMain.lstCharacters.Items.Add("Steel Plated Smash Hit")
        frmMain.lstCharacters.Items.Add("Stormblade")
        frmMain.lstCharacters.Items.Add("Super Shot Stealth Elf")
        frmMain.lstCharacters.Items.Add("Thrillipede")
        frmMain.lstCharacters.Items.Add("Turbo Charge Donkey Kong")

        'frmMain.lstCharacters.Items.Add("--Villain Vehicles--")
        'frmMain.lstCharacters.Items.Add("--Pandergast Vehicles--")
        frmMain.lstCharacters.Items.Add("--Trophies--")
        frmMain.lstCharacters.Items.Add("Kaos Trophy")
        frmMain.lstCharacters.Items.Add("Land Trophy")
        frmMain.lstCharacters.Items.Add("Sea Trophy")
        frmMain.lstCharacters.Items.Add("Sky Trophy")
    End Sub
    Shared Sub Imaginators()
        'Characters
        frmMain.lstCharacters.Items.Add("Air Strike")
        frmMain.lstCharacters.Items.Add("Ambush")
        frmMain.lstCharacters.Items.Add("Aurora")
        frmMain.lstCharacters.Items.Add("Bad Juju")
        frmMain.lstCharacters.Items.Add("Barbella")
        frmMain.lstCharacters.Items.Add("Blaster-Tron")
        frmMain.lstCharacters.Items.Add("Boom Bloom")
        frmMain.lstCharacters.Items.Add("Buckshot")
        frmMain.lstCharacters.Items.Add("Candy-Coated Chopscotch")
        frmMain.lstCharacters.Items.Add("Chain Reaction")
        frmMain.lstCharacters.Items.Add("Chompy Mage")
        frmMain.lstCharacters.Items.Add("Chopscotch")
        frmMain.lstCharacters.Items.Add("Clear Starcast")
        frmMain.lstCharacters.Items.Add("Crash Bandicoot")
        frmMain.lstCharacters.Items.Add("Dark Golden Queen")
        frmMain.lstCharacters.Items.Add("Dark King Pen")
        frmMain.lstCharacters.Items.Add("Dark Wolfgang")
        frmMain.lstCharacters.Items.Add("Dec-Ember")
        frmMain.lstCharacters.Items.Add("Dr. Krankcase")
        frmMain.lstCharacters.Items.Add("Dr. Neo Cortex")
        frmMain.lstCharacters.Items.Add("Egg Bomber Air Strike")
        frmMain.lstCharacters.Items.Add("Ember")
        frmMain.lstCharacters.Items.Add("Flarewolf")
        frmMain.lstCharacters.Items.Add("Golden Queen")
        frmMain.lstCharacters.Items.Add("Grave Clobber")
        frmMain.lstCharacters.Items.Add("Hard-Boiled Flarewolf")
        frmMain.lstCharacters.Items.Add("Heartbreaker Buckshot")
        frmMain.lstCharacters.Items.Add("Hood Sickle")
        frmMain.lstCharacters.Items.Add("Jingle Bell Chompy Mage")
        frmMain.lstCharacters.Items.Add("Kaos")
        frmMain.lstCharacters.Items.Add("King Pen")
        frmMain.lstCharacters.Items.Add("Legendary Pit Boss")
        frmMain.lstCharacters.Items.Add("Legendary Tri-Tip")
        frmMain.lstCharacters.Items.Add("Mystical Bad Juju")
        frmMain.lstCharacters.Items.Add("Mystical Tae Kwon Crow")
        frmMain.lstCharacters.Items.Add("Mysticat")
        frmMain.lstCharacters.Items.Add("Orange Chain Reaction")
        frmMain.lstCharacters.Items.Add("Pain-Yatta")
        frmMain.lstCharacters.Items.Add("Pink Barbella")
        frmMain.lstCharacters.Items.Add("Pit Boss")
        frmMain.lstCharacters.Items.Add("Ro-Bow")
        frmMain.lstCharacters.Items.Add("Rock Candy Pain-Yatta")
        frmMain.lstCharacters.Items.Add("Solar Flare Aurora")
        frmMain.lstCharacters.Items.Add("Starcast")
        frmMain.lstCharacters.Items.Add("Steel Plated Hood Sickle")
        frmMain.lstCharacters.Items.Add("Tae Kwon Crow")
        frmMain.lstCharacters.Items.Add("Tidepool")
        frmMain.lstCharacters.Items.Add("Tri-Tip")
        frmMain.lstCharacters.Items.Add("Wild Storm")
        frmMain.lstCharacters.Items.Add("Wolfgang")
    End Sub

    Shared Sub Traps()
        frmMain.lstCharacters.Items.Add("--Air--")
        frmMain.lstCharacters.Items.Add("Breezy Bird (Toucan)")
        frmMain.lstCharacters.Items.Add("Cloudy Cobra (Snake)")
        frmMain.lstCharacters.Items.Add("Cyclone Sabre (Sword)")
        frmMain.lstCharacters.Items.Add("Drafty Decanter (Jughead)")
        frmMain.lstCharacters.Items.Add("Storm Warning (Screamer)")
        frmMain.lstCharacters.Items.Add("Tempest Timer (Hourglass)")
        frmMain.lstCharacters.Items.Add("--Dark--")
        frmMain.lstCharacters.Items.Add("Dark Dagger (Sword)")
        frmMain.lstCharacters.Items.Add("Ghastly Grimace (Handstand)")
        frmMain.lstCharacters.Items.Add("Shadow Spider (Spider)")
        frmMain.lstCharacters.Items.Add("--Earth--")
        frmMain.lstCharacters.Items.Add("Banded Boulder (Orb)")
        frmMain.lstCharacters.Items.Add("Dust of Time (Hourglass)")
        frmMain.lstCharacters.Items.Add("Rock Hawk (Toucan)")
        frmMain.lstCharacters.Items.Add("Rubble Trouble (Handstand)")
        frmMain.lstCharacters.Items.Add("Slag Hammer (Hammer)")
        frmMain.lstCharacters.Items.Add("Spinning Sandstorm (Totem)")
        frmMain.lstCharacters.Items.Add("--Fire--")
        frmMain.lstCharacters.Items.Add("Blazing Belch (Yawn)")
        frmMain.lstCharacters.Items.Add("Eternal Flame (Torch)")
        frmMain.lstCharacters.Items.Add("Fire Flower (Scepter)")
        frmMain.lstCharacters.Items.Add("Scorching Stopper (Screamer)")
        frmMain.lstCharacters.Items.Add("Searing Spinner (Totem)")
        frmMain.lstCharacters.Items.Add("Spark Spear (Captain's Hat)")
        frmMain.lstCharacters.Items.Add("--Life--")
        frmMain.lstCharacters.Items.Add("Emerald Energy (Torch)")
        frmMain.lstCharacters.Items.Add("Jade Blade (Sword)")
        frmMain.lstCharacters.Items.Add("Oak Eagle (Toucan)")
        frmMain.lstCharacters.Items.Add("Seed Serpent (Snake)")
        frmMain.lstCharacters.Items.Add("Shrub Shrieker (Yawn)")
        frmMain.lstCharacters.Items.Add("Weed Whacker (Hammer)")
        frmMain.lstCharacters.Items.Add("--Light--")
        frmMain.lstCharacters.Items.Add("Beam Scream (Yawn)")
        frmMain.lstCharacters.Items.Add("Heavenly Hawk (Hawk)")
        frmMain.lstCharacters.Items.Add("Shining Ship (Rocket)")
        frmMain.lstCharacters.Items.Add("--Magic--")
        frmMain.lstCharacters.Items.Add("Arcane Hourglass (Hourglass)")
        frmMain.lstCharacters.Items.Add("Axe of Illusion (Axe)")
        frmMain.lstCharacters.Items.Add("Biter's Bane (Log Holder)")
        frmMain.lstCharacters.Items.Add("Rune Rocket (Rocket)")
        frmMain.lstCharacters.Items.Add("Sorcerous Skull (Skull)")
        frmMain.lstCharacters.Items.Add("Spell Slapper (Totem)")
        frmMain.lstCharacters.Items.Add("--Tech--")
        frmMain.lstCharacters.Items.Add("Automatic Angel (Angel)")
        frmMain.lstCharacters.Items.Add("Factory Flower (Scepter)")
        frmMain.lstCharacters.Items.Add("Grabbing Gadget (Hand)")
        frmMain.lstCharacters.Items.Add("Makers Mana (Flying Helmet)")
        frmMain.lstCharacters.Items.Add("Tech Totem (Tiki)")
        frmMain.lstCharacters.Items.Add("Topsy Techy (Handstand)")
        frmMain.lstCharacters.Items.Add("--Undead--")
        frmMain.lstCharacters.Items.Add("Dream Piercer (Captain's Hat)")
        frmMain.lstCharacters.Items.Add("Grim Gripper (Hand)")
        frmMain.lstCharacters.Items.Add("Haunted Hatchet (Axe)")
        frmMain.lstCharacters.Items.Add("Spectral Skull (Skull)")
        frmMain.lstCharacters.Items.Add("Spirit Sphere (Orb)")
        frmMain.lstCharacters.Items.Add("Spooky Snake (Snake)")
        frmMain.lstCharacters.Items.Add("Legendary Spirit Sphere (Orb)")
        frmMain.lstCharacters.Items.Add("Legendary Spectral Skull (Skull)")
        frmMain.lstCharacters.Items.Add("--Water--")
        frmMain.lstCharacters.Items.Add("Aqua Axe (Axe)")
        frmMain.lstCharacters.Items.Add("Flood Flask (Jughead)")
        frmMain.lstCharacters.Items.Add("Frost Helm (Flying Helmet)")
        frmMain.lstCharacters.Items.Add("Soaking Staff (Angel)")
        frmMain.lstCharacters.Items.Add("Tidal Tiki (Tiki)")
        frmMain.lstCharacters.Items.Add("Wet Walter (Log Holder)")
        frmMain.lstCharacters.Items.Add("Legendary Flood Flask (Jughead)")
        frmMain.lstCharacters.Items.Add("--Kaos--")
        frmMain.lstCharacters.Items.Add("The Kaos Trap")
        frmMain.lstCharacters.Items.Add("Ultimate Kaos Trap")
    End Sub
    Shared Sub Vehicles()
        frmMain.lstCharacters.Items.Add("--Land Vehicles--")
        frmMain.lstCharacters.Items.Add("Barrel Blaster")
        frmMain.lstCharacters.Items.Add("Burn-Cycle")
        frmMain.lstCharacters.Items.Add("Crypt Crusher")
        frmMain.lstCharacters.Items.Add("Dark Barrel Blaster")
        frmMain.lstCharacters.Items.Add("Dark Hot Streak")
        frmMain.lstCharacters.Items.Add("E3 Hot Streak")
        frmMain.lstCharacters.Items.Add("Gold Rusher")
        frmMain.lstCharacters.Items.Add("Golden Hot Streak")
        frmMain.lstCharacters.Items.Add("Hot Streak")
        frmMain.lstCharacters.Items.Add("Power Blue Gold Rusher")
        frmMain.lstCharacters.Items.Add("Shark Tank")
        frmMain.lstCharacters.Items.Add("Shield Striker")
        frmMain.lstCharacters.Items.Add("Thump Truck")
        frmMain.lstCharacters.Items.Add("Tomb Buggy")

        frmMain.lstCharacters.Items.Add("--Sea Vehicles--")
        frmMain.lstCharacters.Items.Add("Dark Sea Shadow")
        frmMain.lstCharacters.Items.Add("Dive Bomber")
        frmMain.lstCharacters.Items.Add("Nitro Soda Skimmer")
        frmMain.lstCharacters.Items.Add("Power Blue Splatter Splasher")
        frmMain.lstCharacters.Items.Add("Reef Ripper")
        frmMain.lstCharacters.Items.Add("Sea Shadow")
        frmMain.lstCharacters.Items.Add("Soda Skimmer")
        frmMain.lstCharacters.Items.Add("Splatter Splasher")
        frmMain.lstCharacters.Items.Add("Spring Ahead Dive Bomber")

        frmMain.lstCharacters.Items.Add("--Sky Vehicles--")
        frmMain.lstCharacters.Items.Add("Buzz Wing")
        frmMain.lstCharacters.Items.Add("Clown Cruiser")
        frmMain.lstCharacters.Items.Add("Dark Clown Cruiser")
        frmMain.lstCharacters.Items.Add("Jet Stream")
        frmMain.lstCharacters.Items.Add("Nitro Stealth Stinger")
        frmMain.lstCharacters.Items.Add("Sky Slicer")
        frmMain.lstCharacters.Items.Add("Stealth Stinger")
        frmMain.lstCharacters.Items.Add("Sun Runner")
    End Sub
    Shared Sub Crystals()
        'Apparently these Figures ARE Unique Variant but I have NO information on them.  :(
        frmMain.lstCharacters.Items.Add("Air Crystal")
        'frmMain.lstCharacters.Items.Add("Air Acorn")
        'frmMain.lstCharacters.Items.Add("Air Angel")
        'frmMain.lstCharacters.Items.Add("Air Lantern")
        frmMain.lstCharacters.Items.Add("Dark Crystal")
        'frmMain.lstCharacters.Items.Add("Dark Pyramid")
        'frmMain.lstCharacters.Items.Add("Dark Reactor")
        'frmMain.lstCharacters.Items.Add("Dark Rune")
        frmMain.lstCharacters.Items.Add("Earth Crystal")
        'frmMain.lstCharacters.Items.Add("Earth Armor")
        'frmMain.lstCharacters.Items.Add("Earth Rocket")
        'frmMain.lstCharacters.Items.Add("Earth Rune")
        frmMain.lstCharacters.Items.Add("Fire Crystal")
        'frmMain.lstCharacters.Items.Add("Fire Acorn")
        'frmMain.lstCharacters.Items.Add("Fire Angel")
        'frmMain.lstCharacters.Items.Add("Fire Reactor")
        frmMain.lstCharacters.Items.Add("Life Crystal")
        'frmMain.lstCharacters.Items.Add("Life Acorn")
        'frmMain.lstCharacters.Items.Add("Life Claw")
        'frmMain.lstCharacters.Items.Add("Life Rocket")
        'frmMain.lstCharacters.Items.Add("Life Rune")
        frmMain.lstCharacters.Items.Add("Light Crystal")
        'frmMain.lstCharacters.Items.Add("Light Angel")
        'frmMain.lstCharacters.Items.Add("Light Fanged")
        'frmMain.lstCharacters.Items.Add("Light Rune")
        frmMain.lstCharacters.Items.Add("Magic Crystal")
        'frmMain.lstCharacters.Items.Add("Magic Claw")
        'frmMain.lstCharacters.Items.Add("Magic Lantern")
        'frmMain.lstCharacters.Items.Add("Magic Pyramid")
        frmMain.lstCharacters.Items.Add("Tech Crystal")
        'frmMain.lstCharacters.Items.Add("Tech Armor")
        'frmMain.lstCharacters.Items.Add("Tech Pyramid")
        'frmMain.lstCharacters.Items.Add("Tech Reactor")
        frmMain.lstCharacters.Items.Add("Undead Crystal")
        'frmMain.lstCharacters.Items.Add("Undead Claw")
        'frmMain.lstCharacters.Items.Add("Undead Fanged")
        'frmMain.lstCharacters.Items.Add("Undead Lantern")
        frmMain.lstCharacters.Items.Add("Water Crystal")
        'frmMain.lstCharacters.Items.Add("Water Armor")
        'frmMain.lstCharacters.Items.Add("Water Fanged")
        'frmMain.lstCharacters.Items.Add("Water Rocket")
        'frmMain.lstCharacters.Items.Add("Legendary Life Acorn")
        'frmMain.lstCharacters.Items.Add("Legendary Light Fanged")
        'frmMain.lstCharacters.Items.Add("Legendary Magic Lantern")
    End Sub
    'These Items are mostly, universal.
    'As such, not going to restrict them based on game.
    Shared Sub Items()
        frmMain.lstCharacters.Items.Add("--Adventures--")
        frmMain.lstCharacters.Items.Add("Anvil Rain")
        frmMain.lstCharacters.Items.Add("Ghost Pirate Swords")
        frmMain.lstCharacters.Items.Add("Healing Elixir")
        frmMain.lstCharacters.Items.Add("Hidden Treasure")
        frmMain.lstCharacters.Items.Add("Sky-Iron Shield")
        frmMain.lstCharacters.Items.Add("Sparx the Dragonfly")
        frmMain.lstCharacters.Items.Add("Time Twister Hourglass")
        frmMain.lstCharacters.Items.Add("Winged Boots")
        frmMain.lstCharacters.Items.Add("--Giants--")
        frmMain.lstCharacters.Items.Add("Dragonfire Cannon")
        frmMain.lstCharacters.Items.Add("Scorpion Striker")
        frmMain.lstCharacters.Items.Add("Golden Dragonfire Cannon")
        frmMain.lstCharacters.Items.Add("Platinum Hidden Treasure")
        frmMain.lstCharacters.Items.Add("--Swap Force--")
        frmMain.lstCharacters.Items.Add("Arkeyan Crossbow")
        frmMain.lstCharacters.Items.Add("Battle Hammer")
        frmMain.lstCharacters.Items.Add("Fiery Forge")
        frmMain.lstCharacters.Items.Add("Groove Machine")
        frmMain.lstCharacters.Items.Add("Platinum Sheep")
        frmMain.lstCharacters.Items.Add("Sky Diamond")
        frmMain.lstCharacters.Items.Add("UFO Hat")
        frmMain.lstCharacters.Items.Add("--Trap Team--")
        frmMain.lstCharacters.Items.Add("Hand of Fate")
        frmMain.lstCharacters.Items.Add("Legendary Hand of Fate")
        frmMain.lstCharacters.Items.Add("Piggy Bank")
        frmMain.lstCharacters.Items.Add("Rocket Ram")
        frmMain.lstCharacters.Items.Add("Tiki Speaky")
        frmMain.lstCharacters.Items.Add("--SuperChargers--")
        frmMain.lstCharacters.Items.Add("Kaos Trophy")
        frmMain.lstCharacters.Items.Add("Land Trophy")
        frmMain.lstCharacters.Items.Add("Sea Trophy")
        frmMain.lstCharacters.Items.Add("Sky Trophy")
        'Chests
        frmMain.lstCharacters.Items.Add("--Imaginators--")
        frmMain.lstCharacters.Items.Add("Blue Imaginite Mystery Chest")
        frmMain.lstCharacters.Items.Add("Bronze Imaginite Mystery Chest")
        frmMain.lstCharacters.Items.Add("Gold Imaginite Mystery Chest")
        frmMain.lstCharacters.Items.Add("Silver Imaginite Mystery Chest")
    End Sub
    Shared Sub AdventurePacks()
        'The Commented out Adventure Packs, are unlocked via figure not Item.
        frmMain.lstCharacters.Items.Add("--Adventures--")
        frmMain.lstCharacters.Items.Add("Darklight Crypt")
        frmMain.lstCharacters.Items.Add("Dragon's Peak")
        frmMain.lstCharacters.Items.Add("Empire of Ice")
        frmMain.lstCharacters.Items.Add("Pirate Seas")
        frmMain.lstCharacters.Items.Add("Volcanic Vault")
        frmMain.lstCharacters.Items.Add("--Swap Force--")
        frmMain.lstCharacters.Items.Add("Fiery Forge")
        frmMain.lstCharacters.Items.Add("Sheep Wreck Island")
        frmMain.lstCharacters.Items.Add("Tower of Time")
        frmMain.lstCharacters.Items.Add("--Trap Team--")
        frmMain.lstCharacters.Items.Add("Midnight Museum")
        frmMain.lstCharacters.Items.Add("Mirror of Mystery")
        frmMain.lstCharacters.Items.Add("Nightmare Express")
        frmMain.lstCharacters.Items.Add("Sunscraper Spire")
        frmMain.lstCharacters.Items.Add("--Imaginators--")
        'Obtained through Air Sensei Wild Storm
        'frmMain.lstCharacters.Items.Add("Cursed Tiki Temple")
        frmMain.lstCharacters.Items.Add("Enchanted Elven Forest")
        frmMain.lstCharacters.Items.Add("Gryphon Park Observatory")
        'Obtained through Tech Sensei Ro-Bow
        'frmMain.lstCharacters.Items.Add("Lost Imaginite Mines")
        'Obtained through Crash or Cortex Figures.
        'frmMain.lstCharacters.Items.Add("Thumpin' Wumpa Islands")
    End Sub
#End Region
End Class
