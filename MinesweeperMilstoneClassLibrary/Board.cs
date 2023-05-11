using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperMilstoneClassLibrary
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }
        public int Difficulty { get; set; }


        public Board(int size)
        {
            Size = size;
            theGrid = new Cell[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
            Difficulty = 1;
            
        }

        public void setupLiveNeighbors(int bombs)
        {
            Random rnd = new Random();
            for (int i = 0; i < bombs; i++)
            {
                int x = rnd.Next(0,Size);
                int y = rnd.Next(0,Size);

                if(theGrid[x,y].Live)
                    bombs++;
                else
                    theGrid[x, y].Live = true;
            }
        }

       
        
        public bool CheckLiveNeighbors(Cell cell)
        {
            cell.Neighbors = 0;

            //check neigbors here
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    try
                    {
                        if (theGrid[cell.RowNumber + i, cell.ColumnNumber + j].Live)
                        {
                            cell.Neighbors += 1;
                        }
                    }
                    catch { }
                }
            }


            //return
            if (cell.Neighbors == 0){ return false; }
            else { return true; }
        }
    }
}
