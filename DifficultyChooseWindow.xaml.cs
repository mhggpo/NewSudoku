using System;
using System.Windows;

namespace NewSudoku
{
    /// <summary>
    /// 难度选择窗口
    /// </summary>
    public partial class DifficultyChooseWindow : Window
    {
        private int Difficulty=0;//难度标识，0为默认，1为容易，2为中等，3为困难
        private bool NowClose;//窗口关闭标识
        public DifficultyChooseWindow()
        {
            
            InitializeComponent();
        }

        public int getDifficulty()
        {
            return Difficulty;
        }

        public bool IsClosing()
        {
            return NowClose;
        }
        private void EasyButton_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 1;
            NowClose = true;
            Close();
        }

        private void HardButton_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 2;
            NowClose = true;
            Close();
        }

        private void VeryHardButton_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 3;
            NowClose = true;
            Close();
        }

        private void DifClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NowClose = true;
        }

        private void DifClosed(object sender, EventArgs e)
        {
            NowClose = true;
        }
    }
}
