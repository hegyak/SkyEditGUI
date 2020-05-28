Imports SkyReader_GUI.FigureIO
Imports SkyReader_GUI.frmMain
Public Class Hero
	Shared Sub GetHero()
		Dim HeroArea0(1) As Byte
		Dim HeroValueArea0 As Double
		Dim HeroArea1(1) As Byte
		Dim HeroValueArea1 As Double


		HeroArea0(0) = WholeFile(&HDA)
		HeroArea0(1) = WholeFile(&HDB)
		HeroArea1(0) = WholeFile(&H29A)
		HeroArea1(1) = WholeFile(&H29B)

		Try
			HeroValueArea0 = BitConverter.ToInt16(HeroArea0, 0)
		Catch ex As Exception
			HeroValueArea0 = 0
		End Try
		Try
			HeroValueArea1 = BitConverter.ToInt16(HeroArea1, 0)
		Catch ex As Exception
			HeroValueArea1 = 0
		End Try
		If HeroValueArea0 > 100 Then
			HeroValueArea0 = 100
		End If
		If HeroValueArea1 > 100 Then
			HeroValueArea1 = 100
		End If
		Try
			If Area0 > Area1 Then
				frmMain.numHero.Value = CDec(HeroValueArea0)
			ElseIf Area1 > Area0 Then
				frmMain.numHero.Value = CDec(HeroValueArea1)
			ElseIf Area0 = Area1 Then
				frmMain.numHero.Value = CDec(HeroValueArea0)
			End If
		Catch ex As Exception
			frmMain.numHero.Value = 0
		End Try


	End Sub

	Shared Sub WriteHero()
        Dim intHero As Integer = frmMain.numHero.Value
        Dim Hero As Byte() = BitConverter.GetBytes(intHero)
        'If Area0 > Area1 Then
        'Area 0 Gold
        WholeFile(&HDA) = Hero(0)
        WholeFile(&HDB) = 0
        'ElseIf Area1 > Area0 Then
        'Area 1 Gold
        '1C0
        WholeFile(&H29A) = Hero(0)
        WholeFile(&H29B) = 0
        'ElseIf Area0 = Area1 Then
        'Area 0 Gold
        'WholeFile(&HDA) = Hero(0)
        'WholeFile(&HDB) = Hero(1)
        'End If
    End Sub
End Class