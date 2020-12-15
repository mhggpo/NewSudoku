using System;

namespace NewSudoku.Core
{	
	/// <summary>
	/// 核心代码，生成符合要求的数独板，被注释的部分检测是否有唯一解
	/// </summary>
	class BoardGenerator
	{

		protected const int MAX_EMPTY_SEARCH_ATTEMPTS = 20;//最高挖洞搜索尝试次数，调高了会影响效率

		protected Board solutionBoard;
		protected Board puzzleBoard;
        protected static Random rnd = new Random();
        private int toRemove;//挖洞的数量，最终可能会有0-1的偏差
		public BoardGenerator()
        {
            toRemove = 50;
        }

        public void setRemove(int t)
        {
			toRemove = t;
        }
        public void generatePuzzleBoard()
        {
            bool solvable = false;
            while (!solvable)
            {
                // 第一步：挖洞
                Board testBoard = new Board();
                testBoard.copyBoard(solutionBoard);
                MirrorBoardPoker mbp = new MirrorBoardPoker(ref testBoard);
                mbp.setRemove(toRemove);
                mbp.process();
                // 第二步：检测是否有唯一解
                BoardSolver bs = new BoardSolver(testBoard);
                int numSolutions = bs.countSolutions();
                if (numSolutions == 1)
                {
                    solvable = true;
                }
                // 第三步：最终检查
                if (solvable)
                {
                    puzzleBoard = testBoard;
                }
            }
        }

        public void generateSolutionBoard()
		{
			solutionBoard = new Board();
			while (!trySolutionGeneration())
			{
				solutionBoard.whipeBoard();
			}
		}

		public Board getPuzzleBoard()
		{
			return puzzleBoard;
		}

		public Board getSolutionBoard()
		{
			return solutionBoard;
		}

		protected bool trySolutionGeneration()
		{
            for (int num = 1; num <= 9; num += 1)
			{
				for (int xq = 0; xq < 3; xq += 1)
				{
					for (int yq = 0; yq < 3; yq += 1)
					{
						int tries = 0;
						bool foundEmpty = false;
						int absX = 0;
						int absY = 0;
						while (!foundEmpty)
						{
							int rx, ry;
							lock (rnd)
							{
								rx = rnd.Next(0, 3);
								ry = rnd.Next(0, 3);
							}
							absX = (xq * 3) + rx;
							absY = (yq * 3) + ry;
							if (solutionBoard.canPlaceAtSubGrid(xq, yq, rx, ry, num))
							{
								if (solutionBoard.canBePlacedAtPosition(absX, absY, num))
								{
									foundEmpty = true;
								}
							}
							tries += 1;
							if (!foundEmpty && (tries >= MAX_EMPTY_SEARCH_ATTEMPTS))
							{
								return false;
							}
						}
                        solutionBoard.setNumber(absX, absY, num);
					}
				}
			}
			return true;
		}

	}

}
