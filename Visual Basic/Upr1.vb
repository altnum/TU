REM  *****  BASIC  *****
Option VBASupport 1
Sub Main()
  Range("A4:AA10000").Clear
  
  
  For I = 5 To Sheets("VRRN_1").Cells(1, 2) + 4
    Sheets("VRRN_1").Cells(I, 1).Value = "V" + CStr(I - 4)
  Next I
 For I = 2 To Sheets("VRRN_1").Cells(2, 2) + 1
    Sheets("VRRN_1").Cells(4, I).Value = "T" + CStr(I - 1)
  Next I
  For I = 5 To Sheets("VRRN_1").Cells(1, 2) + 4
     For j = 2 To Sheets("VRRN_1").Cells(2, 2) + 1
     Sheets("VRRN_1").Cells(I, j).Interior.Color = RGB(255, 255, 153)
     Sheets("VRRN_1").Cells(I, j).Value = Int(100 * Rnd())
    Next j
  Next I
    
End Sub

Private Sub Wald()
  'Критерий на Уолд
  
  Range(Cells(5, Sheets("VRRN_1").Cells(1, 2) + 2), Cells(Sheets("VRRN_1").Cells(1, 2) + 5, Sheets("VRRN_1").Cells(2, 2) + 2)).Clear
  
  Range(Cells(4 + Sheets("VRRN_1").Cells(1, 2) + 1, 1), Cells(2 * Sheets("VRRN_1").Cells(1, 2) + 5 + 1, Sheets("VRRN_1").Cells(2, 2) + 2)).Clear
   
  
  Dim FW As Double
  FW_Opt = -100000
  For I = 5 To Sheets("VRRN_1").Cells(1, 2) + 4
  FW = 100000
    For j = 2 To Sheets("VRRN_1").Cells(2, 2) + 1
      
         Sheets("VRRN_1").Cells(I, j).Interior.Color = RGB(255, 153, 51)
         Wait 1000
         
         If FW > Sheets("VRRN_1").Cells(I, j).Value Then
            FW = Sheets("VRRN_1").Cells(I, j).Value
            Sheets("VRRN_1").Cells(I, Sheets("VRRN_1").Cells(2, 2) + 2).Value = FW
         End If
         
       Next j
     
     If FW_Opt < FW Then
       FW_Opt = FW
     End If
    Next I
    
    For I = 5 To Sheets("VRRN_1").Cells(1, 2) + 4
    Sheets("VRRN_1").Cells(I, Sheets("VRRN_1").Cells(2, 2) + 2).Interior.Color = RGB(255, 153, 51)
      If Sheets("VRRN_1").Cells(I, Sheets("VRRN_1").Cells(2, 2) + 2) = FW_Opt Then
        Sheets("VRRN_1").Cells(I, Sheets("VRRN_1").Cells(2, 2) + 2).Interior.Color = RGB(76, 153, 0)
      End If
    Wait 1000
    Next I
End Sub