namespace NewSudoku.Core
{
    /// <summary>
    /// BoardBox是一个3x3的int数组，表示数独Board中的一部分
    /// </summary>
    class BoardBox
    {

        protected int[,] grid;

        public BoardBox()
        {
            grid = new int[3, 3];
            whipeGrid();
        }

        public int getNumber(int x, int y)
        {
            return grid[x, y];
        }

        public void setNumber(int x, int y, int num)
        {
            grid[x, y] = num;
        }

        public void whipeGrid()//将BoardBox中的数值置为0
        {
            for (int x = 0; x < 3; x += 1)
            {
                for (int y = 0; y < 3; y += 1)
                {
                    grid[x, y] = 0;
                }
            }
        }

    }

}