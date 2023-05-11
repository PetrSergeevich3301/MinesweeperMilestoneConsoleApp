using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperMilstoneClassLibrary
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool Visited { get; set; }
        public bool Live { get; set; }
        public int Neighbors { get; set; }

        public Cell() { 
            RowNumber = -1;
            ColumnNumber = -1;
            Visited = false;
            Live = false;
            Neighbors = 0;
        }

        public Cell(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
            Visited = false;
            Live = false;
            Neighbors = 0;
        }


    }
}
