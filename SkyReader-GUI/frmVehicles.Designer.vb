<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVehicles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVehicles))
        Me.cmbDecoration = New System.Windows.Forms.ComboBox()
        Me.lblDecoration = New System.Windows.Forms.Label()
        Me.lblTopper = New System.Windows.Forms.Label()
        Me.cmbTopper = New System.Windows.Forms.ComboBox()
        Me.lblNeon = New System.Windows.Forms.Label()
        Me.cmbNeon = New System.Windows.Forms.ComboBox()
        Me.cmbShout = New System.Windows.Forms.ComboBox()
        Me.lblShout = New System.Windows.Forms.Label()
        Me.lblShield = New System.Windows.Forms.Label()
        Me.numShield = New System.Windows.Forms.NumericUpDown()
        Me.numWeapon = New System.Windows.Forms.NumericUpDown()
        Me.lblWeapon = New System.Windows.Forms.Label()
        Me.lblGearbits = New System.Windows.Forms.Label()
        Me.numGearbits = New System.Windows.Forms.NumericUpDown()
        Me.btnGoBack = New System.Windows.Forms.Button()
        CType(Me.numShield, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numWeapon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGearbits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbDecoration
        '
        Me.cmbDecoration.FormattingEnabled = True
        Me.cmbDecoration.Items.AddRange(New Object() {"(None)", "Darkness", "Cap'N Cluck", "Ancient", "Cartoon", "Eon", "Kaos", "Police", "Construction", "Holiday", "Ghost", "Thermal", "Fire Truck", "Ninja", "Royal", "Robot"})
        Me.cmbDecoration.Location = New System.Drawing.Point(12, 27)
        Me.cmbDecoration.Name = "cmbDecoration"
        Me.cmbDecoration.Size = New System.Drawing.Size(121, 21)
        Me.cmbDecoration.TabIndex = 0
        '
        'lblDecoration
        '
        Me.lblDecoration.AutoSize = True
        Me.lblDecoration.Location = New System.Drawing.Point(43, 11)
        Me.lblDecoration.Name = "lblDecoration"
        Me.lblDecoration.Size = New System.Drawing.Size(59, 13)
        Me.lblDecoration.TabIndex = 1
        Me.lblDecoration.Text = "Decoration"
        '
        'lblTopper
        '
        Me.lblTopper.AutoSize = True
        Me.lblTopper.Location = New System.Drawing.Point(202, 9)
        Me.lblTopper.Name = "lblTopper"
        Me.lblTopper.Size = New System.Drawing.Size(41, 13)
        Me.lblTopper.TabIndex = 3
        Me.lblTopper.Text = "Topper"
        '
        'cmbTopper
        '
        Me.cmbTopper.FormattingEnabled = True
        Me.cmbTopper.Items.AddRange(New Object() {"(None)", "The Darkness", "Lucky Coin", "King-Sized Bucket", "Popcorn", "Chicken Leg", "Pinata", "Bag of Gold", "Chompy", "Balloon", "Ripe Banana", "Beach Ball", "Teddy Hat", "Corn on the Cob", "Dragonfire Cannon", "Eon's Sock", "Eon's Statue", "Kaos Statue", "Spitfire Doll", "Golden Piggy Bank", "Raccoon Tail", "Rasta Hat", "Party Sheep", "Snap Shot Doll", "Space Helmet", "Squeeks Jr.", "Tiki Speaky", "Traffic Cone", "Tree Rex Doll", "Tricorn Hat", "Trigger Happy Doll", "Wash Buckler Doll", "Weathervane", "Eon's Helm", "Pluck", "Siren", "Ghost Topper", "Cartoon Doll", "Kaos Punching Bag", "Cup O' Cocoa", "Hand of Fate", "Like Clockwork", "Empire of Ice", "Pizza", "Yeti Doll", "Kaos Sigil", "Cowboy Hat", "Eyeball Ball", "Asteroid", "Hook Hand", "The Mighty Atom", "Holiday Tree", "Shuriken", "Mechanical Gear", "Royal Crown", "Fire Hydrant"})
        Me.cmbTopper.Location = New System.Drawing.Point(162, 27)
        Me.cmbTopper.Name = "cmbTopper"
        Me.cmbTopper.Size = New System.Drawing.Size(121, 21)
        Me.cmbTopper.TabIndex = 4
        '
        'lblNeon
        '
        Me.lblNeon.AutoSize = True
        Me.lblNeon.Location = New System.Drawing.Point(56, 59)
        Me.lblNeon.Name = "lblNeon"
        Me.lblNeon.Size = New System.Drawing.Size(33, 13)
        Me.lblNeon.TabIndex = 5
        Me.lblNeon.Text = "Neon"
        '
        'cmbNeon
        '
        Me.cmbNeon.FormattingEnabled = True
        Me.cmbNeon.Items.AddRange(New Object() {"(None)", "Darkness", "Eon", "Ancient", "Cap'N Cluck", "Cartoon", "Kaos", "Police", "Construction", "Holiday", "Ghost", "Royal", "Ninja", "Thermal", "Robot", "Fire Truck"})
        Me.cmbNeon.Location = New System.Drawing.Point(12, 75)
        Me.cmbNeon.Name = "cmbNeon"
        Me.cmbNeon.Size = New System.Drawing.Size(121, 21)
        Me.cmbNeon.TabIndex = 6
        '
        'cmbShout
        '
        Me.cmbShout.FormattingEnabled = True
        Me.cmbShout.Items.AddRange(New Object() {"(None)", "Sneer: Cali", "Jeer: Cali", "Cheer: Cali", "Back off Bear", "Breakdown", "Pull Over!", "Evil Eye", "Bird Brain", "The Ultimate Evil!", "Leave Me Alone Lion", "Going Nuclear", "Sneer: Sharpfin", "The Darkness", "Why I Oughta", "Police Siren", "Fire It Up", "Sneer: Buzz", "Call Me!", "Car Trouble", "Sneer: Pomfrey", "Yield!", "Hype Train", "Doggin' After Ya", "Crash and Burn", "Earthquake", "Flat Tire", "Fly Trap", "Sneer: Glumshanks", "Sneer: Hugo", "Sneer: Queen Cumulus", "Ninja Stars", "AAAAAA…", "Jeer: Sharpfin", "Red Means Go Right?", "The Final Countdown", "Rush Hour", "Sneer: Tessa", "Tidal Wave", "Toasty!", "All Spun Up", "Under Construction", "Howlin' Good", "Cheer: Buzz", "Cheer: Pomfrey", "Checkered Flag", "Eon Impersonator", "Cheer: Flynn", "Cheer: Glumshanks", "Wink Wink Nudge Nudge", "Silver Bells", "Cheer: Queen Cumulus", "Cheer: Persephone", "Cheer: Sharpfin", "Cheer: Hugo", ":)", "Cheer: Tessa", "First Place Trophy", "Big Bell", "Rude Chompy", "Your Robot Son", "Cry Baby", "The Gulper", "Sweet Innocence", "Diplomacy", "The Prince of Pontification", "Scandalous!", "Like Clockwork", "Ancient Energy", "Banana Peel", "Bashful Face", "Boo", "Boo Too", "Jeer: Buzz", "Catchy Jingle", "Jeer: Pomfrey", "Laugh It Up", "Cow Crossing", "Cuckoo Cuckoo", "Rude Dolphin", "Jack the Donkey", "Quack!", "Trumpet Trunk", "Blub-Blub", "Jeer: Flynn", "Jeer: Glumshanks", "Indignant Goose", "Ham!", "Horsin' Around", "Jeer: Hugo", "Kissy Face", "Purrfect", "Lockpick Gremlin", "Nature Calls", "Jeer: Queen Cumulus", "Oop Oop Eek", "Tauntalizing", "Soda Pop", "Wow!", "Baa-Aaa!", "Squeaky Toy", "Jeer: Tessa"})
        Me.cmbShout.Location = New System.Drawing.Point(162, 75)
        Me.cmbShout.Name = "cmbShout"
        Me.cmbShout.Size = New System.Drawing.Size(121, 21)
        Me.cmbShout.TabIndex = 7
        '
        'lblShout
        '
        Me.lblShout.AutoSize = True
        Me.lblShout.Location = New System.Drawing.Point(205, 57)
        Me.lblShout.Name = "lblShout"
        Me.lblShout.Size = New System.Drawing.Size(35, 13)
        Me.lblShout.TabIndex = 8
        Me.lblShout.Text = "Shout"
        '
        'lblShield
        '
        Me.lblShield.AutoSize = True
        Me.lblShield.Location = New System.Drawing.Point(40, 113)
        Me.lblShield.Name = "lblShield"
        Me.lblShield.Size = New System.Drawing.Size(65, 13)
        Me.lblShield.TabIndex = 9
        Me.lblShield.Text = "Shield Level"
        '
        'numShield
        '
        Me.numShield.Location = New System.Drawing.Point(12, 129)
        Me.numShield.Maximum = New Decimal(New Integer() {1048575, 0, 0, 0})
        Me.numShield.Name = "numShield"
        Me.numShield.Size = New System.Drawing.Size(121, 20)
        Me.numShield.TabIndex = 10
        '
        'numWeapon
        '
        Me.numWeapon.Location = New System.Drawing.Point(162, 129)
        Me.numWeapon.Maximum = New Decimal(New Integer() {1048575, 0, 0, 0})
        Me.numWeapon.Name = "numWeapon"
        Me.numWeapon.Size = New System.Drawing.Size(121, 20)
        Me.numWeapon.TabIndex = 12
        '
        'lblWeapon
        '
        Me.lblWeapon.AutoSize = True
        Me.lblWeapon.Location = New System.Drawing.Point(184, 113)
        Me.lblWeapon.Name = "lblWeapon"
        Me.lblWeapon.Size = New System.Drawing.Size(77, 13)
        Me.lblWeapon.TabIndex = 11
        Me.lblWeapon.Text = "Weapon Level"
        '
        'lblGearbits
        '
        Me.lblGearbits.AutoSize = True
        Me.lblGearbits.Location = New System.Drawing.Point(49, 161)
        Me.lblGearbits.Name = "lblGearbits"
        Me.lblGearbits.Size = New System.Drawing.Size(46, 13)
        Me.lblGearbits.TabIndex = 13
        Me.lblGearbits.Text = "Gearbits"
        '
        'numGearbits
        '
        Me.numGearbits.Location = New System.Drawing.Point(13, 182)
        Me.numGearbits.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numGearbits.Name = "numGearbits"
        Me.numGearbits.Size = New System.Drawing.Size(120, 20)
        Me.numGearbits.TabIndex = 14
        '
        'btnGoBack
        '
        Me.btnGoBack.Location = New System.Drawing.Point(185, 179)
        Me.btnGoBack.Name = "btnGoBack"
        Me.btnGoBack.Size = New System.Drawing.Size(75, 23)
        Me.btnGoBack.TabIndex = 15
        Me.btnGoBack.Text = "Go Back"
        Me.btnGoBack.UseVisualStyleBackColor = True
        '
        'frmVehicles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 214)
        Me.Controls.Add(Me.btnGoBack)
        Me.Controls.Add(Me.numGearbits)
        Me.Controls.Add(Me.lblGearbits)
        Me.Controls.Add(Me.numWeapon)
        Me.Controls.Add(Me.lblWeapon)
        Me.Controls.Add(Me.numShield)
        Me.Controls.Add(Me.lblShield)
        Me.Controls.Add(Me.lblShout)
        Me.Controls.Add(Me.cmbShout)
        Me.Controls.Add(Me.cmbNeon)
        Me.Controls.Add(Me.lblNeon)
        Me.Controls.Add(Me.cmbTopper)
        Me.Controls.Add(Me.lblTopper)
        Me.Controls.Add(Me.lblDecoration)
        Me.Controls.Add(Me.cmbDecoration)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmVehicles"
        Me.Text = "Vehicles"
        CType(Me.numShield, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numWeapon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGearbits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbDecoration As ComboBox
	Friend WithEvents lblDecoration As Label
	Friend WithEvents lblTopper As Label
	Friend WithEvents cmbTopper As ComboBox
	Friend WithEvents lblNeon As Label
	Friend WithEvents cmbNeon As ComboBox
	Friend WithEvents cmbShout As ComboBox
	Friend WithEvents lblShout As Label
	Friend WithEvents lblShield As Label
	Friend WithEvents numShield As NumericUpDown
	Friend WithEvents numWeapon As NumericUpDown
	Friend WithEvents lblWeapon As Label
	Friend WithEvents lblGearbits As Label
	Friend WithEvents numGearbits As NumericUpDown
	Friend WithEvents btnGoBack As Button
End Class
