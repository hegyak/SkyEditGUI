Imports System.Text
Imports System.Windows.Forms.VisualStyles
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
		WholeFile(&H81) = Convert.ToByte(numVillianCount.Value)

		'Set Villian 1 ID and Variant
		'Only Villian 1 has Variant
		If chkVillian1Variant.Checked = True Then
			'if 0x80 = 01 and 0x90 is the same as 0x87 then Variant Villain?
			WholeFile(&H80) = &H1
			WholeFile(&H87) = Convert.ToByte(cmbVillian1.SelectedIndex)
			WholeFile(&H90) = Convert.ToByte(cmbVillian1.SelectedIndex)
		Else
			WholeFile(&H80) = &H0
			WholeFile(&H90) = Convert.ToByte(cmbVillian1.SelectedIndex)
		End If

		'Set Villain 1 Evolved
		If chkVillian1Evolved.Checked = True Then
			WholeFile(&H91) = &H1
		Else
			WholeFile(&H91) = &H0
		End If
		'Set Villain 1 Hat
		WholeFile(&H92) = Save_Hat(cmbVillian1Hat.SelectedIndex)
		'Set Villian 1 Trinket
		WholeFile(&H93) = Convert.ToByte(cmbVillian1Trinket.SelectedIndex)
		'Set Villian 1 Nickname (If set)
		If txtVillian1Name.Text <> "" Then
			Save_Name(&H94, txtVillian1Name.Text)
		End If

		'Set Villian 2 ID
		WholeFile(&HD0) = Convert.ToByte(cmbVillian2.SelectedIndex)
		If chkVillian2Evolved.Checked = True Then
			WholeFile(&HD1) = 1
		Else
			WholeFile(&HD1) = 0
		End If
		'Set Villian 2 Hat
		WholeFile(&HD2) = Save_Hat(cmbVillian2Hat.SelectedIndex)
		'Set Villian 2 Trinket
		WholeFile(&HD3) = Convert.ToByte(cmbVillian2Trinket.SelectedIndex)
		If txtVillian2Name.Text <> "" Then
			Save_Name(&HD4, txtVillian2Name.Text)
		End If

		'Set Villian 3 ID
		WholeFile(&H110) = Convert.ToByte(cmbVillian3.SelectedIndex)
		If chkVillian3Evolved.Checked = True Then
			WholeFile(&H111) = 1
		Else
			WholeFile(&H111) = 0
		End If
		'Set Villan 3 Hat
		WholeFile(&H112) = Save_Hat(cmbVillian3Hat.SelectedIndex)
		'Set Villian 3 Trinket
		WholeFile(&H113) = Convert.ToByte(cmbVillian3Trinket.SelectedIndex)
		If txtVillian3Name.Text <> "" Then
			Save_Name(&H114, txtVillian3Name.Text)
		End If

		'Set Villian 4 ID
		WholeFile(&H150) = Convert.ToByte(cmbVillian4.SelectedIndex)
		If chkVillian4Evolved.Checked = True Then
			WholeFile(&H151) = 1
		Else
			WholeFile(&H151) = 0
		End If
		'Set Villan 4 Hat
		WholeFile(&H152) = Save_Hat(cmbVillian4Hat.SelectedIndex)
		'Set Villian 4 Trinket
		WholeFile(&H153) = Convert.ToByte(cmbVillian4Trinket.SelectedIndex)
		If txtVillian1Name.Text <> "" Then
			Save_Name(&H154, txtVillian4Name.Text)
		End If

		'Set Villian 5 ID
		WholeFile(&H190) = Convert.ToByte(cmbVillian5.SelectedIndex)
		If chkVillian5Evolved.Checked = True Then
			WholeFile(&H191) = 1
		Else
			WholeFile(&H191) = 0
		End If
		'Set Villan 5 Hat
		WholeFile(&H192) = Save_Hat(cmbVillian5Hat.SelectedIndex)
		'Set Villian 5 Trinket
		WholeFile(&H193) = Convert.ToByte(cmbVillian5Trinket.SelectedIndex)
		If txtVillian1Name.Text <> "" Then
			Save_Name(&H194, txtVillian5Name.Text)
		End If

		'Set Villian 6 ID
		WholeFile(&H1D0) = Convert.ToByte(cmbVillian6.SelectedIndex)
		If chkVillian6Evolved.Checked = True Then
			WholeFile(&H1D1) = 1
		Else
			WholeFile(&H1D1) = 0
		End If
		'Set Villan 6 Hat
		WholeFile(&H1D2) = Save_Hat(cmbVillian6Hat.SelectedIndex)
		'Set Villian 6 Trinket
		WholeFile(&H1D3) = Convert.ToByte(cmbVillian6Trinket.SelectedIndex)
		If txtVillian1Name.Text <> "" Then
			Save_Name(&H1D4, txtVillian6Name.Text)
		End If
		'This resolves Area A
	End Sub
	Sub Save_Area_B()
		'Add 1C0 to All Hex Offsets
		'Write Quanity Trapped
		WholeFile(&H241) = Convert.ToByte(numVillianCount.Value)

		'Set Villian 1 ID and Variant
		'Only Villian 1 has Variant
		If chkVillian1Variant.Checked = True Then
			'if 0x80 = 01 and 0x90 is the same as 0x87 then Variant Villain?
			WholeFile(&H240) = &H1
			WholeFile(&H247) = Convert.ToByte(cmbVillian1.SelectedIndex)
			WholeFile(&H250) = Convert.ToByte(cmbVillian1.SelectedIndex)
		Else
			WholeFile(&H240) = &H0
			WholeFile(&H250) = Convert.ToByte(cmbVillian1.SelectedIndex)
		End If

		'Set Villain 1 Evolved
		If chkVillian1Evolved.Checked = True Then
			WholeFile(&H251) = &H1
		Else
			WholeFile(&H251) = &H0
		End If
		'Set Villain 1 Hat
		WholeFile(&H252) = Save_Hat(cmbVillian1Hat.SelectedIndex)
		'Set Villian 1 Trinket
		WholeFile(&H253) = Convert.ToByte(cmbVillian1Trinket.SelectedIndex)
		'Set Villian 1 Nickname (If set)
		If txtVillian1Name.Text <> "" Then
			Save_Name(&H254, txtVillian1Name.Text)
		End If

		'Set Villian 2 ID
		WholeFile(&H290) = Convert.ToByte(cmbVillian2.SelectedIndex)
		If chkVillian2Evolved.Checked = True Then
			WholeFile(&H291) = 1
		Else
			WholeFile(&H291) = 0
		End If
		'Set Villian 2 Hat
		WholeFile(&H292) = Save_Hat(cmbVillian2Hat.SelectedIndex)
		'Set Villian 2 Trinket
		WholeFile(&H293) = Convert.ToByte(cmbVillian2Trinket.SelectedIndex)
		If txtVillian2Name.Text <> "" Then
			Save_Name(&H294, txtVillian2Name.Text)
		End If

		'Set Villian 3 ID
		WholeFile(&H2D0) = Convert.ToByte(cmbVillian3.SelectedIndex)
		If chkVillian3Evolved.Checked = True Then
			WholeFile(&H2D1) = 1
		Else
			WholeFile(&H2D1) = 0
		End If
		'Set Villan 3 Hat
		WholeFile(&H2D2) = Save_Hat(cmbVillian3Hat.SelectedIndex)
		'Set Villian 3 Trinket
		WholeFile(&H2D3) = Convert.ToByte(cmbVillian3Trinket.SelectedIndex)
		If txtVillian3Name.Text <> "" Then
			Save_Name(&H2D4, txtVillian3Name.Text)
		End If

		'Set Villian 4 ID
		WholeFile(&H310) = Convert.ToByte(cmbVillian4.SelectedIndex)
		If chkVillian4Evolved.Checked = True Then
			WholeFile(&H311) = 1
		Else
			WholeFile(&H311) = 0
		End If
		'Set Villan 4 Hat
		WholeFile(&H312) = Save_Hat(cmbVillian4Hat.SelectedIndex)
		'Set Villian 4 Trinket
		WholeFile(&H313) = Convert.ToByte(cmbVillian4Trinket.SelectedIndex)
		If txtVillian1Name.Text <> "" Then
			Save_Name(&H314, txtVillian4Name.Text)
		End If

		'Set Villian 5 ID
		WholeFile(&H350) = Convert.ToByte(cmbVillian5.SelectedIndex)
		If chkVillian5Evolved.Checked = True Then
			WholeFile(&H351) = 1
		Else
			WholeFile(&H351) = 0
		End If
		'Set Villan 5 Hat
		WholeFile(&H352) = Save_Hat(cmbVillian5Hat.SelectedIndex)
		'Set Villian 5 Trinket
		WholeFile(&H353) = Convert.ToByte(cmbVillian5Trinket.SelectedIndex)
		If txtVillian1Name.Text <> "" Then
			Save_Name(&H354, txtVillian5Name.Text)
		End If

		'Set Villian 6 ID
		WholeFile(&H1D0) = Convert.ToByte(cmbVillian6.SelectedIndex)
		If chkVillian6Evolved.Checked = True Then
			WholeFile(&H391) = 1
		Else
			WholeFile(&H391) = 0
		End If
		'Set Villan 6 Hat
		WholeFile(&H392) = Save_Hat(cmbVillian6Hat.SelectedIndex)
		'Set Villian 6 Trinket
		WholeFile(&H393) = Convert.ToByte(cmbVillian6Trinket.SelectedIndex)
		If txtVillian1Name.Text <> "" Then
			Save_Name(&H394, txtVillian6Name.Text)
		End If
		'This resolves Area B
	End Sub
	Function Save_Hat(Hat_Index As Integer)
		If Hat_Index = 0 Then
			Return &H0
		ElseIf Hat_Index = 1 Then
			Return &HD3
		ElseIf Hat_Index = 2 Then
			Return &HDA
		ElseIf Hat_Index = 3 Then
			Return &HD4
		ElseIf Hat_Index = 4 Then
			Return &H9B
		ElseIf Hat_Index = 5 Then
			Return &HED
		ElseIf Hat_Index = 6 Then
			Return &HC3
		ElseIf Hat_Index = 7 Then
			Return &H9C
		ElseIf Hat_Index = 8 Then
			Return &H9D
		ElseIf Hat_Index = 9 Then
			Return &HEE
		ElseIf Hat_Index = 10 Then
			Return &H9E
		ElseIf Hat_Index = 11 Then
			Return &HEA
		ElseIf Hat_Index = 12 Then
			Return &HE8
		ElseIf Hat_Index = 13 Then
			Return &HF6
		ElseIf Hat_Index = 14 Then
			Return &HA0
		ElseIf Hat_Index = 15 Then
			Return &HBB
		ElseIf Hat_Index = 16 Then
			Return &HA3
		ElseIf Hat_Index = 17 Then
			Return &HA2
		ElseIf Hat_Index = 18 Then
			Return &HF7
		ElseIf Hat_Index = 19 Then
			Return &HA4
		ElseIf Hat_Index = 20 Then
			Return &HFC
		ElseIf Hat_Index = 21 Then
			Return &HA6
		ElseIf Hat_Index = 22 Then
			Return &HBD
		ElseIf Hat_Index = 23 Then
			Return &HD6
		ElseIf Hat_Index = 24 Then
			Return &HA7
		ElseIf Hat_Index = 25 Then
			Return &HA8
		ElseIf Hat_Index = 26 Then
			Return &HA9
		ElseIf Hat_Index = 27 Then
			Return &HEB
		ElseIf Hat_Index = 28 Then
			Return &H9F
		ElseIf Hat_Index = 29 Then
			Return &HAA
		ElseIf Hat_Index = 30 Then
			Return &HE9
		ElseIf Hat_Index = 31 Then
			Return &HCB
		ElseIf Hat_Index = 32 Then
			Return &HD9
		ElseIf Hat_Index = 33 Then
			Return &HDC
		ElseIf Hat_Index = 34 Then
			Return &HC6
		ElseIf Hat_Index = 35 Then
			Return &HAE
		ElseIf Hat_Index = 36 Then
			Return &HAD
		ElseIf Hat_Index = 37 Then
			Return &HE2
		ElseIf Hat_Index = 38 Then
			Return &HAF
		ElseIf Hat_Index = 39 Then
			Return &HC4
		ElseIf Hat_Index = 40 Then
			Return &HD5
		ElseIf Hat_Index = 41 Then
			Return &HB0
		ElseIf Hat_Index = 42 Then
			Return &HA1
		ElseIf Hat_Index = 43 Then
			Return &HB1
		ElseIf Hat_Index = 44 Then
			Return &HA5
		ElseIf Hat_Index = 45 Then
			Return &HB2
		ElseIf Hat_Index = 46 Then
			Return &HDB
		ElseIf Hat_Index = 47 Then
			Return &HDE
		ElseIf Hat_Index = 48 Then
			Return &HAC
		ElseIf Hat_Index = 49 Then
			Return &HB3
		ElseIf Hat_Index = 50 Then
			Return &HB4
		ElseIf Hat_Index = 51 Then
			Return &HC0
		ElseIf Hat_Index = 52 Then
			Return &HE5
		ElseIf Hat_Index = 53 Then
			Return &HFA
		ElseIf Hat_Index = 54 Then
			Return &HC7
		ElseIf Hat_Index = 55 Then
			Return &HB5
		ElseIf Hat_Index = 56 Then
			Return &HE0
		ElseIf Hat_Index = 57 Then
			Return &HB6
		ElseIf Hat_Index = 58 Then
			Return &HFD
		ElseIf Hat_Index = 59 Then
			Return &HBA
		ElseIf Hat_Index = 60 Then
			Return &HAB
		ElseIf Hat_Index = 61 Then
			Return &HB7
		ElseIf Hat_Index = 62 Then
			Return &HB8
		ElseIf Hat_Index = 63 Then
			Return &HB9
		ElseIf Hat_Index = 64 Then
			Return &HEC
		ElseIf Hat_Index = 65 Then
			Return &HD2
		ElseIf Hat_Index = 66 Then
			Return &HE4
		ElseIf Hat_Index = 67 Then
			Return &HBC
		ElseIf Hat_Index = 68 Then
			Return &HD8
		ElseIf Hat_Index = 69 Then
			Return &HBE
		ElseIf Hat_Index = 70 Then
			Return &HD1
		ElseIf Hat_Index = 71 Then
			Return &HBF
		ElseIf Hat_Index = 72 Then
			Return &HCC
		ElseIf Hat_Index = 73 Then
			Return &HDD
		ElseIf Hat_Index = 74 Then
			Return &HC8
		ElseIf Hat_Index = 75 Then
			Return &HC2
		ElseIf Hat_Index = 76 Then
			Return &HEF
		ElseIf Hat_Index = 77 Then
			Return &HF3
		ElseIf Hat_Index = 78 Then
			Return &HC1
		ElseIf Hat_Index = 79 Then
			Return &HC5
		ElseIf Hat_Index = 80 Then
			Return &HE1
		ElseIf Hat_Index = 81 Then
			Return &HCE
		ElseIf Hat_Index = 82 Then
			Return &HDF
		ElseIf Hat_Index = 83 Then
			Return &HE3
		ElseIf Hat_Index = 84 Then
			Return &HC9
		ElseIf Hat_Index = 85 Then
			Return &HD0
		ElseIf Hat_Index = 86 Then
			Return &HCA
		ElseIf Hat_Index = 87 Then
			Return &HCD
		ElseIf Hat_Index = 88 Then
			Return &HD7
		ElseIf Hat_Index = 89 Then
			Return &HCF
		End If

	End Function
	Private Sub frmTraps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Application.DoEvents()
		'chkVillian1Variant.Checked = True
		If Area0 > Area1 Then
			Load_Area_0()
		ElseIf Area1 > Area0 Then
			Load_Area_1()
		ElseIf Area0 = Area1 Then
			Load_Area_0()
		End If
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
		Select Case Villian1_ID
			Case &H0
				cmbVillian1.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian1.SelectedItem = "Chompy Mage"
				Exit Select
			Case &H2
				cmbVillian1.SelectedItem = "Dr. Crankcase"
				Exit Select
			Case &H3
				cmbVillian1.SelectedItem = "Wolfgang"
				Exit Select
			Case &H4
				cmbVillian1.SelectedItem = "Chef Pepper Jack"
				Exit Select
			Case &H5
				cmbVillian1.SelectedItem = "Nightshade"
				Exit Select
			Case &H6
				cmbVillian1.SelectedItem = "Luminous"
				Exit Select
			Case &H7
				cmbVillian1.SelectedItem = "Golden Queen"
				Exit Select
			Case &H8
				cmbVillian1.SelectedItem = "Dreamcatcher"
				Exit Select
			Case &H9
				cmbVillian1.SelectedItem = "Gulper"
				Exit Select
			Case &HA
				cmbVillian1.SelectedItem = "Kaos"
				Exit Select
			Case &HB
				cmbVillian1.SelectedItem = "Cuckoo Clocker"
				Exit Select
			Case &HC
				cmbVillian1.SelectedItem = "Buzzer Beak"
				Exit Select
			Case &HD
				cmbVillian1.SelectedItem = "Shield Shredder"
				Exit Select
			Case &HE
				cmbVillian1.SelectedItem = "Cross Crow"
				Exit Select
			Case &HF
				cmbVillian1.SelectedItem = "Bone Chompy"
				Exit Select
			Case &H10
				MessageBox.Show("Brawl")
				cmbVillian1.SelectedItem = "Brawl and Chain"
				Exit Select
			Case &H11
				cmbVillian1.SelectedItem = "Bomb Shell"
				Exit Select
			Case &H12
				cmbVillian1.SelectedItem = "Masker Mind"
				Exit Select
			Case &H13
				cmbVillian1.SelectedItem = "Chill Bill"
				Exit Select
			Case &H14
				cmbVillian1.SelectedItem = "Sheep Creep"
				Exit Select
			Case &H15
				cmbVillian1.SelectedItem = "Shrednaught"
				Exit Select
			Case &H16
				cmbVillian1.SelectedItem = "Chomp Chest"
				Exit Select
			Case &H17
				cmbVillian1.SelectedItem = "Broccoli Guy"
				Exit Select
			Case &H18
				cmbVillian1.SelectedItem = "Rage Mage"
				Exit Select
			Case &H19
				cmbVillian1.SelectedItem = "Lob Goblin"
				Exit Select
			Case &H1A
				cmbVillian1.SelectedItem = "Chompy"
				Exit Select
			Case &H1B
				cmbVillian1.SelectedItem = "Fisticuffs"
				Exit Select
			Case &H1C
				cmbVillian1.SelectedItem = "Trolling Thunder"
				Exit Select
			Case &H1D
				cmbVillian1.SelectedItem = "Hood Sickle"
				Exit Select
			Case &H1E
				cmbVillian1.SelectedItem = "Bruiser Cruiser"
				Exit Select
			Case &H1F
				cmbVillian1.SelectedItem = "Brawlrus"
				Exit Select
			Case &H20
				cmbVillian1.SelectedItem = "Tussle Sprout"
				Exit Select
			Case &H21
				cmbVillian1.SelectedItem = "Krankenstein"
				Exit Select
			Case &H22
				cmbVillian1.SelectedItem = "Scrap Shooter"
				Exit Select
			Case &H23
				cmbVillian1.SelectedItem = "Slobber Trap"
				Exit Select
			Case &H24
				cmbVillian1.SelectedItem = "Grinnade"
				Exit Select
			Case &H25
				cmbVillian1.SelectedItem = "Bad Juju"
				Exit Select
			Case &H26
				cmbVillian1.SelectedItem = "Blaster-Tron"
				Exit Select
			Case &H27
				cmbVillian1.SelectedItem = "Tae Kwon Crow"
				Exit Select
			Case &H28
				cmbVillian1.SelectedItem = "Painyata"
				Exit Select
			Case &H29
				cmbVillian1.SelectedItem = "Smoke Scream"
				Exit Select
			Case &H2A
				cmbVillian1.SelectedItem = "Eye Five"
				Exit Select
			Case &H2B
				cmbVillian1.SelectedItem = "Grave Clobber"
				Exit Select
			Case &H2C
				cmbVillian1.SelectedItem = "Threatpack"
				Exit Select
			Case &H2D
				cmbVillian1.SelectedItem = "Mab Lobs"
				Exit Select
			Case &H2E
				cmbVillian1.SelectedItem = "Eye Scream"
				Exit Select
			Case Else
				cmbVillian1.SelectedItem = "(None)"
				Exit Select
		End Select
		If WholeFile(&H91) = &H1 Then
			chkVillian1Evolved.Checked = True
		End If
		Dim Villian1_Hat As Byte = WholeFile(&H92)
		Select Case Villian1_Hat
			Case &H0
				cmbVillian1Hat.SelectedItem = "(None)"
			Case &HD3
				cmbVillian1Hat.SelectedItem = "Alarm Clock Hat"
			Case &HDA
				cmbVillian1Hat.SelectedItem = "Bat Hat"
			Case &HD4
				cmbVillian1Hat.SelectedItem = "Batter Up Hat"
			Case &H9B
				cmbVillian1Hat.SelectedItem = "Beetle Hat"
			Case &HED
				cmbVillian1Hat.SelectedItem = "Bellhop Hat"
			Case &HC3
				cmbVillian1Hat.SelectedItem = "Bobby"
			Case &H9C
				cmbVillian1Hat.SelectedItem = "Brain Hat"
			Case &H9D
				cmbVillian1Hat.SelectedItem = "Brainiac Hat"
			Case &HEE
				cmbVillian1Hat.SelectedItem = "Bronze Arkeyan Helm"
			Case &H9E
				cmbVillian1Hat.SelectedItem = "Bucket Hat"
			Case &HEA
				cmbVillian1Hat.SelectedItem = "Candle Hat"
			Case &HE8
				cmbVillian1Hat.SelectedItem = "Candy Cane Hat"
			Case &HF6
				cmbVillian1Hat.SelectedItem = "Carnival Hat"
			Case &HA0
				cmbVillian1Hat.SelectedItem = "Ceiling Fan Hat"
			Case &HBB
				cmbVillian1Hat.SelectedItem = "Classic Pot Hat"
			Case &HA3
				cmbVillian1Hat.SelectedItem = "Clown Bowler Hat"
			Case &HA2
				cmbVillian1Hat.SelectedItem = "Clown Classic Hat"
			Case &HF7
				cmbVillian1Hat.SelectedItem = "Coconut Hat"
			Case &HA4
				cmbVillian1Hat.SelectedItem = "Colander Hat"
			Case &HFC
				cmbVillian1Hat.SelectedItem = "Core Of Light Hat"
			Case &HA6
				cmbVillian1Hat.SelectedItem = "Cornucopia Hat"
			Case &HBD
				cmbVillian1Hat.SelectedItem = "Crazy Light Bulb Hat"
			Case &HD6
				cmbVillian1Hat.SelectedItem = "Croissant Hat"
			Case &HA7
				cmbVillian1Hat.SelectedItem = "Cubano Hat"
			Case &HA8
				cmbVillian1Hat.SelectedItem = "Cycling Hat"
			Case &HA9
				cmbVillian1Hat.SelectedItem = "Daisy Crown"
			Case &HEB
				cmbVillian1Hat.SelectedItem = "Dark Helm"
			Case &H9F
				cmbVillian1Hat.SelectedItem = "Desert Crown"
			Case &HAA
				cmbVillian1Hat.SelectedItem = "Dragon Skull"
			Case &HE9
				cmbVillian1Hat.SelectedItem = "Eggshell Hat"
			Case &HCB
				cmbVillian1Hat.SelectedItem = "Extreme Viking Hat"
			Case &HD9
				cmbVillian1Hat.SelectedItem = "Eye of Kaos Hat"
			Case &HDC
				cmbVillian1Hat.SelectedItem = "Firefly Jar"
			Case &HC6
				cmbVillian1Hat.SelectedItem = "Flight Attendant Hat"
			Case &HAE
				cmbVillian1Hat.SelectedItem = "Garrison Hat"
			Case &HAD
				cmbVillian1Hat.SelectedItem = "Generalissimo"
			Case &HE2
				cmbVillian1Hat.SelectedItem = "Gold Arkeyan Helm"
			Case &HAF
				cmbVillian1Hat.SelectedItem = "Gondolier Hat"
			Case &HC4
				cmbVillian1Hat.SelectedItem = "Hedgehog Hat"
			Case &HD5
				cmbVillian1Hat.SelectedItem = "Horns Be With You Hat"
			Case &HB0
				cmbVillian1Hat.SelectedItem = "Hunting Hat"
			Case &HA1
				cmbVillian1Hat.SelectedItem = "Imperial Hat"
			Case &HB1
				cmbVillian1Hat.SelectedItem = "Juicer Hat"
			Case &HA5
				cmbVillian1Hat.SelectedItem = "Kepi Hat"
			Case &HB2
				cmbVillian1Hat.SelectedItem = "Kokoshnik"
			Case &HDB
				cmbVillian1Hat.SelectedItem = "Light Bulb Hat"
			Case &HDE
				cmbVillian1Hat.SelectedItem = "Lighthouse Beacon Hat"
			Case &HAC
				cmbVillian1Hat.SelectedItem = "Lil' Elf Hat"
			Case &HB3
				cmbVillian1Hat.SelectedItem = "Medic Hat"
			Case &HB4
				cmbVillian1Hat.SelectedItem = "Melon Hat"
			Case &HC0
				cmbVillian1Hat.SelectedItem = "Metal Fin Hat"
			Case &HE5
				cmbVillian1Hat.SelectedItem = "Miniature Skylands Hat"
			Case &HFA
				cmbVillian1Hat.SelectedItem = "Molekin Mountain Hat"
			Case &HC7
				cmbVillian1Hat.SelectedItem = "Monday Hat"
			Case &HB5
				cmbVillian1Hat.SelectedItem = "Mountie Hat"
			Case &HE0
				cmbVillian1Hat.SelectedItem = "Night Cap"
			Case &HB6
				cmbVillian1Hat.SelectedItem = "Nurse Hat"
			Case &HFD
				cmbVillian1Hat.SelectedItem = "Octavius Cloptimus Hat"
			Case &HBA
				cmbVillian1Hat.SelectedItem = "Old-Time Movie Hat"
			Case &HAB
				cmbVillian1Hat.SelectedItem = "Outback Hat"
			Case &HB7
				cmbVillian1Hat.SelectedItem = "Palm Hat"
			Case &HB8
				cmbVillian1Hat.SelectedItem = "Paperboy Hat"
			Case &HB9
				cmbVillian1Hat.SelectedItem = "Parrot Nest"
			Case &HEC
				cmbVillian1Hat.SelectedItem = "Planet Hat"
			Case &HD2
				cmbVillian1Hat.SelectedItem = "Pork Pie Hat"
			Case &HE4
				cmbVillian1Hat.SelectedItem = "Pyramid Hat"
			Case &HBC
				cmbVillian1Hat.SelectedItem = "Radar Hat"
			Case &HD8
				cmbVillian1Hat.SelectedItem = "Rainbow Hat"
			Case &HBE
				cmbVillian1Hat.SelectedItem = "Rubber Glove Hat"
			Case &HD1
				cmbVillian1Hat.SelectedItem = "Rude Boy Hat"
			Case &HBF
				cmbVillian1Hat.SelectedItem = "Rugby Hat"
			Case &HCC
				cmbVillian1Hat.SelectedItem = "Scooter Hat"
			Case &HDD
				cmbVillian1Hat.SelectedItem = "Shadow Ghost Hat"
			Case &HC8
				cmbVillian1Hat.SelectedItem = "Sherpa Hat"
			Case &HC2
				cmbVillian1Hat.SelectedItem = "Shower Cap"
			Case &HEF
				cmbVillian1Hat.SelectedItem = "Silver Arkeyan Helm"
			Case &HF3
				cmbVillian1Hat.SelectedItem = "Skipper Hat"
			Case &HC1
				cmbVillian1Hat.SelectedItem = "Sleuth Hat"
			Case &HC5
				cmbVillian1Hat.SelectedItem = "Steampunk Hat"
			Case &HE1
				cmbVillian1Hat.SelectedItem = "Storm Hat"
			Case &HCE
				cmbVillian1Hat.SelectedItem = "Synchronized Swimming Cap"
			Case &HDF
				cmbVillian1Hat.SelectedItem = "Tin Foil Hat"
			Case &HE3
				cmbVillian1Hat.SelectedItem = "Toucan Hat"
			Case &HC9
				cmbVillian1Hat.SelectedItem = "Trash Lid"
			Case &HD0
				cmbVillian1Hat.SelectedItem = "Tribal Hat"
			Case &HCA
				cmbVillian1Hat.SelectedItem = "Turtle Hat"
			Case &HCD
				cmbVillian1Hat.SelectedItem = "Volcano Island Hat"
			Case &HD7
				cmbVillian1Hat.SelectedItem = "Weather Vane Hat"
			Case &HCF
				cmbVillian1Hat.SelectedItem = "William Tell Hat"
			Case Else
				cmbVillian1Hat.SelectedItem = "(None)"
		End Select
		Dim Villian1_Trinket As Byte = WholeFile(&H93)
		Select Case Villian1_Trinket
			Case &H0
				cmbVillian1Trinket.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian1Trinket.SelectedItem = "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				cmbVillian1Trinket.SelectedItem = "Batterson's Bubble"
				Exit Select
			Case &H3
				cmbVillian1Trinket.SelectedItem = "Dark Water Daisy"
				Exit Select
			Case &H4
				cmbVillian1Trinket.SelectedItem = "Vote For Cyclops"
				Exit Select
			Case &H5
				cmbVillian1Trinket.SelectedItem = "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				cmbVillian1Trinket.SelectedItem = "Iris' Iris"
				Exit Select
			Case &H7
				cmbVillian1Trinket.SelectedItem = "Kuckoo Kazoo"
				Exit Select
			Case &H8
				cmbVillian1Trinket.SelectedItem = "Ramses' Rune"
				Exit Select
			Case &H9
				cmbVillian1Trinket.SelectedItem = "Ullysses Uniclops"
				Exit Select
			Case &HA
				cmbVillian1Trinket.SelectedItem = "Billy Bison"
				Exit Select
			Case &HB
				cmbVillian1Trinket.SelectedItem = "Stealth Elf's Gift"
				Exit Select
			Case &HC
				cmbVillian1Trinket.SelectedItem = "Lizard Lilly"
				Exit Select
			Case &HD
				cmbVillian1Trinket.SelectedItem = "Pirate Pinwheel"
				Exit Select
			Case &HE
				cmbVillian1Trinket.SelectedItem = "Bubble Blower"
				Exit Select
			Case &HF
				cmbVillian1Trinket.SelectedItem = "Medal of Heroism"
				Exit Select
			Case &H10
				cmbVillian1Trinket.SelectedItem = "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				cmbVillian1Trinket.SelectedItem = "Medal of Valliance"
				Exit Select
			Case &H12
				cmbVillian1Trinket.SelectedItem = "Medal of Gallantry"
				Exit Select
			Case &H13
				cmbVillian1Trinket.SelectedItem = "Medal of Mettle"
				Exit Select
			Case &H14
				cmbVillian1Trinket.SelectedItem = "Winged Medal of Bravery"
				Exit Select
			Case &H15
				cmbVillian1Trinket.SelectedItem = "Seadog Seashell"
				Exit Select
			Case &H16
				cmbVillian1Trinket.SelectedItem = "Snuckles' Sunflower"
				Exit Select
			Case &H17
				cmbVillian1Trinket.SelectedItem = "Teddy Cyclops"
				Exit Select
			Case &H18
				cmbVillian1Trinket.SelectedItem = "Goo Factory Gear"
				Exit Select
			Case &H19
				cmbVillian1Trinket.SelectedItem = "Elemental Opal"
				Exit Select
			Case &H1A
				cmbVillian1Trinket.SelectedItem = "Elemental Radiant"
				Exit Select
			Case &H1B
				cmbVillian1Trinket.SelectedItem = "Elemental Diamond"
				Exit Select
			Case &H1C
				cmbVillian1Trinket.SelectedItem = "Cyclops Spinner"
				Exit Select
			Case &H1D
				cmbVillian1Trinket.SelectedItem = "Wiliken Windmill"
				Exit Select
			Case &H1E
				cmbVillian1Trinket.SelectedItem = "Time Town Ticker"
				Exit Select
			Case &H1F
				cmbVillian1Trinket.SelectedItem = "Big Bow of Doom"
				Exit Select
			Case &H20
				cmbVillian1Trinket.SelectedItem = "Mabu's Medallion"
				Exit Select
			Case &H21
				cmbVillian1Trinket.SelectedItem = "Spyro's Shield"
				Exit Select
			Case Else
				cmbVillian1Trinket.SelectedItem = "(None)"
				Exit Select
		End Select
		'Load Name from Offset 0x94
		txtVillian1Name.Text = Load_Name(&H94)

		'+&H40
		'Villian Two Data is 0xD00 to 0x111
		'Ignore 0xF00 Block as it's MiFare
		'Dim Villian2_ID As Byte = WholeFile(&HD0)
		'MessageBox.Show("HEX: " & Hex(WholeFile(&HD0)))
		Select Case WholeFile(&HD0)
			Case &H0
				cmbVillian2.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian2.SelectedItem = "Chompy Mage"
				Exit Select
			Case &H2
				cmbVillian2.SelectedItem = "Dr. Crankcase"
				Exit Select
			Case &H3
				cmbVillian2.SelectedItem = "Wolfgang"
				Exit Select
			Case &H4
				cmbVillian2.SelectedItem = "Chef Pepper Jack"
				Exit Select
			Case &H5
				cmbVillian2.SelectedItem = "Nightshade"
				Exit Select
			Case &H6
				cmbVillian2.SelectedItem = "Luminous"
				Exit Select
			Case &H7
				cmbVillian2.SelectedItem = "Golden Queen"
				Exit Select
			Case &H8
				cmbVillian2.SelectedItem = "Dreamcatcher"
				Exit Select
			Case &H9
				cmbVillian2.SelectedItem = "Gulper"
				Exit Select
			Case &HA
				cmbVillian2.SelectedItem = "Kaos"
				Exit Select
			Case &HB
				cmbVillian2.SelectedItem = "Cuckoo Clocker"
				Exit Select
			Case &HC
				cmbVillian2.SelectedItem = "Buzzer Beak"
				Exit Select
			Case &HD
				cmbVillian2.SelectedItem = "Shield Shredder"
				Exit Select
			Case &HE
				cmbVillian2.SelectedItem = "Cross Crow"
				Exit Select
			Case &HF
				cmbVillian2.SelectedItem = "Bone Chompy"
				Exit Select
			Case &H10
				cmbVillian2.SelectedItem = "Brawl and Chain"
				Exit Select
			Case &H11
				cmbVillian2.SelectedItem = "Bomb Shell"
				Exit Select
			Case &H12
				cmbVillian2.SelectedItem = "Masker Mind"
				Exit Select
			Case &H13
				cmbVillian2.SelectedItem = "Chill Bill"
				Exit Select
			Case &H14
				cmbVillian2.SelectedItem = "Sheep Creep"
				Exit Select
			Case &H15
				cmbVillian2.SelectedItem = "Shrednaught"
				Exit Select
			Case &H16
				cmbVillian2.SelectedItem = "Chomp Chest"
				Exit Select
			Case &H17
				cmbVillian2.SelectedItem = "Broccoli Guy"
				Exit Select
			Case &H18
				cmbVillian2.SelectedItem = "Rage Mage"
				Exit Select
			Case &H19
				cmbVillian2.SelectedItem = "Lob Goblin"
				Exit Select
			Case &H1A
				cmbVillian2.SelectedItem = "Chompy"
				Exit Select
			Case &H1B
				cmbVillian2.SelectedItem = "Fisticuffs"
				Exit Select
			Case &H1C
				cmbVillian2.SelectedItem = "Trolling Thunder"
				Exit Select
			Case &H1D
				cmbVillian2.SelectedItem = "Hood Sickle"
				Exit Select
			Case &H1E
				cmbVillian2.SelectedItem = "Bruiser Cruiser"
				Exit Select
			Case &H1F
				cmbVillian2.SelectedItem = "Brawlrus"
				Exit Select
			Case &H20
				cmbVillian2.SelectedItem = "Tussle Sprout"
				Exit Select
			Case &H21
				cmbVillian2.SelectedItem = "Krankenstein"
				Exit Select
			Case &H22
				cmbVillian2.SelectedItem = "Scrap Shooter"
				Exit Select
			Case &H23
				cmbVillian2.SelectedItem = "Slobber Trap"
				Exit Select
			Case &H24
				cmbVillian2.SelectedItem = "Grinnade"
				Exit Select
			Case &H25
				cmbVillian2.SelectedItem = "Bad Juju"
				Exit Select
			Case &H26
				cmbVillian2.SelectedItem = "Blaster-Tron"
				Exit Select
			Case &H27
				cmbVillian2.SelectedItem = "Tae Kwon Crow"
				Exit Select
			Case &H28
				cmbVillian2.SelectedItem = "Painyata"
				Exit Select
			Case &H29
				cmbVillian2.SelectedItem = "Smoke Scream"
				Exit Select
			Case &H2A
				cmbVillian2.SelectedItem = "Eye Five"
				Exit Select
			Case &H2B
				cmbVillian2.SelectedItem = "Grave Clobber"
				Exit Select
			Case &H2C
				cmbVillian2.SelectedItem = "Threatpack"
				Exit Select
			Case &H2D
				cmbVillian2.SelectedItem = "Mab Lobs"
				Exit Select
			Case &H2E
				cmbVillian2.SelectedItem = "Eye Scream"
				Exit Select
			Case Else
				cmbVillian2.SelectedItem = "(None)"
				Exit Select
		End Select
		If WholeFile(&HD1) = &H1 Then
			chkVillian2Evolved.Checked = True
		End If
		Dim Villian2_Hat As Byte = WholeFile(&HD2)
		Select Case Villian2_Hat
			Case &H0
				cmbVillian2Hat.SelectedItem = "(None)"
			Case &HD3
				cmbVillian2Hat.SelectedItem = "Alarm Clock Hat"
			Case &HDA
				cmbVillian2Hat.SelectedItem = "Bat Hat"
			Case &HD4
				cmbVillian2Hat.SelectedItem = "Batter Up Hat"
			Case &H9B
				cmbVillian2Hat.SelectedItem = "Beetle Hat"
			Case &HED
				cmbVillian2Hat.SelectedItem = "Bellhop Hat"
			Case &HC3
				cmbVillian2Hat.SelectedItem = "Bobby"
			Case &H9C
				cmbVillian2Hat.SelectedItem = "Brain Hat"
			Case &H9D
				cmbVillian2Hat.SelectedItem = "Brainiac Hat"
			Case &HEE
				cmbVillian2Hat.SelectedItem = "Bronze Arkeyan Helm"
			Case &H9E
				cmbVillian2Hat.SelectedItem = "Bucket Hat"
			Case &HEA
				cmbVillian2Hat.SelectedItem = "Candle Hat"
			Case &HE8
				cmbVillian2Hat.SelectedItem = "Candy Cane Hat"
			Case &HF6
				cmbVillian2Hat.SelectedItem = "Carnival Hat"
			Case &HA0
				cmbVillian2Hat.SelectedItem = "Ceiling Fan Hat"
			Case &HBB
				cmbVillian2Hat.SelectedItem = "Classic Pot Hat"
			Case &HA3
				cmbVillian2Hat.SelectedItem = "Clown Bowler Hat"
			Case &HA2
				cmbVillian2Hat.SelectedItem = "Clown Classic Hat"
			Case &HF7
				cmbVillian2Hat.SelectedItem = "Coconut Hat"
			Case &HA4
				cmbVillian2Hat.SelectedItem = "Colander Hat"
			Case &HFC
				cmbVillian2Hat.SelectedItem = "Core Of Light Hat"
			Case &HA6
				cmbVillian2Hat.SelectedItem = "Cornucopia Hat"
			Case &HBD
				cmbVillian2Hat.SelectedItem = "Crazy Light Bulb Hat"
			Case &HD6
				cmbVillian2Hat.SelectedItem = "Croissant Hat"
			Case &HA7
				cmbVillian2Hat.SelectedItem = "Cubano Hat"
			Case &HA8
				cmbVillian2Hat.SelectedItem = "Cycling Hat"
			Case &HA9
				cmbVillian2Hat.SelectedItem = "Daisy Crown"
			Case &HEB
				cmbVillian2Hat.SelectedItem = "Dark Helm"
			Case &H9F
				cmbVillian2Hat.SelectedItem = "Desert Crown"
			Case &HAA
				cmbVillian2Hat.SelectedItem = "Dragon Skull"
			Case &HE9
				cmbVillian2Hat.SelectedItem = "Eggshell Hat"
			Case &HCB
				cmbVillian2Hat.SelectedItem = "Extreme Viking Hat"
			Case &HD9
				cmbVillian2Hat.SelectedItem = "Eye of Kaos Hat"
			Case &HDC
				cmbVillian2Hat.SelectedItem = "Firefly Jar"
			Case &HC6
				cmbVillian2Hat.SelectedItem = "Flight Attendant Hat"
			Case &HAE
				cmbVillian2Hat.SelectedItem = "Garrison Hat"
			Case &HAD
				cmbVillian2Hat.SelectedItem = "Generalissimo"
			Case &HE2
				cmbVillian2Hat.SelectedItem = "Gold Arkeyan Helm"
			Case &HAF
				cmbVillian2Hat.SelectedItem = "Gondolier Hat"
			Case &HC4
				cmbVillian2Hat.SelectedItem = "Hedgehog Hat"
			Case &HD5
				cmbVillian2Hat.SelectedItem = "Horns Be With You Hat"
			Case &HB0
				cmbVillian2Hat.SelectedItem = "Hunting Hat"
			Case &HA1
				cmbVillian2Hat.SelectedItem = "Imperial Hat"
			Case &HB1
				cmbVillian2Hat.SelectedItem = "Juicer Hat"
			Case &HA5
				cmbVillian2Hat.SelectedItem = "Kepi Hat"
			Case &HB2
				cmbVillian2Hat.SelectedItem = "Kokoshnik"
			Case &HDB
				cmbVillian2Hat.SelectedItem = "Light Bulb Hat"
			Case &HDE
				cmbVillian2Hat.SelectedItem = "Lighthouse Beacon Hat"
			Case &HAC
				cmbVillian2Hat.SelectedItem = "Lil' Elf Hat"
			Case &HB3
				cmbVillian2Hat.SelectedItem = "Medic Hat"
			Case &HB4
				cmbVillian2Hat.SelectedItem = "Melon Hat"
			Case &HC0
				cmbVillian2Hat.SelectedItem = "Metal Fin Hat"
			Case &HE5
				cmbVillian2Hat.SelectedItem = "Miniature Skylands Hat"
			Case &HFA
				cmbVillian2Hat.SelectedItem = "Molekin Mountain Hat"
			Case &HC7
				cmbVillian2Hat.SelectedItem = "Monday Hat"
			Case &HB5
				cmbVillian2Hat.SelectedItem = "Mountie Hat"
			Case &HE0
				cmbVillian2Hat.SelectedItem = "Night Cap"
			Case &HB6
				cmbVillian2Hat.SelectedItem = "Nurse Hat"
			Case &HFD
				cmbVillian2Hat.SelectedItem = "Octavius Cloptimus Hat"
			Case &HBA
				cmbVillian2Hat.SelectedItem = "Old-Time Movie Hat"
			Case &HAB
				cmbVillian2Hat.SelectedItem = "Outback Hat"
			Case &HB7
				cmbVillian2Hat.SelectedItem = "Palm Hat"
			Case &HB8
				cmbVillian2Hat.SelectedItem = "Paperboy Hat"
			Case &HB9
				cmbVillian2Hat.SelectedItem = "Parrot Nest"
			Case &HEC
				cmbVillian2Hat.SelectedItem = "Planet Hat"
			Case &HD2
				cmbVillian2Hat.SelectedItem = "Pork Pie Hat"
			Case &HE4
				cmbVillian2Hat.SelectedItem = "Pyramid Hat"
			Case &HBC
				cmbVillian2Hat.SelectedItem = "Radar Hat"
			Case &HD8
				cmbVillian2Hat.SelectedItem = "Rainbow Hat"
			Case &HBE
				cmbVillian2Hat.SelectedItem = "Rubber Glove Hat"
			Case &HD1
				cmbVillian2Hat.SelectedItem = "Rude Boy Hat"
			Case &HBF
				cmbVillian2Hat.SelectedItem = "Rugby Hat"
			Case &HCC
				cmbVillian2Hat.SelectedItem = "Scooter Hat"
			Case &HDD
				cmbVillian2Hat.SelectedItem = "Shadow Ghost Hat"
			Case &HC8
				cmbVillian2Hat.SelectedItem = "Sherpa Hat"
			Case &HC2
				cmbVillian2Hat.SelectedItem = "Shower Cap"
			Case &HEF
				cmbVillian2Hat.SelectedItem = "Silver Arkeyan Helm"
			Case &HF3
				cmbVillian2Hat.SelectedItem = "Skipper Hat"
			Case &HC1
				cmbVillian2Hat.SelectedItem = "Sleuth Hat"
			Case &HC5
				cmbVillian2Hat.SelectedItem = "Steampunk Hat"
			Case &HE1
				cmbVillian2Hat.SelectedItem = "Storm Hat"
			Case &HCE
				cmbVillian2Hat.SelectedItem = "Synchronized Swimming Cap"
			Case &HDF
				cmbVillian2Hat.SelectedItem = "Tin Foil Hat"
			Case &HE3
				cmbVillian2Hat.SelectedItem = "Toucan Hat"
			Case &HC9
				cmbVillian2Hat.SelectedItem = "Trash Lid"
			Case &HD0
				cmbVillian2Hat.SelectedItem = "Tribal Hat"
			Case &HCA
				cmbVillian2Hat.SelectedItem = "Turtle Hat"
			Case &HCD
				cmbVillian2Hat.SelectedItem = "Volcano Island Hat"
			Case &HD7
				cmbVillian2Hat.SelectedItem = "Weather Vane Hat"
			Case &HCF
				cmbVillian2Hat.SelectedItem = "William Tell Hat"
			Case Else
				cmbVillian2Hat.SelectedItem = "(None)"
		End Select
		Dim Villian2_Trinket As Byte = WholeFile(&HD3)
		Select Case Villian2_Trinket
			Case &H0
				cmbVillian2Trinket.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian2Trinket.SelectedItem = "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				cmbVillian2Trinket.SelectedItem = "Batterson's Bubble"
				Exit Select
			Case &H3
				cmbVillian2Trinket.SelectedItem = "Dark Water Daisy"
				Exit Select
			Case &H4
				cmbVillian2Trinket.SelectedItem = "Vote For Cyclops"
				Exit Select
			Case &H5
				cmbVillian2Trinket.SelectedItem = "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				cmbVillian2Trinket.SelectedItem = "Iris' Iris"
				Exit Select
			Case &H7
				cmbVillian2Trinket.SelectedItem = "Kuckoo Kazoo"
				Exit Select
			Case &H8
				cmbVillian2Trinket.SelectedItem = "Ramses' Rune"
				Exit Select
			Case &H9
				cmbVillian2Trinket.SelectedItem = "Ullysses Uniclops"
				Exit Select
			Case &HA
				cmbVillian2Trinket.SelectedItem = "Billy Bison"
				Exit Select
			Case &HB
				cmbVillian2Trinket.SelectedItem = "Stealth Elf's Gift"
				Exit Select
			Case &HC
				cmbVillian2Trinket.SelectedItem = "Lizard Lilly"
				Exit Select
			Case &HD
				cmbVillian2Trinket.SelectedItem = "Pirate Pinwheel"
				Exit Select
			Case &HE
				cmbVillian2Trinket.SelectedItem = "Bubble Blower"
				Exit Select
			Case &HF
				cmbVillian2Trinket.SelectedItem = "Medal of Heroism"
				Exit Select
			Case &H10
				cmbVillian2Trinket.SelectedItem = "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				cmbVillian2Trinket.SelectedItem = "Medal of Valliance"
				Exit Select
			Case &H12
				cmbVillian2Trinket.SelectedItem = "Medal of Gallantry"
				Exit Select
			Case &H13
				cmbVillian2Trinket.SelectedItem = "Medal of Mettle"
				Exit Select
			Case &H14
				cmbVillian2Trinket.SelectedItem = "Winged Medal of Bravery"
				Exit Select
			Case &H15
				cmbVillian2Trinket.SelectedItem = "Seadog Seashell"
				Exit Select
			Case &H16
				cmbVillian2Trinket.SelectedItem = "Snuckles' Sunflower"
				Exit Select
			Case &H17
				cmbVillian2Trinket.SelectedItem = "Teddy Cyclops"
				Exit Select
			Case &H18
				cmbVillian2Trinket.SelectedItem = "Goo Factory Gear"
				Exit Select
			Case &H19
				cmbVillian2Trinket.SelectedItem = "Elemental Opal"
				Exit Select
			Case &H1A
				cmbVillian2Trinket.SelectedItem = "Elemental Radiant"
				Exit Select
			Case &H1B
				cmbVillian2Trinket.SelectedItem = "Elemental Diamond"
				Exit Select
			Case &H1C
				cmbVillian2Trinket.SelectedItem = "Cyclops Spinner"
				Exit Select
			Case &H1D
				cmbVillian2Trinket.SelectedItem = "Wiliken Windmill"
				Exit Select
			Case &H1E
				cmbVillian2Trinket.SelectedItem = "Time Town Ticker"
				Exit Select
			Case &H1F
				cmbVillian2Trinket.SelectedItem = "Big Bow of Doom"
				Exit Select
			Case &H20
				cmbVillian2Trinket.SelectedItem = "Mabu's Medallion"
				Exit Select
			Case &H21
				cmbVillian2Trinket.SelectedItem = "Spyro's Shield"
				Exit Select
			Case Else
				cmbVillian2Trinket.SelectedItem = "(None)"
				Exit Select
		End Select
		'Load Name from Byte 0xD4
		txtVillian2Name.Text = Load_Name(&HD4)

		'+&H40
		'Villian Three Data is 0x110 to 0x141
		'Ignore 0X130 Block as it's MiFare
		Dim Villian3_ID As Byte = WholeFile(&H110)
		Select Case Villian3_ID
			Case &H0
				cmbVillian3.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian3.SelectedItem = "Chompy Mage"
				Exit Select
			Case &H2
				cmbVillian3.SelectedItem = "Dr. Crankcase"
				Exit Select
			Case &H3
				cmbVillian3.SelectedItem = "Wolfgang"
				Exit Select
			Case &H4
				cmbVillian3.SelectedItem = "Chef Pepper Jack"
				Exit Select
			Case &H5
				cmbVillian3.SelectedItem = "Nightshade"
				Exit Select
			Case &H6
				cmbVillian3.SelectedItem = "Luminous"
				Exit Select
			Case &H7
				cmbVillian3.SelectedItem = "Golden Queen"
				Exit Select
			Case &H8
				cmbVillian3.SelectedItem = "Dreamcatcher"
				Exit Select
			Case &H9
				cmbVillian3.SelectedItem = "Gulper"
				Exit Select
			Case &HA
				cmbVillian3.SelectedItem = "Kaos"
				Exit Select
			Case &HB
				cmbVillian3.SelectedItem = "Cuckoo Clocker"
				Exit Select
			Case &HC
				cmbVillian3.SelectedItem = "Buzzer Beak"
				Exit Select
			Case &HD
				cmbVillian3.SelectedItem = "Shield Shredder"
				Exit Select
			Case &HE
				cmbVillian3.SelectedItem = "Cross Crow"
				Exit Select
			Case &HF
				cmbVillian3.SelectedItem = "Bone Chompy"
				Exit Select
			Case &H10
				cmbVillian3.SelectedItem = "Brawl and Chain"
				Exit Select
			Case &H11
				cmbVillian3.SelectedItem = "Bomb Shell"
				Exit Select
			Case &H12
				cmbVillian3.SelectedItem = "Masker Mind"
				Exit Select
			Case &H13
				cmbVillian3.SelectedItem = "Chill Bill"
				Exit Select
			Case &H14
				cmbVillian3.SelectedItem = "Sheep Creep"
				Exit Select
			Case &H15
				cmbVillian3.SelectedItem = "Shrednaught"
				Exit Select
			Case &H16
				cmbVillian3.SelectedItem = "Chomp Chest"
				Exit Select
			Case &H17
				cmbVillian3.SelectedItem = "Broccoli Guy"
				Exit Select
			Case &H18
				cmbVillian3.SelectedItem = "Rage Mage"
				Exit Select
			Case &H19
				cmbVillian3.SelectedItem = "Lob Goblin"
				Exit Select
			Case &H1A
				cmbVillian3.SelectedItem = "Chompy"
				Exit Select
			Case &H1B
				cmbVillian3.SelectedItem = "Fisticuffs"
				Exit Select
			Case &H1C
				cmbVillian3.SelectedItem = "Trolling Thunder"
				Exit Select
			Case &H1D
				cmbVillian3.SelectedItem = "Hood Sickle"
				Exit Select
			Case &H1E
				cmbVillian3.SelectedItem = "Bruiser Cruiser"
				Exit Select
			Case &H1F
				cmbVillian3.SelectedItem = "Brawlrus"
				Exit Select
			Case &H20
				cmbVillian3.SelectedItem = "Tussle Sprout"
				Exit Select
			Case &H21
				cmbVillian3.SelectedItem = "Krankenstein"
				Exit Select
			Case &H22
				cmbVillian3.SelectedItem = "Scrap Shooter"
				Exit Select
			Case &H23
				cmbVillian3.SelectedItem = "Slobber Trap"
				Exit Select
			Case &H24
				cmbVillian3.SelectedItem = "Grinnade"
				Exit Select
			Case &H25
				cmbVillian3.SelectedItem = "Bad Juju"
				Exit Select
			Case &H26
				cmbVillian3.SelectedItem = "Blaster-Tron"
				Exit Select
			Case &H27
				cmbVillian3.SelectedItem = "Tae Kwon Crow"
				Exit Select
			Case &H28
				cmbVillian3.SelectedItem = "Painyata"
				Exit Select
			Case &H29
				cmbVillian3.SelectedItem = "Smoke Scream"
				Exit Select
			Case &H2A
				cmbVillian3.SelectedItem = "Eye Five"
				Exit Select
			Case &H2B
				cmbVillian3.SelectedItem = "Grave Clobber"
				Exit Select
			Case &H2C
				cmbVillian3.SelectedItem = "Threatpack"
				Exit Select
			Case &H2D
				cmbVillian3.SelectedItem = "Mab Lobs"
				Exit Select
			Case &H2E
				cmbVillian3.SelectedItem = "Eye Scream"
				Exit Select
			Case Else
				cmbVillian3.SelectedItem = "(None)"
				Exit Select
		End Select
		If WholeFile(&H111) = &H1 Then
			chkVillian3Evolved.Checked = True
		End If
		Dim Villian3_Hat As Byte = WholeFile(&H112)
		Select Case Villian3_Hat
			Case &H0
				cmbVillian3Hat.SelectedItem = "(None)"
			Case &HD3
				cmbVillian3Hat.SelectedItem = "Alarm Clock Hat"
			Case &HDA
				cmbVillian3Hat.SelectedItem = "Bat Hat"
			Case &HD4
				cmbVillian3Hat.SelectedItem = "Batter Up Hat"
			Case &H9B
				cmbVillian3Hat.SelectedItem = "Beetle Hat"
			Case &HED
				cmbVillian3Hat.SelectedItem = "Bellhop Hat"
			Case &HC3
				cmbVillian3Hat.SelectedItem = "Bobby"
			Case &H9C
				cmbVillian3Hat.SelectedItem = "Brain Hat"
			Case &H9D
				cmbVillian3Hat.SelectedItem = "Brainiac Hat"
			Case &HEE
				cmbVillian3Hat.SelectedItem = "Bronze Arkeyan Helm"
			Case &H9E
				cmbVillian3Hat.SelectedItem = "Bucket Hat"
			Case &HEA
				cmbVillian3Hat.SelectedItem = "Candle Hat"
			Case &HE8
				cmbVillian3Hat.SelectedItem = "Candy Cane Hat"
			Case &HF6
				cmbVillian3Hat.SelectedItem = "Carnival Hat"
			Case &HA0
				cmbVillian3Hat.SelectedItem = "Ceiling Fan Hat"
			Case &HBB
				cmbVillian3Hat.SelectedItem = "Classic Pot Hat"
			Case &HA3
				cmbVillian3Hat.SelectedItem = "Clown Bowler Hat"
			Case &HA2
				cmbVillian3Hat.SelectedItem = "Clown Classic Hat"
			Case &HF7
				cmbVillian3Hat.SelectedItem = "Coconut Hat"
			Case &HA4
				cmbVillian3Hat.SelectedItem = "Colander Hat"
			Case &HFC
				cmbVillian3Hat.SelectedItem = "Core Of Light Hat"
			Case &HA6
				cmbVillian3Hat.SelectedItem = "Cornucopia Hat"
			Case &HBD
				cmbVillian3Hat.SelectedItem = "Crazy Light Bulb Hat"
			Case &HD6
				cmbVillian3Hat.SelectedItem = "Croissant Hat"
			Case &HA7
				cmbVillian3Hat.SelectedItem = "Cubano Hat"
			Case &HA8
				cmbVillian3Hat.SelectedItem = "Cycling Hat"
			Case &HA9
				cmbVillian3Hat.SelectedItem = "Daisy Crown"
			Case &HEB
				cmbVillian3Hat.SelectedItem = "Dark Helm"
			Case &H9F
				cmbVillian3Hat.SelectedItem = "Desert Crown"
			Case &HAA
				cmbVillian3Hat.SelectedItem = "Dragon Skull"
			Case &HE9
				cmbVillian3Hat.SelectedItem = "Eggshell Hat"
			Case &HCB
				cmbVillian3Hat.SelectedItem = "Extreme Viking Hat"
			Case &HD9
				cmbVillian3Hat.SelectedItem = "Eye of Kaos Hat"
			Case &HDC
				cmbVillian3Hat.SelectedItem = "Firefly Jar"
			Case &HC6
				cmbVillian3Hat.SelectedItem = "Flight Attendant Hat"
			Case &HAE
				cmbVillian3Hat.SelectedItem = "Garrison Hat"
			Case &HAD
				cmbVillian3Hat.SelectedItem = "Generalissimo"
			Case &HE2
				cmbVillian3Hat.SelectedItem = "Gold Arkeyan Helm"
			Case &HAF
				cmbVillian3Hat.SelectedItem = "Gondolier Hat"
			Case &HC4
				cmbVillian3Hat.SelectedItem = "Hedgehog Hat"
			Case &HD5
				cmbVillian3Hat.SelectedItem = "Horns Be With You Hat"
			Case &HB0
				cmbVillian3Hat.SelectedItem = "Hunting Hat"
			Case &HA1
				cmbVillian3Hat.SelectedItem = "Imperial Hat"
			Case &HB1
				cmbVillian3Hat.SelectedItem = "Juicer Hat"
			Case &HA5
				cmbVillian3Hat.SelectedItem = "Kepi Hat"
			Case &HB2
				cmbVillian3Hat.SelectedItem = "Kokoshnik"
			Case &HDB
				cmbVillian3Hat.SelectedItem = "Light Bulb Hat"
			Case &HDE
				cmbVillian3Hat.SelectedItem = "Lighthouse Beacon Hat"
			Case &HAC
				cmbVillian3Hat.SelectedItem = "Lil' Elf Hat"
			Case &HB3
				cmbVillian3Hat.SelectedItem = "Medic Hat"
			Case &HB4
				cmbVillian3Hat.SelectedItem = "Melon Hat"
			Case &HC0
				cmbVillian3Hat.SelectedItem = "Metal Fin Hat"
			Case &HE5
				cmbVillian3Hat.SelectedItem = "Miniature Skylands Hat"
			Case &HFA
				cmbVillian3Hat.SelectedItem = "Molekin Mountain Hat"
			Case &HC7
				cmbVillian3Hat.SelectedItem = "Monday Hat"
			Case &HB5
				cmbVillian3Hat.SelectedItem = "Mountie Hat"
			Case &HE0
				cmbVillian3Hat.SelectedItem = "Night Cap"
			Case &HB6
				cmbVillian3Hat.SelectedItem = "Nurse Hat"
			Case &HFD
				cmbVillian3Hat.SelectedItem = "Octavius Cloptimus Hat"
			Case &HBA
				cmbVillian3Hat.SelectedItem = "Old-Time Movie Hat"
			Case &HAB
				cmbVillian3Hat.SelectedItem = "Outback Hat"
			Case &HB7
				cmbVillian3Hat.SelectedItem = "Palm Hat"
			Case &HB8
				cmbVillian3Hat.SelectedItem = "Paperboy Hat"
			Case &HB9
				cmbVillian3Hat.SelectedItem = "Parrot Nest"
			Case &HEC
				cmbVillian3Hat.SelectedItem = "Planet Hat"
			Case &HD2
				cmbVillian3Hat.SelectedItem = "Pork Pie Hat"
			Case &HE4
				cmbVillian3Hat.SelectedItem = "Pyramid Hat"
			Case &HBC
				cmbVillian3Hat.SelectedItem = "Radar Hat"
			Case &HD8
				cmbVillian3Hat.SelectedItem = "Rainbow Hat"
			Case &HBE
				cmbVillian3Hat.SelectedItem = "Rubber Glove Hat"
			Case &HD1
				cmbVillian3Hat.SelectedItem = "Rude Boy Hat"
			Case &HBF
				cmbVillian3Hat.SelectedItem = "Rugby Hat"
			Case &HCC
				cmbVillian3Hat.SelectedItem = "Scooter Hat"
			Case &HDD
				cmbVillian3Hat.SelectedItem = "Shadow Ghost Hat"
			Case &HC8
				cmbVillian3Hat.SelectedItem = "Sherpa Hat"
			Case &HC2
				cmbVillian3Hat.SelectedItem = "Shower Cap"
			Case &HEF
				cmbVillian3Hat.SelectedItem = "Silver Arkeyan Helm"
			Case &HF3
				cmbVillian3Hat.SelectedItem = "Skipper Hat"
			Case &HC1
				cmbVillian3Hat.SelectedItem = "Sleuth Hat"
			Case &HC5
				cmbVillian3Hat.SelectedItem = "Steampunk Hat"
			Case &HE1
				cmbVillian3Hat.SelectedItem = "Storm Hat"
			Case &HCE
				cmbVillian3Hat.SelectedItem = "Synchronized Swimming Cap"
			Case &HDF
				cmbVillian3Hat.SelectedItem = "Tin Foil Hat"
			Case &HE3
				cmbVillian3Hat.SelectedItem = "Toucan Hat"
			Case &HC9
				cmbVillian3Hat.SelectedItem = "Trash Lid"
			Case &HD0
				cmbVillian3Hat.SelectedItem = "Tribal Hat"
			Case &HCA
				cmbVillian3Hat.SelectedItem = "Turtle Hat"
			Case &HCD
				cmbVillian3Hat.SelectedItem = "Volcano Island Hat"
			Case &HD7
				cmbVillian3Hat.SelectedItem = "Weather Vane Hat"
			Case &HCF
				cmbVillian3Hat.SelectedItem = "William Tell Hat"
			Case Else
				cmbVillian3Hat.SelectedItem = "(None)"
		End Select
		Dim Villian3_Trinket As Byte = WholeFile(&H113)
		Select Case Villian3_Trinket
			Case &H0
				cmbVillian3Trinket.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian3Trinket.SelectedItem = "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				cmbVillian3Trinket.SelectedItem = "Batterson's Bubble"
				Exit Select
			Case &H3
				cmbVillian3Trinket.SelectedItem = "Dark Water Daisy"
				Exit Select
			Case &H4
				cmbVillian3Trinket.SelectedItem = "Vote For Cyclops"
				Exit Select
			Case &H5
				cmbVillian3Trinket.SelectedItem = "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				cmbVillian3Trinket.SelectedItem = "Iris' Iris"
				Exit Select
			Case &H7
				cmbVillian3Trinket.SelectedItem = "Kuckoo Kazoo"
				Exit Select
			Case &H8
				cmbVillian3Trinket.SelectedItem = "Ramses' Rune"
				Exit Select
			Case &H9
				cmbVillian3Trinket.SelectedItem = "Ullysses Uniclops"
				Exit Select
			Case &HA
				cmbVillian3Trinket.SelectedItem = "Billy Bison"
				Exit Select
			Case &HB
				cmbVillian3Trinket.SelectedItem = "Stealth Elf's Gift"
				Exit Select
			Case &HC
				cmbVillian3Trinket.SelectedItem = "Lizard Lilly"
				Exit Select
			Case &HD
				cmbVillian3Trinket.SelectedItem = "Pirate Pinwheel"
				Exit Select
			Case &HE
				cmbVillian3Trinket.SelectedItem = "Bubble Blower"
				Exit Select
			Case &HF
				cmbVillian3Trinket.SelectedItem = "Medal of Heroism"
				Exit Select
			Case &H10
				cmbVillian3Trinket.SelectedItem = "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				cmbVillian3Trinket.SelectedItem = "Medal of Valliance"
				Exit Select
			Case &H12
				cmbVillian3Trinket.SelectedItem = "Medal of Gallantry"
				Exit Select
			Case &H13
				cmbVillian3Trinket.SelectedItem = "Medal of Mettle"
				Exit Select
			Case &H14
				cmbVillian3Trinket.SelectedItem = "Winged Medal of Bravery"
				Exit Select
			Case &H15
				cmbVillian3Trinket.SelectedItem = "Seadog Seashell"
				Exit Select
			Case &H16
				cmbVillian3Trinket.SelectedItem = "Snuckles' Sunflower"
				Exit Select
			Case &H17
				cmbVillian3Trinket.SelectedItem = "Teddy Cyclops"
				Exit Select
			Case &H18
				cmbVillian3Trinket.SelectedItem = "Goo Factory Gear"
				Exit Select
			Case &H19
				cmbVillian3Trinket.SelectedItem = "Elemental Opal"
				Exit Select
			Case &H1A
				cmbVillian3Trinket.SelectedItem = "Elemental Radiant"
				Exit Select
			Case &H1B
				cmbVillian3Trinket.SelectedItem = "Elemental Diamond"
				Exit Select
			Case &H1C
				cmbVillian3Trinket.SelectedItem = "Cyclops Spinner"
				Exit Select
			Case &H1D
				cmbVillian3Trinket.SelectedItem = "Wiliken Windmill"
				Exit Select
			Case &H1E
				cmbVillian3Trinket.SelectedItem = "Time Town Ticker"
				Exit Select
			Case &H1F
				cmbVillian3Trinket.SelectedItem = "Big Bow of Doom"
				Exit Select
			Case &H20
				cmbVillian3Trinket.SelectedItem = "Mabu's Medallion"
				Exit Select
			Case &H21
				cmbVillian3Trinket.SelectedItem = "Spyro's Shield"
				Exit Select
			Case Else
				cmbVillian3Trinket.SelectedItem = "(None)"
				Exit Select
		End Select
		'Load Name from Byte 0x114
		txtVillian3Name.Text = Load_Name(&H114)

		'+&H40
		'Villian Four Data is 0x150 to 0x181
		'Ignore 0x170 Block as it's MiFare
		Dim Villian4_ID As Byte = WholeFile(&H150)
		Select Case Villian4_ID
			Case &H0
				cmbVillian4.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian4.SelectedItem = "Chompy Mage"
				Exit Select
			Case &H2
				cmbVillian4.SelectedItem = "Dr. Crankcase"
				Exit Select
			Case &H3
				cmbVillian4.SelectedItem = "Wolfgang"
				Exit Select
			Case &H4
				cmbVillian4.SelectedItem = "Chef Pepper Jack"
				Exit Select
			Case &H5
				cmbVillian4.SelectedItem = "Nightshade"
				Exit Select
			Case &H6
				cmbVillian4.SelectedItem = "Luminous"
				Exit Select
			Case &H7
				cmbVillian4.SelectedItem = "Golden Queen"
				Exit Select
			Case &H8
				cmbVillian4.SelectedItem = "Dreamcatcher"
				Exit Select
			Case &H9
				cmbVillian4.SelectedItem = "Gulper"
				Exit Select
			Case &HA
				cmbVillian4.SelectedItem = "Kaos"
				Exit Select
			Case &HB
				cmbVillian4.SelectedItem = "Cuckoo Clocker"
				Exit Select
			Case &HC
				cmbVillian4.SelectedItem = "Buzzer Beak"
				Exit Select
			Case &HD
				cmbVillian4.SelectedItem = "Shield Shredder"
				Exit Select
			Case &HE
				cmbVillian4.SelectedItem = "Cross Crow"
				Exit Select
			Case &HF
				cmbVillian4.SelectedItem = "Bone Chompy"
				Exit Select
			Case &H10
				cmbVillian4.SelectedItem = "Brawl and Chain"
				Exit Select
			Case &H11
				cmbVillian4.SelectedItem = "Bomb Shell"
				Exit Select
			Case &H12
				cmbVillian4.SelectedItem = "Masker Mind"
				Exit Select
			Case &H13
				cmbVillian4.SelectedItem = "Chill Bill"
				Exit Select
			Case &H14
				cmbVillian4.SelectedItem = "Sheep Creep"
				Exit Select
			Case &H15
				cmbVillian4.SelectedItem = "Shrednaught"
				Exit Select
			Case &H16
				cmbVillian4.SelectedItem = "Chomp Chest"
				Exit Select
			Case &H17
				cmbVillian4.SelectedItem = "Broccoli Guy"
				Exit Select
			Case &H18
				cmbVillian4.SelectedItem = "Rage Mage"
				Exit Select
			Case &H19
				cmbVillian4.SelectedItem = "Lob Goblin"
				Exit Select
			Case &H1A
				cmbVillian4.SelectedItem = "Chompy"
				Exit Select
			Case &H1B
				cmbVillian4.SelectedItem = "Fisticuffs"
				Exit Select
			Case &H1C
				cmbVillian4.SelectedItem = "Trolling Thunder"
				Exit Select
			Case &H1D
				cmbVillian4.SelectedItem = "Hood Sickle"
				Exit Select
			Case &H1E
				cmbVillian4.SelectedItem = "Bruiser Cruiser"
				Exit Select
			Case &H1F
				cmbVillian4.SelectedItem = "Brawlrus"
				Exit Select
			Case &H20
				cmbVillian4.SelectedItem = "Tussle Sprout"
				Exit Select
			Case &H21
				cmbVillian4.SelectedItem = "Krankenstein"
				Exit Select
			Case &H22
				cmbVillian4.SelectedItem = "Scrap Shooter"
				Exit Select
			Case &H23
				cmbVillian4.SelectedItem = "Slobber Trap"
				Exit Select
			Case &H24
				cmbVillian4.SelectedItem = "Grinnade"
				Exit Select
			Case &H25
				cmbVillian4.SelectedItem = "Bad Juju"
				Exit Select
			Case &H26
				cmbVillian4.SelectedItem = "Blaster-Tron"
				Exit Select
			Case &H27
				cmbVillian4.SelectedItem = "Tae Kwon Crow"
				Exit Select
			Case &H28
				cmbVillian4.SelectedItem = "Painyata"
				Exit Select
			Case &H29
				cmbVillian4.SelectedItem = "Smoke Scream"
				Exit Select
			Case &H2A
				cmbVillian4.SelectedItem = "Eye Five"
				Exit Select
			Case &H2B
				cmbVillian4.SelectedItem = "Grave Clobber"
				Exit Select
			Case &H2C
				cmbVillian4.SelectedItem = "Threatpack"
				Exit Select
			Case &H2D
				cmbVillian4.SelectedItem = "Mab Lobs"
				Exit Select
			Case &H2E
				cmbVillian4.SelectedItem = "Eye Scream"
				Exit Select
			Case Else
				cmbVillian4.SelectedItem = "(None)"
				Exit Select
		End Select
		If WholeFile(&H151) = &H1 Then
			chkVillian4Evolved.Checked = True
		End If
		Dim Villian4_Hat As Byte = WholeFile(&H152)
		Select Case Villian4_Hat
			Case &H0
				cmbVillian4Hat.SelectedItem = "(None)"
			Case &HD3
				cmbVillian4Hat.SelectedItem = "Alarm Clock Hat"
			Case &HDA
				cmbVillian4Hat.SelectedItem = "Bat Hat"
			Case &HD4
				cmbVillian4Hat.SelectedItem = "Batter Up Hat"
			Case &H9B
				cmbVillian4Hat.SelectedItem = "Beetle Hat"
			Case &HED
				cmbVillian4Hat.SelectedItem = "Bellhop Hat"
			Case &HC3
				cmbVillian4Hat.SelectedItem = "Bobby"
			Case &H9C
				cmbVillian4Hat.SelectedItem = "Brain Hat"
			Case &H9D
				cmbVillian4Hat.SelectedItem = "Brainiac Hat"
			Case &HEE
				cmbVillian4Hat.SelectedItem = "Bronze Arkeyan Helm"
			Case &H9E
				cmbVillian4Hat.SelectedItem = "Bucket Hat"
			Case &HEA
				cmbVillian4Hat.SelectedItem = "Candle Hat"
			Case &HE8
				cmbVillian4Hat.SelectedItem = "Candy Cane Hat"
			Case &HF6
				cmbVillian4Hat.SelectedItem = "Carnival Hat"
			Case &HA0
				cmbVillian4Hat.SelectedItem = "Ceiling Fan Hat"
			Case &HBB
				cmbVillian4Hat.SelectedItem = "Classic Pot Hat"
			Case &HA3
				cmbVillian4Hat.SelectedItem = "Clown Bowler Hat"
			Case &HA2
				cmbVillian4Hat.SelectedItem = "Clown Classic Hat"
			Case &HF7
				cmbVillian4Hat.SelectedItem = "Coconut Hat"
			Case &HA4
				cmbVillian4Hat.SelectedItem = "Colander Hat"
			Case &HFC
				cmbVillian4Hat.SelectedItem = "Core Of Light Hat"
			Case &HA6
				cmbVillian4Hat.SelectedItem = "Cornucopia Hat"
			Case &HBD
				cmbVillian4Hat.SelectedItem = "Crazy Light Bulb Hat"
			Case &HD6
				cmbVillian4Hat.SelectedItem = "Croissant Hat"
			Case &HA7
				cmbVillian4Hat.SelectedItem = "Cubano Hat"
			Case &HA8
				cmbVillian4Hat.SelectedItem = "Cycling Hat"
			Case &HA9
				cmbVillian4Hat.SelectedItem = "Daisy Crown"
			Case &HEB
				cmbVillian4Hat.SelectedItem = "Dark Helm"
			Case &H9F
				cmbVillian4Hat.SelectedItem = "Desert Crown"
			Case &HAA
				cmbVillian4Hat.SelectedItem = "Dragon Skull"
			Case &HE9
				cmbVillian4Hat.SelectedItem = "Eggshell Hat"
			Case &HCB
				cmbVillian4Hat.SelectedItem = "Extreme Viking Hat"
			Case &HD9
				cmbVillian4Hat.SelectedItem = "Eye of Kaos Hat"
			Case &HDC
				cmbVillian4Hat.SelectedItem = "Firefly Jar"
			Case &HC6
				cmbVillian4Hat.SelectedItem = "Flight Attendant Hat"
			Case &HAE
				cmbVillian4Hat.SelectedItem = "Garrison Hat"
			Case &HAD
				cmbVillian4Hat.SelectedItem = "Generalissimo"
			Case &HE2
				cmbVillian4Hat.SelectedItem = "Gold Arkeyan Helm"
			Case &HAF
				cmbVillian4Hat.SelectedItem = "Gondolier Hat"
			Case &HC4
				cmbVillian4Hat.SelectedItem = "Hedgehog Hat"
			Case &HD5
				cmbVillian4Hat.SelectedItem = "Horns Be With You Hat"
			Case &HB0
				cmbVillian4Hat.SelectedItem = "Hunting Hat"
			Case &HA1
				cmbVillian4Hat.SelectedItem = "Imperial Hat"
			Case &HB1
				cmbVillian4Hat.SelectedItem = "Juicer Hat"
			Case &HA5
				cmbVillian4Hat.SelectedItem = "Kepi Hat"
			Case &HB2
				cmbVillian4Hat.SelectedItem = "Kokoshnik"
			Case &HDB
				cmbVillian4Hat.SelectedItem = "Light Bulb Hat"
			Case &HDE
				cmbVillian4Hat.SelectedItem = "Lighthouse Beacon Hat"
			Case &HAC
				cmbVillian4Hat.SelectedItem = "Lil' Elf Hat"
			Case &HB3
				cmbVillian4Hat.SelectedItem = "Medic Hat"
			Case &HB4
				cmbVillian4Hat.SelectedItem = "Melon Hat"
			Case &HC0
				cmbVillian4Hat.SelectedItem = "Metal Fin Hat"
			Case &HE5
				cmbVillian4Hat.SelectedItem = "Miniature Skylands Hat"
			Case &HFA
				cmbVillian4Hat.SelectedItem = "Molekin Mountain Hat"
			Case &HC7
				cmbVillian4Hat.SelectedItem = "Monday Hat"
			Case &HB5
				cmbVillian4Hat.SelectedItem = "Mountie Hat"
			Case &HE0
				cmbVillian4Hat.SelectedItem = "Night Cap"
			Case &HB6
				cmbVillian4Hat.SelectedItem = "Nurse Hat"
			Case &HFD
				cmbVillian4Hat.SelectedItem = "Octavius Cloptimus Hat"
			Case &HBA
				cmbVillian4Hat.SelectedItem = "Old-Time Movie Hat"
			Case &HAB
				cmbVillian4Hat.SelectedItem = "Outback Hat"
			Case &HB7
				cmbVillian4Hat.SelectedItem = "Palm Hat"
			Case &HB8
				cmbVillian4Hat.SelectedItem = "Paperboy Hat"
			Case &HB9
				cmbVillian4Hat.SelectedItem = "Parrot Nest"
			Case &HEC
				cmbVillian4Hat.SelectedItem = "Planet Hat"
			Case &HD2
				cmbVillian4Hat.SelectedItem = "Pork Pie Hat"
			Case &HE4
				cmbVillian4Hat.SelectedItem = "Pyramid Hat"
			Case &HBC
				cmbVillian4Hat.SelectedItem = "Radar Hat"
			Case &HD8
				cmbVillian4Hat.SelectedItem = "Rainbow Hat"
			Case &HBE
				cmbVillian4Hat.SelectedItem = "Rubber Glove Hat"
			Case &HD1
				cmbVillian4Hat.SelectedItem = "Rude Boy Hat"
			Case &HBF
				cmbVillian4Hat.SelectedItem = "Rugby Hat"
			Case &HCC
				cmbVillian4Hat.SelectedItem = "Scooter Hat"
			Case &HDD
				cmbVillian4Hat.SelectedItem = "Shadow Ghost Hat"
			Case &HC8
				cmbVillian4Hat.SelectedItem = "Sherpa Hat"
			Case &HC2
				cmbVillian4Hat.SelectedItem = "Shower Cap"
			Case &HEF
				cmbVillian4Hat.SelectedItem = "Silver Arkeyan Helm"
			Case &HF3
				cmbVillian4Hat.SelectedItem = "Skipper Hat"
			Case &HC1
				cmbVillian4Hat.SelectedItem = "Sleuth Hat"
			Case &HC5
				cmbVillian4Hat.SelectedItem = "Steampunk Hat"
			Case &HE1
				cmbVillian4Hat.SelectedItem = "Storm Hat"
			Case &HCE
				cmbVillian4Hat.SelectedItem = "Synchronized Swimming Cap"
			Case &HDF
				cmbVillian4Hat.SelectedItem = "Tin Foil Hat"
			Case &HE3
				cmbVillian4Hat.SelectedItem = "Toucan Hat"
			Case &HC9
				cmbVillian4Hat.SelectedItem = "Trash Lid"
			Case &HD0
				cmbVillian4Hat.SelectedItem = "Tribal Hat"
			Case &HCA
				cmbVillian4Hat.SelectedItem = "Turtle Hat"
			Case &HCD
				cmbVillian4Hat.SelectedItem = "Volcano Island Hat"
			Case &HD7
				cmbVillian4Hat.SelectedItem = "Weather Vane Hat"
			Case &HCF
				cmbVillian4Hat.SelectedItem = "William Tell Hat"
			Case Else
				cmbVillian4Hat.SelectedItem = "(None)"
		End Select
		Dim Villian4_Trinket As Byte = WholeFile(&H153)
		Select Case Villian4_Trinket
			Case &H0
				cmbVillian4Trinket.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian4Trinket.SelectedItem = "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				cmbVillian4Trinket.SelectedItem = "Batterson's Bubble"
				Exit Select
			Case &H3
				cmbVillian4Trinket.SelectedItem = "Dark Water Daisy"
				Exit Select
			Case &H4
				cmbVillian4Trinket.SelectedItem = "Vote For Cyclops"
				Exit Select
			Case &H5
				cmbVillian4Trinket.SelectedItem = "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				cmbVillian4Trinket.SelectedItem = "Iris' Iris"
				Exit Select
			Case &H7
				cmbVillian4Trinket.SelectedItem = "Kuckoo Kazoo"
				Exit Select
			Case &H8
				cmbVillian4Trinket.SelectedItem = "Ramses' Rune"
				Exit Select
			Case &H9
				cmbVillian4Trinket.SelectedItem = "Ullysses Uniclops"
				Exit Select
			Case &HA
				cmbVillian4Trinket.SelectedItem = "Billy Bison"
				Exit Select
			Case &HB
				cmbVillian4Trinket.SelectedItem = "Stealth Elf's Gift"
				Exit Select
			Case &HC
				cmbVillian4Trinket.SelectedItem = "Lizard Lilly"
				Exit Select
			Case &HD
				cmbVillian4Trinket.SelectedItem = "Pirate Pinwheel"
				Exit Select
			Case &HE
				cmbVillian4Trinket.SelectedItem = "Bubble Blower"
				Exit Select
			Case &HF
				cmbVillian4Trinket.SelectedItem = "Medal of Heroism"
				Exit Select
			Case &H10
				cmbVillian4Trinket.SelectedItem = "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				cmbVillian4Trinket.SelectedItem = "Medal of Valliance"
				Exit Select
			Case &H12
				cmbVillian4Trinket.SelectedItem = "Medal of Gallantry"
				Exit Select
			Case &H13
				cmbVillian4Trinket.SelectedItem = "Medal of Mettle"
				Exit Select
			Case &H14
				cmbVillian4Trinket.SelectedItem = "Winged Medal of Bravery"
				Exit Select
			Case &H15
				cmbVillian4Trinket.SelectedItem = "Seadog Seashell"
				Exit Select
			Case &H16
				cmbVillian4Trinket.SelectedItem = "Snuckles' Sunflower"
				Exit Select
			Case &H17
				cmbVillian4Trinket.SelectedItem = "Teddy Cyclops"
				Exit Select
			Case &H18
				cmbVillian4Trinket.SelectedItem = "Goo Factory Gear"
				Exit Select
			Case &H19
				cmbVillian4Trinket.SelectedItem = "Elemental Opal"
				Exit Select
			Case &H1A
				cmbVillian4Trinket.SelectedItem = "Elemental Radiant"
				Exit Select
			Case &H1B
				cmbVillian4Trinket.SelectedItem = "Elemental Diamond"
				Exit Select
			Case &H1C
				cmbVillian4Trinket.SelectedItem = "Cyclops Spinner"
				Exit Select
			Case &H1D
				cmbVillian4Trinket.SelectedItem = "Wiliken Windmill"
				Exit Select
			Case &H1E
				cmbVillian4Trinket.SelectedItem = "Time Town Ticker"
				Exit Select
			Case &H1F
				cmbVillian4Trinket.SelectedItem = "Big Bow of Doom"
				Exit Select
			Case &H20
				cmbVillian4Trinket.SelectedItem = "Mabu's Medallion"
				Exit Select
			Case &H21
				cmbVillian4Trinket.SelectedItem = "Spyro's Shield"
				Exit Select
			Case Else
				cmbVillian4Trinket.SelectedItem = "(None)"
				Exit Select
		End Select
		'Load Name from Byte 0x154
		txtVillian4Name.Text = Load_Name(&H154)

		'+&H40
		'Villian Five Data is 0x190 to 0x1C1
		'Ignore 0x1B0 Block as it's MiFare
		Dim Villian5_ID As Byte = WholeFile(&H190)
		Select Case Villian5_ID
			Case &H0
				cmbVillian5.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian5.SelectedItem = "Chompy Mage"
				Exit Select
			Case &H2
				cmbVillian5.SelectedItem = "Dr. Crankcase"
				Exit Select
			Case &H3
				cmbVillian5.SelectedItem = "Wolfgang"
				Exit Select
			Case &H4
				cmbVillian5.SelectedItem = "Chef Pepper Jack"
				Exit Select
			Case &H5
				cmbVillian5.SelectedItem = "Nightshade"
				Exit Select
			Case &H6
				cmbVillian5.SelectedItem = "Luminous"
				Exit Select
			Case &H7
				cmbVillian5.SelectedItem = "Golden Queen"
				Exit Select
			Case &H8
				cmbVillian5.SelectedItem = "Dreamcatcher"
				Exit Select
			Case &H9
				cmbVillian5.SelectedItem = "Gulper"
				Exit Select
			Case &HA
				cmbVillian5.SelectedItem = "Kaos"
				Exit Select
			Case &HB
				cmbVillian5.SelectedItem = "Cuckoo Clocker"
				Exit Select
			Case &HC
				cmbVillian5.SelectedItem = "Buzzer Beak"
				Exit Select
			Case &HD
				cmbVillian5.SelectedItem = "Shield Shredder"
				Exit Select
			Case &HE
				cmbVillian5.SelectedItem = "Cross Crow"
				Exit Select
			Case &HF
				cmbVillian5.SelectedItem = "Bone Chompy"
				Exit Select
			Case &H10
				cmbVillian5.SelectedItem = "Brawl and Chain"
				Exit Select
			Case &H11
				cmbVillian5.SelectedItem = "Bomb Shell"
				Exit Select
			Case &H12
				cmbVillian5.SelectedItem = "Masker Mind"
				Exit Select
			Case &H13
				cmbVillian5.SelectedItem = "Chill Bill"
				Exit Select
			Case &H14
				cmbVillian5.SelectedItem = "Sheep Creep"
				Exit Select
			Case &H15
				cmbVillian5.SelectedItem = "Shrednaught"
				Exit Select
			Case &H16
				cmbVillian5.SelectedItem = "Chomp Chest"
				Exit Select
			Case &H17
				cmbVillian5.SelectedItem = "Broccoli Guy"
				Exit Select
			Case &H18
				cmbVillian5.SelectedItem = "Rage Mage"
				Exit Select
			Case &H19
				cmbVillian5.SelectedItem = "Lob Goblin"
				Exit Select
			Case &H1A
				cmbVillian5.SelectedItem = "Chompy"
				Exit Select
			Case &H1B
				cmbVillian5.SelectedItem = "Fisticuffs"
				Exit Select
			Case &H1C
				cmbVillian5.SelectedItem = "Trolling Thunder"
				Exit Select
			Case &H1D
				cmbVillian5.SelectedItem = "Hood Sickle"
				Exit Select
			Case &H1E
				cmbVillian5.SelectedItem = "Bruiser Cruiser"
				Exit Select
			Case &H1F
				cmbVillian5.SelectedItem = "Brawlrus"
				Exit Select
			Case &H20
				cmbVillian5.SelectedItem = "Tussle Sprout"
				Exit Select
			Case &H21
				cmbVillian5.SelectedItem = "Krankenstein"
				Exit Select
			Case &H22
				cmbVillian5.SelectedItem = "Scrap Shooter"
				Exit Select
			Case &H23
				cmbVillian5.SelectedItem = "Slobber Trap"
				Exit Select
			Case &H24
				cmbVillian5.SelectedItem = "Grinnade"
				Exit Select
			Case &H25
				cmbVillian5.SelectedItem = "Bad Juju"
				Exit Select
			Case &H26
				cmbVillian5.SelectedItem = "Blaster-Tron"
				Exit Select
			Case &H27
				cmbVillian5.SelectedItem = "Tae Kwon Crow"
				Exit Select
			Case &H28
				cmbVillian5.SelectedItem = "Painyata"
				Exit Select
			Case &H29
				cmbVillian5.SelectedItem = "Smoke Scream"
				Exit Select
			Case &H2A
				cmbVillian5.SelectedItem = "Eye Five"
				Exit Select
			Case &H2B
				cmbVillian5.SelectedItem = "Grave Clobber"
				Exit Select
			Case &H2C
				cmbVillian5.SelectedItem = "Threatpack"
				Exit Select
			Case &H2D
				cmbVillian5.SelectedItem = "Mab Lobs"
				Exit Select
			Case &H2E
				cmbVillian5.SelectedItem = "Eye Scream"
				Exit Select
			Case Else
				cmbVillian5.SelectedItem = "(None)"
				Exit Select
		End Select
		If WholeFile(&H191) = &H1 Then
			chkVillian5Evolved.Checked = True
		End If
		Dim Villian5_Hat As Byte = WholeFile(&H192)
		Select Case Villian5_Hat
			Case &H0
				cmbVillian5Hat.SelectedItem = "(None)"
			Case &HD3
				cmbVillian5Hat.SelectedItem = "Alarm Clock Hat"
			Case &HDA
				cmbVillian5Hat.SelectedItem = "Bat Hat"
			Case &HD4
				cmbVillian5Hat.SelectedItem = "Batter Up Hat"
			Case &H9B
				cmbVillian5Hat.SelectedItem = "Beetle Hat"
			Case &HED
				cmbVillian5Hat.SelectedItem = "Bellhop Hat"
			Case &HC3
				cmbVillian5Hat.SelectedItem = "Bobby"
			Case &H9C
				cmbVillian5Hat.SelectedItem = "Brain Hat"
			Case &H9D
				cmbVillian5Hat.SelectedItem = "Brainiac Hat"
			Case &HEE
				cmbVillian5Hat.SelectedItem = "Bronze Arkeyan Helm"
			Case &H9E
				cmbVillian5Hat.SelectedItem = "Bucket Hat"
			Case &HEA
				cmbVillian5Hat.SelectedItem = "Candle Hat"
			Case &HE8
				cmbVillian5Hat.SelectedItem = "Candy Cane Hat"
			Case &HF6
				cmbVillian5Hat.SelectedItem = "Carnival Hat"
			Case &HA0
				cmbVillian5Hat.SelectedItem = "Ceiling Fan Hat"
			Case &HBB
				cmbVillian5Hat.SelectedItem = "Classic Pot Hat"
			Case &HA3
				cmbVillian5Hat.SelectedItem = "Clown Bowler Hat"
			Case &HA2
				cmbVillian5Hat.SelectedItem = "Clown Classic Hat"
			Case &HF7
				cmbVillian5Hat.SelectedItem = "Coconut Hat"
			Case &HA4
				cmbVillian5Hat.SelectedItem = "Colander Hat"
			Case &HFC
				cmbVillian5Hat.SelectedItem = "Core Of Light Hat"
			Case &HA6
				cmbVillian5Hat.SelectedItem = "Cornucopia Hat"
			Case &HBD
				cmbVillian5Hat.SelectedItem = "Crazy Light Bulb Hat"
			Case &HD6
				cmbVillian5Hat.SelectedItem = "Croissant Hat"
			Case &HA7
				cmbVillian5Hat.SelectedItem = "Cubano Hat"
			Case &HA8
				cmbVillian5Hat.SelectedItem = "Cycling Hat"
			Case &HA9
				cmbVillian5Hat.SelectedItem = "Daisy Crown"
			Case &HEB
				cmbVillian5Hat.SelectedItem = "Dark Helm"
			Case &H9F
				cmbVillian5Hat.SelectedItem = "Desert Crown"
			Case &HAA
				cmbVillian5Hat.SelectedItem = "Dragon Skull"
			Case &HE9
				cmbVillian5Hat.SelectedItem = "Eggshell Hat"
			Case &HCB
				cmbVillian5Hat.SelectedItem = "Extreme Viking Hat"
			Case &HD9
				cmbVillian5Hat.SelectedItem = "Eye of Kaos Hat"
			Case &HDC
				cmbVillian5Hat.SelectedItem = "Firefly Jar"
			Case &HC6
				cmbVillian5Hat.SelectedItem = "Flight Attendant Hat"
			Case &HAE
				cmbVillian5Hat.SelectedItem = "Garrison Hat"
			Case &HAD
				cmbVillian5Hat.SelectedItem = "Generalissimo"
			Case &HE2
				cmbVillian5Hat.SelectedItem = "Gold Arkeyan Helm"
			Case &HAF
				cmbVillian5Hat.SelectedItem = "Gondolier Hat"
			Case &HC4
				cmbVillian5Hat.SelectedItem = "Hedgehog Hat"
			Case &HD5
				cmbVillian5Hat.SelectedItem = "Horns Be With You Hat"
			Case &HB0
				cmbVillian5Hat.SelectedItem = "Hunting Hat"
			Case &HA1
				cmbVillian5Hat.SelectedItem = "Imperial Hat"
			Case &HB1
				cmbVillian5Hat.SelectedItem = "Juicer Hat"
			Case &HA5
				cmbVillian5Hat.SelectedItem = "Kepi Hat"
			Case &HB2
				cmbVillian5Hat.SelectedItem = "Kokoshnik"
			Case &HDB
				cmbVillian5Hat.SelectedItem = "Light Bulb Hat"
			Case &HDE
				cmbVillian5Hat.SelectedItem = "Lighthouse Beacon Hat"
			Case &HAC
				cmbVillian5Hat.SelectedItem = "Lil' Elf Hat"
			Case &HB3
				cmbVillian5Hat.SelectedItem = "Medic Hat"
			Case &HB4
				cmbVillian5Hat.SelectedItem = "Melon Hat"
			Case &HC0
				cmbVillian5Hat.SelectedItem = "Metal Fin Hat"
			Case &HE5
				cmbVillian5Hat.SelectedItem = "Miniature Skylands Hat"
			Case &HFA
				cmbVillian5Hat.SelectedItem = "Molekin Mountain Hat"
			Case &HC7
				cmbVillian5Hat.SelectedItem = "Monday Hat"
			Case &HB5
				cmbVillian5Hat.SelectedItem = "Mountie Hat"
			Case &HE0
				cmbVillian5Hat.SelectedItem = "Night Cap"
			Case &HB6
				cmbVillian5Hat.SelectedItem = "Nurse Hat"
			Case &HFD
				cmbVillian5Hat.SelectedItem = "Octavius Cloptimus Hat"
			Case &HBA
				cmbVillian5Hat.SelectedItem = "Old-Time Movie Hat"
			Case &HAB
				cmbVillian5Hat.SelectedItem = "Outback Hat"
			Case &HB7
				cmbVillian5Hat.SelectedItem = "Palm Hat"
			Case &HB8
				cmbVillian5Hat.SelectedItem = "Paperboy Hat"
			Case &HB9
				cmbVillian5Hat.SelectedItem = "Parrot Nest"
			Case &HEC
				cmbVillian5Hat.SelectedItem = "Planet Hat"
			Case &HD2
				cmbVillian5Hat.SelectedItem = "Pork Pie Hat"
			Case &HE4
				cmbVillian5Hat.SelectedItem = "Pyramid Hat"
			Case &HBC
				cmbVillian5Hat.SelectedItem = "Radar Hat"
			Case &HD8
				cmbVillian5Hat.SelectedItem = "Rainbow Hat"
			Case &HBE
				cmbVillian5Hat.SelectedItem = "Rubber Glove Hat"
			Case &HD1
				cmbVillian5Hat.SelectedItem = "Rude Boy Hat"
			Case &HBF
				cmbVillian5Hat.SelectedItem = "Rugby Hat"
			Case &HCC
				cmbVillian5Hat.SelectedItem = "Scooter Hat"
			Case &HDD
				cmbVillian5Hat.SelectedItem = "Shadow Ghost Hat"
			Case &HC8
				cmbVillian5Hat.SelectedItem = "Sherpa Hat"
			Case &HC2
				cmbVillian5Hat.SelectedItem = "Shower Cap"
			Case &HEF
				cmbVillian5Hat.SelectedItem = "Silver Arkeyan Helm"
			Case &HF3
				cmbVillian5Hat.SelectedItem = "Skipper Hat"
			Case &HC1
				cmbVillian5Hat.SelectedItem = "Sleuth Hat"
			Case &HC5
				cmbVillian5Hat.SelectedItem = "Steampunk Hat"
			Case &HE1
				cmbVillian5Hat.SelectedItem = "Storm Hat"
			Case &HCE
				cmbVillian5Hat.SelectedItem = "Synchronized Swimming Cap"
			Case &HDF
				cmbVillian5Hat.SelectedItem = "Tin Foil Hat"
			Case &HE3
				cmbVillian5Hat.SelectedItem = "Toucan Hat"
			Case &HC9
				cmbVillian5Hat.SelectedItem = "Trash Lid"
			Case &HD0
				cmbVillian5Hat.SelectedItem = "Tribal Hat"
			Case &HCA
				cmbVillian5Hat.SelectedItem = "Turtle Hat"
			Case &HCD
				cmbVillian5Hat.SelectedItem = "Volcano Island Hat"
			Case &HD7
				cmbVillian5Hat.SelectedItem = "Weather Vane Hat"
			Case &HCF
				cmbVillian5Hat.SelectedItem = "William Tell Hat"
			Case Else
				cmbVillian5Hat.SelectedItem = "(None)"
		End Select
		Dim Villian5_Trinket As Byte = WholeFile(&H193)
		Select Case Villian5_Trinket
			Case &H0
				cmbVillian5Trinket.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian5Trinket.SelectedItem = "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				cmbVillian5Trinket.SelectedItem = "Batterson's Bubble"
				Exit Select
			Case &H3
				cmbVillian5Trinket.SelectedItem = "Dark Water Daisy"
				Exit Select
			Case &H4
				cmbVillian5Trinket.SelectedItem = "Vote For Cyclops"
				Exit Select
			Case &H5
				cmbVillian5Trinket.SelectedItem = "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				cmbVillian5Trinket.SelectedItem = "Iris' Iris"
				Exit Select
			Case &H7
				cmbVillian5Trinket.SelectedItem = "Kuckoo Kazoo"
				Exit Select
			Case &H8
				cmbVillian5Trinket.SelectedItem = "Ramses' Rune"
				Exit Select
			Case &H9
				cmbVillian5Trinket.SelectedItem = "Ullysses Uniclops"
				Exit Select
			Case &HA
				cmbVillian5Trinket.SelectedItem = "Billy Bison"
				Exit Select
			Case &HB
				cmbVillian5Trinket.SelectedItem = "Stealth Elf's Gift"
				Exit Select
			Case &HC
				cmbVillian5Trinket.SelectedItem = "Lizard Lilly"
				Exit Select
			Case &HD
				cmbVillian5Trinket.SelectedItem = "Pirate Pinwheel"
				Exit Select
			Case &HE
				cmbVillian5Trinket.SelectedItem = "Bubble Blower"
				Exit Select
			Case &HF
				cmbVillian5Trinket.SelectedItem = "Medal of Heroism"
				Exit Select
			Case &H10
				cmbVillian5Trinket.SelectedItem = "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				cmbVillian5Trinket.SelectedItem = "Medal of Valliance"
				Exit Select
			Case &H12
				cmbVillian5Trinket.SelectedItem = "Medal of Gallantry"
				Exit Select
			Case &H13
				cmbVillian5Trinket.SelectedItem = "Medal of Mettle"
				Exit Select
			Case &H14
				cmbVillian5Trinket.SelectedItem = "Winged Medal of Bravery"
				Exit Select
			Case &H15
				cmbVillian5Trinket.SelectedItem = "Seadog Seashell"
				Exit Select
			Case &H16
				cmbVillian5Trinket.SelectedItem = "Snuckles' Sunflower"
				Exit Select
			Case &H17
				cmbVillian5Trinket.SelectedItem = "Teddy Cyclops"
				Exit Select
			Case &H18
				cmbVillian5Trinket.SelectedItem = "Goo Factory Gear"
				Exit Select
			Case &H19
				cmbVillian5Trinket.SelectedItem = "Elemental Opal"
				Exit Select
			Case &H1A
				cmbVillian5Trinket.SelectedItem = "Elemental Radiant"
				Exit Select
			Case &H1B
				cmbVillian5Trinket.SelectedItem = "Elemental Diamond"
				Exit Select
			Case &H1C
				cmbVillian5Trinket.SelectedItem = "Cyclops Spinner"
				Exit Select
			Case &H1D
				cmbVillian5Trinket.SelectedItem = "Wiliken Windmill"
				Exit Select
			Case &H1E
				cmbVillian5Trinket.SelectedItem = "Time Town Ticker"
				Exit Select
			Case &H1F
				cmbVillian5Trinket.SelectedItem = "Big Bow of Doom"
				Exit Select
			Case &H20
				cmbVillian5Trinket.SelectedItem = "Mabu's Medallion"
				Exit Select
			Case &H21
				cmbVillian5Trinket.SelectedItem = "Spyro's Shield"
				Exit Select
			Case Else
				cmbVillian5Trinket.SelectedItem = "(None)"
				Exit Select
		End Select
		'Load Name from Byte 0x194
		txtVillian5Name.Text = Load_Name(&H194)

		'+&H40
		'Villian Six Data is 0x1D0 to 0x201
		'Ignore 0x200 Block as it's MiFare
		Dim Villian6_ID As Byte = WholeFile(&H1D0)
		Select Case Villian6_ID
			Case &H0
				cmbVillian6.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian6.SelectedItem = "Chompy Mage"
				Exit Select
			Case &H2
				cmbVillian6.SelectedItem = "Dr. Crankcase"
				Exit Select
			Case &H3
				cmbVillian6.SelectedItem = "Wolfgang"
				Exit Select
			Case &H4
				cmbVillian6.SelectedItem = "Chef Pepper Jack"
				Exit Select
			Case &H5
				cmbVillian6.SelectedItem = "Nightshade"
				Exit Select
			Case &H6
				cmbVillian6.SelectedItem = "Luminous"
				Exit Select
			Case &H7
				cmbVillian6.SelectedItem = "Golden Queen"
				Exit Select
			Case &H8
				cmbVillian6.SelectedItem = "Dreamcatcher"
				Exit Select
			Case &H9
				cmbVillian6.SelectedItem = "Gulper"
				Exit Select
			Case &HA
				cmbVillian6.SelectedItem = "Kaos"
				Exit Select
			Case &HB
				cmbVillian6.SelectedItem = "Cuckoo Clocker"
				Exit Select
			Case &HC
				cmbVillian6.SelectedItem = "Buzzer Beak"
				Exit Select
			Case &HD
				cmbVillian6.SelectedItem = "Shield Shredder"
				Exit Select
			Case &HE
				cmbVillian6.SelectedItem = "Cross Crow"
				Exit Select
			Case &HF
				cmbVillian6.SelectedItem = "Bone Chompy"
				Exit Select
			Case &H10
				cmbVillian6.SelectedItem = "Brawl and Chain"
				Exit Select
			Case &H11
				cmbVillian6.SelectedItem = "Bomb Shell"
				Exit Select
			Case &H12
				cmbVillian6.SelectedItem = "Masker Mind"
				Exit Select
			Case &H13
				cmbVillian6.SelectedItem = "Chill Bill"
				Exit Select
			Case &H14
				cmbVillian6.SelectedItem = "Sheep Creep"
				Exit Select
			Case &H15
				cmbVillian6.SelectedItem = "Shrednaught"
				Exit Select
			Case &H16
				cmbVillian6.SelectedItem = "Chomp Chest"
				Exit Select
			Case &H17
				cmbVillian6.SelectedItem = "Broccoli Guy"
				Exit Select
			Case &H18
				cmbVillian6.SelectedItem = "Rage Mage"
				Exit Select
			Case &H19
				cmbVillian6.SelectedItem = "Lob Goblin"
				Exit Select
			Case &H1A
				cmbVillian6.SelectedItem = "Chompy"
				Exit Select
			Case &H1B
				cmbVillian6.SelectedItem = "Fisticuffs"
				Exit Select
			Case &H1C
				cmbVillian6.SelectedItem = "Trolling Thunder"
				Exit Select
			Case &H1D
				cmbVillian6.SelectedItem = "Hood Sickle"
				Exit Select
			Case &H1E
				cmbVillian6.SelectedItem = "Bruiser Cruiser"
				Exit Select
			Case &H1F
				cmbVillian6.SelectedItem = "Brawlrus"
				Exit Select
			Case &H20
				cmbVillian6.SelectedItem = "Tussle Sprout"
				Exit Select
			Case &H21
				cmbVillian6.SelectedItem = "Krankenstein"
				Exit Select
			Case &H22
				cmbVillian6.SelectedItem = "Scrap Shooter"
				Exit Select
			Case &H23
				cmbVillian6.SelectedItem = "Slobber Trap"
				Exit Select
			Case &H24
				cmbVillian6.SelectedItem = "Grinnade"
				Exit Select
			Case &H25
				cmbVillian6.SelectedItem = "Bad Juju"
				Exit Select
			Case &H26
				cmbVillian6.SelectedItem = "Blaster-Tron"
				Exit Select
			Case &H27
				cmbVillian6.SelectedItem = "Tae Kwon Crow"
				Exit Select
			Case &H28
				cmbVillian6.SelectedItem = "Painyata"
				Exit Select
			Case &H29
				cmbVillian6.SelectedItem = "Smoke Scream"
				Exit Select
			Case &H2A
				cmbVillian6.SelectedItem = "Eye Five"
				Exit Select
			Case &H2B
				cmbVillian6.SelectedItem = "Grave Clobber"
				Exit Select
			Case &H2C
				cmbVillian6.SelectedItem = "Threatpack"
				Exit Select
			Case &H2D
				cmbVillian6.SelectedItem = "Mab Lobs"
				Exit Select
			Case &H2E
				cmbVillian6.SelectedItem = "Eye Scream"
				Exit Select
			Case Else
				cmbVillian6.SelectedItem = "(None)"
				Exit Select
		End Select
		If WholeFile(&H1D1) = &H1 Then
			chkVillian6Evolved.Checked = True
		End If
		Dim Villian6_Trinket As Byte = WholeFile(&H1D3)
		Select Case Villian6_Trinket
			Case &H0
				cmbVillian6Trinket.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian6Trinket.SelectedItem = "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				cmbVillian6Trinket.SelectedItem = "Batterson's Bubble"
				Exit Select
			Case &H3
				cmbVillian6Trinket.SelectedItem = "Dark Water Daisy"
				Exit Select
			Case &H4
				cmbVillian6Trinket.SelectedItem = "Vote For Cyclops"
				Exit Select
			Case &H5
				cmbVillian6Trinket.SelectedItem = "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				cmbVillian6Trinket.SelectedItem = "Iris' Iris"
				Exit Select
			Case &H7
				cmbVillian6Trinket.SelectedItem = "Kuckoo Kazoo"
				Exit Select
			Case &H8
				cmbVillian6Trinket.SelectedItem = "Ramses' Rune"
				Exit Select
			Case &H9
				cmbVillian6Trinket.SelectedItem = "Ullysses Uniclops"
				Exit Select
			Case &HA
				cmbVillian6Trinket.SelectedItem = "Billy Bison"
				Exit Select
			Case &HB
				cmbVillian6Trinket.SelectedItem = "Stealth Elf's Gift"
				Exit Select
			Case &HC
				cmbVillian6Trinket.SelectedItem = "Lizard Lilly"
				Exit Select
			Case &HD
				cmbVillian6Trinket.SelectedItem = "Pirate Pinwheel"
				Exit Select
			Case &HE
				cmbVillian6Trinket.SelectedItem = "Bubble Blower"
				Exit Select
			Case &HF
				cmbVillian6Trinket.SelectedItem = "Medal of Heroism"
				Exit Select
			Case &H10
				cmbVillian6Trinket.SelectedItem = "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				cmbVillian6Trinket.SelectedItem = "Medal of Valliance"
				Exit Select
			Case &H12
				cmbVillian6Trinket.SelectedItem = "Medal of Gallantry"
				Exit Select
			Case &H13
				cmbVillian6Trinket.SelectedItem = "Medal of Mettle"
				Exit Select
			Case &H14
				cmbVillian6Trinket.SelectedItem = "Winged Medal of Bravery"
				Exit Select
			Case &H15
				cmbVillian6Trinket.SelectedItem = "Seadog Seashell"
				Exit Select
			Case &H16
				cmbVillian6Trinket.SelectedItem = "Snuckles' Sunflower"
				Exit Select
			Case &H17
				cmbVillian6Trinket.SelectedItem = "Teddy Cyclops"
				Exit Select
			Case &H18
				cmbVillian6Trinket.SelectedItem = "Goo Factory Gear"
				Exit Select
			Case &H19
				cmbVillian6Trinket.SelectedItem = "Elemental Opal"
				Exit Select
			Case &H1A
				cmbVillian6Trinket.SelectedItem = "Elemental Radiant"
				Exit Select
			Case &H1B
				cmbVillian6Trinket.SelectedItem = "Elemental Diamond"
				Exit Select
			Case &H1C
				cmbVillian6Trinket.SelectedItem = "Cyclops Spinner"
				Exit Select
			Case &H1D
				cmbVillian6Trinket.SelectedItem = "Wiliken Windmill"
				Exit Select
			Case &H1E
				cmbVillian6Trinket.SelectedItem = "Time Town Ticker"
				Exit Select
			Case &H1F
				cmbVillian6Trinket.SelectedItem = "Big Bow of Doom"
				Exit Select
			Case &H20
				cmbVillian6Trinket.SelectedItem = "Mabu's Medallion"
				Exit Select
			Case &H21
				cmbVillian6Trinket.SelectedItem = "Spyro's Shield"
				Exit Select
			Case Else
				cmbVillian6Trinket.SelectedItem = "(None)"
				Exit Select
		End Select
		Dim Villian6_Hat As Byte = WholeFile(&H1D2)
		Select Case Villian6_Hat
			Case &H0
				cmbVillian6Hat.SelectedItem = "(None)"
			Case &HD3
				cmbVillian6Hat.SelectedItem = "Alarm Clock Hat"
			Case &HDA
				cmbVillian6Hat.SelectedItem = "Bat Hat"
			Case &HD4
				cmbVillian6Hat.SelectedItem = "Batter Up Hat"
			Case &H9B
				cmbVillian6Hat.SelectedItem = "Beetle Hat"
			Case &HED
				cmbVillian6Hat.SelectedItem = "Bellhop Hat"
			Case &HC3
				cmbVillian6Hat.SelectedItem = "Bobby"
			Case &H9C
				cmbVillian6Hat.SelectedItem = "Brain Hat"
			Case &H9D
				cmbVillian6Hat.SelectedItem = "Brainiac Hat"
			Case &HEE
				cmbVillian6Hat.SelectedItem = "Bronze Arkeyan Helm"
			Case &H9E
				cmbVillian6Hat.SelectedItem = "Bucket Hat"
			Case &HEA
				cmbVillian6Hat.SelectedItem = "Candle Hat"
			Case &HE8
				cmbVillian6Hat.SelectedItem = "Candy Cane Hat"
			Case &HF6
				cmbVillian6Hat.SelectedItem = "Carnival Hat"
			Case &HA0
				cmbVillian6Hat.SelectedItem = "Ceiling Fan Hat"
			Case &HBB
				cmbVillian6Hat.SelectedItem = "Classic Pot Hat"
			Case &HA3
				cmbVillian6Hat.SelectedItem = "Clown Bowler Hat"
			Case &HA2
				cmbVillian6Hat.SelectedItem = "Clown Classic Hat"
			Case &HF7
				cmbVillian6Hat.SelectedItem = "Coconut Hat"
			Case &HA4
				cmbVillian6Hat.SelectedItem = "Colander Hat"
			Case &HFC
				cmbVillian6Hat.SelectedItem = "Core Of Light Hat"
			Case &HA6
				cmbVillian6Hat.SelectedItem = "Cornucopia Hat"
			Case &HBD
				cmbVillian6Hat.SelectedItem = "Crazy Light Bulb Hat"
			Case &HD6
				cmbVillian6Hat.SelectedItem = "Croissant Hat"
			Case &HA7
				cmbVillian6Hat.SelectedItem = "Cubano Hat"
			Case &HA8
				cmbVillian6Hat.SelectedItem = "Cycling Hat"
			Case &HA9
				cmbVillian6Hat.SelectedItem = "Daisy Crown"
			Case &HEB
				cmbVillian6Hat.SelectedItem = "Dark Helm"
			Case &H9F
				cmbVillian6Hat.SelectedItem = "Desert Crown"
			Case &HAA
				cmbVillian6Hat.SelectedItem = "Dragon Skull"
			Case &HE9
				cmbVillian6Hat.SelectedItem = "Eggshell Hat"
			Case &HCB
				cmbVillian6Hat.SelectedItem = "Extreme Viking Hat"
			Case &HD9
				cmbVillian6Hat.SelectedItem = "Eye of Kaos Hat"
			Case &HDC
				cmbVillian6Hat.SelectedItem = "Firefly Jar"
			Case &HC6
				cmbVillian6Hat.SelectedItem = "Flight Attendant Hat"
			Case &HAE
				cmbVillian6Hat.SelectedItem = "Garrison Hat"
			Case &HAD
				cmbVillian6Hat.SelectedItem = "Generalissimo"
			Case &HE2
				cmbVillian6Hat.SelectedItem = "Gold Arkeyan Helm"
			Case &HAF
				cmbVillian6Hat.SelectedItem = "Gondolier Hat"
			Case &HC4
				cmbVillian6Hat.SelectedItem = "Hedgehog Hat"
			Case &HD5
				cmbVillian6Hat.SelectedItem = "Horns Be With You Hat"
			Case &HB0
				cmbVillian6Hat.SelectedItem = "Hunting Hat"
			Case &HA1
				cmbVillian6Hat.SelectedItem = "Imperial Hat"
			Case &HB1
				cmbVillian6Hat.SelectedItem = "Juicer Hat"
			Case &HA5
				cmbVillian6Hat.SelectedItem = "Kepi Hat"
			Case &HB2
				cmbVillian6Hat.SelectedItem = "Kokoshnik"
			Case &HDB
				cmbVillian6Hat.SelectedItem = "Light Bulb Hat"
			Case &HDE
				cmbVillian6Hat.SelectedItem = "Lighthouse Beacon Hat"
			Case &HAC
				cmbVillian6Hat.SelectedItem = "Lil' Elf Hat"
			Case &HB3
				cmbVillian6Hat.SelectedItem = "Medic Hat"
			Case &HB4
				cmbVillian6Hat.SelectedItem = "Melon Hat"
			Case &HC0
				cmbVillian6Hat.SelectedItem = "Metal Fin Hat"
			Case &HE5
				cmbVillian6Hat.SelectedItem = "Miniature Skylands Hat"
			Case &HFA
				cmbVillian6Hat.SelectedItem = "Molekin Mountain Hat"
			Case &HC7
				cmbVillian6Hat.SelectedItem = "Monday Hat"
			Case &HB5
				cmbVillian6Hat.SelectedItem = "Mountie Hat"
			Case &HE0
				cmbVillian6Hat.SelectedItem = "Night Cap"
			Case &HB6
				cmbVillian6Hat.SelectedItem = "Nurse Hat"
			Case &HFD
				cmbVillian6Hat.SelectedItem = "Octavius Cloptimus Hat"
			Case &HBA
				cmbVillian6Hat.SelectedItem = "Old-Time Movie Hat"
			Case &HAB
				cmbVillian6Hat.SelectedItem = "Outback Hat"
			Case &HB7
				cmbVillian6Hat.SelectedItem = "Palm Hat"
			Case &HB8
				cmbVillian6Hat.SelectedItem = "Paperboy Hat"
			Case &HB9
				cmbVillian6Hat.SelectedItem = "Parrot Nest"
			Case &HEC
				cmbVillian6Hat.SelectedItem = "Planet Hat"
			Case &HD2
				cmbVillian6Hat.SelectedItem = "Pork Pie Hat"
			Case &HE4
				cmbVillian6Hat.SelectedItem = "Pyramid Hat"
			Case &HBC
				cmbVillian6Hat.SelectedItem = "Radar Hat"
			Case &HD8
				cmbVillian6Hat.SelectedItem = "Rainbow Hat"
			Case &HBE
				cmbVillian6Hat.SelectedItem = "Rubber Glove Hat"
			Case &HD1
				cmbVillian6Hat.SelectedItem = "Rude Boy Hat"
			Case &HBF
				cmbVillian6Hat.SelectedItem = "Rugby Hat"
			Case &HCC
				cmbVillian6Hat.SelectedItem = "Scooter Hat"
			Case &HDD
				cmbVillian6Hat.SelectedItem = "Shadow Ghost Hat"
			Case &HC8
				cmbVillian6Hat.SelectedItem = "Sherpa Hat"
			Case &HC2
				cmbVillian6Hat.SelectedItem = "Shower Cap"
			Case &HEF
				cmbVillian6Hat.SelectedItem = "Silver Arkeyan Helm"
			Case &HF3
				cmbVillian6Hat.SelectedItem = "Skipper Hat"
			Case &HC1
				cmbVillian6Hat.SelectedItem = "Sleuth Hat"
			Case &HC5
				cmbVillian6Hat.SelectedItem = "Steampunk Hat"
			Case &HE1
				cmbVillian6Hat.SelectedItem = "Storm Hat"
			Case &HCE
				cmbVillian6Hat.SelectedItem = "Synchronized Swimming Cap"
			Case &HDF
				cmbVillian6Hat.SelectedItem = "Tin Foil Hat"
			Case &HE3
				cmbVillian6Hat.SelectedItem = "Toucan Hat"
			Case &HC9
				cmbVillian6Hat.SelectedItem = "Trash Lid"
			Case &HD0
				cmbVillian6Hat.SelectedItem = "Tribal Hat"
			Case &HCA
				cmbVillian6Hat.SelectedItem = "Turtle Hat"
			Case &HCD
				cmbVillian6Hat.SelectedItem = "Volcano Island Hat"
			Case &HD7
				cmbVillian6Hat.SelectedItem = "Weather Vane Hat"
			Case &HCF
				cmbVillian6Hat.SelectedItem = "William Tell Hat"
			Case Else
				cmbVillian6Hat.SelectedItem = "(None)"
		End Select
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
		Select Case Villian1_ID
			Case &H0
				cmbVillian1.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian1.SelectedItem = "Chompy Mage"
				Exit Select
			Case &H2
				cmbVillian1.SelectedItem = "Dr. Crankcase"
				Exit Select
			Case &H3
				cmbVillian1.SelectedItem = "Wolfgang"
				Exit Select
			Case &H4
				cmbVillian1.SelectedItem = "Chef Pepper Jack"
				Exit Select
			Case &H5
				cmbVillian1.SelectedItem = "Nightshade"
				Exit Select
			Case &H6
				cmbVillian1.SelectedItem = "Luminous"
				Exit Select
			Case &H7
				cmbVillian1.SelectedItem = "Golden Queen"
				Exit Select
			Case &H8
				cmbVillian1.SelectedItem = "Dreamcatcher"
				Exit Select
			Case &H9
				cmbVillian1.SelectedItem = "Gulper"
				Exit Select
			Case &HA
				cmbVillian1.SelectedItem = "Kaos"
				Exit Select
			Case &HB
				cmbVillian1.SelectedItem = "Cuckoo Clocker"
				Exit Select
			Case &HC
				cmbVillian1.SelectedItem = "Buzzer Beak"
				Exit Select
			Case &HD
				cmbVillian1.SelectedItem = "Shield Shredder"
				Exit Select
			Case &HE
				cmbVillian1.SelectedItem = "Cross Crow"
				Exit Select
			Case &HF
				cmbVillian1.SelectedItem = "Bone Chompy"
				Exit Select
			Case &H10
				cmbVillian1.SelectedItem = "Brawl and Chain"
				Exit Select
			Case &H11
				cmbVillian1.SelectedItem = "Bomb Shell"
				Exit Select
			Case &H12
				cmbVillian1.SelectedItem = "Masker Mind"
				Exit Select
			Case &H13
				cmbVillian1.SelectedItem = "Chill Bill"
				Exit Select
			Case &H14
				cmbVillian1.SelectedItem = "Sheep Creep"
				Exit Select
			Case &H15
				cmbVillian1.SelectedItem = "Shrednaught"
				Exit Select
			Case &H16
				cmbVillian1.SelectedItem = "Chomp Chest"
				Exit Select
			Case &H17
				cmbVillian1.SelectedItem = "Broccoli Guy"
				Exit Select
			Case &H18
				cmbVillian1.SelectedItem = "Rage Mage"
				Exit Select
			Case &H19
				cmbVillian1.SelectedItem = "Lob Goblin"
				Exit Select
			Case &H1A
				cmbVillian1.SelectedItem = "Chompy"
				Exit Select
			Case &H1B
				cmbVillian1.SelectedItem = "Fisticuffs"
				Exit Select
			Case &H1C
				cmbVillian1.SelectedItem = "Trolling Thunder"
				Exit Select
			Case &H1D
				cmbVillian1.SelectedItem = "Hood Sickle"
				Exit Select
			Case &H1E
				cmbVillian1.SelectedItem = "Bruiser Cruiser"
				Exit Select
			Case &H1F
				cmbVillian1.SelectedItem = "Brawlrus"
				Exit Select
			Case &H20
				cmbVillian1.SelectedItem = "Tussle Sprout"
				Exit Select
			Case &H21
				cmbVillian1.SelectedItem = "Krankenstein"
				Exit Select
			Case &H22
				cmbVillian1.SelectedItem = "Scrap Shooter"
				Exit Select
			Case &H23
				cmbVillian1.SelectedItem = "Slobber Trap"
				Exit Select
			Case &H24
				cmbVillian1.SelectedItem = "Grinnade"
				Exit Select
			Case &H25
				cmbVillian1.SelectedItem = "Bad Juju"
				Exit Select
			Case &H26
				cmbVillian1.SelectedItem = "Blaster-Tron"
				Exit Select
			Case &H27
				cmbVillian1.SelectedItem = "Tae Kwon Crow"
				Exit Select
			Case &H28
				cmbVillian1.SelectedItem = "Painyata"
				Exit Select
			Case &H29
				cmbVillian1.SelectedItem = "Smoke Scream"
				Exit Select
			Case &H2A
				cmbVillian1.SelectedItem = "Eye Five"
				Exit Select
			Case &H2B
				cmbVillian1.SelectedItem = "Grave Clobber"
				Exit Select
			Case &H2C
				cmbVillian1.SelectedItem = "Threatpack"
				Exit Select
			Case &H2D
				cmbVillian1.SelectedItem = "Mab Lobs"
				Exit Select
			Case &H2E
				cmbVillian1.SelectedItem = "Eye Scream"
				Exit Select
			Case Else
				cmbVillian1.SelectedItem = "(None)"
				Exit Select
		End Select
		If WholeFile(&H251) = &H1 Then
			chkVillian1Evolved.Checked = True
		End If
		Dim Villian1_Hat As Byte = WholeFile(&H252)
		Select Case Villian1_Hat
			Case &H0
				cmbVillian1Hat.SelectedItem = "(None)"
			Case &HD3
				cmbVillian1Hat.SelectedItem = "Alarm Clock Hat"
			Case &HDA
				cmbVillian1Hat.SelectedItem = "Bat Hat"
			Case &HD4
				cmbVillian1Hat.SelectedItem = "Batter Up Hat"
			Case &H9B
				cmbVillian1Hat.SelectedItem = "Beetle Hat"
			Case &HED
				cmbVillian1Hat.SelectedItem = "Bellhop Hat"
			Case &HC3
				cmbVillian1Hat.SelectedItem = "Bobby"
			Case &H9C
				cmbVillian1Hat.SelectedItem = "Brain Hat"
			Case &H9D
				cmbVillian1Hat.SelectedItem = "Brainiac Hat"
			Case &HEE
				cmbVillian1Hat.SelectedItem = "Bronze Arkeyan Helm"
			Case &H9E
				cmbVillian1Hat.SelectedItem = "Bucket Hat"
			Case &HEA
				cmbVillian1Hat.SelectedItem = "Candle Hat"
			Case &HE8
				cmbVillian1Hat.SelectedItem = "Candy Cane Hat"
			Case &HF6
				cmbVillian1Hat.SelectedItem = "Carnival Hat"
			Case &HA0
				cmbVillian1Hat.SelectedItem = "Ceiling Fan Hat"
			Case &HBB
				cmbVillian1Hat.SelectedItem = "Classic Pot Hat"
			Case &HA3
				cmbVillian1Hat.SelectedItem = "Clown Bowler Hat"
			Case &HA2
				cmbVillian1Hat.SelectedItem = "Clown Classic Hat"
			Case &HF7
				cmbVillian1Hat.SelectedItem = "Coconut Hat"
			Case &HA4
				cmbVillian1Hat.SelectedItem = "Colander Hat"
			Case &HFC
				cmbVillian1Hat.SelectedItem = "Core Of Light Hat"
			Case &HA6
				cmbVillian1Hat.SelectedItem = "Cornucopia Hat"
			Case &HBD
				cmbVillian1Hat.SelectedItem = "Crazy Light Bulb Hat"
			Case &HD6
				cmbVillian1Hat.SelectedItem = "Croissant Hat"
			Case &HA7
				cmbVillian1Hat.SelectedItem = "Cubano Hat"
			Case &HA8
				cmbVillian1Hat.SelectedItem = "Cycling Hat"
			Case &HA9
				cmbVillian1Hat.SelectedItem = "Daisy Crown"
			Case &HEB
				cmbVillian1Hat.SelectedItem = "Dark Helm"
			Case &H9F
				cmbVillian1Hat.SelectedItem = "Desert Crown"
			Case &HAA
				cmbVillian1Hat.SelectedItem = "Dragon Skull"
			Case &HE9
				cmbVillian1Hat.SelectedItem = "Eggshell Hat"
			Case &HCB
				cmbVillian1Hat.SelectedItem = "Extreme Viking Hat"
			Case &HD9
				cmbVillian1Hat.SelectedItem = "Eye of Kaos Hat"
			Case &HDC
				cmbVillian1Hat.SelectedItem = "Firefly Jar"
			Case &HC6
				cmbVillian1Hat.SelectedItem = "Flight Attendant Hat"
			Case &HAE
				cmbVillian1Hat.SelectedItem = "Garrison Hat"
			Case &HAD
				cmbVillian1Hat.SelectedItem = "Generalissimo"
			Case &HE2
				cmbVillian1Hat.SelectedItem = "Gold Arkeyan Helm"
			Case &HAF
				cmbVillian1Hat.SelectedItem = "Gondolier Hat"
			Case &HC4
				cmbVillian1Hat.SelectedItem = "Hedgehog Hat"
			Case &HD5
				cmbVillian1Hat.SelectedItem = "Horns Be With You Hat"
			Case &HB0
				cmbVillian1Hat.SelectedItem = "Hunting Hat"
			Case &HA1
				cmbVillian1Hat.SelectedItem = "Imperial Hat"
			Case &HB1
				cmbVillian1Hat.SelectedItem = "Juicer Hat"
			Case &HA5
				cmbVillian1Hat.SelectedItem = "Kepi Hat"
			Case &HB2
				cmbVillian1Hat.SelectedItem = "Kokoshnik"
			Case &HDB
				cmbVillian1Hat.SelectedItem = "Light Bulb Hat"
			Case &HDE
				cmbVillian1Hat.SelectedItem = "Lighthouse Beacon Hat"
			Case &HAC
				cmbVillian1Hat.SelectedItem = "Lil' Elf Hat"
			Case &HB3
				cmbVillian1Hat.SelectedItem = "Medic Hat"
			Case &HB4
				cmbVillian1Hat.SelectedItem = "Melon Hat"
			Case &HC0
				cmbVillian1Hat.SelectedItem = "Metal Fin Hat"
			Case &HE5
				cmbVillian1Hat.SelectedItem = "Miniature Skylands Hat"
			Case &HFA
				cmbVillian1Hat.SelectedItem = "Molekin Mountain Hat"
			Case &HC7
				cmbVillian1Hat.SelectedItem = "Monday Hat"
			Case &HB5
				cmbVillian1Hat.SelectedItem = "Mountie Hat"
			Case &HE0
				cmbVillian1Hat.SelectedItem = "Night Cap"
			Case &HB6
				cmbVillian1Hat.SelectedItem = "Nurse Hat"
			Case &HFD
				cmbVillian1Hat.SelectedItem = "Octavius Cloptimus Hat"
			Case &HBA
				cmbVillian1Hat.SelectedItem = "Old-Time Movie Hat"
			Case &HAB
				cmbVillian1Hat.SelectedItem = "Outback Hat"
			Case &HB7
				cmbVillian1Hat.SelectedItem = "Palm Hat"
			Case &HB8
				cmbVillian1Hat.SelectedItem = "Paperboy Hat"
			Case &HB9
				cmbVillian1Hat.SelectedItem = "Parrot Nest"
			Case &HEC
				cmbVillian1Hat.SelectedItem = "Planet Hat"
			Case &HD2
				cmbVillian1Hat.SelectedItem = "Pork Pie Hat"
			Case &HE4
				cmbVillian1Hat.SelectedItem = "Pyramid Hat"
			Case &HBC
				cmbVillian1Hat.SelectedItem = "Radar Hat"
			Case &HD8
				cmbVillian1Hat.SelectedItem = "Rainbow Hat"
			Case &HBE
				cmbVillian1Hat.SelectedItem = "Rubber Glove Hat"
			Case &HD1
				cmbVillian1Hat.SelectedItem = "Rude Boy Hat"
			Case &HBF
				cmbVillian1Hat.SelectedItem = "Rugby Hat"
			Case &HCC
				cmbVillian1Hat.SelectedItem = "Scooter Hat"
			Case &HDD
				cmbVillian1Hat.SelectedItem = "Shadow Ghost Hat"
			Case &HC8
				cmbVillian1Hat.SelectedItem = "Sherpa Hat"
			Case &HC2
				cmbVillian1Hat.SelectedItem = "Shower Cap"
			Case &HEF
				cmbVillian1Hat.SelectedItem = "Silver Arkeyan Helm"
			Case &HF3
				cmbVillian1Hat.SelectedItem = "Skipper Hat"
			Case &HC1
				cmbVillian1Hat.SelectedItem = "Sleuth Hat"
			Case &HC5
				cmbVillian1Hat.SelectedItem = "Steampunk Hat"
			Case &HE1
				cmbVillian1Hat.SelectedItem = "Storm Hat"
			Case &HCE
				cmbVillian1Hat.SelectedItem = "Synchronized Swimming Cap"
			Case &HDF
				cmbVillian1Hat.SelectedItem = "Tin Foil Hat"
			Case &HE3
				cmbVillian1Hat.SelectedItem = "Toucan Hat"
			Case &HC9
				cmbVillian1Hat.SelectedItem = "Trash Lid"
			Case &HD0
				cmbVillian1Hat.SelectedItem = "Tribal Hat"
			Case &HCA
				cmbVillian1Hat.SelectedItem = "Turtle Hat"
			Case &HCD
				cmbVillian1Hat.SelectedItem = "Volcano Island Hat"
			Case &HD7
				cmbVillian1Hat.SelectedItem = "Weather Vane Hat"
			Case &HCF
				cmbVillian1Hat.SelectedItem = "William Tell Hat"
			Case Else
				cmbVillian1Hat.SelectedItem = "(None)"
		End Select
		Dim Villian1_Trinket As Byte = WholeFile(&H253)
		Select Case Villian1_Trinket
			Case &H0
				cmbVillian1Trinket.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian1Trinket.SelectedItem = "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				cmbVillian1Trinket.SelectedItem = "Batterson's Bubble"
				Exit Select
			Case &H3
				cmbVillian1Trinket.SelectedItem = "Dark Water Daisy"
				Exit Select
			Case &H4
				cmbVillian1Trinket.SelectedItem = "Vote For Cyclops"
				Exit Select
			Case &H5
				cmbVillian1Trinket.SelectedItem = "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				cmbVillian1Trinket.SelectedItem = "Iris' Iris"
				Exit Select
			Case &H7
				cmbVillian1Trinket.SelectedItem = "Kuckoo Kazoo"
				Exit Select
			Case &H8
				cmbVillian1Trinket.SelectedItem = "Ramses' Rune"
				Exit Select
			Case &H9
				cmbVillian1Trinket.SelectedItem = "Ullysses Uniclops"
				Exit Select
			Case &HA
				cmbVillian1Trinket.SelectedItem = "Billy Bison"
				Exit Select
			Case &HB
				cmbVillian1Trinket.SelectedItem = "Stealth Elf's Gift"
				Exit Select
			Case &HC
				cmbVillian1Trinket.SelectedItem = "Lizard Lilly"
				Exit Select
			Case &HD
				cmbVillian1Trinket.SelectedItem = "Pirate Pinwheel"
				Exit Select
			Case &HE
				cmbVillian1Trinket.SelectedItem = "Bubble Blower"
				Exit Select
			Case &HF
				cmbVillian1Trinket.SelectedItem = "Medal of Heroism"
				Exit Select
			Case &H10
				cmbVillian1Trinket.SelectedItem = "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				cmbVillian1Trinket.SelectedItem = "Medal of Valliance"
				Exit Select
			Case &H12
				cmbVillian1Trinket.SelectedItem = "Medal of Gallantry"
				Exit Select
			Case &H13
				cmbVillian1Trinket.SelectedItem = "Medal of Mettle"
				Exit Select
			Case &H14
				cmbVillian1Trinket.SelectedItem = "Winged Medal of Bravery"
				Exit Select
			Case &H15
				cmbVillian1Trinket.SelectedItem = "Seadog Seashell"
				Exit Select
			Case &H16
				cmbVillian1Trinket.SelectedItem = "Snuckles' Sunflower"
				Exit Select
			Case &H17
				cmbVillian1Trinket.SelectedItem = "Teddy Cyclops"
				Exit Select
			Case &H18
				cmbVillian1Trinket.SelectedItem = "Goo Factory Gear"
				Exit Select
			Case &H19
				cmbVillian1Trinket.SelectedItem = "Elemental Opal"
				Exit Select
			Case &H1A
				cmbVillian1Trinket.SelectedItem = "Elemental Radiant"
				Exit Select
			Case &H1B
				cmbVillian1Trinket.SelectedItem = "Elemental Diamond"
				Exit Select
			Case &H1C
				cmbVillian1Trinket.SelectedItem = "Cyclops Spinner"
				Exit Select
			Case &H1D
				cmbVillian1Trinket.SelectedItem = "Wiliken Windmill"
				Exit Select
			Case &H1E
				cmbVillian1Trinket.SelectedItem = "Time Town Ticker"
				Exit Select
			Case &H1F
				cmbVillian1Trinket.SelectedItem = "Big Bow of Doom"
				Exit Select
			Case &H20
				cmbVillian1Trinket.SelectedItem = "Mabu's Medallion"
				Exit Select
			Case &H21
				cmbVillian1Trinket.SelectedItem = "Spyro's Shield"
				Exit Select
			Case Else
				cmbVillian1Trinket.SelectedItem = "(None)"
				Exit Select
		End Select
		'Load Name from Byte 0x254
		txtVillian1Name.Text = Load_Name(&H254)

		'+&H40
		'Villian Two Data is 0x290 to 0x2C1
		'Ignore 0x2B0 Block as it's MiFare
		Dim Villian2_ID As Byte = WholeFile(&H290)
		Select Case Villian2_ID
			Case &H0
				cmbVillian2.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian2.SelectedItem = "Chompy Mage"
				Exit Select
			Case &H2
				cmbVillian2.SelectedItem = "Dr. Crankcase"
				Exit Select
			Case &H3
				cmbVillian2.SelectedItem = "Wolfgang"
				Exit Select
			Case &H4
				cmbVillian2.SelectedItem = "Chef Pepper Jack"
				Exit Select
			Case &H5
				cmbVillian2.SelectedItem = "Nightshade"
				Exit Select
			Case &H6
				cmbVillian2.SelectedItem = "Luminous"
				Exit Select
			Case &H7
				cmbVillian2.SelectedItem = "Golden Queen"
				Exit Select
			Case &H8
				cmbVillian2.SelectedItem = "Dreamcatcher"
				Exit Select
			Case &H9
				cmbVillian2.SelectedItem = "Gulper"
				Exit Select
			Case &HA
				cmbVillian2.SelectedItem = "Kaos"
				Exit Select
			Case &HB
				cmbVillian2.SelectedItem = "Cuckoo Clocker"
				Exit Select
			Case &HC
				cmbVillian2.SelectedItem = "Buzzer Beak"
				Exit Select
			Case &HD
				cmbVillian2.SelectedItem = "Shield Shredder"
				Exit Select
			Case &HE
				cmbVillian2.SelectedItem = "Cross Crow"
				Exit Select
			Case &HF
				cmbVillian2.SelectedItem = "Bone Chompy"
				Exit Select
			Case &H10
				cmbVillian2.SelectedItem = "Brawl and Chain"
				Exit Select
			Case &H11
				cmbVillian2.SelectedItem = "Bomb Shell"
				Exit Select
			Case &H12
				cmbVillian2.SelectedItem = "Masker Mind"
				Exit Select
			Case &H13
				cmbVillian2.SelectedItem = "Chill Bill"
				Exit Select
			Case &H14
				cmbVillian2.SelectedItem = "Sheep Creep"
				Exit Select
			Case &H15
				cmbVillian2.SelectedItem = "Shrednaught"
				Exit Select
			Case &H16
				cmbVillian2.SelectedItem = "Chomp Chest"
				Exit Select
			Case &H17
				cmbVillian2.SelectedItem = "Broccoli Guy"
				Exit Select
			Case &H18
				cmbVillian2.SelectedItem = "Rage Mage"
				Exit Select
			Case &H19
				cmbVillian2.SelectedItem = "Lob Goblin"
				Exit Select
			Case &H1A
				cmbVillian2.SelectedItem = "Chompy"
				Exit Select
			Case &H1B
				cmbVillian2.SelectedItem = "Fisticuffs"
				Exit Select
			Case &H1C
				cmbVillian2.SelectedItem = "Trolling Thunder"
				Exit Select
			Case &H1D
				cmbVillian2.SelectedItem = "Hood Sickle"
				Exit Select
			Case &H1E
				cmbVillian2.SelectedItem = "Bruiser Cruiser"
				Exit Select
			Case &H1F
				cmbVillian2.SelectedItem = "Brawlrus"
				Exit Select
			Case &H20
				cmbVillian2.SelectedItem = "Tussle Sprout"
				Exit Select
			Case &H21
				cmbVillian2.SelectedItem = "Krankenstein"
				Exit Select
			Case &H22
				cmbVillian2.SelectedItem = "Scrap Shooter"
				Exit Select
			Case &H23
				cmbVillian2.SelectedItem = "Slobber Trap"
				Exit Select
			Case &H24
				cmbVillian2.SelectedItem = "Grinnade"
				Exit Select
			Case &H25
				cmbVillian2.SelectedItem = "Bad Juju"
				Exit Select
			Case &H26
				cmbVillian2.SelectedItem = "Blaster-Tron"
				Exit Select
			Case &H27
				cmbVillian2.SelectedItem = "Tae Kwon Crow"
				Exit Select
			Case &H28
				cmbVillian2.SelectedItem = "Painyata"
				Exit Select
			Case &H29
				cmbVillian2.SelectedItem = "Smoke Scream"
				Exit Select
			Case &H2A
				cmbVillian2.SelectedItem = "Eye Five"
				Exit Select
			Case &H2B
				cmbVillian2.SelectedItem = "Grave Clobber"
				Exit Select
			Case &H2C
				cmbVillian2.SelectedItem = "Threatpack"
				Exit Select
			Case &H2D
				cmbVillian2.SelectedItem = "Mab Lobs"
				Exit Select
			Case &H2E
				cmbVillian2.SelectedItem = "Eye Scream"
				Exit Select
			Case Else
				cmbVillian2.SelectedItem = "(None)"
				Exit Select
		End Select
		If WholeFile(&H291) = &H1 Then
			chkVillian2Evolved.Checked = True
		End If
		Dim Villian2_Hat As Byte = WholeFile(&H292)
		Select Case Villian2_Hat
			Case &H0
				cmbVillian2Hat.SelectedItem = "(None)"
			Case &HD3
				cmbVillian2Hat.SelectedItem = "Alarm Clock Hat"
			Case &HDA
				cmbVillian2Hat.SelectedItem = "Bat Hat"
			Case &HD4
				cmbVillian2Hat.SelectedItem = "Batter Up Hat"
			Case &H9B
				cmbVillian2Hat.SelectedItem = "Beetle Hat"
			Case &HED
				cmbVillian2Hat.SelectedItem = "Bellhop Hat"
			Case &HC3
				cmbVillian2Hat.SelectedItem = "Bobby"
			Case &H9C
				cmbVillian2Hat.SelectedItem = "Brain Hat"
			Case &H9D
				cmbVillian2Hat.SelectedItem = "Brainiac Hat"
			Case &HEE
				cmbVillian2Hat.SelectedItem = "Bronze Arkeyan Helm"
			Case &H9E
				cmbVillian2Hat.SelectedItem = "Bucket Hat"
			Case &HEA
				cmbVillian2Hat.SelectedItem = "Candle Hat"
			Case &HE8
				cmbVillian2Hat.SelectedItem = "Candy Cane Hat"
			Case &HF6
				cmbVillian2Hat.SelectedItem = "Carnival Hat"
			Case &HA0
				cmbVillian2Hat.SelectedItem = "Ceiling Fan Hat"
			Case &HBB
				cmbVillian2Hat.SelectedItem = "Classic Pot Hat"
			Case &HA3
				cmbVillian2Hat.SelectedItem = "Clown Bowler Hat"
			Case &HA2
				cmbVillian2Hat.SelectedItem = "Clown Classic Hat"
			Case &HF7
				cmbVillian2Hat.SelectedItem = "Coconut Hat"
			Case &HA4
				cmbVillian2Hat.SelectedItem = "Colander Hat"
			Case &HFC
				cmbVillian2Hat.SelectedItem = "Core Of Light Hat"
			Case &HA6
				cmbVillian2Hat.SelectedItem = "Cornucopia Hat"
			Case &HBD
				cmbVillian2Hat.SelectedItem = "Crazy Light Bulb Hat"
			Case &HD6
				cmbVillian2Hat.SelectedItem = "Croissant Hat"
			Case &HA7
				cmbVillian2Hat.SelectedItem = "Cubano Hat"
			Case &HA8
				cmbVillian2Hat.SelectedItem = "Cycling Hat"
			Case &HA9
				cmbVillian2Hat.SelectedItem = "Daisy Crown"
			Case &HEB
				cmbVillian2Hat.SelectedItem = "Dark Helm"
			Case &H9F
				cmbVillian2Hat.SelectedItem = "Desert Crown"
			Case &HAA
				cmbVillian2Hat.SelectedItem = "Dragon Skull"
			Case &HE9
				cmbVillian2Hat.SelectedItem = "Eggshell Hat"
			Case &HCB
				cmbVillian2Hat.SelectedItem = "Extreme Viking Hat"
			Case &HD9
				cmbVillian2Hat.SelectedItem = "Eye of Kaos Hat"
			Case &HDC
				cmbVillian2Hat.SelectedItem = "Firefly Jar"
			Case &HC6
				cmbVillian2Hat.SelectedItem = "Flight Attendant Hat"
			Case &HAE
				cmbVillian2Hat.SelectedItem = "Garrison Hat"
			Case &HAD
				cmbVillian2Hat.SelectedItem = "Generalissimo"
			Case &HE2
				cmbVillian2Hat.SelectedItem = "Gold Arkeyan Helm"
			Case &HAF
				cmbVillian2Hat.SelectedItem = "Gondolier Hat"
			Case &HC4
				cmbVillian2Hat.SelectedItem = "Hedgehog Hat"
			Case &HD5
				cmbVillian2Hat.SelectedItem = "Horns Be With You Hat"
			Case &HB0
				cmbVillian2Hat.SelectedItem = "Hunting Hat"
			Case &HA1
				cmbVillian2Hat.SelectedItem = "Imperial Hat"
			Case &HB1
				cmbVillian2Hat.SelectedItem = "Juicer Hat"
			Case &HA5
				cmbVillian2Hat.SelectedItem = "Kepi Hat"
			Case &HB2
				cmbVillian2Hat.SelectedItem = "Kokoshnik"
			Case &HDB
				cmbVillian2Hat.SelectedItem = "Light Bulb Hat"
			Case &HDE
				cmbVillian2Hat.SelectedItem = "Lighthouse Beacon Hat"
			Case &HAC
				cmbVillian2Hat.SelectedItem = "Lil' Elf Hat"
			Case &HB3
				cmbVillian2Hat.SelectedItem = "Medic Hat"
			Case &HB4
				cmbVillian2Hat.SelectedItem = "Melon Hat"
			Case &HC0
				cmbVillian2Hat.SelectedItem = "Metal Fin Hat"
			Case &HE5
				cmbVillian2Hat.SelectedItem = "Miniature Skylands Hat"
			Case &HFA
				cmbVillian2Hat.SelectedItem = "Molekin Mountain Hat"
			Case &HC7
				cmbVillian2Hat.SelectedItem = "Monday Hat"
			Case &HB5
				cmbVillian2Hat.SelectedItem = "Mountie Hat"
			Case &HE0
				cmbVillian2Hat.SelectedItem = "Night Cap"
			Case &HB6
				cmbVillian2Hat.SelectedItem = "Nurse Hat"
			Case &HFD
				cmbVillian2Hat.SelectedItem = "Octavius Cloptimus Hat"
			Case &HBA
				cmbVillian2Hat.SelectedItem = "Old-Time Movie Hat"
			Case &HAB
				cmbVillian2Hat.SelectedItem = "Outback Hat"
			Case &HB7
				cmbVillian2Hat.SelectedItem = "Palm Hat"
			Case &HB8
				cmbVillian2Hat.SelectedItem = "Paperboy Hat"
			Case &HB9
				cmbVillian2Hat.SelectedItem = "Parrot Nest"
			Case &HEC
				cmbVillian2Hat.SelectedItem = "Planet Hat"
			Case &HD2
				cmbVillian2Hat.SelectedItem = "Pork Pie Hat"
			Case &HE4
				cmbVillian2Hat.SelectedItem = "Pyramid Hat"
			Case &HBC
				cmbVillian2Hat.SelectedItem = "Radar Hat"
			Case &HD8
				cmbVillian2Hat.SelectedItem = "Rainbow Hat"
			Case &HBE
				cmbVillian2Hat.SelectedItem = "Rubber Glove Hat"
			Case &HD1
				cmbVillian2Hat.SelectedItem = "Rude Boy Hat"
			Case &HBF
				cmbVillian2Hat.SelectedItem = "Rugby Hat"
			Case &HCC
				cmbVillian2Hat.SelectedItem = "Scooter Hat"
			Case &HDD
				cmbVillian2Hat.SelectedItem = "Shadow Ghost Hat"
			Case &HC8
				cmbVillian2Hat.SelectedItem = "Sherpa Hat"
			Case &HC2
				cmbVillian2Hat.SelectedItem = "Shower Cap"
			Case &HEF
				cmbVillian2Hat.SelectedItem = "Silver Arkeyan Helm"
			Case &HF3
				cmbVillian2Hat.SelectedItem = "Skipper Hat"
			Case &HC1
				cmbVillian2Hat.SelectedItem = "Sleuth Hat"
			Case &HC5
				cmbVillian2Hat.SelectedItem = "Steampunk Hat"
			Case &HE1
				cmbVillian2Hat.SelectedItem = "Storm Hat"
			Case &HCE
				cmbVillian2Hat.SelectedItem = "Synchronized Swimming Cap"
			Case &HDF
				cmbVillian2Hat.SelectedItem = "Tin Foil Hat"
			Case &HE3
				cmbVillian2Hat.SelectedItem = "Toucan Hat"
			Case &HC9
				cmbVillian2Hat.SelectedItem = "Trash Lid"
			Case &HD0
				cmbVillian2Hat.SelectedItem = "Tribal Hat"
			Case &HCA
				cmbVillian2Hat.SelectedItem = "Turtle Hat"
			Case &HCD
				cmbVillian2Hat.SelectedItem = "Volcano Island Hat"
			Case &HD7
				cmbVillian2Hat.SelectedItem = "Weather Vane Hat"
			Case &HCF
				cmbVillian2Hat.SelectedItem = "William Tell Hat"
			Case Else
				cmbVillian2Hat.SelectedItem = "(None)"
		End Select
		Dim Villian2_Trinket As Byte = WholeFile(&H293)
		Select Case Villian2_Trinket
			Case &H0
				cmbVillian2Trinket.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian2Trinket.SelectedItem = "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				cmbVillian2Trinket.SelectedItem = "Batterson's Bubble"
				Exit Select
			Case &H3
				cmbVillian2Trinket.SelectedItem = "Dark Water Daisy"
				Exit Select
			Case &H4
				cmbVillian2Trinket.SelectedItem = "Vote For Cyclops"
				Exit Select
			Case &H5
				cmbVillian2Trinket.SelectedItem = "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				cmbVillian2Trinket.SelectedItem = "Iris' Iris"
				Exit Select
			Case &H7
				cmbVillian2Trinket.SelectedItem = "Kuckoo Kazoo"
				Exit Select
			Case &H8
				cmbVillian2Trinket.SelectedItem = "Ramses' Rune"
				Exit Select
			Case &H9
				cmbVillian2Trinket.SelectedItem = "Ullysses Uniclops"
				Exit Select
			Case &HA
				cmbVillian2Trinket.SelectedItem = "Billy Bison"
				Exit Select
			Case &HB
				cmbVillian2Trinket.SelectedItem = "Stealth Elf's Gift"
				Exit Select
			Case &HC
				cmbVillian2Trinket.SelectedItem = "Lizard Lilly"
				Exit Select
			Case &HD
				cmbVillian2Trinket.SelectedItem = "Pirate Pinwheel"
				Exit Select
			Case &HE
				cmbVillian2Trinket.SelectedItem = "Bubble Blower"
				Exit Select
			Case &HF
				cmbVillian2Trinket.SelectedItem = "Medal of Heroism"
				Exit Select
			Case &H10
				cmbVillian2Trinket.SelectedItem = "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				cmbVillian2Trinket.SelectedItem = "Medal of Valliance"
				Exit Select
			Case &H12
				cmbVillian2Trinket.SelectedItem = "Medal of Gallantry"
				Exit Select
			Case &H13
				cmbVillian2Trinket.SelectedItem = "Medal of Mettle"
				Exit Select
			Case &H14
				cmbVillian2Trinket.SelectedItem = "Winged Medal of Bravery"
				Exit Select
			Case &H15
				cmbVillian2Trinket.SelectedItem = "Seadog Seashell"
				Exit Select
			Case &H16
				cmbVillian2Trinket.SelectedItem = "Snuckles' Sunflower"
				Exit Select
			Case &H17
				cmbVillian2Trinket.SelectedItem = "Teddy Cyclops"
				Exit Select
			Case &H18
				cmbVillian2Trinket.SelectedItem = "Goo Factory Gear"
				Exit Select
			Case &H19
				cmbVillian2Trinket.SelectedItem = "Elemental Opal"
				Exit Select
			Case &H1A
				cmbVillian2Trinket.SelectedItem = "Elemental Radiant"
				Exit Select
			Case &H1B
				cmbVillian2Trinket.SelectedItem = "Elemental Diamond"
				Exit Select
			Case &H1C
				cmbVillian2Trinket.SelectedItem = "Cyclops Spinner"
				Exit Select
			Case &H1D
				cmbVillian2Trinket.SelectedItem = "Wiliken Windmill"
				Exit Select
			Case &H1E
				cmbVillian2Trinket.SelectedItem = "Time Town Ticker"
				Exit Select
			Case &H1F
				cmbVillian2Trinket.SelectedItem = "Big Bow of Doom"
				Exit Select
			Case &H20
				cmbVillian2Trinket.SelectedItem = "Mabu's Medallion"
				Exit Select
			Case &H21
				cmbVillian2Trinket.SelectedItem = "Spyro's Shield"
				Exit Select
			Case Else
				cmbVillian2Trinket.SelectedItem = "(None)"
				Exit Select
		End Select
		'Load Name from Byte 0x294
		txtVillian1Name.Text = Load_Name(&H294)

		'+&H40
		'Villian Three Data is 0x2D0 to 0x301
		'Ignore 0X2F0 Block as it's MiFare
		Dim Villian3_ID As Byte = WholeFile(&H2D0)
		Select Case Villian3_ID
			Case &H0
				cmbVillian3.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian3.SelectedItem = "Chompy Mage"
				Exit Select
			Case &H2
				cmbVillian3.SelectedItem = "Dr. Crankcase"
				Exit Select
			Case &H3
				cmbVillian3.SelectedItem = "Wolfgang"
				Exit Select
			Case &H4
				cmbVillian3.SelectedItem = "Chef Pepper Jack"
				Exit Select
			Case &H5
				cmbVillian3.SelectedItem = "Nightshade"
				Exit Select
			Case &H6
				cmbVillian3.SelectedItem = "Luminous"
				Exit Select
			Case &H7
				cmbVillian3.SelectedItem = "Golden Queen"
				Exit Select
			Case &H8
				cmbVillian3.SelectedItem = "Dreamcatcher"
				Exit Select
			Case &H9
				cmbVillian3.SelectedItem = "Gulper"
				Exit Select
			Case &HA
				cmbVillian3.SelectedItem = "Kaos"
				Exit Select
			Case &HB
				cmbVillian3.SelectedItem = "Cuckoo Clocker"
				Exit Select
			Case &HC
				cmbVillian3.SelectedItem = "Buzzer Beak"
				Exit Select
			Case &HD
				cmbVillian3.SelectedItem = "Shield Shredder"
				Exit Select
			Case &HE
				cmbVillian3.SelectedItem = "Cross Crow"
				Exit Select
			Case &HF
				cmbVillian3.SelectedItem = "Bone Chompy"
				Exit Select
			Case &H10
				cmbVillian3.SelectedItem = "Brawl and Chain"
				Exit Select
			Case &H11
				cmbVillian3.SelectedItem = "Bomb Shell"
				Exit Select
			Case &H12
				cmbVillian3.SelectedItem = "Masker Mind"
				Exit Select
			Case &H13
				cmbVillian3.SelectedItem = "Chill Bill"
				Exit Select
			Case &H14
				cmbVillian3.SelectedItem = "Sheep Creep"
				Exit Select
			Case &H15
				cmbVillian3.SelectedItem = "Shrednaught"
				Exit Select
			Case &H16
				cmbVillian3.SelectedItem = "Chomp Chest"
				Exit Select
			Case &H17
				cmbVillian3.SelectedItem = "Broccoli Guy"
				Exit Select
			Case &H18
				cmbVillian3.SelectedItem = "Rage Mage"
				Exit Select
			Case &H19
				cmbVillian3.SelectedItem = "Lob Goblin"
				Exit Select
			Case &H1A
				cmbVillian3.SelectedItem = "Chompy"
				Exit Select
			Case &H1B
				cmbVillian3.SelectedItem = "Fisticuffs"
				Exit Select
			Case &H1C
				cmbVillian3.SelectedItem = "Trolling Thunder"
				Exit Select
			Case &H1D
				cmbVillian3.SelectedItem = "Hood Sickle"
				Exit Select
			Case &H1E
				cmbVillian3.SelectedItem = "Bruiser Cruiser"
				Exit Select
			Case &H1F
				cmbVillian3.SelectedItem = "Brawlrus"
				Exit Select
			Case &H20
				cmbVillian3.SelectedItem = "Tussle Sprout"
				Exit Select
			Case &H21
				cmbVillian3.SelectedItem = "Krankenstein"
				Exit Select
			Case &H22
				cmbVillian3.SelectedItem = "Scrap Shooter"
				Exit Select
			Case &H23
				cmbVillian3.SelectedItem = "Slobber Trap"
				Exit Select
			Case &H24
				cmbVillian3.SelectedItem = "Grinnade"
				Exit Select
			Case &H25
				cmbVillian3.SelectedItem = "Bad Juju"
				Exit Select
			Case &H26
				cmbVillian3.SelectedItem = "Blaster-Tron"
				Exit Select
			Case &H27
				cmbVillian3.SelectedItem = "Tae Kwon Crow"
				Exit Select
			Case &H28
				cmbVillian3.SelectedItem = "Painyata"
				Exit Select
			Case &H29
				cmbVillian3.SelectedItem = "Smoke Scream"
				Exit Select
			Case &H2A
				cmbVillian3.SelectedItem = "Eye Five"
				Exit Select
			Case &H2B
				cmbVillian3.SelectedItem = "Grave Clobber"
				Exit Select
			Case &H2C
				cmbVillian3.SelectedItem = "Threatpack"
				Exit Select
			Case &H2D
				cmbVillian3.SelectedItem = "Mab Lobs"
				Exit Select
			Case &H2E
				cmbVillian3.SelectedItem = "Eye Scream"
				Exit Select
			Case Else
				cmbVillian3.SelectedItem = "(None)"
				Exit Select
		End Select
		If WholeFile(&H2D1) = &H1 Then
			chkVillian3Evolved.Checked = True
		End If
		Dim Villian3_Hat As Byte = WholeFile(&H2D2)
		Select Case Villian3_Hat
			Case &H0
				cmbVillian3Hat.SelectedItem = "(None)"
			Case &HD3
				cmbVillian3Hat.SelectedItem = "Alarm Clock Hat"
			Case &HDA
				cmbVillian3Hat.SelectedItem = "Bat Hat"
			Case &HD4
				cmbVillian3Hat.SelectedItem = "Batter Up Hat"
			Case &H9B
				cmbVillian3Hat.SelectedItem = "Beetle Hat"
			Case &HED
				cmbVillian3Hat.SelectedItem = "Bellhop Hat"
			Case &HC3
				cmbVillian3Hat.SelectedItem = "Bobby"
			Case &H9C
				cmbVillian3Hat.SelectedItem = "Brain Hat"
			Case &H9D
				cmbVillian3Hat.SelectedItem = "Brainiac Hat"
			Case &HEE
				cmbVillian3Hat.SelectedItem = "Bronze Arkeyan Helm"
			Case &H9E
				cmbVillian3Hat.SelectedItem = "Bucket Hat"
			Case &HEA
				cmbVillian3Hat.SelectedItem = "Candle Hat"
			Case &HE8
				cmbVillian3Hat.SelectedItem = "Candy Cane Hat"
			Case &HF6
				cmbVillian3Hat.SelectedItem = "Carnival Hat"
			Case &HA0
				cmbVillian3Hat.SelectedItem = "Ceiling Fan Hat"
			Case &HBB
				cmbVillian3Hat.SelectedItem = "Classic Pot Hat"
			Case &HA3
				cmbVillian3Hat.SelectedItem = "Clown Bowler Hat"
			Case &HA2
				cmbVillian3Hat.SelectedItem = "Clown Classic Hat"
			Case &HF7
				cmbVillian3Hat.SelectedItem = "Coconut Hat"
			Case &HA4
				cmbVillian3Hat.SelectedItem = "Colander Hat"
			Case &HFC
				cmbVillian3Hat.SelectedItem = "Core Of Light Hat"
			Case &HA6
				cmbVillian3Hat.SelectedItem = "Cornucopia Hat"
			Case &HBD
				cmbVillian3Hat.SelectedItem = "Crazy Light Bulb Hat"
			Case &HD6
				cmbVillian3Hat.SelectedItem = "Croissant Hat"
			Case &HA7
				cmbVillian3Hat.SelectedItem = "Cubano Hat"
			Case &HA8
				cmbVillian3Hat.SelectedItem = "Cycling Hat"
			Case &HA9
				cmbVillian3Hat.SelectedItem = "Daisy Crown"
			Case &HEB
				cmbVillian3Hat.SelectedItem = "Dark Helm"
			Case &H9F
				cmbVillian3Hat.SelectedItem = "Desert Crown"
			Case &HAA
				cmbVillian3Hat.SelectedItem = "Dragon Skull"
			Case &HE9
				cmbVillian3Hat.SelectedItem = "Eggshell Hat"
			Case &HCB
				cmbVillian3Hat.SelectedItem = "Extreme Viking Hat"
			Case &HD9
				cmbVillian3Hat.SelectedItem = "Eye of Kaos Hat"
			Case &HDC
				cmbVillian3Hat.SelectedItem = "Firefly Jar"
			Case &HC6
				cmbVillian3Hat.SelectedItem = "Flight Attendant Hat"
			Case &HAE
				cmbVillian3Hat.SelectedItem = "Garrison Hat"
			Case &HAD
				cmbVillian3Hat.SelectedItem = "Generalissimo"
			Case &HE2
				cmbVillian3Hat.SelectedItem = "Gold Arkeyan Helm"
			Case &HAF
				cmbVillian3Hat.SelectedItem = "Gondolier Hat"
			Case &HC4
				cmbVillian3Hat.SelectedItem = "Hedgehog Hat"
			Case &HD5
				cmbVillian3Hat.SelectedItem = "Horns Be With You Hat"
			Case &HB0
				cmbVillian3Hat.SelectedItem = "Hunting Hat"
			Case &HA1
				cmbVillian3Hat.SelectedItem = "Imperial Hat"
			Case &HB1
				cmbVillian3Hat.SelectedItem = "Juicer Hat"
			Case &HA5
				cmbVillian3Hat.SelectedItem = "Kepi Hat"
			Case &HB2
				cmbVillian3Hat.SelectedItem = "Kokoshnik"
			Case &HDB
				cmbVillian3Hat.SelectedItem = "Light Bulb Hat"
			Case &HDE
				cmbVillian3Hat.SelectedItem = "Lighthouse Beacon Hat"
			Case &HAC
				cmbVillian3Hat.SelectedItem = "Lil' Elf Hat"
			Case &HB3
				cmbVillian3Hat.SelectedItem = "Medic Hat"
			Case &HB4
				cmbVillian3Hat.SelectedItem = "Melon Hat"
			Case &HC0
				cmbVillian3Hat.SelectedItem = "Metal Fin Hat"
			Case &HE5
				cmbVillian3Hat.SelectedItem = "Miniature Skylands Hat"
			Case &HFA
				cmbVillian3Hat.SelectedItem = "Molekin Mountain Hat"
			Case &HC7
				cmbVillian3Hat.SelectedItem = "Monday Hat"
			Case &HB5
				cmbVillian3Hat.SelectedItem = "Mountie Hat"
			Case &HE0
				cmbVillian3Hat.SelectedItem = "Night Cap"
			Case &HB6
				cmbVillian3Hat.SelectedItem = "Nurse Hat"
			Case &HFD
				cmbVillian3Hat.SelectedItem = "Octavius Cloptimus Hat"
			Case &HBA
				cmbVillian3Hat.SelectedItem = "Old-Time Movie Hat"
			Case &HAB
				cmbVillian3Hat.SelectedItem = "Outback Hat"
			Case &HB7
				cmbVillian3Hat.SelectedItem = "Palm Hat"
			Case &HB8
				cmbVillian3Hat.SelectedItem = "Paperboy Hat"
			Case &HB9
				cmbVillian3Hat.SelectedItem = "Parrot Nest"
			Case &HEC
				cmbVillian3Hat.SelectedItem = "Planet Hat"
			Case &HD2
				cmbVillian3Hat.SelectedItem = "Pork Pie Hat"
			Case &HE4
				cmbVillian3Hat.SelectedItem = "Pyramid Hat"
			Case &HBC
				cmbVillian3Hat.SelectedItem = "Radar Hat"
			Case &HD8
				cmbVillian3Hat.SelectedItem = "Rainbow Hat"
			Case &HBE
				cmbVillian3Hat.SelectedItem = "Rubber Glove Hat"
			Case &HD1
				cmbVillian3Hat.SelectedItem = "Rude Boy Hat"
			Case &HBF
				cmbVillian3Hat.SelectedItem = "Rugby Hat"
			Case &HCC
				cmbVillian3Hat.SelectedItem = "Scooter Hat"
			Case &HDD
				cmbVillian3Hat.SelectedItem = "Shadow Ghost Hat"
			Case &HC8
				cmbVillian3Hat.SelectedItem = "Sherpa Hat"
			Case &HC2
				cmbVillian3Hat.SelectedItem = "Shower Cap"
			Case &HEF
				cmbVillian3Hat.SelectedItem = "Silver Arkeyan Helm"
			Case &HF3
				cmbVillian3Hat.SelectedItem = "Skipper Hat"
			Case &HC1
				cmbVillian3Hat.SelectedItem = "Sleuth Hat"
			Case &HC5
				cmbVillian3Hat.SelectedItem = "Steampunk Hat"
			Case &HE1
				cmbVillian3Hat.SelectedItem = "Storm Hat"
			Case &HCE
				cmbVillian3Hat.SelectedItem = "Synchronized Swimming Cap"
			Case &HDF
				cmbVillian3Hat.SelectedItem = "Tin Foil Hat"
			Case &HE3
				cmbVillian3Hat.SelectedItem = "Toucan Hat"
			Case &HC9
				cmbVillian3Hat.SelectedItem = "Trash Lid"
			Case &HD0
				cmbVillian3Hat.SelectedItem = "Tribal Hat"
			Case &HCA
				cmbVillian3Hat.SelectedItem = "Turtle Hat"
			Case &HCD
				cmbVillian3Hat.SelectedItem = "Volcano Island Hat"
			Case &HD7
				cmbVillian3Hat.SelectedItem = "Weather Vane Hat"
			Case &HCF
				cmbVillian3Hat.SelectedItem = "William Tell Hat"
			Case Else
				cmbVillian3Hat.SelectedItem = "(None)"
		End Select
		Dim Villian3_Trinket As Byte = WholeFile(&H2D3)
		Select Case Villian3_Trinket
			Case &H0
				cmbVillian3Trinket.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian3Trinket.SelectedItem = "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				cmbVillian3Trinket.SelectedItem = "Batterson's Bubble"
				Exit Select
			Case &H3
				cmbVillian3Trinket.SelectedItem = "Dark Water Daisy"
				Exit Select
			Case &H4
				cmbVillian3Trinket.SelectedItem = "Vote For Cyclops"
				Exit Select
			Case &H5
				cmbVillian3Trinket.SelectedItem = "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				cmbVillian3Trinket.SelectedItem = "Iris' Iris"
				Exit Select
			Case &H7
				cmbVillian3Trinket.SelectedItem = "Kuckoo Kazoo"
				Exit Select
			Case &H8
				cmbVillian3Trinket.SelectedItem = "Ramses' Rune"
				Exit Select
			Case &H9
				cmbVillian3Trinket.SelectedItem = "Ullysses Uniclops"
				Exit Select
			Case &HA
				cmbVillian3Trinket.SelectedItem = "Billy Bison"
				Exit Select
			Case &HB
				cmbVillian3Trinket.SelectedItem = "Stealth Elf's Gift"
				Exit Select
			Case &HC
				cmbVillian3Trinket.SelectedItem = "Lizard Lilly"
				Exit Select
			Case &HD
				cmbVillian3Trinket.SelectedItem = "Pirate Pinwheel"
				Exit Select
			Case &HE
				cmbVillian3Trinket.SelectedItem = "Bubble Blower"
				Exit Select
			Case &HF
				cmbVillian3Trinket.SelectedItem = "Medal of Heroism"
				Exit Select
			Case &H10
				cmbVillian3Trinket.SelectedItem = "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				cmbVillian3Trinket.SelectedItem = "Medal of Valliance"
				Exit Select
			Case &H12
				cmbVillian3Trinket.SelectedItem = "Medal of Gallantry"
				Exit Select
			Case &H13
				cmbVillian3Trinket.SelectedItem = "Medal of Mettle"
				Exit Select
			Case &H14
				cmbVillian3Trinket.SelectedItem = "Winged Medal of Bravery"
				Exit Select
			Case &H15
				cmbVillian3Trinket.SelectedItem = "Seadog Seashell"
				Exit Select
			Case &H16
				cmbVillian3Trinket.SelectedItem = "Snuckles' Sunflower"
				Exit Select
			Case &H17
				cmbVillian3Trinket.SelectedItem = "Teddy Cyclops"
				Exit Select
			Case &H18
				cmbVillian3Trinket.SelectedItem = "Goo Factory Gear"
				Exit Select
			Case &H19
				cmbVillian3Trinket.SelectedItem = "Elemental Opal"
				Exit Select
			Case &H1A
				cmbVillian3Trinket.SelectedItem = "Elemental Radiant"
				Exit Select
			Case &H1B
				cmbVillian3Trinket.SelectedItem = "Elemental Diamond"
				Exit Select
			Case &H1C
				cmbVillian3Trinket.SelectedItem = "Cyclops Spinner"
				Exit Select
			Case &H1D
				cmbVillian3Trinket.SelectedItem = "Wiliken Windmill"
				Exit Select
			Case &H1E
				cmbVillian3Trinket.SelectedItem = "Time Town Ticker"
				Exit Select
			Case &H1F
				cmbVillian3Trinket.SelectedItem = "Big Bow of Doom"
				Exit Select
			Case &H20
				cmbVillian3Trinket.SelectedItem = "Mabu's Medallion"
				Exit Select
			Case &H21
				cmbVillian3Trinket.SelectedItem = "Spyro's Shield"
				Exit Select
			Case Else
				cmbVillian3Trinket.SelectedItem = "(None)"
				Exit Select
		End Select
		'Load Name from Byte 0x2D4
		txtVillian1Name.Text = Load_Name(&H2D4)

		'+&H40
		'Villian Four Data is 0x310 to 0x341
		'Ignore 0x330 Block as it's MiFare
		Dim Villian4_ID As Byte = WholeFile(&H310)
		Select Case Villian4_ID
			Case &H0
				cmbVillian4.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian4.SelectedItem = "Chompy Mage"
				Exit Select
			Case &H2
				cmbVillian4.SelectedItem = "Dr. Crankcase"
				Exit Select
			Case &H3
				cmbVillian4.SelectedItem = "Wolfgang"
				Exit Select
			Case &H4
				cmbVillian4.SelectedItem = "Chef Pepper Jack"
				Exit Select
			Case &H5
				cmbVillian4.SelectedItem = "Nightshade"
				Exit Select
			Case &H6
				cmbVillian4.SelectedItem = "Luminous"
				Exit Select
			Case &H7
				cmbVillian4.SelectedItem = "Golden Queen"
				Exit Select
			Case &H8
				cmbVillian4.SelectedItem = "Dreamcatcher"
				Exit Select
			Case &H9
				cmbVillian4.SelectedItem = "Gulper"
				Exit Select
			Case &HA
				cmbVillian4.SelectedItem = "Kaos"
				Exit Select
			Case &HB
				cmbVillian4.SelectedItem = "Cuckoo Clocker"
				Exit Select
			Case &HC
				cmbVillian4.SelectedItem = "Buzzer Beak"
				Exit Select
			Case &HD
				cmbVillian4.SelectedItem = "Shield Shredder"
				Exit Select
			Case &HE
				cmbVillian4.SelectedItem = "Cross Crow"
				Exit Select
			Case &HF
				cmbVillian4.SelectedItem = "Bone Chompy"
				Exit Select
			Case &H10
				cmbVillian4.SelectedItem = "Brawl and Chain"
				Exit Select
			Case &H11
				cmbVillian4.SelectedItem = "Bomb Shell"
				Exit Select
			Case &H12
				cmbVillian4.SelectedItem = "Masker Mind"
				Exit Select
			Case &H13
				cmbVillian4.SelectedItem = "Chill Bill"
				Exit Select
			Case &H14
				cmbVillian4.SelectedItem = "Sheep Creep"
				Exit Select
			Case &H15
				cmbVillian4.SelectedItem = "Shrednaught"
				Exit Select
			Case &H16
				cmbVillian4.SelectedItem = "Chomp Chest"
				Exit Select
			Case &H17
				cmbVillian4.SelectedItem = "Broccoli Guy"
				Exit Select
			Case &H18
				cmbVillian4.SelectedItem = "Rage Mage"
				Exit Select
			Case &H19
				cmbVillian4.SelectedItem = "Lob Goblin"
				Exit Select
			Case &H1A
				cmbVillian4.SelectedItem = "Chompy"
				Exit Select
			Case &H1B
				cmbVillian4.SelectedItem = "Fisticuffs"
				Exit Select
			Case &H1C
				cmbVillian4.SelectedItem = "Trolling Thunder"
				Exit Select
			Case &H1D
				cmbVillian4.SelectedItem = "Hood Sickle"
				Exit Select
			Case &H1E
				cmbVillian4.SelectedItem = "Bruiser Cruiser"
				Exit Select
			Case &H1F
				cmbVillian4.SelectedItem = "Brawlrus"
				Exit Select
			Case &H20
				cmbVillian4.SelectedItem = "Tussle Sprout"
				Exit Select
			Case &H21
				cmbVillian4.SelectedItem = "Krankenstein"
				Exit Select
			Case &H22
				cmbVillian4.SelectedItem = "Scrap Shooter"
				Exit Select
			Case &H23
				cmbVillian4.SelectedItem = "Slobber Trap"
				Exit Select
			Case &H24
				cmbVillian4.SelectedItem = "Grinnade"
				Exit Select
			Case &H25
				cmbVillian4.SelectedItem = "Bad Juju"
				Exit Select
			Case &H26
				cmbVillian4.SelectedItem = "Blaster-Tron"
				Exit Select
			Case &H27
				cmbVillian4.SelectedItem = "Tae Kwon Crow"
				Exit Select
			Case &H28
				cmbVillian4.SelectedItem = "Painyata"
				Exit Select
			Case &H29
				cmbVillian4.SelectedItem = "Smoke Scream"
				Exit Select
			Case &H2A
				cmbVillian4.SelectedItem = "Eye Five"
				Exit Select
			Case &H2B
				cmbVillian4.SelectedItem = "Grave Clobber"
				Exit Select
			Case &H2C
				cmbVillian4.SelectedItem = "Threatpack"
				Exit Select
			Case &H2D
				cmbVillian4.SelectedItem = "Mab Lobs"
				Exit Select
			Case &H2E
				cmbVillian4.SelectedItem = "Eye Scream"
				Exit Select
			Case Else
				cmbVillian4.SelectedItem = "(None)"
				Exit Select
		End Select
		If WholeFile(&H311) = &H1 Then
			chkVillian4Evolved.Checked = True
		End If
		Dim Villian4_Hat As Byte = WholeFile(&H312)
		Select Case Villian4_Hat
			Case &H0
				cmbVillian4Hat.SelectedItem = "(None)"
			Case &HD3
				cmbVillian4Hat.SelectedItem = "Alarm Clock Hat"
			Case &HDA
				cmbVillian4Hat.SelectedItem = "Bat Hat"
			Case &HD4
				cmbVillian4Hat.SelectedItem = "Batter Up Hat"
			Case &H9B
				cmbVillian4Hat.SelectedItem = "Beetle Hat"
			Case &HED
				cmbVillian4Hat.SelectedItem = "Bellhop Hat"
			Case &HC3
				cmbVillian4Hat.SelectedItem = "Bobby"
			Case &H9C
				cmbVillian4Hat.SelectedItem = "Brain Hat"
			Case &H9D
				cmbVillian4Hat.SelectedItem = "Brainiac Hat"
			Case &HEE
				cmbVillian4Hat.SelectedItem = "Bronze Arkeyan Helm"
			Case &H9E
				cmbVillian4Hat.SelectedItem = "Bucket Hat"
			Case &HEA
				cmbVillian4Hat.SelectedItem = "Candle Hat"
			Case &HE8
				cmbVillian4Hat.SelectedItem = "Candy Cane Hat"
			Case &HF6
				cmbVillian4Hat.SelectedItem = "Carnival Hat"
			Case &HA0
				cmbVillian4Hat.SelectedItem = "Ceiling Fan Hat"
			Case &HBB
				cmbVillian4Hat.SelectedItem = "Classic Pot Hat"
			Case &HA3
				cmbVillian4Hat.SelectedItem = "Clown Bowler Hat"
			Case &HA2
				cmbVillian4Hat.SelectedItem = "Clown Classic Hat"
			Case &HF7
				cmbVillian4Hat.SelectedItem = "Coconut Hat"
			Case &HA4
				cmbVillian4Hat.SelectedItem = "Colander Hat"
			Case &HFC
				cmbVillian4Hat.SelectedItem = "Core Of Light Hat"
			Case &HA6
				cmbVillian4Hat.SelectedItem = "Cornucopia Hat"
			Case &HBD
				cmbVillian4Hat.SelectedItem = "Crazy Light Bulb Hat"
			Case &HD6
				cmbVillian4Hat.SelectedItem = "Croissant Hat"
			Case &HA7
				cmbVillian4Hat.SelectedItem = "Cubano Hat"
			Case &HA8
				cmbVillian4Hat.SelectedItem = "Cycling Hat"
			Case &HA9
				cmbVillian4Hat.SelectedItem = "Daisy Crown"
			Case &HEB
				cmbVillian4Hat.SelectedItem = "Dark Helm"
			Case &H9F
				cmbVillian4Hat.SelectedItem = "Desert Crown"
			Case &HAA
				cmbVillian4Hat.SelectedItem = "Dragon Skull"
			Case &HE9
				cmbVillian4Hat.SelectedItem = "Eggshell Hat"
			Case &HCB
				cmbVillian4Hat.SelectedItem = "Extreme Viking Hat"
			Case &HD9
				cmbVillian4Hat.SelectedItem = "Eye of Kaos Hat"
			Case &HDC
				cmbVillian4Hat.SelectedItem = "Firefly Jar"
			Case &HC6
				cmbVillian4Hat.SelectedItem = "Flight Attendant Hat"
			Case &HAE
				cmbVillian4Hat.SelectedItem = "Garrison Hat"
			Case &HAD
				cmbVillian4Hat.SelectedItem = "Generalissimo"
			Case &HE2
				cmbVillian4Hat.SelectedItem = "Gold Arkeyan Helm"
			Case &HAF
				cmbVillian4Hat.SelectedItem = "Gondolier Hat"
			Case &HC4
				cmbVillian4Hat.SelectedItem = "Hedgehog Hat"
			Case &HD5
				cmbVillian4Hat.SelectedItem = "Horns Be With You Hat"
			Case &HB0
				cmbVillian4Hat.SelectedItem = "Hunting Hat"
			Case &HA1
				cmbVillian4Hat.SelectedItem = "Imperial Hat"
			Case &HB1
				cmbVillian4Hat.SelectedItem = "Juicer Hat"
			Case &HA5
				cmbVillian4Hat.SelectedItem = "Kepi Hat"
			Case &HB2
				cmbVillian4Hat.SelectedItem = "Kokoshnik"
			Case &HDB
				cmbVillian4Hat.SelectedItem = "Light Bulb Hat"
			Case &HDE
				cmbVillian4Hat.SelectedItem = "Lighthouse Beacon Hat"
			Case &HAC
				cmbVillian4Hat.SelectedItem = "Lil' Elf Hat"
			Case &HB3
				cmbVillian4Hat.SelectedItem = "Medic Hat"
			Case &HB4
				cmbVillian4Hat.SelectedItem = "Melon Hat"
			Case &HC0
				cmbVillian4Hat.SelectedItem = "Metal Fin Hat"
			Case &HE5
				cmbVillian4Hat.SelectedItem = "Miniature Skylands Hat"
			Case &HFA
				cmbVillian4Hat.SelectedItem = "Molekin Mountain Hat"
			Case &HC7
				cmbVillian4Hat.SelectedItem = "Monday Hat"
			Case &HB5
				cmbVillian4Hat.SelectedItem = "Mountie Hat"
			Case &HE0
				cmbVillian4Hat.SelectedItem = "Night Cap"
			Case &HB6
				cmbVillian4Hat.SelectedItem = "Nurse Hat"
			Case &HFD
				cmbVillian4Hat.SelectedItem = "Octavius Cloptimus Hat"
			Case &HBA
				cmbVillian4Hat.SelectedItem = "Old-Time Movie Hat"
			Case &HAB
				cmbVillian4Hat.SelectedItem = "Outback Hat"
			Case &HB7
				cmbVillian4Hat.SelectedItem = "Palm Hat"
			Case &HB8
				cmbVillian4Hat.SelectedItem = "Paperboy Hat"
			Case &HB9
				cmbVillian4Hat.SelectedItem = "Parrot Nest"
			Case &HEC
				cmbVillian4Hat.SelectedItem = "Planet Hat"
			Case &HD2
				cmbVillian4Hat.SelectedItem = "Pork Pie Hat"
			Case &HE4
				cmbVillian4Hat.SelectedItem = "Pyramid Hat"
			Case &HBC
				cmbVillian4Hat.SelectedItem = "Radar Hat"
			Case &HD8
				cmbVillian4Hat.SelectedItem = "Rainbow Hat"
			Case &HBE
				cmbVillian4Hat.SelectedItem = "Rubber Glove Hat"
			Case &HD1
				cmbVillian4Hat.SelectedItem = "Rude Boy Hat"
			Case &HBF
				cmbVillian4Hat.SelectedItem = "Rugby Hat"
			Case &HCC
				cmbVillian4Hat.SelectedItem = "Scooter Hat"
			Case &HDD
				cmbVillian4Hat.SelectedItem = "Shadow Ghost Hat"
			Case &HC8
				cmbVillian4Hat.SelectedItem = "Sherpa Hat"
			Case &HC2
				cmbVillian4Hat.SelectedItem = "Shower Cap"
			Case &HEF
				cmbVillian4Hat.SelectedItem = "Silver Arkeyan Helm"
			Case &HF3
				cmbVillian4Hat.SelectedItem = "Skipper Hat"
			Case &HC1
				cmbVillian4Hat.SelectedItem = "Sleuth Hat"
			Case &HC5
				cmbVillian4Hat.SelectedItem = "Steampunk Hat"
			Case &HE1
				cmbVillian4Hat.SelectedItem = "Storm Hat"
			Case &HCE
				cmbVillian4Hat.SelectedItem = "Synchronized Swimming Cap"
			Case &HDF
				cmbVillian4Hat.SelectedItem = "Tin Foil Hat"
			Case &HE3
				cmbVillian4Hat.SelectedItem = "Toucan Hat"
			Case &HC9
				cmbVillian4Hat.SelectedItem = "Trash Lid"
			Case &HD0
				cmbVillian4Hat.SelectedItem = "Tribal Hat"
			Case &HCA
				cmbVillian4Hat.SelectedItem = "Turtle Hat"
			Case &HCD
				cmbVillian4Hat.SelectedItem = "Volcano Island Hat"
			Case &HD7
				cmbVillian4Hat.SelectedItem = "Weather Vane Hat"
			Case &HCF
				cmbVillian4Hat.SelectedItem = "William Tell Hat"
			Case Else
				cmbVillian4Hat.SelectedItem = "(None)"
		End Select
		Dim Villian4_Trinket As Byte = WholeFile(&H313)
		Select Case Villian4_Trinket
			Case &H0
				cmbVillian4Trinket.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian4Trinket.SelectedItem = "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				cmbVillian4Trinket.SelectedItem = "Batterson's Bubble"
				Exit Select
			Case &H3
				cmbVillian4Trinket.SelectedItem = "Dark Water Daisy"
				Exit Select
			Case &H4
				cmbVillian4Trinket.SelectedItem = "Vote For Cyclops"
				Exit Select
			Case &H5
				cmbVillian4Trinket.SelectedItem = "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				cmbVillian4Trinket.SelectedItem = "Iris' Iris"
				Exit Select
			Case &H7
				cmbVillian4Trinket.SelectedItem = "Kuckoo Kazoo"
				Exit Select
			Case &H8
				cmbVillian4Trinket.SelectedItem = "Ramses' Rune"
				Exit Select
			Case &H9
				cmbVillian4Trinket.SelectedItem = "Ullysses Uniclops"
				Exit Select
			Case &HA
				cmbVillian4Trinket.SelectedItem = "Billy Bison"
				Exit Select
			Case &HB
				cmbVillian4Trinket.SelectedItem = "Stealth Elf's Gift"
				Exit Select
			Case &HC
				cmbVillian4Trinket.SelectedItem = "Lizard Lilly"
				Exit Select
			Case &HD
				cmbVillian4Trinket.SelectedItem = "Pirate Pinwheel"
				Exit Select
			Case &HE
				cmbVillian4Trinket.SelectedItem = "Bubble Blower"
				Exit Select
			Case &HF
				cmbVillian4Trinket.SelectedItem = "Medal of Heroism"
				Exit Select
			Case &H10
				cmbVillian4Trinket.SelectedItem = "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				cmbVillian4Trinket.SelectedItem = "Medal of Valliance"
				Exit Select
			Case &H12
				cmbVillian4Trinket.SelectedItem = "Medal of Gallantry"
				Exit Select
			Case &H13
				cmbVillian4Trinket.SelectedItem = "Medal of Mettle"
				Exit Select
			Case &H14
				cmbVillian4Trinket.SelectedItem = "Winged Medal of Bravery"
				Exit Select
			Case &H15
				cmbVillian4Trinket.SelectedItem = "Seadog Seashell"
				Exit Select
			Case &H16
				cmbVillian4Trinket.SelectedItem = "Snuckles' Sunflower"
				Exit Select
			Case &H17
				cmbVillian4Trinket.SelectedItem = "Teddy Cyclops"
				Exit Select
			Case &H18
				cmbVillian4Trinket.SelectedItem = "Goo Factory Gear"
				Exit Select
			Case &H19
				cmbVillian4Trinket.SelectedItem = "Elemental Opal"
				Exit Select
			Case &H1A
				cmbVillian4Trinket.SelectedItem = "Elemental Radiant"
				Exit Select
			Case &H1B
				cmbVillian4Trinket.SelectedItem = "Elemental Diamond"
				Exit Select
			Case &H1C
				cmbVillian4Trinket.SelectedItem = "Cyclops Spinner"
				Exit Select
			Case &H1D
				cmbVillian4Trinket.SelectedItem = "Wiliken Windmill"
				Exit Select
			Case &H1E
				cmbVillian4Trinket.SelectedItem = "Time Town Ticker"
				Exit Select
			Case &H1F
				cmbVillian4Trinket.SelectedItem = "Big Bow of Doom"
				Exit Select
			Case &H20
				cmbVillian4Trinket.SelectedItem = "Mabu's Medallion"
				Exit Select
			Case &H21
				cmbVillian4Trinket.SelectedItem = "Spyro's Shield"
				Exit Select
			Case Else
				cmbVillian4Trinket.SelectedItem = "(None)"
				Exit Select
		End Select
		'Load Name from Byte 0x314
		txtVillian1Name.Text = Load_Name(&H314)

		'+&H40
		'Villian Five Data is 0x350 to 0x381
		'Ignore 0x370 Block as it's MiFare
		Dim Villian5_ID As Byte = WholeFile(&H350)
		Select Case Villian5_ID
			Case &H0
				cmbVillian5.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian5.SelectedItem = "Chompy Mage"
				Exit Select
			Case &H2
				cmbVillian5.SelectedItem = "Dr. Crankcase"
				Exit Select
			Case &H3
				cmbVillian5.SelectedItem = "Wolfgang"
				Exit Select
			Case &H4
				cmbVillian5.SelectedItem = "Chef Pepper Jack"
				Exit Select
			Case &H5
				cmbVillian5.SelectedItem = "Nightshade"
				Exit Select
			Case &H6
				cmbVillian5.SelectedItem = "Luminous"
				Exit Select
			Case &H7
				cmbVillian5.SelectedItem = "Golden Queen"
				Exit Select
			Case &H8
				cmbVillian5.SelectedItem = "Dreamcatcher"
				Exit Select
			Case &H9
				cmbVillian5.SelectedItem = "Gulper"
				Exit Select
			Case &HA
				cmbVillian5.SelectedItem = "Kaos"
				Exit Select
			Case &HB
				cmbVillian5.SelectedItem = "Cuckoo Clocker"
				Exit Select
			Case &HC
				cmbVillian5.SelectedItem = "Buzzer Beak"
				Exit Select
			Case &HD
				cmbVillian5.SelectedItem = "Shield Shredder"
				Exit Select
			Case &HE
				cmbVillian5.SelectedItem = "Cross Crow"
				Exit Select
			Case &HF
				cmbVillian5.SelectedItem = "Bone Chompy"
				Exit Select
			Case &H10
				cmbVillian5.SelectedItem = "Brawl and Chain"
				Exit Select
			Case &H11
				cmbVillian5.SelectedItem = "Bomb Shell"
				Exit Select
			Case &H12
				cmbVillian5.SelectedItem = "Masker Mind"
				Exit Select
			Case &H13
				cmbVillian5.SelectedItem = "Chill Bill"
				Exit Select
			Case &H14
				cmbVillian5.SelectedItem = "Sheep Creep"
				Exit Select
			Case &H15
				cmbVillian5.SelectedItem = "Shrednaught"
				Exit Select
			Case &H16
				cmbVillian5.SelectedItem = "Chomp Chest"
				Exit Select
			Case &H17
				cmbVillian5.SelectedItem = "Broccoli Guy"
				Exit Select
			Case &H18
				cmbVillian5.SelectedItem = "Rage Mage"
				Exit Select
			Case &H19
				cmbVillian5.SelectedItem = "Lob Goblin"
				Exit Select
			Case &H1A
				cmbVillian5.SelectedItem = "Chompy"
				Exit Select
			Case &H1B
				cmbVillian5.SelectedItem = "Fisticuffs"
				Exit Select
			Case &H1C
				cmbVillian5.SelectedItem = "Trolling Thunder"
				Exit Select
			Case &H1D
				cmbVillian5.SelectedItem = "Hood Sickle"
				Exit Select
			Case &H1E
				cmbVillian5.SelectedItem = "Bruiser Cruiser"
				Exit Select
			Case &H1F
				cmbVillian5.SelectedItem = "Brawlrus"
				Exit Select
			Case &H20
				cmbVillian5.SelectedItem = "Tussle Sprout"
				Exit Select
			Case &H21
				cmbVillian5.SelectedItem = "Krankenstein"
				Exit Select
			Case &H22
				cmbVillian5.SelectedItem = "Scrap Shooter"
				Exit Select
			Case &H23
				cmbVillian5.SelectedItem = "Slobber Trap"
				Exit Select
			Case &H24
				cmbVillian5.SelectedItem = "Grinnade"
				Exit Select
			Case &H25
				cmbVillian5.SelectedItem = "Bad Juju"
				Exit Select
			Case &H26
				cmbVillian5.SelectedItem = "Blaster-Tron"
				Exit Select
			Case &H27
				cmbVillian5.SelectedItem = "Tae Kwon Crow"
				Exit Select
			Case &H28
				cmbVillian5.SelectedItem = "Painyata"
				Exit Select
			Case &H29
				cmbVillian5.SelectedItem = "Smoke Scream"
				Exit Select
			Case &H2A
				cmbVillian5.SelectedItem = "Eye Five"
				Exit Select
			Case &H2B
				cmbVillian5.SelectedItem = "Grave Clobber"
				Exit Select
			Case &H2C
				cmbVillian5.SelectedItem = "Threatpack"
				Exit Select
			Case &H2D
				cmbVillian5.SelectedItem = "Mab Lobs"
				Exit Select
			Case &H2E
				cmbVillian5.SelectedItem = "Eye Scream"
				Exit Select
			Case Else
				cmbVillian5.SelectedItem = "(None)"
				Exit Select
		End Select
		If WholeFile(&H351) = &H1 Then
			chkVillian5Evolved.Checked = True
		End If
		Dim Villian5_Hat As Byte = WholeFile(&H352)
		Select Case Villian5_Hat
			Case &H0
				cmbVillian5Hat.SelectedItem = "(None)"
			Case &HD3
				cmbVillian5Hat.SelectedItem = "Alarm Clock Hat"
			Case &HDA
				cmbVillian5Hat.SelectedItem = "Bat Hat"
			Case &HD4
				cmbVillian5Hat.SelectedItem = "Batter Up Hat"
			Case &H9B
				cmbVillian5Hat.SelectedItem = "Beetle Hat"
			Case &HED
				cmbVillian5Hat.SelectedItem = "Bellhop Hat"
			Case &HC3
				cmbVillian5Hat.SelectedItem = "Bobby"
			Case &H9C
				cmbVillian5Hat.SelectedItem = "Brain Hat"
			Case &H9D
				cmbVillian5Hat.SelectedItem = "Brainiac Hat"
			Case &HEE
				cmbVillian5Hat.SelectedItem = "Bronze Arkeyan Helm"
			Case &H9E
				cmbVillian5Hat.SelectedItem = "Bucket Hat"
			Case &HEA
				cmbVillian5Hat.SelectedItem = "Candle Hat"
			Case &HE8
				cmbVillian5Hat.SelectedItem = "Candy Cane Hat"
			Case &HF6
				cmbVillian5Hat.SelectedItem = "Carnival Hat"
			Case &HA0
				cmbVillian5Hat.SelectedItem = "Ceiling Fan Hat"
			Case &HBB
				cmbVillian5Hat.SelectedItem = "Classic Pot Hat"
			Case &HA3
				cmbVillian5Hat.SelectedItem = "Clown Bowler Hat"
			Case &HA2
				cmbVillian5Hat.SelectedItem = "Clown Classic Hat"
			Case &HF7
				cmbVillian5Hat.SelectedItem = "Coconut Hat"
			Case &HA4
				cmbVillian5Hat.SelectedItem = "Colander Hat"
			Case &HFC
				cmbVillian5Hat.SelectedItem = "Core Of Light Hat"
			Case &HA6
				cmbVillian5Hat.SelectedItem = "Cornucopia Hat"
			Case &HBD
				cmbVillian5Hat.SelectedItem = "Crazy Light Bulb Hat"
			Case &HD6
				cmbVillian5Hat.SelectedItem = "Croissant Hat"
			Case &HA7
				cmbVillian5Hat.SelectedItem = "Cubano Hat"
			Case &HA8
				cmbVillian5Hat.SelectedItem = "Cycling Hat"
			Case &HA9
				cmbVillian5Hat.SelectedItem = "Daisy Crown"
			Case &HEB
				cmbVillian5Hat.SelectedItem = "Dark Helm"
			Case &H9F
				cmbVillian5Hat.SelectedItem = "Desert Crown"
			Case &HAA
				cmbVillian5Hat.SelectedItem = "Dragon Skull"
			Case &HE9
				cmbVillian5Hat.SelectedItem = "Eggshell Hat"
			Case &HCB
				cmbVillian5Hat.SelectedItem = "Extreme Viking Hat"
			Case &HD9
				cmbVillian5Hat.SelectedItem = "Eye of Kaos Hat"
			Case &HDC
				cmbVillian5Hat.SelectedItem = "Firefly Jar"
			Case &HC6
				cmbVillian5Hat.SelectedItem = "Flight Attendant Hat"
			Case &HAE
				cmbVillian5Hat.SelectedItem = "Garrison Hat"
			Case &HAD
				cmbVillian5Hat.SelectedItem = "Generalissimo"
			Case &HE2
				cmbVillian5Hat.SelectedItem = "Gold Arkeyan Helm"
			Case &HAF
				cmbVillian5Hat.SelectedItem = "Gondolier Hat"
			Case &HC4
				cmbVillian5Hat.SelectedItem = "Hedgehog Hat"
			Case &HD5
				cmbVillian5Hat.SelectedItem = "Horns Be With You Hat"
			Case &HB0
				cmbVillian5Hat.SelectedItem = "Hunting Hat"
			Case &HA1
				cmbVillian5Hat.SelectedItem = "Imperial Hat"
			Case &HB1
				cmbVillian5Hat.SelectedItem = "Juicer Hat"
			Case &HA5
				cmbVillian5Hat.SelectedItem = "Kepi Hat"
			Case &HB2
				cmbVillian5Hat.SelectedItem = "Kokoshnik"
			Case &HDB
				cmbVillian5Hat.SelectedItem = "Light Bulb Hat"
			Case &HDE
				cmbVillian5Hat.SelectedItem = "Lighthouse Beacon Hat"
			Case &HAC
				cmbVillian5Hat.SelectedItem = "Lil' Elf Hat"
			Case &HB3
				cmbVillian5Hat.SelectedItem = "Medic Hat"
			Case &HB4
				cmbVillian5Hat.SelectedItem = "Melon Hat"
			Case &HC0
				cmbVillian5Hat.SelectedItem = "Metal Fin Hat"
			Case &HE5
				cmbVillian5Hat.SelectedItem = "Miniature Skylands Hat"
			Case &HFA
				cmbVillian5Hat.SelectedItem = "Molekin Mountain Hat"
			Case &HC7
				cmbVillian5Hat.SelectedItem = "Monday Hat"
			Case &HB5
				cmbVillian5Hat.SelectedItem = "Mountie Hat"
			Case &HE0
				cmbVillian5Hat.SelectedItem = "Night Cap"
			Case &HB6
				cmbVillian5Hat.SelectedItem = "Nurse Hat"
			Case &HFD
				cmbVillian5Hat.SelectedItem = "Octavius Cloptimus Hat"
			Case &HBA
				cmbVillian5Hat.SelectedItem = "Old-Time Movie Hat"
			Case &HAB
				cmbVillian5Hat.SelectedItem = "Outback Hat"
			Case &HB7
				cmbVillian5Hat.SelectedItem = "Palm Hat"
			Case &HB8
				cmbVillian5Hat.SelectedItem = "Paperboy Hat"
			Case &HB9
				cmbVillian5Hat.SelectedItem = "Parrot Nest"
			Case &HEC
				cmbVillian5Hat.SelectedItem = "Planet Hat"
			Case &HD2
				cmbVillian5Hat.SelectedItem = "Pork Pie Hat"
			Case &HE4
				cmbVillian5Hat.SelectedItem = "Pyramid Hat"
			Case &HBC
				cmbVillian5Hat.SelectedItem = "Radar Hat"
			Case &HD8
				cmbVillian5Hat.SelectedItem = "Rainbow Hat"
			Case &HBE
				cmbVillian5Hat.SelectedItem = "Rubber Glove Hat"
			Case &HD1
				cmbVillian5Hat.SelectedItem = "Rude Boy Hat"
			Case &HBF
				cmbVillian5Hat.SelectedItem = "Rugby Hat"
			Case &HCC
				cmbVillian5Hat.SelectedItem = "Scooter Hat"
			Case &HDD
				cmbVillian5Hat.SelectedItem = "Shadow Ghost Hat"
			Case &HC8
				cmbVillian5Hat.SelectedItem = "Sherpa Hat"
			Case &HC2
				cmbVillian5Hat.SelectedItem = "Shower Cap"
			Case &HEF
				cmbVillian5Hat.SelectedItem = "Silver Arkeyan Helm"
			Case &HF3
				cmbVillian5Hat.SelectedItem = "Skipper Hat"
			Case &HC1
				cmbVillian5Hat.SelectedItem = "Sleuth Hat"
			Case &HC5
				cmbVillian5Hat.SelectedItem = "Steampunk Hat"
			Case &HE1
				cmbVillian5Hat.SelectedItem = "Storm Hat"
			Case &HCE
				cmbVillian5Hat.SelectedItem = "Synchronized Swimming Cap"
			Case &HDF
				cmbVillian5Hat.SelectedItem = "Tin Foil Hat"
			Case &HE3
				cmbVillian5Hat.SelectedItem = "Toucan Hat"
			Case &HC9
				cmbVillian5Hat.SelectedItem = "Trash Lid"
			Case &HD0
				cmbVillian5Hat.SelectedItem = "Tribal Hat"
			Case &HCA
				cmbVillian5Hat.SelectedItem = "Turtle Hat"
			Case &HCD
				cmbVillian5Hat.SelectedItem = "Volcano Island Hat"
			Case &HD7
				cmbVillian5Hat.SelectedItem = "Weather Vane Hat"
			Case &HCF
				cmbVillian5Hat.SelectedItem = "William Tell Hat"
			Case Else
				cmbVillian5Hat.SelectedItem = "(None)"
		End Select
		Dim Villian5_Trinket As Byte = WholeFile(&H353)
		Select Case Villian5_Trinket
			Case &H0
				cmbVillian5Trinket.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian5Trinket.SelectedItem = "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				cmbVillian5Trinket.SelectedItem = "Batterson's Bubble"
				Exit Select
			Case &H3
				cmbVillian5Trinket.SelectedItem = "Dark Water Daisy"
				Exit Select
			Case &H4
				cmbVillian5Trinket.SelectedItem = "Vote For Cyclops"
				Exit Select
			Case &H5
				cmbVillian5Trinket.SelectedItem = "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				cmbVillian5Trinket.SelectedItem = "Iris' Iris"
				Exit Select
			Case &H7
				cmbVillian5Trinket.SelectedItem = "Kuckoo Kazoo"
				Exit Select
			Case &H8
				cmbVillian5Trinket.SelectedItem = "Ramses' Rune"
				Exit Select
			Case &H9
				cmbVillian5Trinket.SelectedItem = "Ullysses Uniclops"
				Exit Select
			Case &HA
				cmbVillian5Trinket.SelectedItem = "Billy Bison"
				Exit Select
			Case &HB
				cmbVillian5Trinket.SelectedItem = "Stealth Elf's Gift"
				Exit Select
			Case &HC
				cmbVillian5Trinket.SelectedItem = "Lizard Lilly"
				Exit Select
			Case &HD
				cmbVillian5Trinket.SelectedItem = "Pirate Pinwheel"
				Exit Select
			Case &HE
				cmbVillian5Trinket.SelectedItem = "Bubble Blower"
				Exit Select
			Case &HF
				cmbVillian5Trinket.SelectedItem = "Medal of Heroism"
				Exit Select
			Case &H10
				cmbVillian5Trinket.SelectedItem = "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				cmbVillian5Trinket.SelectedItem = "Medal of Valliance"
				Exit Select
			Case &H12
				cmbVillian5Trinket.SelectedItem = "Medal of Gallantry"
				Exit Select
			Case &H13
				cmbVillian5Trinket.SelectedItem = "Medal of Mettle"
				Exit Select
			Case &H14
				cmbVillian5Trinket.SelectedItem = "Winged Medal of Bravery"
				Exit Select
			Case &H15
				cmbVillian5Trinket.SelectedItem = "Seadog Seashell"
				Exit Select
			Case &H16
				cmbVillian5Trinket.SelectedItem = "Snuckles' Sunflower"
				Exit Select
			Case &H17
				cmbVillian5Trinket.SelectedItem = "Teddy Cyclops"
				Exit Select
			Case &H18
				cmbVillian5Trinket.SelectedItem = "Goo Factory Gear"
				Exit Select
			Case &H19
				cmbVillian5Trinket.SelectedItem = "Elemental Opal"
				Exit Select
			Case &H1A
				cmbVillian5Trinket.SelectedItem = "Elemental Radiant"
				Exit Select
			Case &H1B
				cmbVillian5Trinket.SelectedItem = "Elemental Diamond"
				Exit Select
			Case &H1C
				cmbVillian5Trinket.SelectedItem = "Cyclops Spinner"
				Exit Select
			Case &H1D
				cmbVillian5Trinket.SelectedItem = "Wiliken Windmill"
				Exit Select
			Case &H1E
				cmbVillian5Trinket.SelectedItem = "Time Town Ticker"
				Exit Select
			Case &H1F
				cmbVillian5Trinket.SelectedItem = "Big Bow of Doom"
				Exit Select
			Case &H20
				cmbVillian5Trinket.SelectedItem = "Mabu's Medallion"
				Exit Select
			Case &H21
				cmbVillian5Trinket.SelectedItem = "Spyro's Shield"
				Exit Select
			Case Else
				cmbVillian5Trinket.SelectedItem = "(None)"
				Exit Select
		End Select
		'Load Name from Byte 0x354
		txtVillian1Name.Text = Load_Name(&H354)

		'+&H40
		'Villian Six Data is 0x390 to 0x3C1
		'Ignore 0x3B0 Block as it's MiFare
		Dim Villian6_ID As Byte = WholeFile(&H390)
		Select Case Villian6_ID
			Case &H0
				cmbVillian6.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian6.SelectedItem = "Chompy Mage"
				Exit Select
			Case &H2
				cmbVillian6.SelectedItem = "Dr. Crankcase"
				Exit Select
			Case &H3
				cmbVillian6.SelectedItem = "Wolfgang"
				Exit Select
			Case &H4
				cmbVillian6.SelectedItem = "Chef Pepper Jack"
				Exit Select
			Case &H5
				cmbVillian6.SelectedItem = "Nightshade"
				Exit Select
			Case &H6
				cmbVillian6.SelectedItem = "Luminous"
				Exit Select
			Case &H7
				cmbVillian6.SelectedItem = "Golden Queen"
				Exit Select
			Case &H8
				cmbVillian6.SelectedItem = "Dreamcatcher"
				Exit Select
			Case &H9
				cmbVillian6.SelectedItem = "Gulper"
				Exit Select
			Case &HA
				cmbVillian6.SelectedItem = "Kaos"
				Exit Select
			Case &HB
				cmbVillian6.SelectedItem = "Cuckoo Clocker"
				Exit Select
			Case &HC
				cmbVillian6.SelectedItem = "Buzzer Beak"
				Exit Select
			Case &HD
				cmbVillian6.SelectedItem = "Shield Shredder"
				Exit Select
			Case &HE
				cmbVillian6.SelectedItem = "Cross Crow"
				Exit Select
			Case &HF
				cmbVillian6.SelectedItem = "Bone Chompy"
				Exit Select
			Case &H10
				cmbVillian6.SelectedItem = "Brawl and Chain"
				Exit Select
			Case &H11
				cmbVillian6.SelectedItem = "Bomb Shell"
				Exit Select
			Case &H12
				cmbVillian6.SelectedItem = "Masker Mind"
				Exit Select
			Case &H13
				cmbVillian6.SelectedItem = "Chill Bill"
				Exit Select
			Case &H14
				cmbVillian6.SelectedItem = "Sheep Creep"
				Exit Select
			Case &H15
				cmbVillian6.SelectedItem = "Shrednaught"
				Exit Select
			Case &H16
				cmbVillian6.SelectedItem = "Chomp Chest"
				Exit Select
			Case &H17
				cmbVillian6.SelectedItem = "Broccoli Guy"
				Exit Select
			Case &H18
				cmbVillian6.SelectedItem = "Rage Mage"
				Exit Select
			Case &H19
				cmbVillian6.SelectedItem = "Lob Goblin"
				Exit Select
			Case &H1A
				cmbVillian6.SelectedItem = "Chompy"
				Exit Select
			Case &H1B
				cmbVillian6.SelectedItem = "Fisticuffs"
				Exit Select
			Case &H1C
				cmbVillian6.SelectedItem = "Trolling Thunder"
				Exit Select
			Case &H1D
				cmbVillian6.SelectedItem = "Hood Sickle"
				Exit Select
			Case &H1E
				cmbVillian6.SelectedItem = "Bruiser Cruiser"
				Exit Select
			Case &H1F
				cmbVillian6.SelectedItem = "Brawlrus"
				Exit Select
			Case &H20
				cmbVillian6.SelectedItem = "Tussle Sprout"
				Exit Select
			Case &H21
				cmbVillian6.SelectedItem = "Krankenstein"
				Exit Select
			Case &H22
				cmbVillian6.SelectedItem = "Scrap Shooter"
				Exit Select
			Case &H23
				cmbVillian6.SelectedItem = "Slobber Trap"
				Exit Select
			Case &H24
				cmbVillian6.SelectedItem = "Grinnade"
				Exit Select
			Case &H25
				cmbVillian6.SelectedItem = "Bad Juju"
				Exit Select
			Case &H26
				cmbVillian6.SelectedItem = "Blaster-Tron"
				Exit Select
			Case &H27
				cmbVillian6.SelectedItem = "Tae Kwon Crow"
				Exit Select
			Case &H28
				cmbVillian6.SelectedItem = "Painyata"
				Exit Select
			Case &H29
				cmbVillian6.SelectedItem = "Smoke Scream"
				Exit Select
			Case &H2A
				cmbVillian6.SelectedItem = "Eye Five"
				Exit Select
			Case &H2B
				cmbVillian6.SelectedItem = "Grave Clobber"
				Exit Select
			Case &H2C
				cmbVillian6.SelectedItem = "Threatpack"
				Exit Select
			Case &H2D
				cmbVillian6.SelectedItem = "Mab Lobs"
				Exit Select
			Case &H2E
				cmbVillian6.SelectedItem = "Eye Scream"
				Exit Select
			Case Else
				cmbVillian6.SelectedItem = "(None)"
				Exit Select
		End Select
		If WholeFile(&H391) = &H1 Then
			chkVillian6Evolved.Checked = True
		End If
		Dim Villian6_Trinket As Byte = WholeFile(&H393)
		Select Case Villian6_Trinket
			Case &H0
				cmbVillian6Trinket.SelectedItem = "(None)"
				Exit Select
			Case &H1
				cmbVillian6Trinket.SelectedItem = "T-Bone's Lucky Tie"
				Exit Select
			Case &H2
				cmbVillian6Trinket.SelectedItem = "Batterson's Bubble"
				Exit Select
			Case &H3
				cmbVillian6Trinket.SelectedItem = "Dark Water Daisy"
				Exit Select
			Case &H4
				cmbVillian6Trinket.SelectedItem = "Vote For Cyclops"
				Exit Select
			Case &H5
				cmbVillian6Trinket.SelectedItem = "Ramses' Dragon Horn"
				Exit Select
			Case &H6
				cmbVillian6Trinket.SelectedItem = "Iris' Iris"
				Exit Select
			Case &H7
				cmbVillian6Trinket.SelectedItem = "Kuckoo Kazoo"
				Exit Select
			Case &H8
				cmbVillian6Trinket.SelectedItem = "Ramses' Rune"
				Exit Select
			Case &H9
				cmbVillian6Trinket.SelectedItem = "Ullysses Uniclops"
				Exit Select
			Case &HA
				cmbVillian6Trinket.SelectedItem = "Billy Bison"
				Exit Select
			Case &HB
				cmbVillian6Trinket.SelectedItem = "Stealth Elf's Gift"
				Exit Select
			Case &HC
				cmbVillian6Trinket.SelectedItem = "Lizard Lilly"
				Exit Select
			Case &HD
				cmbVillian6Trinket.SelectedItem = "Pirate Pinwheel"
				Exit Select
			Case &HE
				cmbVillian6Trinket.SelectedItem = "Bubble Blower"
				Exit Select
			Case &HF
				cmbVillian6Trinket.SelectedItem = "Medal of Heroism"
				Exit Select
			Case &H10
				cmbVillian6Trinket.SelectedItem = "Blobber's Medal of Courage"
				Exit Select
			Case &H11
				cmbVillian6Trinket.SelectedItem = "Medal of Valliance"
				Exit Select
			Case &H12
				cmbVillian6Trinket.SelectedItem = "Medal of Gallantry"
				Exit Select
			Case &H13
				cmbVillian6Trinket.SelectedItem = "Medal of Mettle"
				Exit Select
			Case &H14
				cmbVillian6Trinket.SelectedItem = "Winged Medal of Bravery"
				Exit Select
			Case &H15
				cmbVillian6Trinket.SelectedItem = "Seadog Seashell"
				Exit Select
			Case &H16
				cmbVillian6Trinket.SelectedItem = "Snuckles' Sunflower"
				Exit Select
			Case &H17
				cmbVillian6Trinket.SelectedItem = "Teddy Cyclops"
				Exit Select
			Case &H18
				cmbVillian6Trinket.SelectedItem = "Goo Factory Gear"
				Exit Select
			Case &H19
				cmbVillian6Trinket.SelectedItem = "Elemental Opal"
				Exit Select
			Case &H1A
				cmbVillian6Trinket.SelectedItem = "Elemental Radiant"
				Exit Select
			Case &H1B
				cmbVillian6Trinket.SelectedItem = "Elemental Diamond"
				Exit Select
			Case &H1C
				cmbVillian6Trinket.SelectedItem = "Cyclops Spinner"
				Exit Select
			Case &H1D
				cmbVillian6Trinket.SelectedItem = "Wiliken Windmill"
				Exit Select
			Case &H1E
				cmbVillian6Trinket.SelectedItem = "Time Town Ticker"
				Exit Select
			Case &H1F
				cmbVillian6Trinket.SelectedItem = "Big Bow of Doom"
				Exit Select
			Case &H20
				cmbVillian6Trinket.SelectedItem = "Mabu's Medallion"
				Exit Select
			Case &H21
				cmbVillian6Trinket.SelectedItem = "Spyro's Shield"
				Exit Select
			Case Else
				cmbVillian6Trinket.SelectedItem = "(None)"
				Exit Select
		End Select
		Dim Villian6_Hat As Byte = WholeFile(&H392)
		Select Case Villian6_Hat
			Case &H0
				cmbVillian6Hat.SelectedItem = "(None)"
			Case &HD3
				cmbVillian6Hat.SelectedItem = "Alarm Clock Hat"
			Case &HDA
				cmbVillian6Hat.SelectedItem = "Bat Hat"
			Case &HD4
				cmbVillian6Hat.SelectedItem = "Batter Up Hat"
			Case &H9B
				cmbVillian6Hat.SelectedItem = "Beetle Hat"
			Case &HED
				cmbVillian6Hat.SelectedItem = "Bellhop Hat"
			Case &HC3
				cmbVillian6Hat.SelectedItem = "Bobby"
			Case &H9C
				cmbVillian6Hat.SelectedItem = "Brain Hat"
			Case &H9D
				cmbVillian6Hat.SelectedItem = "Brainiac Hat"
			Case &HEE
				cmbVillian6Hat.SelectedItem = "Bronze Arkeyan Helm"
			Case &H9E
				cmbVillian6Hat.SelectedItem = "Bucket Hat"
			Case &HEA
				cmbVillian6Hat.SelectedItem = "Candle Hat"
			Case &HE8
				cmbVillian6Hat.SelectedItem = "Candy Cane Hat"
			Case &HF6
				cmbVillian6Hat.SelectedItem = "Carnival Hat"
			Case &HA0
				cmbVillian6Hat.SelectedItem = "Ceiling Fan Hat"
			Case &HBB
				cmbVillian6Hat.SelectedItem = "Classic Pot Hat"
			Case &HA3
				cmbVillian6Hat.SelectedItem = "Clown Bowler Hat"
			Case &HA2
				cmbVillian6Hat.SelectedItem = "Clown Classic Hat"
			Case &HF7
				cmbVillian6Hat.SelectedItem = "Coconut Hat"
			Case &HA4
				cmbVillian6Hat.SelectedItem = "Colander Hat"
			Case &HFC
				cmbVillian6Hat.SelectedItem = "Core Of Light Hat"
			Case &HA6
				cmbVillian6Hat.SelectedItem = "Cornucopia Hat"
			Case &HBD
				cmbVillian6Hat.SelectedItem = "Crazy Light Bulb Hat"
			Case &HD6
				cmbVillian6Hat.SelectedItem = "Croissant Hat"
			Case &HA7
				cmbVillian6Hat.SelectedItem = "Cubano Hat"
			Case &HA8
				cmbVillian6Hat.SelectedItem = "Cycling Hat"
			Case &HA9
				cmbVillian6Hat.SelectedItem = "Daisy Crown"
			Case &HEB
				cmbVillian6Hat.SelectedItem = "Dark Helm"
			Case &H9F
				cmbVillian6Hat.SelectedItem = "Desert Crown"
			Case &HAA
				cmbVillian6Hat.SelectedItem = "Dragon Skull"
			Case &HE9
				cmbVillian6Hat.SelectedItem = "Eggshell Hat"
			Case &HCB
				cmbVillian6Hat.SelectedItem = "Extreme Viking Hat"
			Case &HD9
				cmbVillian6Hat.SelectedItem = "Eye of Kaos Hat"
			Case &HDC
				cmbVillian6Hat.SelectedItem = "Firefly Jar"
			Case &HC6
				cmbVillian6Hat.SelectedItem = "Flight Attendant Hat"
			Case &HAE
				cmbVillian6Hat.SelectedItem = "Garrison Hat"
			Case &HAD
				cmbVillian6Hat.SelectedItem = "Generalissimo"
			Case &HE2
				cmbVillian6Hat.SelectedItem = "Gold Arkeyan Helm"
			Case &HAF
				cmbVillian6Hat.SelectedItem = "Gondolier Hat"
			Case &HC4
				cmbVillian6Hat.SelectedItem = "Hedgehog Hat"
			Case &HD5
				cmbVillian6Hat.SelectedItem = "Horns Be With You Hat"
			Case &HB0
				cmbVillian6Hat.SelectedItem = "Hunting Hat"
			Case &HA1
				cmbVillian6Hat.SelectedItem = "Imperial Hat"
			Case &HB1
				cmbVillian6Hat.SelectedItem = "Juicer Hat"
			Case &HA5
				cmbVillian6Hat.SelectedItem = "Kepi Hat"
			Case &HB2
				cmbVillian6Hat.SelectedItem = "Kokoshnik"
			Case &HDB
				cmbVillian6Hat.SelectedItem = "Light Bulb Hat"
			Case &HDE
				cmbVillian6Hat.SelectedItem = "Lighthouse Beacon Hat"
			Case &HAC
				cmbVillian6Hat.SelectedItem = "Lil' Elf Hat"
			Case &HB3
				cmbVillian6Hat.SelectedItem = "Medic Hat"
			Case &HB4
				cmbVillian6Hat.SelectedItem = "Melon Hat"
			Case &HC0
				cmbVillian6Hat.SelectedItem = "Metal Fin Hat"
			Case &HE5
				cmbVillian6Hat.SelectedItem = "Miniature Skylands Hat"
			Case &HFA
				cmbVillian6Hat.SelectedItem = "Molekin Mountain Hat"
			Case &HC7
				cmbVillian6Hat.SelectedItem = "Monday Hat"
			Case &HB5
				cmbVillian6Hat.SelectedItem = "Mountie Hat"
			Case &HE0
				cmbVillian6Hat.SelectedItem = "Night Cap"
			Case &HB6
				cmbVillian6Hat.SelectedItem = "Nurse Hat"
			Case &HFD
				cmbVillian6Hat.SelectedItem = "Octavius Cloptimus Hat"
			Case &HBA
				cmbVillian6Hat.SelectedItem = "Old-Time Movie Hat"
			Case &HAB
				cmbVillian6Hat.SelectedItem = "Outback Hat"
			Case &HB7
				cmbVillian6Hat.SelectedItem = "Palm Hat"
			Case &HB8
				cmbVillian6Hat.SelectedItem = "Paperboy Hat"
			Case &HB9
				cmbVillian6Hat.SelectedItem = "Parrot Nest"
			Case &HEC
				cmbVillian6Hat.SelectedItem = "Planet Hat"
			Case &HD2
				cmbVillian6Hat.SelectedItem = "Pork Pie Hat"
			Case &HE4
				cmbVillian6Hat.SelectedItem = "Pyramid Hat"
			Case &HBC
				cmbVillian6Hat.SelectedItem = "Radar Hat"
			Case &HD8
				cmbVillian6Hat.SelectedItem = "Rainbow Hat"
			Case &HBE
				cmbVillian6Hat.SelectedItem = "Rubber Glove Hat"
			Case &HD1
				cmbVillian6Hat.SelectedItem = "Rude Boy Hat"
			Case &HBF
				cmbVillian6Hat.SelectedItem = "Rugby Hat"
			Case &HCC
				cmbVillian6Hat.SelectedItem = "Scooter Hat"
			Case &HDD
				cmbVillian6Hat.SelectedItem = "Shadow Ghost Hat"
			Case &HC8
				cmbVillian6Hat.SelectedItem = "Sherpa Hat"
			Case &HC2
				cmbVillian6Hat.SelectedItem = "Shower Cap"
			Case &HEF
				cmbVillian6Hat.SelectedItem = "Silver Arkeyan Helm"
			Case &HF3
				cmbVillian6Hat.SelectedItem = "Skipper Hat"
			Case &HC1
				cmbVillian6Hat.SelectedItem = "Sleuth Hat"
			Case &HC5
				cmbVillian6Hat.SelectedItem = "Steampunk Hat"
			Case &HE1
				cmbVillian6Hat.SelectedItem = "Storm Hat"
			Case &HCE
				cmbVillian6Hat.SelectedItem = "Synchronized Swimming Cap"
			Case &HDF
				cmbVillian6Hat.SelectedItem = "Tin Foil Hat"
			Case &HE3
				cmbVillian6Hat.SelectedItem = "Toucan Hat"
			Case &HC9
				cmbVillian6Hat.SelectedItem = "Trash Lid"
			Case &HD0
				cmbVillian6Hat.SelectedItem = "Tribal Hat"
			Case &HCA
				cmbVillian6Hat.SelectedItem = "Turtle Hat"
			Case &HCD
				cmbVillian6Hat.SelectedItem = "Volcano Island Hat"
			Case &HD7
				cmbVillian6Hat.SelectedItem = "Weather Vane Hat"
			Case &HCF
				cmbVillian6Hat.SelectedItem = "William Tell Hat"
			Case Else
				cmbVillian6Hat.SelectedItem = "(None)"
		End Select
		'Load Name from Byte 0x394
		txtVillian1Name.Text = Load_Name(&H394)
	End Sub

	Function Load_Name(offset As Integer)
		Dim NameBytes(29) As Byte
		Dim Adder As Integer = 0
		Do Until Adder = 28
			NameBytes(Adder) = WholeFile(offset)
			offset = offset + 1
			Adder += 1
		Loop
		'Skip MiFare Block
		offset += 16
		Do Until Adder = 30
			NameBytes(Adder) = WholeFile(offset)
			offset = offset + 1
			Adder += 1
		Loop
		Return Encoding.Unicode.GetString(NameBytes)
	End Function

	Sub Save_Name(Offset As Integer, Villian_Name As String)
		Dim Full_VilianName(29) As Byte
		Full_VilianName = Encoding.Unicode.GetBytes(Villian_Name)
		Dim adder As Integer = 0
		Do Until adder = 28
			WholeFile(Offset) = Full_VilianName(adder)
			Offset = Offset + 1
			adder += 1
		Loop
		'Skip MiFare Block
		Offset += 16
		Do Until adder = 30
			WholeFile(Offset) = Full_VilianName(adder)
			Offset = Offset + 1
			adder += 1
		Loop
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

	Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
		'MessageBox.Show("!" & cmbVillian4.SelectedItem & "!")
		'MessageBox.Show(txtVillian1Name.Text.Length)
	End Sub
End Class