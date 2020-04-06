# SkyEditGUI
GUI for Editor for MiFare based figures

I am trying to create an All-in-One Editor for a game that uses MiFar based Figures.

Current Features:
Identify Most (but not all) of the Figures that the game supports dumps.

Edit ALL values for Characters. This includes Hat, Name, Gold, Exp/Level, Heroic Challenges, Fairy Path and Hero Points.

Reads in Figures from a NON-XBox 360 USB Game Portal connected to a Windows PC.

Reads in Encrypted Figures for editing.

Reads in Decrypted Figures for editing.

Writes Decrypted Figure Dumps and Encrypted Figure Dumps by user selection in a file menu.

Can write data back to a Figure on the Non-XBox 360 Game Portal.

The Figure's serial number can be randomized but should ONLY be used on a MiFare S50/Magic Chinese card. NOT on a figure on the Portal. See below for Known issues.

Can edit Figure's Character ID and Variant/Generation ID. With Exceptions, as noted below.

Supports Maxlander Tags for reading/editing except for the 2KB Swap Force Dumps.

Corrects the Checksums for Figures when writing to the Portal, or back to your PC.

Writes data to both Data blocks for the Figure. So your edited data is there, no matter which data block the game reads from.


To do:
The Program can not identify All Imaginator Crystals. The program does recognize the Imaginator crystals that have been posted here but according to the Skylander Wiki, I am missing some dumps still. Thankfully it should be somewhat simple to find the missing figures Data as they follow a pattern. And I would only need to modify two bytes on the Dump at most to brute force find the missing values. I will post a follow up on what I have in terms of Crystal dumps.

The Fairy Skills writing may write all skills as obtained for that path, and not allow the user a more fine grained selection of skills.

Reading a Figure from the Portal needs to disable the Random Serial option/function.

Reading a Figure from the Portal needs to disable the ability to change the Figure's ID and/or Generation/Variant ID.

Traps (Not Trap Team Characters) are not editable yet. I need more information on their data structure and their data so I can create a new GUI interface for it. And what Data goes where on the Figure for the new GUI.

Superchargers Vehicles are identified but I don't know what data is where on the figure, outside of the Header Bytes, and what values are written, if any or if their data structure is different from a Charahcter Figure.

Imaginators Crystals are completely unknown for me. They should have the same header bytes, but beyond tat, their data structure is unknown. Editing these, would probably be an awesome feature to have but would require community effort and lots of dumps and me figuring out what data goes where. Resetting a Creator Crystal should be easy to implement though.

Reading and Writing via an Xbox 360 portal would be a nice feature to have but would require more effort for the user as well as myself to make that work. This is due to the Drivers for the Xbox 360 portal being unsigned. There is a way to fix this but it does require more technical know how for the end user as well. Also, the Xbox 360 portal will require more commands sent via USB compared to a Non-Xbox 360 portal. This is a low priority feature.


Known Editor Defects/issues:
The Program can NOT write Header Data to a blank MiFare (S50/Magic Chinese) Card via a the Game USB Portal. This is NOT a fault of the program, but how the Portal itself works/behaves. The Skylander Portal can be told "Write to the Header Blocks of the Figure/Card" but those commands are ignored by the portal itself.

This program does not write to external hardware like the ACR122u. It's not supported by this program.

Not all Figures are correctly identified. If you have a figure that is not identified by the editor, please let me know what it is supposed to be, and make sure your dump is valid/good.

Hats are editable on a single game basis even though you can set a hat for each game from Superchargers going backward to Adventures on a single figure.

If a Figure's Nickname, contains a NON-ASCII Character or characters, then the program will assume that the dump is encrypted. Even if the figure is not encrypted.

An Unknown figure shows the error message about "Unknown Figure" twice.

Attempting to Load a Maxander 2KB dump for a Swap Force Character's Top and Bottom Half, will not work. The program even mention that it thinks you are loading a Maxlander 2KB Dump file.

The Figure Detection method is not a thing. Loading any 1KB file will be treated as a tag. Any 2KB File is thought of as a Maxlander Dump for a Swapforce Character top and bottom half. But this does not create a valid Tag from a blank 1KB File.
