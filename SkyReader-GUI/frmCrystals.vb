Imports SkyReader_GUI.FigureIO
Public Class frmCrystals
    Sub Save()
        Select Case cmbMold.SelectedItem
            Case "Beaded D20"
                Mold = &H10
            Case "Beaded Rosette"
                Mold = &H12
            Case "Beaded Soccer"
                Mold = &H11
            Case "Clawed Cone"
                Mold = &H1B
            Case "Clawed Egg"
                Mold = &H1A
            Case "Clawed Rosette"
                Mold = &H19
            Case "Crowned Cone"
                Mold = &H1D
            Case "Crowned Soccer"
                Mold = &H1C
            Case "Crowned Uncut"
                Mold = &H1E
            Case "Handled Cube"
                Mold = &H8
            Case "Handled D12"
                Mold = &H7
            Case "Handled Quartz"
                Mold = &H9
            Case "Mech D12"
                Mold = &HE
            Case "Mech D20"
                Mold = &HF
            Case "Mech Quartz"
                Mold = &HD
            Case "Plated Rosette"
                Mold = &H14
            Case "Plated Soccer"
                Mold = &H15
            Case "Plated Uncut"
                Mold = &H13
            Case "Pointed Cube"
                Mold = &H6
            Case "Pointed Egg"
                Mold = &H4
            Case "Pointed Pyramid"
                Mold = &H5
            Case "Rocky Cube"
                Mold = &H1F
            Case "Rocky D12"
                Mold = &HC
            Case "Rocky Pyramid"
                Mold = &HA
            Case "Rocky Quartz"
                Mold = &HB
            Case "Rooted D20"
                Mold = &H17
            Case "Rooted D6"
                Mold = &H16
            Case "Rooted Egg"
                Mold = &H18
            Case "Winged Cone"
                Mold = &H3
            Case "Winged Pyramid"
                Mold = &H1
            Case "Winged Uncut"
                Mold = &H2
        End Select
        Select Case cmbBattleClass.SelectedItem
            Case "Knight"
                Battlecast = &H1
            Case "Bowslinger"
                Battlecast = &H2
            Case "Quickshot"
                Battlecast = &H3
            Case "Ninja"
                Battlecast = &H4
            Case "Brawler"
                Battlecast = &H5
            Case "Smasher"
                Battlecast = &H6
            Case "Sorcerer"
                Battlecast = &H7
            Case "Swashbuckler"
                Battlecast = &H8
            Case "Sentinel"
                Battlecast = &H9
            Case "Bazooker"
                Battlecast = &HA
        End Select
        Select Case cmbHead.SelectedItem
            Case "Under Wraps"
                Head = &H1
            Case "Bug Shot"
                Head = &H2
            Case "Bobbed and Beautiful"
                Head = &H3
            Case "Black Knight Head"
                Head = &H4
            Case "Veggie Head"
                Head = &H5
            Case "Cawsome"
                Head = &H6
            Case "Helmet Hair"
                Head = &H7
            Case "Cool Cat"
                Head = &H8
            Case "Eye-Clops"
                Head = &H9
            Case "Miss Clockwork"
                Head = &HA
            Case "Squidbeard"
                Head = &HB
            Case "Fish Fatale"
                Head = &HC
            Case "No Sight No Problem"
                Head = &HD
            Case "Flame-ulous"
                Head = &HE
            Case "Brutebot"
                Head = &HF
            Case "Robolander"
                Head = &H10
            Case "Mr. Skull"
                Head = &H11
            Case "Hooded Mystery"
                Head = &H12
            Case "Monkey Business"
                Head = &H13
            Case "Witchy Ways"
                Head = &H14
            Case "Flynnteresting"
                Head = &H15
            Case "Chinstrap"
                Head = &H16
            Case "Bananana"
                Head = &H17
            Case "Fangtastic"
                Head = &H18
            Case "Familiar Face"
                Head = &H1A
            Case "Doomlackey"
                Head = &H1B
            Case "Tiki-Time"
                Head = &H1C
            Case "Imagi-tron 3000"
                Head = &H1D
            Case "Squid Kid"
                Head = &H1E
            Case "Bird Brain"
                Head = &H1F
            Case "Cyglobe"
                Head = &H20
            Case "Big Cheese"
                Head = &H21
            Case "Super Mask"
                Head = &H22
            Case "Boar Bash"
                Head = &H23
            Case "Shield Maiden Head"
                Head = &H24
            Case "Biclops"
                Head = &H25
            Case "Underbite"
                Head = &H26
            Case "Soldier Head"
                Head = &H27
            Case "Brainlander"
                Head = &H28
            Case "Cowboy Head"
                Head = &H29
            Case "Monsertious"
                Head = &H2A
            Case "Silverback"
                Head = &H2B
            Case "Sporeman"
                Head = &H2C
            Case "Sylvan"
                Head = &H2D
            Case "Expolorer Head"
                Head = &H2E
            Case "Lavabrain"
                Head = &H2F
            Case "Rex"
                Head = &H30
            Case "Turtle"
                Head = &H31
            Case "Retrobot"
                Head = &H32
            Case "Spark Head"
                Head = &H33
            Case "Amazonian Head"
                Head = &H34
            Case "Snapshot"
                Head = &H35
            Case "Tiger Head"
                Head = &H36
            Case "Spiky Hair Head"
                Head = &H37
            Case "Leafy Hair Head"
                Head = &H38
            Case "Flat Top Head"
                Head = &H39
            Case "Caesar Hair Head"
                Head = &H3A
            Case "Scruff"
                Head = &H3B
            Case "Doe Deer"
                Head = &H3C
            Case "Rocky"
                Head = &H3D
            Case "Nightwalker"
                Head = &H3E
            Case "Mr. Frost"
                Head = &H3F
            Case "Dino Head"
                Head = &H40
            Case "Rockets"
                Head = &H41
            Case "Squid Head"
                Head = &H42
            Case "Pirate Head"
                Head = &H43
            Case "Diver Head"
                Head = &H44
            Case "Chompy Head"
                Head = &H45
            Case "White Knight Head"
                Head = &H46
            Case "One Eye Head"
                Head = &H47
            Case "Gladiator Head"
                Head = &H48
            Case "Wasteland Head"
                Head = &H49
            Case "Faun Head"
                Head = &H4A
            Case "Seahorse Head"
                Head = &H4B
            Case "Wolf Head"
                Head = &H4C
            Case "Sparta Head"
                Head = &H4D
            Case "Equestrian Head"
                Head = &H4E
            Case "Firemask Head"
                Head = &H4F
            Case "Vernian Adventurer Head"
                Head = &H50
            Case "Elf Enchantress"
                Head = &H51
            Case "Blonde Streak Head"
                Head = &H52
            Case "Head Band Head"
                Head = &H53
            Case "Librarian Head"
                Head = &H54
            Case "Ninja Head"
                Head = &H55
            Case "Fossil Head"
                Head = &H56
            Case "Bunhead Head"
                Head = &H57
            Case "Bobbed Head"
                Head = &H58
            Case "Scarecrow Head"
                Head = &H59
            Case "Braided Head"
                Head = &H5A
            Case "Bull Head"
                Head = &H5B
            Case "Leaf Head"
                Head = &H5C
            Case "Fire Dancer Head"
                Head = &H5D
            Case "Robo Skull Head"
                Head = &H5E
            Case "Fish Monster Head"
                Head = &H5F
            Case "Cute Mammal Head"
                Head = &H60
            Case "Troll Head"
                Head = &H61
            Case "Crazy Head"
                Head = &H62
            Case "Monkey King Head"
                Head = &H63
            Case "Skele-Warrior Head"
                Head = &H64
            Case "Rock Helmet Head"
                Head = &H65
            Case "Dragon Head"
                Head = &H66
            Case "Mushroom Head"
                Head = &H67
            Case "Baby Dragon Head"
                Head = &H68
            Case "Ragdoll Head"
                Head = &H69
            Case "Spider Head"
                Head = &H6A
            Case "Insect Head"
                Head = &H6B
            Case "Pumpkin Head"
                Head = &H6C
            Case "Leaf Monster Head"
                Head = &H6D
            Case "Lightbulb Head"
                Head = &H6E
            Case "Baby Faced"
                Head = &H6F
            Case "Gargoyle Head"
                Head = &H70
            Case "Kabuki Head"
                Head = &H71
            Case "Sharp Toothed"
                Head = &H72
            Case "Painted Skull Head"
                Head = &H73
            Case "Gas Masked"
                Head = &H74
            Case "Cyborg Head"
                Head = &H75
            Case "Shaved Head"
                Head = &H76
            Case "Lucha Libre"
                Head = &H77
            Case "Ladybug Head"
                Head = &H78
            Case "Mustached Head"
                Head = &H79
            Case "Freckles Head"
                Head = &H7A
            Case "Orc Head"
                Head = &H7B
            Case "Elf Head"
                Head = &H7C
            Case "Professional Head"
                Head = &H7D
            Case "Hipster Head"
                Head = &H7E
            Case "Student Head"
                Head = &H7F
            Case "Burrbearian Head"
                Head = &H80
            Case "Reptilian Head"
                Head = &H81
            Case "Rhino Mask"
                Head = &H82
            Case "Petal Head"
                Head = &H83
            Case "Dryad Head"
                Head = &H84
            Case "Train Head"
                Head = &H85
            Case "Aztec Mask"
                Head = &H86
            Case "Feline Face"
                Head = &H87
            Case "Slime Head"
                Head = &H88
            Case "Chameleon Head"
                Head = &H89
            Case "Plane Head"
                Head = &H8A
            Case "Warrior Queen Head"
                Head = &H8B
            Case "Box Top"
                Head = &H8C
            Case "Snake Head"
                Head = &H8D
            Case "Night Owl Mask"
                Head = &H8E
            Case "Sheep Head"
                Head = &H8F
            Case "Masquerade Head"
                Head = &H90
            Case "Cybug Head"
                Head = &H91
            Case "Beetle Head"
                Head = &H92
            Case "Royal Guard Head"
                Head = &H93
            Case "Lion Fish Head"
                Head = &H94
            Case "Miner Head"
                Head = &H95
            Case "Idol Mask"
                Head = &H96
            Case "Diner Head"
                Head = &H97
            Case "Scuba Head"
                Head = &H98
            Case "Demon Spirit Head"
                Head = &H99
            Case "Grizly Head"
                Head = &H9A
            Case "Training Dummy Head"
                Head = &H9B
            Case "Shield Queen Head"
                Head = &H9C
            Case "Boom Box"
                Head = &H9D
            Case "Metal Skull Head"
                Head = &H9E
            Case "Rook Head"
                Head = &H9F
            Case "Sparkly Head"
                Head = &HA0
            Case "Half Bot Head"
                Head = &HA1
        End Select
        Select Case cmbEyes.SelectedItem
            Case "Default"
                Eyes = &H0
            Case "Cat"
                Eyes = &H1
            Case "Goat"
                Eyes = &H2
            Case "Human"
                Eyes = &H3
            Case "Monster"
                Eyes = &H4
            Case "Plain"
                Eyes = &H5
            Case "Pupil"
                Eyes = &H6
            Case "Target"
                Eyes = &H7
            Case "Bug"
                Eyes = &H8
            Case "Heart"
                Eyes = &H9
            Case "Spiral"
                Eyes = &HA
            Case "Robot"
                Eyes = &HB
            Case "Star"
                Eyes = &HC
            Case "Alien"
                Eyes = &HD
            Case "Iball"
                Eyes = &HE
            Case "Glowy"
                Eyes = &HF
        End Select
        Select Case cmbEars.SelectedItem
            Case "(None)"
                Ears = &H0
            Case "Elf Ears"
                Ears = &H1
            Case "Winged Ears"
                Ears = &H2
            Case "Spyro Horns"
                Ears = &H3
            Case "Fish Girl Ears"
                Ears = &H4
            Case "Dear Ring Ears"
                Ears = &H5
            Case "Cow Pierced"
                Ears = &H6
            Case "Troll Ears"
                Ears = &H7
            Case "Trumpet Ears"
                Ears = &H8
            Case "Pencil Ears"
                Ears = &H9
            Case "Ears of Corn"
                Ears = &HA
            Case "Magnet Ears"
                Ears = &HB
            Case "Ram Horn"
                Ears = &HC
            Case "Deer Antlers"
                Ears = &HD
            Case "Moose Antlers"
                Ears = &HE
            Case "Pigtails"
                Ears = &HF
            Case "Batty Ears"
                Ears = &H10
            Case "Rounded Ears"
                Ears = &H11
            Case "Antennae"
                Ears = &H12
            Case "Supersonic Ears"
                Ears = &H13
            Case "Jackal Ears"
                Ears = &H14
            Case "Deepglow Ears"
                Ears = &H15
            Case "Tentacles"
                Ears = &H16
            Case "Shell-o Ears"
                Ears = &H17
            Case "Pretty Fly Ears"
                Ears = &H18
            Case "Crystal Ears"
                Ears = &H19
            Case "Doomstein Ears"
                Ears = &H1A
            Case "Earmuffs"
                Ears = &H1B
            Case "Ears of Doom"
                Ears = &H1C
            Case "Scaled Ears"
                Ears = &H1D
            Case "Shiver Me Ears"
                Ears = &H1E
            Case "Squidly Ears"
                Ears = &H1F
            Case "Chompy Ears"
                Ears = &H20
            Case "Firebird Ears"
                Ears = &H21
            Case "Seahorse Ears"
                Ears = &H22
            Case "Faun Ears"
                Ears = &H23
            Case "Wolf Ears"
                Ears = &H24
            Case "Conbot Ears"
                Ears = &H25
            Case "Eyeballs Ears"
                Ears = &H26
            Case "Neo Cortex Ears"
                Ears = &H27
            Case "Ballerina Ears"
                Ears = &H28
            Case "Candy Ears"
                Ears = &H29
            Case "Scarecrow Ears"
                Ears = &H2A
            Case "Satellite Ears"
                Ears = &H2B
            Case "Antenna Ears"
                Ears = &H2C
            Case "Dog Ears"
                Ears = &H2D
            Case "Cat Ears"
                Ears = &H2E
            Case "Bear Ears"
                Ears = &H2F
            Case "Mouse Ears"
                Ears = &H30
            Case "Fire Dancer Ears"
                Ears = &H31
            Case "Plunger Ears"
                Ears = &H33
            Case "Bullhorn Ears"
                Ears = &H34
            Case "Cyborg Ears"
                Ears = &H35
            Case "Ladybug Earmuffs"
                Ears = &H36
            Case "Gargoyle Ears"
                Ears = &H37
            Case "Rhino Ears"
                Ears = &H38
            Case "Blossom Ears"
                Ears = &H39
            Case "Aztec Ears"
                Ears = &H3A
            Case "Plane Ears"
                Ears = &H3B
            Case "Warrior Queen Ears"
                Ears = &H3C
            Case "Cardboard Ears"
                Ears = &H3D
            Case "Sheep Ears"
                Ears = &H3E
            Case "Cybug Ears"
                Ears = &H3F
            Case "Beetle Ears"
                Ears = &H40
            Case "Lion Fish Ears"
                Ears = &H41
            Case "Idol Ears"
                Ears = &H42
            Case "Snorkel"
                Ears = &H43
            Case "Tusk Jewelry Ears"
                Ears = &H44
            Case "Amplifying Ears"
                Ears = &H45
            Case "Half Bot Ears"
                Ears = &H46
        End Select
        Select Case cmbChest.SelectedItem
            Case "Mummy Chest"
                Chest = &H1
            Case "Exoskeleton Chest"
                Chest = &H2
            Case "Crop Top Chest"
                Chest = &H3
            Case "Mummy Guard Chest"
                Chest = &H4
            Case "Bird Guard Chest"
                Chest = &H5
            Case "Bird Chest"
                Chest = &H6
            Case "Troll Chest"
                Chest = &H7
            Case "Coils Chest"
                Chest = &H8
            Case "Ninjini Chest"
                Chest = &H9
            Case "Bushwack Chest"
                Chest = &HA
            Case "Skeleton Chest"
                Chest = &HB
            Case "Heroic Chest"
                Chest = &HC
            Case "Tech Gear Chest"
                Chest = &HD
            Case "Tech Knight Chest"
                Chest = &HE
            Case "Dessert King Chest"
                Chest = &HF
            Case "Undead Skull Chest"
                Chest = &H10
            Case "Pilot's Chest"
                Chest = &H11
            Case "Fancy Chest"
                Chest = &H12
            Case "Vest Chest"
                Chest = &H13
            Case "Doomlander Knight Chest"
                Chest = &H14
            Case "Tuxedo"
                Chest = &H15
            Case "Merry Mischief Chest"
                Chest = &H16
            Case "Studded Chest"
                Chest = &H17
            Case "Judogi Chest"
                Chest = &H18
            Case "Shinobi Chest"
                Chest = &H19
            Case "Turtle Chest"
                Chest = &H1A
            Case "Tiki Chest"
                Chest = &H1B
            Case "Magma Chest"
                Chest = &H1C
            Case "Dustered Chest"
                Chest = &H1D
            Case "Bare It Chest"
                Chest = &H1E
            Case "Buckles and Belts Chest"
                Chest = &H1F
            Case "Shining Armor Chest"
                Chest = &H20
            Case "Bare Bones Chest"
                Chest = &H21
            Case "Heavenly Chest"
                Chest = &H22
            Case "Superhero Chest"
                Chest = &H23
            Case "Snowbody"
                Chest = &H24
            Case "Vampire Chest"
                Chest = &H25
            Case "Spark Chest"
                Chest = &H26
            Case "Top Crop Chest"
                Chest = &H27
            Case "Dragonmail Chest"
                Chest = &H28
            Case "All For One Chest"
                Chest = &H29
            Case "Goin' Bananas Chest"
                Chest = &H2A
            Case "Ahoy Chest"
                Chest = &H2B
            Case "Witchy Chest"
                Chest = &H2C
            Case "Sucker Chest"
                Chest = &H2D
            Case "Deep Sea Chest"
                Chest = &H2E
            Case "Samurai Torso"
                Chest = &H2F
            Case "Firebird Torso"
                Chest = &H30
            Case "Gladiator Torso"
                Chest = &H31
            Case "Wasteland Torso"
                Chest = &H32
            Case "Female Armor Torso"
                Chest = &H33
            Case "Seahorse Torso"
                Chest = &H34
            Case "Queen Torso"
                Chest = &H35
            Case "Firefighter's Torso"
                Chest = &H36
            Case "Wolf Chest"
                Chest = &H37
            Case "Sparta Torso"
                Chest = &H38
            Case "Conbot Torso"
                Chest = &H39
            Case "Equestrian Torso"
                Chest = &H3A
            Case "Eyeballs Torso"
                Chest = &H3B
            Case "King Torso"
                Chest = &H3C
            Case "Princess Torso"
                Chest = &H3D
            Case "Jester Torso"
                Chest = &H3E
            Case "Steampunk Torso"
                Chest = &H3F
            Case "Lionheart Torso"
                Chest = &H40
            Case "Ballerina Torso"
                Chest = &H41
            Case "Candy Torso"
                Chest = &H42
            Case "Scarecrow Torso"
                Chest = &H43
            Case "Fire Dancer Torso"
                Chest = &H44
            Case "Pumpkin Torso"
                Chest = &H45
            Case "Baby Torso"
                Chest = &H46
            Case "Lampman Torso"
                Chest = &H47
            Case "Commando Torso"
                Chest = &H48
            Case "Cyborg Torso"
                Chest = &H49
            Case "Ladybug Torso"
                Chest = &H4A
            Case "Insect Torso"
                Chest = &H4B
            Case "Gargoyle Torso"
                Chest = &H4C
            Case "Athletic Torso"
                Chest = &H4D
            Case "Tiger Torso"
                Chest = &H4E
            Case "Burrbearian Torso"
                Chest = &H4F
            Case "Enhanced Torso"
                Chest = &H50
            Case "Rhino Torso"
                Chest = &H51
            Case "Petal Torso"
                Chest = &H52
            Case "Dryad Torso"
                Chest = &H53
            Case "Train Torso"
                Chest = &H54
            Case "Aztec Chest"
                Chest = &H55
            Case "Cat Suit"
                Chest = &H56
            Case "Slime Torso"
                Chest = &H57
            Case "Chameleon Torso"
                Chest = &H58
            Case "Warrior Queen Torso"
                Chest = &H59
            Case "Boxy Torso"
                Chest = &H5A
            Case "Snake Torso"
                Chest = &H5B
            Case "Night Owl Armor Torso"
                Chest = &H5C
            Case "Woolly Torso"
                Chest = &H5D
            Case "Masquerade Torso"
                Chest = &H5E
            Case "Cybug Torso"
                Chest = &H5F
            Case "Beetle Body"
                Chest = &H60
            Case "Royal Guard Torso"
                Chest = &H61
            Case "Lion Fish Body"
                Chest = &H62
            Case "Digger Torso"
                Chest = &H63
            Case "Monkey Torso"
                Chest = &H64
            Case "Double Bacon Body"
                Chest = &H65
            Case "Diver Torso"
                Chest = &H66
            Case "Barbarian Body"
                Chest = &H67
            Case "Dragonmail Torso"
                Chest = &H68
            Case "Training Dummy Torso"
                Chest = &H69
            Case "Shield Maiden Torso"
                Chest = &H6A
            Case "Neon Breastplate"
                Chest = &H6B
            Case "Walled Body"
                Chest = &H6C
            Case "Lorica Hamata"
                Chest = &H6D
            Case "Diamond Armor"
                Chest = &H6E
        End Select
        Select Case cmbArms.SelectedItem
            Case "Mummy Arms"
                Arms = &H1
            Case "Shell Arms"
                Arms = &H2
            Case "Doomlander Knight Arms"
                Arms = &H3
            Case "Bird Arms"
                Arms = &H4
            Case "Skeleton Arms"
                Arms = &H5
            Case "Robot Arms"
                Arms = &H6
            Case "Robot Bouncer Arms"
                Arms = &H7
            Case "Scale Dress Arms"
                Arms = &H8
            Case "Drill Arms"
                Arms = &H9
            Case "Goblin Arms"
                Arms = &HA
            Case "Heroic Arms"
                Arms = &HB
            Case "Doomlander Barbarian Arms"
                Arms = &HC
            Case "Bellows Arms"
                Arms = &HD
            Case "Armsssss"
                Arms = &HE
            Case "Jester Arms"
                Arms = &HF
            Case "Balloon Arms"
                Arms = &H10
            Case "Puppet Arms"
                Arms = &H11
            Case "Queen Arms"
                Arms = &H12
            Case "Tentacle Arms"
                Arms = &H13
            Case "Vine Arms"
                Arms = &H14
            Case "Adventurer's Arms"
                Arms = &H15
            Case "Feelin' Froggy Arms"
                Arms = &H16
            Case "Muscle Arms"
                Arms = &H17
            Case "Hay Man Arms"
                Arms = &H18
            Case "Magma Arms"
                Arms = &H19
            Case "Fancy Sleeves"
                Arms = &H1A
            Case "Angelic Arms"
                Arms = &H1B
            Case "Frosty Arms"
                Arms = &H1C
            Case "Gothic Arms"
                Arms = &H1D
            Case "Starry Arms"
                Arms = &H1E
            Case "Double Belt Arms"
                Arms = &H1F
            Case "Redsleeves"
                Arms = &H20
            Case "One For All Arms"
                Arms = &H21
            Case "Aye Aye Arms"
                Arms = &H22
            Case "Witchy Arms"
                Arms = &H23
            Case "Raptor Arms"
                Arms = &H24
            Case "Deep Sea Arms"
                Arms = &H25
            Case "Ape Arms"
                Arms = &H26
            Case "Samurai Arms"
                Arms = &H27
            Case "Gladiator Arms"
                Arms = &H28
            Case "Wasteland Arms"
                Arms = &H29
            Case "Wolf Arms"
                Arms = &H2A
            Case "Con Bot Arms"
                Arms = &H2B
            Case "King Arms"
                Arms = &H2C
            Case "Princess Arms"
                Arms = &H2D
            Case "Steam Punk Arms"
                Arms = &H2E
            Case "Ninja Arms"
                Arms = &H2F
            Case "Ballerina Arms"
                Arms = &H30
            Case "Fossil Bone Arms"
                Arms = &H31
            Case "Bare Arms"
                Arms = &H32
            Case "Crash Arms"
                Arms = &H33
            Case "Fire Dancer Arms"
                Arms = &H34
            Case "Cleaning Arms"
                Arms = &H35
            Case "Lampman Arms"
                Arms = &H36
            Case "Command Arms"
                Arms = &H37
            Case "Cyborg Arms"
                Arms = &H38
            Case "Insect Arms"
                Arms = &H39
            Case "Tiger Arms"
                Arms = &H3A
            Case "Burrbearian Arms"
                Arms = &H3B
            Case "Chain Bracer Arms"
                Arms = &H3C
            Case "Dryad Arms"
                Arms = &H3D
            Case "Aztec Arms"
                Arms = &H3E
            Case "Cat Arms"
                Arms = &H3F
            Case "Slime Arms"
                Arms = &H40
            Case "Chameleon Arms"
                Arms = &H41
            Case "Stocking Arms"
                Arms = &H42
            Case "Beetle Arms"
                Arms = &H43
            Case "Royal Guard Arms"
                Arms = &H44
            Case "Monkey Arms"
                Arms = &H45
            Case "Diver Arms"
                Arms = &H46
            Case "Barbarian Arms"
                Arms = &H47
            Case "Chainmail Arms"
                Arms = &H48
            Case "Training Dummy Arms"
                Arms = &H49
            Case "Shield Maiden Arms"
                Arms = &H4A
        End Select
        Select Case cmbLegsTasset.SelectedItem
            Case "Wrapped Up Legs"
                LegsTasset = &H1
            Case "Buggy Legs"
                LegsTasset = &H2
            Case "Bare Legs"
                LegsTasset = &H3
            Case "Feathered Legs"
                LegsTasset = &H4
            Case "Android Legs"
                LegsTasset = &H5
            Case "Arg Me Legs"
                LegsTasset = &H6
            Case "Scale Mail Legs"
                LegsTasset = &H7
            Case "Genie Tasset"
                LegsTasset = &H8
            Case "Doomed Legs"
                LegsTasset = &H9
            Case "Socket Legs"
                LegsTasset = &HA
            Case "Doomlander Barbarian Legs"
                LegsTasset = &HB
            Case "Shining Armor Legs"
                LegsTasset = &HC
            Case "Mystical Legs"
                LegsTasset = &HD
            Case "Heavy-Duty Legs"
                LegsTasset = &HE
            Case "Ring-Ready Legs"
                LegsTasset = &HF
            Case "Caveman Legs"
                LegsTasset = &H10
            Case "Dancin' Legs"
                LegsTasset = &H11
            Case "Adventurer's Legs"
                LegsTasset = &H12
            Case "Elefeet Legs"
                LegsTasset = &H13
            Case "Woodsy Legs"
                LegsTasset = &H14
            Case "Peggy Legs"
                LegsTasset = &H15
            Case "Hoof Legs"
                LegsTasset = &H16
            Case "Skelelegs"
                LegsTasset = &H17
            Case "Frosty Legs"
                LegsTasset = &H18
            Case "Starry Legs"
                LegsTasset = &H19
            Case "Bikini n' Boots"
                LegsTasset = &H1A
            Case "All For One Legs"
                LegsTasset = &H1B
            Case "Witchy Legs"
                LegsTasset = &H1C
            Case "Sucker Legs"
                LegsTasset = &H1D
            Case "Raptor Legs"
                LegsTasset = &H1E
            Case "Deep Sea Legs"
                LegsTasset = &H1F
            Case "Cheesy Tasset"
                LegsTasset = &H20
            Case "Ape Legs"
                LegsTasset = &H21
            Case "Cowpoke Legs"
                LegsTasset = &H22
            Case "Samurai Legs"
                LegsTasset = &H23
            Case "Banana Legs"
                LegsTasset = &H24
            Case "Gladiator Legs"
                LegsTasset = &H25
            Case "Wasteland Legs"
                LegsTasset = &H26
            Case "Viney Legs"
                LegsTasset = &H27
            Case "Undead Tasset"
                LegsTasset = &H28
            Case "Water Tasset"
                LegsTasset = &H29
            Case "Spark Tasset"
                LegsTasset = &H2A
            Case "Faun Legs"
                LegsTasset = &H2B
            Case "Queen Legs"
                LegsTasset = &H2C
            Case "Nature Tasset"
                LegsTasset = &H2D
            Case "Merc Tasset"
                LegsTasset = &H2E
            Case "Wolf Legs"
                LegsTasset = &H2F
            Case "Sparta Legs"
                LegsTasset = &H30
            Case "Conbot Legs"
                LegsTasset = &H31
            Case "King Legs"
                LegsTasset = &H32
            Case "Princess Legs"
                LegsTasset = &H33
            Case "Skirt Tasset"
                LegsTasset = &H34
            Case "Wolfgang Legs"
                LegsTasset = &H35
            Case "Princess Tasset"
                LegsTasset = &H36
            Case "Air Tasset"
                LegsTasset = &H37
            Case "Roman Tasset"
                LegsTasset = &H38
            Case "Ninja Legs"
                LegsTasset = &H39
            Case "Ballerina Legs"
                LegsTasset = &H3A
            Case "Tuxedo Legs"
                LegsTasset = &H3B
            Case "Jester Legs"
                LegsTasset = &H3C
            Case "Fossil Bone Legs"
                LegsTasset = &H3D
            Case "Stone Legs"
                LegsTasset = &H3E
            Case "Scarecrow Legs"
                LegsTasset = &H3F
            Case "Chain Legs"
                LegsTasset = &H40
            Case "Earth Tasset"
                LegsTasset = &H41
            Case "Hydraulic Legs"
                LegsTasset = &H42
            Case "Fire Dancer Legs"
                LegsTasset = &H43
            Case "Heroic Legs"
                LegsTasset = &H44
            Case "Baby Legs"
                LegsTasset = &H45
            Case "Lampman Legs"
                LegsTasset = &H46
            Case "Ladybug Legs"
                LegsTasset = &H47
            Case "Insect Legs"
                LegsTasset = &H48
            Case "Athletic Legs"
                LegsTasset = &H49
            Case "Tiger Legs"
                LegsTasset = &H4A
            Case "Burrbearian Legs"
                LegsTasset = &H4B
            Case "Superhero Legs"
                LegsTasset = &H4C
            Case "Petal Legs"
                LegsTasset = &H4D
            Case "Dryad Legs"
                LegsTasset = &H4E
            Case "Aztec Legs"
                LegsTasset = &H4F
            Case "Cat Legs"
                LegsTasset = &H50
            Case "Slime Legs"
                LegsTasset = &H51
            Case "Warrior Queen Legs"
                LegsTasset = &H52
            Case "Night Owl Legs"
                LegsTasset = &H53
            Case "Sheep Legs"
                LegsTasset = &H54
            Case "Boots N Leggings"
                LegsTasset = &H55
            Case "Cybug Legs"
                LegsTasset = &H56
            Case "Beetle Legs"
                LegsTasset = &H57
            Case "Royal Guard Legs"
                LegsTasset = &H58
            Case "Lion Fish Tasset"
                LegsTasset = &H59
            Case "Monkey Legs"
                LegsTasset = &H5A
            Case "Leaf Tasset"
                LegsTasset = &H5B
            Case "Diver Legs"
                LegsTasset = &H5C
            Case "Barbarian Legs"
                LegsTasset = &H5D
            Case "Spirit Warrior Legs"
                LegsTasset = &H5E
            Case "Training Dummy Legs"
                LegsTasset = &H5F
            Case "Shield Maiden Legs"
                LegsTasset = &H60
            Case "Legionnaire Legs"
                LegsTasset = &H61
            Case "Bling Legs"
                LegsTasset = &H62
            Case "Sea Skirt"
                LegsTasset = &H63
        End Select
        Select Case cmbTail.SelectedItem
            Case "Bird Tail"
                Tail = &H1
            Case "Rooty Tail"
                Tail = &H2
            Case "Stinger Tail"
                Tail = &H3
            Case "Fishtail"
                Tail = &H4
            Case "Familiar Tail"
                Tail = &H5
            Case "Scaly Tail"
                Tail = &H6
            Case "Robo-Tail"
                Tail = &H7
            Case "Shelled Tail"
                Tail = &H8
            Case "Sleek Tail"
                Tail = &H9
            Case "Leaf Tail"
                Tail = &HA
            Case "Feathercat Tail"
                Tail = &HB
            Case "Cactus Tail"
                Tail = &HC
            Case "Rattler Tail"
                Tail = &HD
            Case "Zig-Zag Tail"
                Tail = &HE
            Case "Croc Tail"
                Tail = &HF
            Case "King's Tail"
                Tail = &H10
            Case "Skeletail"
                Tail = &H11
            Case "Tentacle Tail"
                Tail = &H12
            Case "Poison Tail"
                Tail = &H13
            Case "Horse Tail"
                Tail = &H14
            Case "Rainbow Tail"
                Tail = &H15
            Case "Bone Naga"
                Tail = &H16
            Case "Scorpion Naga"
                Tail = &H17
            Case "Raptor Tail"
                Tail = &H18
            Case "Furry Naga"
                Tail = &H19
            Case "Tentacle Naga"
                Tail = &H1A
            Case "Pangolin Naga"
                Tail = &H1B
            Case "Mermaid Naga"
                Tail = &H1C
            Case "Spark Naga"
                Tail = &H1D
            Case "Faun Tail"
                Tail = &H1E
            Case "Wolf Tail"
                Tail = &H1F
            Case "Eyeball Tail"
                Tail = &H20
            Case "Dragon Naga"
                Tail = &H21
            Case "Raptor Naga"
                Tail = &H22
            Case "Birdman Tail"
                Tail = &H23
            Case "Fossil Bone Tail"
                Tail = &H24
            Case "Bunny Tail"
                Tail = &H25
            Case "Skunk Tail"
                Tail = &H26
            Case "Lynx Tail"
                Tail = &H27
            Case "Lemur Tail"
                Tail = &H28
            Case "Rat Tail"
                Tail = &H29
            Case "Chain Tail"
                Tail = &H2A
            Case "Robot Naga"
                Tail = &H2B
            Case "Snake Naga"
                Tail = &H2C
            Case "Plug Tail"
                Tail = &H2D
            Case "Beaver Tail"
                Tail = &H2E
            Case "Gargoyle Tail"
                Tail = &H2F
            Case "Insect Tail"
                Tail = &H30
            Case "Tiger Tail"
                Tail = &H31
            Case "Spriggan Tail"
                Tail = &H32
            Case "Chameleon Tail"
                Tail = &H33
            Case "Lion Fish Naga"
                Tail = &H34
            Case "Lamp Naga"
                Tail = &H35
            Case "Monster Naga"
                Tail = &H36
            Case "Mic Tail"
                Tail = &H37
            Case "Gold Snapper Tail"
                Tail = &H38
            Case "Dolph Fin"
                Tail = &H39
        End Select
        Select Case cmbHeadgear.SelectedItem
            Case "(None)"
                Headgear = &H0
            Case "Queen's Crown"
                Headgear = &H1
            Case "Warrior's Ponytail"
                Headgear = &H2
            Case "Shell Helmet"
                Headgear = &H3
            Case "Fascinator"
                Headgear = &H4
            Case "Dundee Hat"
                Headgear = &H5
            Case "Stem Punk Hat"
                Headgear = &H6
            Case "Trash Hat"
                Headgear = &H7
            Case "Alarm Hat"
                Headgear = &H8
            Case "Morion Helmet"
                Headgear = &H9
            Case "Candle Hat"
                Headgear = &HA
            Case "Boneytail"
                Headgear = &HB
            Case "Mongol Hat"
                Headgear = &HC
            Case "Ice Cream Hat"
                Headgear = &HD
            Case "Oracle Hat"
                Headgear = &HE
            Case "Adventurer's Hat"
                Headgear = &HF
            Case "Trench Hat"
                Headgear = &H10
            Case "Cactihat"
                Headgear = &H11
            Case "Guard Helmet"
                Headgear = &H12
            Case "Challenger's Helm"
                Headgear = &H13
            Case "Fly By Knight Hat"
                Headgear = &H14
            Case "Pharaoh's Pride"
                Headgear = &H15
            Case "Demon Horns"
                Headgear = &H16
            Case "Porcupine Helm"
                Headgear = &H17
            Case "Bright Ideas Hat"
                Headgear = &H18
            Case "All-Seeing Hat"
                Headgear = &H19
            Case "Pointy Helmet"
                Headgear = &H1A
            Case "Battle Jester Hat"
                Headgear = &H1B
            Case "Forhead Fossil"
                Headgear = &H1C
            Case "Lavaglow Hat"
                Headgear = &H1D
            Case "Mysterious Hat"
                Headgear = &H1E
            Case "Number One Hat"
                Headgear = &H1F
            Case "Slouchy Beanie"
                Headgear = &H20
            Case "Bear-Headed Hat"
                Headgear = &H21
            Case "Artist's Hat"
                Headgear = &H22
            Case "Derby Hat"
                Headgear = &H23
            Case "Mad Mad Hat"
                Headgear = &H24
            Case "Boating Hat"
                Headgear = &H25
            Case "Carrot Beanie"
                Headgear = &H26
            Case "Sheriff's Hat"
                Headgear = &H27
            Case "Band Leader Hat"
                Headgear = &H28
            Case "Jingle Hat"
                Headgear = &H29
            Case "Firefighter's Hat"
                Headgear = &H2A
            Case "Military Hat"
                Headgear = &H2B
            Case "Kufi Cap"
                Headgear = &H2C
            Case "Horned Helm"
                Headgear = &H2D
            Case "Kitchen Crusader Hat"
                Headgear = &H2E
            Case "Viking's Pride"
                Headgear = &H2F
            Case "Safety Hat"
                Headgear = &H30
            Case "Holiday Hat"
                Headgear = &H31
            Case "Coconut Hat"
                Headgear = &H32
            Case "Dragon's Ridge"
                Headgear = &H33
            Case "Fishy Fin"
                Headgear = &H34
            Case "Doomed Knight Helm"
                Headgear = &H35
            Case "Centurion's Crest"
                Headgear = &H36
            Case "Mohawk"
                Headgear = &H37
            Case "Octohawk"
                Headgear = &H38
            Case "Unihorn"
                Headgear = &H39
            Case "Queen's Gem"
                Headgear = &H3A
            Case "Skeleton Drill"
                Headgear = &H3B
            Case "Heavenly Halo"
                Headgear = &H3C
            Case "Totally Metal Hat"
                Headgear = &H3D
            Case "See Saw Hat"
                Headgear = &H3E
            Case "Jolly Top Hat"
                Headgear = &H40
            Case "Bun-dle of Joy"
                Headgear = &H41
            Case "Hot-Head"
                Headgear = &H42
            Case "Fire Dragon Helm"
                Headgear = &H43
            Case "Rocket Man's Ridge"
                Headgear = &H44
            Case "Bonier-Tail"
                Headgear = &H45
            Case "Cavalier Hat"
                Headgear = &H46
            Case "Scallywag Hat"
                Headgear = &H47
            Case "Witchy Hat"
                Headgear = &H48
            Case "Squidley Hat"
                Headgear = &H49
            Case "Chompy Eyes"
                Headgear = &H4A
            Case "Samurai Helmet"
                Headgear = &H4B
            Case "Samurai U"
                Headgear = &H4C
            Case "Metal Crest"
                Headgear = &H4D
            Case "Firebird Helm"
                Headgear = &H4E
            Case "Gladiator Plume"
                Headgear = &H4F
            Case "Wasteland Spikes"
                Headgear = &H50
            Case "Brain Hat"
                Headgear = &H51
            Case "Colander Hat"
                Headgear = &H52
            Case "Sparta Plume"
                Headgear = &H53
            Case "Conbot Helmet"
                Headgear = &H54
            Case "Equestrian Helmet"
                Headgear = &H55
            Case "Eyeballs Helmet"
                Headgear = &H56
            Case "King's Crown"
                Headgear = &H57
            Case "Bad Juju Helmet"
                Headgear = &H58
            Case "Dr. Krankcase Hat"
                Headgear = &H59
            Case "Turtle Shell Helmet"
                Headgear = &H5A
            Case "Princess Hat"
                Headgear = &H5B
            Case "Blaster-tron Helnet"
                Headgear = &H5C
            Case "Tidepool Helmet"
                Headgear = &H5D
            Case "Grass Helmet"
                Headgear = &H5E
            Case "Chainsaw Beard"
                Headgear = &H5F
            Case "Bloom Helmet"
                Headgear = &H60
            Case "Steam Punk Helmet"
                Headgear = &H61
            Case "Investigating Hat"
                Headgear = &H62
            Case "Bat Hat"
                Headgear = &H63
            Case "Pink Ear Hat"
                Headgear = &H64
            Case "Fisherman's Hat"
                Headgear = &H65
            Case "Speedster Hat"
                Headgear = &H66
            Case "Rogue's Hat"
                Headgear = &H67
            Case "Cornucopia Hat"
                Headgear = &H68
            Case "Cubano Hat"
                Headgear = &H69
            Case "Boater Hat"
                Headgear = &H6A
            Case "Skipper's Hat"
                Headgear = &H6B
            Case "Lion's Maw"
                Headgear = &H6C
            Case "Royal Tiara"
                Headgear = &H6D
            Case "Jester Hat"
                Headgear = &H6E
            Case "Umbrella Dome"
                Headgear = &H6F
            Case "Candy Helmet"
                Headgear = &H70
            Case "Flattop Hawk"
                Headgear = &H71
            Case "Hair Spikes"
                Headgear = &H72
            Case "Scarecrow Hat"
                Headgear = &H73
            Case "Feathers"
                Headgear = &H74
            Case "Classic Ponytail"
                Headgear = &H75
            Case "Toilet Bowler"
                Headgear = &H78
            Case "Bunny Hat"
                Headgear = &H79
            Case "Baby Hair"
                Headgear = &H7A
            Case "Pumpkin Stem"
                Headgear = &H7B
            Case "Commando Helmet"
                Headgear = &H7C
            Case "Cyborg Helmet"
                Headgear = &H7D
            Case "Ladybug Feelers"
                Headgear = &H7E
            Case "Gargoyle Horns"
                Headgear = &H7F
            Case "Insect Antennae"
                Headgear = &H80
            Case "Helm of Ultimate Wisdom"
                Headgear = &H81
            Case "Superior Hair"
                Headgear = &H82
            Case "Blossom Hat"
                Headgear = &H83
            Case "Rhino Helm"
                Headgear = &H84
            Case "Dryad Horns"
                Headgear = &H85
            Case "Smokestack"
                Headgear = &H86
            Case "Aztec Head Gear"
                Headgear = &H87
            Case "Cat Hat"
                Headgear = &H88
            Case "Plane Fin"
                Headgear = &H89
            Case "Warrior Queen Visor"
                Headgear = &H8A
            Case "Snake Helmet"
                Headgear = &H8B
            Case "Fluffy Pompadour"
                Headgear = &H8C
            Case "Cybug Antennae"
                Headgear = &H8D
            Case "Beetle Hat"
                Headgear = &H8E
            Case "Royal Guard Head Gear"
                Headgear = &H8F
            Case "Lion Fish Mask"
                Headgear = &H90
            Case "Spelunk Helm"
                Headgear = &H91
            Case "Tasty Topper"
                Headgear = &H92
            Case "Ornate Ponytail"
                Headgear = &H93
            Case "Primal Hat"
                Headgear = &H94
            Case "Rabbit Ear Antennae"
                Headgear = &H95
            Case "Skully Mohawk"
                Headgear = &H96
            Case "Steeple"
                Headgear = &H97
            Case "Legionnaire Helm"
                Headgear = &H98
            Case "Golden Koi Helm"
                Headgear = &H99
        End Select
        Select Case cmbShoulderGuards.SelectedItem
            Case "(None)"
                ShoulderGuards = &H0
            Case "Sparta Shoulder Armor"
                ShoulderGuards = &H1
            Case "Ninja Shoulders"
                ShoulderGuards = &H2
            Case "Fire Dragon Shoulders"
                ShoulderGuards = &H3
            Case "Conbot Shoulder Armor"
                ShoulderGuards = &H4
            Case "Firefighter's  Shoulder Armor"
                ShoulderGuards = &H5
            Case "Chompy Shoulder Guards"
                ShoulderGuards = &H6
            Case "Pirate Epaulets"
                ShoulderGuards = &H7
            Case "Squid Shoulder Armor"
                ShoulderGuards = &H8
            Case "Samurai Shoulder Armor"
                ShoulderGuards = &H9
            Case "Wasteland Shoulder Pads"
                ShoulderGuards = &HA
            Case "Faun Shoulder Armor"
                ShoulderGuards = &HB
            Case "Clam Shoulder Armor"
                ShoulderGuards = &HC
            Case "Equestrian Shoulder Armor"
                ShoulderGuards = &HD
            Case "King Shoulder Armor"
                ShoulderGuards = &HE
            Case "Turtle Shoulder Armor"
                ShoulderGuards = &HF
            Case "Star Shoulder Armor"
                ShoulderGuards = &H10
            Case "Steam Punk Pauldrons"
                ShoulderGuards = &H11
            Case "Doomlander Smasher Shoulder Armor"
                ShoulderGuards = &H12
            Case "Mummy's Pauldrons"
                ShoulderGuards = &H13
            Case "Shoulder Shell"
                ShoulderGuards = &H14
            Case "Bird Pauldrons"
                ShoulderGuards = &H15
            Case "Ol'Faithful Pauldrons"
                ShoulderGuards = &H16
            Case "Woody Pauldrons"
                ShoulderGuards = &H17
            Case "Spiky Shoulders"
                ShoulderGuards = &H18
            Case "Stone Hero's Armor"
                ShoulderGuards = &H19
            Case "Leather Pauldrons"
                ShoulderGuards = &H1A
            Case "Double Guard"
                ShoulderGuards = &H1B
            Case "Pointy Protection"
                ShoulderGuards = &H1C
            Case "Engraved Armor"
                ShoulderGuards = &H1D
            Case "Cog Pauldrons"
                ShoulderGuards = &H1E
            Case "Circuit Shoulders"
                ShoulderGuards = &H1F
            Case "Studded Shoulders"
                ShoulderGuards = &H20
            Case "Arctic Armor"
                ShoulderGuards = &H21
            Case "Breeze Armor"
                ShoulderGuards = &H22
            Case "Fishy Shoulders"
                ShoulderGuards = &H23
            Case "Ceremonial Pauldrons"
                ShoulderGuards = &H24
            Case "Bare Bones Protection"
                ShoulderGuards = &H25
            Case "Horned Shoulders"
                ShoulderGuards = &H26
            Case "E-Guard 7000"
                ShoulderGuards = &H27
            Case "Spacey Armor"
                ShoulderGuards = &H28
            Case "Stoked Shoulders"
                ShoulderGuards = &H29
            Case "Scaly Shoulders"
                ShoulderGuards = &H2A
            Case "Metal Skull Shoulders"
                ShoulderGuards = &H2B
            Case "Stony Shoulders"
                ShoulderGuards = &H2C
            Case "All Natural Pauldrons"
                ShoulderGuards = &H2D
            Case "High Tech Protection"
                ShoulderGuards = &H2E
            Case "Lava Pauldrons"
                ShoulderGuards = &H2F
            Case "Heroic Shoulder Armor"
                ShoulderGuards = &H30
            Case "Guard Pauldrons"
                ShoulderGuards = &H31
            Case "Robotic Shoulders"
                ShoulderGuards = &H32
            Case "Stormy Shoulders"
                ShoulderGuards = &H33
            Case "Jeweled Pauldrons"
                ShoulderGuards = &H34
            Case "Fine Feathered Shoulders"
                ShoulderGuards = &H35
            Case "Arbor Armor"
                ShoulderGuards = &H36
            Case "Spangled Shoulders"
                ShoulderGuards = &H37
            Case "Nutty Shoulder Armor"
                ShoulderGuards = &H38
            Case "Snake Shoulders"
                ShoulderGuards = &H39
            Case "Rough Gold Shoulders"
                ShoulderGuards = &H3A
            Case "Paneled Leather Armor"
                ShoulderGuards = &H3B
            Case "Skull Pauldrons"
                ShoulderGuards = &H3C
            Case "Eagle-Eye Armor"
                ShoulderGuards = &H3D
            Case "Mighty Melon Pauldrons"
                ShoulderGuards = &H3E
            Case "Locomotor Shoulders"
                ShoulderGuards = &H3F
            Case "Squidley Shoulder Armor"
                ShoulderGuards = &H40
            Case "Sunbeam Shoulders"
                ShoulderGuards = &H41
            Case "Eye See Shoulders"
                ShoulderGuards = &H42
            Case "Seashell Shoulders"
                ShoulderGuards = &H43
            Case "Driftwood Pauldrons"
                ShoulderGuards = &H44
            Case "Bandit Pauldrons"
                ShoulderGuards = &H45
            Case "Royal Guard Pauldrons"
                ShoulderGuards = &H46
            Case "Heavy-Duty Pauldrons"
                ShoulderGuards = &H47
            Case "Domlander Sorcerer Pauldrons"
                ShoulderGuards = &H48
            Case "Doomed Dome  Shoulder Armor"
                ShoulderGuards = &H49
            Case "Doomed Bone Pauldrons"
                ShoulderGuards = &H4A
            Case "Lion Shoulders"
                ShoulderGuards = &H4B
            Case "Crystal Shoulders"
                ShoulderGuards = &H4C
            Case "Horn Skull Shoulder Armor"
                ShoulderGuards = &H4D
            Case "Spider Shoulder Armor"
                ShoulderGuards = &H4E
            Case "Pumpkin Pauldrons"
                ShoulderGuards = &H4F
            Case "Ladybug Shoulder Armor"
                ShoulderGuards = &H50
            Case "Burrbearian Pauldrons"
                ShoulderGuards = &H51
            Case "Rhino Pauldrons"
                ShoulderGuards = &H52
            Case "Petal Shoulder Armor"
                ShoulderGuards = &H53
            Case "Train Pauldrons"
                ShoulderGuards = &H54
            Case "Bomber Pauldrons"
                ShoulderGuards = &H55
            Case "Warrior Queen Pauldrons"
                ShoulderGuards = &H56
            Case "Shipping Shoulder Pads"
                ShoulderGuards = &H57
            Case "Snake Shoulder Pads"
                ShoulderGuards = &H58
            Case "Cybug Shoulder Pads"
                ShoulderGuards = &H59
            Case "Beetle Shoulder Pads"
                ShoulderGuards = &H5A
            Case "Royal Guard Shoulder Armor"
                ShoulderGuards = &H5B
            Case "Mined Shoulder Pads"
                ShoulderGuards = &H5C
            Case "Patty Pauldrons"
                ShoulderGuards = &H5D
            Case "Spirit Warrior Shoulders"
                ShoulderGuards = &H5E
            Case "Tricera Shoulders"
                ShoulderGuards = &H5F
            Case "Bow Shoulders"
                ShoulderGuards = &H60
            Case "Zeus Shoulders"
                ShoulderGuards = &H61
            Case "Ornate Knot Shoulder Pads"
                ShoulderGuards = &H62
            Case "Speaker Shoulders"
                ShoulderGuards = &H63
            Case "Metal Bone Shoulder Pads"
                ShoulderGuards = &H64
            Case "Parapet Shoulders"
                ShoulderGuards = &H65
            Case "Lorica Pauldrons"
                ShoulderGuards = &H66
            Case "Showy Shoulder Pads"
                ShoulderGuards = &H67
            Case "Seaweed Wrapped Shoulders"
                ShoulderGuards = &H68
        End Select
        Select Case cmbArmGuards.SelectedItem
            Case "(None)"
                ArmGuards = &H0
            Case "Shell Arm Armor"
                ArmGuards = &H1
            Case "Firefighter's Arm Armor"
                ArmGuards = &H2
            Case "Conbot Arm Armor"
                ArmGuards = &H3
            Case "Equestrian Arm Armor"
                ArmGuards = &H4
            Case "Eyeballs Arm Armor"
                ArmGuards = &H5
            Case "Turtle Arm Armor"
                ArmGuards = &H6
            Case "Wildstorm Arm Armor"
                ArmGuards = &H7
            Case "Buckshot Arm Armor"
                ArmGuards = &H8
            Case "Doom Bow Arm Armor"
                ArmGuards = &H9
            Case "Candy Arm Armor"
                ArmGuards = &HA
            Case "Pharaoh's Bracelets"
                ArmGuards = &HC
            Case "Exoskeleton Arm Armor"
                ArmGuards = &HD
            Case "Bird Arm Guards"
                ArmGuards = &HE
            Case "Spiral Arm Guards"
                ArmGuards = &HF
            Case "Driftwood Arm Guards"
                ArmGuards = &H10
            Case "Rocky Arm Armor"
                ArmGuards = &H11
            Case "Stoked Arm Armor"
                ArmGuards = &H12
            Case "Ancient Arm Guards"
                ArmGuards = &H13
            Case "Blocky Arm Guards"
                ArmGuards = &H14
            Case "Nuts and Bollts Arm Guards"
                ArmGuards = &H15
            Case "Squire's Arm Armor"
                ArmGuards = &H16
            Case "Skeletal Arm Armor"
                ArmGuards = &H17
            Case "Steam-Powered Arm Guards"
                ArmGuards = &H18
            Case "Viking Arm Guards"
                ArmGuards = &H19
            Case "High Tech Arm Shields"
                ArmGuards = &H1A
            Case "Unchained Arm Armor"
                ArmGuards = &H1B
            Case "Ceremonial Arm Armor"
                ArmGuards = &H1C
            Case "Spike Bracelets"
                ArmGuards = &H1D
            Case "Wrist Wraps"
                ArmGuards = &H1E
            Case "Bladed Arm Guards"
                ArmGuards = &H1F
            Case "Axeblade Arm Guards"
                ArmGuards = &H20
            Case "Aquatic Arm Armor"
                ArmGuards = &H21
            Case "Studded Arm Guards"
                ArmGuards = &H22
            Case "Fuzzy Arm Armor"
                ArmGuards = &H23
            Case "Fisherman's Arm Armor"
                ArmGuards = &H24
            Case "Skelemetal Gauntlets"
                ArmGuards = &H25
            Case "Mighty Melon Gauntlets"
                ArmGuards = &H26
            Case "Pizza Protection Arm Armor"
                ArmGuards = &H27
            Case "Radioactive Arm Armor"
                ArmGuards = &H28
            Case "Robotic Arm Guards"
                ArmGuards = &H29
            Case "Clam Shell Arm Guards"
                ArmGuards = &H2A
            Case "All Naturall Arm Armor"
                ArmGuards = &H2B
            Case "Steel Bangle Wrist Guards"
                ArmGuards = &H2C
            Case "Fossil Fury Arm Armor"
                ArmGuards = &H2D
            Case "Furry Wrist Guards"
                ArmGuards = &H2E
            Case "Riveting Arm Armor"
                ArmGuards = &H2F
            Case "Mosaic Arm Guards"
                ArmGuards = &H30
            Case "Brave Bones Arm Armor"
                ArmGuards = &H31
            Case "Centurion Arm Guards"
                ArmGuards = &H32
            Case "Crystal Arm Guards"
                ArmGuards = &H33
            Case "All-Seeing Eye Arm Guards"
                ArmGuards = &H34
            Case "Dragonscale Arm Guards"
                ArmGuards = &H35
            Case "Beaded Battle Bracelets"
                ArmGuards = &H36
            Case "Doomlander Spiky Arm Guards"
                ArmGuards = &H37
            Case "Hardcore Arm Guards"
                ArmGuards = &H38
            Case "Domlander Smasher Arm Guards"
                ArmGuards = &H39
            Case "Saw Gauntlets"
                ArmGuards = &H3A
            Case "Horned Arm Guards"
                ArmGuards = &H3B
            Case "Lion Arm Armor"
                ArmGuards = &H3C
            Case "Scarecrow Arm Armor"
                ArmGuards = &H3D
            Case "Spider Arm Armor"
                ArmGuards = &H3E
            Case "Rhino Wrist Guards"
                ArmGuards = &H3F
            Case "Train Arm Armor"
                ArmGuards = &H40
            Case "Petal Bracelets"
                ArmGuards = &H41
            Case "Propeller Bracelets"
                ArmGuards = &H42
            Case "Night Owl Arm Guards"
                ArmGuards = &H43
            Case "Drillin Arm Guards"
                ArmGuards = &H44
            Case "Hot Dawg Arm Guards"
                ArmGuards = &H45
            Case "Spirit Warrior Arm Guards"
                ArmGuards = &H46
            Case "Metal Skull Bracers"
                ArmGuards = &H47
            Case "Crenelled Arm Guards"
                ArmGuards = &H48
            Case "Lorica Wrists"
                ArmGuards = &H49
            Case "Glittering Arm Guards"
                ArmGuards = &H4A
            Case "Rainbow Roll Wrist Guards"
                ArmGuards = &H4B
        End Select
        Select Case cmbLegGuards.SelectedItem
            Case "(None)"
                LegGuards = &H0
            Case "Sparta Leg Armor"
                LegGuards = &H1
            Case "Conbot Leg Armor"
                LegGuards = &H2
            Case "Firefighter's Leg Armor"
                LegGuards = &H3
            Case "Centurion Leg Armor"
                LegGuards = &H4
            Case "Pharaoh's Leg Armor"
                LegGuards = &H5
            Case "Seashell Leg Armor"
                LegGuards = &H6
            Case "Bird Armor Greaves"
                LegGuards = &H7
            Case "Old Faithful Leg Armor"
                LegGuards = &H8
            Case "Rocky Greaves"
                LegGuards = &H9
            Case "Squire's Greaves"
                LegGuards = &HA
            Case "Winged Greaves"
                LegGuards = &HB
            Case "Lava Leg Armor"
                LegGuards = &HC
            Case "Skeleton Leg Armor"
                LegGuards = &HD
            Case "Webbed Greaves"
                LegGuards = &HE
            Case "Barbarian Leg Armor"
                LegGuards = &HF
            Case "Full Protection Leg Armor"
                LegGuards = &H10
            Case "Arrow Greaves"
                LegGuards = &H11
            Case "Studded Leg Armor"
                LegGuards = &H12
            Case "Bandit Greaves"
                LegGuards = &H13
            Case "Knight's Greaves"
                LegGuards = &H14
            Case "Offensive Defense Leg Armor"
                LegGuards = &H15
            Case "Paneled Leg Armor"
                LegGuards = &H16
            Case "Ceremonial Leg Armor"
                LegGuards = &H17
            Case "Batty Greaves"
                LegGuards = &H18
            Case "Lion Greaves"
                LegGuards = &H19
            Case "Doomlander Knight Leg Armor"
                LegGuards = &H1A
            Case "Doomlander Smasher Leg Armor"
                LegGuards = &H1B
            Case "Doomlander Archer Leg Armor"
                LegGuards = &H1C
            Case "Dragonhead Greaves"
                LegGuards = &H1D
            Case "All For One Leg Armor"
                LegGuards = &H1E
            Case "Firebird Leg Armor"
                LegGuards = &H1F
            Case "Equestrian Leg Armor"
                LegGuards = &H20
            Case "Eyeballs Leg Armor"
                LegGuards = &H21
            Case "Turtle Leg Armor"
                LegGuards = &H22
            Case "Earth Leg Armor"
                LegGuards = &H23
            Case "Steam Punk Leg Armor"
                LegGuards = &H24
            Case "Knight Leg Armor"
                LegGuards = &H25
            Case "Spiky Leg Armor"
                LegGuards = &H26
            Case "Candy Leg Armor"
                LegGuards = &H27
            Case "Spider Leg Armor"
                LegGuards = &H28
            Case "Pumpkin Leg Armor"
                LegGuards = &H29
            Case "Packaged Leg Armor"
                LegGuards = &H2A
            Case "Drillin Leg Guards"
                LegGuards = &H2B
            Case "Cobra Leg Armor"
                LegGuards = &H2C
            Case "King Leg Armor"
                LegGuards = &H2D
            Case "Laser Bone Leg Guards"
                LegGuards = &H2E
            Case "Merloned Leg Guards"
                LegGuards = &H2F
            Case "Plate Mail Leg Guards"
                LegGuards = &H30
            Case "Shrimp Leg Guards"
                LegGuards = &H31
            Case "Glittering Leg Guards"
                LegGuards = &H32
        End Select
        Select Case cmbBackpack.SelectedItem
            Case "(None)"
                Backpack = &H0
            Case "Feathered Wings"
                Backpack = &H1
            Case "Kaos Backpack"
                Backpack = &H2
            Case "Hoodsickle Backpack"
                Backpack = &H3
            Case "Bat Wings"
                Backpack = &H4
            Case "Turtle Shell Backpack"
                Backpack = &H5
            Case "Ninja Pack"
                Backpack = &H6
            Case "Piñata Pack"
                Backpack = &H7
            Case "Steam Punk Pack"
                Backpack = &H8
            Case "Barrel Back"
                Backpack = &H9
            Case "The Clean-Up"
                Backpack = &HA
            Case "Scarab's Flight"
                Backpack = &HB
            Case "Bird of Steel"
                Backpack = &HC
            Case "Ancient Tome"
                Backpack = &HE
            Case "Insect Wings"
                Backpack = &HF
            Case "Freeze - Stay Frosty"
                Backpack = &H10
            Case "Furnace Backpack"
                Backpack = &H11
            Case "Butterfly Wings"
                Backpack = &H12
            Case "Robo Wings"
                Backpack = &H13
            Case "Rockin' Rockets"
                Backpack = &H14
            Case "Cheesewings"
                Backpack = &H15
            Case "Dragon Wings"
                Backpack = &H16
            Case "Chilled Out"
                Backpack = &H17
            Case "Mr. Bear"
                Backpack = &H18
            Case "Lava Spikes"
                Backpack = &H19
            Case "Crystal Spine"
                Backpack = &H1A
            Case "Adventurer's Satchel"
                Backpack = &H1B
            Case "Skelesaurus Spine"
                Backpack = &H1C
            Case "Starfish Friend"
                Backpack = &H1D
            Case "Squirrel's Bounty"
                Backpack = &H1E
            Case "Chompy Pack"
                Backpack = &H1F
            Case "Wind-Up Key"
                Backpack = &H20
            Case "Shark Streak"
                Backpack = &H21
            Case "Mini-Snowman"
                Backpack = &H22
            Case "Gothic Cape"
                Backpack = &H23
            Case "Skeletal Spine"
                Backpack = &H24
            Case "Deep Sea Backpack"
                Backpack = &H25
            Case "Samurai Banner"
                Backpack = &H26
            Case "Ornate Shield"
                Backpack = &H27
            Case "Dragonfly Wings"
                Backpack = &H28
            Case "Air Strike Wings"
                Backpack = &H29
            Case "Fossil Bone Pack"
                Backpack = &H2A
            Case "Candy Pack"
                Backpack = &H2B
            Case "Golden Wings"
                Backpack = &H2C
            Case "Tailed Cape"
                Backpack = &H2D
            Case "Torn Cape"
                Backpack = &H2E
            Case "Spider Leg Pack"
                Backpack = &H30
            Case "Toilet Paper Pack"
                Backpack = &H31
            Case "Battery Pack"
                Backpack = &H32
            Case "To-Go Bottle"
                Backpack = &H33
            Case "Commando Pack"
                Backpack = &H34
            Case "Ladybug Backpack"
                Backpack = &H35
            Case "Aztec Backpack"
                Backpack = &H36
            Case "Cat Box"
                Backpack = &H37
            Case "Bow Pack"
                Backpack = &H38
            Case "Cybug Wings"
                Backpack = &H39
            Case "Lion Fish Backpack"
                Backpack = &H3A
            Case "Ore Rich Backpack"
                Backpack = &H3B
            Case "Fries Back"
                Backpack = &H3C
            Case "Scuba Tank"
                Backpack = &H3D
            Case "Bad Delivery"
                Backpack = &H3E
            Case "Short Wave"
                Backpack = &H3F
            Case "Rice Ball Backpack"
                Backpack = &H40
        End Select
        Select Case cmbAura.SelectedItem
            Case "(None)"
                Aura = &H0
            Case "Dark Star"
                Aura = &H1
            Case "Electrons"
                Aura = &H2
            Case "Electro Spark"
                Aura = &H3
            Case "Glowbug"
                Aura = &H4
            Case "Golden Rays"
                Aura = &H5
            Case "Star Child"
                Aura = &H6
            Case "Bloop"
                Aura = &H7
            Case "Bubbles"
                Aura = &H8
            Case "Stinky"
                Aura = &H9
            Case "Party"
                Aura = &HA
            Case "Rain Cloud"
                Aura = &HB
            Case "Air Elemental"
                Aura = &HC
            Case "Dark Elemental"
                Aura = &HD
            Case "Earth Elemental"
                Aura = &HE
            Case "Fire Elemental"
                Aura = &HF
            Case "Life Elemental"
                Aura = &H10
            Case "Light Elemental"
                Aura = &H11
            Case "Magic Elemental"
                Aura = &H12
            Case "Tech Elemental"
                Aura = &H13
            Case "Undead Elemental"
                Aura = &H14
            Case "Water Elemental"
                Aura = &H15
        End Select
        Select Case cmbVoice.SelectedItem
            Case "Drill Sergeant"
                Voice = &H0
            Case "Giant"
                Voice = &H1
            Case "Islander"
                Voice = &H2
            Case "Heroine"
                Voice = &H3
            Case "Hero"
                Voice = &H4
            Case "Cool"
                Voice = &H5
            Case "Pirate"
                Voice = &H6
            Case "Fairie"
                Voice = &H7
            Case "Wacky"
                Voice = &H8
            Case "Troll"
                Voice = &H9
            Case "Ghoul"
                Voice = &HA
            Case "Robot"
                Voice = &HB
            Case "Cowgirl"
                Voice = &HC
            Case "Soldier"
                Voice = &HD
            Case "Angelic"
                Voice = &HE
            Case "Scientist"
                Voice = &HF
            Case "Regal"
                Voice = &H10
            Case "Vampiress"
                Voice = &H11
            Case "Alien"
                Voice = &H12
            Case "Beeps"
                Voice = &H13
            Case "(None)"
                Voice = &H14
        End Select
        Select Case cmbStyle.SelectedItem
            Case "(None)"
                Style = &H0
            Case "Bot"
                Style = &H1
            Case "Warbler"
                Style = &H2
            Case "Magical"
                Style = &H3
            Case "Small"
                Style = &H4
            Case "Big"
                Style = &H5
            Case "Laser"
                Style = &H6
            Case "Radio"
                Style = &H7
            Case "Underwater"
                Style = &H8
            Case "Tiny"
                Style = &H9
            Case "Canyon"
                Style = &HA
            Case "Minibot"
                Style = &HB
            Case "Maxibot"
                Style = &HC
            Case "Spooky"
                Style = &HD
        End Select
        Select Case cmbMusic.SelectedItem
            Case "(None)"
                Music = &H0
            Case "Funk"
                Music = &H1
            Case "Electronic"
                Music = &H2
            Case "Country"
                Music = &H3
            Case "Hip Hop"
                Music = &H4
            Case "SKA"
                Music = &H5
            Case "Rock"
                Music = &H6
            Case "Fiesta"
                Music = &H7
            Case "Jazz"
                Music = &H8
            Case "A State of Trance"
                Music = &H9
            Case "8-Bit Skylands"
                Music = &HA
        End Select
        Select Case cmbEffects.SelectedItem
            Case "(None)"
                Effects = &H0
            Case "Cartoon"
                Effects = &H1
            Case "Video Game"
                Effects = &H2
            Case "Gassy"
                Effects = &H3
            Case "Haunted"
                Effects = &H5
            Case "Party"
                Effects = &H6
            Case "Animal"
                Effects = &H7
            Case "Sci-Fi"
                Effects = &H8
            Case "Guitar"
                Effects = &H9
            Case "Orchestra"
                Effects = &HB
            Case "Burpy"
                Effects = &HF
            Case "Machine"
                Effects = &H10
            Case "Squishy"
                Effects = &H11
        End Select
        Select Case cmbCatch.SelectedItem
            Case "Forecast calls for"
                Catc = &H0
            Case "The wind howls for"
                Catc = &H1
            Case "Fear"
                Catc = &H2
            Case "Cower before"
                Catc = &H3
            Case "I dig"
                Catc = &H4
            Case "Rock on"
                Catc = &H5
            Case "Fired up for"
                Catc = &H6
            Case "Something's burning. Must be"
                Catc = &H7
            Case "I live for"
                Catc = &H8
            Case "Rooting for"
                Catc = &H9
            Case "Shining through"
                Catc = &HA
            Case "Can't hold a candle to"
                Catc = &HB
            Case "I summon"
                Catc = &HC
            Case "Destined for"
                Catc = &HD
            Case "Engage"
                Catc = &HE
            Case "Fueled by"
                Catc = &HF
            Case "Be afraid of"
                Catc = &H10
            Case "Haunted by"
                Catc = &H11
            Case "Rain down"
                Catc = &H12
            Case "Making a splash with"
                Catc = &H13
            Case "All hail"
                Catc = &H14
            Case "Portal Master! Grant me"
                Catc = &H15
            Case "Check out"
                Catc = &H16
            Case "I will avenge"
                Catc = &H17
            Case "I like"
                Catc = &H18
            Case "Don't mess with"
                Catc = &H19
            Case "This one goes out to"
                Catc = &H1A
            Case "You can't handle"
                Catc = &H1B
            Case "Party with"
                Catc = &H1C
            Case "Time for"
                Catc = &H1D
            Case "Don't forget"
                Catc = &H1E
            Case "I'm crazy for"
                Catc = &H1F
            Case "This looks like a job for"
                Catc = &H20
            Case "Make way for"
                Catc = &H21
            Case "You're no match for"
                Catc = &H22
            Case "Say hello to"
                Catc = &H23
            Case "Prepare to face"
                Catc = &H24
            Case "Never underestimate"
                Catc = &H25
            Case "I'm all about"
                Catc = &H26
            Case "Too cool for"
                Catc = &H27
            Case "The password is"
                Catc = &H28
            Case "Get ready for"
                Catc = &H29
            Case "Unleash"
                Catc = &H2A
            Case "Can't stop"
                Catc = &H2B
            Case "You can count on"
                Catc = &H2C
            Case "Hear that? Sounds like"
                Catc = &H2D
            Case "No one expects"
                Catc = &H2E
            Case "Master of"
                Catc = &H2F
            Case "I rule over"
                Catc = &H30
            Case "Nothing better than"
                Catc = &H31
            Case "Knock knock. Who's there?"
                Catc = &H32
            Case "The return of"
                Catc = &H33
            Case "Strength, courage, and"
                Catc = &H34
            Case "Behold"
                Catc = &H35
            Case "Beware of"
                Catc = &H36
            Case "Brace for"
                Catc = &H37
            Case "I am one with"
                Catc = &H38
        End Select
        Select Case cmbPhrase.SelectedItem
            Case "the storm"
                Phrase = &H0
            Case "the air"
                Phrase = &H1
            Case "the dark"
                Phrase = &H2
            Case "doom"
                Phrase = &H3
            Case "the unknown"
                Phrase = &H4
            Case "falling rocks"
                Phrase = &H5
            Case "rock and roll"
                Phrase = &H6
            Case "the earth"
                Phrase = &H7
            Case "explosives"
                Phrase = &H8
            Case "fire"
                Phrase = &H9
            Case "flower power"
                Phrase = &HA
            Case "life"
                Phrase = &HB
            Case "pure radiance"
                Phrase = &HC
            Case "the light"
                Phrase = &HD
            Case "glitter"
                Phrase = &HE
            Case "magic"
                Phrase = &HF
            Case "the machines"
                Phrase = &H10
            Case "my superior technology"
                Phrase = &H11
            Case "zombie dance parties"
                Phrase = &H12
            Case "the undead"
                Phrase = &H13
            Case "my nightmare"
                Phrase = &H14
            Case "the tide"
                Phrase = &H15
            Case "water"
                Phrase = &H16
            Case "my arrows"
                Phrase = &H17
            Case "my bow"
                Phrase = &H18
            Case "my missiles"
                Phrase = &H19
            Case "the boom"
                Phrase = &H1A
            Case "my blades"
                Phrase = &H1B
            Case "my moves"
                Phrase = &H1C
            Case "my barbarian magnetism"
                Phrase = &H1D
            Case "my club"
                Phrase = &H1E
            Case "my muscles"
                Phrase = &H1F
            Case "my knuckles"
                Phrase = &H20
            Case "my wand"
                Phrase = &H21
            Case "the cosmos"
                Phrase = &H22
            Case "my staff"
                Phrase = &H23
            Case "double trouble"
                Phrase = &H24
            Case "the big guns"
                Phrase = &H25
            Case "my blasters"
                Phrase = &H26
            Case "my sword"
                Phrase = &H27
            Case "my steel"
                Phrase = &H28
            Case "my throwing stars"
                Phrase = &H29
            Case "my speed"
                Phrase = &H2A
            Case "mystery"
                Phrase = &H2B
            Case "techno"
                Phrase = &H2C
            Case "emotion"
                Phrase = &H2D
            Case "the monkeys"
                Phrase = &H2E
            Case "hugs"
                Phrase = &H2F
            Case "my sarcasm"
                Phrase = &H30
            Case "the bananas"
                Phrase = &H31
            Case "heroism"
                Phrase = &H32
            Case "hilarity"
                Phrase = &H33
            Case "my wrath"
                Phrase = &H34
            Case "glory"
                Phrase = &H35
            Case "my power"
                Phrase = &H36
            Case "victory"
                Phrase = &H37
            Case "my ultimate awesomeness"
                Phrase = &H38
            Case "evil"
                Phrase = &H39
            Case "my valor"
                Phrase = &H3A
            Case "the pancake house"
                Phrase = &H3B
            Case "pizza"
                Phrase = &H3C
            Case "the music"
                Phrase = &H3D
            Case "justice"
                Phrase = &H3E
            Case "my friends"
                Phrase = &H3F
            Case "the future"
                Phrase = &H40
            Case "piñatas"
                Phrase = &H41
            Case "disaster"
                Phrase = &H42
            Case "nothing"
                Phrase = &H43
        End Select
    End Sub
    Dim Mold As Byte
