Imports SkyReader_GUI.FigureIO
Imports SkyReader_GUI.frmMain
Public Class Challenges
	Shared Sub GetChallenges()
		Dim HeroicChallengesArea0(3) As Byte
		Dim HeroicChallengesValueArea0 As Double
		Dim HeroicChallengesArea1(3) As Byte
		Dim HeroicChallengesValueArea1 As Double

		Dim Counter As Integer = 0
        Do Until Counter = 4
            HeroicChallengesArea0(Counter) = WholeFile(&HD6 + Counter)
            Counter += 1
        Loop
        Try
			HeroicChallengesValueArea0 = BitConverter.ToUInt32(HeroicChallengesArea0, 0)
		Catch ex As Exception
			HeroicChallengesArea0(0) = 0
			HeroicChallengesArea0(1) = 0
			HeroicChallengesArea0(2) = 0
			HeroicChallengesArea0(3) = 0
		End Try
		Counter = 0
        Do Until Counter = 4
            HeroicChallengesArea1(Counter) = WholeFile(&H296 + Counter)
            Counter += 1
        Loop
        Try
			HeroicChallengesValueArea1 = BitConverter.ToUInt32(HeroicChallengesArea1, 0)
		Catch ex As Exception
			HeroicChallengesArea1(0) = 0
			HeroicChallengesArea1(1) = 0
			HeroicChallengesArea1(2) = 0
			HeroicChallengesArea1(3) = 0
		End Try

        If HeroicChallengesValueArea0 > 4294967295 Then
            HeroicChallengesValueArea0 = 4294967295
        End If
        If HeroicChallengesValueArea1 > 4294967295 Then
            HeroicChallengesValueArea1 = 4294967295
        End If

        If Area0 > Area1 Then
			frmMain.numHeroicChallenges.Value = HeroicChallengesValueArea0
		ElseIf Area1 > Area0 Then
			frmMain.numHeroicChallenges.Value = HeroicChallengesValueArea1
		ElseIf Area0 = Area1 Then
			frmMain.numHeroicChallenges.Value = HeroicChallengesValueArea0
		End If

	End Sub
	Shared Sub WriteChallenges()
		Dim intHeroicChallenges As Long = frmMain.numHeroicChallenges.Value
		Dim HeroicChallenges As Byte() = BitConverter.GetBytes(intHeroicChallenges)

		Dim Counter As Integer = 0

		'ReCheck this write

		Do Until Counter = 4
			WholeFile(&HD6 + Counter) = HeroicChallenges(Counter)
			Counter += 1
		Loop

		Counter = 0
		Do Until Counter = 4
			WholeFile(&H296 + Counter) = HeroicChallenges(Counter)
			Counter += 1
		Loop

	End Sub
End Class
