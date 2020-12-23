using System;
using System.Collections.Generic;
using System.Linq;
namespace NewSudoku.Core
{
    /// <summary>
    /// 本程序尝试挖空的方式是对称挖空，所以这是一个对称取格子器
    /// </summary>
	class MirrorBoardPoker : BoardPoker
    {

        private int toRemove;

        public MirrorBoardPoker(ref Board pBoard) : base(ref pBoard)
        {
            toRemove = 52;
        }

        public void setRemove(int t)
        {
            toRemove = t;
        }
        public override void process()
        {
            Random rnd = new Random();
            while (toRemove > 0)
            {
                int rx = rnd.Next(0, 9);
                int ry = rnd.Next(0, 9);
                int testNum = puzzleBoard.getNumber(rx, ry);
                if (testNum == 0)
                {
                    continue;
                }
                int mx = 8 - rx;
                int my = 8 - ry;
                puzzleBoard.setNumber(rx, ry, 0);
                puzzleBoard.setNumber(mx, my, 0);
                toRemove -= 2;
            }
        }

    }
}
