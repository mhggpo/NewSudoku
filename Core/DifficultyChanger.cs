using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSudoku.Core
{
    enum Difficulty
    {
        EASY=1,
        MIDDLE,
        DIFFICULT
    }
    class DifficultyChanger
    {
        public Board TargetBoard { get; protected set; }
        public Board SolutionBoard { get; protected set; }
        protected BoardGenerator gen;
        protected static Random rnd = new Random();

        private readonly static Dictionary<Difficulty, int> s_removeCount = new Dictionary<Difficulty, int>()
        { {Difficulty.EASY,30 } ,{ Difficulty.MIDDLE,40},{ Difficulty.DIFFICULT,50} };

        public DifficultyChanger()
        {
            gen = new BoardGenerator();
            gen.generateSolutionBoard();
            SolutionBoard = gen.getSolutionBoard();
        }

        public void GeneratePuzzleBoard(Difficulty difficulty)
        {
            gen.setRemove(s_removeCount[difficulty]);
            gen.generatePuzzleBoard();
            TargetBoard = gen.getPuzzleBoard();
        }
    }
}
