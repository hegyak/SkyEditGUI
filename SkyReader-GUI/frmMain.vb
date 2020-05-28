Imports System.ComponentModel
Imports SkyReader_GUI.DeviceManagement
Imports SkyReader_GUI.FigureIO
'TODO Chart
'Fix Trap CRC

'Finish Vehicle Editor

'Crystals Editing

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
    'Should these be here?  Probably not.  Probably in Figure or FigureIO
    Public Shared Area0 As Byte
    Public Shared Area1 As Byte

#Region " File Read/Write "


    Private Sub btnRaw_Click(sender As Object, e As EventArgs) Handles btnRaw.Click
        Raw_Write()
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
    'Dim CMB As Integer = 0
    Private Sub cmbGame_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGame.SelectedIndexChanged
        lstCharacters.Items.Clear()
        chkSerial.Enabled = True
        Enable_Controls()
        lblArea1Type4.Text = "Area 0 Type 4"
        lblArea2Type4.Text = "Area 1 Type 4"
        lblArea1Type3.Visible = True
        lblArea2Type3.Visible = True
        picArea0Type3.Visible = True
        picArea1Type3.Visible = True

        If blnTrap = True And cmbGame.SelectedItem <> "Traps" Then
            cmbGame.SelectedItem = "Traps"
            ' Exit Sub
        End If
        If BlnVehicle = True And cmbGame.SelectedItem <> "Vehicles" Then
            cmbGame.SelectedItem = "Vehicles"
            'Exit Sub
        ElseIf blnCrystal = True And cmbGame.SelectedItem <> "Crystals" Then
            cmbGame.SelectedItem = "Crystals"
            'Exit Sub
        End If

        'Adventure Packs

        If cmbGame.SelectedItem = "Spyro's Adventure" Then
            'Spyro's Adventure
            Figures.SpyroAdventure()

        ElseIf cmbGame.SelectedItem = "Giants" Then
            'Giants
            Figures.Giants()
        ElseIf cmbGame.SelectedItem = "Swap Force" Then
            'Swap Force
            Figures.SwapForce()
        ElseIf cmbGame.SelectedItem = "Trap Team" Then
            'Trap Team
            Figures.TrapTeam()
        ElseIf cmbGame.SelectedItem = "Traps" Then
            'Traps
            Disable_Controls()
            Figures.Traps()
            'Traps, do not use Type 4 CRC
            'Traps, do not use Type 3 CRC
            lblArea1Type4.Text = "Area 0 Trap CRC"
            lblArea2Type4.Text = "Area 1 Trap CRC"
            lblArea1Type3.Visible = False
            lblArea2Type3.Visible = False
            picArea0Type3.Visible = False
            picArea1Type3.Visible = False
        ElseIf cmbGame.SelectedItem = "SuperChargers" Then
            'SuperChargers
            Figures.SuperChargers()
        ElseIf cmbGame.SelectedItem = "Vehicles" Then
            'SaldeStatus.Text = "TODO: FIX"
            Figures.Vehicles()
        ElseIf cmbGame.SelectedItem = "Imaginators" Then
            'Imaginators
            Figures.Imaginators()
            'Due to the Extra Layer of Security, changing the Figure's Serial is Disabled.
            chkSerial.Checked = False
            chkSerial.Enabled = False
        ElseIf cmbGame.SelectedItem = "Imaginators Crystals" Then
            'SaldeStatus.Text = "TODO: FIX"
            Figures.Crystals()
            'Due to the Extra Layer of Security, changing the Figure's Serial is Disabled.
            chkSerial.Checked = False
            chkSerial.Enabled = False
        ElseIf cmbGame.SelectedItem = "Items" Then
            'Items
            'We don't populate the Hats since items and Traps can't wear them.
            Figures.Items()
            Disable_Controls()
        ElseIf cmbGame.SelectedItem = "Adventure Packs" Then
            'Adventure Packs
            Disable_Controls()
            Figures.AdventurePacks()
        End If
        'Only the main games get Hats.
        If cmbGame.SelectedIndex < 6 Then
            'cmbHat.SelectedIndex = 0
        End If
        Application.DoEvents()
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
#If DEBUG Then
#Else
        cmbGame.Items.Remove("Imaginators Crystals")
        CrystalsToolStripMenuItem.Dispose()
        btnCrystals.Dispose
#End If
    End Sub
#End Region

