Private Sub Savage()

  Range(Cells(5, Sheets("VRN_1_W_S").Cells(3, 5) + 2), Cells(Sheets("VRN_1_W_S").Cells(2, 5) + 5, Sheets("VRN_1_W_S").Cells(3, 5) + 4)).Clear
  
  Range(Cells(6 + Sheets("VRN_1_W_S").Cells(2, 5) + 1, 1), Cells(2 * Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 1, Sheets("VRN_1_W_S").Cells(3, 5) + 4)).Clear
  

  For I = 6 + Sheets("VRN_1_W_S").Cells(2, 5) + 2 To 2 * Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2

    Sheets("VRN_1_W_S").Cells(I, 1).Value = "V" + CStr(I - Sheets("VRN_1_W_S").Cells(2, 5) - 7)

    Sheets("VRN_1_W_S").Cells(I, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Value = 0

    Sheets("VRN_1_W_S").Cells(I, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Interior.Color = RGB(255, 255, 153)
  Next I
  

  For I = 2 To Sheets("VRN_1_W_S").Cells(3, 5) + 1
    Sheets("VRN_1_W_S").Cells(5, I).Value = "T" + CStr(I - 1)
  Next I
  
  
  For I = 6 To Sheets("VRN_1_W_S").Cells(2, 5) + 5
     For j = 2 To Sheets("VRN_1_W_S").Cells(3, 5) + 1

     Sheets("VRN_1_W_S").Cells(I, j).Interior.Color = RGB(255, 255, 153)
     
    Next j
  Next I
  

  Sheets("VRN_1_W_S").Cells(6 + Sheets("VRN_1_W_S").Cells(2, 5) + 1, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Value = "MAX(V)"
  Sheets("VRN_1_W_S").Cells(6 + Sheets("VRN_1_W_S").Cells(2, 5) + 1, 1) = "MAX(T)"
  

  For I = 6 + Sheets("VRN_1_W_S").Cells(2, 5) + 2 To 2 * Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2
     For j = 2 To Sheets("VRN_1_W_S").Cells(3, 5) + 1
      Sheets("VRN_1_W_S").Cells(I, j).Interior.Color = RGB(255, 255, 153)
      Sheets("VRN_1_W_S").Cells(I, j).Value = 0
    Next j
  Next I
  

    For j = 2 To Sheets("VRN_1_W_S").Cells(3, 5) + 1
    FW = -100000

       Sheets("VRN_1_W_S").Cells(Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2, j).Value = WorksheetFunction.Max(Range(Cells(6, j), Cells(Sheets("VRN_1_W_S").Cells(2, 5) + 5, j)))
    Next j
    
   

    For j = 2 To Sheets("VRN_1_W_S").Cells(3, 5) + 1
   
       For I = 6 To Sheets("VRN_1_W_S").Cells(2, 5) + 5
       
            Sheets("VRN_1_W_S").Cells(I, j).Interior.Color = RGB(255, 153, 51)

            Sheets("VRN_1_W_S").Cells(I + Sheets("VRN_1_W_S").Cells(2, 5) + 2, j).Value = _
            Sheets("VRN_1_W_S").Cells(Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2, j).Value - _
            Sheets("VRN_1_W_S").Cells(I, j).Value

            Wait 1000

       Next I
   Next j
      
    

    FS_Opt = 100000
    For I = 6 + Sheets("VRN_1_W_S").Cells(2, 5) + 2 To 2 * Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2

         Sheets("VRN_1_W_S").Cells(I, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Value = WorksheetFunction.Max(Range(Cells(I,  1), Cells(I,  Sheets("VRN_1_W_S").Cells(3, 5) + 1)))

      
    Next I
    

    For I = 6 + Sheets("VRN_1_W_S").Cells(2, 5) + 2 To 2 * Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2

   Sheets("VRN_1_W_S").Cells(I, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Interior.Color = RGB(255, 153, 51)


      If Sheets("VRN_1_W_S").Cells(I, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Value = WorksheetFunction.Min(Range(Cells(6 + Sheets("VRN_1_W_S").Cells(2, 5) + 2,  Sheets("VRN_1_W_S").Cells(3, 5) + 2), Cells(2 * Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2, Sheets("VRN_1_W_S").Cells(3, 5) + 2))) Then

        Sheets("VRN_1_W_S").Cells(I, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Interior.Color = RGB(76, 153, 0)
      End If
    Next I
    
End Sub
