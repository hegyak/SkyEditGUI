Imports SkyReader_GUI.frmMain
Public Class Skills
	Shared Sub GetSkillPath()
		Dim SkillPathArea0(1) As Byte
		Dim SkillPathArea1(1) As Byte

		SkillPathArea0(0) = WholeFile(&H90)
		SkillPathArea0(1) = WholeFile(&H91)

		SkillPathArea1(0) = WholeFile(&H250)
		SkillPathArea1(1) = WholeFile(&H251)

		If Area0 > Area1 Then
			If SkillPathArea0(0) = &HFD Then
				frmMain.radLeft.Checked = True
			ElseIf SkillPathArea0(0) = &HFF Then
				frmMain.radRight.Checked = True
			Else
				frmMain.radNone.Checked = True
			End If
		ElseIf Area1 > Area0 Then
			If SkillPathArea1(0) = &HFD Then
				frmMain.radLeft.Checked = True
			ElseIf SkillPathArea1(0) = &HFF Then
				frmMain.radRight.Checked = True
			Else
				frmMain.radNone.Checked = True
			End If
		ElseIf Area0 = Area1 Then
			If SkillPathArea0(0) = &HFD Then
				frmMain.radLeft.Checked = True
			ElseIf SkillPathArea0(0) = &HFF Then
				frmMain.radRight.Checked = True
			Else
				frmMain.radNone.Checked = True
			End If
		End If
	End Sub

	Shared Sub WriteSkillPath()
		Dim SkillPath(1) As Byte
		'To Set the Skill Path to the Left it's, "FD 03"
		'To set the Skill Path to the Right it's "FF 03"
		If frmMain.radLeft.Checked = True Then
			SkillPath(0) = &HFD
			SkillPath(1) = &H3
		ElseIf frmMain.radRight.Checked = True Then
			SkillPath(0) = &HFF
			SkillPath(1) = &H3
		ElseIf frmMain.radNone.Checked = True Then
			SkillPath(0) = &H0
			SkillPath(1) = &HC
		End If

		'If Area0 > Area1 Then
		'Area 0 Skill Path
		WholeFile(&H90) = SkillPath(0)
		WholeFile(&H91) = SkillPath(1)
		'ElseIf Area1 > Area0 Then
		'Area 1 Skill Path
		WholeFile(&H250) = SkillPath(0)
		WholeFile(&H251) = SkillPath(1)
		'ElseIf Area0 = Area1 Then
		'Area 0 Skill Path
		'WholeFile(&H90) = SkillPath(0)
		'WholeFile(&H91) = SkillPath(1)
		'End If
	End Sub
End Class
