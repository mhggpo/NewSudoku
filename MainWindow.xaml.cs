using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using NewSudoku.Core;

namespace NewSudoku
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }
        DifficultyChanger dif;
        private int Gametime = 0;
        private bool GameStart = false;
        private Board GameBoard;
        private bool StartGen = false;
        private bool GenDone = false;
        private void dispatcherTimer_Tick(object sender, EventArgs e)//计时执行的程序
        {
            Gametime += 1;
            TimeLabel.Content =Convert.ToString(Gametime);
        }
        private void Draw(TextBlock t, int num)
        {
            t.Cursor = Cursors.Hand;
            t.TextAlignment = TextAlignment.Center;
            t.FontSize = 28;
            t.FontWeight = FontWeights.Bold;
            if (num != 0) t.Text = Convert.ToString(num);
            else t.Text = null;
        }

        private void DrawPoint(int x,int y,int num)
        {
            if (x == 0)
            {
                if (y == 0) Draw(Point_0_0, num);
                if (y == 1) Draw(Point_0_1, num);
                if (y == 2) Draw(Point_0_2, num);
                if (y == 3) Draw(Point_0_3, num);
                if (y == 4) Draw(Point_0_4, num);
                if (y == 5) Draw(Point_0_5, num);
                if (y == 6) Draw(Point_0_6, num);
                if (y == 7) Draw(Point_0_7, num);
                if (y == 8) Draw(Point_0_8, num);
            }
            if (x == 1)
            {
                if (y == 0) Draw(Point_1_0, num);
                if (y == 1) Draw(Point_1_1, num);
                if (y == 2) Draw(Point_1_2, num);
                if (y == 3) Draw(Point_1_3, num);
                if (y == 4) Draw(Point_1_4, num);
                if (y == 5) Draw(Point_1_5, num);
                if (y == 6) Draw(Point_1_6, num);
                if (y == 7) Draw(Point_1_7, num);
                if (y == 8) Draw(Point_1_8, num);
            }
            if (x == 2)
            {
                if (y == 0) Draw(Point_2_0, num);
                if (y == 1) Draw(Point_2_1, num);
                if (y == 2) Draw(Point_2_2, num);
                if (y == 3) Draw(Point_2_3, num);
                if (y == 4) Draw(Point_2_4, num);
                if (y == 5) Draw(Point_2_5, num);
                if (y == 6) Draw(Point_2_6, num);
                if (y == 7) Draw(Point_2_7, num);
                if (y == 8) Draw(Point_2_8, num);
            }
            if (x == 3)
            {
                if (y == 0) Draw(Point_3_0, num);
                if (y == 1) Draw(Point_3_1, num);
                if (y == 2) Draw(Point_3_2, num);
                if (y == 3) Draw(Point_3_3, num);
                if (y == 4) Draw(Point_3_4, num);
                if (y == 5) Draw(Point_3_5, num);
                if (y == 6) Draw(Point_3_6, num);
                if (y == 7) Draw(Point_3_7, num);
                if (y == 8) Draw(Point_3_8, num);
            }
            if (x == 4)
            {
                if (y == 0) Draw(Point_4_0, num);
                if (y == 1) Draw(Point_4_1, num);
                if (y == 2) Draw(Point_4_2, num);
                if (y == 3) Draw(Point_4_3, num);
                if (y == 4) Draw(Point_4_4, num);
                if (y == 5) Draw(Point_4_5, num);
                if (y == 6) Draw(Point_4_6, num);
                if (y == 7) Draw(Point_4_7, num);
                if (y == 8) Draw(Point_4_8, num);
            }
            if (x == 5)
            {
                if (y == 0) Draw(Point_5_0, num);
                if (y == 1) Draw(Point_5_1, num);
                if (y == 2) Draw(Point_5_2, num);
                if (y == 3) Draw(Point_5_3, num);
                if (y == 4) Draw(Point_5_4, num);
                if (y == 5) Draw(Point_5_5, num);
                if (y == 6) Draw(Point_5_6, num);
                if (y == 7) Draw(Point_5_7, num);
                if (y == 8) Draw(Point_5_8, num);
            }
            if (x == 6)
            {
                if (y == 0) Draw(Point_6_0, num);
                if (y == 1) Draw(Point_6_1, num);
                if (y == 2) Draw(Point_6_2, num);
                if (y == 3) Draw(Point_6_3, num);
                if (y == 4) Draw(Point_6_4, num);
                if (y == 5) Draw(Point_6_5, num);
                if (y == 6) Draw(Point_6_6, num);
                if (y == 7) Draw(Point_6_7, num);
                if (y == 8) Draw(Point_6_8, num);
            }
            if (x == 7)
            {
                if (y == 0) Draw(Point_7_0, num);
                if (y == 1) Draw(Point_7_1, num);
                if (y == 2) Draw(Point_7_2, num);
                if (y == 3) Draw(Point_7_3, num);
                if (y == 4) Draw(Point_7_4, num);
                if (y == 5) Draw(Point_7_5, num);
                if (y == 6) Draw(Point_7_6, num);
                if (y == 7) Draw(Point_7_7, num);
                if (y == 8) Draw(Point_7_8, num);
            }

            if (x == 8)
            {
                if (y == 0) Draw(Point_8_0, num);
                if (y == 1) Draw(Point_8_1, num);
                if (y == 2) Draw(Point_8_2, num);
                if (y == 3) Draw(Point_8_3, num);
                if (y == 4) Draw(Point_8_4, num);
                if (y == 5) Draw(Point_8_5, num);
                if (y == 6) Draw(Point_8_6, num);
                if (y == 7) Draw(Point_8_7, num);
                if (y == 8) Draw(Point_8_8, num);
            }
        }

        private void DrawPuzzleBoard(Board board)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    DrawPoint(x, y, board.getNumber(x, y));
                }
            }
        }

        private void ClearPuzzleBoard()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    DrawPoint(x, y, 0);
                }
            }
        }

        private void EnableLabel()
        {
            GameStart = true;
            Label1.IsEnabled = true;
            TimeLabel.IsEnabled = true;
            Gametime = 0;
            MidLabel.Content = null;
            dispatcherTimer.Start();
        }
        private void NewGame()
        {
            GameBoard = new Board();
            DifficultyChooseWindow difchos = new DifficultyChooseWindow();
            difchos.ShowDialog();
            Stopwatch sw = new Stopwatch();
            if (difchos.IsClosing())
            {
                sw.Start();
                if (difchos.getDifficulty() == 1)
                {
                    Task.Factory.StartNew(SchedulerWork);
                    //MidLabel.Content = "数独生成中";
                    //dif = new DifficultyChanger();
                    //dif.generateEasyPuzzleBoard();
                    while (!GenDone)
                    {

                    }
                    ClearPuzzleBoard();
                    DrawPuzzleBoard(dif.getEasyPuzzleBoard());
                    GameBoard.copyBoard(dif.getEasyPuzzleBoard());
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;
                    StatusLabel.Content = "成功生成了简单难度数独，用时" + ts.TotalMilliseconds + "毫秒";
                    EnableLabel();
                    return;
                }
                else if (difchos.getDifficulty() == 2)
                {
                    
                    //MidLabel.Content = "数独生成中";
                    dif = new DifficultyChanger();
                    StartGen = true;
                    dif.generateHardPuzzleBoard();
                    GenDone = true;
                    ClearPuzzleBoard();
                    DrawPuzzleBoard(dif.getHardPuzzleBoard());
                    GameBoard.copyBoard(dif.getHardPuzzleBoard());
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;
                    StatusLabel.Content = "成功生成了中等难度数独，用时" + ts.TotalMilliseconds + "毫秒";
                    EnableLabel();
                    return;
                }
                else if (difchos.getDifficulty() == 3)
                {
                    //MidLabel.Content = "数独生成中";
                    //dif = new DifficultyChanger();
                    //StartGen = true;
                    //dif.generateVeryHardPuzzleBoard();
                    MidLabel.Content = "数独生成中";
                    Task.Factory.StartNew(SchedulerVeryHardWork);
                    while (!GenDone) { }
                    ClearPuzzleBoard();
                    DrawPuzzleBoard(dif.getVeryHardPuzzleBoard());
                    GameBoard.copyBoard(dif.getVeryHardPuzzleBoard());
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;
                    StatusLabel.Content = "成功生成了困难难度数独，用时" + ts.TotalMilliseconds + "毫秒";
                    EnableLabel();
                    return;
                }
                else if (difchos.getDifficulty() == 0)
                {
                    ClearPuzzleBoard();
                    sw.Stop();
                    return;
                }
            }
        }

        private void ClickBoard(TextBlock t,int x,int y,int num)
        {
            t.TextAlignment = TextAlignment.Center;
            t.FontSize = 28;
            t.FontWeight = FontWeights.Bold;
            if (t.Text != null)
            {
                MessageBox.Show("不能修改原有的值！", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (num != dif.getSolutionBoard().getNumber(x, y))
            {
                MessageBox.Show("填错了，帮你清空","提示",MessageBoxButton.OK,MessageBoxImage.Error);
                t.Text = null;
            }
        }
        private void SchedulerWork()
        {
            //fistr,second,three是三个TextBlock控件的名字
            Task task = new Task(()=> ChangeMidLabel());
            task.Start();
            Task.WaitAll(task);
        }
        private void SchedulerVeryHardWork()
        {
            //fistr,second,three是三个TextBlock控件的名字
            Task task = new Task(() => GenVeryHard());
            task.Start();
            Task.WaitAll(task);
        }
        private void GenVeryHard()
        {
            //this.Dispatcher.BeginInvoke(new Action(() => MidLabel.Content = "数独生成中"));
            dif = new DifficultyChanger();
            dif.generateVeryHardPuzzleBoard();
            GenDone = true;
        }
        private void ChangeMidLabel()
        {
            while (!StartGen) { }
            this.Dispatcher.BeginInvoke(new Action(() => MidLabel.Content = "数独生成中"));
            //dif = new DifficultyChanger();
            //dif.generateEasyPuzzleBoard();
            //dif.generateHardPuzzleBoard();
            //dif.generateVeryHardPuzzleBoard();
            while (!GenDone) { }
            this.Dispatcher.BeginInvoke(new Action(() => MidLabel.Content = null));
        }
        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            //Task.Factory.StartNew(SchedulerWork);
            NewGame();
        }
    }
}
