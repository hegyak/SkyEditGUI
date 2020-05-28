Imports System.Text
Imports SkyReader_GUI.FigureIO
Imports SkyReader_GUI.frmMain
Public Class frmTraps
	Private Sub cmbVillian1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVillian1.SelectedIndexChanged
		Select Case cmbVillian1.SelectedItem
			Case "Shield Shredder"
				chkVillian1Variant.Enabled = True
				Exit Select
			Case "Brawl and Chain"
				chkVillian1Variant.Enabled = True
				Exit Select
			Case "Shrednaught"
				chkVillian1Variant.Enabled = True
				Exit Select
			Case "Broccoli Guy"
				chkVillian1Variant.Enabled = True
				Exit Select
			Case "Lob Goblin"
				chkVillian1Variant.Enabled = True
				Exit Select
			Case "Tussle Sprout"
				chkVillian1Variant.Enabled = True
				Exit Select
			Case Else
				chkVillian1Variant.Enabled = False
				chkVillian1Variant.Checked = False
				Exit Select
		End Select
	End Sub
	Private Sub frmTraps_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
		Dim result As DialogResult
		result = MessageBox.Show("Do you want to apply any changes made to this figure?", "Apply Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
		If result = DialogResult.Yes Then
			Save()
			'I need a way to load back the Main Form.
			frmMain.Show()
			Dispose()
		Else
			'Go back anyway.
			frmMain.Show()
			Dispose()
		End If
	End Sub
	Sub Save()
		Save_Area_A()
		Save_Area_B()
	End Sub

	Sub Save_Area_A()
		'Write Quanity Trapped
		If cmbVillian1.SelectedItem = "(None)" Then
			WholeFile(&H80) = &H0
			WholeFile(&H81) = &H0
			WholeFile(&H87) = &H0
			WholeFile(&H90) = &H0
			WholeFile(&H91) = &H0
			WholeFile(&H92) = &H0
			WholeFile(&H93) = &H0
			'Wipe out Old Name
			Save_Name(&H94, "")
		Else
			WholeFile(&H81) = Convert.ToByte(numVillianCount.Value)

			'Set Villian 1 ID and Variant
			'Only Villian 1 has Variant
			If chkVillian1Variant.Checked = True Then
				'if 0x80 = 01 and 0x90 is the same as 0x87 then Variant Villain?
				WholeFile(&H80) = &H1
				WholeFile(&H87) = Save_Villian(cmbVillian1.SelectedItem)
				WholeFile(&H90) = Save_Villian(cmbVillian1.SelectedItem)
			Else
				WholeFile(&H80) = &H0
				WholeFile(&H90) = Save_Villian(cmbVillian1.SelectedItem)
			End If

			'Set Villain 1 Evolved
			If chkVillian1Evolved.Checked = True Then
				WholeFile(&H91) = &H1
			Else
				WholeFile(&H91) = &H0
			End If
			'Set Villain 1 Hat
			WholeFile(&H92) = Save_Hat(cmbVillian1Hat.SelectedItem)
			'Set Villian 1 Trinket
			WholeFile(&H93) = Save_Trinket(cmbVillian1Trinket.SelectedItem)
			'Set Villian 1 Nickname (If set)
			If txtVillian1Name.Text <> "" Then
				Save_Name(&H94, txtVillian1Name.Text)
			End If
		End If

		'Set Villian 2 ID
		If cmbVillian2.SelectedItem = "(None)" Then
			WholeFile(&HD0) = &H0
			WholeFile(&HD1) = &H0
			WholeFile(&HD2) = &H0
			WholeFile(&HD3) = &H0
			'Wipe out Old Name
			Save_Name(&HD4, "")
		Else
			WholeFile(&HD0) = Save_Villian(cmbVillian2.SelectedItem)
			If chkVillian2Evolved.Checked = True Then
				WholeFile(&HD1) = 1
			Else
				WholeFile(&HD1) = 0
			End If
			'Set Villian 2 Hat
			WholeFile(&HD2) = Save_Hat(cmbVillian2Hat.SelectedItem)
			'Set Villian 2 Trinket
			WholeFile(&HD3) = Save_Trinket(cmbVillian2Trinket.SelectedItem)
			If txtVillian2Name.Text <> "" Then
				Save_Name(&HD4, txtVillian2Name.Text)
			End If
		End If


		'Set Villian 3 ID
		If cmbVillian3.SelectedItem = "(None)" Then
			WholeFile(&H110) = &H0
			WholeFile(&H111) = &H0
			WholeFile(&H112) = &H0
			WholeFile(&H113) = &H0
			'Wipe out Old Name
			Save_Name(&H114, "")
		Else
			WholeFile(&H110) = Save_Villian(cmbVillian3.SelectedItem)
			If chkVillian3Evolved.Checked = True Then
				WholeFile(&H111) = 1
			Else
				WholeFile(&H111) = 0
			End If
			'Set Villan 3 Hat
			WholeFile(&H112) = Save_Hat(cmbVillian3Hat.SelectedItem)
			'Set Villian 3 Trinket
			WholeFile(&H113) = Save_Trinket(cmbVillian3Trinket.SelectedItem)
			If txtVillian3Name.Text <> "" Then
				Save_Name(&H114, txtVillian3Name.Text)
			End If
		End If


		'Set Villian 4 ID
		If cmbVillian4.SelectedItem = "(None)" Then
			WholeFile(&H150) = &H0
			WholeFile(&H151) = &H0
			WholeFile(&H152) = &H0
			WholeFile(&H153) = &H0
			'Wipe out Old Name
			Save_Name(&H154, "")
		Else
			WholeFile(&H150) = Save_Villian(cmbVillian4.SelectedItem)
			If chkVillian4Evolved.Checked = True Then
				WholeFile(&H151) = 1
			Else
				WholeFile(&H151) = 0
			End If
			'Set Villan 4 Hat
			WholeFile(&H152) = Save_Hat(cmbVillian4Hat.SelectedItem)
			'Set Villian 4 Trinket
			WholeFile(&H153) = Save_Trinket(cmbVillian4Trinket.SelectedItem)
			If txtVillian4Name.Text <> "" Then
				Save_Name(&H154, txtVillian4Name.Text)
			End If
		End If


		'Set Villian 5 ID
		If cmbVillian5.SelectedItem = "(None)" Then
			WholeFile(&H190) = &H0
			WholeFile(&H191) = &H0
			WholeFile(&H192) = &H0
			WholeFile(&H193) = &H0
			'Wipe out Old Name
			Save_Name(&H194, "")
		Else
			WholeFile(&H190) = Save_Villian(cmbVillian5.SelectedItem)
			If chkVillian5Evolved.Checked = True Then
				WholeFile(&H191) = 1
			Else
				WholeFile(&H191) = 0
			End If
			'Set Villan 5 Hat
			WholeFile(&H192) = Save_Hat(cmbVillian5Hat.SelectedItem)
			'Set Villian 5 Trinket
			WholeFile(&H193) = Save_Trinket(cmbVillian5Trinket.SelectedItem)
			If txtVillian5Name.Text <> "" Then
				Save_Name(&H194, txtVillian5Name.Text)
			End If
		End If


		'Set Villian 6 ID
		If cmbVillian6.SelectedItem = "(None)" Then
			WholeFile(&H1D0) = &H0
			WholeFile(&H1D1) = &H0
			WholeFile(&H1D2) = &H0
			WholeFile(&H1D3) = &H0
			'Wipe out Old Name
			Save_Name(&H1D4, "")
		Else
			WholeFile(&H1D0) = Save_Villian(cmbVillian6.SelectedItem)
			If chkVillian6Evolved.Checked = True Then
				WholeFile(&H1D1) = 1
			Else
				WholeFile(&H1D1) = 0
			End If
			'Set Villan 6 Hat
			WholeFile(&H1D2) = Save_Hat(cmbVillian6Hat.SelectedItem)
			'Set Villian 6 Trinket
			WholeFile(&H1D3) = Save_Trinket(cmbVillian6Trinket.SelectedItem)
			If txtVillian6Name.Text <> "" Then
				Save_Name(&H1D4, txtVillian6Name.Text)
			End If
		End If

		'This resolves Area A
	End Sub
	Sub Save_Area_B()
		'Add 1C0 to All Hex Offsets

		If cmbVillian1.SelectedItem = "(None)" Then
			WholeFile(&H240) = &H0
			WholeFile(&H241) = &H0
			WholeFile(&H247) = &H0
			WholeFile(&H250) = &H0
			WholeFile(&H251) = &H0
			WholeFile(&H252) = &H0
			WholeFile(&H253) = &H0
			'Wipe out Old Name
			Save_Name(&H254, "")
		Else
			'Write Quanity Trapped
			WholeFile(&H241) = Convert.ToByte(numVillianCount.Value)
			'Set Villian 1 ID and Variant
			'Only Villian 1 has Variant
			If chkVillian1Variant.Checked = True Then
				'if 0x80 = 01 and 0x90 is the same as 0x87 then Variant Villain?
				WholeFile(&H240) = &H1
				WholeFile(&H247) = Save_Villian(cmbVillian1.SelectedItem)
				WholeFile(&H250) = Save_Villian(cmbVillian1.SelectedItem)
			Else
				WholeFile(&H240) = &H0
				WholeFile(&H250) = Save_Villian(cmbVillian1.SelectedItem)
			End If
			'Set Villain 1 Evolved
			If chkVillian1Evolved.Checked = True Then
				WholeFile(&H251) = &H1
			Else
				WholeFile(&H251) = &H0
			End If
			'Set Villain 1 Hat
			WholeFile(&H252) = Save_Hat(cmbVillian1Hat.SelectedItem)
			'Set Villian 1 Trinket
			WholeFile(&H253) = Save_Trinket(cmbVillian1Trinket.SelectedItem)
			'Set Villian 1 Nickname (If set)
			If txtVillian1Name.Text <> "" Then
				Save_Name(&H254, txtVillian1Name.Text)
			End If

		End If
		'MessageBox.Show("Wrote 1st")
		'Exit Sub

		'Set Villian 2 ID
		If cmbVillian2.SelectedItem = "(None)" Then
			WholeFile(&H290) = &H0
			WholeFile(&H291) = &H0
			WholeFile(&H292) = &H0
			WholeFile(&H293) = &H0
			'Wipe out Old Name
			Save_Name(&H294, "")
		Else
			WholeFile(&H290) = Save_Villian(cmbVillian2.SelectedItem)
			If chkVillian2Evolved.Checked = True Then
				WholeFile(&H291) = 1
			Else
				WholeFile(&H291) = 0
			End If
			'Set Villian 2 Hat
			WholeFile(&H292) = Save_Hat(cmbVillian2Hat.SelectedItem)
			'Set Villian 2 Trinket
			WholeFile(&H293) = Save_Trinket(cmbVillian2Trinket.SelectedItem)
			If txtVillian2Name.Text <> "" Then
				Save_Name(&H294, txtVillian2Name.Text)
			End If

		End If
		'MessageBox.Show("Wrote 1st and 2nd")
		'Exit Sub

		If cmbVillian3.SelectedItem = "(None)" Then
			WholeFile(&H2D0) = &H0
			WholeFile(&H2D1) = &H0
			WholeFile(&H2D2) = &H0
			WholeFile(&H2D3) = &H0
			'Wipe out Old Name
			Save_Name(&H2D4, "")
		Else
			'Set Villian 3 ID
			WholeFile(&H2D0) = Save_Villian(cmbVillian3.SelectedItem)
			If chkVillian3Evolved.Checked = True Then
				WholeFile(&H2D1) = 1
			Else
				WholeFile(&H2D1) = 0
			End If
			'Set Villan 3 Hat
			WholeFile(&H2D2) = Save_Hat(cmbVillian3Hat.SelectedItem)
			'Set Villian 3 Trinket
			WholeFile(&H2D3) = Save_Trinket(cmbVillian3Trinket.SelectedItem)
			If txtVillian3Name.Text <> "" Then
				Save_Name(&H2D4, txtVillian3Name.Text)
			End If
		End If


		'Set Villian 4 ID
		If cmbVillian4.SelectedItem = "(None)" Then
			WholeFile(&H310) = &H0
			WholeFile(&H311) = &H0
			WholeFile(&H312) = &H0
			WholeFile(&H313) = &H0
			'Wipe out Old Name
			Save_Name(&H314, "")
		Else
			WholeFile(&H310) = Save_Villian(cmbVillian4.SelectedItem)
			If chkVillian4Evolved.Checked = True Then
				WholeFile(&H311) = 1
			Else
				WholeFile(&H311) = 0
			End If
			'Set Villan 4 Hat
			WholeFile(&H312) = Save_Hat(cmbVillian4Hat.SelectedItem)
			'Set Villian 4 Trinket
			WholeFile(&H313) = Save_Trinket(cmbVillian4Trinket.SelectedItem)
			If txtVillian4Name.Text <> "" Then
				Save_Name(&H314, txtVillian4Name.Text)
			End If
		End If


		'Set Villian 5 ID
		If cmbVillian5.SelectedItem = "(None)" Then
			WholeFile(&H350) = &H0
			WholeFile(&H351) = &H0
			WholeFile(&H352) = &H0
			WholeFile(&H353) = &H0
			'Wipe out Old Name
			Save_Name(&H354, "")
		Else
			WholeFile(&H350) = Save_Villian(cmbVillian5.SelectedItem)
			If chkVillian5Evolved.Checked = True Then
				WholeFile(&H351) = 1
			Else
				WholeFile(&H351) = 0
			End If
			'Set Villan 5 Hat
			WholeFile(&H352) = Save_Hat(cmbVillian5Hat.SelectedItem)
			'Set Villian 5 Trinket
			WholeFile(&H353) = Save_Trinket(cmbVillian5Trinket.SelectedItem)
			If txtVillian5Name.Text <> "" Then
				Save_Name(&H354, txtVillian5Name.Text)
			End If
		End If


		'Set Villian 6 ID
		If cmbVillian6.SelectedItem = "(None)" Then
			WholeFile(&H390) = &H0
			WholeFile(&H391) = &H0
			WholeFile(&H392) = &H0
			WholeFile(&H393) = &H0
			'Wipe out Old Name
			Save_Name(&H394, "")
		Else
			WholeFile(&H390) = Save_Villian(cmbVillian6.SelectedItem)
			If chkVillian6Evolved.Checked = True Then
				WholeFile(&H391) = 1
			Else
				WholeFile(&H391) = 0
			End If
			'Set Villan 6 Hat
			WholeFile(&H392) = Save_Hat(cmbVillian6Hat.SelectedItem)
			'Set Villian 6 Trinket
			WholeFile(&H393) = Save_Trinket(cmbVillian6Trinket.SelectedItem)
			If txtVillian6Name.Text <> "" Then
				Save_Name(&H394, txtVillian6Name.Text)
			End If
		End If

		'This resolves Area B
	End Sub
	Function Save_Trinket(SelectedTrinket As String)
		Select Case SelectedTrinket
			Case "(None)"
				Return &H0
			Case "T-Bone's Lucky Tie"
				Return &H1
			Case "Batterson's Bubble"
				Return &H2
			Case "Dark Water Daisy"
				Return &H3
			Case "Vote For Cyclops"
				Return &H4
			Case "Ramses' Dragon Horn"
				Return &H5
			Case "Iris' Iris"
				Return &H6
			Case "Kuckoo Kazoo"
				Return &H7
			Case "Ramses' Rune"
				Return &H8
			Case "Ullysses Uniclops"
				Return &H9
			Case "Billy Bison"
				Return &HA
			Case "Stealth Elf's Gift"
				Return &HB
			Case "Lizard Lilly"
				Return &HC
			Case "Pirate Pinwheel"
				Return &HD
			Case "Bubble Blower"
				Return &HE
			Case "Medal of Heroism"
				Return &HF
			Case "Blobber's Medal of Courage"
				Return &H10
			Case "Medal of Valliance"
				Return &H11
			Case "Medal of Gallantry"
				Return &H12
			Case "Medal of Mettle"
				Return &H13
			Case "Winged Medal of Bravery"
				Return &H14
			Case "Seadog Seashell"
				Return &H15
			Case "Snuckles' Sunflower"
				Return &H16
			Case "Teddy Cyclops"
				Return &H17
			Case "Goo Factory Gear"
				Return &H18
			Case "Elemental Opal"
				Return &H19
			Case "Elemental Radiant"
				Return &H1A
			Case "Elemental Diamond"
				Return &H1B
			Case "Cyclops Spinner"
				Return &H1C
			Case "Wiliken Windmill"
				Return &H1D
			Case "Time Town Ticker"
				Return &H1E
			Case "Big Bow of Doom"
				Return &H1F
			Case "Mabu's Medallion"
				Return &H20
			Case "Spyro's Shield"
				Return &H21
			Case Else
				Return &H0
		End Select

	End Function
	Function Save_Villian(SelectedVillian As String)
		'Because I want to Improve
		Select Case SelectedVillian
			Case "(None)"
				Return &H0
			Case "Chompy Mage"
				Return &H1
			Case "Dr. Crankcase"
				Return &H2
			Case "Wolfgang"
				Return &H3
			Case "Chef Pepper Jack"
				Return &H4
			Case "Nightshade"
				Return &H5
			Case "Luminous"
				Return &H6
			Case "Golden Queen"
				Return &H7
			Case "Dreamcatcher"
				Return &H8
			Case "Gulper"
				Return &H9
			Case "Kaos"
				Return &HA
			Case "Cuckoo Clocker"
				Return &HB
			Case "Buzzer Beak"
				Return &HC
			Case "Shield Shredder"
				Return &HD
			Case "Cross Crow"
				Return &HE
			Case "Bone Chompy"
				Return &HF
			Case "Brawl and Chain"
				Return &H10
			Case "Bomb Shell"
				Return &H11
			Case "Masker Mind"
				Return &H12
			Case "Chill Bill"
				Return &H13
			Case "Sheep Creep"
				Return &H14
			Case "Shrednaught"
				Return &H15
			Case "Chomp Chest"
				Return &H16
			Case "Broccoli Guy"
				Return &H17
			Case "Rage Mage"
				Return &H18
			Case "Lob Goblin"
				Return &H19
			Case "Chompy"
				Return &H1A
			Case "Fisticuffs"
				Return &H1B
			Case "Trolling Thunder"
				Return &H1C
			Case "Hood Sickle"
				Return &H1D
			Case "Bruiser Cruiser"
				Return &H1E
			Case "Brawlrus"
				Return &H1F
			Case "Tussle Sprout"
				Return &H20
			Case "Krankenstein"
				Return &H21
			Case "Scrap Shooter"
				Return &H22
			Case "Slobber Trap"
				Return &H23
			Case "Grinnade"
				Return &H24
			Case "Bad Juju"
				Return &H25
			Case "Blaster-Tron"
				Return &H26
			Case "Tae Kwon Crow"
				Return &H27
			Case "Painyata"
				Return &H28
			Case "Smoke Scream"
				Return &H29
			Case "Eye Five"
				Return &H2A
			Case "Grave Clobber"
				Return &H2B
			Case "Threatpack"
				Return &H2C
			Case "Mab Lobs"
				Return &H2D
			Case "Eye Scream"
				Return &H2E
			Case Else
				Return &H0
		End Select
	End Function
	Function Save_Hat(SelectedHat As String)
		Select Case SelectedHat
			Case "Combat Hat"
				Return &H1
			Case "Napoleon Hat"
				Return &H2
			Case "Spy Gear"
				Return &H3
			Case "Miner Hat"
				Return &H4
			Case "General's Hat"
				Return &H5
			Case "Pirate Hat"
				Return &H6
			Case "Propeller Cap"
				Return &H7
			Case "Coonskin Cap"
				Return &H8
			Case "Straw Hat"
				Return &H9
			Case "Fancy Hat"
				Return &HA
			Case "Top Hat"
				Return &HB
			Case "Viking Helmet"
				Return &HC
			Case "Spiked Hat"
				Return &HD
			Case "Anvil Hat"
				Return &HE
			Case "Beret"
				Return &HF
			Case "Birthday Hat"
				Return &H10
			Case "Bone Head"
				Return &H11
			Case "Bowler Hat"
				Return &H12
			Case "Wabbit Ears"
				Return &H13
			Case "Tropical Turban"
				Return &H14
			Case "Chef Hat"
				Return &H15
			Case "Cowboy Hat"
				Return &H16
			Case "Rocker Hair"
				Return &H17
			Case "Royal Crown"
				Return &H18
			Case "Lil Devil"
				Return &H19
			Case "Eye Hat"
				Return &H1A
			Case "Fez"
				Return &H1B
			Case "Crown of Light"
				Return &H1C
			Case "Jester Hat"
				Return &H1D
			Case "Winged Hat"
				Return &H1E
			Case "Moose Hat"
				Return &H1F
			Case "Plunger Head"
				Return &H20
			Case "Pan Hat"
				Return &H21
			Case "Rocket Hat"
				Return &H22
			Case "Santa Hat"
				Return &H23
			Case "Tiki Hat"
				Return &H24
			Case "Trojan Helmet"
				Return &H25
			Case "Unicorn Hat"
				Return &H26
			Case "Wizard Hat"
				Return &H27
			Case "Pumpkin Hat"
				Return &H28
			Case "Pirate Doo Rag"
				Return &H29
			Case "Cossack Hat"
				Return &H2A
			Case "Flower Hat"
				Return &H2B
			Case "Balloon Hat"
				Return &H2C
			Case "Happy Birthday"
				Return &H2D
			Case "Vintage Baseball Cap"
				Return &H2E
			Case "Prototype: Pink Bow"
				Return &H2F
			Case "Bowling Pin Hat"
				Return &H30
			Case "Officer Cap"
				Return &H31
			Case "Firefighter Helmet"
				Return &H32
			Case "Graduation Hat"
				Return &H33
			Case "Lampshade Hat"
				Return &H34
			Case "Mariachi Hat"
				Return &H35
			Case "Prototype: Headdress"
				Return &H36
			Case "Paper Fast Food Hat"
				Return &H37
			Case "Pilgrim Hat"
				Return &H38
			Case "Police Siren Hat"
				Return &H39
			Case "Purple Fedora"
				Return &H3A
			Case "Archer Hat"
				Return &H3B
			Case "Prototype: Dog Turd"
				Return &H3C
			Case "Safari Hat"
				Return &H3D
			Case "Sailor Hat"
				Return &H3E
			Case "Prototype: Wool Hat"
				Return &H3F
			Case "Dancer Hat"
				Return &H40
			Case "Traffic Cone Hat"
				Return &H41
			Case "Turban"
				Return &H42
			Case "Battle Helmet"
				Return &H43
			Case "Bottle Cap Hat"
				Return &H44
			Case "Prototype: Arrow"
				Return &H45
			Case "Carrot Hat"
				Return &H46
			Case "Prototype: Helmet"
				Return &H47
			Case "Elf Hat"
				Return &H48
			Case "Fishing Hat"
				Return &H49
			Case "Future Hat"
				Return &H4A
			Case "Nefertiti Hat"
				Return &H4B
			Case "Prototype: Helmet"
				Return &H4C
			Case "Pants Hat"
				Return &H4D
			Case "Princess Hat"
				Return &H4E
			Case "Toy Solider Hat"
				Return &H4F
			Case "Trucker Hat"
				Return &H50
			Case "Umbrella Hat"
				Return &H51
			Case "Showtime Hat"
				Return &H52
			Case "Caesar Hat"
				Return &H53
			Case "Flower Fairy Hat"
				Return &H54
			Case "Funnel Hat"
				Return &H55
			Case "Scrumshanks Hat"
				Return &H56
			Case "Biter Hat"
				Return &H57
			Case "Atom Hat"
				Return &H58
			Case "Sombrero"
				Return &H59
			Case "Rasta Hat"
				Return &H5A
			Case "Kufi Hat"
				Return &H5B
			Case "Knight Helm"
				Return &H5C
			Case "Dangling Carrot Hat"
				Return &H5D
			Case "Bronze Top Hat"
				Return &H5E
			Case "Silver Top Hat"
				Return &H5F
			Case "Gold Top Hat"
				Return &H60
			Case "Rain Hat"
				Return &H61
			Case "The Outsider"
				Return &H62
			Case "Greeble Hat"
				Return &H63
			Case "Volcano Hat"
				Return &H64
			Case "Boater Hat"
				Return &H65
			Case "Stone Hat"
				Return &H66
			Case "Stovepipe Hat"
				Return &H67
			Case "Boonie Hat"
				Return &H68
			Case "Sawblade Hat"
				Return &H69
			Case "Zombeanie"
				Return &H6A
			Case "Gaucho Hat"
				Return &H6B
			Case "Roundlet"
				Return &H6C
			Case "Capuchon"
				Return &H6D
			Case "Tricorn Hat"
				Return &H6E
			Case "Peacock Hat"
				Return &H6F
			Case "Bearskin Cap"
				Return &H70
			Case "Fishbone Hat"
				Return &H71
			Case "Ski Cap"
				Return &H72
			Case "Crown of Frost"
				Return &H73
			Case "Four Winds Hat"
				Return &H74
			Case "Beacon Hat"
				Return &H75
			Case "Flower Garland"
				Return &H76
			Case "Tree Branch"
				Return &H77
			Case "Aviator's Cap"
				Return &H78
			Case "Asteroid Hat"
				Return &H79
			Case "Crystal Hat"
				Return &H7A
			Case "Creepy Helm"
				Return &H7B
			Case "Fancy Ribbon"
				Return &H7C
			Case "Deely Boppers"
				Return &H7D
			Case "Beanie"
				Return &H7E
			Case "Leprechaun Hat"
				Return &H7F
			Case "Shark Hat"
				Return &H80
			Case "Life Preserver Hat"
				Return &H81
			Case "Glittering Tiara"
				Return &H82
			Case "Great Helm"
				Return &H83
			Case "Space Helmet"
				Return &H84
			Case "UFO Hat"
				Return &H85
			Case "Whirlwind Diadem"
				Return &H86
			Case "Obsidian Helm"
				Return &H87
			Case "Lilypad Hat"
				Return &H88
			Case "Crown of Flames"
				Return &H89
			Case "Runic Headband"
				Return &H8A
			Case "Clockwork Hat"
				Return &H8B
			Case "Cactus Hat"
				Return &H8C
			Case "Skull Helm"
				Return &H8D
			Case "Gloop Hat"
				Return &H8E
			Case "Puma Hat"
				Return &H8F
			Case "Elephant Hat"
				Return &H90
			Case "Tiger Skin Cap"
				Return &H91
			Case "Teeth Top Hat"
				Return &H92
			Case "Turkey Hat"
				Return &H93
			Case "Eyefro"
				Return &H94
			Case "Bacon Bandana"
				Return &H95
			Case "Awesome Hat"
				Return &H96
			Case "Card Shark Hat"
				Return &H97
			Case "Springtime Hat"
				Return &H98
			Case "Jolly Hat"
				Return &H99
			Case "Kickoff Hat"
				Return &H9A
			Case "Beetle Hat"
				Return &H9B
			Case "Brain Hat"
				Return &H9C
			Case "Brainiac Hat"
				Return &H9D
			Case "Bucket Hat"
				Return &H9E
			Case "Desert Crown"
				Return &H9F
			Case "Ceiling Fan Hat"
				Return &HA0
			Case "Imperial Hat"
				Return &HA1
			Case "Clown Classic Hat"
				Return &HA2
			Case "Clown Bowler Hat"
				Return &HA3
			Case "Colander Hat"
				Return &HA4
			Case "Kepi Hat"
				Return &HA5
			Case "Cornucopia Hat"
				Return &HA6
			Case "Cubano Hat"
				Return &HA7
			Case "Cycling Hat"
				Return &HA8
			Case "Daisy Crown"
				Return &HA9
			Case "Dragon Skull"
				Return &HAA
			Case "Outback Hat"
				Return &HAB
			Case "Lil' Elf Hat"
				Return &HAC
			Case "Generalissimo Hat"
				Return &HAD
			Case "Garrison Hat"
				Return &HAE
			Case "Gondolier Hat"
				Return &HAF
			Case "Hunting Hat"
				Return &HB0
			Case "Juicer Hat"
				Return &HB1
			Case "Kokoshnik"
				Return &HB2
			Case "Medic Hat"
				Return &HB3
			Case "Melon Hat"
				Return &HB4
			Case "Mountie Hat"
				Return &HB5
			Case "Nurse Hat"
				Return &HB6
			Case "Palm Hat"
				Return &HB7
			Case "Paperboy Hat"
				Return &HB8
			Case "Parrot Hat"
				Return &HB9
			Case "Old-Time Movie Hat"
				Return &HBA
			Case "Classic Pot Hat"
				Return &HBB
			Case "Radar Hat"
				Return &HBC
			Case "Crazy Light Bulb Hat"
				Return &HBD
			Case "Rubber Glove Hat"
				Return &HBE
			Case "Rugby Hat"
				Return &HBF
			Case "Metal Fin Hat"
				Return &HC0
			Case "Sleuth Hat"
				Return &HC1
			Case "Shower Cap"
				Return &HC2
			Case "Bobby"
				Return &HC3
			Case "Hedgehog Hat"
				Return &HC4
			Case "Steampunk Hat"
				Return &HC5
			Case "Flight Attendant Hat"
				Return &HC6
			Case "Monday Hat"
				Return &HC7
			Case "Sherpa Hat"
				Return &HC8
			Case "Trash Lid"
				Return &HC9
			Case "Turtle Hat"
				Return &HCA
			Case "Extreme Viking Hat"
				Return &HCB
			Case "Scooter Hat"
				Return &HCC
			Case "Volcano Island Hat"
				Return &HCD
			Case "Sychronized Swimming Hat"
				Return &HCE
			Case "William Tell Hat"
				Return &HCF
			Case "Tribal Hat"
				Return &HD0
			Case "Rude Boy Hat"
				Return &HD1
			Case "Pork Pie Hat"
				Return &HD2
			Case "Alarm Clock Hat"
				Return &HD3
			Case "Batter Up Hat"
				Return &HD4
			Case "Horns Be With You Hat"
				Return &HD5
			Case "Croissant Hat"
				Return &HD6
			Case "Weather Vane Hat"
				Return &HD7
			Case "Rainbow Hat"
				Return &HD8
			Case "Eye of Kaos"
				Return &HD9
			Case "Bat Hat"
				Return &HDA
			Case "Light Bulb Hat"
				Return &HDB
			Case "Firefly Jar"
				Return &HDC
			Case "Shadow Ghost Hat"
				Return &HDD
			Case "Lighthouse Beacon Hat"
				Return &HDE
			Case "Tin Foil Hat"
				Return &HDF
			Case "Night Cap"
				Return &HE0
			Case "Storm Hat"
				Return &HE1
			Case "Gold Arkeyan Helm"
				Return &HE2
			Case "Toucan Hat"
				Return &HE3
			Case "Pyramid Hat"
				Return &HE4
			Case "Minature Skylands Hat"
				Return &HE5
			Case "Wizard Hat"
				Return &HE6
			Case "Prototype: blank"
				Return &HE7
			Case "Candy Cane Hat"
				Return &HE8
			Case "Eggshell Hat"
				Return &HE9
			Case "Candle Hat"
				Return &HEA
			Case "Dark Helm"
				Return &HEB
			Case "Planet Hat"
				Return &HEC
			Case "Bellhop Hat"
				Return &HED
			Case "Bronze Arkeyan Helm"
				Return &HEE
			Case "Silver Arkeyan Helm"
				Return &HEF
			Case "Raver Hat"
				Return &HF0
			Case "Shire Hat"
				Return &HF1
			Case "Mongol Hat"
				Return &HF2
			Case "Skipper Hat"
				Return &HF3
			Case "Medieval Bard Hat"
				Return &HF4
			Case "Wooden Hat"
				Return &HF5
			Case "Carnival Hat"
				Return &HF6
			Case "Coconut Hat"
				Return &HF7
			Case "Model Home Hat"
				Return &HF8
			Case "Ice Cream Hat"
				Return &HF9
			Case "Molekin Mountain Hat"
				Return &HFA
			Case "Sheepwrecked Hat"
				Return &HFB
			Case "Core of Light Hat"
				Return &HFC
			Case "Octavius Cloptimus Hat"
				Return &HFD
			Case "Prototype: blank"
				Return &HFE
			Case "Prototype: blank"
				Return &HFF
			Case Else
				Return &H0
		End Select
	End Function

	Private Sub frmTraps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Application.DoEvents()
		If Area0 > Area1 Then
			Load_Area_0()
		ElseIf Area1 > Area0 Then
			Load_Area_1()
		ElseIf Area0 = Area1 Then
			Load_Area_0()
		End If
		'MessageBox.Show(Area0)
		'MessageBox.Show(Area1)
	End Sub
	Sub Load_Area_0()
		'This only gets applied to the first villian
		'Special Villan Variables are at the 0x80 Block
		numVillianCount.Value = WholeFile(&H81)
		If WholeFile(&H80) = &H1 And WholeFile(&H87) = WholeFile(&H90) Then
			chkVillian1Variant.Checked = True
		End If

		'Villain One Data is 0x90 to 0xC1
		'Ignore 0xB0 Block as it's MiFare
		Dim Villian1_ID As Byte = WholeFile(&H90)
		cmbVillian1.SelectedItem = Load_Villian(Villian1_ID)
		If WholeFile(&H91) = &H1 Then
			chkVillian1Evolved.Checked = True
		End If
		Dim Villian1_Hat As Byte = WholeFile(&H92)
		cmbVillian1Hat.SelectedItem = Load_Hat(Villian1_Hat)
		Dim Villian1_Trinket As Byte = WholeFile(&H93)
		cmbVillian1Trinket.SelectedItem = Load_Trinket(Villian1_Trinket)
		'Load Name from Offset 0x94
		txtVillian1Name.Text = Load_Name(&H94)

		'+&H40
		'Villian Two Data is 0xD00 to 0x111
		'Ignore 0xF00 Block as it's MiFare
		Dim Villian2_ID As Byte = WholeFile(&HD0)
		cmbVillian2.SelectedItem = Load_Villian(Villian2_ID)
		If WholeFile(&HD1) = &H1 Then
			chkVillian2Evolved.Checked = True
		End If
		Dim Villian2_Hat As Byte = WholeFile(&HD2)
		cmbVillian2Hat.SelectedItem = Load_Hat(Villian2_Hat)
		Dim Villian2_Trinket As Byte = WholeFile(&HD3)
		cmbVillian2Trinket.SelectedItem = Load_Trinket(Villian2_Trinket)
		'Load Name from Byte 0xD4
		txtVillian2Name.Text = Load_Name(&HD4)

		'+&H40
		'Villian Three Data is 0x110 to 0x141
		'Ignore 0X130 Block as it's MiFare
		Dim Villian3_ID As Byte = WholeFile(&H110)
		cmbVillian3.SelectedItem = Load_Villian(Villian3_ID)
		If WholeFile(&H111) = &H1 Then
			chkVillian3Evolved.Checked = True
		End If
		Dim Villian3_Hat As Byte = WholeFile(&H112)
		cmbVillian3Hat.SelectedItem = Load_Hat(Villian3_Hat)
		Dim Villian3_Trinket As Byte = WholeFile(&H113)
		cmbVillian3Trinket.SelectedItem = Load_Trinket(Villian3_Trinket)
		'Load Name from Byte 0x114
		txtVillian3Name.Text = Load_Name(&H114)

		'+&H40
		'Villian Four Data is 0x150 to 0x181
		'Ignore 0x170 Block as it's MiFare
		Dim Villian4_ID As Byte = WholeFile(&H150)
		cmbVillian4.SelectedItem = Load_Villian(Villian4_ID)
		If WholeFile(&H151) = &H1 Then
			chkVillian4Evolved.Checked = True
		End If
		Dim Villian4_Hat As Byte = WholeFile(&H152)
		cmbVillian4Hat.SelectedItem = Load_Hat(Villian4_Hat)
		Dim Villian4_Trinket As Byte = WholeFile(&H153)
		cmbVillian4Trinket.SelectedItem = Load_Trinket(Villian4_Trinket)
		'Load Name from Byte 0x154
		txtVillian4Name.Text = Load_Name(&H154)

		'+&H40
		'Villian Five Data is 0x190 to 0x1C1
		'Ignore 0x1B0 Block as it's MiFare
		Dim Villian5_ID As Byte = WholeFile(&H190)
		cmbVillian5.SelectedItem = Load_Villian(Villian5_ID)
		If WholeFile(&H191) = &H1 Then
			chkVillian5Evolved.Checked = True
		End If
		Dim Villian5_Hat As Byte = WholeFile(&H192)
		cmbVillian5Hat.SelectedItem = Load_Hat(Villian5_Hat)
		Dim Villian5_Trinket As Byte = WholeFile(&H193)
		cmbVillian5Trinket.SelectedItem = Load_Trinket(Villian5_Trinket)
		'Load Name from Byte 0x194
		txtVillian5Name.Text = Load_Name(&H194)

		'+&H40
		'Villian Six Data is 0x1D0 to 0x201
		'Ignore 0x200 Block as it's MiFare
		Dim Villian6_ID As Byte = WholeFile(&H1D0)
		cmbVillian6.SelectedItem = Load_Villian(Villian6_ID)
		If WholeFile(&H1D1) = &H1 Then
			chkVillian6Evolved.Checked = True
		End If
		Dim Villian6_Hat As Byte = WholeFile(&H1D2)
		cmbVillian6Hat.SelectedItem = Load_Hat(Villian6_Hat)
		Dim Villian6_Trinket As Byte = WholeFile(&H1D3)
		cmbVillian6Trinket.SelectedItem = Load_Trinket(Villian6_Trinket)

		'Load Name from Byte 0x1D4
		txtVillian6Name.Text = Load_Name(&H1D4)
	End Sub
	Sub Load_Area_1()
		'Add 1C0
		'This only gets applied to the first villian
		'Special Villan Variables are at the 0x240 Block
		numVillianCount.Value = WholeFile(&H241)
		If WholeFile(&H240) = &H1 And WholeFile(&H247) = WholeFile(&H240) Then
			chkVillian1Variant.Checked = True
		End If

		'Villain One Data is 0x250 to 0x281
		'Ignore 0x270 Block as it's MiFare
		Dim Villian1_ID As Byte = WholeFile(&H250)
		cmbVillian1.SelectedItem = Load_Villian(Villian1_ID)
		If WholeFile(&H251) = &H1 Then
			chkVillian1Evolved.Checked = True
		End If
		Dim Villian1_Hat As Byte = WholeFile(&H252)
		cmbVillian1Hat.SelectedItem = Load_Hat(Villian1_Hat)
		Dim Villian1_Trinket As Byte = WholeFile(&H253)
		cmbVillian1Trinket.SelectedItem = Load_Hat(Villian1_Trinket)
		'Load Name from Byte 0x254
		txtVillian1Name.Text = Load_Name(&H254)

		'+&H40
		'Villian Two Data is 0x290 to 0x2C1
		'Ignore 0x2B0 Block as it's MiFare
		Dim Villian2_ID As Byte = WholeFile(&H290)
		cmbVillian2.SelectedItem = Load_Villian(Villian2_ID)
		If WholeFile(&H291) = &H1 Then
			chkVillian2Evolved.Checked = True
		End If
		Dim Villian2_Hat As Byte = WholeFile(&H292)
		cmbVillian2Hat.SelectedItem = Load_Hat(Villian2_Hat)
		Dim Villian2_Trinket As Byte = WholeFile(&H293)
		cmbVillian2Trinket.SelectedItem = Load_Hat(Villian2_Trinket)
		'Load Name from Byte 0x294
		txtVillian2Name.Text = Load_Name(&H294)

		'+&H40
		'Villian Three Data is 0x2D0 to 0x301
		'Ignore 0X2F0 Block as it's MiFare
		Dim Villian3_ID As Byte = WholeFile(&H2D0)
		cmbVillian3.SelectedItem = Load_Villian(Villian3_ID)
		If WholeFile(&H2D1) = &H1 Then
			chkVillian3Evolved.Checked = True
		End If
		Dim Villian3_Hat As Byte = WholeFile(&H2D2)
		cmbVillian3Hat.SelectedItem = Load_Hat(Villian3_Hat)
		Dim Villian3_Trinket As Byte = WholeFile(&H2D3)
		cmbVillian3Trinket.SelectedItem = Load_Hat(Villian3_Trinket)
		'Load Name from Byte 0x2D4
		txtVillian3Name.Text = Load_Name(&H2D4)

		'+&H40
		'Villian Four Data is 0x310 to 0x341
		'Ignore 0x330 Block as it's MiFare
		Dim Villian4_ID As Byte = WholeFile(&H310)
		cmbVillian4.SelectedItem = Load_Villian(Villian4_ID)
		If WholeFile(&H311) = &H1 Then
			chkVillian4Evolved.Checked = True
		End If
		Dim Villian4_Hat As Byte = WholeFile(&H312)
		cmbVillian4Hat.SelectedItem = Load_Hat(Villian4_Hat)
		Dim Villian4_Trinket As Byte = WholeFile(&H313)
		cmbVillian4Trinket.SelectedItem = Load_Hat(Villian4_Trinket)
		'Load Name from Byte 0x314
		txtVillian4Name.Text = Load_Name(&H314)

		'+&H40
		'Villian Five Data is 0x350 to 0x381
		'Ignore 0x370 Block as it's MiFare
		Dim Villian5_ID As Byte = WholeFile(&H350)
		cmbVillian5.SelectedItem = Load_Villian(Villian5_ID)
		If WholeFile(&H351) = &H1 Then
			chkVillian5Evolved.Checked = True
		End If
		Dim Villian5_Hat As Byte = WholeFile(&H352)
		cmbVillian5Hat.SelectedItem = Load_Hat(Villian5_Hat)
		Dim Villian5_Trinket As Byte = WholeFile(&H353)
		cmbVillian5Trinket.SelectedItem = Load_Hat(Villian5_Trinket)
		'Load Name from Byte 0x354
		txtVillian5Name.Text = Load_Name(&H354)

		'+&H40
		'Villian Six Data is 0x390 to 0x3C1
		'Ignore 0x3B0 Block as it's MiFare
		Dim Villian6_ID As Byte = WholeFile(&H390)
		cmbVillian6.SelectedItem = Load_Villian(Villian6_ID)
		If WholeFile(&H391) = &H1 Then
			chkVillian6Evolved.Checked = True
		End If
		Dim Villian6_Hat As Byte = WholeFile(&H392)
		cmbVillian6Hat.SelectedItem = Load_Hat(Villian6_Hat)
		Dim Villian6_Trinket As Byte = WholeFile(&H393)
		cmbVillian6Trinket.SelectedItem = Load_Hat(Villian6_Trinket)
		'Load Name from Byte 0x394
		txtVillian6Name.Text = Load_Name(&H394)
	End Sub


	Function Load_Villian(VillianID As Byte)
		Select Case VillianID
			Case &H0
				Return "(None)"
				Exit Select
			Case &H1
				Return "Chompy Mage"
				Exit Select
			Case &H2
				Return "Dr. Crankcase"
				Exit Select
			Case &H3
				Return "Wolfgang"
				Exit Select
			Case &H4
				Return "Chef Pepper Jack"
				Exit Select
			Case &H5
				Return "Nightshade"
				Exit Select
			Case &H6
				Return "Luminous"
				Exit Select
			Case &H7
				Return "Golden Queen"
				Exit Select
			Case &H8
				Return "Dreamcatcher"
				Exit Select
			Case &H9
				Return "Gulper"
				Exit Select
			Case &HA
				Return "Kaos"
				Exit Select
			Case &HB
				Return "Cuckoo Clocker"
				Exit Select
			Case &HC
				Return "Buzzer Beak"
				Exit Select
			Case &HD
				Return "Shield Shredder"
				Exit Select
			Case &HE
				Return "Cross Crow"
				Exit Select
			Case &HF
				Return "Bone Chompy"
				Exit Select
			Case &H10
				Return "Brawl and Chain"
				Exit Select
			Case &H11
				Return "Bomb Shell"
				Exit Select
			Case &H12
				Return "Masker Mind"
				Exit Select
			Case &H13
				Return "Chill Bill"
				Exit Select
			Case &H14
				Return "Sheep Creep"
				Exit Select
			Case &H15
				Return "Shrednaught"
				Exit Select
			Case &H16
				Return "Chomp Chest"
				Exit Select
			Case &H17
				Return "Broccoli Guy"
				Exit Select
			Case &H18
				Return "Rage Mage"
				Exit Select
			Case &H19
				Return "Lob Goblin"
				Exit Select
			Case &H1A
				Return "Chompy"
				Exit Select
			Case &H1B
				Return "Fisticuffs"
				Exit Select
			Case &H1C
				Return "Trolling Thunder"
				Exit Select
			Case &H1D
				Return "Hood Sickle"
				Exit Select
			Case &H1E
				Return "Bruiser Cruiser"
				Exit Select
			Case &H1F
				Return "Brawlrus"
				Exit Select
			Case &H20
				Return "Tussle Sprout"
				Exit Select
			Case &H21
				Return "Krankenstein"
				Exit Select
			Case &H22
				Return "Scrap Shooter"
				Exit Select
			Case &H23
				Return "Slobber Trap"
				Exit Select
			Case &H24
				Return "Grinnade"
				Exit Select
			Case &H25
				Return "Bad Juju"
				Exit Select
			Case &H26
				Return "Blaster-Tron"
				Exit Select
			Case &H27
				Return "Tae Kwon Crow"
				Exit Select
			Case &H28
				Return "Painyata"
				Exit Select
			Case &H29
				Return "Smoke Scream"
				Exit Select
			Case &H2A
				Return "Eye Five"
				Exit Select
			Case &H2B
				Return "Grave Clobber"
				Exit Select
			Case &H2C
				Return "Threatpack"
				Exit Select
			Case &H2D
				Return "Mab Lobs"
				Exit Select
			Case &H2E
				Return "Eye Scream"
				Exit Select
			Case Else
				Return "(None)"
		End Select
	End Function
	Function Load_Hat(HatID As Byte)
		Select Case HatID
			Case &H0
				Return "(None)"
			Case &HD3
				Return "Alarm Clock Hat"
			Case &HDA
				Return "Bat Hat"
			Case &HD4
				Return "Batter Up Hat"
			Case &H9B
				Return "Beetle Hat"
			Case &HED
				Return "Bellhop Hat"
			Case &HC3
				Return "Bobby"
			Case &H9C
				Return "Brain Hat"
			Case &H9D
				Return "Brainiac Hat"
			Case &HEE
				Return "Bronze Arkeyan Helm"
			Case &H9E
				Return "Bucket Hat"
			Case &HEA
				Return "Candle Hat"
			Case &HE8
				Return "Candy Cane Hat"
			Case &HF6
				Return "Carnival Hat"
			Case &HA0
				Return "Ceiling Fan Hat"
			Case &HBB
				Return "Classic Pot Hat"
			Case &HA3
				Return "Clown Bowler Hat"
			Case &HA2
				Return "Clown Classic Hat"
			Case &HF7
				Return "Coconut Hat"
			Case &HA4
				Return "Colander Hat"
			Case &HFC
				Return "Core Of Light Hat"
			Case &HA6
				Return "Cornucopia Hat"
			Case &HBD
				Return "Crazy Light Bulb Hat"
			Case &HD6
				Return "Croissant Hat"
			Case &HA7
				Return "Cubano Hat"
			Case &HA8
				Return "Cycling Hat"
			Case &HA9
				Return "Daisy Crown"
			Case &HEB
				Return "Dark Helm"
			Case &H9F
				Return "Desert Crown"
			Case &HAA
				Return "Dragon Skull"
			Case &HE9
				Return "Eggshell Hat"
			Case &HCB
				Return "Extreme Viking Hat"
			Case &HD9
				Return "Eye of Kaos Hat"
			Case &HDC
				Return "Firefly Jar"
			Case &HC6
				Return "Flight Attendant Hat"
			Case &HAE
				Return "Garrison Hat"
			Case &HAD
				Return "Generalissimo Hat"
			Case &HE2
				Return "Gold Arkeyan Helm"
			Case &HAF
				Return "Gondolier Hat"
			Case &HC4
				Return "Hedgehog Hat"
			Case &HD5
				Return "Horns Be With You Hat"
			Case &HB0
				Return "Hunting Hat"
			Case &HA1
				Return "Imperial Hat"
			Case &HB1
				Return "Juicer Hat"
			Case &HA5
				Return "Kepi Hat"
			Case &HB2
				Return "Kokoshnik"
			Case &HDB
				Return "Light Bulb Hat"
			Case &HDE
				Return "Lighthouse Beacon Hat"
			Case &HAC
				Return "Lil' Elf Hat"
			Case &HB3
				Return "Medic Hat"
			Case &HB4
				Return "Melon Hat"
			Case &HC0
				Return "Metal Fin Hat"
			Case &HE5
				Return "Miniature Skylands Hat"
			Case &HFA
				Return "Molekin Mountain Hat"
			Case &HC7
				Return "Monday Hat"
			Case &HB5
				Return "Mountie Hat"
			Case &HE0
				Return "Night Cap"
			Case &HB6
				Return "Nurse Hat"
			Case &HFD
				Return "Octavius Cloptimus Hat"
			Case &HBA
				Return "Old-Time Movie Hat"
			Case &HAB
				Return "Outback Hat"
			Case &HB7
				Return "Palm Hat"
			Case &HB8
				Return "Paperboy Hat"
			Case &HB9
				Return "Parrot Nest"
			Case &HEC
				Return "Planet Hat"
			Case &HD2
				Return "Pork Pie Hat"
			Case &HE4
				Return "Pyramid Hat"
			Case &HBC
				Return "Radar Hat"
			Case &HD8
				Return "Rainbow Hat"
			Case &HBE
				Return "Rubber Glove Hat"
			Case &HD1
				Return "Rude Boy Hat"
			Case &HBF
				Return "Rugby Hat"
			Case &HCC
				Return "Scooter Hat"
			Case &HDD
				Return "Shadow Ghost Hat"
			Case &HC8
				Return "Sherpa Hat"
			Case &HC2
				Return "Shower Cap"
			Case &HEF
				Return "Silver Arkeyan Helm"
			Case &HF3
				Return "Skipper Hat"
			Case &HC1
				Return "Sleuth Hat"
			Case &HC5
				Return "Steampunk Hat"
			Case &HE1
				Return "Storm Hat"
			Case &HCE
				Return "Synchronized Swimming Cap"
			Case &HDF
				Return "Tin Foil Hat"
			Case &HE3
				Return "Toucan Hat"
			Case &HC9
				Return "Trash Lid"
			Case &HD0
				Return "Tribal Hat"
			Case &HCA
				Return "Turtle Hat"
			Case &HCD
				Return "Volcano Island Hat"
			Case &HD7
				Return "Weather Vane Hat"
			Case &HCF
				Return "William Tell Hat"
			Case Else
				Return "(None)"
		End Select
	End Function
	Function Load_Trinket(TrinketID As Byte)
		Select Case TrinketID
			Case &H0
				Return "(None)"
				Exit Select
			Case &H1
				Return "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				Return "Batterson's Bubble"
				Exit Select
			Case &H3
				Return "Dark Water Daisy"
				Exit Select
			Case &H4
				Return "Vote For Cyclops"
				Exit Select
			Case &H5
				Return "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				Return "Iris' Iris"
				Exit Select
			Case &H7
				Return "Kuckoo Kazoo"
				Exit Select
			Case &H8
				Return "Ramses' Rune"
				Exit Select
			Case &H9
				Return "Ullysses Uniclops"
				Exit Select
			Case &HA
				Return "Billy Bison"
				Exit Select
			Case &HB
				Return "Stealth Elf's Gift"
				Exit Select
			Case &HC
				Return "Lizard Lilly"
				Exit Select
			Case &HD
				Return "Pirate Pinwheel"
				Exit Select
			Case &HE
				Return "Bubble Blower"
				Exit Select
			Case &HF
				Return "Medal of Heroism"
				Exit Select
			Case &H10
				Return "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				Return "Medal of Valliance"
				Exit Select
			Case &H12
				Return "Medal of Gallantry"
				Exit Select
			Case &H13
				Return "Medal of Mettle"
				Exit Select
			Case &H14
				Return "Winged Medal of Bravery"
				Exit Select
			Case &H15
				Return "Seadog Seashell"
				Exit Select
			Case &H16
				Return "Snuckles' Sunflower"
				Exit Select
			Case &H17
				Return "Teddy Cyclops"
				Exit Select
			Case &H18
				Return "Goo Factory Gear"
				Exit Select
			Case &H19
				Return "Elemental Opal"
				Exit Select
			Case &H1A
				Return "Elemental Radiant"
				Exit Select
			Case &H1B
				Return "Elemental Diamond"
				Exit Select
			Case &H1C
				Return "Cyclops Spinner"
				Exit Select
			Case &H1D
				Return "Wiliken Windmill"
				Exit Select
			Case &H1E
				Return "Time Town Ticker"
				Exit Select
			Case &H1F
				Return "Big Bow of Doom"
				Exit Select
			Case &H20
				Return "Mabu's Medallion"
				Exit Select
			Case &H21
				Return "Spyro's Shield"
				Exit Select
			Case Else
				Return "(None)"
				Exit Select
		End Select
	End Function

	'Special Encryption Checking is Done for Traps, here
	Function Load_Name(offset As Integer)
		Dim NameBytes(29) As Byte
		Dim Adder As Integer = 0
		Dim Full_Name As String
		Do Until Adder = 28
			'MessageBox.Show(Hex(offset))
			NameBytes(Adder) = WholeFile(offset)
			offset += 1
			Adder += 1
		Loop
		'Skip MiFare Block
		offset += 17
		Do Until Adder = 30
			'MessageBox.Show(Hex(offset))
			NameBytes(Adder) = WholeFile(offset)
			offset = offset + 1
			Adder += 1
		Loop
		Full_Name = Encoding.Unicode.GetString(NameBytes)
		Return Encoding.Unicode.GetString(NameBytes)
	End Function

	Sub Save_Name(Offset As Integer, Villian_Name As String)
		'We Define Offset as an integer because it doesn't handle Hex Values and the array can stil be refrenced fully through Integer Values
		'Blank Array
		Dim Full_VilianName(29) As Byte
		Full_VilianName = Encoding.Unicode.GetBytes(Villian_Name)
		'We ReDim the array because it gets Shortened if the name is not using all characters (15).
		'Yes, it's 29 because Unicode uses Two Bytes.
		ReDim Preserve Full_VilianName(29)
		Dim adder As Integer = 0
		Try
			Do Until adder = 28
				WholeFile(Offset) = Full_VilianName(adder)
				Offset = Offset + 1
				adder += 1
			Loop
			'Skip MiFare Block
			Offset += 17
			Do Until adder = 30
				WholeFile(Offset) = Full_VilianName(adder)
				Offset = Offset + 1
				adder += 1
			Loop
		Catch ex As Exception
			MessageBox.Show("EX: " & ex.ToString)
			MessageBox.Show("WholeFile Offset: " & Offset & " WholeFile Length: " & WholeFile.Length)
			MessageBox.Show("FullVillanName Length: " & Full_VilianName.Length)
		End Try

	End Sub

	'if 0x80 = 01 and 0x90 is the same as 0x87 then Variant Villain?
	'idx	name	            variant

	'01     Chompy Mage	
	'02     Dr. Crankcase	
	'03     Wolfgang	
	'04     Chef Pepper Jack	
	'05     Nightshade	
	'06     Luminous	
	'07     Golden Queen	
	'08     Dreamcatcher	
	'09     Gulper	
	'0A 	Kaos
	'0B	    Cuckoo Clocker	
	'0C	    Buzzer Beak	
	'0D	    Shield Shredder     Riot
	'0E	    Cross Crow	
	'0F	    Bone Chompy	
	'10     Brawl and Chain     Outlaw
	'11     Bomb Shell	
	'12     Masker Mind	
	'13     Chill Bill	
	'14     Sheep Creep	
	'15     Shrednaught         Steampunk
	'16     Chomp Chest	
	'17     Broccoli Guy        Steamed
	'18     Rage Mage	
	'19     Lob Goblin          Rebel
	'1A	    Chompy	
	'1B	    Fisticuffs	
	'1C	    Trolling Thunder	
	'1D	    Hood Sickle	
	'1E	    Bruiser Cruiser	
	'1F	    Brawlrus	
	'20     Tussle Sprout	    Red Hot
	'21     Krankenstein	
	'22     Scrap Shooter	
	'23     Slobber Trap	
	'24     Grinnade	
	'25     Bad Juju	
	'26     Blaster-Tron	
	'27     Tae Kwon Crow	
	'28     Painyata	
	'29     Smoke Scream	
	'2A     Eye Five	
	'2B     Grave Clobber	
	'2C     Threatpack	
	'2D     Mab Lobs	
	'2E     Eye Scream	


	'Hex Offsets:
	'Mold is at 0x1C
	'Release and Variant is at 0x1D
	'0 means Ultimate Kaos Trap
	'2 means Legendary
	'Variant Flag is at 0x80

	'Trinkets:
	'01	T-Bone's Lucky Tie
	'02 Batterson's Bubble
	'03 Dark Water Daisy
	'04 Vote For Cyclops
	'05 Ramses' Dragon Horn
	'06 Iris' Iris
	'07 Kuckoo Kazoo
	'08 Ramses' Rune
	'09 Ullysses Uniclops
	'0A	Billy Bison
	'0B	Stealth Elf's Gift
	'0C	Lizard Lilly
	'0D	Pirate Pinwheel
	'0E	Bubble Blower
	'0F	Medal of Heroism
	'10 Blobber's Medal of Courage
	'11 Medal of Valliance
	'12 Medal of Gallantry
	'13 Medal of Mettle
	'14 Winged Medal of Bravery
	'15 Seadog Seashell
	'16 Snuckles' Sunflower
	'17 Teddy Cyclops
	'18 Goo Factory Gear
	'19 Elemental Opal
	'1A	Elemental Radiant
	'1B	Elemental Diamond
	'1C	Cyclops Spinner
	'1D	Wiliken Windmill
	'1E	Time Town Ticker
	'1F	Big Bow of Doom
	'20 Mabu's Medallion
	'21 Spyro's Shield



	'Trap?
	'ID     MoldValue	Mold's Name	    Trap	            Variant
	'D2     02	        Logholder 	    Biters Bane	
	'D2     08	        Skull           Sorcerous Skull	
	'D2     12	        Totem	        Spell Slapper	
	'D2     15	        Rocket   	    Rune Rocket	
	'D2	    0B          Axe 	        Axe Of Illusion 	
	'D2     0E	        Hourglass 	    Arcane Hourglass	
	'D3	    01          Tiki            Tidal Tiki	
	'D3	    02	        Logholder 	    Wet Walter	        Outlaw
	'D3	    06          Jughead 	    Flood Flask	        Legendary
	'D3	    07	        Angel 	        Soaking Staff	
	'D3	    16	        Helmet      	Frost Helm	
	'D3	    0B	        Axe         	Aqua Axe	
	'D4	    03	        Toucan       	Breezy Bird	
	'D4	    06	        Jughead 	    Drafty Decanter	
	'D4	    10	        Snake	        Cloudy Cobra	
	'D4	    11	        Screamer 	    Storm Warning	
	'D4	    18	        Sword       	Cyclone Sabre	
	'D4	    0E	        Hourglass 	    Tempest Timer	
	'D5	    04	        Orb 	        Spirit Sphere	    Legendary
	'D5	    08	        Skull 	        Spectral Skull  	Legendary
	'D5	    10	        Snake	        Spooky Snake	
	'D5	    17	        Spear	        Dream Piercer	
	'D5	    0B	        Axe 	        Haunted Hatchet	
	'D5	    0C	        Hand 	        Grim Gripper	
	'D6	    01	        Tiki 	        Tech Totem	
	'D6	    07	        Angel 	        Automatic Angel	
	'D6	    09	        Scepter     	Factory Flower	
	'D6	    16	        Helmet          Makers Mana         Steampunk
	'D6	    1A	        Flipped 	    Topsy Techy	
	'D6	    0C          Hand         	Grabbing Gadget	
	'D7	    05	        Torch       	Eternal Flame	
	'D7	    09	        Scepter	        Fire Flower	
	'D7	    11	        Screamer	    Scorching Stopper	
	'D7	    12	        Totem	        Searing Spinner	
	'D7	    17	        Spear	        Spark Spear	
	'D7	    1B	        Yawn	        Blazing Belch 	
	'D8	    03	        Toucan	        Rock Hawk	
	'D8	    04	        Orb 	        Banded Boulder	
	'D8	    12	        Totem	        Spinning Sandstorm  Red Hot
	'D8	    1A	        Flipped 	    Rubble Trouble      Bunny
	'D8	    0A	        Hammer	        Slag Hammer	
	'D8	    0E	        Hourglass       Dust Of Time	
	'D9	    03	        Toucan          Oak Eagle           Steamed
	'D9	    05	        Torch	        Emerald Energy	    Riot
	'D9	    10	        Snake	        Seep Serpent	
	'D9	    18	        Sword	        Jade Blade	
	'D9	    1B	        Yawn	        Shrub Shrieker	
	'D9	    0A          Hammer      	Weed Whacker	
	'DA     15	        Rocket 	        Shining Ship	    Rebel
	'DA	    1B	        Yawn 	        Beam Scream	
	'DA	    0F	        Owl	            Heavenly Hawk	
	'DB	    14          Spider          Shadow Spider	
	'DB	    18          Sword           Dark Dagger	
	'DB	    1A          Flipped         Ghastly Grimace	
	'DC	    1E	        Kaos	        Kaos Trap	
	'DC	    1F	        Kaos - Ultimate Ultimate Kaos Trap	


	Private Sub btnIDTrap_Click(sender As Object, e As EventArgs) Handles btnIDTrap.Click
		MessageBox.Show("Trap ID: " & Hex(WholeFile(&H10)))
		MessageBox.Show("Mold: " & Hex(WholeFile(&H1C)))

		MessageBox.Show("Variant Flag: " & Hex(WholeFile(&H80)))
		MessageBox.Show("Quanity Captured: " & Hex(WholeFile(&H81)))
		MessageBox.Show("Villian Variant: " & Hex(WholeFile(&H87)))

		MessageBox.Show("Villian ID: " & Hex(WholeFile(&H90)))
		MessageBox.Show("Evolved? " & Hex(WholeFile(&H91)))
		MessageBox.Show("Hat ID: " & Hex(WholeFile(&H92)))
		MessageBox.Show("Trinket ID: " & Hex(WholeFile(&H93)))
	End Sub
End Class