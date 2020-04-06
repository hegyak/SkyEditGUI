Imports System.IO

Public Class Extra
    Sub ParseExtra()
        Dim Reader As StreamReader = New StreamReader("Clean Extra.txt")
        Dim Writer As StreamWriter = New StreamWriter("Mod Extra.txt")
        Dim Ending As String
        Dim Full As String
        Dim Start As String
        Dim End1 As String
        Dim End2 As String
        Do Until Reader.Peek = -1
            Full = Reader.ReadLine
            Ending = Full.Remove(0, Full.Length - 4)
            'MessageBox.Show(Ending)
            'I need to Split and reverse Ending based on Byte.
            End1 = Ending.Remove(2, 2)
            'MessageBox.Show(End1)
            End2 = Ending.Remove(0, 2)
            'MessageBox.Show(End2)
            'MessageBox.Show(End2 & End1)
            Start = Full.Remove(Full.Length - 4, 4)
            'MessageBox.Show(Start)
            Writer.WriteLine(Start & End2 & End1)
        Loop
        Reader.Close()
        Writer.Flush()
        Writer.Close()
    End Sub
    Sub FurtherParseExtra()
        Dim Reader As StreamReader = New StreamReader("Mod Extra.txt")
        Dim Writer As StreamWriter = New StreamWriter("Mod EX.txt")
        Dim Line As String
        Do Until Reader.Peek = -1
            Line = Reader.ReadLine
            If Line.StartsWith("AIR ") Then
                Line = Line.Remove(0, 4)
            ElseIf Line.StartsWith("EARTH ") Then
                Line = Line.Remove(0, 6)
            ElseIf Line.StartsWith("FIRE ") Then
                Line = Line.Remove(0, 5)
            ElseIf Line.StartsWith("LIFE ") Then
                Line = Line.Remove(0, 5)
            ElseIf Line.StartsWith("LIGHT ") Then
                Line = Line.Remove(0, 6)
            ElseIf Line.StartsWith("MAGIC ") Then
                Line = Line.Remove(0, 6)
            ElseIf Line.StartsWith("TECH ") Then
                Line = Line.Remove(0, 5)
            ElseIf Line.StartsWith("UNDEAD ") Then
                Line = Line.Remove(0, 7)
            ElseIf Line.StartsWith("VILLAIN ") Then
                Line = Line.Remove(0, 8)
            ElseIf Line.StartsWith("WATER ") Then
                Line = Line.Remove(0, 6)
            Else
            End If
            Writer.WriteLine(Line)
        Loop
        Reader.Close()
        Writer.Flush()
        Writer.Close()
    End Sub
    Sub HardestParsingExtra()
        Dim Reader As StreamReader = New StreamReader("Mod Uber.txt")
        'Dim Writer As StreamWriter = New StreamWriter("Mod Uber.txt")
        Dim Caser As StreamWriter = New StreamWriter("Case.txt")
        Dim Line As String
        Dim ID As String
        Dim Name As String
        Dim Alt As String
        Dim arrID(99999) As String
        Dim ArrAlt(99999) As String
        Dim ArrName(99999) As String
        Dim Counter As Double = 0
        Dim NewerCounter As Double = 0
        Do Until Reader.Peek = -1
            Line = Reader.ReadLine
            Name = Line.Remove(0, 10)
            'MessageBox.Show(Name)
            ID = Line.Remove(4, Name.Length + 6)
            'ID = ID.Remove(5, 5)
            'MessageBox.Show(ID)
            Alt = Line.Remove(9, Name.Length + 1)
            Alt = Alt.Remove(0, 5)

            'MessageBox.Show(Alt)
            'Writer.WriteLine(Line)
            'Writer.WriteLine(ID & ":" & Alt & ":" & Name)
            arrID(Counter) = ID
            ArrAlt(Counter) = Alt
            ArrName(Counter) = Name
            Counter += 1
        Loop
        Reader.Close()
        'Writer.Flush()
        'Writer.Close()
        'I want to write these lines:
        'Case "0000"
        'If Var = "0000" Then
        ''txtToy.Text = "Whirlwind"                      '0000|0030|regular|air
        'ElseIf Var = "0118" Then
        ''txtToy.Text = "SERIES 2 WHIRLWIND"
        'ElseIf Var = "021C" Then
        ''txtToy.Text = "POLAR WHIRLWIND"
        'ElseIf Var = "0528" Then
        ''txtToy.Text = "HORN BLAST WHIRLWIND"
        'End If
        Dim NewID As String
        Dim Alter As Boolean = False
        Dim OrgName As String
        Dim Adder As Integer = 0
        Do Until NewerCounter > Counter
            Adder = 0
            Caser.WriteLine("Case " & Chr(34) & arrID(NewerCounter) & Chr(34))
            Caser.WriteLine("If Var = " & Chr(34) & ArrAlt(NewerCounter) & Chr(34))
            Caser.WriteLine("'txtToy.Text = " & Chr(34) & ArrName(NewerCounter) & Chr(34))
            OrgName = ArrName(NewerCounter)
            NewID = arrID(NewerCounter + 1)
            If NewID = arrID(NewerCounter) Then
                Caser.WriteLine("Elseif Var = " & Chr(34) & ArrAlt(NewerCounter + 1) & Chr(34) & " Then")
                Caser.WriteLine("'txtToy.text = " & Chr(34) & ArrName(NewerCounter + 1) & Chr(34))
                NewerCounter = NewerCounter + 1
                NewID = arrID(NewerCounter)
                Alter = True
            End If
            If Alter = True Then
                Alter = False
                Caser.WriteLine("Else ")
                Caser.WriteLine("'txtToy.text = " & Chr(34) & "Unknown Variant of " & OrgName & Chr(34))
            End If
            Caser.WriteLine("End IF")
            NewerCounter += 1
        Loop

        Caser.Flush()
        Caser.Close()
    End Sub
    Sub ExtremeCase()
        Dim Fig As String = "Dad"
        Dim Var As String = "Mom"

    End Sub

    Sub Old()

        Dim Var As String = "Hey"
        Select Case Var
            Case "0000"
                'lblVarGen.Text = "Adventures"
                Exit Select
            Case "0010"
                'lblVarGen.Text = "Giants"
                Exit Select
            Case "0020"
                'lblVarGen.Text = "Swap Force"
                Exit Select
            Case "0030"
                'lblVarGen.Text = "Trap Team"
                Exit Select
            Case "0040"
                'lblVarGen.Text = "Super Chargers"
                Exit Select
            Case "0050"
                'lblVarGen.Text = "Imaginators"
                Exit Select
            Case "0118"
                'lblVarGen.Text = "Series 2"
                Exit Select
            Case "0602"
                'lblVarGen.Text = "Adventures LightCore"
                Exit Select
            Case "0612"
                'lblVarGen.Text = "Giants LightCore"
                Exit Select
            Case "0622"
                'lblVarGen.Text = "Swap Force LightCore"
                Exit Select
            Case "0632"
                'lblVarGen.Text = "Trap Team LightCore"
                Exit Select
            Case "0642"
                'lblVarGen.Text = "Super Chargers LightCore "
                Exit Select
            Case "0652"
                'lblVarGen.Text = "Imaginators LightCore"
                Exit Select
            Case "0226"
                'lblVarGen.Text = "Swap Force Enchanted Star Strike Lightcore"
                Exit Select
            Case Else
                ''lblVarGen.Text = "0X" & B(0).ToString("X2") & B(1).ToString("X2")
                'MessageBox.Show("Hex")
        End Select
        Dim Fig As String = "Hey"
        'MessageBox.Show(Fig)
        Select Case Fig
            Case "0000"
                If Var = "0000" Then
                    'txtToy.Text = "Whirlwind"                      '0000|0030|regular|air
                ElseIf Var = "0118" Then
                    'txtToy.Text = "SERIES 2 WHIRLWIND"
                ElseIf Var = "021C" Then
                    'txtToy.Text = "POLAR WHIRLWIND"
                ElseIf Var = "0528" Then
                    'txtToy.Text = "HORN BLAST WHIRLWIND"
                End If
            Case "0001"
                'txtToy.Text = "Sonic Boom"                     '0100|0030|regular|air
            Case 2
                'txtToy.Text = "Warnado"                        '0200|0030|regular|air
            Case 3
                'txtToy.Text = "Lightning Rod"                  '0300|0030|regular|air
            Case 4
                'txtToy.Text = "Bash"                           '0400|0030|regular|earth
            Case 5
                'txtToy.Text = "Terrafin"                       '0500|0030|regular|earth
            Case 6
                'txtToy.Text = "Dino-Rang"                      '0600|0030|regular|earth
            Case 7
                'txtToy.Text = "Prism Break"                    '0700|0030|regular|earth
            Case 8
                'txtToy.Text = "Sunburn"                        '0800|0030|regular|fire
            Case 9
                'txtToy.Text = "Eruptor"                        '0900|0030|regular|fire
            Case "000A"
                'txtToy.Text = "Ignitor"                       '0a00|0030|regular|fire
            Case 11
                'txtToy.Text = "Flameslinger"                  '0b00|0030|regular|fire
            Case 12
                'txtToy.Text = "Zap"                           '0c00|0030|regular|water
            Case 13
                'txtToy.Text = "Wham-Shell"                    '0d00|0030|regular|water
            Case 14
                'txtToy.Text = "Gill Grunt"                    '0e00|0030|regular|water
            Case 15
                'txtToy.Text = "Slam Bam"                      '0f00|0030|regular|water
            Case 16
                'txtToy.Text = "Spyro"                         '1000|0030|regular|magic
            Case 17
                'txtToy.Text = "Voodood"                       '1100|0030|regular|magic
            Case 18
                'txtToy.Text = "Double Trouble"                '1200|0030|regular|magic
            Case 19
                'txtToy.Text = "Trigger Happy"                 '1300|0030|regular|tech
            Case 20
                'txtToy.Text = "Drobot"                        '1400|0030|regular|tech
            Case 21
                'txtToy.Text = "Drill Sergeant"                '1500|0030|regular|tech
            Case 22
                'txtToy.Text = "Boomer"                        '1600|0030|regular|tech
            Case 23
                'txtToy.Text = "Wrecking Ball"                 '1700|0030|regular|magic
            Case 24
                'txtToy.Text = "Camo"                          '1800|0030|regular|life
            Case 25
                'txtToy.Text = "Zook"                          '1900|0030|regular|life
            Case 26
                'txtToy.Text = "Stealth Elf"                   '1a00|0030|regular|life
            Case 27
                'txtToy.Text = "Stump Smash"                   '1b00|0030|regular|life
            Case 28
                'txtToy.Text = "Dark Spyro"                    '1c00|0030|regular|magic
            Case 29
                'txtToy.Text = "Hex"                           '1d00|0030|regular|undead
            Case 30
                'txtToy.Text = "Chop Chop"                     '1e00|0030|regular|undead
            Case 31
                'txtToy.Text = "Ghost Roaster"                 '1f00|0030|regular|undead
            Case "0020"
                'txtToy.Text = "Cynder"                        '2000|0030|regular|undead
            Case 100
                'txtToy.Text = "Jet Vac"                      '6400|0030|regular|air
            Case 101
                'txtToy.Text = "Swarm"                        '6500|0030|giant|air
            Case 102
                'txtToy.Text = "Crusher"                      '6600|0030|giant|earth
            Case 103
                'txtToy.Text = "Flashwing"                    '6700|0030|regular|earth
            Case 104
                'txtToy.Text = "Hot Head"                     '6800|0030|giant|fire
            Case 105
                'txtToy.Text = "Hot Dog"                      '6900|0030|regular|fire
            Case 106
                'txtToy.Text = "Chill"                        '6a00|0030|regular|water
            Case 107
                'txtToy.Text = "Thumpback"                    '6b00|0030|giant|water
            Case 108
                'txtToy.Text = "Pop Fizz"                     '6c00|0030|regular|magic
            Case 109
                'txtToy.Text = "Ninjini"                      '6d00|0030|giant|magic
            Case 110
                'txtToy.Text = "Bouncer"                      '6e00|0030|giant|tech
            Case 111
                'txtToy.Text = "Sprocket"                     '6f00|0030|regular|tech
            Case 112
                'txtToy.Text = "Tree Rex"                     '7000|0030|giant|life
            Case 113
                'txtToy.Text = "Shroomboom"                   '7100|0030|regular|life
            Case 114
                'txtToy.Text = "Eye-Brawl"                    '7200|0030|giant|undead
            Case 115
                'txtToy.Text = "Fright Rider"                 '7300|0030|regular|undead
            Case 200
                'txtToy.Text = "Anvil Rain"                   'c800|0030|item|none
            Case 201
                'txtToy.Text = "Treasure Chest"               'c900|0030|item|none
            Case 202
                'txtToy.Text = "Healing Elixer"               'ca00|0030|item|none
            Case 203
                'txtToy.Text = "Ghost Swords"                 'cb00|0030|item|none
            Case 204
                'txtToy.Text = "Time Twister"                 'cc00|0030|item|none
            Case 205
                'txtToy.Text = "Sky-Iron Shield"              'cd00|0030|item|none
            Case 206
                'txtToy.Text = "Winged Boots"                 'ce00|0030|item|none
            Case 207
                'txtToy.Text = "Sparx Dragonfly"              'cf00|0030|item|none
            Case 208
                'txtToy.Text = "Dragonfire Cannon"            'd000|0030|item|none
            Case 209
                'txtToy.Text = "Scorpion Striker Catapult"    'd100|0030|item|none
            Case 230
                'txtToy.Text = "Hand Of Fate"                 'e600|0030|item|none
            Case 231
                'txtToy.Text = "Piggy Bank"                   'e700|0030|item|none
            Case 232
                'txtToy.Text = "Rocket Ram"                   'e800|0030|item|none
            Case 233
                'txtToy.Text = "Tiki Speaky"                  'e900|0030|item|none
            Case 300
                'txtToy.Text = "Dragons Peak"                 '2c01|0030|location|none
            Case 301
                'txtToy.Text = "Empire of Ice"                '2d01|0030|location|none
            Case 302
                'txtToy.Text = "Pirate Seas"                  '2e01|0030|location|none
            Case 303
                'txtToy.Text = "Darklight Crypt"              '2f01|0030|location|none
            Case 304
                'txtToy.Text = "Volcanic Vault"               '3001|0030|location|none
            Case 305
                'txtToy.Text = "Mirror Of Mystery"            '3101|0030|location|none
            Case 306
                'txtToy.Text = "Nightmare Express"            '3201|0030|location|none
            Case 307
                'txtToy.Text = "Sunscraper Spire"             '3301|0030|location|light
            Case 308
                'txtToy.Text = "Midnight Museum"              '3401|0030|location|dark
            Case 404
                'txtToy.Text = "Bash"                         '9401|0030|legendary|earth
            Case 416
                'txtToy.Text = "Spyro"                        'a001|0030|legendary|magic
            Case 419
                'txtToy.Text = "Trigger Happy"                'a301|0030|legendary|tech
            Case 430
                'txtToy.Text = "Chop Chop"                    'ae01|0030|legendary|undead
            Case 450
                'txtToy.Text = "Gusto"                        'c201|0030|trapmaster|air
            Case 451
                'txtToy.Text = "Thunderbolt"                  'c301|0030|trapmaster|air
            Case 452
                'txtToy.Text = "Fling Kong"                   'c401|0030|regular|air
            Case 453
                'txtToy.Text = "Blades"                       'c501|0030|regular|air
            Case 454
                'txtToy.Text = "Wallop"                       'c601|0030|trapmaster|earth
            Case 455
                'txtToy.Text = "Head Rush"                    'c701|0030|trapmaster|earth
            Case 456
                'txtToy.Text = "Fist Bump"                    'c801|0030|regular|earth
            Case 457
                'txtToy.Text = "Rocky Roll"                   'c901|0030|regular|earth
            Case 458
                'txtToy.Text = "Wildfire"                     'ca01|0030|trapmaster|fire
            Case 459
                'txtToy.Text = "Ka Boom"                      'cb01|0030|trapmaster|fire
            Case 460
                'txtToy.Text = "Trail Blazer"                 'cc01|0030|regular|fire
            Case 461
                'txtToy.Text = "Torch"                        'cd01|0030|regular|fire
            Case 462
                'txtToy.Text = "Snap Shot"                    'ce01|0030|trapmaster|water
            Case 463
                'txtToy.Text = "Lob Star"                     'cf01|0030|trapmaster|water
            Case 464
                'txtToy.Text = "Flip Wreck"                   'd001|0030|regular|water
            Case 465
                'txtToy.Text = "Echo"                         'd101|0030|regular|water
            Case 466
                'txtToy.Text = "Blastermind"                  'd201|0030|trapmaster|magic
            Case 467
                'txtToy.Text = "Enigma"                       'd301|0030|trapmaster|magic
            Case 468
                'txtToy.Text = "Deja Vu"                      'd401|0030|regular|magic
            Case 469
                'txtToy.Text = "Cobra Cadabra"                'd501|0030|regular|magic
            Case 470
                'txtToy.Text = "Jawbreaker"                   'd601|0030|trapmaster|tech
            Case 471
                'txtToy.Text = "Gearshift"                    'd701|0030|trapmaster|tech
            Case 472
                'txtToy.Text = "Chopper"                      'd801|0030|regular|tech
            Case 473
                'txtToy.Text = "Tread Head"                   'd901|0030|regular|tech
            Case 474
                'txtToy.Text = "Bushwhack"                    'da01|0030|trapmaster|life
            Case 475
                'txtToy.Text = "Tuff Luck"                    'db01|0030|trapmaster|life
            Case 476
                'txtToy.Text = "Food Fight"                   'dc01|0030|regular|life
            Case 477
                'txtToy.Text = "High Five"                    'dd01|0030|regular|life
            Case 478
                'txtToy.Text = "Krypt King"                   'de01|0030|trapmaster|undead
            Case 479
                'txtToy.Text = "Short Cut"                    'df01|0030|trapmaster|undead
            Case 480
                'txtToy.Text = "Bat Spin"                     'e001|0030|regular|undead
            Case 481
                'txtToy.Text = "Funny Bone"                   'e101|0030|regular|undead
            Case 482
                'txtToy.Text = "Knight light"                 'e201|0030|trapmaster|light
            Case 483
                'txtToy.Text = "Spotlight"                    'e301|0030|regular|light
            Case 484
                'txtToy.Text = "Knight Mare"                  'e401|0030|trapmaster|dark
            Case 485
                'txtToy.Text = "Blackout"                     'e501|0030|regular|dark
            Case 502
                'txtToy.Text = "Bop"                          'f601|0030|mini|earth
            Case 503
                'txtToy.Text = "Spry"                         'f701|0030|mini|magic
            Case 504
                'txtToy.Text = "Hijinx"                       'f801|0030|mini|undead
            Case 505
                'txtToy.Text = "Terrabite"                    'f901|0030|mini|earth
            Case 506
                'txtToy.Text = "Breeze"                       'fa01|0030|mini|air
            Case 507
                'txtToy.Text = "Weeruptor"                    'fb01|0030|mini|fire
            Case 508
                'txtToy.Text = "Pet Vac"                      'fc01|0030|mini|air
            Case 509
                'txtToy.Text = "Small Fry"                    'fd01|0030|mini|fire
            Case 510
                'txtToy.Text = "Drobit"                       'fe01|0030|mini|tech
            Case 514
                'txtToy.Text = "Gill Runt"                    '0202|0030|mini|water
            Case 519
                'txtToy.Text = "Trigger Snappy"               '0702|0030|mini|tech
            Case 526
                'txtToy.Text = "Whisper Elf"                  '0e02|0030|mini|life
            Case 540
                'txtToy.Text = "Barkley"                      '1c02|0030|mini|life
            Case 541
                'txtToy.Text = "Thumpling"                    '1d02|0030|mini|water
            Case 542
                'txtToy.Text = "Mini Jini"                    '1e02|0030|mini|magic
            Case 543
                'txtToy.Text = "Eye Small"                    '1f02|0030|mini|undead
            Case 1004
                'txtToy.Text = "Blast Zone"                  '||swapforce|fire
            Case 1015
                'txtToy.Text = "Wash Buckler"                '||swapforce|water
            Case 2004
                'txtToy.Text = "Blast Zone (Head)"           '||swapforce|fire
            Case 2015
                'txtToy.Text = "Wash Buckler (Head)"         '||swapforce|water
            Case 3000
                'txtToy.Text = "Scratch"                     'b80b|0030|regular|air
            Case 3001
                'txtToy.Text = "Pop Thorn"                   'b90b|0030|regular|air
            Case 3002
                'txtToy.Text = "Slobber Tooth"               'ba0b|0030|regular|earth
            Case 3003
                'txtToy.Text = "Scorp"                       'bb0b|0030|regular|earth
            Case 3004
                'txtToy.Text = "Fryno"                       'bc0b|0030|regular|fire
            Case 3005
                'txtToy.Text = "Smolderdash"                 'bd0b|0030|regular|fire
            Case 3006
                'txtToy.Text = "Bumble Blast"                'be0b|0030|regular|life
            Case 3007
                'txtToy.Text = "Zoo Lou"                     'bf0b|0030|regular|life
            Case 3008
                'txtToy.Text = "Dune Bug"                    'c00b|0030|regular|magic
            Case 3009
                'txtToy.Text = "Star Strike"                 'c10b|0030|regular|magic
            Case 3010
                'txtToy.Text = "Countdown"                   'c20b|0030|regular|tech
            Case 3011
                'txtToy.Text = "Wind Up"                     'c30b|0030|regular|tech
            Case 3012
                'txtToy.Text = "Roller Brawl"                'c40b|0030|regular|undead
            Case 3013
                'txtToy.Text = "Grim Creeper"                'c50b|0030|regular|undead
            Case 3014
                'txtToy.Text = "Rip Tide"                    'c60b|0030|regular|water
            Case 3015
                'txtToy.Text = "Punk Shock"                  'c70b|0030|regular|water
        End Select
    End Sub
End Class
