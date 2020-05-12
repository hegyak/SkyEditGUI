Imports SkyReader_GUI.frmMain
Public Class frmVehicles
    Private Sub frmVehicles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initial Values.

        cmbDecoration.SelectedIndex = 0
        cmbNeon.SelectedIndex = 0
        cmbShout.SelectedIndex = 0
        cmbTopper.SelectedIndex = 0
        'Add 1C0
        'Decoration.  We define one Byte values for both Area A/B
        Dim Deco_One As Byte = WholeFile(&H98)
        Dim Deco_Two As Byte = WholeFile(&H258)

        Dim Topper_One As Byte = WholeFile(&H99)
        Dim Topper_Two As Byte = WholeFile(&H259)

        Dim Neon_One As Byte = WholeFile(&H9A)
        Dim Neon_Two As Byte

        Dim Shout_One As Byte = WholeFile(&H9B)
        Dim Shout_Two As Byte


        'I need to read data here:
        'The question is, how can I tell which to use, neatly?
        If Area0 > Area1 Then
            Deco_One = Deco_One
            Topper_One = Topper_One
            Neon_One = Neon_One
            Shout_One = Shout_One
        ElseIf Area1 > Area0 Then
            Deco_One = Deco_Two
            Topper_One = Topper_Two
            Neon_One = Neon_Two
            Shout_One = Shout_Two
        ElseIf Area0 = Area1 Then
            Deco_One = Deco_One
            Topper_One = Topper_One
            Neon_One = Neon_One
            Shout_One = Shout_One
        End If
        'We wait for the Application to load all the Values into their Comboboxes.
        Application.DoEvents()

        Try
            cmbDecoration.SelectedIndex = Convert.ToInt32(Deco_One)
        Catch ex As Exception

        End Try
        Try
            cmbTopper.SelectedIndex = Convert.ToInt32(Topper_One)
        Catch ex As Exception

        End Try
        Try
            cmbNeon.SelectedIndex = Convert.ToInt32(Neon_One)
        Catch ex As Exception

        End Try
        Try
            cmbShout.SelectedIndex = Convert.ToInt32(Shout_One)
            'MessageBox.Show(Shout_One)
        Catch ex As Exception

        End Try
        'MessageBox.Show("Deco: " & cmbDecoration.Items.Count)
        ' MessageBox.Show("TOP: " & cmbTopper.Items.Count)
        'MessageBox.Show("Neon: " & cmbNeon.Items.Count)
        'MessageBox.Show("Sho: " & cmbShout.Items.Count)
    End Sub
    Sub Save()
        'I need to write Data here:
        'Add 1C0
        'x098		Deco	
        'x099  Topper 
        'x09A  Neon 
        'x09B  Shout 

        Select Case cmbDecoration.SelectedIndex
        'Decorations
        '1 Darkness
        '2 Cap'N Cluck
        '3 Ancient
        '4 Cartoon
        '5 Eon
        '6 Kaos
        '7 Police
        '8 Construction
        '9 Holiday
        'A Ghost
        'B Thermal
        'C Fire Truck
        'D Ninja
        'E Royal
        'F Robot
            Case 0
                WholeFile(&H98) = &H0
                WholeFile(&H258) = &H0
                Exit Select
            Case 1
                WholeFile(&H98) = &H1
                WholeFile(&H258) = &H1
                Exit Select
            Case 2
                WholeFile(&H98) = &H2
                WholeFile(&H258) = &H2
                Exit Select
            Case 3
                WholeFile(&H98) = &H3
                WholeFile(&H258) = &H3
                Exit Select
            Case 4
                WholeFile(&H98) = &H4
                WholeFile(&H258) = &H4
                Exit Select
            Case 5
                WholeFile(&H98) = &H5
                WholeFile(&H258) = &H5
                Exit Select
            Case 6
                WholeFile(&H98) = &H6
                WholeFile(&H258) = &H6
                Exit Select
            Case 7
                WholeFile(&H98) = &H7
                WholeFile(&H258) = &H7
                Exit Select
            Case 8
                WholeFile(&H98) = &H8
                WholeFile(&H258) = &H8
                Exit Select
            Case 9
                WholeFile(&H98) = &H9
                WholeFile(&H258) = &H9
                Exit Select
            Case 10
                WholeFile(&H98) = &HA
                WholeFile(&H258) = &HA
                Exit Select
            Case 11
                WholeFile(&H98) = &HB
                WholeFile(&H258) = &HB
                Exit Select
            Case 12
                WholeFile(&H98) = &HC
                WholeFile(&H258) = &HC
                Exit Select
            Case 13
                WholeFile(&H98) = &HD
                WholeFile(&H258) = &HD
                Exit Select
            Case 14
                WholeFile(&H98) = &HE
                WholeFile(&H258) = &HE
                Exit Select
            Case 15
                WholeFile(&H98) = &HF
                WholeFile(&H258) = &HF
                Exit Select
            Case Else
                MessageBox.Show("This is what it's like to go FURTHER BEYOND!")
        End Select
        Select Case cmbTopper.SelectedIndex
        'Topper
        '01 The Darkness
        '02 Lucky Coin
        '03 King-Sized Bucket
        '04 Popcorn
        '05 Chicken Leg
        '06 Pinata
        '07 Bag of Gold
        '08 Chompy
        '09 Balloon
        '0A Ripe Banana
        '0B Beach Ball
        '0C Teddy Hat
        '0D Corn on the Cob
        '0E Dragonfire Cannon
        '0F Eon's Sock
        '10 Eon's Statue
        '11 Kaos Statue
        '12 Spitfire Doll
        '13 Golden Piggy Bank
        '14 Raccoon Tail
        '15 Rasta Hat
        '16 Party Sheep
        '17 Snap Shot Doll
        '18 Space Helmet
        '19 Squeeks Jr.
        '1A Tiki Speaky
        '1B Traffic Cone
        '1C Tree Rex Doll
        '1D Tricorn Hat
        '1E Trigger Happy Doll
        '1F Wash Buckler Doll
        '20 Weathervane
        '21 Eon's Helm
        '22 Pluck
        '23 Siren
        '24 Ghost Topper
        '25 Cartoon Doll
        '26 Kaos Punching Bag
        '27 Cup O' Cocoa
        '28 Hand of Fate
        '29 Like Clockwork
        '2A Empire of Ice
        '2B Pizza
        '2C Yeti Doll
        '2D Kaos Sigil
        '2E Cowboy Hat
        '2F Eyeball Ball
        '30 Asteroid
        '31 Hook Hand
        '32	The Mighty Atom
        '33	Holiday Tree
        '34	Shuriken
        '35	Mechanical Gear
        '36	Royal Crown
        '37	Fire Hydrant

            Case 0
                WholeFile(&H99) = &H0
                WholeFile(&H259) = &H0
                Exit Select
            Case 1
                WholeFile(&H99) = &H1
                WholeFile(&H259) = &H1
                Exit Select
            Case 2
                WholeFile(&H99) = &H2
                WholeFile(&H259) = &H2
                Exit Select
            Case 3
                WholeFile(&H99) = &H3
                WholeFile(&H259) = &H3
                Exit Select
            Case 4
                WholeFile(&H99) = &H4
                WholeFile(&H259) = &H4
                Exit Select
            Case 5
                WholeFile(&H99) = &H5
                WholeFile(&H259) = &H5
                Exit Select
            Case 6
                WholeFile(&H99) = &H6
                WholeFile(&H259) = &H6
                Exit Select
            Case 7
                WholeFile(&H99) = &H7
                WholeFile(&H259) = &H7
                Exit Select
            Case 8
                WholeFile(&H99) = &H8
                WholeFile(&H259) = &H8
                Exit Select
            Case 9
                WholeFile(&H99) = &H9
                WholeFile(&H259) = &H9
                Exit Select
            Case 10
                WholeFile(&H99) = &HA
                WholeFile(&H259) = &HA
                Exit Select
            Case 11
                WholeFile(&H99) = &HB
                WholeFile(&H259) = &HB
                Exit Select
            Case 12
                WholeFile(&H99) = &HC
                WholeFile(&H259) = &HC
                Exit Select
            Case 13
                WholeFile(&H99) = &HD
                WholeFile(&H259) = &HD
                Exit Select
            Case 14
                WholeFile(&H99) = &HE
                WholeFile(&H259) = &HE
                Exit Select
            Case 15
                WholeFile(&H99) = &HF
                WholeFile(&H259) = &HF
                Exit Select
            Case 16
                WholeFile(&H99) = &H10
                WholeFile(&H259) = &H10
                Exit Select
            Case 17
                WholeFile(&H99) = &H11
                WholeFile(&H259) = &H11
                Exit Select
            Case 18
                WholeFile(&H99) = &H12
                WholeFile(&H259) = &H12
                Exit Select
            Case 19
                WholeFile(&H99) = &H13
                WholeFile(&H259) = &H13
                Exit Select
            Case 20
                WholeFile(&H99) = &H14
                WholeFile(&H259) = &H14
                Exit Select
            Case 21
                WholeFile(&H99) = &H15
                WholeFile(&H259) = &H15
                Exit Select
            Case 22
                WholeFile(&H99) = &H16
                WholeFile(&H259) = &H16
                Exit Select
            Case 23
                WholeFile(&H99) = &H17
                WholeFile(&H259) = &H17
                Exit Select
            Case 24
                WholeFile(&H99) = &H18
                WholeFile(&H259) = &H18
                Exit Select
            Case 25
                WholeFile(&H99) = &H19
                WholeFile(&H259) = &H19
                Exit Select
            Case 26
                WholeFile(&H99) = &H1A
                WholeFile(&H259) = &H1A
                Exit Select
            Case 27
                WholeFile(&H99) = &H1B
                WholeFile(&H259) = &H1B
                Exit Select
            Case 28
                WholeFile(&H99) = &H1C
                WholeFile(&H259) = &H1C
                Exit Select
            Case 29
                WholeFile(&H99) = &H1D
                WholeFile(&H259) = &H1D
                Exit Select
            Case 30
                WholeFile(&H99) = &H1E
                WholeFile(&H259) = &H1E
                Exit Select
            Case 31
                WholeFile(&H99) = &H1F
                WholeFile(&H259) = &H1F
                Exit Select
            Case 32
                WholeFile(&H99) = &H20
                WholeFile(&H259) = &H20
                Exit Select
            Case 33
                WholeFile(&H99) = &H21
                WholeFile(&H259) = &H21
                Exit Select
            Case 34
                WholeFile(&H99) = &H22
                WholeFile(&H259) = &H22
                Exit Select
            Case 35
                WholeFile(&H99) = &H23
                WholeFile(&H259) = &H23
                Exit Select
            Case 36
                WholeFile(&H99) = &H24
                WholeFile(&H259) = &H24
                Exit Select
            Case 37
                WholeFile(&H99) = &H25
                WholeFile(&H259) = &H25
                Exit Select
            Case 38
                WholeFile(&H99) = &H26
                WholeFile(&H259) = &H26
                Exit Select
            Case 39
                WholeFile(&H99) = &H27
                WholeFile(&H259) = &H27
                Exit Select
            Case 40
                WholeFile(&H99) = &H28
                WholeFile(&H259) = &H28
                Exit Select
            Case 41
                WholeFile(&H99) = &H29
                WholeFile(&H259) = &H29
                Exit Select
            Case 42
                WholeFile(&H99) = &H2A
                WholeFile(&H259) = &H2A
                Exit Select
            Case 43
                WholeFile(&H99) = &H2B
                WholeFile(&H259) = &H2B
                Exit Select
            Case 44
                WholeFile(&H99) = &H2C
                WholeFile(&H259) = &H2C
                Exit Select
            Case 45
                WholeFile(&H99) = &H2D
                WholeFile(&H259) = &H2D
                Exit Select
            Case 46
                WholeFile(&H99) = &H2E
                WholeFile(&H259) = &H2E
                Exit Select
            Case 47
                WholeFile(&H99) = &H2F
                WholeFile(&H259) = &H2F
                Exit Select
            Case 48
                WholeFile(&H99) = &H30
                WholeFile(&H259) = &H30
                Exit Select
            Case 49
                WholeFile(&H99) = &H31
                WholeFile(&H259) = &H31
                Exit Select
            Case 50
                WholeFile(&H99) = &H32
                WholeFile(&H259) = &H32
                Exit Select
            Case 51
                WholeFile(&H99) = &H33
                WholeFile(&H259) = &H33
                Exit Select
            Case 52
                WholeFile(&H99) = &H34
                WholeFile(&H259) = &H34
                Exit Select
            Case 53
                WholeFile(&H99) = &H35
                WholeFile(&H259) = &H35
                Exit Select
            Case 54
                WholeFile(&H99) = &H36
                WholeFile(&H259) = &H36
                Exit Select
            Case 55
                WholeFile(&H99) = &H37
                WholeFile(&H259) = &H37
                Exit Select

            Case Else
                MessageBox.Show("This is what it's like to go FURTHER BEYOND!")
        End Select
        Select Case cmbNeon.SelectedIndex
            '1   Darkness
            '2   Eon
            '3   Ancient
            '4   Cap'N Cluck
            '5   Cartoon
            '6   Kaos
            '7   Police
            '8   Construction
            '9   Holiday
            'A   Ghost
            'B   Royal
            'C   Ninja
            'D   Thermal
            'E   Robot
            'F   Fire Truck
            Case 0
                WholeFile(&H9A) = &H0
                WholeFile(&H25A) = &H0
                Exit Select
            Case 1
                WholeFile(&H9A) = &H1
                WholeFile(&H25A) = &H1
                Exit Select
            Case 2
                WholeFile(&H9A) = &H2
                WholeFile(&H25A) = &H2
                Exit Select
            Case 3
                WholeFile(&H9A) = &H3
                WholeFile(&H25A) = &H3
                Exit Select
            Case 4
                WholeFile(&H9A) = &H4
                WholeFile(&H25A) = &H4
                Exit Select
            Case 5
                WholeFile(&H9A) = &H5
                WholeFile(&H25A) = &H5
                Exit Select
            Case 6
                WholeFile(&H9A) = &H6
                WholeFile(&H25A) = &H6
                Exit Select
            Case 7
                WholeFile(&H9A) = &H7
                WholeFile(&H25A) = &H7
                Exit Select
            Case 8
                WholeFile(&H9A) = &H8
                WholeFile(&H25A) = &H8
                Exit Select
            Case 9
                WholeFile(&H9A) = &H9
                WholeFile(&H25A) = &H9
                Exit Select
            Case 10
                WholeFile(&H9A) = &HA
                WholeFile(&H25A) = &HA
                Exit Select
            Case 11
                WholeFile(&H9A) = &HB
                WholeFile(&H25A) = &HB
                Exit Select
            Case 12
                WholeFile(&H9A) = &HC
                WholeFile(&H25A) = &HC
                Exit Select
            Case 13
                WholeFile(&H9A) = &HD
                WholeFile(&H25A) = &HD
                Exit Select
            Case 14
                WholeFile(&H9A) = &HE
                WholeFile(&H25A) = &HE
                Exit Select
            Case 15
                WholeFile(&H9A) = &HF
                WholeFile(&H25A) = &HF
                Exit Select

            Case Else
                MessageBox.Show("This is what it's like to go FURTHER BEYOND!")
        End Select
        Select Case cmbShout.SelectedIndex

            '1   Sneer: Cali
            '2   Jeer: Cali
            '3   Cheer: Cali
            '4   Back off Bear
            '5   Breakdown
