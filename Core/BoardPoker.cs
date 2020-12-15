using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSudoku.Core
{
    abstract class BoardPoker
    {

        protected Board puzzleBoard;

        public BoardPoker(ref Board pBoard)
        {
            puzzleBoard = pBoard;
        }

        public virtual void process()
        {

        }

    }
}
