Imports System.IO
Public Class Test

    Shared Sub Hats()
        Dim Reader As New StreamReader("hat_simulator.txt")
        Dim Line As String
        Dim Writer As New StreamWriter("hats2.txt")
        Dim SP(1) As String
        Do Until Reader.Peek = -1
            Line = Reader.ReadLine
            If Line.Contains(",") Then
                SP = Line.Split(",")
                Try
                    Writer.Write(SP(0) & ",")
                    Writer.WriteLine(Hex(SP(1)))
                Catch ex As Exception
                    Writer.Write(SP(0) & ",")
                    Writer.WriteLine(SP(1))
                End Try

            End If
        Loop
        Writer.Flush()
        Writer.Close()
    End Sub
    Shared Sub ParseIDs()
        Dim Reader As StreamReader = New StreamReader("Items.txt")
        Dim Writer As StreamWriter = New StreamWriter("IDs.txt")
        Dim Line As String
        Dim intFig As Integer = 0
        Dim FigureName As String
        Do Until Reader.Peek = -1
            Line = Reader.ReadLine
            If Line.StartsWith("ElseIf frmMain.lstCharacters.SelectedItem = ") Then
                FigureName = Line.Remove(0, 45)
                Writer.WriteLine("'" & FigureName)
            ElseIf Line.StartsWith("'") Then
                Writer.WriteLine(Line)
            End If
        Loop
        Writer.Flush()
        Writer.Close()
    End Sub

    Shared Sub GetVariants()
        Dim Reader As StreamReader = New StreamReader("IDs.txt")
        Dim Writer As StreamWriter = New StreamWriter("Vars.txt")
        Dim Var As String
        Do Until Reader.Peek = -1
            Reader.ReadLine() 'Name
            Reader.ReadLine() 'Gets ID
            Var = Reader.ReadLine() 'Gets Variant
            'MessageBox.Show(Var)
            Writer.WriteLine(Var)
        Loop
        Writer.Flush()
        Writer.Close()
    End Sub

    Shared Sub HatParse()
        Dim reader As StreamReader = New StreamReader("Hat.txt")
        Dim Writer As StreamWriter = New StreamWriter("Out.txt")
        Dim HatName As String() = {}
        Dim HexValue As String() = {}
        Dim Line As String
        Do Until reader.Peek = -1
            'Writer
            Line = reader.ReadLine
            If Line.Contains("ElseIf frmMain.cmbHat.SelectedItem =") = True Then
                HatName = Line.Split("=")

                HatName(1) = HatName(1).Replace(" Then", "")
                HatName(1) = HatName(1).Replace(Chr(34), "")
                'HatName(1))
                'ElseIf 
                reader.ReadLine()
                Line = reader.ReadLine
                HexValue = Line.Split("=")
                'MessageBox.Show(HexValue(1))
                HexValue(1) = HexValue(1).Replace(" ", "")
            End If
            'MessageBox.Show("^" & HexValue(1) & "^")
            If HexValue(1) = "&H" Then
                Writer.WriteLine("'elseIf Hat(0) = " & HexValue(1) & " Then")
                Writer.WriteLine("'frmMain.cmbHat.SelectedItem = %" & HatName(1) & "%")
            Else
                Writer.WriteLine("elseIf Hat(0) = " & HexValue(1) & " Then")
                Writer.WriteLine("frmMain.cmbHat.SelectedItem = %" & HatName(1) & "%")
            End If
        Loop
        Writer.Flush()
        Writer.Close()
    End Sub

    Shared Sub MakeMeCode()
        Dim Reader As StreamReader = New StreamReader("Min.txt")
        Dim Writer As StreamWriter = New StreamWriter("Code.txt")
        Dim Var As String
        Do Until Reader.Peek = -1
            Var = Reader.ReadLine
            Writer.WriteLine("Dim VariantID " & Var & "As StreamWriter = New StreamWriter(%" & Var & ".txt%)")
        Loop

        Reader = New StreamReader("Vars.txt")
        Do Until Reader.Peek = -1
            Var = Reader.ReadLine
            Writer.WriteLine("Case % " & Var & "%")
            Writer.WriteLine("VariantID" & Var & ".WriteLine(^case %^ & FigID & ^%^)")
            Writer.WriteLine("VariantID" & Var & ".WriteLine(Figname)")
            Writer.WriteLine("VariantID" & Var & ".WriteLine(^frmMain.lstCharacters.SelectedItem = %^ & FigName & ^%^)")
        Loop
        Writer.Flush()
        Writer.Close()
    End Sub
    Shared Sub EvenParseIDs()
        Dim Reader As StreamReader = New StreamReader("IDs.txt")
        'Dim Writer As StreamWriter = New StreamWriter("Out.txt")
        Dim FigName As String
        Dim FigID As String
        Dim VariantID As String
        Dim VariantID0D45 As StreamWriter = New StreamWriter("0D45.txt")
        Dim VariantID0E45 As StreamWriter = New StreamWriter("0E45.txt")
        Dim VariantID0040 As StreamWriter = New StreamWriter("0040.txt")
        Dim VariantID0041 As StreamWriter = New StreamWriter("0041.txt")
        Dim VariantID0244 As StreamWriter = New StreamWriter("0244.txt")
        Dim VariantID0245 As StreamWriter = New StreamWriter("0245.txt")
        Dim VariantID0344 As StreamWriter = New StreamWriter("0344.txt")
        Dim VariantID0345 As StreamWriter = New StreamWriter("0345.txt")
        Dim VariantID0440 As StreamWriter = New StreamWriter("0440.txt")
        Dim VariantID1E44 As StreamWriter = New StreamWriter("1E44.txt")
        Dim VariantID1038 As StreamWriter = New StreamWriter("1038.txt")
        Dim VariantID1048 As StreamWriter = New StreamWriter("1048.txt")
        Dim VariantID1138 As StreamWriter = New StreamWriter("1138.txt")
        Dim VariantID1545 As StreamWriter = New StreamWriter("1545.txt")


        Do Until Reader.Peek = -1
            FigName = Reader.ReadLine()
            FigID = Reader.ReadLine()
            VariantID = Reader.ReadLine()
            Try
                VariantID = VariantID.Remove(0, 1)
            Catch ex As Exception
                MessageBox.Show(VariantID)
            End Try


            'MessageBox.Show(VariantID)
            Select Case VariantID

            End Select

        Loop
        'VariantID0030.Close()
        'VariantID0138.Close()
        'VariantID023C.Close()
        'VariantID0234.Close()
        'VariantID0334.Close()
        'VariantID0538.Close()
        'VariantID0938.Close()
        'VariantID1038.Close()
    End Sub


    Shared Sub IFs()
        Dim Reader As StreamReader = New StreamReader("Super.txt")
        Dim Writer As StreamWriter = New StreamWriter("Output.txt")
        Dim INP As String
        Dim Var As String
        Dim yourStrings(1) As String
        Do Until Reader.Peek = -1
            INP = Reader.ReadLine()
            If INP.StartsWith("End If") Then
                'Done
                Writer.Flush()
                Writer.Close()
            ElseIf INP.StartsWith("ElseIf ") Then
                'Write the ElseIf Line
                Writer.WriteLine(INP)
            ElseIf INP.StartsWith("'") And INP.Length = 5 Then
                'MessageBox.Show(INP)
                Writer.WriteLine(INP)
                Var = Reader.ReadLine
                Writer.WriteLine(Var)
                yourStrings(0) = INP.Remove(0, 1)
                yourStrings(0) = yourStrings(0).Remove(2, 2)
                'MessageBox.Show(yourStrings(0))
                yourStrings(1) = INP.Remove(0, 3)
                'MessageBox.Show(yourStrings(1))
                Writer.WriteLine("CharacterID(0) = &H" & yourStrings(0))
                Writer.WriteLine("CharacterID(1) = &H" & yourStrings(1))
                yourStrings(0) = Var.Remove(0, 1)
                yourStrings(0) = yourStrings(0).Remove(2, 2)
                'MessageBox.Show(yourStrings(0))
                yourStrings(1) = Var.Remove(0, 3)
                'MessageBox.Show(yourStrings(1))
                Writer.WriteLine("CharacterVariant(0) = &H" & yourStrings(0))
                Writer.WriteLine("CharacterVariant(1) = &H" & yourStrings(1))
            ElseIf INP.StartsWith("MessageBox.Show(") Then
                Writer.WriteLine(INP)
            End If

        Loop
        MessageBox.Show("Done")
    End Sub



    'Junk Code.

End Class
