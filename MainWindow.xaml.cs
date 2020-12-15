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
    /// 主窗口，代码不止UI，理论上可以把生成数独的过程放至另一线程处理，防止窗口假死，目前未实现
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();//计时器
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }
        DifficultyChanger dif;//难度选择器
        private int Gametime;//游戏时间
        private bool GameStart;//标记游戏是否开始
        private Board PuzzleBoard;//谜题板
        private Board GameBoard;//正式游戏使用的题板
        private int inputX, inputY;//键盘输入的X,Y
        private int zerocount;//谜题板中0的数量
        private void dispatcherTimer_Tick(object sender, EventArgs e)//计算一局游戏的时间
        {
            Gametime += 1;
            TimeLabel.Content =Convert.ToString(Gametime);
        }
        private void Draw(TextBlock t, int num)
        {
            t.Foreground = Brushes.Black;
            if (num != 0) t.Text = Convert.ToString(num);
            else t.Text = null;
        }//给格子填数

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
        }//通过XY坐标给格子填数

        private void DrawPuzzleBoard(Board board)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    DrawPoint(x, y, board.getNumber(x, y));
                }
            }
        }//把谜题板填到格子里

        private void ClearPuzzleBoard()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    DrawPoint(x, y, 0);
                }
            }
        }//把格子全部清空

        private void EnableLabel()
        {
            GameStart = true;
            Label1.IsEnabled = true;
            TimeLabel.IsEnabled = true;
            Gametime = 0;
            MidLabel.Content = null;
            MidLabel.Visibility = Visibility.Collapsed;
            dispatcherTimer.Start();
        }//打开游戏时间标签

        private int CountZero(Board board)
        {
            int x = 0;
            StringBuilder s = new StringBuilder();
            s.Append(board.toString());
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    x++;
                }
            }
            return x;
        }//计算板子中有几个0
        private void NewGame()
        {
            GameBoard = new Board();
            PuzzleBoard = new Board();
            DifficultyChooseWindow difchos = new DifficultyChooseWindow
            {
                Left = this.Left,
                Top = this.Top + 150
            };
            difchos.ShowDialog();
            Stopwatch sw = new Stopwatch();
            if (difchos.IsClosing())
            {
                sw.Start();
                if (difchos.getDifficulty() == 1)
                {
                    dif = new DifficultyChanger();
                    dif.generateEasyPuzzleBoard();
                    ClearPuzzleBoard();
                    DrawPuzzleBoard(dif.getEasyPuzzleBoard());
                    GameBoard.copyBoard(dif.getEasyPuzzleBoard());
                    PuzzleBoard.copyBoard(dif.getEasyPuzzleBoard());
                    zerocount = CountZero(PuzzleBoard);
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;
                    StatusLabel.Content = "成功生成了简单难度数独，用时" + ts.TotalMilliseconds + "毫秒";
                    EnableLabel();
                    return;
                }
                else if (difchos.getDifficulty() == 2)
                {
                    dif = new DifficultyChanger();
                    dif.generateHardPuzzleBoard();
                    ClearPuzzleBoard();
                    DrawPuzzleBoard(dif.getHardPuzzleBoard());
                    GameBoard.copyBoard(dif.getHardPuzzleBoard());
                    PuzzleBoard.copyBoard(dif.getHardPuzzleBoard());
                    zerocount = CountZero(PuzzleBoard);
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;
                    StatusLabel.Content = "成功生成了中等难度数独，用时" + ts.TotalMilliseconds + "毫秒";
                    EnableLabel();
                    return;
                }
                else if (difchos.getDifficulty() == 3)
                {
                    dif = new DifficultyChanger();
                    dif.generateVeryHardPuzzleBoard();
                    ClearPuzzleBoard();
                    DrawPuzzleBoard(dif.getVeryHardPuzzleBoard());
                    GameBoard.copyBoard(dif.getVeryHardPuzzleBoard());
                    PuzzleBoard.copyBoard(dif.getVeryHardPuzzleBoard());
                    zerocount = CountZero(PuzzleBoard);
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
                    MidLabel.Content = "游戏未开始";
                    return;
                }
            }
        }//创建新游戏

        private void ClickBoard(TextBlock t,int x,int y,int num)
        {
            if (num == 0)
            {
                if (t.Text.Length == 0)
                {
                    return;
                }
                else
                {
                    t.Text = null;
                    zerocount++;
                    GameBoard.setNumber(x, y, 0);
                    return;
                }
            }
            t.Foreground = Brushes.CadetBlue;
            t.Text = Convert.ToString(num);
            if (!GameBoard.canBePlacedAtPosition(x,y,num))
            {
                MessageBox.Show("出现行列冲突！","提示",MessageBoxButton.OK,MessageBoxImage.Error);
                t.Text = null;
            }
            else if (!GameBoard.canPlaceAtSubGrid(x,y,num))
            {
                MessageBox.Show("出现九宫格冲突！", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                t.Text = null;
            }
            else
            {
                GameBoard.setNumber(x, y, num);
                zerocount--;
            }
            if (zerocount==0)
            {
                //Win
                dispatcherTimer.Stop();
                MessageBox.Show("解答正确，游戏结束，用时"+Convert.ToString(Gametime)+"秒", "解答正确", MessageBoxButton.OK, MessageBoxImage.Information);
                StatusLabel.Content = "解答正确，游戏结束，用时" + Convert.ToString(Gametime) + "秒";
                GameStart = false;
            }
        }//键盘填数交互
        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            if (!GameStart)
            {
                ClearPuzzleBoard();
                MidLabel.Content = "数独生成中";
                MidLabel.Visibility = Visibility.Visible;
                NewGame();
            }
            else
            {
                dispatcherTimer.Stop();
                if (MessageBox.Show("现有数据将被清空，是否确定开始新游戏？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) ==
                    MessageBoxResult.OK)
                {
                    ClearPuzzleBoard();
                    dif = null;
                    System.GC.Collect();
                    MidLabel.Content = "数独生成中";
                    MidLabel.Visibility = Visibility.Visible;
                    NewGame();
                }
                else
                {
                    dispatcherTimer.Start();
                    return;
                }
            }
        }//开始游戏按钮交互

        private void Point_0_0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!GameStart) return;
            TextBlock t = (TextBlock) e.OriginalSource;
            int x = Convert.ToInt32(t.Name.Substring(6, 1));
            int y= Convert.ToInt32(t.Name.Substring(8, 1));
            if (t.Text.Length!=0)
            {
                if (Convert.ToInt32(t.Text) == PuzzleBoard.getNumber(x, y))
                {
                    MessageBox.Show("不能修改原有的值！", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    t.Background = Brushes.DeepSkyBlue;
                    StatusLabel.Content = "选中了第" + Convert.ToString(x + 1) + "行,第" + Convert.ToString(y + 1) + "列";
                    inputX = x;
                    inputY = y;
                    t.Focus();
                }
            }
            else
            {
                t.Background = Brushes.DeepSkyBlue;
                StatusLabel.Content = "选中了第"+Convert.ToString(x+1)+"行,第"+ Convert.ToString(y + 1)+"列";
                inputX = x;
                inputY = y;
                t.Focus();
            }
        }//鼠标点击格子交互

        private void Point_0_0_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBlock t = (TextBlock)e.OriginalSource;
            t.Background = null;
        }//焦点移动交互

        private void Point_0_0_KeyDown(object sender, KeyEventArgs e)
        {
            int num = 0;
            TextBlock t = (TextBlock)e.OriginalSource;
            if (((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)))
            {
                if (e.Key.ToString().Substring(0, 1) == "D")
                {
                    num = Convert.ToInt32(e.Key.ToString().Substring(1, 1));
                }
                else
                {
                    num = Convert.ToInt32(e.Key.ToString().Substring(6, 1));
                }
                ClickBoard(t, inputX, inputY, num);
            }
            else
            {
                MessageBox.Show("请输入0-9的数字！", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }//按键交互
    }
}
