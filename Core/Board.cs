using System;

namespace NewSudoku.Core
{
	/// <summary>
	/// Board是一个完整的数独板，包含3x3个BoardBox
	/// </summary>
	class Board
	{

		protected BoardBox[,] board;

		public Board()//构造函数，之后清零
		{
			board = new BoardBox[3, 3];
			whipeBoard();
		}

		public bool canBePlacedAtPosition(int x, int y, int num)//冲突检测之行列检测
		{
			int current = getNumber(x, y);
			if (current > 0)
			{
				return false;
			}
			// row
			for (int tx = 0; tx < 9; tx += 1)
			{
				if (tx == x)
				{
					continue;
				}
				int thisNum = getNumber(tx, y);
				if (thisNum == num)
				{
					return false;
				}
			}
			// col
			for (int ty = 0; ty < 9; ty += 1)
			{
				if (ty == y)
				{
					continue;
				}
				int thisNum = getNumber(x, ty);
				if (thisNum == num)
				{
					return false;
				}
			}
			return true;
		}

		public bool canPlaceAtSubGrid(int x,int y,int num)
		{
			int subX = (int)Math.Floor((double)x / 3);
			int subY = (int)Math.Floor((double)y / 3);
			int relX = x - (subX * 3);
			int relY = y - (subY * 3);
			return canPlaceAtSubGrid(subX, subY, relX, relY, num);
		}
		public bool canPlaceAtSubGrid(int subX, int subY, int relX, int relY, int num)//冲突检测之能否放在BoardBox中
		{
			BoardBox subGrid = board[subX, subY];
			int checkNum = subGrid.getNumber(relX, relY);
			if (checkNum == 0)
			{
				bool numExists = false;
				for (int x = 0; x < 3; x += 1)
				{
					for (int y = 0; y < 3; y += 1)
					{
						if ((x == relX) && (y == relY))
						{
							continue;
						}
						checkNum = subGrid.getNumber(x, y);
						if (checkNum == num)
						{
							numExists = true;
							break;
						}
					}
					if (numExists)
					{
						break;
					}
				}
				if (!numExists)
				{
					return true;
				}
			}
			return false;
		}

		public void copyBoard(Board master) //复制一份Board
		{
			for (int y = 0; y < 9; y += 1)
			{
				for (int x = 0; x < 9; x += 1)
				{
					setNumber(x, y, master.getNumber(x, y));
				}
			}
		}

        public int getNumber(int x, int y)//x,y的范围均是从0到8，本方法先定位到BoardBox，再定位到具体数
		{
			int row = (int)Math.Floor((double)y / 3);
			int col = (int)Math.Floor((double)x / 3);
			BoardBox bb = board[col, row];
			int minorX = x - (col * 3);
			int minorY = y - (row * 3);
			return bb.getNumber(minorX, minorY);
		}

		public void setNumber(int x, int y, int num)
		{
			int row = (int)Math.Floor((double)y / 3);
			int col = (int)Math.Floor((double)x / 3);
			BoardBox bb = board[col, row];
			int minorX = x - (col * 3);
			int minorY = y - (row * 3);
			bb.setNumber(minorX, minorY, num);
		}

		public string toString()
		{
			string output = "";
			for (int y = 0; y < 9; y += 1)
			{
				for (int x = 0; x < 9; x += 1)
				{
					output += "" + getNumber(x, y);
				}
            }
			return output;
		}

		public void whipeBoard()//清零
		{
			for (int x = 0; x < 3; x += 1)
			{
				for (int y = 0; y < 3; y += 1)
				{
					board[x, y] = new BoardBox();
				}
			}
		}

	}

}