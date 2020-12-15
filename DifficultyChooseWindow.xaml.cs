using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NewSudoku.Core;

namespace NewSudoku
{
    /// <summary>
    /// DifficultyChooseWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DifficultyChooseWindow : Window
    {
        private int Difficulty=0;
        private bool NowClose;
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