#Region " Mold "
    '10 Beaded D20
    '12 Beaded Rosette
    '11 Beaded Soccer
    '1B	Clawed Cone
    '1A Clawed Egg
    '19 Clawed Rosette
    '1D Crowned Cone
    '1C Crowned Soccer
    '1E Crowned Uncut
    '08 Handled Cube
    '07 Handled D12
    '09 Handled Quartz
    '0E Mech D12
    '0F Mech D20
    '0D Mech Quartz
    '14 Plated Rosette
    '15 Plated Soccer
    '13 Plated Uncut
    '06 Pointed Cube
    '04 Pointed Egg
    '05 Pointed Pyramid
    '1F	Rocky Cube
    '0C Rocky D12
    '0A Rocky Pyramid
    '0B Rocky Quartz
    '17 Rooted D20
    '16 Rooted D6
    '18 Rooted Egg
    '03 Winged Cone
    '01 Winged Pyramid
    '02 Winged Uncut
#End Region
    Dim Battlecast As Byte
#Region " Battlecast "
    '01 Knight
    '02 Bowslinger
    '03 Quickshot
    '04 Ninja
    '05 Brawler
    '06 Smasher
    '07 Sorcerer
    '08 Swashbuckler
    '09 Sentinel
    '0A Bazooker
#End Region
    Dim Head As Byte
