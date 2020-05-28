Imports SkyReader_GUI.FigureIO
Public Class Web_Code
    Dim blnLoading_Web_Code As Boolean = False
    Shared Sub Load()
        'This math SUCKS
        Dim Hex_Web_Code As String = WholeFile(&H14).ToString("X2") + WholeFile(&H15).ToString("X2") + WholeFile(&H16).ToString("X2") + WholeFile(&H17).ToString("X2") +
            WholeFile(&H18).ToString("X2") + WholeFile(&H19).ToString("X2") + WholeFile(&H1A).ToString("X2") + WholeFile(&H1B).ToString("X2")
        'frmMain.txtWebCodeHex.Text = Hex_Web_Code
        Dim Total_Web_Code As Decimal = WholeFile(&H14) + WholeFile(&H15) * 16 ^ 2 + WholeFile(&H16) * 16 ^ 4 + WholeFile(&H17) * 16 ^ 6 +
            WholeFile(&H18) * 16 ^ 8 + WholeFile(&H19) * 16 ^ 10 + WholeFile(&H1A) * 16 ^ 12
        'MessageBox.Show(Total_Web_Code)

        Dim Code() As String = {"2", "3", "4", "5", "6", "7", "8", "9", "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Y", "Z"}

        'What I need to do:
        'Add all values from the WebCode together (Done)
        'Take the Total_Web_Code then divide by 29 and DROP Decimal Rounding Down
        'Do Math.  Take the Total from the Above Value on the "List" and Divide by 29, keeping it Decimal.
        'Then Subtract the Non-Decimal Number from the Decimal Number.  Leaving you, a Decimal.  Then multiply the result by 29.
        Try
            Dim First_Web_Code_Char_Down As Decimal = 0
            Dim First_Web_Code_Char_Dec As Decimal = 0
            First_Web_Code_Char_Down = Fix(Total_Web_Code / 29)
            First_Web_Code_Char_Dec = ((Total_Web_Code / 29) - First_Web_Code_Char_Down) * 29

            Dim Second_Web_Code_Char_Down As Decimal = 0
            Dim Second_Web_Code_Char_Dec As Decimal = 0
            Second_Web_Code_Char_Down = Fix(First_Web_Code_Char_Down / 29)
            Second_Web_Code_Char_Dec = ((First_Web_Code_Char_Down / 29) - Second_Web_Code_Char_Down) * 29

            Dim Third_Web_Code_Char_Down As Decimal = 0
            Dim Third_Web_Code_Char_Dec As Decimal = 0
            Third_Web_Code_Char_Down = Fix(Second_Web_Code_Char_Down / 29)
            Third_Web_Code_Char_Dec = ((Second_Web_Code_Char_Down / 29) - Third_Web_Code_Char_Down) * 29

            Dim Fourth_Web_Code_Char_Down As Decimal = 0
            Dim Fourth_Web_Code_Char_Dec As Decimal = 0
            Fourth_Web_Code_Char_Down = Fix(Third_Web_Code_Char_Down / 29)
            Fourth_Web_Code_Char_Dec = ((Third_Web_Code_Char_Down / 29) - Fourth_Web_Code_Char_Down) * 29

            Dim Fifth_Web_Code_Char_Down As Decimal = 0
            Dim Fifth_Web_Code_Char_Dec As Decimal = 0
            Fifth_Web_Code_Char_Down = Fix(Fourth_Web_Code_Char_Down / 29)
            Fifth_Web_Code_Char_Dec = ((Fourth_Web_Code_Char_Down / 29) - Fifth_Web_Code_Char_Down) * 29

            Dim Sixth_Web_Code_Char_Down As Decimal = 0
            Dim Sixth_Web_Code_Char_Dec As Decimal = 0
            Sixth_Web_Code_Char_Down = Fix(Fifth_Web_Code_Char_Down / 29)
            Sixth_Web_Code_Char_Dec = ((Fifth_Web_Code_Char_Down / 29) - Sixth_Web_Code_Char_Down) * 29

            Dim Seventh_Web_Code_Char_Down As Decimal = 0
            Dim Seventh_Web_Code_Char_Dec As Decimal = 0
            Seventh_Web_Code_Char_Down = Fix(Sixth_Web_Code_Char_Down / 29)
            Seventh_Web_Code_Char_Dec = ((Sixth_Web_Code_Char_Down / 29) - Seventh_Web_Code_Char_Down) * 29

            Dim Eighth_Web_Code_Char_Down As Decimal = 0
            Dim Eighth_Web_Code_Char_Dec As Decimal = 0
            Eighth_Web_Code_Char_Down = Fix(Seventh_Web_Code_Char_Down / 29)
            Eighth_Web_Code_Char_Dec = ((Seventh_Web_Code_Char_Down / 29) - Eighth_Web_Code_Char_Down) * 29

            Dim Nineth_Web_Code_Char_Down As Decimal = 0
            Dim Nineth_Web_Code_Char_Dec As Decimal = 0
            Nineth_Web_Code_Char_Down = Fix(Eighth_Web_Code_Char_Down / 29)
            Nineth_Web_Code_Char_Dec = ((Eighth_Web_Code_Char_Down / 29) - Nineth_Web_Code_Char_Down) * 29

            Dim Tenth_Web_Code_Char_Down As Decimal = 0
            Dim Tenth_Web_Code_Char_Dec As Decimal = 0
            Tenth_Web_Code_Char_Down = Fix(Nineth_Web_Code_Char_Down / 29)
            Tenth_Web_Code_Char_Dec = ((Nineth_Web_Code_Char_Down / 29) - Tenth_Web_Code_Char_Down) * 29

            Dim Web_Code As String = Code(Tenth_Web_Code_Char_Dec) & Code(Nineth_Web_Code_Char_Dec) & Code(Eighth_Web_Code_Char_Dec) & Code(Seventh_Web_Code_Char_Dec) &
                Code(Sixth_Web_Code_Char_Dec) & "-" & Code(Fifth_Web_Code_Char_Dec) & Code(Fourth_Web_Code_Char_Dec) & Code(Third_Web_Code_Char_Dec) &
                Code(Second_Web_Code_Char_Dec) & Code(First_Web_Code_Char_Dec)
            If Web_Code = "22222-22222" Then
                frmMain.lblWebCode.Text = "N/A"
                Exit Sub
            End If
            frmMain.lblWebCode.Text = frmMain.lblWebCode.Text & Code(Tenth_Web_Code_Char_Dec) & Code(Nineth_Web_Code_Char_Dec) & Code(Eighth_Web_Code_Char_Dec) & Code(Seventh_Web_Code_Char_Dec) &
                Code(Sixth_Web_Code_Char_Dec) & "-" & Code(Fifth_Web_Code_Char_Dec) & Code(Fourth_Web_Code_Char_Dec) & Code(Third_Web_Code_Char_Dec) &
                Code(Second_Web_Code_Char_Dec) & Code(First_Web_Code_Char_Dec)
        Catch ex As Exception
            frmMain.SaldeStatus.Text = "Error: The Web Code Parsing caused an error."
        End Try
    End Sub
End Class
