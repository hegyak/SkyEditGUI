Imports SkyReader_GUI.frmMain
Public Class Hats
    Shared AdventureHat(1) As Byte
    Shared GiantHat(1) As Byte
    Shared SwapTrapHat(1) As Byte
    Shared SuperChargerHat(1) As Byte
    Shared Hat(1) As Byte
    Shared Sub ReadHats()
        'Offset by 1C0

        'Adventures
        AdventureHat(0) = WholeFile(&H94)
        'Giants
        GiantHat(0) = WholeFile(&H115)
        'Swap/Trap
        SwapTrapHat(0) = WholeFile(&H11C)
        'Super
        SuperChargerHat(0) = WholeFile(&H11E)

        'Adventures
        AdventureHat(1) = WholeFile(&H254)
        'Giants
        GiantHat(1) = WholeFile(&H2D5)
        'Swap/Trap
        SwapTrapHat(1) = WholeFile(&H2DC)
        'Super
        SuperChargerHat(1) = WholeFile(&H2DE)


        'To be used for Getting Values
        'MessageBox.Show("Area 0: " & Hex(HatArea0(0)))
        'MessageBox.Show("Area 1: " & Hex(HatArea1(0)))

        If Area0 > Area1 Then
            AdventureHat(0) = AdventureHat(0)
            GiantHat(0) = GiantHat(0)
            SwapTrapHat(0) = SwapTrapHat(0)
            SuperChargerHat(0) = SuperChargerHat(0)
        ElseIf Area1 > Area0 Then
            AdventureHat(0) = AdventureHat(1)
            GiantHat(0) = GiantHat(1)
            SwapTrapHat(0) = SwapTrapHat(1)
            SuperChargerHat(0) = SuperChargerHat(1)
        ElseIf Area0 = Area1 Then
            AdventureHat(0) = AdventureHat(0)
            GiantHat(0) = GiantHat(0)
            SwapTrapHat(0) = SwapTrapHat(0)
            SuperChargerHat(0) = SuperChargerHat(0)
        End If

        If SuperChargerHat(0) <> &H0 Then
            'Due to Superchargers rolling over 255, we set these
            Hat(0) = &HFF
            Hat(1) = SuperChargerHat(0)
            SwapTrapHat(0) = &H0
            GiantHat(0) = &H0
            AdventureHat(0) = &H0
        ElseIf SwapTrapHat(0) <> &H0 Then
            Hat(0) = SwapTrapHat(0)
            GiantHat(0) = &H0
            AdventureHat(0) = &H0
        ElseIf GiantHat(0) <> &H0 Then
            Hat(0) = GiantHat(0)
            AdventureHat(0) = &H0
        Else
            Hat(0) = AdventureHat(0)
        End If
        cmbHatSelect()
    End Sub
    Shared Sub WriteHats()
        'Note:
        'May have issues
        'MessageBox.Show(Hat(0))
        Select Case Hat(0)
            Case 0 To 45
                'MessageBox.Show("Adventures")
                'Adventures
                WholeFile(&H94) = Hat(0)
                'Giants
                WholeFile(&H115) = &H0
                'Swap/Trap
                WholeFile(&H11C) = &H0
                'Superchargers
                WholeFile(&H11E) = &H0

                'Adventures
                WholeFile(&H254) = Hat(0)
                'Giants
                WholeFile(&H2D5) = &H0
                'Swap/Trap
                WholeFile(&H2DC) = &H0
                'Superchargers
                WholeFile(&H2DE) = &H0
            Case 46 To 96
                'MessageBox.Show("Giants")
                'Adventures
                WholeFile(&H94) = &H0
                'Giants
                WholeFile(&H115) = Hat(0)
                'Swap/Trap
                WholeFile(&H11C) = &H0
                'Superchargers
                WholeFile(&H11E) = &H0

                'Adventures
                WholeFile(&H254) = &H0
                'Giants
                WholeFile(&H2D5) = Hat(0)
                'Swap/Trap
                WholeFile(&H2DC) = &H0
                'Superchargers
                WholeFile(&H2DE) = &H0
            Case 97 To 254
                ' MessageBox.Show("Swap/Trap")
                'Adventures
                WholeFile(&H94) = &H0
                'Giants
                WholeFile(&H115) = &H0
                'Swap/Trap
                WholeFile(&H11C) = Hat(0)
                'Superchargers
                WholeFile(&H11E) = &H0

                'Adventures
                WholeFile(&H254) = &H0
                'Giants
                WholeFile(&H2D5) = &H0
                'Swap/Trap
                WholeFile(&H2DC) = Hat(0)
                'Superchargers
                WholeFile(&H2DE) = &H0
            Case 255
                'SuperChargers
                'MessageBox.Show("Super")
                'Adventures
                WholeFile(&H94) = &H0
                'Giants
                WholeFile(&H115) = &H0
                'Swap/Trap
                WholeFile(&H11C) = &H0
                'Superchargers
                WholeFile(&H11E) = Hat(1)

                'Adventures
                WholeFile(&H254) = &H0
                'Giants
                WholeFile(&H2D5) = &H0
                'Swap/Trap
                WholeFile(&H2DC) = &H0
                'Superchargers
                WholeFile(&H2DE) = Hat(1)
        End Select
    End Sub

    Shared Sub cmbHatFill()
        frmMain.cmbHat.Items.Clear()
        frmMain.cmbHat.Items.Add("No Hat") '&H0
        'All Values are Decimal
        frmMain.cmbHat.Items.Add("--Adventures--")
        frmMain.cmbHat.Items.Add("Anvil Hat") '14
        frmMain.cmbHat.Items.Add("Balloon Hat") ' 44
        frmMain.cmbHat.Items.Add("Beret") ' 15
        frmMain.cmbHat.Items.Add("Birthday Hat") ' 16
        frmMain.cmbHat.Items.Add("Bone Head") ' 17
        frmMain.cmbHat.Items.Add("Bowler Hat") ' 18
        frmMain.cmbHat.Items.Add("Chef Hat") ' 21
        frmMain.cmbHat.Items.Add("Combat Hat") ' 1
        frmMain.cmbHat.Items.Add("Coonskin Cap") ' 8
        frmMain.cmbHat.Items.Add("Cossack Hat") ' 42
        frmMain.cmbHat.Items.Add("Cowboy Hat") ' 22
        frmMain.cmbHat.Items.Add("Crown of Light") ' 28
        frmMain.cmbHat.Items.Add("Eye Hat") ' 26
        frmMain.cmbHat.Items.Add("Fancy Hat") ' 10
        frmMain.cmbHat.Items.Add("Fez") ' 27
        frmMain.cmbHat.Items.Add("Flower Hat") ' 43
        frmMain.cmbHat.Items.Add("General's Hat") ' 5
        frmMain.cmbHat.Items.Add("Happy Birthday!") ' 45
        frmMain.cmbHat.Items.Add("Jester Hat") ' 29
        frmMain.cmbHat.Items.Add("Lil Devil") ' 25
        frmMain.cmbHat.Items.Add("Miner Hat") ' 4
        frmMain.cmbHat.Items.Add("Moose Hat") ' 31
        frmMain.cmbHat.Items.Add("Napoleon Hat") ' 2
        frmMain.cmbHat.Items.Add("Pan Hat") ' 33
        frmMain.cmbHat.Items.Add("Pirate Doo Rag") ' 41
        frmMain.cmbHat.Items.Add("Pirate Hat") ' 6
        frmMain.cmbHat.Items.Add("Plunger Head") ' 32
        frmMain.cmbHat.Items.Add("Propeller Hat") ' 7
        frmMain.cmbHat.Items.Add("Pumpkin Hat") ' 40
        frmMain.cmbHat.Items.Add("Rocker Hair") ' 23
        frmMain.cmbHat.Items.Add("Rocket Hat") ' 34
        frmMain.cmbHat.Items.Add("Royal Crown") ' 24
        frmMain.cmbHat.Items.Add("Santa Hat") ' 35
        frmMain.cmbHat.Items.Add("Spiked Hat") ' 13
        frmMain.cmbHat.Items.Add("Spy Gear") ' 3
        frmMain.cmbHat.Items.Add("Straw Hat") ' 9
        frmMain.cmbHat.Items.Add("Tiki Hat") ' 36
        frmMain.cmbHat.Items.Add("Top Hat") ' 11
        frmMain.cmbHat.Items.Add("Trojan Helmet") ' 37
        frmMain.cmbHat.Items.Add("Tropical Turban") ' 20
        frmMain.cmbHat.Items.Add("Unicorn Hat") ' 38
        frmMain.cmbHat.Items.Add("Viking Helmet") ' 12
        frmMain.cmbHat.Items.Add("Wabbit Ears") ' 19
        frmMain.cmbHat.Items.Add("Winged Hat") ' 30
        frmMain.cmbHat.Items.Add("Wizard Hat") ' 39
        'Giants
        frmMain.cmbHat.Items.Add("--Giants--")
        frmMain.cmbHat.Items.Add("Archer Hat") ' 59
        frmMain.cmbHat.Items.Add("Atom Hat") ' 88
        frmMain.cmbHat.Items.Add("Battle Helmet") ' 67
        frmMain.cmbHat.Items.Add("Biter Hat") ' 87
        frmMain.cmbHat.Items.Add("Bottle Cap Hat") ' 68
        frmMain.cmbHat.Items.Add("Bowling Pin Hat") ' 48
        frmMain.cmbHat.Items.Add("Bronze Top Hat") ' 94
        frmMain.cmbHat.Items.Add("Caesar Hat") ' 83
        frmMain.cmbHat.Items.Add("Carrot Hat") ' 70
        frmMain.cmbHat.Items.Add("Dancer Hat") ' 64
        frmMain.cmbHat.Items.Add("Dangling Carrot Hat") ' 93
        frmMain.cmbHat.Items.Add("Elf Hat") ' 72
        frmMain.cmbHat.Items.Add("Firefighter Hat") ' 50
        frmMain.cmbHat.Items.Add("Fishing Hat") ' 73
        frmMain.cmbHat.Items.Add("Flower Fairy Hat") ' 84
        frmMain.cmbHat.Items.Add("Funnel Hat") ' 85
        frmMain.cmbHat.Items.Add("Future Hat") ' 74
        frmMain.cmbHat.Items.Add("Gold Top Hat") ' 96
        frmMain.cmbHat.Items.Add("Graduation Hat") ' 51
        frmMain.cmbHat.Items.Add("Knight Helm") ' 92
        frmMain.cmbHat.Items.Add("Kufi Hat") ' 91
        frmMain.cmbHat.Items.Add("Lampshade Hat") ' 52
        frmMain.cmbHat.Items.Add("Mariachi Hat") ' 53
        frmMain.cmbHat.Items.Add("Nefertiti Hat") ' 75
        frmMain.cmbHat.Items.Add("Officer Hat") ' 49
        frmMain.cmbHat.Items.Add("Pants Hat") ' 77
        frmMain.cmbHat.Items.Add("Paper Fast Food Hat") ' 55
        frmMain.cmbHat.Items.Add("Pilgrim Hat") ' 56
        frmMain.cmbHat.Items.Add("Police Siren Hat") ' 57
        frmMain.cmbHat.Items.Add("Princess Hat") ' 78
        frmMain.cmbHat.Items.Add("Purple Fedora") ' 58
        frmMain.cmbHat.Items.Add("Rasta Hat") ' 90
        frmMain.cmbHat.Items.Add("Safari Hat") ' 61
        frmMain.cmbHat.Items.Add("Sailor Hat") ' 62
        frmMain.cmbHat.Items.Add("Scrumshanks Hat") ' 86
        frmMain.cmbHat.Items.Add("Showtime Hat") ' 82
        frmMain.cmbHat.Items.Add("Silver Top Hat") ' 95
        frmMain.cmbHat.Items.Add("Sombrero") ' 89
        frmMain.cmbHat.Items.Add("Toy Soldier Hat") ' 79
        frmMain.cmbHat.Items.Add("Traffic Cone Hat") ' 65
        frmMain.cmbHat.Items.Add("Trucker Hat") ' 80
        frmMain.cmbHat.Items.Add("Turban") ' 66
        frmMain.cmbHat.Items.Add("Umbrella Hat") ' 81
        frmMain.cmbHat.Items.Add("Vintage Baseball Cap") ' 46
        'Swapforce is seperated from Trap Team, even if they use the same Byte Offset
        frmMain.cmbHat.Items.Add("--Swap Force--")
        frmMain.cmbHat.Items.Add("Asteroid Hat") '121
        frmMain.cmbHat.Items.Add("Aviator's Cap") '120
        frmMain.cmbHat.Items.Add("Awesome Hat") '150
        frmMain.cmbHat.Items.Add("Bacon Bandana") '149
        frmMain.cmbHat.Items.Add("Beacon Hat") '117
        frmMain.cmbHat.Items.Add("Beanie Cap") '126
        frmMain.cmbHat.Items.Add("Bearskin Cap") '112
        frmMain.cmbHat.Items.Add("Boater Hat") '101
        frmMain.cmbHat.Items.Add("Boonie Hat") '104
        frmMain.cmbHat.Items.Add("Cactus Hat") '140
        frmMain.cmbHat.Items.Add("Capuchon") '109
        frmMain.cmbHat.Items.Add("Card Shark Hat") '151
        frmMain.cmbHat.Items.Add("Clockwork Hat") '139
        frmMain.cmbHat.Items.Add("Creepy Helm") '123
        frmMain.cmbHat.Items.Add("Crown of Flames") '137
        frmMain.cmbHat.Items.Add("Crown of Frost") '115
        frmMain.cmbHat.Items.Add("Crystal Hat") '122
        frmMain.cmbHat.Items.Add("Dangling Carrot Hat") '93
        frmMain.cmbHat.Items.Add("Deely Boppers") '125
        frmMain.cmbHat.Items.Add("Elephant Hat") '144
        frmMain.cmbHat.Items.Add("Eyefro") '148
        frmMain.cmbHat.Items.Add("Fancy Ribbon")  '124
        frmMain.cmbHat.Items.Add("Fishbone Hat") '113
        frmMain.cmbHat.Items.Add("Flower Garland") '118
        frmMain.cmbHat.Items.Add("Four Winds Hat") '116
        frmMain.cmbHat.Items.Add("Gaucho Hat") '107
        frmMain.cmbHat.Items.Add("Glittering Tiara") '130
        frmMain.cmbHat.Items.Add("Gloop Hat") '142
        frmMain.cmbHat.Items.Add("Great Helm") '131
        frmMain.cmbHat.Items.Add("Greeble Hat") '99
        frmMain.cmbHat.Items.Add("Jolly Hat") '152
        frmMain.cmbHat.Items.Add("Kickoff Hat") '153
        frmMain.cmbHat.Items.Add("Leprechaun Hat") '127
        frmMain.cmbHat.Items.Add("Life Preserver Hat") '129  'Lifesaver Hat?
        frmMain.cmbHat.Items.Add("Lilypad Hat") '136
        frmMain.cmbHat.Items.Add("Obsidian Helm") '135
        frmMain.cmbHat.Items.Add("Paper Fast Food Hat") '55
        frmMain.cmbHat.Items.Add("Peacock Hat") '111
        frmMain.cmbHat.Items.Add("Puma Hat") '143
        frmMain.cmbHat.Items.Add("Rain Hat") '97
        frmMain.cmbHat.Items.Add("Roundlet") '108
        frmMain.cmbHat.Items.Add("Runic Headband") '138
        frmMain.cmbHat.Items.Add("Sawblade Hat") '105
        frmMain.cmbHat.Items.Add("Shark Hat") '128
        frmMain.cmbHat.Items.Add("Ski Cap") '114
        frmMain.cmbHat.Items.Add("Skullhelm") '141
        frmMain.cmbHat.Items.Add("Space Helmet") '132
        frmMain.cmbHat.Items.Add("Springtime Hat") '154
        frmMain.cmbHat.Items.Add("Stone Hat") '102
        frmMain.cmbHat.Items.Add("Stovepipe Hat") '103
        frmMain.cmbHat.Items.Add("Teeth Top Hat") '146
        frmMain.cmbHat.Items.Add("The Outsider") '98
        frmMain.cmbHat.Items.Add("Tiger Skin Cap") '145
        frmMain.cmbHat.Items.Add("Tree Branch") '119
        frmMain.cmbHat.Items.Add("Tricorn Hat") '110
        frmMain.cmbHat.Items.Add("Turkey Hat") '147
        frmMain.cmbHat.Items.Add("UFO Hat") '133
        frmMain.cmbHat.Items.Add("Volcano Hat") '100
        frmMain.cmbHat.Items.Add("Whirlwind Diadem") '134
        frmMain.cmbHat.Items.Add("Zombeanie") '106
        'Trap Team
        frmMain.cmbHat.Items.Add("--Trap Team--")
        frmMain.cmbHat.Items.Add("Alarm Clock Hat") '211
        frmMain.cmbHat.Items.Add("Bat Hat") '218
        frmMain.cmbHat.Items.Add("Batter Up Hat") '212
        frmMain.cmbHat.Items.Add("Beetle Hat") '155
        frmMain.cmbHat.Items.Add("Bellhop Hat") '237
        frmMain.cmbHat.Items.Add("Bobby") '195
        frmMain.cmbHat.Items.Add("Brain Hat") '156
        frmMain.cmbHat.Items.Add("Brainiac Hat") '157
        frmMain.cmbHat.Items.Add("Bronze Arkeyan Helm") '238
        frmMain.cmbHat.Items.Add("Bucket Hat") '158
        frmMain.cmbHat.Items.Add("Candle Hat") '234
        frmMain.cmbHat.Items.Add("Candy Cane Hat") '232
        frmMain.cmbHat.Items.Add("Carnival Hat") '246
        frmMain.cmbHat.Items.Add("Ceiling Fan Hat") '160
        frmMain.cmbHat.Items.Add("Classic Pot Hat") '187
        frmMain.cmbHat.Items.Add("Clown Bowler Hat") '163
        frmMain.cmbHat.Items.Add("Clown Classic Hat") '162
        frmMain.cmbHat.Items.Add("Coconut Hat") '247
        frmMain.cmbHat.Items.Add("Colander Hat") '164
        frmMain.cmbHat.Items.Add("Core Of Light Hat") '252
        frmMain.cmbHat.Items.Add("Cornucopia Hat") '166
        frmMain.cmbHat.Items.Add("Crazy Light Bulb Hat") '189
        frmMain.cmbHat.Items.Add("Croissant Hat") '214
        frmMain.cmbHat.Items.Add("Cubano Hat") '167
        frmMain.cmbHat.Items.Add("Cycling Hat") '168
        frmMain.cmbHat.Items.Add("Daisy Crown") '169
        frmMain.cmbHat.Items.Add("Dark Helm") '235
        frmMain.cmbHat.Items.Add("Desert Crown") '159
        frmMain.cmbHat.Items.Add("Dragon Skull") '170
        frmMain.cmbHat.Items.Add("Eggshell Hat") '233
        frmMain.cmbHat.Items.Add("Extreme Viking Hat") '203
        frmMain.cmbHat.Items.Add("Eye of Kaos Hat") '217
        frmMain.cmbHat.Items.Add("Firefly Jar") '220
        frmMain.cmbHat.Items.Add("Flight Attendant Hat") '198
        frmMain.cmbHat.Items.Add("Garrison Hat") '174
        frmMain.cmbHat.Items.Add("Generalissimo") '173
        frmMain.cmbHat.Items.Add("Gold Arkeyan Helm") '226
        frmMain.cmbHat.Items.Add("Gondolier Hat") '175
        frmMain.cmbHat.Items.Add("Hedgehog Hat") '196
        frmMain.cmbHat.Items.Add("Horns Be With You Hat") '213
        frmMain.cmbHat.Items.Add("Hunting Hat") '176
        frmMain.cmbHat.Items.Add("Imperial Hat") '161
        frmMain.cmbHat.Items.Add("Juicer Hat") '177
        frmMain.cmbHat.Items.Add("Kepi Hat") '165
        frmMain.cmbHat.Items.Add("Kokoshnik") '178
        frmMain.cmbHat.Items.Add("Light Bulb Hat") '219
        frmMain.cmbHat.Items.Add("Lighthouse Beacon Hat") '222
        frmMain.cmbHat.Items.Add("Lil' Elf Hat") '172
        frmMain.cmbHat.Items.Add("Medic Hat") '179
        frmMain.cmbHat.Items.Add("Melon Hat") '180
        frmMain.cmbHat.Items.Add("Metal Fin Hat") '192
        frmMain.cmbHat.Items.Add("Miniature Skylands Hat") '229
        frmMain.cmbHat.Items.Add("Molekin Mountain Hat") '250
        frmMain.cmbHat.Items.Add("Monday Hat") '199
        frmMain.cmbHat.Items.Add("Mountie Hat") '181
        frmMain.cmbHat.Items.Add("Night Cap") '224
        frmMain.cmbHat.Items.Add("Nurse Hat") '182
        frmMain.cmbHat.Items.Add("Octavius Cloptimus Hat") '253
        frmMain.cmbHat.Items.Add("Old-Time Movie Hat") '186
        frmMain.cmbHat.Items.Add("Outback Hat") '171
        frmMain.cmbHat.Items.Add("Palm Hat") '183
        frmMain.cmbHat.Items.Add("Paperboy Hat") '184
        frmMain.cmbHat.Items.Add("Parrot Nest") '185
        frmMain.cmbHat.Items.Add("Planet Hat") '236
        frmMain.cmbHat.Items.Add("Pork Pie Hat") '210
        frmMain.cmbHat.Items.Add("Pyramid Hat") '228
        frmMain.cmbHat.Items.Add("Radar Hat") '188
        frmMain.cmbHat.Items.Add("Rainbow Hat") '216
        frmMain.cmbHat.Items.Add("Rubber Glove Hat") '190
        frmMain.cmbHat.Items.Add("Rude Boy Hat") '209
        frmMain.cmbHat.Items.Add("Rugby Hat") '191
        frmMain.cmbHat.Items.Add("Scooter Hat") '204
        frmMain.cmbHat.Items.Add("Shadow Ghost Hat") '221
        frmMain.cmbHat.Items.Add("Sherpa Hat") '200
        frmMain.cmbHat.Items.Add("Shower Cap") '194
        frmMain.cmbHat.Items.Add("Silver Arkeyan Helm") '239
        frmMain.cmbHat.Items.Add("Skipper Hat") '243
        frmMain.cmbHat.Items.Add("Sleuth Hat") '193
        frmMain.cmbHat.Items.Add("Steampunk Hat") '197
        frmMain.cmbHat.Items.Add("Storm Hat") '225
        frmMain.cmbHat.Items.Add("Synchronized Swimming Cap") '206
        frmMain.cmbHat.Items.Add("Tin Foil Hat") '223
        frmMain.cmbHat.Items.Add("Toucan Hat") '227
        frmMain.cmbHat.Items.Add("Trash Lid") '201
        frmMain.cmbHat.Items.Add("Tribal Hat") '208
        frmMain.cmbHat.Items.Add("Turtle Hat") '202
        frmMain.cmbHat.Items.Add("Volcano Island Hat") '205
        frmMain.cmbHat.Items.Add("Weather Vane Hat") '215
        frmMain.cmbHat.Items.Add("William Tell Hat") '207
        'Superchargers
        'rolls back to 0 in figure in new byte location
        'Value is Value - 255
        frmMain.cmbHat.Items.Add("--Superchargers--")
        frmMain.cmbHat.Items.Add("Burn-Cycle Header") ' 261-255
        frmMain.cmbHat.Items.Add("Buzz Wing Hat") ' 271-255
        frmMain.cmbHat.Items.Add("Crypt Crusher Cap") ' 276-255
        frmMain.cmbHat.Items.Add("Dive Bomber Hat") ' 259-255
        frmMain.cmbHat.Items.Add("Eon’s Helm") ' 279-255
        frmMain.cmbHat.Items.Add("Gold Rusher Cog Cap") ' 268-255
        frmMain.cmbHat.Items.Add("Hot Streak Headpiece") ' 274-255
        frmMain.cmbHat.Items.Add("Jet Stream Helmet") ' 263-255
        frmMain.cmbHat.Items.Add("Kaos Krown") ' 278-255
        frmMain.cmbHat.Items.Add("Mags Hat") ' 277-255
        frmMain.cmbHat.Items.Add("Reef Ripper Helmet") ' 262-255
        frmMain.cmbHat.Items.Add("Sea Shadow Hat") ' 260-255
        frmMain.cmbHat.Items.Add("Shark Tank Topper") ' 267-255
        frmMain.cmbHat.Items.Add("Shield Striker Helmet") ' 272-255
        frmMain.cmbHat.Items.Add("Sky Slicer Hat") ' 275-255
        frmMain.cmbHat.Items.Add("Soda Skimmer Shower Cap") ' 264-255
        frmMain.cmbHat.Items.Add("Splatter Splasher Spires") ' 269-255
        frmMain.cmbHat.Items.Add("Stealth Stinger Beanie") ' 266-255
        frmMain.cmbHat.Items.Add("Sun Runner Spikes") ' 273-255
        frmMain.cmbHat.Items.Add("Thump Trucker’s Hat") ' 270-255
        frmMain.cmbHat.Items.Add("Tomb Buggy Skullcap") ' 265-255
        frmMain.cmbHat.SelectedIndex = 0
    End Sub

    'This is the Read in Hat Value
    Shared Sub cmbHatSelect()
        'MessageBox.Show(Hat(0))
        Try
            If Hat(0) = &H0 Then
                frmMain.cmbHat.SelectedItem = "None"
            ElseIf Hat(0) = &HE Then
                frmMain.cmbHat.SelectedItem = "Anvil Hat"
            ElseIf Hat(0) = &H2C Then
                frmMain.cmbHat.SelectedItem = "Balloon Hat"
            ElseIf Hat(0) = &HF Then
                frmMain.cmbHat.SelectedItem = "Beret"
            ElseIf Hat(0) = &H10 Then
                frmMain.cmbHat.SelectedItem = "Birthday Hat"
            ElseIf Hat(0) = &H11 Then
                frmMain.cmbHat.SelectedItem = "Bone Head"
            ElseIf Hat(0) = &H12 Then
                frmMain.cmbHat.SelectedItem = "Bowler Hat"
            ElseIf Hat(0) = &H15 Then
                frmMain.cmbHat.SelectedItem = "Chef Hat"
            ElseIf Hat(0) = &H1 Then
                frmMain.cmbHat.SelectedItem = "Combat Hat"
            ElseIf Hat(0) = &H8 Then
                frmMain.cmbHat.SelectedItem = "Coonskin Cap"
            ElseIf Hat(0) = &H2A Then
                frmMain.cmbHat.SelectedItem = "Cossack Hat"
            ElseIf Hat(0) = &H16 Then
                frmMain.cmbHat.SelectedItem = "Cowboy Hat"
            ElseIf Hat(0) = &H1C Then
                frmMain.cmbHat.SelectedItem = "Crown of Light"
            ElseIf Hat(0) = &H1A Then
                frmMain.cmbHat.SelectedItem = "Eye Hat"
            ElseIf Hat(0) = &HA Then
                frmMain.cmbHat.SelectedItem = "Fancy Hat"
            ElseIf Hat(0) = &H1B Then
                frmMain.cmbHat.SelectedItem = "Fez"
            ElseIf Hat(0) = &H2B Then
                frmMain.cmbHat.SelectedItem = "Flower Hat"
            ElseIf Hat(0) = &H5 Then
                frmMain.cmbHat.SelectedItem = "General's Hat"
            ElseIf Hat(0) = &H2D Then
                frmMain.cmbHat.SelectedItem = "Happy Birthday!"
            ElseIf Hat(0) = &H1D Then
                frmMain.cmbHat.SelectedItem = "Jester Hat"
            ElseIf Hat(0) = &H19 Then
                frmMain.cmbHat.SelectedItem = "Lil Devil"
            ElseIf Hat(0) = &H4 Then
                frmMain.cmbHat.SelectedItem = "Miner Hat"
            ElseIf Hat(0) = &H1F Then
                frmMain.cmbHat.SelectedItem = "Moose Hat"
            ElseIf Hat(0) = &H2 Then
                frmMain.cmbHat.SelectedItem = "Napoleon Hat"
            ElseIf Hat(0) = &H21 Then
                frmMain.cmbHat.SelectedItem = "Pan Hat"
            ElseIf Hat(0) = &H29 Then
                frmMain.cmbHat.SelectedItem = "Pirate Doo Rag"
            ElseIf Hat(0) = &H6 Then
                frmMain.cmbHat.SelectedItem = "Pirate Hat"
            ElseIf Hat(0) = &H20 Then
                frmMain.cmbHat.SelectedItem = "Plunger Head"
            ElseIf Hat(0) = &H7 Then
                frmMain.cmbHat.SelectedItem = "Propeller Hat"
            ElseIf Hat(0) = &H28 Then
                frmMain.cmbHat.SelectedItem = "Pumpkin Hat"
            ElseIf Hat(0) = &H17 Then
                frmMain.cmbHat.SelectedItem = "Rocker Hair"
            ElseIf Hat(0) = &H22 Then
                frmMain.cmbHat.SelectedItem = "Rocket Hat"
            ElseIf Hat(0) = &H18 Then
                frmMain.cmbHat.SelectedItem = "Royal Crown"
            ElseIf Hat(0) = &H23 Then
                frmMain.cmbHat.SelectedItem = "Santa Hat"
            ElseIf Hat(0) = &HD Then
                frmMain.cmbHat.SelectedItem = "Spiked Hat"
            ElseIf Hat(0) = &H3 Then
                frmMain.cmbHat.SelectedItem = "Spy Gear"
            ElseIf Hat(0) = &H9 Then
                frmMain.cmbHat.SelectedItem = "Straw Hat"
            ElseIf Hat(0) = &H24 Then
                frmMain.cmbHat.SelectedItem = "Tiki Hat"
            ElseIf Hat(0) = &HB Then
                frmMain.cmbHat.SelectedItem = "Top Hat"
            ElseIf Hat(0) = &H25 Then
                frmMain.cmbHat.SelectedItem = "Trojan Helmet"
            ElseIf Hat(0) = &H14 Then
                frmMain.cmbHat.SelectedItem = "Tropical Turban"
            ElseIf Hat(0) = &H26 Then
                frmMain.cmbHat.SelectedItem = "Unicorn Hat"
            ElseIf Hat(0) = &HC Then
                frmMain.cmbHat.SelectedItem = "Viking Helmet"
            ElseIf Hat(0) = &H13 Then
                frmMain.cmbHat.SelectedItem = "Wabbit Ears"
            ElseIf Hat(0) = &H1E Then
                frmMain.cmbHat.SelectedItem = "Winged Hat"
            ElseIf Hat(0) = &H27 Then
                frmMain.cmbHat.SelectedItem = "Wizard Hat"
            ElseIf Hat(0) = &H3B Then
                frmMain.cmbHat.SelectedItem = "Archer Hat"
            ElseIf Hat(0) = &H58 Then
                frmMain.cmbHat.SelectedItem = "Atom Hat"
            ElseIf Hat(0) = &H43 Then
                frmMain.cmbHat.SelectedItem = "Battle Helmet"
            ElseIf Hat(0) = &H57 Then
                frmMain.cmbHat.SelectedItem = "Biter Hat"
            ElseIf Hat(0) = &H44 Then
                frmMain.cmbHat.SelectedItem = "Bottle Cap Hat"
            ElseIf Hat(0) = &H30 Then
                frmMain.cmbHat.SelectedItem = "Bowling Pin Hat"
            ElseIf Hat(0) = &H5E Then
                frmMain.cmbHat.SelectedItem = "Bronze Top Hat"
            ElseIf Hat(0) = &H53 Then
                frmMain.cmbHat.SelectedItem = "Caesar Hat"
            ElseIf Hat(0) = &H46 Then
                frmMain.cmbHat.SelectedItem = "Carrot Hat"
            ElseIf Hat(0) = &H40 Then
                frmMain.cmbHat.SelectedItem = "Dancer Hat"
            ElseIf Hat(0) = &H5D Then
                frmMain.cmbHat.SelectedItem = "Dangling Carrot Hat"
            ElseIf Hat(0) = &H48 Then
                frmMain.cmbHat.SelectedItem = "Elf Hat"
            ElseIf Hat(0) = &H32 Then
                frmMain.cmbHat.SelectedItem = "Firefighter Hat"
            ElseIf Hat(0) = &H49 Then
                frmMain.cmbHat.SelectedItem = "Fishing Hat"
            ElseIf Hat(0) = &H54 Then
                frmMain.cmbHat.SelectedItem = "Flower Fairy Hat"
            ElseIf Hat(0) = &H55 Then
                frmMain.cmbHat.SelectedItem = "Funnel Hat"
            ElseIf Hat(0) = &H4A Then
                frmMain.cmbHat.SelectedItem = "Future Hat"
            ElseIf Hat(0) = &H60 Then
                frmMain.cmbHat.SelectedItem = "Gold Top Hat"
            ElseIf Hat(0) = &H33 Then
                frmMain.cmbHat.SelectedItem = "Graduation Hat"
            ElseIf Hat(0) = &H5C Then
                frmMain.cmbHat.SelectedItem = "Knight Helm"
            ElseIf Hat(0) = &H5B Then
                frmMain.cmbHat.SelectedItem = "Kufi Hat"
            ElseIf Hat(0) = &H34 Then
                frmMain.cmbHat.SelectedItem = "Lampshade Hat"
            ElseIf Hat(0) = &H35 Then
                frmMain.cmbHat.SelectedItem = "Mariachi Hat"
            ElseIf Hat(0) = &H4B Then
                frmMain.cmbHat.SelectedItem = "Nefertiti Hat"
            ElseIf Hat(0) = &H31 Then
                frmMain.cmbHat.SelectedItem = "Officer Hat"
            ElseIf Hat(0) = &H4D Then
                frmMain.cmbHat.SelectedItem = "Pants Hat"
            ElseIf Hat(0) = &H37 Then
                frmMain.cmbHat.SelectedItem = "Paper Fast Food Hat"
            ElseIf Hat(0) = &H38 Then
                frmMain.cmbHat.SelectedItem = "Pilgrim Hat"
            ElseIf Hat(0) = &H39 Then
                frmMain.cmbHat.SelectedItem = "Police Siren Hat"
            ElseIf Hat(0) = &H4E Then
                frmMain.cmbHat.SelectedItem = "Princess Hat"
            ElseIf Hat(0) = &H3A Then
                frmMain.cmbHat.SelectedItem = "Purple Fedora"
            ElseIf Hat(0) = &H5A Then
                frmMain.cmbHat.SelectedItem = "Rasta Hat"
            ElseIf Hat(0) = &H3D Then
                frmMain.cmbHat.SelectedItem = "Safari Hat"
            ElseIf Hat(0) = &H3E Then
                frmMain.cmbHat.SelectedItem = "Sailor Hat"
            ElseIf Hat(0) = &H56 Then
                frmMain.cmbHat.SelectedItem = "Scrumshanks Hat"
            ElseIf Hat(0) = &H52 Then
                frmMain.cmbHat.SelectedItem = "Showtime Hat"
            ElseIf Hat(0) = &H5F Then
                frmMain.cmbHat.SelectedItem = "Silver Top Hat"
            ElseIf Hat(0) = &H59 Then
                frmMain.cmbHat.SelectedItem = "Sombrero"
            ElseIf Hat(0) = &H4F Then
                frmMain.cmbHat.SelectedItem = "Toy Soldier Hat"
            ElseIf Hat(0) = &H41 Then
                frmMain.cmbHat.SelectedItem = "Traffic Cone Hat"
            ElseIf Hat(0) = &H50 Then
                frmMain.cmbHat.SelectedItem = "Trucker Hat"
            ElseIf Hat(0) = &H42 Then
                frmMain.cmbHat.SelectedItem = "Turban"
            ElseIf Hat(0) = &H51 Then
                frmMain.cmbHat.SelectedItem = "Umbrella Hat"
            ElseIf Hat(0) = &H2E Then
                frmMain.cmbHat.SelectedItem = "Vintage Baseball Cap"
            ElseIf Hat(0) = &H79 Then
                frmMain.cmbHat.SelectedItem = "Asteroid Hat"
            ElseIf Hat(0) = &H78 Then
                frmMain.cmbHat.SelectedItem = "Aviator's Cap"
            ElseIf Hat(0) = &H96 Then
                frmMain.cmbHat.SelectedItem = "Awesome Hat"
            ElseIf Hat(0) = &H95 Then
                frmMain.cmbHat.SelectedItem = "Bacon Bandana"
            ElseIf Hat(0) = &H75 Then
                frmMain.cmbHat.SelectedItem = "Beacon Hat"
            ElseIf Hat(0) = &H7E Then
                frmMain.cmbHat.SelectedItem = "Beanie Cap"
            ElseIf Hat(0) = &H70 Then
                frmMain.cmbHat.SelectedItem = "Bearskin Cap"
            ElseIf Hat(0) = &H65 Then
                frmMain.cmbHat.SelectedItem = "Boater Hat"
            ElseIf Hat(0) = &H68 Then
                frmMain.cmbHat.SelectedItem = "Boonie Hat"
            ElseIf Hat(0) = &H8C Then
                frmMain.cmbHat.SelectedItem = "Cactus Hat"
            ElseIf Hat(0) = &H6D Then
                frmMain.cmbHat.SelectedItem = "Capuchon"
            ElseIf Hat(0) = &H97 Then
                frmMain.cmbHat.SelectedItem = "Card Shark Hat"
            ElseIf Hat(0) = &H8B Then
                frmMain.cmbHat.SelectedItem = "Clockwork Hat"
            ElseIf Hat(0) = &H7B Then
                frmMain.cmbHat.SelectedItem = "Creepy Helm"
            ElseIf Hat(0) = &H89 Then
                frmMain.cmbHat.SelectedItem = "Crown of Flames"
            ElseIf Hat(0) = &H73 Then
                frmMain.cmbHat.SelectedItem = "Crown of Frost"
            ElseIf Hat(0) = &H7A Then
                frmMain.cmbHat.SelectedItem = "Crystal Hat"
            ElseIf Hat(0) = &H5D Then
                frmMain.cmbHat.SelectedItem = "Dangling Carrot Hat"
            ElseIf Hat(0) = &H7D Then
                frmMain.cmbHat.SelectedItem = "Deely Boppers"
            ElseIf Hat(0) = &H90 Then
                frmMain.cmbHat.SelectedItem = "Elephant Hat"
            ElseIf Hat(0) = &H94 Then
                frmMain.cmbHat.SelectedItem = "Eyefro"
            ElseIf Hat(0) = &H7C Then
                frmMain.cmbHat.SelectedItem = "Fancy Ribbon "
            ElseIf Hat(0) = &H71 Then
                frmMain.cmbHat.SelectedItem = "Fishbone Hat"
            ElseIf Hat(0) = &H76 Then
                frmMain.cmbHat.SelectedItem = "Flower Garland"
            ElseIf Hat(0) = &H74 Then
                frmMain.cmbHat.SelectedItem = "Four Winds Hat"
            ElseIf Hat(0) = &H6B Then
                frmMain.cmbHat.SelectedItem = "Gaucho Hat"
            ElseIf Hat(0) = &H82 Then
                frmMain.cmbHat.SelectedItem = "Glittering Tiara"
            ElseIf Hat(0) = &H8E Then
                frmMain.cmbHat.SelectedItem = "Gloop Hat"
            ElseIf Hat(0) = &H83 Then
                frmMain.cmbHat.SelectedItem = "Great Helm"
            ElseIf Hat(0) = &H63 Then
                frmMain.cmbHat.SelectedItem = "Greeble Hat"
            ElseIf Hat(0) = &H98 Then
                frmMain.cmbHat.SelectedItem = "Jolly Hat"
            ElseIf Hat(0) = &H99 Then
                frmMain.cmbHat.SelectedItem = "Kickoff Hat"
            ElseIf Hat(0) = &H7F Then
                frmMain.cmbHat.SelectedItem = "Leprechaun Hat"
            ElseIf Hat(0) = &H81 Then
                frmMain.cmbHat.SelectedItem = "Life Preserver Hat"
            ElseIf Hat(0) = &H88 Then
                frmMain.cmbHat.SelectedItem = "Lilypad Hat"
            ElseIf Hat(0) = &H87 Then
                frmMain.cmbHat.SelectedItem = "Obsidian Helm"
            ElseIf Hat(0) = &H37 Then
                frmMain.cmbHat.SelectedItem = "Paper Fast Food Hat"
            ElseIf Hat(0) = &H6F Then
                frmMain.cmbHat.SelectedItem = "Peacock Hat"
            ElseIf Hat(0) = &H8F Then
                frmMain.cmbHat.SelectedItem = "Puma Hat"
            ElseIf Hat(0) = &H61 Then
                frmMain.cmbHat.SelectedItem = "Rain Hat"
            ElseIf Hat(0) = &H6C Then
                frmMain.cmbHat.SelectedItem = "Roundlet"
            ElseIf Hat(0) = &H8A Then
                frmMain.cmbHat.SelectedItem = "Runic Headband"
            ElseIf Hat(0) = &H69 Then
                frmMain.cmbHat.SelectedItem = "Sawblade Hat"
            ElseIf Hat(0) = &H80 Then
                frmMain.cmbHat.SelectedItem = "Shark Hat"
            ElseIf Hat(0) = &H72 Then
                frmMain.cmbHat.SelectedItem = "Ski Cap"
            ElseIf Hat(0) = &H8D Then
                frmMain.cmbHat.SelectedItem = "Skullhelm"
            ElseIf Hat(0) = &H84 Then
                frmMain.cmbHat.SelectedItem = "Space Helmet"
            ElseIf Hat(0) = &H9A Then
                frmMain.cmbHat.SelectedItem = "Springtime Hat"
            ElseIf Hat(0) = &H66 Then
                frmMain.cmbHat.SelectedItem = "Stone Hat"
            ElseIf Hat(0) = &H67 Then
                frmMain.cmbHat.SelectedItem = "Stovepipe Hat"
            ElseIf Hat(0) = &H92 Then
                frmMain.cmbHat.SelectedItem = "Teeth Top Hat"
            ElseIf Hat(0) = &H62 Then
                frmMain.cmbHat.SelectedItem = "The Outsider"
            ElseIf Hat(0) = &H91 Then
                frmMain.cmbHat.SelectedItem = "Tiger Skin Cap"
            ElseIf Hat(0) = &H77 Then
                frmMain.cmbHat.SelectedItem = "Tree Branch"
            ElseIf Hat(0) = &H6E Then
                frmMain.cmbHat.SelectedItem = "Tricorn Hat"
            ElseIf Hat(0) = &H93 Then
                frmMain.cmbHat.SelectedItem = "Turkey Hat"
            ElseIf Hat(0) = &H85 Then
                frmMain.cmbHat.SelectedItem = "UFO Hat"
            ElseIf Hat(0) = &H64 Then
                frmMain.cmbHat.SelectedItem = "Volcano Hat"
            ElseIf Hat(0) = &H86 Then
                frmMain.cmbHat.SelectedItem = "Whirlwind Diadem"
            ElseIf Hat(0) = &H6A Then
                frmMain.cmbHat.SelectedItem = "Zombeanie"
            ElseIf Hat(0) = &HD3 Then
                frmMain.cmbHat.SelectedItem = "Alarm Clock Hat"
            ElseIf Hat(0) = &HDA Then
                frmMain.cmbHat.SelectedItem = "Bat Hat"
            ElseIf Hat(0) = &HD4 Then
                frmMain.cmbHat.SelectedItem = "Batter Up Hat"
            ElseIf Hat(0) = &H9B Then
                frmMain.cmbHat.SelectedItem = "Beetle Hat"
            ElseIf Hat(0) = &HED Then
                frmMain.cmbHat.SelectedItem = "Bellhop Hat"
            ElseIf Hat(0) = &HC3 Then
                frmMain.cmbHat.SelectedItem = "Bobby"
            ElseIf Hat(0) = &H9C Then
                frmMain.cmbHat.SelectedItem = "Brain Hat"
            ElseIf Hat(0) = &H9D Then
                frmMain.cmbHat.SelectedItem = "Brainiac Hat"
            ElseIf Hat(0) = &HEE Then
                frmMain.cmbHat.SelectedItem = "Bronze Arkeyan Helm"
            ElseIf Hat(0) = &H9E Then
                frmMain.cmbHat.SelectedItem = "Bucket Hat"
            ElseIf Hat(0) = &HEA Then
                frmMain.cmbHat.SelectedItem = "Candle Hat"
            ElseIf Hat(0) = &HE8 Then
                frmMain.cmbHat.SelectedItem = "Candy Cane Hat"
            ElseIf Hat(0) = &HF6 Then
                frmMain.cmbHat.SelectedItem = "Carnival Hat"
            ElseIf Hat(0) = &HA0 Then
                frmMain.cmbHat.SelectedItem = "Ceiling Fan Hat"
            ElseIf Hat(0) = &HBB Then
                frmMain.cmbHat.SelectedItem = "Classic Pot Hat"
            ElseIf Hat(0) = &HA3 Then
                frmMain.cmbHat.SelectedItem = "Clown Bowler Hat"
            ElseIf Hat(0) = &HA2 Then
                frmMain.cmbHat.SelectedItem = "Clown Classic Hat"
            ElseIf Hat(0) = &HF7 Then
                frmMain.cmbHat.SelectedItem = "Coconut Hat"
            ElseIf Hat(0) = &HA4 Then
                frmMain.cmbHat.SelectedItem = "Colander Hat"
            ElseIf Hat(0) = &HFC Then
                frmMain.cmbHat.SelectedItem = "Core Of Light Hat"
            ElseIf Hat(0) = &HA6 Then
                frmMain.cmbHat.SelectedItem = "Cornucopia Hat"
            ElseIf Hat(0) = &HBD Then
                frmMain.cmbHat.SelectedItem = "Crazy Light Bulb Hat"
            ElseIf Hat(0) = &HD6 Then
                frmMain.cmbHat.SelectedItem = "Croissant Hat"
            ElseIf Hat(0) = &HA7 Then
                frmMain.cmbHat.SelectedItem = "Cubano Hat"
            ElseIf Hat(0) = &HA8 Then
                frmMain.cmbHat.SelectedItem = "Cycling Hat"
            ElseIf Hat(0) = &HA9 Then
                frmMain.cmbHat.SelectedItem = "Daisy Crown"
            ElseIf Hat(0) = &HEB Then
                frmMain.cmbHat.SelectedItem = "Dark Helm"
            ElseIf Hat(0) = &H9F Then
                frmMain.cmbHat.SelectedItem = "Desert Crown"
            ElseIf Hat(0) = &HAA Then
                frmMain.cmbHat.SelectedItem = "Dragon Skull"
            ElseIf Hat(0) = &HE9 Then
                frmMain.cmbHat.SelectedItem = "Eggshell Hat"
            ElseIf Hat(0) = &HCB Then
                frmMain.cmbHat.SelectedItem = "Extreme Viking Hat"
            ElseIf Hat(0) = &HD9 Then
                frmMain.cmbHat.SelectedItem = "Eye of Kaos Hat"
            ElseIf Hat(0) = &HDC Then
                frmMain.cmbHat.SelectedItem = "Firefly Jar"
            ElseIf Hat(0) = &HC6 Then
                frmMain.cmbHat.SelectedItem = "Flight Attendant Hat"
            ElseIf Hat(0) = &HAE Then
                frmMain.cmbHat.SelectedItem = "Garrison Hat"
            ElseIf Hat(0) = &HAD Then
                frmMain.cmbHat.SelectedItem = "Generalissimo"
            ElseIf Hat(0) = &HE2 Then
                frmMain.cmbHat.SelectedItem = "Gold Arkeyan Helm"
            ElseIf Hat(0) = &HAF Then
                frmMain.cmbHat.SelectedItem = "Gondolier Hat"
            ElseIf Hat(0) = &HC4 Then
                frmMain.cmbHat.SelectedItem = "Hedgehog Hat"
            ElseIf Hat(0) = &HD5 Then
                frmMain.cmbHat.SelectedItem = "Horns Be With You Hat"
            ElseIf Hat(0) = &HB0 Then
                frmMain.cmbHat.SelectedItem = "Hunting Hat"
            ElseIf Hat(0) = &HA1 Then
                frmMain.cmbHat.SelectedItem = "Imperial Hat"
            ElseIf Hat(0) = &HB1 Then
                frmMain.cmbHat.SelectedItem = "Juicer Hat"
            ElseIf Hat(0) = &HA5 Then
                frmMain.cmbHat.SelectedItem = "Kepi Hat"
            ElseIf Hat(0) = &HB2 Then
                frmMain.cmbHat.SelectedItem = "Kokoshnik"
            ElseIf Hat(0) = &HDB Then
                frmMain.cmbHat.SelectedItem = "Light Bulb Hat"
            ElseIf Hat(0) = &HDE Then
                frmMain.cmbHat.SelectedItem = "Lighthouse Beacon Hat"
            ElseIf Hat(0) = &HAC Then
                frmMain.cmbHat.SelectedItem = "Lil' Elf Hat"
            ElseIf Hat(0) = &HB3 Then
                frmMain.cmbHat.SelectedItem = "Medic Hat"
            ElseIf Hat(0) = &HB4 Then
                frmMain.cmbHat.SelectedItem = "Melon Hat"
            ElseIf Hat(0) = &HC0 Then
                frmMain.cmbHat.SelectedItem = "Metal Fin Hat"
            ElseIf Hat(0) = &HE5 Then
                frmMain.cmbHat.SelectedItem = "Miniature Skylands Hat"
            ElseIf Hat(0) = &HFA Then
                frmMain.cmbHat.SelectedItem = "Molekin Mountain Hat"
            ElseIf Hat(0) = &HC7 Then
                frmMain.cmbHat.SelectedItem = "Monday Hat"
            ElseIf Hat(0) = &HB5 Then
                frmMain.cmbHat.SelectedItem = "Mountie Hat"
            ElseIf Hat(0) = &HE0 Then
                frmMain.cmbHat.SelectedItem = "Night Cap"
            ElseIf Hat(0) = &HB6 Then
                frmMain.cmbHat.SelectedItem = "Nurse Hat"
            ElseIf Hat(0) = &HFD Then
                frmMain.cmbHat.SelectedItem = "Octavius Cloptimus Hat"
            ElseIf Hat(0) = &HBA Then
                frmMain.cmbHat.SelectedItem = "Old-Time Movie Hat"
            ElseIf Hat(0) = &HAB Then
                frmMain.cmbHat.SelectedItem = "Outback Hat"
            ElseIf Hat(0) = &HB7 Then
                frmMain.cmbHat.SelectedItem = "Palm Hat"
            ElseIf Hat(0) = &HB8 Then
                frmMain.cmbHat.SelectedItem = "Paperboy Hat"
            ElseIf Hat(0) = &HB9 Then
                frmMain.cmbHat.SelectedItem = "Parrot Nest"
            ElseIf Hat(0) = &HEC Then
                frmMain.cmbHat.SelectedItem = "Planet Hat"
            ElseIf Hat(0) = &HD2 Then
                frmMain.cmbHat.SelectedItem = "Pork Pie Hat"
            ElseIf Hat(0) = &HE4 Then
                frmMain.cmbHat.SelectedItem = "Pyramid Hat"
            ElseIf Hat(0) = &HBC Then
                frmMain.cmbHat.SelectedItem = "Radar Hat"
            ElseIf Hat(0) = &HD8 Then
                frmMain.cmbHat.SelectedItem = "Rainbow Hat"
            ElseIf Hat(0) = &HBE Then
                frmMain.cmbHat.SelectedItem = "Rubber Glove Hat"
            ElseIf Hat(0) = &HD1 Then
                frmMain.cmbHat.SelectedItem = "Rude Boy Hat"
            ElseIf Hat(0) = &HBF Then
                frmMain.cmbHat.SelectedItem = "Rugby Hat"
            ElseIf Hat(0) = &HCC Then
                frmMain.cmbHat.SelectedItem = "Scooter Hat"
            ElseIf Hat(0) = &HDD Then
                frmMain.cmbHat.SelectedItem = "Shadow Ghost Hat"
            ElseIf Hat(0) = &HC8 Then
                frmMain.cmbHat.SelectedItem = "Sherpa Hat"
            ElseIf Hat(0) = &HC2 Then
                frmMain.cmbHat.SelectedItem = "Shower Cap"
            ElseIf Hat(0) = &HEF Then
                frmMain.cmbHat.SelectedItem = "Silver Arkeyan Helm"
            ElseIf Hat(0) = &HF3 Then
                frmMain.cmbHat.SelectedItem = "Skipper Hat"
            ElseIf Hat(0) = &HC1 Then
                frmMain.cmbHat.SelectedItem = "Sleuth Hat"
            ElseIf Hat(0) = &HC5 Then
                frmMain.cmbHat.SelectedItem = "Steampunk Hat"
            ElseIf Hat(0) = &HE1 Then
                frmMain.cmbHat.SelectedItem = "Storm Hat"
            ElseIf Hat(0) = &HCE Then
                frmMain.cmbHat.SelectedItem = "Synchronized Swimming Cap"
            ElseIf Hat(0) = &HDF Then
                frmMain.cmbHat.SelectedItem = "Tin Foil Hat"
            ElseIf Hat(0) = &HE3 Then
                frmMain.cmbHat.SelectedItem = "Toucan Hat"
            ElseIf Hat(0) = &HC9 Then
                frmMain.cmbHat.SelectedItem = "Trash Lid"
            ElseIf Hat(0) = &HD0 Then
                frmMain.cmbHat.SelectedItem = "Tribal Hat"
            ElseIf Hat(0) = &HCA Then
                frmMain.cmbHat.SelectedItem = "Turtle Hat"
            ElseIf Hat(0) = &HCD Then
                frmMain.cmbHat.SelectedItem = "Volcano Island Hat"
            ElseIf Hat(0) = &HD7 Then
                frmMain.cmbHat.SelectedItem = "Weather Vane Hat"
            ElseIf Hat(0) = &HCF Then
                frmMain.cmbHat.SelectedItem = "William Tell Hat"
                'Superchargers
            ElseIf Hat(1) = &H6 Then
                frmMain.cmbHat.SelectedItem = "Burn-Cycle Header"
            ElseIf Hat(1) = &H10 Then
                frmMain.cmbHat.SelectedItem = "Buzz Wing Hat"
            ElseIf Hat(1) = &H15 Then
                frmMain.cmbHat.SelectedItem = "Crypt Crusher Cap"
            ElseIf Hat(1) = &H4 Then
                frmMain.cmbHat.SelectedItem = "Dive Bomber Hat"
            ElseIf Hat(1) = &H18 Then
                frmMain.cmbHat.SelectedItem = "Eon's Helm"
            ElseIf Hat(1) = &HD Then
                frmMain.cmbHat.SelectedItem = "Gold Rusher Cog Cap"
            ElseIf Hat(1) = &H13 Then
                frmMain.cmbHat.SelectedItem = "Hot Streak Headpiece"
            ElseIf Hat(1) = &H8 Then
                frmMain.cmbHat.SelectedItem = "Jet Stream Helmet"
            ElseIf Hat(1) = &H17 Then
                frmMain.cmbHat.SelectedItem = "Kaos Krown"
            ElseIf Hat(1) = &H16 Then
                frmMain.cmbHat.SelectedItem = "Mags Hat"
            ElseIf Hat(1) = &H7 Then
                frmMain.cmbHat.SelectedItem = "Reef Ripper Helmet"
            ElseIf Hat(1) = &H5 Then
                frmMain.cmbHat.SelectedItem = "Sea Shadow Hat"
            ElseIf Hat(1) = &HC Then
                frmMain.cmbHat.SelectedItem = "Shark Tank Topper"
            ElseIf Hat(1) = &H11 Then
                frmMain.cmbHat.SelectedItem = "Shield Striker Helmet"
            ElseIf Hat(1) = &H14 Then
                frmMain.cmbHat.SelectedItem = "Sky Slicer Hat"
            ElseIf Hat(1) = &H9 Then
                frmMain.cmbHat.SelectedItem = "Soda Skimmer Shower Cap"
            ElseIf Hat(1) = &HE Then
                frmMain.cmbHat.SelectedItem = "Splatter Splasher Spires"
            ElseIf Hat(1) = &HB Then
                frmMain.cmbHat.SelectedItem = "Stealth Stinger Beanie"
            ElseIf Hat(1) = &H12 Then
                frmMain.cmbHat.SelectedItem = "Sun Runner Spikes"
            ElseIf Hat(1) = &HF Then
                frmMain.cmbHat.SelectedItem = "Thump Trucker's Hat"
            ElseIf Hat(1) = &HA Then
                frmMain.cmbHat.SelectedItem = "Tomb Buggy Skullcap"
            End If
        Catch ex As Exception

        End Try

    End Sub

    'This is called when the user selects a new Hat
    Shared Sub SelectHat()
        Hat(0) = &H0
        Hat(1) = &H0
        If frmMain.cmbHat.SelectedItem = "No Hat" Then
            '00
            Hat(0) = &H0
        ElseIf frmMain.cmbHat.SelectedItem = "Alarm Clock Hat" Then
            '211
            Hat(0) = &HD3
        ElseIf frmMain.cmbHat.SelectedItem = "Anvil Hat" Then
            '14
            Hat(0) = &HE
        ElseIf frmMain.cmbHat.SelectedItem = "Archer Hat" Then
            '59
            Hat(0) = &H3B
        ElseIf frmMain.cmbHat.SelectedItem = "Asteroid Hat" Then
            '121
            Hat(0) = &H79
        ElseIf frmMain.cmbHat.SelectedItem = "Atom Hat" Then
            '88
            Hat(0) = &H58
        ElseIf frmMain.cmbHat.SelectedItem = "Aviator's Cap" Then
            '120
            Hat(0) = &H78
        ElseIf frmMain.cmbHat.SelectedItem = "Awesome Hat" Then
            '150
            Hat(0) = &H96
        ElseIf frmMain.cmbHat.SelectedItem = "Bacon Bandana" Then
            '149
            Hat(0) = &H95
        ElseIf frmMain.cmbHat.SelectedItem = "Balloon Hat" Then
            '44
            Hat(0) = &H2C
        ElseIf frmMain.cmbHat.SelectedItem = "Bat Hat" Then
            '218
            Hat(0) = &HDA
        ElseIf frmMain.cmbHat.SelectedItem = "Batter Up Hat" Then
            '212
            Hat(0) = &HD4
        ElseIf frmMain.cmbHat.SelectedItem = "Battle Helmet" Then
            '67
            Hat(0) = &H43
        ElseIf frmMain.cmbHat.SelectedItem = "Beacon Hat" Then
            '117
            Hat(0) = &H75
        ElseIf frmMain.cmbHat.SelectedItem = "Beanie Cap" Then
            '126
            Hat(0) = &H7E
        ElseIf frmMain.cmbHat.SelectedItem = "Bearskin Cap" Then
            '112
            Hat(0) = &H70
        ElseIf frmMain.cmbHat.SelectedItem = "Beetle Hat" Then
            '155
            Hat(0) = &H9B
        ElseIf frmMain.cmbHat.SelectedItem = "Bellhop Hat" Then
            '237
            Hat(0) = &HED
        ElseIf frmMain.cmbHat.SelectedItem = "Beret" Then
            '15
            Hat(0) = &HF
        ElseIf frmMain.cmbHat.SelectedItem = "Birthday Hat" Then
            '16
            Hat(0) = &H10
        ElseIf frmMain.cmbHat.SelectedItem = "Biter Hat" Then
            '87
            Hat(0) = &H57
        ElseIf frmMain.cmbHat.SelectedItem = "Boater Hat" Then
            '101
            Hat(0) = &H65
        ElseIf frmMain.cmbHat.SelectedItem = "Bobby" Then
            '195
            Hat(0) = &HC3
        ElseIf frmMain.cmbHat.SelectedItem = "Bone Head" Then
            '17
            Hat(0) = &H11
        ElseIf frmMain.cmbHat.SelectedItem = "Boonie Hat" Then
            '104
            Hat(0) = &H68
        ElseIf frmMain.cmbHat.SelectedItem = "Bottle Cap Hat" Then
            '68
            Hat(0) = &H44
        ElseIf frmMain.cmbHat.SelectedItem = "Bowler Hat" Then
            '18
            Hat(0) = &H12
        ElseIf frmMain.cmbHat.SelectedItem = "Bowling Pin Hat" Then
            '48
            Hat(0) = &H30
        ElseIf frmMain.cmbHat.SelectedItem = "Brain Hat" Then
            '156
            Hat(0) = &H9C
        ElseIf frmMain.cmbHat.SelectedItem = "Brainiac Hat" Then
            '157
            Hat(0) = &H9D
        ElseIf frmMain.cmbHat.SelectedItem = "Bronze Arkeyan Helm" Then
            '238
            Hat(0) = &HEE
        ElseIf frmMain.cmbHat.SelectedItem = "Bronze Top Hat" Then
            '94
            Hat(0) = &H5E
        ElseIf frmMain.cmbHat.SelectedItem = "Bucket Hat" Then
            '158
            Hat(0) = &H9E
        ElseIf frmMain.cmbHat.SelectedItem = "Cactus Hat" Then
            '140
            Hat(0) = &H8C
        ElseIf frmMain.cmbHat.SelectedItem = "Caesar Hat" Then
            '83
            Hat(0) = &H53
        ElseIf frmMain.cmbHat.SelectedItem = "Candle Hat" Then
            '234
            Hat(0) = &HEA
        ElseIf frmMain.cmbHat.SelectedItem = "Candy Cane Hat" Then
            '232
            Hat(0) = &HE8
        ElseIf frmMain.cmbHat.SelectedItem = "Capuchon" Then
            '109
            Hat(0) = &H6D
        ElseIf frmMain.cmbHat.SelectedItem = "Card Shark Hat" Then
            '151
            Hat(0) = &H97
        ElseIf frmMain.cmbHat.SelectedItem = "Carnival Hat" Then
            '246
            Hat(0) = &HF6
        ElseIf frmMain.cmbHat.SelectedItem = "Carrot Hat" Then
            '70
            Hat(0) = &H46
        ElseIf frmMain.cmbHat.SelectedItem = "Ceiling Fan Hat" Then
            '160
            Hat(0) = &HA0
        ElseIf frmMain.cmbHat.SelectedItem = "Chef Hat" Then
            '21
            Hat(0) = &H15
        ElseIf frmMain.cmbHat.SelectedItem = "Classic Pot Hat" Then
            '187
            Hat(0) = &HBB
        ElseIf frmMain.cmbHat.SelectedItem = "Clockwork Hat" Then
            '139
            Hat(0) = &H8B
        ElseIf frmMain.cmbHat.SelectedItem = "Clown Bowler Hat" Then
            '163
            Hat(0) = &HA3
        ElseIf frmMain.cmbHat.SelectedItem = "Clown Classic Hat" Then
            '162
            Hat(0) = &HA2
        ElseIf frmMain.cmbHat.SelectedItem = "Coconut Hat" Then
            '247
            Hat(0) = &HF7
        ElseIf frmMain.cmbHat.SelectedItem = "Colander Hat" Then
            '164
            Hat(0) = &HA4
        ElseIf frmMain.cmbHat.SelectedItem = "Combat Hat" Then
            '1
            Hat(0) = &H1
        ElseIf frmMain.cmbHat.SelectedItem = "Coonskin Cap" Then
            '8
            Hat(0) = &H8
        ElseIf frmMain.cmbHat.SelectedItem = "Core Of Light Hat" Then
            '252
            Hat(0) = &HFC
        ElseIf frmMain.cmbHat.SelectedItem = "Cornucopia Hat" Then
            '166
            Hat(0) = &HA6
        ElseIf frmMain.cmbHat.SelectedItem = "Cossack Hat" Then
            '42
            Hat(0) = &H2A
        ElseIf frmMain.cmbHat.SelectedItem = "Cowboy Hat" Then
            '22
            Hat(0) = &H16
        ElseIf frmMain.cmbHat.SelectedItem = "Crazy Light Bulb Hat" Then
            '189
            Hat(0) = &HBD
        ElseIf frmMain.cmbHat.SelectedItem = "Creepy Helm" Then
            '123
            Hat(0) = &H7B
        ElseIf frmMain.cmbHat.SelectedItem = "Croissant Hat" Then
            '214
            Hat(0) = &HD6
        ElseIf frmMain.cmbHat.SelectedItem = "Crown of Flames" Then
            '137
            Hat(0) = &H89
        ElseIf frmMain.cmbHat.SelectedItem = "Crown of Frost" Then
            '115
            Hat(0) = &H73
        ElseIf frmMain.cmbHat.SelectedItem = "Crown of Light" Then
            '28
            Hat(0) = &H1C
        ElseIf frmMain.cmbHat.SelectedItem = "Crystal Hat" Then
            '122
            Hat(0) = &H7A
        ElseIf frmMain.cmbHat.SelectedItem = "Cubano Hat" Then
            '167
            Hat(0) = &HA7
        ElseIf frmMain.cmbHat.SelectedItem = "Cycling Hat" Then
            '168
            Hat(0) = &HA8
        ElseIf frmMain.cmbHat.SelectedItem = "Daisy Crown" Then
            '169
            Hat(0) = &HA9
        ElseIf frmMain.cmbHat.SelectedItem = "Dancer Hat" Then
            '64
            Hat(0) = &H40
        ElseIf frmMain.cmbHat.SelectedItem = "Dangling Carrot Hat" Then
            '93
            Hat(0) = &H5D
        ElseIf frmMain.cmbHat.SelectedItem = "Dark Helm" Then
            '235
            Hat(0) = &HEB
        ElseIf frmMain.cmbHat.SelectedItem = "Deely Boppers" Then
            '125
            Hat(0) = &H7D
        ElseIf frmMain.cmbHat.SelectedItem = "Desert Crown" Then
            '159
            Hat(0) = &H9D
        ElseIf frmMain.cmbHat.SelectedItem = "Dragon Skull" Then
            '170
            Hat(0) = &HAA
        ElseIf frmMain.cmbHat.SelectedItem = "Eggshell Hat" Then
            '233
            Hat(0) = &HE9
        ElseIf frmMain.cmbHat.SelectedItem = "Elephant Hat" Then
            '144
            Hat(0) = &H90
        ElseIf frmMain.cmbHat.SelectedItem = "Elf Hat" Then
            '72
            Hat(0) = &H48
        ElseIf frmMain.cmbHat.SelectedItem = "Extreme Viking Hat" Then
            '203
            Hat(0) = &HCB
        ElseIf frmMain.cmbHat.SelectedItem = "Eyefro" Then
            '148
            Hat(0) = &H94
        ElseIf frmMain.cmbHat.SelectedItem = "Eye Hat" Then
            '26
            Hat(0) = &H1A
        ElseIf frmMain.cmbHat.SelectedItem = "Eye of Kaos Hat" Then
            '217
            Hat(0) = &HD9
        ElseIf frmMain.cmbHat.SelectedItem = "Fancy Hat" Then
            '10
            Hat(0) = &HA
        ElseIf frmMain.cmbHat.SelectedItem = "Fancy Ribbon" Then
            '124
            Hat(0) = &H7C
        ElseIf frmMain.cmbHat.SelectedItem = "Fez" Then
            '27
            Hat(0) = &H1B
        ElseIf frmMain.cmbHat.SelectedItem = "Firefighter Hat" Then
            '50
            Hat(0) = &H32
        ElseIf frmMain.cmbHat.SelectedItem = "Firefly Jar" Then
            '220
            Hat(0) = &HDC
        ElseIf frmMain.cmbHat.SelectedItem = "Fishbone Hat" Then
            '113
            Hat(0) = &H71
        ElseIf frmMain.cmbHat.SelectedItem = "Fishing Hat" Then
            '73
            Hat(0) = &H49
        ElseIf frmMain.cmbHat.SelectedItem = "Flight Attendant Hat" Then
            '198
            Hat(0) = &HC6
        ElseIf frmMain.cmbHat.SelectedItem = "Flower Fairy Hat" Then
            '84
            Hat(0) = &H54
        ElseIf frmMain.cmbHat.SelectedItem = "Flower Garland" Then
            '118
            Hat(0) = &H76
        ElseIf frmMain.cmbHat.SelectedItem = "Flower Hat" Then
            '43
            Hat(0) = &H2B
        ElseIf frmMain.cmbHat.SelectedItem = "Four Winds Hat" Then
            '116
            Hat(0) = &H74
        ElseIf frmMain.cmbHat.SelectedItem = "Funnel Hat" Then
            '85
            Hat(0) = &H55
        ElseIf frmMain.cmbHat.SelectedItem = "Future Hat" Then
            '74
            Hat(0) = &H4A
        ElseIf frmMain.cmbHat.SelectedItem = "Garrison Hat" Then
            '174
            Hat(0) = &HAE
        ElseIf frmMain.cmbHat.SelectedItem = "Gaucho Hat" Then
            '107
            Hat(0) = &H6B
        ElseIf frmMain.cmbHat.SelectedItem = "General's Hat" Then
            '5
            Hat(0) = &H5
        ElseIf frmMain.cmbHat.SelectedItem = "Generalissimo" Then
            '173
            Hat(0) = &HAD
        ElseIf frmMain.cmbHat.SelectedItem = "Glittering Tiara" Then
            '130
            Hat(0) = &H82
        ElseIf frmMain.cmbHat.SelectedItem = "Gloop Hat" Then
            '142
            Hat(0) = &H8E
        ElseIf frmMain.cmbHat.SelectedItem = "Gold Arkeyan Helm" Then
            '226
            Hat(0) = &HE2
        ElseIf frmMain.cmbHat.SelectedItem = "Gold Top Hat" Then
            '96
            Hat(0) = &H60
        ElseIf frmMain.cmbHat.SelectedItem = "Gondolier Hat" Then
            '175
            Hat(0) = &HAF
        ElseIf frmMain.cmbHat.SelectedItem = "Graduation Hat" Then
            '51
            Hat(0) = &H33
        ElseIf frmMain.cmbHat.SelectedItem = "Great Helm" Then
            '131
            Hat(0) = &H83
        ElseIf frmMain.cmbHat.SelectedItem = "Greeble Hat" Then
            '99
            Hat(0) = &H63
        ElseIf frmMain.cmbHat.SelectedItem = "Happy Birthday!" Then
            '45
            Hat(0) = &H2D
        ElseIf frmMain.cmbHat.SelectedItem = "Hedgehog Hat" Then
            '196
            Hat(0) = &HC4
        ElseIf frmMain.cmbHat.SelectedItem = "Horns Be With You Hat" Then
            '213
            Hat(0) = &HD5
        ElseIf frmMain.cmbHat.SelectedItem = "Hunting Hat" Then
            '176
            Hat(0) = &HB0
        ElseIf frmMain.cmbHat.SelectedItem = "Imperial Hat" Then
            '161
            Hat(0) = &HA1
        ElseIf frmMain.cmbHat.SelectedItem = "Jester Hat" Then
            '29
            Hat(0) = &H1D
        ElseIf frmMain.cmbHat.SelectedItem = "Jolly Hat" Then
            '152
            Hat(0) = &H98
        ElseIf frmMain.cmbHat.SelectedItem = "Juicer Hat" Then
            '177
            Hat(0) = &HB1
        ElseIf frmMain.cmbHat.SelectedItem = "Kepi Hat" Then
            '91
            Hat(0) = &H5B
        ElseIf frmMain.cmbHat.SelectedItem = "Kickoff Hat" Then
            '153
            Hat(0) = &H99
        ElseIf frmMain.cmbHat.SelectedItem = "Knight Helm" Then
            '92
            Hat(0) = &H5C
        ElseIf frmMain.cmbHat.SelectedItem = "Kokoshnik" Then
            '178
            Hat(0) = &HB2
        ElseIf frmMain.cmbHat.SelectedItem = "Kufi Hat" Then
            '91
            Hat(0) = &H5B
        ElseIf frmMain.cmbHat.SelectedItem = "Lampshade Hat" Then
            '52
            Hat(0) = &H34
        ElseIf frmMain.cmbHat.SelectedItem = "Leprechaun Hat" Then
            '127
            Hat(0) = &H7F
        ElseIf frmMain.cmbHat.SelectedItem = "Life Preserver Hat" Then
            '129
            Hat(0) = &H81
        ElseIf frmMain.cmbHat.SelectedItem = "Light Bulb Hat" Then
            '219
            Hat(0) = &HD8
        ElseIf frmMain.cmbHat.SelectedItem = "Lighthouse Beacon Hat" Then
            '222
            Hat(0) = &HDE
        ElseIf frmMain.cmbHat.SelectedItem = "Lil' Elf Hat" Then
            '172
            Hat(0) = &HAC
        ElseIf frmMain.cmbHat.SelectedItem = "Lil Devil" Then
            '25
            Hat(0) = &H19
        ElseIf frmMain.cmbHat.SelectedItem = "Lilypad Hat" Then
            '136
            Hat(0) = &H88
        ElseIf frmMain.cmbHat.SelectedItem = "Mariachi Hat" Then
            '53
            Hat(0) = &H35
        ElseIf frmMain.cmbHat.SelectedItem = "Medic Hat" Then
            '179
            Hat(0) = &HB3
        ElseIf frmMain.cmbHat.SelectedItem = "Melon Hat" Then
            '180
            Hat(0) = &HB4
        ElseIf frmMain.cmbHat.SelectedItem = "Metal Fin Hat" Then
            '192
            Hat(0) = &HC0
        ElseIf frmMain.cmbHat.SelectedItem = "Miner Hat" Then
            '4
            Hat(0) = &H4
        ElseIf frmMain.cmbHat.SelectedItem = "Miniature Skylands Hat" Then
            '229
            Hat(0) = &HE5
        ElseIf frmMain.cmbHat.SelectedItem = "Molekin Mountain Hat" Then
            '250
            Hat(0) = &HFA
        ElseIf frmMain.cmbHat.SelectedItem = "Monday Hat" Then
            '199
            Hat(0) = &HC7
        ElseIf frmMain.cmbHat.SelectedItem = "Moose Hat" Then
            '31
            Hat(0) = &H1F
        ElseIf frmMain.cmbHat.SelectedItem = "Mountie Hat" Then
            '181
            Hat(0) = &HB5
        ElseIf frmMain.cmbHat.SelectedItem = "Napoleon Hat" Then
            '2
            Hat(0) = &H2
        ElseIf frmMain.cmbHat.SelectedItem = "Nefertiti Hat" Then
            '75
            Hat(0) = &H4B
        ElseIf frmMain.cmbHat.SelectedItem = "Night Cap" Then
            '224
            Hat(0) = &HE0
        ElseIf frmMain.cmbHat.SelectedItem = "Nurse Hat" Then
            '182
            Hat(0) = &HB6
        ElseIf frmMain.cmbHat.SelectedItem = "Obsidian Helm" Then
            '135
            Hat(0) = &H87
        ElseIf frmMain.cmbHat.SelectedItem = "Octavius Cloptimus Hat" Then
            '253
            Hat(0) = &HFD
        ElseIf frmMain.cmbHat.SelectedItem = "Officer Hat" Then
            '49
            Hat(0) = &H31
        ElseIf frmMain.cmbHat.SelectedItem = "Old-Time Movie Hat" Then
            '186
            Hat(0) = &HBA
        ElseIf frmMain.cmbHat.SelectedItem = "Outback Hat" Then
            '171
            Hat(0) = &HAB
        ElseIf frmMain.cmbHat.SelectedItem = "Palm Hat" Then
            '183
            Hat(0) = &HB7
        ElseIf frmMain.cmbHat.SelectedItem = "Pan Hat" Then
            '33
            Hat(0) = &H21
        ElseIf frmMain.cmbHat.SelectedItem = "Pants Hat" Then
            '77
            Hat(0) = &H4D
        ElseIf frmMain.cmbHat.SelectedItem = "Paper Fast Food Hat" Then
            '55
            Hat(0) = &H37
        ElseIf frmMain.cmbHat.SelectedItem = "Paperboy Hat" Then
            '184
            Hat(0) = &HB8
        ElseIf frmMain.cmbHat.SelectedItem = "Parrot Nest" Then
            '185
            Hat(0) = &HB9
        ElseIf frmMain.cmbHat.SelectedItem = "Peacock Hat" Then
            '111
            Hat(0) = &H6F
        ElseIf frmMain.cmbHat.SelectedItem = "Pilgrim Hat" Then
            '56
            Hat(0) = &H38
        ElseIf frmMain.cmbHat.SelectedItem = "Pirate Doo Rag" Then
            '41
            Hat(0) = &H29
        ElseIf frmMain.cmbHat.SelectedItem = "Pirate Hat" Then
            '6
            Hat(0) = &H6
        ElseIf frmMain.cmbHat.SelectedItem = "Planet Hat" Then
            '236
            Hat(0) = &HEC
        ElseIf frmMain.cmbHat.SelectedItem = "Plunger Head" Then
            '32
            Hat(0) = &H20
        ElseIf frmMain.cmbHat.SelectedItem = "Police Siren Hat" Then
            '57
            Hat(0) = &H39
        ElseIf frmMain.cmbHat.SelectedItem = "Pork Pie Hat" Then
            '210
            Hat(0) = &HD2
        ElseIf frmMain.cmbHat.SelectedItem = "Princess Hat" Then
            '78
            Hat(0) = &H4E
        ElseIf frmMain.cmbHat.SelectedItem = "Propeller Hat" Then
            '7
            Hat(0) = &H7
        ElseIf frmMain.cmbHat.SelectedItem = "Puma Hat" Then
            '143
            Hat(0) = &H8F
        ElseIf frmMain.cmbHat.SelectedItem = "Pumpkin Hat" Then
            '40
            Hat(0) = &H28
        ElseIf frmMain.cmbHat.SelectedItem = "Purple Fedora" Then
            '58
            Hat(0) = &H3A
        ElseIf frmMain.cmbHat.SelectedItem = "Pyramid Hat" Then
            '228
            Hat(0) = &HE4
        ElseIf frmMain.cmbHat.SelectedItem = "Radar Hat" Then
            '188
            Hat(0) = &HBC
        ElseIf frmMain.cmbHat.SelectedItem = "Rainbow Hat" Then
            '216
            Hat(0) = &HD8
        ElseIf frmMain.cmbHat.SelectedItem = "Rain Hat" Then
            '97
            Hat(0) = &H61
        ElseIf frmMain.cmbHat.SelectedItem = "Rasta Hat" Then
            '90
            Hat(0) = &H5A
        ElseIf frmMain.cmbHat.SelectedItem = "Rocker Hair" Then
            '23
            Hat(0) = &H17
        ElseIf frmMain.cmbHat.SelectedItem = "Rocket Hat" Then
            '34
            Hat(0) = &H22
        ElseIf frmMain.cmbHat.SelectedItem = "Roundlet" Then
            '108
            Hat(0) = &H6C
        ElseIf frmMain.cmbHat.SelectedItem = "Royal Crown" Then
            '24
            Hat(0) = &H18
        ElseIf frmMain.cmbHat.SelectedItem = "Rubber Glove Hat" Then
            '190
            Hat(0) = &HBE
        ElseIf frmMain.cmbHat.SelectedItem = "Rude Boy Hat" Then
            '209
            Hat(0) = &HD1
        ElseIf frmMain.cmbHat.SelectedItem = "Rugby Hat" Then
            '191
            Hat(0) = &HBF
        ElseIf frmMain.cmbHat.SelectedItem = "Runic Headband" Then
            '138
            Hat(0) = &H8A
        ElseIf frmMain.cmbHat.SelectedItem = "Safari Hat" Then
            '61
            Hat(0) = &H3D
        ElseIf frmMain.cmbHat.SelectedItem = "Sailor Hat" Then
            '62
            Hat(0) = &H3E
        ElseIf frmMain.cmbHat.SelectedItem = "Santa Hat" Then
            '35
            Hat(0) = &H23
        ElseIf frmMain.cmbHat.SelectedItem = "Sawblade Hat" Then
            '105
            Hat(0) = &H69
        ElseIf frmMain.cmbHat.SelectedItem = "Scooter Hat" Then
            '204
            Hat(0) = &HCC
        ElseIf frmMain.cmbHat.SelectedItem = "Scrumshanks Hat" Then
            '86
            Hat(0) = &H56
        ElseIf frmMain.cmbHat.SelectedItem = "Shadow Ghost Hat" Then
            '221
            Hat(0) = &HDD
        ElseIf frmMain.cmbHat.SelectedItem = "Shark Hat" Then
            '128
            Hat(0) = &H80
        ElseIf frmMain.cmbHat.SelectedItem = "Sherpa Hat" Then
            '200
            Hat(0) = &HC8
        ElseIf frmMain.cmbHat.SelectedItem = "Shower Cap" Then
            '194
            Hat(0) = &HC2
        ElseIf frmMain.cmbHat.SelectedItem = "Showtime Hat" Then
            '82
            Hat(0) = &H52
        ElseIf frmMain.cmbHat.SelectedItem = "Silver Arkeyan Helm" Then
            '239
            Hat(0) = &HEF
        ElseIf frmMain.cmbHat.SelectedItem = "Silver Top Hat" Then
            '95
            Hat(0) = &H5F
        ElseIf frmMain.cmbHat.SelectedItem = "Ski Cap" Then
            '114
            Hat(0) = &H72
        ElseIf frmMain.cmbHat.SelectedItem = "Skipper Hat" Then
            '243
            Hat(0) = &HF3
        ElseIf frmMain.cmbHat.SelectedItem = "Skullhelm" Then
            '141
            Hat(0) = &H8D
        ElseIf frmMain.cmbHat.SelectedItem = "Sleuth Hat" Then
            '193
            Hat(0) = &HC
        ElseIf frmMain.cmbHat.SelectedItem = "Sombrero" Then
            '89
            Hat(0) = &H59
        ElseIf frmMain.cmbHat.SelectedItem = "Space Helmet" Then
            '132
            Hat(0) = &H84
        ElseIf frmMain.cmbHat.SelectedItem = "Spiked Hat" Then
            '13
            Hat(0) = &HD
        ElseIf frmMain.cmbHat.SelectedItem = "Springtime Hat" Then
            '154
            Hat(0) = &H9A
        ElseIf frmMain.cmbHat.SelectedItem = "Spy Gear" Then
            '3
            Hat(0) = &H3
        ElseIf frmMain.cmbHat.SelectedItem = "Steampunk Hat" Then
            '197
            Hat(0) = &HC5
        ElseIf frmMain.cmbHat.SelectedItem = "Stone Hat" Then
            '102
            Hat(0) = &H66
        ElseIf frmMain.cmbHat.SelectedItem = "Storm Hat" Then
            '225
            Hat(0) = &HE1
        ElseIf frmMain.cmbHat.SelectedItem = "Stovepipe Hat" Then
            '103
            Hat(0) = &H67
        ElseIf frmMain.cmbHat.SelectedItem = "Straw Hat" Then
            '9
            Hat(0) = &H9
        ElseIf frmMain.cmbHat.SelectedItem = "Synchronized Swimming Cap" Then
            '206
            Hat(0) = &HCE
        ElseIf frmMain.cmbHat.SelectedItem = "Teeth Top Hat" Then
            '146
            Hat(0) = &H92
        ElseIf frmMain.cmbHat.SelectedItem = "The Outsider" Then
            '98
            Hat(0) = &H62
        ElseIf frmMain.cmbHat.SelectedItem = "Tiger Skin Cap" Then
            '145
            Hat(0) = &H91
        ElseIf frmMain.cmbHat.SelectedItem = "Tiki Hat" Then
            '36
            Hat(0) = &H24
        ElseIf frmMain.cmbHat.SelectedItem = "Tin Foil Hat" Then
            '223
            Hat(0) = &HDF
        ElseIf frmMain.cmbHat.SelectedItem = "Top Hat" Then
            '11
            Hat(0) = &HB
        ElseIf frmMain.cmbHat.SelectedItem = "Toucan Hat" Then
            '227
            Hat(0) = &HE3
        ElseIf frmMain.cmbHat.SelectedItem = "Toy Soldier Hat" Then
            '79
            Hat(0) = &H4F
        ElseIf frmMain.cmbHat.SelectedItem = "Traffic Cone Hat" Then
            '65
            Hat(0) = &H41
        ElseIf frmMain.cmbHat.SelectedItem = "Trash Lid" Then
            '201
            Hat(0) = &HC9
        ElseIf frmMain.cmbHat.SelectedItem = "Tree Branch" Then
            '119
            Hat(0) = &H77
        ElseIf frmMain.cmbHat.SelectedItem = "Tribal Hat" Then
            '208
            Hat(0) = &HD0
        ElseIf frmMain.cmbHat.SelectedItem = "Tricorn Hat" Then
            '110
            Hat(0) = &H6E
        ElseIf frmMain.cmbHat.SelectedItem = "Trojan Helmet" Then
            '37
            Hat(0) = &H25
        ElseIf frmMain.cmbHat.SelectedItem = "Tropical Turban" Then
            '20
            Hat(0) = &H14
        ElseIf frmMain.cmbHat.SelectedItem = "Trucker Hat" Then
            '80
            Hat(0) = &H50
        ElseIf frmMain.cmbHat.SelectedItem = "Turban" Then
            '66
            Hat(0) = &H42
        ElseIf frmMain.cmbHat.SelectedItem = "Turkey Hat" Then
            '147
            Hat(0) = &H93
        ElseIf frmMain.cmbHat.SelectedItem = "Turtle Hat" Then
            '202
            Hat(0) = &HCA
        ElseIf frmMain.cmbHat.SelectedItem = "UFO Hat" Then
            '133
            Hat(0) = &H85
        ElseIf frmMain.cmbHat.SelectedItem = "Umbrella Hat" Then
            '81
            Hat(0) = &H51
        ElseIf frmMain.cmbHat.SelectedItem = "Unicorn Hat" Then
            '38
            Hat(0) = &H26
        ElseIf frmMain.cmbHat.SelectedItem = "Viking Helmet" Then
            '12
            Hat(0) = &HC
        ElseIf frmMain.cmbHat.SelectedItem = "Vintage Baseball Cap" Then
            '46
            Hat(0) = &H2E
        ElseIf frmMain.cmbHat.SelectedItem = "Volcano Hat" Then
            '100
            Hat(0) = &H64
        ElseIf frmMain.cmbHat.SelectedItem = "Volcano Island Hat" Then
            '205
            Hat(0) = &HCD
        ElseIf frmMain.cmbHat.SelectedItem = "Wabbit Ears" Then
            '19
            Hat(0) = &H13
        ElseIf frmMain.cmbHat.SelectedItem = "Weather Vane Hat" Then
            '215
            Hat(0) = &HD7
        ElseIf frmMain.cmbHat.SelectedItem = "Whirlwind Diadem" Then
            '134
            Hat(0) = &H86
        ElseIf frmMain.cmbHat.SelectedItem = "William Tell Hat" Then
            '207
            Hat(0) = &HCF
        ElseIf frmMain.cmbHat.SelectedItem = "Winged Hat" Then
            '30
            Hat(0) = &H1E
        ElseIf frmMain.cmbHat.SelectedItem = "Wizard Hat" Then
            '39
            Hat(0) = &H27
        ElseIf frmMain.cmbHat.SelectedItem = "Zombeanie" Then
            '106
            Hat(0) = &H6A
            'We do Supercahrgers hats here instead of keeping it alphebitical
        ElseIf frmMain.cmbHat.SelectedItem = "Burn-Cycle Header" Then
            '261-255
            '6
            Hat(0) = &HFF
            Hat(1) = &H6
        ElseIf frmMain.cmbHat.SelectedItem = "Buzz Wing Hat" Then
            '271-255
            '16
            Hat(0) = &HFF
            Hat(1) = &H10
        ElseIf frmMain.cmbHat.SelectedItem = "Crypt Crusher Cap" Then
            '276-255
            '21
            Hat(0) = &HFF
            Hat(1) = &H15
        ElseIf frmMain.cmbHat.SelectedItem = "Dive Bomber Hat" Then
            '259-255
            '4
            Hat(0) = &HFF
            Hat(1) = &H4
        ElseIf frmMain.cmbHat.SelectedItem = "Eon’s Helm" Then
            '279-255
            '24
            Hat(0) = &HFF
            Hat(1) = &H18
        ElseIf frmMain.cmbHat.SelectedItem = "Gold Rusher Cog Cap" Then ', 268
            '268-255
            '13
            Hat(0) = &HFF
            Hat(1) = &HD
        ElseIf frmMain.cmbHat.SelectedItem = "Hot Streak Headpiece" Then ', 274
            '274-255
            '19
            Hat(0) = &HFF
            Hat(1) = &H13
        ElseIf frmMain.cmbHat.SelectedItem = "Kaos Krown" Then
            '278-255
            '23
            Hat(0) = &HFF
            Hat(1) = &H17
        ElseIf frmMain.cmbHat.SelectedItem = "Mags Hat" Then
            '277-255
            '22
            Hat(0) = &HFF
            Hat(1) = &H16
        ElseIf frmMain.cmbHat.SelectedItem = "Jet Stream Helmet" Then ', 263
            '263-255
            '8
            Hat(0) = &HFF
            Hat(1) = &H8
        ElseIf frmMain.cmbHat.SelectedItem = "Reef Ripper Helmet" Then ', 262
            '262-255
            '7
            Hat(0) = &HFF
            Hat(1) = &H7
        ElseIf frmMain.cmbHat.SelectedItem = "Sea Shadow Hat" Then
            '260-255
            '5
            Hat(0) = &HFF
            Hat(1) = &H5
        ElseIf frmMain.cmbHat.SelectedItem = "Shark Tank Topper" Then
            '267-255
            '12
            Hat(0) = &HFF
            Hat(1) = &HC
        ElseIf frmMain.cmbHat.SelectedItem = "Shield Striker Helmet" Then
            '272-255
            '17
            Hat(0) = &HFF
            Hat(1) = &H11
        ElseIf frmMain.cmbHat.SelectedItem = "Sky Slicer Hat" Then
            '275-255
            '20
            Hat(0) = &HFF
            Hat(1) = &H14
        ElseIf frmMain.cmbHat.SelectedItem = "Soda Skimmer Shower Cap" Then ', 264
            '264-255
            '9
            Hat(0) = &HFF
            Hat(1) = &H9
        ElseIf frmMain.cmbHat.SelectedItem = "Splatter Splasher Spires" Then ', 269
            '269-255
            '14
            Hat(0) = &HFF
            Hat(1) = &HE
        ElseIf frmMain.cmbHat.SelectedItem = "Stealth Stinger Beanie" Then ', 266
            '266-255
            '11
            Hat(0) = &HFF
            Hat(1) = &HB
        ElseIf frmMain.cmbHat.SelectedItem = "Sun Runner Spikes" Then ', 273
            '273-255
            '18
            Hat(0) = &HFF
            Hat(1) = &H12
        ElseIf frmMain.cmbHat.SelectedItem = "Thump Trucker’s Hat" Then ', 270
            '270-255
            '15
            Hat(0) = &HFF
            Hat(1) = &HF
        ElseIf frmMain.cmbHat.SelectedItem = "Tomb Buggy Skullcap" Then
            '265-255
            '10
            Hat(0) = &HFF
            Hat(1) = &HA
        ElseIf frmMain.cmbHat.SelectedItem.ToString.StartsWith("--") Then
            frmMain.cmbHat.SelectedIndex += 1
        Else
            MessageBox.Show("Hat Error.")
        End If
        'MessageBox.Show(Hat(0))
    End Sub
End Class