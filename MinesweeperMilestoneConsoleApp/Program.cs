using MinesweeperMilstoneClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperMilestoneConsoleApp
{
    internal class Program
    {
        static Board myBoard = new Board(11);
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            bool gameEnded = false;
            myBoard.setupLiveNeighbors(15);
            while (gameEnded == false)
            {

                PrintBoard();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Enter a Column Number ");
                int.TryParse(Console.ReadLine(), out int columnNumber);
                Console.WriteLine("Enter a Row Number ");
                int.TryParse(Console.ReadLine(), out int rowNumber);
                try
                {
                    myBoard.theGrid[rowNumber, columnNumber].Visited = true;
                    myBoard.CheckLiveNeighbors(myBoard.theGrid[rowNumber, columnNumber]);

                }
                catch { continue; }
                if (myBoard.theGrid[rowNumber, columnNumber].Neighbors == 0)
                {
                    OpenNeighborsVoidCells(myBoard.theGrid[rowNumber, columnNumber]);
                }

                if (myBoard.theGrid[rowNumber, columnNumber].Live == true)
                {
                    gameEnded = true;
                    PrintBoard();
                    Console.WriteLine("You are LOSE!");
                }
                else if(isAllCellsOpen())
                {
                    gameEnded = true;
                    PrintBoard();
                    Console.WriteLine("You are WIN!");
                }
            }



            Console.ReadLine();
        }

        private static void OpenNeighborsVoidCells(Cell curCell)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    try
                    {
                        myBoard.CheckLiveNeighbors(myBoard.theGrid[curCell.RowNumber + i, curCell.ColumnNumber + j]);
                        if (myBoard.theGrid[curCell.RowNumber + i, curCell.ColumnNumber + j].Neighbors == 0 && myBoard.theGrid[curCell.RowNumber + i, curCell.ColumnNumber + j].Visited==false)
                        {
                            myBoard.theGrid[curCell.RowNumber + i, curCell.ColumnNumber + j].Visited = true;
                            OpenNeighborsVoidCells(myBoard.theGrid[curCell.RowNumber + i, curCell.ColumnNumber + j]);
                        }
                        else
                        {
                            myBoard.theGrid[curCell.RowNumber + i, curCell.ColumnNumber + j].Visited = true;
                        }
                    }
                    catch { }
                }
            }
        }

        private static bool isAllCellsOpen()
        {
            bool isWin = true;
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    if (myBoard.theGrid[i, j].Visited == false && myBoard.theGrid[i, j].Live == false)
                    {
                        isWin = false; break;
                    }
                }

            }
            return isWin;
        }

        public static void PrintBoard()//
        {
            for (int i = 0; i < myBoard.Size; i++)
            {
                Console.Write("  " + i + " ");
            }

            Console.WriteLine();
            Console.WriteLine(DrawHorizontalLine(myBoard.Size));


            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    if (myBoard.theGrid[i, j].Visited)
                    {
                        if (myBoard.theGrid[i, j].Live)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("| * ");
                        }
                        else if (myBoard.CheckLiveNeighbors(myBoard.theGrid[i, j]))
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("| " + myBoard.theGrid[i, j].Neighbors.ToString() + " ");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            
                            Console.Write("|   ");
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.Write("| ? ");
                    }
                }
                Console.BackgroundColor= ConsoleColor.Black;
                Console.Write("|  " + i);
                Console.WriteLine();
                Console.WriteLine(DrawHorizontalLine(myBoard.Size));
            }
        }

        //public static void DrawGrid()//
        //{
        //    for (int i = 0; i < myBoard.Size; i++)
        //    {
        //        Console.Write("  " + i + " ");
        //    }

        //    Console.WriteLine();
        //    Console.WriteLine(DrawHorizontalLine(myBoard.Size));
        //    for (int i = 0; i < myBoard.Size; i++)
        //    {
        //        for (int j = 0; j < myBoard.Size; j++)
        //        {
        //            if (myBoard.theGrid[i, j].Live)
        //            {
        //                Console.Write("| * ");
        //            }
        //            else if (myBoard.CheckLiveNeighbors(myBoard.theGrid[i, j]))
        //            {
        //                Console.Write("| " + myBoard.theGrid[i, j].Neighbors.ToString() + " ");
        //            }
        //            else
        //            {
        //                Console.Write("| 0 ");
        //            }
        //        }
        //        Console.Write("|  " + i);
        //        Console.WriteLine();
        //        Console.WriteLine(DrawHorizontalLine(myBoard.Size));
        //    }
        //}


        private static string DrawHorizontalLine(int size)///
        {
            string line = "";
            for (int i = 0; i < size; i++) { line += "----"; }
            return line;
        }
    }
}
