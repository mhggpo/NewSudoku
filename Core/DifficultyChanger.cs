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
        public void generateVeryHardPuzzleBoard()//生成困难谜题板
        {
            gen.setRemove(50);
            gen.generatePuzzleBoard();
            VeryHardBoard = gen.getPuzzleBoard();
        }
        public void generateHardPuzzleBoard()//生成中等谜题板
        {
            gen.setRemove(40);
            gen.generatePuzzleBoard();
            HardBoard = gen.getPuzzleBoard();
        }
        public void generateEasyPuzzleBoard()//生成容易谜题板
        {
            gen.setRemove(30);
            gen.generatePuzzleBoard();
            EasyBoard = gen.getPuzzleBoard();
        }
        public Board getSolutionBoard()//获取完整题板
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
