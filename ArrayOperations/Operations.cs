using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace ArrayOperations
{
    public  class Operations
    {



        public int[,] _array;
        public int[,] _array2 ;
        
        public int _selection { get; set; }
        public int _rowsSize { get; set; } = 10;

        public int _colSize { get; set; } = 10;

        public void start()
        {

            do
            {
                Console.WriteLine(showMenu());
                try
                {

                    _selection = int.Parse(Console.ReadLine());
                    switch (_selection)
                    {

                        case 0:
                            colorFontPrint("Program terminated successfully", false);
                            break;
                        case 1:
                            createArray(ref _array);

                            break;
                        case 2:
                            multiply(ref _array);
                            break;
                        case 3:
                           
                                transpose(ref _array, printArray);
                           

                            break;

                        case 4:
                            //  revertArray();
                            rotate(ref _array);
                            break;
                        case 5:
                            //  revertArray();
                            shift(ref _array);
                            break;
                        case 6:
                            //  revertArray();
                            addRow(ref _array);
                            break;
                        case 7:
                            //  revertArray();
                            addColumn(ref _array);
                            break;

                        default:
                            colorFontPrint("Unknown input please retry");
                            break;
                    }
                }
                catch (Exception ex)
                {

                    colorFontPrint(ex.Message);
                    _selection = -1;
                }
            } while (_selection != 0);
        }
        public string showMenu()
        {

            return "Please select:\n 0)Quit\n 1)Create an array\n 2)Multiply an array\n 3)Transpose an array\n 4)Rotate an array \n 5)Shift an array \n6)Add Row \n 7)Add Column";

        }


        public bool validateElement(dynamic element)
        {

            try
            {

              

                if (  decimal.TryParse(element, out decimal Fnumber) || new Regex("^[a-zA-Z]*$").IsMatch(element))
                {
                    return true;
                }
               
              
                colorFontPrint($"{element} is not allowed");
                return false;
            }
            catch (Exception ex)
            {
                colorFontPrint(ex.Message);
            }
            return false;
        }

        public bool createArray(ref int[,] arr)
        {




       

                try
                {

                    Console.WriteLine("Enter row size");
                    _rowsSize = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter column size");
                    _colSize = int.Parse(Console.ReadLine());
                arr = new int[_rowsSize, _colSize];

                for (int row = 0; row < arr.GetLength(0); row++)
                {
                    for (int col = 0; col < arr.GetLength(1); col++)
                    {
                        Console.WriteLine($"Enter for [{row},{col}]");
                        try
                        {
                            arr[row, col] = int.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            colorFontPrint(ex.Message);

                           
                        }
                    }
                }
                printArray(arr);
                     return true;
                }
                catch (Exception ex)
                {

                   
                    colorFontPrint($"{ex.Message}");

                    return false;
                }

               
     





        
        }

        public bool isMulable(int[,] first,int[,] second)
        {
            if (first.GetLength(1)!=second.GetLength(0))
            {
                return false;
            }
            return true;
        }
        public void multiply(ref int[,] arr)
        {

            if (_array!=null && _array.GetLength(0)>0)
            {
                if (createArray(ref _array2))
                {
                    //only multiplyable if no of col = no of rows
                    if (isMulable(arr, _array2))
                    {
                        //creating new resultant matrix which will be equ to no of rows of first and no of col of 2nd matrix
                      
                       //equal matrix case
                        if (arr.GetLength(0)==_array2.GetLength(0) && (arr.GetLength(1) == _array2.GetLength(1)))
                        {
                            int[,] _tempArray = new int[arr.GetLength(0), arr.GetLength(1)];
                            for (int row = 0; row < arr.GetLength(0); row++)
                            {
                                for (int col = 0; col < arr.GetLength(1); col++)
                                {
                                    for (int r = 0; r <1; r++)
                                    {
                                        int sum = 0;
                                        for (int c = 0; c < _array2.GetLength(0); c++)
                                        {
                                            sum += (arr[row, c] * _array2[c, col]);
                                       
                                        }
                                        _tempArray[row, col] = sum;
                                    }
                                   
                                }
                               
                            }
                          
                            Console.WriteLine("Before");
                            printArray(arr);
                            arr = _tempArray;
                            Console.WriteLine("After");
                            printArray(arr);
                            colorFontPrint("Successfully multiplied", false);
                        }
                        if (arr.GetLength(0) > _array2.GetLength(0))
                        {
                           // colorFontPrint($"Not implemented case matrix A rows > matrix B rows");
                        }
                        else
                        {
                           // colorFontPrint($"Not implemented case matrix B rows > matrix A rows");

                        }

                    }
                    else
                    {

                        colorFontPrint("cannot mul matrix no of col in matrix A not eq to no of rows of B");
                    }
                }
                else
                {
                    colorFontPrint("could not create matrix");
                }
            }
            else
            {
                colorFontPrint("please create array first");
            }
           
            

        }
        public void printArray(int[,] arr)
        {


            if (arr != null && arr.Length > 0)
            {
                Console.WriteLine("Array stored are");
                try
                {
                    for (int row = 0; row <arr.GetLength(0); row++)
                    {
                        for (int col = 0; col < arr.GetLength(1); col++)
                        {
                            Console.Write($"{arr[row, col]}\t");
                        }
                        Console.WriteLine();

                    }
                }
                catch (Exception ex)
                {

                    colorFontPrint(ex.Message);
                }
              
               
            }
        }
        public void rotate(ref int[,] arr)
        {
            try
            {

                if (_array != null && _array.GetLength(0) > 0)
                {
                    Console.WriteLine("Please select rotation\n 1)Rotate Clockwise \n 2)Rotate Anticlock");

                    int type = int.Parse(Console.ReadLine());
                    switch (type)
                    {
                        case 1:
                            try
                            {
                                rotateRight(ref arr, printArray);
                            }
                            catch (Exception ex)
                            {

                                colorFontPrint(ex.Message);
                            }
                            break;
                        case 2:
                            rotateLeft(ref arr, printArray);
                            break;


                        default:
                            Console.WriteLine("Invalid selection");
                            break;
                    }
                }
                else
                {

                    colorFontPrint("Please create array first");
                }
               
            }
            catch (Exception ex)
            {
                colorFontPrint(ex.Message);

            }
        }


        public void shift(ref int[,] arr)
        {
            try
            {

                if (_array != null && _array.GetLength(0) > 0)
                {
                    Console.WriteLine("Please select shift\n 1)Shift left \n 2)Shift Right");

                    int type = int.Parse(Console.ReadLine());
                    switch (type)
                    {
                        case 1:
                            shiftLeft(ref arr, printArray);
                            break;
                        case 2:
                            shiftRight(ref arr, printArray);
                            break;


                        default:
                            Console.WriteLine("Invalid selection");
                            break;
                    }

                }
                else
                {

                    colorFontPrint("Please insert array first");
                }
            }
            catch (Exception ex)
            {

                colorFontPrint(ex.Message);
            }
        }


        public void colorFontPrint(string message,bool isWarning=true)
        {
            Console.ForegroundColor = isWarning == true? ConsoleColor.Red:ConsoleColor.Green;
             Console.WriteLine(message);
            
            Console.ForegroundColor = ConsoleColor.White;
        }

        public  int[,] rotateRight(ref int[,] arr, Action<int[,]> print)
        {
            Console.WriteLine("Before rotate right");
            print(arr);
            int[,] tempArray = new int[arr.GetLength(0), arr.GetLength(1)];

            try
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    int _tempRow = 0;
                    for (int row = arr.GetLength(0) - 1; row >= 0; row--)
                    {
                        tempArray[col, _tempRow] = arr[row, col];
                        _tempRow++;
                    }

                }
                arr = tempArray;

                Console.WriteLine("After rotate right");

                print(arr);
                colorFontPrint("Successfully rotate right", false);
            }
            catch (Exception ex)
            {
                colorFontPrint(ex.Message);
            }



            return arr;

        }
        public   int[,] rotateLeft(ref int[,] arr, Action<int[,]> print)
        {
            Console.WriteLine("Before rotate left");
            print(arr);
            int[,] tempArray = new int[arr.GetLength(0), arr.GetLength(1)];

            try
            {
                int _tempCol = arr.GetLength(1)-1;
                for (int row = 0; row < tempArray.GetLength(0); row++)
                {
                   
                    for (int col =0;col< tempArray.GetLength(1) ; col++)
                    {
                        tempArray[row, col] = arr[col, _tempCol];
                       
                    }
                    _tempCol--;

                }
                arr = tempArray;

                Console.WriteLine("After rotate left");

                print(arr);
                colorFontPrint("Successfully rotate left", false);
            }
            catch (Exception ex)
            {
                colorFontPrint(ex.Message);
            }



            return arr;
        }


       public   int[,] transpose(ref int[,] arr, Action<int[,]> print)
        {

            if (_array != null && _array.GetLength(0) > 0)
            {
                if (_array.GetLength(0)==_array.GetLength(1))
                {
                  

                    Console.WriteLine("Before transpose");
                    print(arr);
                    int[,] tempArray = new int[arr.GetLength(0), arr.GetLength(1)];

                    try
                    {

                        for (int col = 0; col < arr.GetLength(1); col++)
                        {
                            for (int row = arr.GetLength(0) - 1; row >= 0; row--)
                            {
                                tempArray[col, row] = arr[row, col];
                            }
                        }
                        arr = tempArray;
                        Console.WriteLine("After transpose");
                        print(arr);
                        colorFontPrint("Successfully transpose", false);
                    }
                    catch (Exception ex)
                    {
                        colorFontPrint(ex.Message);
                    }
                }
                else
                {

                    colorFontPrint("Row and column length must be equal in order to transpose");
                }
            }
            else
            {

                colorFontPrint("Please enter array first");
            }
               



            return arr;
        }

        public int[,] shiftLeft(ref int[,] arr,Action<int[,]> print)
        {
            Console.WriteLine("Before shift left");
            print(arr);
            try
            {
                Console.WriteLine("Enter row to shift left");
                int _shiftRow = int.Parse(Console.ReadLine());
                if (_shiftRow<=arr.GetLength(0))
                {
                  
                    int _temp=-1;
                   
                        
                        for (int col = arr.GetLength(1)-1; col >=0; col--)
                        {
                            int _tempPos =  (col - 1 <0) ? arr.GetLength(1)-1 : col - 1;

                            if (_temp==-1)
                            {
                                _temp = arr[_shiftRow, _tempPos];

                                arr[_shiftRow, _tempPos] = arr[_shiftRow, col];
                            }
                            else
                            {
                                //previous temp
                                int _tmp = _temp;
                                //current temp
                                _temp = arr[_shiftRow, _tempPos];
                                arr[_shiftRow, _tempPos] = _tmp;
                            
                            }
                         

                           


                        }
                       
                    
                    print(arr);

                    colorFontPrint("Successfully shift left", false);
                }
                else
                {
                    Console.WriteLine($"No row exist on position {_shiftRow}");
                }
               
            }
            catch (Exception ex)
            {
                colorFontPrint(ex.Message);
               
            }
            return arr;
        }




        public int[,] shiftRight(ref int[,] arr, Action<int[,]> print)
        {
            Console.WriteLine("Before shift right");
            print(arr);
            try
            {
                Console.WriteLine("Enter row to shift right");
                int _shiftRow = int.Parse(Console.ReadLine());
                if (_shiftRow <= arr.GetLength(0))
                {

                    int _temp = -1;
                  

                        for (int col = 0; col< arr.GetLength(1); col++)
                        {
                            int _tempPos = (col + 1 > arr.GetLength(1)-1) ? 0 : col +1;

                            if (_temp == -1)
                            {
                                _temp = arr[_shiftRow, _tempPos];

                                arr[_shiftRow, _tempPos] =  arr[_shiftRow,col];
                            }
                            else
                            {
                                //previous temp
                                int _tmp = _temp;
                                //current temp
                                _temp = arr[_shiftRow, _tempPos];
                                arr[_shiftRow, _tempPos] =  _tmp;

                            }





                        }

                   

                }
                else
                {
                    Console.WriteLine($"No row exist on position {_shiftRow}");
                }
                print(arr);

                colorFontPrint("Successfully shift right", false);
            }
            catch (Exception ex)
            {
                colorFontPrint(ex.Message);

            }
            return arr;
        }


        public void addRow(ref int[,] arr)
        {
            try
            {


                if (arr==null)
                {
                    colorFontPrint("Please create array first");
                }
                else
                {
                    int _actualRow = arr.GetLength(1);
                ResizeArray(ref arr, 1, 0);

                if (ResizeArray(ref arr, 0, 1).GetLength(1) > _actualRow)

                {
                    colorFontPrint("Please enter column values");

                    for (int col = 0; col < arr.GetLength(1); col++)
                    {
                        for (int row = arr.GetLength(0); row <= arr.GetLength(0); row++)
                        {
                            Console.WriteLine($"Enter row {row} col {col}");
                            try
                            {
                                arr[row, col] = int.Parse(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {

                                colorFontPrint(ex.Message);
                            }
                        }
                    }
                }


            }

            }
            catch (global::System.Exception ex)
            {

                throw;
            }
        }



        public void addColumn(ref int[,] arr)
        {
            try
            {

                if (arr==null)
                {
                    colorFontPrint("Please create array first");
                }
                else
                {


                    int _actualCol = arr.GetLength(1);
                    if (ResizeArray(ref arr, 0, 1).GetLength(1) > _actualCol)
                    {
                        colorFontPrint("Please enter column values");

                        for (int row = 0; row < arr.GetLength(0); row++)
                        {
                            for (int col = arr.GetLength(1); col <= arr.GetLength(1); col++)
                            {
                                Console.WriteLine($"Enter row {row} col {col}");
                                try
                                {
                                    arr[row, col] = int.Parse(Console.ReadLine());
                                }
                                catch (Exception ex)
                                {

                                    colorFontPrint(ex.Message);
                                }
                            }
                        }
                    }
                    }
               
                
                
            }
            catch (global::System.Exception ex)
            {

                throw;
            }
        }

        T[,] ResizeArray<T>(ref T[,] original, int rows, int cols)
        {
            var newArray = new T[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
            return newArray;
        }

    }





}