#Region " Head "
    '01 Under Wraps
    '02 Bug Shot
    '03 Bobbed and Beautiful
    '04 Black Knight Head
    '05 Veggie Head
    '06 Cawsome
    '07 Helmet Hair
    '08 Cool Cat
    '09 Eye-Clops
    '0A Miss Clockwork
    '0B Squidbeard
    '0C Fish Fatale
    '0D No Sight No Problem
    '0E Flame-ulous
    '0F Brutebot
    '10 Robolander
    '11 Mr. Skull
    '12 Hooded Mystery
    '13 Monkey Business
    '14 Witchy Ways
    '15 Flynnteresting
    '16 Chinstrap
    '17 Bananana
    '18 Fangtastic
    '1A Familiar Face
    '1B Doomlackey
    '1C Tiki-Time
    '1D Imagi-tron 3000
    '1E Squid Kid
    '1F Bird Brain
    '20 Cyglobe
    '21 Big Cheese
    '22 Super Mask
    '23 Boar Bash
    '24 Shield Maiden Head
    '25 Biclops
    '26 Underbite
    '27 Soldier Head
    '28 Brainlander
    '29 Cowboy Head
    '2A Monsertious
    '2B Silverback
    '2C Sporeman
    '2D Sylvan
    '2E Expolorer Head
    '2F Lavabrain
    '30 Rex
    '31 Turtle
    '32 Retrobot
    '33 Spark Head
    '34 Amazonian Head
    '35 Snapshot
    '36 Tiger Head
    '37 Spiky Hair Head
    '38 Leafy Hair Head
    '39 Flat Top Head
    '3A Caesar Hair Head
    '3B Scruff
    '3C Doe Deer
    '3D Rocky
    '3E Nightwalker
    '3F Mr. Frost
    '40 Dino Head
    '41 Rockets
    '42 Squid Head
    '43 Pirate Head
    '44 Diver Head
    '45 Chompy Head
    '46 White Knight Head
    '47 One Eye Head
    '48 Gladiator Head
    '49 Wasteland Head
    '4A Faun Head
    '4B Seahorse Head
    '4C Wolf Head
    '4D Sparta Head
    '4E Equestrian Head
    '4F Firemask Head
    '50 Vernian Adventurer Head
    '51 Elf Enchantress
    '52 Blonde Streak Head
    '53 Head Band Head
    '54 Librarian Head
    '55 Ninja Head
    '56 Fossil Head
    '57 Bunhead Head
    '58 Bobbed Head
    '59 Scarecrow Head
    '5A Braided Head
    '5B Bull Head
    '5C Leaf Head
    '5D Fire Dancer Head
    '5E Robo Skull Head
    '5F Fish Monster Head
    '60 Cute Mammal Head
    '61 Troll Head
    '62 Crazy Head
    '63 Monkey King Head
    '64 Skele-Warrior Head
    '65 Rock Helmet Head
    '66 Dragon Head
    '67 Mushroom Head
    '68 Baby Dragon Head
    '69 Ragdoll Head
    '6A Spider Head
    '6B Insect Head
    '6C Pumpkin Head
    '6D Leaf Monster Head
    '6E Lightbulb Head
    '6F Baby Faced
    '70 Gargoyle Head
    '71 Kabuki Head
    '72 Sharp Toothed
    '73 Painted Skull Head
    '74 Gas Masked
    '75 Cyborg Head
    '76 Shaved Head
    '77 Lucha Libre!
    '78 Ladybug Head
    '79 Mustached Head
    '7A Freckles Head
    '7B Orc Head
    '7C Elf Head
    '7D Professional Head
    '7E Hipster Head
    '7F Student Head
    '80 Burrbearian Head
    '81 Reptilian Head
    '82 Rhino Mask
    '83 Petal Head
    '84 Dryad Head
    '85 Train Head
    '86 Aztec Mask
    '87 Feline Face
    '88 Slime Head
    '89 Chameleon Head
    '8A Plane Head
    '8B Warrior Queen Head
    '8C Box Top
    '8D Snake Head
    '8E Night Owl Mask
    '8F Sheep Head
    '90 Masquerade Head
    '91 Cybug Head
    '92 Beetle Head
    '93 Royal Guard Head
    '94 Lion Fish Head
    '95 Miner Head
    '96 Idol Mask
    '97 Diner Head
    '98 Scuba Head
    '99 Demon Spirit Head
    '9A Grizly Head
    '9B Training Dummy Head
    '9C Shield Queen Head
    '9D Boom Box
    '9E Metal Skull Head
    '9F Rook Head
    'A0 Sparkly Head
    'A1 Half Bot Head
