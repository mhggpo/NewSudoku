using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSudoku.Core
{
    /// <summary>
    /// 一个数独求解器，用于检测数独是否有唯一解
    /// </summary>
	class BoardSolver
    {

        protected Board gameBoard;
        protected int solutions;
        protected List<Tuple<int, int>> emptyCells;

        public BoardSolver(Board partialBoard)
        {
            gameBoard = partialBoard;
        }

        public bool canBeSolved()
        {
            return (countSolutions(true) > 0);
        }

        public int countSolutions(bool stopAtOne = true)//如果参数中布尔值为false，会寻找各种解，影响程序效率
        {
            solutions = 0;

            int index = 0;
            emptyCells = new List<Tuple<int, int>>();
            // find the empty cells
            for (int y = 0; y < 9; y += 1)
            {
                for (int x = 0; x < 9; x += 1)
                {
                    int num = gameBoard.getNumber(x, y);
                    if (num == 0)
                    {
                        Tuple<int, int> empty = new Tuple<int, int>(x, y);
                        emptyCells.Add(empty);
                    }
                }
            }

            if (emptyCells.Count <= 0)
            {
                return solutions;
            }

            tryPoint(index);

            return solutions;
        }

        private void tryPoint(int index)
        {
            Tuple<int, int> point = emptyCells[index];
            int x = point.Item1;
            int y = point.Item2;
            for (int num = 1; num <= 9; num += 1)
            {
                if (gameBoard.canBePlacedAtPosition(x, y, num))
                {
                    int subX = (int)Math.Floor((double)x / 3);
                    int subY = (int)Math.Floor((double)y / 3);
                    int relX = x - (subX * 3);
                    int relY = y - (subY * 3);
                    if (gameBoard.canPlaceAtSubGrid(subX, subY, relX, relY, num))
                    {
                        //Console.WriteLine("OK placement!");
                        gameBoard.setNumber(x, y, num);
                        if (index == (emptyCells.Count - 1))
                        {
                            // last cell
                            solutions += 1;
                            //Console.WriteLine("Solution! " + index);
                            //Console.WriteLine(gameBoard.toString(false));
                        }
                        else
                        {
                            // go next
                            tryPoint(index + 1);
                        }
                        gameBoard.setNumber(x, y, 0);
                    }
                }
            }
            //Console.WriteLine("Leaving point " + x + "," + y);
            // reset
            gameBoard.setNumber(x, y, 0);
        }

    }
}
