# SkyReader-GUI

It's an editor for Figures from that game series.  It involves portals.
-----------------------------------------------------------------------------------------
DISCLAIMER
This is an ALPHA program at the moment.  It has issues.  It has bugs.  Using this, 
means you take responsiblity for anything you do with this program.
Detailed and though out Bug Reports help.
-----------------------------------------------------------------------------------------

Special thanks to silicontrip for his Skyreader which started this program.  And giving
the Hex Offsets I needed for most values and the limits of the values.

Special thanks to Jan Axelson for making the code examples to controlling HID devices from VB.NET

BIG Extra Special Thank you to SigmaDolphin for helping me out with the HID implimentation 
and answering questions I have.  And for acting as a "Partner" of a sort on this project.


ALWAYS KEEP A VALID BACKUP OF YOUR SKYLANDER BEFORE MODIFYING DATA

ALWAYS KEEP A VALID BACKUP OF YOUR SKYLANDER BEFORE MODIFYING DATA

ALWAYS KEEP A VALID BACKUP OF YOUR SKYLANDER BEFORE MODIFYING DATA


# What it can't do:
Edit or write Header Bytes using the Portal.  This is a Portal Hardware based issue.
Any bug reports suggesting that there is a "solution" using X and the Portal, will be closed.
The Portal will NOT write Header Bytes.  Ever.

Work with an Xbox 360/XBox One portal.  This is a software issue.
Both Drivers being unsinged and Xbox Peripheral security.


# What this program CAN do

Backup/Restore Figures to your System.

Edit All the values for the figure that you want.

Non-XBox Portals are supported natively in Windows 7, 8 and 10.

Detects Most Figures.

Works natively with Encrypted Dumps or Decrypted Dumps from other programs.


# TODO:

Identify/Read/Edit Trap contents.  Trap Figure editing does work.

Properly Edit Vehicles

Properly Edit Lower Half of Duo Characters.

More in Depth Skill Selection/Editing.

Properly Edit Imaginator Figures (Though it should work?)

Get ALL Figures Identified.


# USAGE:

Option 1: (All-in-One)
Connect a Non-Xbox 360 Portal to a Windows 7, 8 or 10 System.
Run the Program.
If your Portal is Detected, the Program will tell you "Portal Connected!"

If the Portal is not connected automatically, you can use the Menu Item,
"Connect to Portal" to attempt to manually find the Portal.

You can then read the figure data from the Portal.
This does a take a little bit of time.
Please only use one figure or one Duo Figure at a time.
If your using a Duo Figure, the Top half is read by selecting the first Read option.
The bottom half is read by the Second Read Option.

Set the values you want and then select the first write option, unless you are writing 
to the bottom half of a Duo Character.  Then use the Second Write option to write to the 
bottom half of a Duo Character.

The write method has Thread.Sleep because the Portal is not that quick.


Option 2:  (Bring your own Dump)
Run the Program.
Go to File -> Open
And select the Dump you made with another program.
Edit the file as you see fit.

Go to File -> Save Encrypted or File -> Save Decrypted to save your dump.
Then you can write the Dump back to the figure using another solution.


Please be aware, that this program can and WILL write ALL Non-Header Bytes.
YOU are Responsible for what your writing to your figure(s).


# CONTRIBUTE:

If you have figure ID information that I do not have, please let me know.

If you find a bug, please submit a Pull Request or steps to recreate the bug.

# CHANGELOG
ALPHA-1

First Public Release