#End Region
    Dim Eyes As Byte
#Region " Eyes "
    '00 Default
    '01 Cat
    '02 Goat
    '03 Human
    '04 Monster
    '05 Plain
    '06 Pupil
    '07 Target
    '08 Bug
    '09 Heart
    '0A Spiral
    '0B Robot
    '0C Star
    '0D Alien
    '0E Iball
    '0F Glowy
#End Region
    Dim Ears As Byte
#Region " Ears "
    '00 (None)
    '01 Elf Ears
    '02 Winged Ears
    '03 Spyro Horns
    '04 Fish Girl Ears
    '05 Dear Ring Ears
    '06 Cow Pierced
    '07 Troll Ears
    '08 Trumpet Ears
    '09 Pencil Ears
    '0A Ears of Corn
    '0B Magnet Ears
    '0C Ram Horn
    '0D Deer Antlers
    '0E Moose Antlers
    '0F Pigtails
    '10 Batty Ears
    '11 Rounded Ears
    '12 Antennae
    '13 Supersonic Ears
    '14 Jackal Ears
    '15 Deepglow Ears
    '16 Tentacles
    '17 Shell-o Ears
    '18 Pretty Fly Ears
    '19 Crystal Ears
    '1A Doomstein Ears
    '1B Earmuffs
    '1C Ears of Doom
    '1D Scaled Ears
    '1E Shiver Me Ears
    '1F Squidly Ears
    '20 Chompy Ears
    '21 Firebird Ears
    '22 Seahorse Ears
    '23 Faun Ears
    '24 Wolf Ears
    '25 Conbot Ears
    '26 Eyeballs Ears
    '27 Neo Cortex Ears
    '28 Ballerina Ears
    '29 Candy Ears
    '2A Scarecrow Ears
    '2B Satellite Ears
    '2C Antenna Ears
    '2D Dog Ears
    '2E Cat Ears
    '2F Bear Ears
    '30 Mouse Ears
    '31 Fire Dancer Ears
    '33 Plunger Ears
    '34 Bullhorn Ears
    '35 Cyborg Ears
    '36 Ladybug Earmuffs
    '37 Gargoyle Ears
    '38 Rhino Ears
    '39 Blossom Ears
    '3A Aztec Ears
    '3B Plane Ears
    '3C Warrior Queen Ears
    '3D Cardboard Ears
    '3E Sheep Ears
    '3F Cybug Ears
    '40 Beetle Ears
    '41 Lion Fish Ears
    '42 Idol Ears
    '43 Snorkel
    '44 Tusk Jewelry Ears
    '45 Amplifying Ears
    '46 Half Bot Ears
