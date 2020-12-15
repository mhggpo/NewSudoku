using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSudoku.Core
{
    class DifficultyChanger
    {
        protected Board HardBoard;
        protected Board EasyBoard;
        protected Board VeryHardBoard;
        protected Board SolutionBoard;
        protected BoardGenerator gen;
        protected static Random rnd = new Random();

        public DifficultyChanger()
        {
            gen = new BoardGenerator();
            gen.generateSolutionBoard();
            SolutionBoard = gen.getSolutionBoard();
        }
        public void generateVeryHardPuzzleBoard()
        {
            gen.setRemove(50);
            gen.generatePuzzleBoard();
            VeryHardBoard = gen.getPuzzleBoard();
        }
        public void generateHardPuzzleBoard()
        {
            gen.setRemove(40);
            gen.generatePuzzleBoard();
            HardBoard = gen.getPuzzleBoard();
        }
        public void generateEasyPuzzleBoard()
        {
            gen.setRemove(30);
            gen.generatePuzzleBoard();
            EasyBoard = gen.getPuzzleBoard();
        }
        public Board getSolutionBoard()
        {
            return SolutionBoard;
        }
        public Board getVeryHardPuzzleBoard()
        {
            return VeryHardBoard;
        }
        public Board getHardPuzzleBoard()
        {
            return HardBoard;
        }
        public Board getEasyPuzzleBoard()
        {
            return EasyBoard;
        }
    }
}