#Region " Menu "
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        'Goes to FigureIO to Load File
        Load_File()
    End Sub

    Private Sub Save_Enc_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Save_Enc_ToolStripMenuItem.Click
        Write_Encrypted_Figure()
    End Sub
    Private Sub SaveDecryptedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Save_Dec_ToolStripMenuItem.Click
        Write_Decrypted_Figure()
    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub


    Private Sub ReadSkylanderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadSkylanderToolStripMenuItem.Click
        If bgReadPortal.IsBusy = False Then
            bgReadPortal.RunWorkerAsync()
        Else
            SaldeStatus.Text = "Reading from Portal.  Please Wait."
            Exit Sub
        End If
    End Sub
    Private Sub WriteSkylanderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WriteSkylanderToolStripMenuItem.Click
        If lstCharacters.SelectedIndex = -1 Then
            SaldeStatus.Text = "No figure Selected"
            Exit Sub
        End If
        'If we use Background Worker, it creates a Seperate Instance of the GUI.
        'We actually need to SET Data here
        If blnCrystal = False And blnTrap = False And BlnVehicle = False Then
            Write_Data()
        End If

        'We need to Encrypt the Array Before we write
        Encrypt()
        SaldeStatus.Text = "Writing to Portal."
        If bgWritePortal.IsBusy Then
            SaldeStatus.Text = "Still Writing to Portal"
            Exit Sub
        End If
        bgWritePortal.RunWorkerAsync()
    End Sub

    'I may want see/check for a Swap Force Figure.
    Private Sub ReadSecondFigureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadSecondFigureToolStripMenuItem.Click
        If bgReadPortalDuo.IsBusy = False Then
            bgReadPortalDuo.RunWorkerAsync()
        Else
            SaldeStatus.Text = "Reading from Portal.  Please Wait."
            Exit Sub
        End If
    End Sub
    Private Sub WriteSecondFigureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WriteSecondFigureToolStripMenuItem.Click
        If lstCharacters.SelectedIndex = -1 Then
            SaldeStatus.Text = "No figure Selected"
            Exit Sub
        End If
        'If we use Background Worker, it creates a Seperate Instance of the GUI.
        'We actually need to SET Data here
        If blnCrystal = False And blnTrap = False And BlnVehicle = False Then
            Write_Data()
        End If
        'We need to Encrypt the Array Before we write
        Encrypt()
        SaldeStatus.Text = "Writing to Portal"
        If bgWritePortalDuo.IsBusy Then
            SaldeStatus.Text = "Still Writing to Portal"
            Exit Sub
        End If
        bgWritePortalDuo.RunWorkerAsync()
    End Sub

    Private Sub ConnectToPortalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToPortalToolStripMenuItem.Click
        Portal.portalHandle = FindThePortal()
    End Sub
    Private Sub TrapsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrapsToolStripMenuItem.Click
        If cmbGame.SelectedItem <> "Traps" Then
            SaldeStatus.Text = "Please Read a Trap Figure in First."
            Exit Sub
        End If
        Dim frmTraps As New frmTraps
        frmTraps.Show()
        Hide()
    End Sub

    Private Sub VehiclesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VehiclesToolStripMenuItem.Click
        Dim frmVehicles As New frmVehicles
        Hide()
        frmVehicles.Show()
    End Sub

    Private Sub CrystalsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrystalsToolStripMenuItem.Click
        If cmbGame.SelectedItem <> "Imaginators Crystals" Then
            Exit Sub
        End If
        Dim frmCrystals As New frmCrystals
        frmCrystals.Show()
        Hide()
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
        'Since we may be resetting from Trap 
        lblArea1Type4.Text = "Area 0 Type 4"
        lblArea2Type4.Text = "Area 1 Type 4"
        lblArea1Type3.Visible = True
        lblArea2Type3.Visible = True
        picArea0Type3.Visible = True
        picArea1Type3.Visible = True

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
        frmArea.Clear()
    End Sub
#End Region