#End Region
    Dim Chest As Byte
#Region " Chest "
    '01 Mummy Chest
    '02 Exoskeleton Chest
    '03 Crop Top Chest
    '04 Mummy Guard Chest
    '05 Bird Guard Chest
    '06 Bird Chest
    '07 Troll Chest
    '08 Coils Chest
    '09 Ninjini Chest
    '0A Bushwack Chest
    '0B Skeleton Chest
    '0C Heroic Chest
    '0D Tech Gear Chest
    '0E Tech Knight Chest
    '0F Dessert King Chest
    '10 Undead Skull Chest
    '11 Pilot's Chest
    '12 Fancy Chest
    '13 Vest Chest
    '14 Doomlander Knight Chest
    '15 Tuxedo
    '16 Merry Mischief Chest
    '17 Studded Chest
    '18 Judogi Chest
    '19 Shinobi Chest
    '1A Turtle Chest
    '1B Tiki Chest
    '1C Magma Chest
    '1D Dustered Chest
    '1E Bare It Chest
    '1F Buckles and Belts Chest
    '20 Shining Armor Chest
    '21 Bare Bones Chest
    '22 Heavenly Chest
    '23 Superhero Chest
    '24 Snowbody
    '25 Vampire Chest
    '26 Spark Chest
    '27 Top Crop Chest
    '28 Dragonmail Chest
    '29 All For One Chest
    '2A Goin' Bananas Chest
    '2B Ahoy! Chest
    '2C Witchy Chest
    '2D Sucker Chest
    '2E Deep Sea Chest
    '2F Samurai Torso
    '30 Firebird Torso
    '31 Gladiator Torso
    '32 Wasteland Torso
    '33 Female Armor Torso
    '34 Seahorse Torso
    '35 Queen Torso
    '36 Firefighter's Torso
    '37 Wolf Chest
    '38 Sparta Torso
    '39 Conbot Torso
    '3A Equestrian Torso
    '3B Eyeballs Torso
    '3C King Torso
    '3D Princess Torso
    '3E Jester Torso
    '3F Steampunk Torso
    '40 Lionheart Torso
    '41 Ballerina Torso
    '42 Candy Torso
    '43 Scarecrow Torso
    '44 Fire Dancer Torso
    '45 Pumpkin Torso
    '46 Baby Torso
    '47 Lampman Torso
    '48 Commando Torso
    '49 Cyborg Torso
    '4A Ladybug Torso
    '4B Insect Torso
    '4C Gargoyle Torso
    '4D Athletic Torso
    '4E Tiger Torso
    '4F Burrbearian Torso
    '50 Enhanced Torso
    '51 Rhino Torso
    '52 Petal Torso
    '53 Dryad Torso
    '54 Train Torso
    '55 Aztec Chest
    '56 Cat Suit
    '57 Slime Torso
    '58 Chameleon Torso
    '59 Warrior Queen Torso
    '5A Boxy Torso
    '5B Snake Torso
    '5C Night Owl Armor Torso
    '5D Woolly Torso
    '5E Masquerade Torso
    '5F Cybug Torso
    '60 Beetle Body
    '61 Royal Guard Torso
    '62 Lion Fish Body
    '63 Digger Torso
    '64 Monkey Torso
    '65 Double Bacon Body
    '66 Diver Torso
    '67 Barbarian Body
    '68 Dragonmail Torso
    '69 Training Dummy Torso
    '6A Shield Maiden Torso
    '6B Neon Breastplate
    '6C Walled Body
    '6D Lorica Hamata
    '6E Diamond Armor