'6   Pull Over!
'7   Evil Eye
'8   Bird Brain
'9   The Ultimate Evil!
'A   Leave Me Alone Lion
'B   Going Nuclear
'C   Sneer: Sharpfin
'D   The Darkness
'E   Why I Oughta
'F   Police Siren
'10  Fire It Up
'11  Sneer: Buzz
'12  Call Me!
'13  Car Trouble
'14  Sneer: Pomfrey
'15  Yield!
'16  Hype Train
'17  Doggin' After Ya
'18  Crash And Burn
'19  Earthquake
'1A	Flat Tire
'1B	Fly Trap
'1C	Sneer: Glumshanks
'1D	Sneer: Hugo
'1E	Sneer: Queen Cumulus
'1F	Ninja Stars
'20  AAAAAA…
'21  Jeer: Sharpfin
'22  Red Means Go Right?
'23  The Final Countdown
'24  Rush Hour
'25  Sneer: Tessa
'26  Tidal Wave
'27  Toasty!
'28  All Spun Up
'29  Under Construction
'2A	Howlin' Good
'2B	Cheer: Buzz
'2C	Cheer: Pomfrey
'2D	Checkered Flag
'2E	Eon Impersonator
'2F	Cheer: Flynn
'30  Cheer: Glumshanks
'31  Wink Wink Nudge Nudge
'32  Silver Bells
'33  Cheer: Queen Cumulus
'34  Cheer: Persephone
'35  Cheer: Sharpfin
'36  Cheer: Hugo
'37 :)
'38  Cheer: Tessa
'39  First Place Trophy
'3A	Big Bell
'3B	Rude Chompy
'3C	Your Robot Son
'3D	Cry Baby
'3E	The Gulper
'3F	Sweet Innocence
'40  Diplomacy
'41  The Prince of Pontification
'42  Scandalous!
'43  Like Clockwork
'44  Ancient Energy
'45  Banana Peel
'46  Bashful Face
'47  Boo
'48  Boo Too
'49  Jeer: Buzz
'4A	Catchy Jingle
'4B	Jeer: Pomfrey
'4C	Laugh It Up
'4D	Cow Crossing
'4E	Cuckoo Cuckoo
'4F	Rude Dolphin
'50  Jack the Donkey
'51  Quack!
'52  Trumpet Trunk
'53  Blub-Blub
'54  Jeer: Flynn
'55  Jeer: Glumshanks
'56  Indignant Goose
'57  Ham!
'58  Horsin' Around
'59  Jeer: Hugo
'5A	Kissy Face
'5B	Purrfect
'5C	Lockpick Gremlin
'5D	Nature Calls
'5E	Jeer: Queen Cumulus
'5F	Oop Oop Eek
'60  Tauntalizing
'61  Soda Pop
'62  Wow!
'63  Baa-Aaa!
'64  Squeaky Toy
'65  Jeer: Tessa

            Case 0
                WholeFile(&H9B) = &H0
                WholeFile(&H25B) = &H0
                Exit Select
            Case 1
                WholeFile(&H9B) = &H1
                WholeFile(&H25B) = &H1
                Exit Select
            Case 2
                WholeFile(&H9B) = &H2
                WholeFile(&H25B) = &H2
                Exit Select
            Case 3
                WholeFile(&H9B) = &H3
                WholeFile(&H25B) = &H3
                Exit Select
            Case 4
                WholeFile(&H9B) = &H4
                WholeFile(&H25B) = &H4
                Exit Select
            Case 5
                WholeFile(&H9B) = &H5
                WholeFile(&H25B) = &H5
                Exit Select
            Case 6
                WholeFile(&H9B) = &H6
                WholeFile(&H25B) = &H6
                Exit Select
            Case 7
                WholeFile(&H9B) = &H7
                WholeFile(&H25B) = &H7
                Exit Select
            Case 8
                WholeFile(&H9B) = &H8
                WholeFile(&H25B) = &H8
                Exit Select
            Case 9
                WholeFile(&H9B) = &H9
                WholeFile(&H25B) = &H9
                Exit Select
            Case 10
                WholeFile(&H9B) = &HA
                WholeFile(&H25B) = &HA
                Exit Select
            Case 11
                WholeFile(&H9B) = &HB
                WholeFile(&H25B) = &HB
                Exit Select
            Case 12
                WholeFile(&H9B) = &HC
                WholeFile(&H25B) = &HC
                Exit Select
            Case 13
                WholeFile(&H9B) = &HD
                WholeFile(&H25B) = &HD
                Exit Select
            Case 14
                WholeFile(&H9B) = &HE
                WholeFile(&H25B) = &HE
                Exit Select
            Case 15
                WholeFile(&H9B) = &HF
                WholeFile(&H25B) = &HF
                Exit Select
            Case 16
                WholeFile(&H9B) = &H10
                WholeFile(&H25B) = &H10
                Exit Select
            Case 17
                WholeFile(&H9B) = &H11
                WholeFile(&H25B) = &H11
                Exit Select
            Case 18
                WholeFile(&H9B) = &H12
                WholeFile(&H25B) = &H12
                Exit Select
            Case 19
                WholeFile(&H9B) = &H13
                WholeFile(&H25B) = &H13
                Exit Select
            Case 20
                WholeFile(&H9B) = &H14
                WholeFile(&H25B) = &H14
                Exit Select
            Case 21
                WholeFile(&H9B) = &H15
                WholeFile(&H25B) = &H15
                Exit Select
            Case 22
                WholeFile(&H9B) = &H16
                WholeFile(&H25B) = &H16
                Exit Select
            Case 23
                WholeFile(&H9B) = &H17
                WholeFile(&H25B) = &H17
                Exit Select
            Case 24
                WholeFile(&H9B) = &H18
                WholeFile(&H25B) = &H18
                Exit Select
            Case 25
                WholeFile(&H9B) = &H19
                WholeFile(&H25B) = &H19
                Exit Select
            Case 26
                WholeFile(&H9B) = &H1A
                WholeFile(&H25B) = &H1A
                Exit Select
            Case 27
                WholeFile(&H9B) = &H1B
                WholeFile(&H25B) = &H1B
                Exit Select
            Case 28
                WholeFile(&H9B) = &H1C
                WholeFile(&H25B) = &H1C
                Exit Select
            Case 29
                WholeFile(&H9B) = &H1D
                WholeFile(&H25B) = &H1D
                Exit Select
            Case 30
                WholeFile(&H9B) = &H1E
                WholeFile(&H25B) = &H1E
                Exit Select
            Case 31
                WholeFile(&H9B) = &H1F
                WholeFile(&H25B) = &H1F
                Exit Select
            Case 32
                WholeFile(&H9B) = &H20
                WholeFile(&H25B) = &H20
                Exit Select
            Case 33
                WholeFile(&H9B) = &H21
                WholeFile(&H25B) = &H21
                Exit Select
            Case 34
                WholeFile(&H9B) = &H22
                WholeFile(&H25B) = &H22
                Exit Select
            Case 35
                WholeFile(&H9B) = &H23
                WholeFile(&H25B) = &H23
                Exit Select
            Case 36
                WholeFile(&H9B) = &H24
                WholeFile(&H25B) = &H24
                Exit Select
            Case 37
                WholeFile(&H9B) = &H25
                WholeFile(&H25B) = &H25
                Exit Select
            Case 38
                WholeFile(&H9B) = &H26
                WholeFile(&H25B) = &H26
                Exit Select
            Case 39
                WholeFile(&H9B) = &H27
                WholeFile(&H25B) = &H27
                Exit Select
            Case 40
                WholeFile(&H9B) = &H28
                WholeFile(&H25B) = &H28
                Exit Select
            Case 41
                WholeFile(&H9B) = &H29
                WholeFile(&H25B) = &H29
                Exit Select
            Case 42
                WholeFile(&H9B) = &H2A
                WholeFile(&H25B) = &H2A
                Exit Select
            Case 43
                WholeFile(&H9B) = &H2B
                WholeFile(&H25B) = &H2B
                Exit Select
            Case 44
                WholeFile(&H9B) = &H2C
                WholeFile(&H25B) = &H2C
                Exit Select
            Case 45
                WholeFile(&H9B) = &H2D
                WholeFile(&H25B) = &H2D
                Exit Select
            Case 46
                WholeFile(&H9B) = &H2E
                WholeFile(&H25B) = &H2E
                Exit Select
            Case 47
                WholeFile(&H9B) = &H2F
                WholeFile(&H25B) = &H2F
                Exit Select
            Case 48
                WholeFile(&H9B) = &H30
                WholeFile(&H25B) = &H30
                Exit Select
            Case 49
                WholeFile(&H9B) = &H31
                WholeFile(&H25B) = &H31
                Exit Select
            Case 50
                WholeFile(&H9B) = &H32
                WholeFile(&H25B) = &H32
                Exit Select
            Case 51
                WholeFile(&H9B) = &H33
                WholeFile(&H25B) = &H33
                Exit Select
            Case 52
                WholeFile(&H9B) = &H34
                WholeFile(&H25B) = &H34
                Exit Select
            Case 53
                WholeFile(&H9B) = &H35
                WholeFile(&H25B) = &H35
                Exit Select
            Case 54
                WholeFile(&H9B) = &H36
                WholeFile(&H25B) = &H36
                Exit Select
            Case 55
                WholeFile(&H9B) = &H37
                WholeFile(&H25B) = &H37
                Exit Select
            Case 56
                WholeFile(&H9B) = &H38
                WholeFile(&H25B) = &H38
                Exit Select
            Case 57
                WholeFile(&H9B) = &H39
                WholeFile(&H25B) = &H39
                Exit Select
            Case 58
                WholeFile(&H9B) = &H3A
                WholeFile(&H25B) = &H3A
                Exit Select
            Case 59
                WholeFile(&H9B) = &H3B
                WholeFile(&H25B) = &H3B
                Exit Select
            Case 60
                WholeFile(&H9B) = &H3C
                WholeFile(&H25B) = &H3C
                Exit Select
            Case 61
                WholeFile(&H9B) = &H3D
                WholeFile(&H25B) = &H3D
                Exit Select
            Case 62
                WholeFile(&H9B) = &H3E
                WholeFile(&H25B) = &H3E
                Exit Select
            Case 63
                WholeFile(&H9B) = &H3F
                WholeFile(&H25B) = &H3F
                Exit Select
            Case 64
                WholeFile(&H9B) = &H40
                WholeFile(&H25B) = &H40
                Exit Select
            Case 65
                WholeFile(&H9B) = &H41
                WholeFile(&H25B) = &H41
                Exit Select
            Case 66
                WholeFile(&H9B) = &H42
                WholeFile(&H25B) = &H42
                Exit Select
            Case 67
                WholeFile(&H9B) = &H43
                WholeFile(&H25B) = &H43
                Exit Select
            Case 68
                WholeFile(&H9B) = &H44
                WholeFile(&H25B) = &H44
                Exit Select
            Case 69
                WholeFile(&H9B) = &H45
                WholeFile(&H25B) = &H45
                Exit Select
            Case 70
                WholeFile(&H9B) = &H46
                WholeFile(&H25B) = &H46
                Exit Select
            Case 71
                WholeFile(&H9B) = &H47
                WholeFile(&H25B) = &H47
                Exit Select
            Case 72
                WholeFile(&H9B) = &H48
                WholeFile(&H25B) = &H48
                Exit Select
            Case 73
                WholeFile(&H9B) = &H49
                WholeFile(&H25B) = &H49
                Exit Select
            Case 74
                WholeFile(&H9B) = &H4A
                WholeFile(&H25B) = &H4A
                Exit Select
            Case 75
                WholeFile(&H9B) = &H4B
                WholeFile(&H25B) = &H4B
                Exit Select
            Case 76
                WholeFile(&H9B) = &H4C
                WholeFile(&H25B) = &H4C
                Exit Select
            Case 77
                WholeFile(&H9B) = &H4D
                WholeFile(&H25B) = &H4D
                Exit Select
            Case 78
                WholeFile(&H9B) = &H4E
                WholeFile(&H25B) = &H4E
                Exit Select
            Case 79
                WholeFile(&H9B) = &H4F
                WholeFile(&H25B) = &H4F
                Exit Select
            Case 80
                WholeFile(&H9B) = &H50
                WholeFile(&H25B) = &H50
                Exit Select
            Case 81
                WholeFile(&H9B) = &H51
                WholeFile(&H25B) = &H51
                Exit Select
            Case 82
                WholeFile(&H9B) = &H52
                WholeFile(&H25B) = &H52
                Exit Select
            Case 83
                WholeFile(&H9B) = &H53
                WholeFile(&H25B) = &H53
                Exit Select
            Case 84
                WholeFile(&H9B) = &H54
                WholeFile(&H25B) = &H54
                Exit Select
            Case 85
                WholeFile(&H9B) = &H55
                WholeFile(&H25B) = &H55
                Exit Select
            Case 86
                WholeFile(&H9B) = &H56
                WholeFile(&H25B) = &H56
                Exit Select
            Case 87
                WholeFile(&H9B) = &H57
                WholeFile(&H25B) = &H57
                Exit Select
            Case 88
                WholeFile(&H9B) = &H58
                WholeFile(&H25B) = &H58
                Exit Select
            Case 89
                WholeFile(&H9B) = &H59
                WholeFile(&H25B) = &H59
                Exit Select
            Case 90
                WholeFile(&H9B) = &H5A
                WholeFile(&H25B) = &H5A
                Exit Select
            Case 91
                WholeFile(&H9B) = &H5B
                WholeFile(&H25B) = &H5B
                Exit Select
            Case 92
                WholeFile(&H9B) = &H5C
                WholeFile(&H25B) = &H5C
                Exit Select
            Case 93
                WholeFile(&H9B) = &H5D
                WholeFile(&H25B) = &H5D
                Exit Select
            Case 94
                WholeFile(&H9B) = &H5E
                WholeFile(&H25B) = &H5E
                Exit Select
            Case 95
                WholeFile(&H9B) = &H5F
                WholeFile(&H25B) = &H5F
                Exit Select
            Case 96
                WholeFile(&H9B) = &H60
                WholeFile(&H25B) = &H60
                Exit Select
            Case 97
                WholeFile(&H9B) = &H61
                WholeFile(&H25B) = &H61
                Exit Select
            Case 98
                WholeFile(&H9B) = &H62
                WholeFile(&H25B) = &H62
                Exit Select
            Case 99
                WholeFile(&H9B) = &H63
                WholeFile(&H25B) = &H63
                Exit Select
            Case 100
                WholeFile(&H9B) = &H64
                WholeFile(&H25B) = &H64
                Exit Select
            Case 101
                WholeFile(&H9B) = &H65
                WholeFile(&H25B) = &H65
                Exit Select
            Case Else
                MessageBox.Show("This is what it's like to go FURTHER BEYOND!")
        End Select
    End Sub

    Private Sub frmVehicles_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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

    Private Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click

    End Sub
End Class