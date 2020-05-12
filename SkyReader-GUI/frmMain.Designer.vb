<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ofdSky = New System.Windows.Forms.OpenFileDialog()
        Me.lblGame = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.picHeader = New System.Windows.Forms.PictureBox()
        Me.grpChecksums = New System.Windows.Forms.GroupBox()
        Me.picSerial = New System.Windows.Forms.PictureBox()
        Me.lblSerial = New System.Windows.Forms.Label()
        Me.picArea1Type4 = New System.Windows.Forms.PictureBox()
        Me.lblArea2Type4 = New System.Windows.Forms.Label()
        Me.picArea0Type4 = New System.Windows.Forms.PictureBox()
        Me.lblArea1Type4 = New System.Windows.Forms.Label()
        Me.picArea1Type3 = New System.Windows.Forms.PictureBox()
        Me.picArea1Type2 = New System.Windows.Forms.PictureBox()
        Me.lblArea2Type3 = New System.Windows.Forms.Label()
        Me.lblArea2Type2 = New System.Windows.Forms.Label()
        Me.picArea1Type1 = New System.Windows.Forms.PictureBox()
        Me.lblArea2Type1 = New System.Windows.Forms.Label()
        Me.picArea0Type3 = New System.Windows.Forms.PictureBox()
        Me.picArea0Type2 = New System.Windows.Forms.PictureBox()
        Me.lblArea1Type3 = New System.Windows.Forms.Label()
        Me.lblArea1Type2 = New System.Windows.Forms.Label()
        Me.picArea0Type1 = New System.Windows.Forms.PictureBox()
        Me.lblArea1Type1 = New System.Windows.Forms.Label()
        Me.lblGold = New System.Windows.Forms.Label()
        Me.numGold = New System.Windows.Forms.NumericUpDown()
        Me.numHeroicChallenges = New System.Windows.Forms.NumericUpDown()
        Me.lblChallenge = New System.Windows.Forms.Label()
        Me.lblHeroPoints = New System.Windows.Forms.Label()
        Me.numHero = New System.Windows.Forms.NumericUpDown()
        Me.grpSkillPath = New System.Windows.Forms.GroupBox()
        Me.radNone = New System.Windows.Forms.RadioButton()
        Me.radRight = New System.Windows.Forms.RadioButton()
        Me.radLeft = New System.Windows.Forms.RadioButton()
        Me.numLevel = New System.Windows.Forms.NumericUpDown()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.cmbGame = New System.Windows.Forms.ComboBox()
        Me.lstCharacters = New System.Windows.Forms.ListBox()
        Me.lblHat = New System.Windows.Forms.Label()
        Me.cmbHat = New System.Windows.Forms.ComboBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.mnuPurp = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Save_Enc_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Save_Dec_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PortalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadSkylanderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WriteSkylanderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadSwapperOtherHalfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WriteSwapperOtherHalfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnectToPortalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusPurp = New System.Windows.Forms.StatusStrip()
        Me.SaldeStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.bgWritePortal = New System.ComponentModel.BackgroundWorker()
        Me.bgReadPortal = New System.ComponentModel.BackgroundWorker()
        Me.tmrPortal = New System.Windows.Forms.Timer(Me.components)
        Me.btnShowData = New System.Windows.Forms.Button()
        Me.chkSerial = New System.Windows.Forms.CheckBox()
        Me.lblData = New System.Windows.Forms.Label()
        Me.btnClearData = New System.Windows.Forms.Button()
        Me.tmrSkyKey = New System.Windows.Forms.Timer(Me.components)
        Me.lblWebCode_Text = New System.Windows.Forms.Label()
        Me.lblWebCode = New System.Windows.Forms.Label()
        Me.lblSystem = New System.Windows.Forms.Label()
        Me.cmbSystem = New System.Windows.Forms.ComboBox()
        Me.btnTraps = New System.Windows.Forms.Button()
        Me.btnVehicles = New System.Windows.Forms.Button()
        Me.btnRaw = New System.Windows.Forms.Button()
        Me.btnCode = New System.Windows.Forms.Button()
        Me.grpDebug = New System.Windows.Forms.GroupBox()
        CType(Me.picHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpChecksums.SuspendLayout()
        CType(Me.picSerial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picArea1Type4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picArea0Type4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picArea1Type3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picArea1Type2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picArea1Type1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picArea0Type3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picArea0Type2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picArea0Type1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHeroicChallenges, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSkillPath.SuspendLayout()
        CType(Me.numLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuPurp.SuspendLayout()
        Me.StatusPurp.SuspendLayout()
        Me.grpDebug.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofdSky
        '
        Me.ofdSky.Title = "Choose File"
        '
        'lblGame
        '
        Me.lblGame.AutoSize = True
        Me.lblGame.Location = New System.Drawing.Point(16, 36)
        Me.lblGame.Name = "lblGame"
        Me.lblGame.Size = New System.Drawing.Size(35, 13)
        Me.lblGame.TabIndex = 3
        Me.lblGame.Text = "Game"
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Location = New System.Drawing.Point(18, 18)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(42, 13)
        Me.lblHeader.TabIndex = 7
        Me.lblHeader.Text = "Header"
        '
        'picHeader
        '
        Me.picHeader.BackColor = System.Drawing.Color.Yellow
        Me.picHeader.Location = New System.Drawing.Point(28, 34)
        Me.picHeader.Name = "picHeader"
        Me.picHeader.Size = New System.Drawing.Size(22, 24)
        Me.picHeader.TabIndex = 8
        Me.picHeader.TabStop = False
        '
        'grpChecksums
        '
        Me.grpChecksums.BackColor = System.Drawing.SystemColors.Control
        Me.grpChecksums.Controls.Add(Me.picSerial)
        Me.grpChecksums.Controls.Add(Me.lblSerial)
        Me.grpChecksums.Controls.Add(Me.picArea1Type4)
        Me.grpChecksums.Controls.Add(Me.lblArea2Type4)
        Me.grpChecksums.Controls.Add(Me.picArea0Type4)
        Me.grpChecksums.Controls.Add(Me.lblArea1Type4)
        Me.grpChecksums.Controls.Add(Me.picArea1Type3)
        Me.grpChecksums.Controls.Add(Me.picArea1Type2)
        Me.grpChecksums.Controls.Add(Me.lblArea2Type3)
        Me.grpChecksums.Controls.Add(Me.lblArea2Type2)
        Me.grpChecksums.Controls.Add(Me.picArea1Type1)
        Me.grpChecksums.Controls.Add(Me.lblArea2Type1)
        Me.grpChecksums.Controls.Add(Me.picArea0Type3)
        Me.grpChecksums.Controls.Add(Me.picArea0Type2)
        Me.grpChecksums.Controls.Add(Me.lblArea1Type3)
        Me.grpChecksums.Controls.Add(Me.lblArea1Type2)
        Me.grpChecksums.Controls.Add(Me.picArea0Type1)
        Me.grpChecksums.Controls.Add(Me.lblArea1Type1)
        Me.grpChecksums.Controls.Add(Me.picHeader)
        Me.grpChecksums.Controls.Add(Me.lblHeader)
        Me.grpChecksums.Location = New System.Drawing.Point(12, 315)
        Me.grpChecksums.Name = "grpChecksums"
        Me.grpChecksums.Size = New System.Drawing.Size(394, 113)
        Me.grpChecksums.TabIndex = 9
        Me.grpChecksums.TabStop = False
        Me.grpChecksums.Text = "Checksums"
        '
        'picSerial
        '
        Me.picSerial.BackColor = System.Drawing.Color.Yellow
        Me.picSerial.Location = New System.Drawing.Point(28, 78)
        Me.picSerial.Name = "picSerial"
        Me.picSerial.Size = New System.Drawing.Size(22, 24)
        Me.picSerial.TabIndex = 26
        Me.picSerial.TabStop = False
        '
        'lblSerial
        '
        Me.lblSerial.AutoSize = True
        Me.lblSerial.Location = New System.Drawing.Point(23, 62)
        Me.lblSerial.Name = "lblSerial"
        Me.lblSerial.Size = New System.Drawing.Size(33, 13)
        Me.lblSerial.TabIndex = 25
        Me.lblSerial.Text = "Serial"
        '
        'picArea1Type4
        '
        Me.picArea1Type4.BackColor = System.Drawing.Color.Yellow
        Me.picArea1Type4.Location = New System.Drawing.Point(326, 78)
        Me.picArea1Type4.Name = "picArea1Type4"
        Me.picArea1Type4.Size = New System.Drawing.Size(22, 24)
        Me.picArea1Type4.TabIndex = 24
        Me.picArea1Type4.TabStop = False
        '
        'lblArea2Type4
        '
        Me.lblArea2Type4.AutoSize = True
        Me.lblArea2Type4.Location = New System.Drawing.Point(300, 62)
        Me.lblArea2Type4.Name = "lblArea2Type4"
        Me.lblArea2Type4.Size = New System.Drawing.Size(74, 13)
        Me.lblArea2Type4.TabIndex = 23
        Me.lblArea2Type4.Text = "Area 1 Type 4"
        '
        'picArea0Type4
        '
        Me.picArea0Type4.BackColor = System.Drawing.Color.Yellow
        Me.picArea0Type4.Location = New System.Drawing.Point(326, 34)
        Me.picArea0Type4.Name = "picArea0Type4"
        Me.picArea0Type4.Size = New System.Drawing.Size(22, 24)
        Me.picArea0Type4.TabIndex = 22
        Me.picArea0Type4.TabStop = False
        '
        'lblArea1Type4
        '
        Me.lblArea1Type4.AutoSize = True
        Me.lblArea1Type4.Location = New System.Drawing.Point(300, 18)
        Me.lblArea1Type4.Name = "lblArea1Type4"
        Me.lblArea1Type4.Size = New System.Drawing.Size(74, 13)
        Me.lblArea1Type4.TabIndex = 21
        Me.lblArea1Type4.Text = "Area 0 Type 4"
        '
        'picArea1Type3
        '
        Me.picArea1Type3.BackColor = System.Drawing.Color.Yellow
        Me.picArea1Type3.Location = New System.Drawing.Point(247, 78)
        Me.picArea1Type3.Name = "picArea1Type3"
        Me.picArea1Type3.Size = New System.Drawing.Size(22, 24)
        Me.picArea1Type3.TabIndex = 20
        Me.picArea1Type3.TabStop = False
        '
        'picArea1Type2
        '
        Me.picArea1Type2.BackColor = System.Drawing.Color.Yellow
        Me.picArea1Type2.Location = New System.Drawing.Point(167, 78)
        Me.picArea1Type2.Name = "picArea1Type2"
        Me.picArea1Type2.Size = New System.Drawing.Size(22, 24)
        Me.picArea1Type2.TabIndex = 19
        Me.picArea1Type2.TabStop = False
        '
        'lblArea2Type3
        '
        Me.lblArea2Type3.AutoSize = True
        Me.lblArea2Type3.Location = New System.Drawing.Point(221, 62)
        Me.lblArea2Type3.Name = "lblArea2Type3"
        Me.lblArea2Type3.Size = New System.Drawing.Size(74, 13)
        Me.lblArea2Type3.TabIndex = 18
        Me.lblArea2Type3.Text = "Area 1 Type 3"
        '
        'lblArea2Type2
        '
        Me.lblArea2Type2.AutoSize = True
        Me.lblArea2Type2.Location = New System.Drawing.Point(141, 62)
        Me.lblArea2Type2.Name = "lblArea2Type2"
        Me.lblArea2Type2.Size = New System.Drawing.Size(74, 13)
        Me.lblArea2Type2.TabIndex = 17
        Me.lblArea2Type2.Text = "Area 1 Type 2"
        '
        'picArea1Type1
        '
        Me.picArea1Type1.BackColor = System.Drawing.Color.Yellow
        Me.picArea1Type1.Location = New System.Drawing.Point(88, 78)
        Me.picArea1Type1.Name = "picArea1Type1"
        Me.picArea1Type1.Size = New System.Drawing.Size(22, 24)
        Me.picArea1Type1.TabIndex = 16
        Me.picArea1Type1.TabStop = False
        '
        'lblArea2Type1
        '
        Me.lblArea2Type1.AutoSize = True
        Me.lblArea2Type1.Location = New System.Drawing.Point(62, 62)
        Me.lblArea2Type1.Name = "lblArea2Type1"
        Me.lblArea2Type1.Size = New System.Drawing.Size(74, 13)
        Me.lblArea2Type1.TabIndex = 15
        Me.lblArea2Type1.Text = "Area 1 Type 1"
        '
        'picArea0Type3
        '
        Me.picArea0Type3.BackColor = System.Drawing.Color.Yellow
        Me.picArea0Type3.Location = New System.Drawing.Point(247, 34)
        Me.picArea0Type3.Name = "picArea0Type3"
        Me.picArea0Type3.Size = New System.Drawing.Size(22, 24)
        Me.picArea0Type3.TabIndex = 14
        Me.picArea0Type3.TabStop = False
        '
        'picArea0Type2
        '
        Me.picArea0Type2.BackColor = System.Drawing.Color.Yellow
        Me.picArea0Type2.Location = New System.Drawing.Point(167, 34)
        Me.picArea0Type2.Name = "picArea0Type2"
        Me.picArea0Type2.Size = New System.Drawing.Size(22, 24)
        Me.picArea0Type2.TabIndex = 13
        Me.picArea0Type2.TabStop = False
        '
        'lblArea1Type3
        '
        Me.lblArea1Type3.AutoSize = True
        Me.lblArea1Type3.Location = New System.Drawing.Point(221, 18)
        Me.lblArea1Type3.Name = "lblArea1Type3"
        Me.lblArea1Type3.Size = New System.Drawing.Size(74, 13)
        Me.lblArea1Type3.TabIndex = 12
        Me.lblArea1Type3.Text = "Area 0 Type 3"
        '
        'lblArea1Type2
        '
        Me.lblArea1Type2.AutoSize = True
        Me.lblArea1Type2.Location = New System.Drawing.Point(141, 18)
        Me.lblArea1Type2.Name = "lblArea1Type2"
        Me.lblArea1Type2.Size = New System.Drawing.Size(74, 13)
        Me.lblArea1Type2.TabIndex = 11
        Me.lblArea1Type2.Text = "Area 0 Type 2"
        '
        'picArea0Type1
        '
        Me.picArea0Type1.BackColor = System.Drawing.Color.Yellow
        Me.picArea0Type1.Location = New System.Drawing.Point(88, 34)
        Me.picArea0Type1.Name = "picArea0Type1"
        Me.picArea0Type1.Size = New System.Drawing.Size(22, 24)
        Me.picArea0Type1.TabIndex = 10
        Me.picArea0Type1.TabStop = False
        '
        'lblArea1Type1
        '
        Me.lblArea1Type1.AutoSize = True
        Me.lblArea1Type1.Location = New System.Drawing.Point(62, 18)
        Me.lblArea1Type1.Name = "lblArea1Type1"
        Me.lblArea1Type1.Size = New System.Drawing.Size(74, 13)
        Me.lblArea1Type1.TabIndex = 9
        Me.lblArea1Type1.Text = "Area 0 Type 1"
        '
        'lblGold
        '
        Me.lblGold.AutoSize = True
        Me.lblGold.Location = New System.Drawing.Point(30, 105)
        Me.lblGold.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGold.Name = "lblGold"
        Me.lblGold.Size = New System.Drawing.Size(29, 13)
        Me.lblGold.TabIndex = 12
        Me.lblGold.Text = "Gold"
        '
        'numGold
        '
        Me.numGold.Location = New System.Drawing.Point(14, 120)
        Me.numGold.Margin = New System.Windows.Forms.Padding(2)
        Me.numGold.Maximum = New Decimal(New Integer() {65000, 0, 0, 0})
        Me.numGold.Name = "numGold"
        Me.numGold.Size = New System.Drawing.Size(83, 20)
        Me.numGold.TabIndex = 13
        '
        'numHeroicChallenges
        '
        Me.numHeroicChallenges.Location = New System.Drawing.Point(14, 163)
        Me.numHeroicChallenges.Margin = New System.Windows.Forms.Padding(2)
        Me.numHeroicChallenges.Maximum = New Decimal(New Integer() {-1, 0, 0, 0})
        Me.numHeroicChallenges.Name = "numHeroicChallenges"
        Me.numHeroicChallenges.Size = New System.Drawing.Size(83, 20)
        Me.numHeroicChallenges.TabIndex = 16
        '
        'lblChallenge
        '
        Me.lblChallenge.AutoSize = True
        Me.lblChallenge.Location = New System.Drawing.Point(9, 147)
        Me.lblChallenge.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblChallenge.Name = "lblChallenge"
        Me.lblChallenge.Size = New System.Drawing.Size(93, 13)
        Me.lblChallenge.TabIndex = 17
        Me.lblChallenge.Text = "Heroic Challenges"
        '
        'lblHeroPoints
        '
        Me.lblHeroPoints.AutoSize = True
        Me.lblHeroPoints.Location = New System.Drawing.Point(112, 147)
        Me.lblHeroPoints.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblHeroPoints.Name = "lblHeroPoints"
        Me.lblHeroPoints.Size = New System.Drawing.Size(62, 13)
        Me.lblHeroPoints.TabIndex = 19
        Me.lblHeroPoints.Text = "Hero Points"
        '
        'numHero
        '
        Me.numHero.Location = New System.Drawing.Point(101, 163)
        Me.numHero.Margin = New System.Windows.Forms.Padding(2)
        Me.numHero.Name = "numHero"
        Me.numHero.Size = New System.Drawing.Size(90, 20)
        Me.numHero.TabIndex = 20
        '
        'grpSkillPath
        '
        Me.grpSkillPath.Controls.Add(Me.radNone)
        Me.grpSkillPath.Controls.Add(Me.radRight)
        Me.grpSkillPath.Controls.Add(Me.radLeft)
        Me.grpSkillPath.Location = New System.Drawing.Point(14, 190)
        Me.grpSkillPath.Margin = New System.Windows.Forms.Padding(2)
        Me.grpSkillPath.Name = "grpSkillPath"
        Me.grpSkillPath.Padding = New System.Windows.Forms.Padding(2)
        Me.grpSkillPath.Size = New System.Drawing.Size(178, 41)
        Me.grpSkillPath.TabIndex = 21
        Me.grpSkillPath.TabStop = False
        Me.grpSkillPath.Text = "Skill Path"
        '
        'radNone
        '
        Me.radNone.AutoSize = True
        Me.radNone.Location = New System.Drawing.Point(112, 18)
        Me.radNone.Name = "radNone"
        Me.radNone.Size = New System.Drawing.Size(51, 17)
        Me.radNone.TabIndex = 24
        Me.radNone.TabStop = True
        Me.radNone.Text = "None"
        Me.radNone.UseVisualStyleBackColor = True
        '
        'radRight
        '
        Me.radRight.AutoSize = True
        Me.radRight.Location = New System.Drawing.Point(57, 18)
        Me.radRight.Margin = New System.Windows.Forms.Padding(2)
        Me.radRight.Name = "radRight"
        Me.radRight.Size = New System.Drawing.Size(50, 17)
        Me.radRight.TabIndex = 23
        Me.radRight.TabStop = True
        Me.radRight.Text = "Right"
        Me.radRight.UseVisualStyleBackColor = True
        '
        'radLeft
        '
        Me.radLeft.AutoSize = True
        Me.radLeft.Location = New System.Drawing.Point(13, 18)
        Me.radLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.radLeft.Name = "radLeft"
        Me.radLeft.Size = New System.Drawing.Size(43, 17)
        Me.radLeft.TabIndex = 22
        Me.radLeft.TabStop = True
        Me.radLeft.Text = "Left"
        Me.radLeft.UseVisualStyleBackColor = True
        '
        'numLevel
        '
        Me.numLevel.Location = New System.Drawing.Point(101, 120)
        Me.numLevel.Margin = New System.Windows.Forms.Padding(2)
        Me.numLevel.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numLevel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLevel.Name = "numLevel"
        Me.numLevel.Size = New System.Drawing.Size(90, 20)
        Me.numLevel.TabIndex = 25
        Me.numLevel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblLevel
        '
        Me.lblLevel.AutoSize = True
        Me.lblLevel.Location = New System.Drawing.Point(128, 104)
        Me.lblLevel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(33, 13)
        Me.lblLevel.TabIndex = 26
        Me.lblLevel.Text = "Level"
        '
        'cmbGame
        '
        Me.cmbGame.FormattingEnabled = True
        Me.cmbGame.Items.AddRange(New Object() {"Spyro's Adventure", "Giants", "Swap Force", "Trap Team", "SuperChargers", "Imaginators", "Items", "Traps", "Adventure Packs"})
        Me.cmbGame.Location = New System.Drawing.Point(56, 33)
        Me.cmbGame.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbGame.Name = "cmbGame"
        Me.cmbGame.Size = New System.Drawing.Size(135, 21)
        Me.cmbGame.TabIndex = 25
        '
        'lstCharacters
        '
        Me.lstCharacters.FormattingEnabled = True
        Me.lstCharacters.Location = New System.Drawing.Point(203, 36)
        Me.lstCharacters.Margin = New System.Windows.Forms.Padding(2)
        Me.lstCharacters.Name = "lstCharacters"
        Me.lstCharacters.Size = New System.Drawing.Size(202, 277)
        Me.lstCharacters.TabIndex = 27
        '
        'lblHat
        '
        Me.lblHat.AutoSize = True
        Me.lblHat.Location = New System.Drawing.Point(16, 75)
        Me.lblHat.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblHat.Name = "lblHat"
        Me.lblHat.Size = New System.Drawing.Size(24, 13)
        Me.lblHat.TabIndex = 25
        Me.lblHat.Text = "Hat"
        '
        'cmbHat
        '
        Me.cmbHat.FormattingEnabled = True
        Me.cmbHat.Location = New System.Drawing.Point(56, 72)
        Me.cmbHat.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbHat.Name = "cmbHat"
        Me.cmbHat.Size = New System.Drawing.Size(135, 21)
        Me.cmbHat.TabIndex = 28
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(11, 274)
        Me.lblName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(55, 13)
        Me.lblName.TabIndex = 29
        Me.lblName.Text = "Nickname"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(14, 290)
        Me.txtName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtName.MaxLength = 15
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(178, 20)
        Me.txtName.TabIndex = 30
        '
        'mnuPurp
        '
        Me.mnuPurp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.PortalToolStripMenuItem})
        Me.mnuPurp.Location = New System.Drawing.Point(0, 0)
        Me.mnuPurp.Name = "mnuPurp"
        Me.mnuPurp.Size = New System.Drawing.Size(648, 24)
        Me.mnuPurp.TabIndex = 35
        Me.mnuPurp.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.Save_Enc_ToolStripMenuItem, Me.Save_Dec_ToolStripMenuItem, Me.ClearToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'Save_Enc_ToolStripMenuItem
        '
        Me.Save_Enc_ToolStripMenuItem.Name = "Save_Enc_ToolStripMenuItem"
        Me.Save_Enc_ToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.Save_Enc_ToolStripMenuItem.Text = "&Save Encrypted"
        '
        'Save_Dec_ToolStripMenuItem
        '
        Me.Save_Dec_ToolStripMenuItem.Name = "Save_Dec_ToolStripMenuItem"
        Me.Save_Dec_ToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.Save_Dec_ToolStripMenuItem.Text = "Save &Decrypted"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.CloseToolStripMenuItem.Text = "&Close"
        '
        'PortalToolStripMenuItem
        '
        Me.PortalToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReadSkylanderToolStripMenuItem, Me.WriteSkylanderToolStripMenuItem, Me.ReadSwapperOtherHalfToolStripMenuItem, Me.WriteSwapperOtherHalfToolStripMenuItem, Me.ConnectToPortalToolStripMenuItem})
        Me.PortalToolStripMenuItem.Name = "PortalToolStripMenuItem"
        Me.PortalToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.PortalToolStripMenuItem.Text = "Portal"
        '
        'ReadSkylanderToolStripMenuItem
        '
        Me.ReadSkylanderToolStripMenuItem.Enabled = False
        Me.ReadSkylanderToolStripMenuItem.Name = "ReadSkylanderToolStripMenuItem"
        Me.ReadSkylanderToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ReadSkylanderToolStripMenuItem.Text = "Read Skylander from Portal"
        '
        'WriteSkylanderToolStripMenuItem
        '
        Me.WriteSkylanderToolStripMenuItem.Enabled = False
        Me.WriteSkylanderToolStripMenuItem.Name = "WriteSkylanderToolStripMenuItem"
        Me.WriteSkylanderToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.WriteSkylanderToolStripMenuItem.Text = "Write Skylander to Portal"
        '
        'ReadSwapperOtherHalfToolStripMenuItem
        '
        Me.ReadSwapperOtherHalfToolStripMenuItem.Enabled = False
        Me.ReadSwapperOtherHalfToolStripMenuItem.Name = "ReadSwapperOtherHalfToolStripMenuItem"
        Me.ReadSwapperOtherHalfToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ReadSwapperOtherHalfToolStripMenuItem.Text = "Read Swap Force Other Half"
        '
        'WriteSwapperOtherHalfToolStripMenuItem
        '
        Me.WriteSwapperOtherHalfToolStripMenuItem.Enabled = False
        Me.WriteSwapperOtherHalfToolStripMenuItem.Name = "WriteSwapperOtherHalfToolStripMenuItem"
        Me.WriteSwapperOtherHalfToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.WriteSwapperOtherHalfToolStripMenuItem.Text = "Write Swap Force Other Half"
        '
        'ConnectToPortalToolStripMenuItem
        '
        Me.ConnectToPortalToolStripMenuItem.Name = "ConnectToPortalToolStripMenuItem"
        Me.ConnectToPortalToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ConnectToPortalToolStripMenuItem.Text = "Connect to Portal"
        '
        'StatusPurp
        '
        Me.StatusPurp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaldeStatus})
        Me.StatusPurp.Location = New System.Drawing.Point(0, 493)
        Me.StatusPurp.Name = "StatusPurp"
        Me.StatusPurp.Size = New System.Drawing.Size(648, 22)
        Me.StatusPurp.TabIndex = 36
        Me.StatusPurp.Text = "StatusStrip1"
        '
        'SaldeStatus
        '
        Me.SaldeStatus.Name = "SaldeStatus"
        Me.SaldeStatus.Size = New System.Drawing.Size(0, 17)
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(116, 238)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 34)
        Me.btnReset.TabIndex = 37
        Me.btnReset.Text = "Reset Figure"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'bgWritePortal
        '
        Me.bgWritePortal.WorkerReportsProgress = True
        '
        'bgReadPortal
        '
        '
        'tmrPortal
        '
        Me.tmrPortal.Enabled = True
        Me.tmrPortal.Interval = 2500
        '
        'btnShowData
        '
        Me.btnShowData.Location = New System.Drawing.Point(355, 438)
        Me.btnShowData.Name = "btnShowData"
        Me.btnShowData.Size = New System.Drawing.Size(75, 23)
        Me.btnShowData.TabIndex = 38
        Me.btnShowData.Text = "Show Data"
        Me.btnShowData.UseVisualStyleBackColor = True
        '
        'chkSerial
        '
        Me.chkSerial.AutoSize = True
        Me.chkSerial.Location = New System.Drawing.Point(14, 438)
        Me.chkSerial.Name = "chkSerial"
        Me.chkSerial.Size = New System.Drawing.Size(108, 17)
        Me.chkSerial.TabIndex = 39
        Me.chkSerial.Text = "Randomize Serial"
        Me.chkSerial.UseVisualStyleBackColor = True
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Location = New System.Drawing.Point(128, 438)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(33, 13)
        Me.lblData.TabIndex = 43
        Me.lblData.Text = "Data:"
        '
        'btnClearData
        '
        Me.btnClearData.Location = New System.Drawing.Point(355, 467)
        Me.btnClearData.Name = "btnClearData"
        Me.btnClearData.Size = New System.Drawing.Size(75, 23)
        Me.btnClearData.TabIndex = 44
        Me.btnClearData.Text = "Clear Data"
        Me.btnClearData.UseVisualStyleBackColor = True
        '
        'tmrSkyKey
        '
        Me.tmrSkyKey.Interval = 1500
        '
        'lblWebCode_Text
        '
        Me.lblWebCode_Text.AutoSize = True
        Me.lblWebCode_Text.Location = New System.Drawing.Point(16, 238)
        Me.lblWebCode_Text.Name = "lblWebCode_Text"
        Me.lblWebCode_Text.Size = New System.Drawing.Size(55, 13)
        Me.lblWebCode_Text.TabIndex = 54
        Me.lblWebCode_Text.Text = "WebCode"
        '
        'lblWebCode
        '
        Me.lblWebCode.AutoSize = True
        Me.lblWebCode.Location = New System.Drawing.Point(16, 251)
        Me.lblWebCode.Name = "lblWebCode"
        Me.lblWebCode.Size = New System.Drawing.Size(0, 13)
        Me.lblWebCode.TabIndex = 57
        '
        'lblSystem
        '
        Me.lblSystem.AutoSize = True
        Me.lblSystem.Location = New System.Drawing.Point(9, 467)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(41, 13)
        Me.lblSystem.TabIndex = 58
        Me.lblSystem.Text = "System"
        '
        'cmbSystem
        '
        Me.cmbSystem.FormattingEnabled = True
        Me.cmbSystem.Items.AddRange(New Object() {"Wii", "Xbox 360", "PS3", "PC", "3DS", "Wii U", "Xbox One", "PS4", "Tablet"})
        Me.cmbSystem.Location = New System.Drawing.Point(54, 464)
        Me.cmbSystem.Name = "cmbSystem"
        Me.cmbSystem.Size = New System.Drawing.Size(121, 21)
        Me.cmbSystem.TabIndex = 59
        '
        'btnTraps
        '
        Me.btnTraps.Location = New System.Drawing.Point(274, 467)
        Me.btnTraps.Name = "btnTraps"
        Me.btnTraps.Size = New System.Drawing.Size(75, 23)
        Me.btnTraps.TabIndex = 60
        Me.btnTraps.Text = "Traps"
        Me.btnTraps.UseVisualStyleBackColor = True
        '
        'btnVehicles
        '
        Me.btnVehicles.Location = New System.Drawing.Point(274, 438)
        Me.btnVehicles.Name = "btnVehicles"
        Me.btnVehicles.Size = New System.Drawing.Size(75, 23)
        Me.btnVehicles.TabIndex = 61
        Me.btnVehicles.Text = "Vehicles"
        Me.btnVehicles.UseVisualStyleBackColor = True
        '
        'btnRaw
        '
        Me.btnRaw.Location = New System.Drawing.Point(6, 34)
        Me.btnRaw.Name = "btnRaw"
        Me.btnRaw.Size = New System.Drawing.Size(75, 23)
        Me.btnRaw.TabIndex = 62
        Me.btnRaw.Text = "Raw Write"
        Me.btnRaw.UseVisualStyleBackColor = True
        '
        'btnCode
        '
        Me.btnCode.Location = New System.Drawing.Point(6, 63)
        Me.btnCode.Name = "btnCode"
        Me.btnCode.Size = New System.Drawing.Size(75, 23)
        Me.btnCode.TabIndex = 63
        Me.btnCode.Text = "Code"
        Me.btnCode.UseVisualStyleBackColor = True
        '
        'grpDebug
        '
        Me.grpDebug.Controls.Add(Me.btnRaw)
        Me.grpDebug.Controls.Add(Me.btnCode)
        Me.grpDebug.Location = New System.Drawing.Point(436, 36)
        Me.grpDebug.Name = "grpDebug"
        Me.grpDebug.Size = New System.Drawing.Size(200, 454)
        Me.grpDebug.TabIndex = 64
        Me.grpDebug.TabStop = False
        Me.grpDebug.Text = "Debug"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 515)
        Me.Controls.Add(Me.grpDebug)
        Me.Controls.Add(Me.btnVehicles)
        Me.Controls.Add(Me.btnTraps)
        Me.Controls.Add(Me.cmbSystem)
        Me.Controls.Add(Me.lblSystem)
        Me.Controls.Add(Me.lblWebCode)
        Me.Controls.Add(Me.lblWebCode_Text)
        Me.Controls.Add(Me.btnClearData)
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.chkSerial)
        Me.Controls.Add(Me.btnShowData)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.StatusPurp)
        Me.Controls.Add(Me.mnuPurp)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.cmbHat)
        Me.Controls.Add(Me.lblHat)
        Me.Controls.Add(Me.lstCharacters)
        Me.Controls.Add(Me.cmbGame)
        Me.Controls.Add(Me.lblLevel)
        Me.Controls.Add(Me.numLevel)
        Me.Controls.Add(Me.grpSkillPath)
        Me.Controls.Add(Me.numHero)
        Me.Controls.Add(Me.lblHeroPoints)
        Me.Controls.Add(Me.lblChallenge)
        Me.Controls.Add(Me.numHeroicChallenges)
        Me.Controls.Add(Me.numGold)
        Me.Controls.Add(Me.lblGold)
        Me.Controls.Add(Me.grpChecksums)
        Me.Controls.Add(Me.lblGame)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuPurp
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "SkyReader-GUI ALPHA-2"
        CType(Me.picHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpChecksums.ResumeLayout(False)
        Me.grpChecksums.PerformLayout()
        CType(Me.picSerial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picArea1Type4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picArea0Type4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picArea1Type3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picArea1Type2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picArea1Type1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picArea0Type3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picArea0Type2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picArea0Type1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHeroicChallenges, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSkillPath.ResumeLayout(False)
        Me.grpSkillPath.PerformLayout()
        CType(Me.numLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuPurp.ResumeLayout(False)
        Me.mnuPurp.PerformLayout()
        Me.StatusPurp.ResumeLayout(False)
        Me.StatusPurp.PerformLayout()
        Me.grpDebug.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofdSky As OpenFileDialog
    Friend WithEvents lblGame As Label
    Friend WithEvents lblHeader As Label
    Friend WithEvents picHeader As PictureBox
    Friend WithEvents grpChecksums As GroupBox
    Friend WithEvents picArea0Type1 As PictureBox
    Friend WithEvents lblArea1Type1 As Label
    Friend WithEvents lblArea1Type3 As Label
    Friend WithEvents lblArea1Type2 As Label
    Friend WithEvents picArea0Type3 As PictureBox
    Friend WithEvents picArea0Type2 As PictureBox
    Friend WithEvents picArea1Type3 As PictureBox
    Friend WithEvents picArea1Type2 As PictureBox
    Friend WithEvents lblArea2Type3 As Label
    Friend WithEvents lblArea2Type2 As Label
    Friend WithEvents picArea1Type1 As PictureBox
    Friend WithEvents lblArea2Type1 As Label
    Friend WithEvents picArea1Type4 As PictureBox
    Friend WithEvents lblArea2Type4 As Label
    Friend WithEvents picArea0Type4 As PictureBox
    Friend WithEvents lblArea1Type4 As Label
    Friend WithEvents lblGold As Label
    Friend WithEvents numGold As NumericUpDown
    Friend WithEvents numHeroicChallenges As NumericUpDown
    Friend WithEvents lblChallenge As Label
    Friend WithEvents lblHeroPoints As Label
    Friend WithEvents numHero As NumericUpDown
    Friend WithEvents grpSkillPath As GroupBox
    Friend WithEvents radRight As RadioButton
    Friend WithEvents radLeft As RadioButton
    Friend WithEvents numLevel As NumericUpDown
    Friend WithEvents lblLevel As Label
    Friend WithEvents radNone As RadioButton
    Friend WithEvents cmbGame As ComboBox
    Friend WithEvents lstCharacters As ListBox
    Friend WithEvents lblHat As Label
    Friend WithEvents cmbHat As ComboBox
    Friend WithEvents lblName As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents mnuPurp As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Save_Enc_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PortalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReadSkylanderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WriteSkylanderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReadSwapperOtherHalfToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WriteSwapperOtherHalfToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConnectToPortalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusPurp As StatusStrip
    Friend WithEvents SaldeStatus As ToolStripStatusLabel
    Friend WithEvents Save_Dec_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnReset As Button
    Friend WithEvents bgWritePortal As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgReadPortal As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrPortal As Timer
    Friend WithEvents ClearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnShowData As Button
    Friend WithEvents picSerial As PictureBox
    Friend WithEvents lblSerial As Label
    Friend WithEvents chkSerial As CheckBox
    Friend WithEvents lblData As Label
    Friend WithEvents btnClearData As Button
    Friend WithEvents tmrSkyKey As Timer
    Friend WithEvents lblWebCode_Text As Label
    Friend WithEvents lblWebCode As Label
    Friend WithEvents lblSystem As Label
    Friend WithEvents cmbSystem As ComboBox
    Friend WithEvents btnTraps As Button
    Friend WithEvents btnVehicles As Button
	Friend WithEvents btnRaw As Button
	Friend WithEvents btnCode As Button
	Friend WithEvents grpDebug As GroupBox
End Class