#End Region
    Dim Arms As Byte
#Region " Arms "
    '01	Mummy Arms
    '02	Shell Arms
    '03	Doomlander Knight Arms
    '04	Bird Arms
    '05	Skeleton Arms
    '06	Robot Arms
    '07	Robot Bouncer Arms
    '08	Scale Dress Arms
    '09	Drill Arms
    '0A	Goblin Arms
    '0B	Heroic Arms
    '0C	Doomlander Barbarian Arms
    '0D	Bellows Arms
    '0E	Armsssss
    '0F	Jester Arms
    '10	Balloon Arms
    '11	Puppet Arms
    '12	Queen Arms
    '13	Tentacle Arms
    '14	Vine Arms
    '15	Adventurer's Arms
    '16	Feelin' Froggy Arms
    '17	Muscle Arms
    '18	Hay Man Arms
    '19	Magma Arms
    '1A	Fancy Sleeves
    '1B	Angelic Arms
    '1C	Frosty Arms
    '1D	Gothic Arms
    '1E	Starry Arms
    '1F	Double Belt Arms
    '20	Redsleeves
    '21	One For All Arms
    '22	Aye Aye! Arms
    '23	Witchy Arms
    '24	Raptor Arms
    '25	Deep Sea Arms
    '26	Ape Arms
    '27	Samurai Arms
    '28	Gladiator Arms
    '29	Wasteland Arms
    '2A	Wolf Arms
    '2B	Con Bot Arms
    '2C	King Arms
    '2D	Princess Arms
    '2E	Steam Punk Arms
    '2F	Ninja Arms
    '30	Ballerina Arms
    '31	Fossil Bone Arms
    '32	Bare Arms
    '33	Crash Arms
    '34	Fire Dancer Arms
    '35	Cleaning Arms
    '36	Lampman Arms
    '37	Command Arms
    '38	Cyborg Arms
    '39	Insect Arms
    '3A	Tiger Arms
    '3B	Burrbearian Arms
    '3C	Chain Bracer Arms
    '3D	Dryad Arms
    '3E	Aztec Arms
    '3F	Cat Arms
    '40	Slime Arms
    '41	Chameleon Arms
    '42	Stocking Arms
    '43	Beetle Arms
    '44	Royal Guard Arms
    '45	Monkey Arms
    '46	Diver Arms
    '47	Barbarian Arms
    '48	Chainmail Arms
    '49	Training Dummy Arms
    '4A	Shield Maiden Arms

