Private Sub Savage()
  'почистване под и вдясно от таблицата
  Range(Cells(5, Sheets("VRN_1_W_S").Cells(3, 5) + 2), Cells(Sheets("VRN_1_W_S").Cells(2, 5) + 5, Sheets("VRN_1_W_S").Cells(3, 5) + 4)).Clear
  
  Range(Cells(6 + Sheets("VRN_1_W_S").Cells(2, 5) + 1, 1), Cells(2 * Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 1, Sheets("VRN_1_W_S").Cells(3, 5) + 4)).Clear
  
'инициализация на матрицата на съжалението + 2 за щото се смята началния offset и този след таблицата и * 2, за да бъде същата таблица под първата
  For I = 6 + Sheets("VRN_1_W_S").Cells(2, 5) + 2 To 2 * Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2
  	'Добавяне на алтернативите V1, V2, V3, ...
    Sheets("VRN_1_W_S").Cells(I, 1).Value = "V" + CStr(I - Sheets("VRN_1_W_S").Cells(2, 5) - 7)
    'Попълване на крайната колона с нули, в който ще бъдат записани макс. стойности на всяко V
    Sheets("VRN_1_W_S").Cells(I, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Value = 0
    'Променяне на цвета на всяка крайна клетка в дадения
    Sheets("VRN_1_W_S").Cells(I, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Interior.Color = RGB(255, 255, 153)
  Next I
  
  'преименуване на реда с T1, T2, T3, ... аргументите
  For I = 2 To Sheets("VRN_1_W_S").Cells(3, 5) + 1
    Sheets("VRN_1_W_S").Cells(5, I).Value = "T" + CStr(I - 1)
  Next I
  
  
  For I = 6 To Sheets("VRN_1_W_S").Cells(2, 5) + 5
     For j = 2 To Sheets("VRN_1_W_S").Cells(3, 5) + 1
     'Обхождане на вътрешността на първата таблица и попълване на цвета с дадения
     Sheets("VRN_1_W_S").Cells(I, j).Interior.Color = RGB(255, 255, 153)
     
    Next j
  Next I
  
  'инициализация на MAX(V) и MAX(T) указателите
  Sheets("VRN_1_W_S").Cells(6 + Sheets("VRN_1_W_S").Cells(2, 5) + 1, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Value = "MAX(V)"
  Sheets("VRN_1_W_S").Cells(6 + Sheets("VRN_1_W_S").Cells(2, 5) + 1, 1) = "MAX(T)"
  
  'Обхождане на матрицата на съжалението и задаване на цвят и стойност = 0 на всяка клетка
  For I = 6 + Sheets("VRN_1_W_S").Cells(2, 5) + 2 To 2 * Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2
     For j = 2 To Sheets("VRN_1_W_S").Cells(3, 5) + 1
      Sheets("VRN_1_W_S").Cells(I, j).Interior.Color = RGB(255, 255, 153)
      Sheets("VRN_1_W_S").Cells(I, j).Value = 0
    Next j
  Next I
  
  'Обхождане на първата таблица по колони и намиране на максималната стойност на T, която отива в първия ред на съответна колона в матрицата на съжалението
    For j = 2 To Sheets("VRN_1_W_S").Cells(3, 5) + 1
    FW = -100000
    'Оптимизиране на кода като се ползва вградената функция WorksheetFunction.Max() за диапазона от първия ред на съответната колона до последния ред за същата колона "j"
       Sheets("VRN_1_W_S").Cells(Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2, j).Value = WorksheetFunction.Max(Range(Cells(6, j), Cells(Sheets("VRN_1_W_S").Cells(2, 5) + 5, j)))
    Next j
    
    
    'Обхождане на матрицата на съжалението по колони
    For j = 2 To Sheets("VRN_1_W_S").Cells(3, 5) + 1
   
       For I = 6 To Sheets("VRN_1_W_S").Cells(2, 5) + 5
       
            Sheets("VRN_1_W_S").Cells(I, j).Interior.Color = RGB(255, 153, 51)
            'Текущата клетка от обхожданата матрица = макс. записаното T - стойността на съответната клетка в първата таблица
            Sheets("VRN_1_W_S").Cells(I + Sheets("VRN_1_W_S").Cells(2, 5) + 2, j).Value = _
            Sheets("VRN_1_W_S").Cells(Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2, j).Value - _
            Sheets("VRN_1_W_S").Cells(I, j).Value
            'Изчакване на една секунда
            Wait 1000

       Next I
   Next j
      
    
   	'Обхождане на матрицата на съжалението по редове и намиране на макс. V за всеки ред
    FS_Opt = 100000
    For I = 6 + Sheets("VRN_1_W_S").Cells(2, 5) + 2 To 2 * Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2
 		'Оптимизиране на кода като се използва функцията WorksheetFunction.Max() за диапазона от първата клетка от матирцата на съжалението до крайната колона най-вдясно
         Sheets("VRN_1_W_S").Cells(I, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Value = WorksheetFunction.Max(Range(Cells(I,  1), Cells(I,  Sheets("VRN_1_W_S").Cells(3, 5) + 1)))

      
    Next I
    
    'От всички максимални стойности записани вдясно от матрицата на съжалението се намират най-малката алтернатива
    For I = 6 + Sheets("VRN_1_W_S").Cells(2, 5) + 2 To 2 * Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2
    'За да се обозначи обхождането цветът на клетките се променя в дадения
    Sheets("VRN_1_W_S").Cells(I, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Interior.Color = RGB(255, 153, 51)
    'Проверка дали стойността на текущата клетка е равен на най-малката стойност от всички в крайната дясна колона.
    'Като за целта се ползва WorksheetFunction.Min() за диапазона от първият най-десен ред до последния
      If Sheets("VRN_1_W_S").Cells(I, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Value = WorksheetFunction.Min(Range(Cells(6 + Sheets("VRN_1_W_S").Cells(2, 5) + 2,  Sheets("VRN_1_W_S").Cells(3, 5) + 2), Cells(2 * Sheets("VRN_1_W_S").Cells(2, 5) + 5 + 2, Sheets("VRN_1_W_S").Cells(3, 5) + 2))) Then
      'То тогава нека отговорът да се маркира в дадения цвят
        Sheets("VRN_1_W_S").Cells(I, Sheets("VRN_1_W_S").Cells(3, 5) + 2).Interior.Color = RGB(76, 153, 0)
      End If
    Next I
    
End Sub