#Region "Portal Handling"
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
                    Portal.blnPortal = False
                End If
            End If
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub BgReadPortal_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgReadPortal.DoWork
        Portal.ReadPortal()
    End Sub

    Private Sub bgReadPortal_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgReadPortal.RunWorkerCompleted
        SaldeStatus.Text = "Figure Read from Portal"
        Parse_Figure()
    End Sub

    Private Sub BgWritePortal_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWritePortal.DoWork

        SaldeStatus.Text = "Writing to Portal"
        'write data to skylander in portal
        Portal.Portal_Write()
    End Sub

    Private Sub bgWritePortal_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgWritePortal.RunWorkerCompleted
        SaldeStatus.Text = "Figure written to Portal"
    End Sub

    Private Sub bgReadPortalDuo_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgReadPortalDuo.DoWork
        Portal.Portal_Duo_Read()
    End Sub
    Private Sub bgReadPortalDuo_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgReadPortalDuo.RunWorkerCompleted
        SaldeStatus.Text = "Figure Read from Portal"
        Parse_Figure()
    End Sub

    Private Sub bgWritePortalDuo_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWritePortalDuo.DoWork
        Portal.Portal_Duo_Write()
        'write data to skylander in portal
    End Sub
    'Disable the Portal Menu Controls except for Connect.
    'This is done when the Portal is Removed
    Public Sub lockPortalControls()
        DisablePortalControls()
    End Sub
    Sub DisableControls()
        Save_Enc_ToolStripMenuItem.Enabled = False
        DisablePortalControls()
    End Sub
    Sub DisablePortalControls()
        ReadSkylanderToolStripMenuItem.Enabled = False
        WriteSkylanderToolStripMenuItem.Enabled = False
        ReadSecondFigureToolStripMenuItem.Enabled = False
        WriteSecondFigureToolStripMenuItem.Enabled = False
    End Sub

    Public Sub unlockPortalControls()
        'SaldeStatus.Text = "Unlocked"
        ReadSkylanderToolStripMenuItem.Enabled = True
        WriteSkylanderToolStripMenuItem.Enabled = True
        ReadSecondFigureToolStripMenuItem.Enabled = True
        WriteSecondFigureToolStripMenuItem.Enabled = True
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

    Private Sub btnShowData_Click(sender As Object, e As EventArgs) Handles btnShowData.Click
        'Figures.Figure()
        'MessageBox.Show("Header Bytes: " & WholeFile(&H10).ToString("X2") + WholeFile(&H11).ToString("X2"))
        'MessageBox.Show("Variant Bytes: " & WholeFile(&H1C).ToString("X2") + WholeFile(&H1D).ToString("X2"))
        lblData.Text = "Head: " & WholeFile(&H10).ToString("X2") + WholeFile(&H11).ToString("X2") & " Variant: " & WholeFile(&H1C).ToString("X2") + WholeFile(&H1D).ToString("X2")
    End Sub



    Private Sub btnClearData_Click(sender As Object, e As EventArgs) Handles btnClearData.Click
        lblData.Text = "Data: "
    End Sub

    Private Sub btnTraps_Click(sender As Object, e As EventArgs) Handles btnTraps.Click
        If cmbGame.SelectedItem <> "Traps" Then
            SaldeStatus.Text = "Please Read a Trap Figure in First."
            Exit Sub
        End If
        Dim frmTraps As New frmTraps
        frmTraps.Show()
        Hide()
    End Sub


    Private Sub btnVehicles_Click(sender As Object, e As EventArgs) Handles btnVehicles.Click
        Dim frmVehicles As New frmVehicles
        Hide()
        frmVehicles.Show()

    End Sub

    Private Sub btnCrystals_Click(sender As Object, e As EventArgs) Handles btnCrystals.Click
        If cmbGame.SelectedItem <> "Imaginators Crystals" Then
            Exit Sub
        End If
        Dim frmCrystals As New frmCrystals
        frmCrystals.Show()
        Hide()
    End Sub

    ReadOnly frmArea As New frmArea
    Private Sub btnArea_Click(sender As Object, e As EventArgs) Handles btnArea.Click
        frmArea.Visible = True
        frmArea.Show()
    End Sub

#Region "Rainbow!"
    Private Sub btnRainbow_Click(sender As Object, e As EventArgs) Handles btnRainbow.Click
        'We do a Rainbow function.  Because Debugging can be fun.
        If Portal.blnPortal = False Then
            Exit Sub
        End If
        If btnRainbow.Text = "Rainbow!" Then
            tmrRainbow.Enabled = True
            btnRainbow.Text = "Stop!"
        Else
            tmrRainbow.Enabled = False
            btnRainbow.Text = "Rainbow!"
        End If
    End Sub
    Shared random As New Random()
    Private Sub tmrRainbow_Tick(sender As Object, e As EventArgs) Handles tmrRainbow.Tick
        random.Next()
        Dim Red As Byte = random.Next(0, 255)
        Dim Blue As Byte = random.Next(0, 255)
        Dim Green As Byte = random.Next(0, 255)
        Portal.Portal_Rainbow(Red, Blue, Green)
    End Sub

    Private Sub btnGame_Click(sender As Object, e As EventArgs) Handles btnGame.Click
        MessageBox.Show(cmbGame.Items.Count)
    End Sub
#End Region

End Class