#End Region
    Dim LegsTasset As Byte
#Region " Legs/Tasset"
    '01	Wrapped Up Legs
    '02	Buggy Legs
    '03	Bare Legs
    '04	Feathered Legs
    '05	Android Legs
    '06	Arg! Me Legs
    '07	Scale Mail Legs
    '08	Genie Tasset
    '09	Doomed Legs
    '0A	Socket Legs
    '0B	Doomlander Barbarian Legs
    '0C	Shining Armor Legs
    '0D	Mystical Legs
    '0E	Heavy-Duty Legs
    '0F	Ring-Ready Legs
    '10	Caveman Legs
    '11	Dancin' Legs
    '12	Adventurer's Legs
    '13	Elefeet Legs
    '14	Woodsy Legs
    '15	Peggy Legs
    '16	Hoof Legs
    '17	Skelelegs
    '18	Frosty Legs
    '19	Starry Legs
    '1A	Bikini n' Boots
    '1B	All For One Legs
    '1C	Witchy Legs
    '1D	Sucker Legs
    '1E	Raptor Legs
    '1F	Deep Sea Legs
    '20	Cheesy Tasset
    '21	Ape Legs
    '22	Cowpoke Legs
    '23	Samurai Legs
    '24	Banana Legs
    '25	Gladiator Legs
    '26	Wasteland Legs
    '27	Viney Legs
    '28	Undead Tasset
    '29	Water Tasset
    '2A	Spark Tasset
    '2B	Faun Legs
    '2C	Queen Legs
    '2D	Nature Tasset
    '2E	Merc Tasset
    '2F	Wolf Legs
    '30	Sparta Legs
    '31	Conbot Legs
    '32	King Legs
    '33	Princess Legs
    '34	Skirt Tasset
    '35	Wolfgang Legs
    '36	Princess Tasset
    '37	Air Tasset
    '38	Roman Tasset
    '39	Ninja Legs
    '3A	Ballerina Legs
    '3B	Tuxedo Legs
    '3C	Jester Legs
    '3D	Fossil Bone Legs
    '3E	Stone Legs
    '3F	Scarecrow Legs
    '40	Chain Legs
    '41	Earth Tasset
    '42	Hydraulic Legs
    '43	Fire Dancer Legs
    '44	Heroic Legs
    '45	Baby Legs
    '46	Lampman Legs
    '47	Ladybug Legs
    '48	Insect Legs
    '49	Athletic Legs
    '4A	Tiger Legs
    '4B	Burrbearian Legs
    '4C	Superhero Legs
    '4D	Petal Legs
    '4E	Dryad Legs
    '4F	Aztec Legs
    '50	Cat Legs
    '51	Slime Legs
    '52	Warrior Queen Legs
    '53	Night Owl Legs
    '54	Sheep Legs
    '55	Boots N Leggings
    '56	Cybug Legs
    '57	Beetle Legs
    '58	Royal Guard Legs
    '59	Lion Fish Tasset
    '5A	Monkey Legs
    '5B	Leaf Tasset
    '5C	Diver Legs
    '5D	Barbarian Legs
    '5E	Spirit Warrior Legs
    '5F	Training Dummy Legs
    '60	Shield Maiden Legs
    '61	Legionnaire Legs
    '62	Bling Legs
    '63	Sea Skirt
#End Region
    Dim Tail As Byte
#Region " Tail "
    '00	None
    '01	Bird Tail
    '02	Rooty Tail
    '03	Stinger Tail
    '04	Fishtail
    '05	Familiar Tail
    '06	Scaly Tail
    '07	Robo-Tail
    '08	Shelled Tail
    '09	Sleek Tail
    '0A	Leaf Tail
    '0B	Feathercat Tail
    '0C	Cactus Tail
    '0D	Rattler Tail
    '0E	Zig-Zag Tail
    '0F	Croc Tail
    '10	King's Tail
    '11	Skeletail
    '12	Tentacle Tail
    '13	Poison Tail
    '14	Horse Tail
    '15	Rainbow Tail
    '16	Bone Naga
    '17	Scorpion Naga
    '18	Raptor Tail
    '19	Furry Naga
    '1A	Tentacle Naga
    '1B	Pangolin Naga
    '1C	Mermaid Naga
    '1D	Spark Naga
    '1E	Faun Tail
    '1F	Wolf Tail
    '20	Eyeball Tail
    '21	Dragon Naga
    '22	Raptor Naga
    '23	Birdman Tail
    '24	Fossil Bone Tail
    '25	Bunny Tail
    '26	Skunk Tail
    '27	Lynx Tail
    '28	Lemur Tail
    '29	Rat Tail
    '2A	Chain Tail
    '2B	Robot Naga
    '2C	Snake Naga
    '2D	Plug Tail
    '2E	Beaver Tail
    '2F	Gargoyle Tail
    '30	Insect Tail
    '31	Tiger Tail
    '32	Spriggan Tail
    '33	Chameleon Tail
    '34	Lion Fish Naga
    '35	Lamp Naga
    '36	Monster Naga
    '37	Mic Tail
    '38	Gold Snapper Tail
    '39	Dolph Fin

#End Region
    Dim Headgear As Byte
#Region " Headgear "
    '00 (None)
    '01 Queen's Crown
    '02 Warrior's Ponytail
    '03 Shell Helmet
    '04 Fascinator
    '05 Dundee Hat
    '06 Stem Punk Hat
    '07 Trash Hat
    '08 Alarm Hat
    '09 Morion Helmet
    '0A Candle Hat
    '0B Boneytail
    '0C Mongol Hat
    '0D Ice Cream Hat
    '0E Oracle Hat
    '0F Adventurer's Hat
    '10 Trench Hat
    '11 Cactihat
    '12 Guard Helmet
    '13 Challenger's Helm
    '14 Fly By Knight Hat
    '15 Pharaoh's Pride
    '16 Demon Horns
    '17 Porcupine Helm
    '18 Bright Ideas Hat
    '19 All-Seeing Hat
    '1A Pointy Helmet
    '1B Battle Jester Hat
    '1C Forhead Fossil
    '1D Lavaglow Hat
    '1E Mysterious Hat
    '1F Number One Hat
    '20 Slouchy Beanie
    '21 Bear-Headed Hat
    '22 Artist's Hat
    '23 Derby Hat
    '24 Mad Mad Hat
    '25 Boating Hat
    '26 Carrot Beanie
    '27 Sheriff's Hat
    '28 Band Leader Hat
    '29 Jingle Hat
    '2A Firefighter's Hat
    '2B Military Hat
    '2C Kufi Cap
    '2D Horned Helm
    '2E Kitchen Crusader Hat
    '2F Viking's Pride
    '30 Safety Hat
    '31 Holiday Hat
    '32 Coconut Hat
    '33 Dragon's Ridge
    '34 Fishy Fin
    '35 Doomed Knight Helm
    '36 Centurion's Crest
    '37 Mohawk
    '38 Octohawk
    '39 Unihorn
    '3A Queen's Gem
    '3B Skeleton Drill
    '3C Heavenly Halo
    '3D Totally Metal Hat
    '3E See Saw Hat
    '40 Jolly Top Hat
    '41 Bun-dle of Joy
    '42 Hot-Head
    '43 Fire Dragon Helm
    '44 Rocket Man's Ridge
    '45 Bonier-Tail
    '46 Cavalier Hat
    '47 Scallywag Hat
    '48 Witchy Hat
    '49 Squidley Hat
    '4A Chompy Eyes
    '4B Samurai Helmet
    '4C Samurai U
    '4D Metal Crest
    '4E Firebird Helm
    '4F Gladiator Plume
    '50 Wasteland Spikes
    '51 Brain Hat
    '52 Colander Hat
    '53 Sparta Plume
    '54 Conbot Helmet
    '55 Equestrian Helmet
    '56 Eyeballs Helmet
    '57 King's Crown
    '58 Bad Juju Helmet
    '59 Dr. Krankcase Hat
    '5A Turtle Shell Helmet
    '5B Princess Hat
    '5C Blaster-tron Helnet
    '5D Tidepool Helmet
    '5E Grass Helmet
    '5F Chainsaw Beard
    '60 Bloom Helmet
    '61 Steam Punk Helmet
    '62 Investigating Hat
    '63 Bat Hat
    '64 Pink Ear Hat
    '65 Fisherman's Hat
    '66 Speedster Hat
    '67 Rogue's Hat
    '68 Cornucopia Hat
    '69 Cubano Hat
    '6A Boater Hat
    '6B Skipper's Hat
    '6C Lion's Maw
    '6D Royal Tiara
    '6E Jester Hat
    '6F Umbrella Dome
    '70 Candy Helmet
    '71 Flattop Hawk
    '72 Hair Spikes
    '73 Scarecrow Hat
    '74 Feathers
    '75 Classic Ponytail
    '78 Toilet Bowler
    '79 Bunny Hat
    '7A Baby Hair
    '7B Pumpkin Stem
    '7C Commando Helmet
    '7D Cyborg Helmet
    '7E Ladybug Feelers
    '7F Gargoyle Horns
    '80 Insect Antennae
    '81 Helm of Ultimate Wisdom
    '82 Superior Hair
    '83 Blossom Hat
    '84 Rhino Helm
    '85 Dryad Horns
    '86 Smokestack
    '87 Aztec Head Gear
    '88 Cat Hat
    '89 Plane Fin
    '8A Warrior Queen Visor
    '8B Snake Helmet
    '8C Fluffy Pompadour
    '8D Cybug Antennae
    '8E Beetle Hat
    '8F Royal Guard Head Gear
    '90 Lion Fish Mask
    '91 Spelunk Helm
    '92 Tasty Topper
    '93 Ornate Ponytail
    '94 Primal Hat
    '95 Rabbit Ear Antennae
    '96 Skully Mohawk
    '97 Steeple
    '98 Legionnaire Helm
    '99 Golden Koi Helm
#End Region
    Dim ShoulderGuards As Byte
#Region " ShoulderGuards "
    '00	None
    '01	Sparta Shoulder Armor
    '02	Ninja Shoulders
    '03	Fire Dragon Shoulders
    '04	Conbot Shoulder Armor
    '05	Firefighter's  Shoulder Armor
    '06	Chompy Shoulder Guards
    '07	Pirate Epaulets
    '08	Squid Shoulder Armor
    '09	Samurai Shoulder Armor
    '0A	Wasteland Shoulder Pads
    '0B	Faun Shoulder Armor
    '0C	Clam Shoulder Armor
    '0D	Equestrian Shoulder Armor
    '0E	King Shoulder Armor
    '0F	Turtle Shoulder Armor
    '10	Star Shoulder Armor
    '11	Steam Punk Pauldrons
    '12	Doomlander Smasher Shoulder Armor
    '13	Mummy's Pauldrons
    '14	Shoulder Shell
    '15	Bird Pauldrons
    '16	Ol'Faithful Pauldrons
    '17	Woody Pauldrons
    '18	Spiky Shoulders
    '19	Stone Hero's Armor
    '1A	Leather Pauldrons
    '1B	Double Guard
    '1C	Pointy Protection
    '1D	Engraved Armor
    '1E	Cog Pauldrons
    '1F	Circuit Shoulders
    '20	Studded Shoulders
    '21	Arctic Armor
    '22	Breeze Armor
    '23	Fishy Shoulders
    '24	Ceremonial Pauldrons
    '25	Bare Bones Protection
    '26	Horned Shoulders
    '27	E-Guard 7000
    '28	Spacey Armor
    '29	Stoked Shoulders
    '2A	Scaly Shoulders
    '2B	Metal Skull Shoulders
    '2C	Stony Shoulders
    '2D	All Natural Pauldrons
    '2E	High Tech Protection
    '2F	Lava Pauldrons
    '30	Heroic Shoulder Armor
    '31	Guard Pauldrons
    '32	Robotic Shoulders
    '33	Stormy Shoulders
    '34	Jeweled Pauldrons
    '35	Fine Feathered Shoulders
    '36	Arbor Armor
    '37	Spangled Shoulders
    '38	Nutty Shoulder Armor
    '39	Snake Shoulders
    '3A	Rough Gold Shoulders
    '3B	Paneled Leather Armor
    '3C	Skull Pauldrons
    '3D	Eagle-Eye Armor
    '3E	Mighty Melon Pauldrons
    '3F	Locomotor Shoulders
    '40	Squidley Shoulder Armor
    '41	Sunbeam Shoulders
    '42	Eye See Shoulders
    '43	Seashell Shoulders
    '44	Driftwood Pauldrons
    '45	Bandit Pauldrons
    '46	Royal Guard Pauldrons
    '47	Heavy-Duty Pauldrons
    '48	Domlander Sorcerer Pauldrons
    '49	Doomed Dome  Shoulder Armor
    '4A	Doomed Bone Pauldrons
    '4B	Lion Shoulders
    '4C	Crystal Shoulders
    '4D	Horn Skull Shoulder Armor
    '4E	Spider Shoulder Armor
    '4F	Pumpkin Pauldrons
    '50	Ladybug Shoulder Armor
    '51	Burrbearian Pauldrons
    '52	Rhino Pauldrons
    '53	Petal Shoulder Armor
    '54	Train Pauldrons
    '55	Bomber Pauldrons
    '56	Warrior Queen Pauldrons
    '57	Shipping Shoulder Pads
    '58	Snake Shoulder Pads
    '59	Cybug Shoulder Pads
    '5A	Beetle Shoulder Pads
    '5B	Royal Guard Shoulder Armor
    '5C	Mined Shoulder Pads
    '5D	Patty Pauldrons
    '5E	Spirit Warrior Shoulders
    '5F	Tricera Shoulders
    '60	Bow Shoulders
    '61	Zeus Shoulders
    '62	Ornate Knot Shoulder Pads
    '63	Speaker Shoulders
    '64	Metal Bone Shoulder Pads
    '65	Parapet Shoulders
    '66	Lorica Pauldrons
    '67	Showy Shoulder Pads
    '68	Seaweed Wrapped Shoulders

#End Region
    Dim ArmGuards As Byte
#Region " ArmGuards "
    '00	None
    '01	Shell Arm Armor
    '02	Firefighter's Arm Armor
    '03	Conbot Arm Armor
    '04	Equestrian Arm Armor
    '05	Eyeballs Arm Armor
    '06	Turtle Arm Armor
    '07	Wildstorm Arm Armor
    '08	Buckshot Arm Armor
    '09	Doom Bow Arm Armor
    '0A	Candy Arm Armor
    '0C	Pharaoh's Bracelets
    '0D	Exoskeleton Arm Armor
    '0E	Bird Arm Guards
    '0F	Spiral Arm Guards
    '10	Driftwood Arm Guards
    '11	Rocky Arm Armor
    '12	Stoked Arm Armor
    '13	Ancient Arm Guards
    '14	Blocky Arm Guards
    '15	Nuts and Bollts Arm Guards
    '16	Squire's Arm Armor
    '17	Skeletal Arm Armor
    '18	Steam-Powered Arm Guards
    '19	Viking Arm Guards
    '1A	High Tech Arm Shields
    '1B	Unchained Arm Armor
    '1C	Ceremonial Arm Armor
    '1D	Spike Bracelets
    '1E	Wrist Wraps
    '1F	Bladed Arm Guards
    '20	Axeblade Arm Guards
    '21	Aquatic Arm Armor
    '22	Studded Arm Guards
    '23	Fuzzy Arm Armor
    '24	Fisherman's Arm Armor
    '25	Skelemetal Gauntlets
    '26	Mighty Melon Gauntlets
    '27	Pizza Protection Arm Armor
    '28	Radioactive Arm Armor
    '29	Robotic Arm Guards
    '2A	Clam Shell Arm Guards
    '2B	All Naturall Arm Armor
    '2C	Steel Bangle Wrist Guards
    '2D	Fossil Fury Arm Armor
    '2E	Furry Wrist Guards
    '2F	Riveting Arm Armor
    '30	Mosaic Arm Guards
    '31	Brave Bones Arm Armor
    '32	Centurion Arm Guards
    '33	Crystal Arm Guards
    '34	All-Seeing Eye Arm Guards
    '35	Dragonscale Arm Guards
    '36	Beaded Battle Bracelets
    '37	Doomlander Spiky Arm Guards
    '38	Hardcore Arm Guards
    '39	Domlander Smasher Arm Guards
    '3A	Saw Gauntlets
    '3B	Horned Arm Guards
    '3C	Lion Arm Armor
    '3D	Scarecrow Arm Armor
    '3E	Spider Arm Armor
    '3F	Rhino Wrist Guards
    '40	Train Arm Armor
    '41	Petal Bracelets
    '42	Propeller Bracelets
    '43	Night Owl Arm Guards
    '44	Drillin Arm Guards
    '45	Hot Dawg Arm Guards
    '46	Spirit Warrior Arm Guards
    '47	Metal Skull Bracers
    '48	Crenelled Arm Guards
    '49	Lorica Wrists
    '4A	Glittering Arm Guards
    '4B	Rainbow Roll Wrist Guards
#End Region
    Dim LegGuards As Byte
#Region " LegGuards "
    '00	None
    '01	Sparta Leg Armor
    '02	Conbot Leg Armor
    '03	Firefighter's Leg Armor
    '04	Centurion Leg Armor
    '05	Pharaoh's Leg Armor
    '06	Seashell Leg Armor
    '07	Bird Armor Greaves
    '08	Old Faithful Leg Armor
    '09	Rocky Greaves
    '0A	Squire's Greaves
    '0B	Winged Greaves
    '0C	Lava Leg Armor
    '0D	Skeleton Leg Armor
    '0E	Webbed Greaves
    '0F	Barbarian Leg Armor
    '10	Full Protection Leg Armor
    '11	Arrow Greaves
    '12	Studded Leg Armor
    '13	Bandit Greaves
    '14	Knight's Greaves
    '15	Offensive Defense Leg Armor
    '16	Paneled Leg Armor
    '17	Ceremonial Leg Armor
    '18	Batty Greaves
    '19	Lion Greaves
    '1A	Doomlander Knight Leg Armor
    '1B	Doomlander Smasher Leg Armor
    '1C	Doomlander Archer Leg Armor
    '1D	Dragonhead Greaves
    '1E	All For One Leg Armor
    '1F	Firebird Leg Armor
    '20	Equestrian Leg Armor
    '21	Eyeballs Leg Armor
    '22	Turtle Leg Armor
    '23	Earth Leg Armor
    '24	Steam Punk Leg Armor
    '25	Knight Leg Armor
    '26	Spiky Leg Armor
    '27	Candy Leg Armor
    '28	Spider Leg Armor
    '29	Pumpkin Leg Armor
    '2A	Packaged Leg Armor
    '2B	Drillin Leg Guards
    '2C	Cobra Leg Armor
    '2D	King Leg Armor
    '2E	Laser Bone Leg Guards
    '2F	Merloned Leg Guards
    '30	Plate Mail Leg Guards
    '31	Shrimp Leg Guards
    '32	Glittering Leg Guards

#End Region
    Dim Backpack As Byte
#Region " Backpack "
    '00	None
    '01	Feathered Wings
    '02	Kaos Backpack
    '03	Hoodsickle Backpack
    '04	Bat Wings
    '05	Turtle Shell Backpack
    '06	Ninja Pack
    '07	Piñata Pack
    '08	Steam Punk Pack
    '09	Barrel Back
    '0A	The Clean-Up
    '0B	Scarab's Flight
    '0C	Bird of Steel
    '0E	Ancient Tome
    '0F	Insect Wings
    '10	Freeze - Stay Frosty
    '11	Furnace Backpack
    '12	Butterfly Wings
    '13	Robo Wings
    '14	Rockin' Rockets
    '15	Cheesewings
    '16	Dragon Wings
    '17	Chilled Out
    '18	Mr. Bear
    '19	Lava Spikes
    '1A	Crystal Spine
    '1B	Adventurer's Satchel
    '1C	Skelesaurus Spine
    '1D	Starfish Friend
    '1E	Squirrel's Bounty
    '1F	Chompy Pack
    '20	Wind-Up Key
    '21	Shark Streak
    '22	Mini-Snowman
    '23	Gothic Cape
    '24	Skeletal Spine
    '25	Deep Sea Backpack
    '26	Samurai Banner
    '27	Ornate Shield
    '28	Dragonfly Wings
    '29	Air Strike Wings
    '2A	Fossil Bone Pack
    '2B	Candy Pack
    '2C	Golden Wings
    '2D	Tailed Cape
    '2E	Torn Cape
    '30	Spider Leg Pack
    '31	Toilet Paper Pack
    '32	Battery Pack
    '33	To-Go Bottle
    '34	Commando Pack
    '35	Ladybug Backpack
    '36	Aztec Backpack
    '37	Cat Box
    '38	Bow Pack
    '39	Cybug Wings
    '3A	Lion Fish Backpack
    '3B	Ore Rich Backpack
    '3C	Fries Back
    '3D	Scuba Tank
    '3E	Bad Delivery
    '3F	Short Wave
    '40	Rice Ball Backpack
#End Region
    Dim Aura As Byte
#Region " Aura "
    '0	None
    '1	Dark Star
    '2	Electrons
    '3	Electro Spark
    '4	Glowbug
    '5	Golden Rays
    '6	Star Child
    '7	Bloop
    '8	Bubbles
    '9	Stinky
    'A	Party
    'B	Rain Cloud
    'C	Air Elemental
    'D	Dark Elemental
    'E	Earth Elemental
    'F	Fire Elemental
    '10	Life Elemental
    '11	Light Elemental
    '12	Magic Elemental
    '13	Tech Elemental
    '14	Undead Elemental
    '15	Water Elemental
#End Region
    Dim Voice As Byte
#Region " Voice "
    '0	Drill Sergeant
    '1	Giant
    '2	Islander
    '3	Heroine
    '4	Hero
    '5	Cool
    '6	Pirate
    '7	Fairie
    '8	Wacky
    '9	Troll
    'A	Ghoul
    'B	Robot
    'C	Cowgirl
    'D	Soldier
    'E	Angelic
    'F	Scientist
    '10	Regal
    '11	Vampiress
    '12	Alien
    '13	Beeps
    '14	None
#End Region
    Dim Style As Byte
#Region " Style "
    '0	None
    '1	Bot
    '2	Warbler
    '3	Magical
    '4	Small
    '5	Big
    '6	Laser
    '7	Radio
    '8	Underwater
    '9	Tiny
    'A	Canyon
    'B	Minibot
    'C	Maxibot
    'D	Spooky
#End Region
    Dim Music As Byte
#Region " Music "
    '0	None
    '1	Funk
    '2	Electronic
    '3	Country
    '4	Hip Hop
    '5	SKA
    '6	Rock
    '7	Fiesta
    '8	Jazz
    '9	A State of Trance
    'A	8-Bit Skylands
#End Region
    Dim Effects As Byte
#Region " Effects "
    '0	None
    '1	Cartoon
    '2	Video Game
    '3	Gassy
    '5	Haunted
    '6	Party
    '7	Animal
    '8	Sci-Fi
    '9	Guitar
    'B	Orchestra
    'F	Burpy
    '10	Machine
    '11	Squishy
#End Region
    Dim Catc As Byte 'First half of Catch Phrase
#Region " Catch "
    '0	Forecast calls for
    '1	The wind howls for
    '2	Fear
    '3	Cower before
    '4	I dig
    '5	Rock on
    '6	Fired up for
    '7	Something's burning. Must be
    '8	I live for
    '9	Rooting for
    'A	Shining through
    'B	Can't hold a candle to
    'C	I summon
    'D	Destined for
    'E	Engage
    'F	Fueled by
    '10	Be afraid of
    '11	Haunted by
    '12	Rain down
    '13	Making a splash with
    '14	All hail
    '15	Portal Master! Grant me
    '16	Check out
    '17	I will avenge
    '18	I like
    '19	Don't mess with
    '1A	This one goes out to
    '1B	You can't handle
    '1C	Party with
    '1D	Time for
    '1E	Don't forget
    '1F	I'm crazy for
    '20	This looks like a job for
    '21	Make way for
    '22	You're no match for
    '23	Say hello to
    '24	Prepare to face
    '25	Never underestimate
    '26	I'm all about
    '27	Too cool for
    '28	The password is
    '29	Get ready for
    '2A	Unleash
    '2B	Can't stop
    '2C	You can count on
    '2D	Hear that? Sounds like
    '2E	No one expects
    '2F	Master of
    '30	I rule over
    '31	Nothing better than
    '32	Knock knock. Who's there?
    '33	The return of
    '34	Strength, courage, and
    '35	Behold
    '36	Beware of
    '37	Brace for
    '38	I am one with
#End Region
    Dim Phrase As Byte 'Second Half of Catch Phrase
#Region " Phrase "
    '0	the storm
    '1	the air
    '2	the dark
    '3	doom
    '4	the unknown
    '5	falling rocks
    '6	rock and roll
    '7	the earth
    '8	explosives
    '9	fire
    'A	flower power
    'B	life
    'C	pure radiance
    'D	the light
    'E	glitter
    'F	magic
    '10	the machines
    '11	my superior technology
    '12	zombie dance parties
    '13	the undead
    '14	my nightmare
    '15	the tide
    '16	water
    '17	my arrows
    '18	my bow
    '19	my missiles
    '1A	the boom
    '1B	my blades
    '1C	my moves
    '1D	my barbarian magnetism
    '1E	my club
    '1F	my muscles
    '20	my knuckles
    '21	my wand
    '22	the cosmos
    '23	my staff
    '24	double trouble
    '25	the big guns
    '26	my blasters
    '27	my sword
    '28	my steel
    '29	my throwing stars
    '2A	my speed
    '2B	mystery
    '2C	techno
    '2D	emotion
    '2E	the monkeys
    '2F	hugs
    '30	my sarcasm
    '31	the bananas
    '32	heroism
    '33	hilarity
    '34	my wrath
    '35	glory
    '36	my power
    '37	victory
    '38	my ultimate awesomeness
    '39	evil
    '3A	my valor
    '3B	the pancake house
    '3C	pizza
    '3D	the music
    '3E	justice
    '3F	my friends
    '40	the future
    '41	piñatas
    '42	disaster
    '43	nothing
#End Region
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnTest.Click

    End Sub
    Private Sub frmCrystals_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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

    Private Sub frmCrystals_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmMain.Disable_Controls()
        'cmbMold.SelectedIndex = 5
        'MessageBox.Show(WholeFile(&H1C))
        Load_Crystal()
    End Sub
    Sub Load_Crystal()
        cmbMold.SelectedIndex = WholeFile(&H1C)
    End Sub
End Class