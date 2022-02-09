using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cPathFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GroupActiveButtons group;
        BoardStates board;
        int tile = 50;
        public MainWindow()
        {
            InitializeComponent();
            initializeRest();

        }
        private void initializeRest()
        {
            group = new GroupActiveButtons();
            group.addToGroup(btnStart);
            group.addToGroup(btnEnd);
            group.addToGroup(btnWall);
            board = new BoardStates(Convert.ToInt32(canBoard.Width), Convert.ToInt32(canBoard.Height), tile);
            foreach(var elem in group)
            {
                elem.Click += new RoutedEventHandler(drawingMode);
            }
            canBoard.MouseDown += new MouseButtonEventHandler(drawOnCanvasStartAndEnd);
            canBoard.MouseMove += new MouseEventHandler(drawOnCanvasWall);
            btnPath.Click += new RoutedEventHandler(clickToDrawPath);
        }

        private void clickToDrawPath(object sender, RoutedEventArgs args)
        {
            
            if (comboAlgorithm.SelectedIndex==0)
            {
                List<Tuple<int, int>> pathToWalk = Algorithms.DepthFirstSearch(board);
                drawPathStepByStep(pathToWalk);
            }
            else if(comboAlgorithm.SelectedIndex==1)
            {
                List<Tuple<int, int>> path_to_walk = Algorithms.BreadthFirstSearch(board);
                drawPathStepByStep(path_to_walk);
            }
            else if(comboAlgorithm.SelectedIndex==2)
            {
                List<Tuple<int,int>> path_to_walk= Algorithms.AStarSearch(board);
                drawPathStepByStep(path_to_walk);
            }
            
        }
        private void drawRectanglesOnBoard(Color col, int width, int height)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = col;
            Rectangle rect = new Rectangle();
            rect.Fill = brush;
            rect.Width = tile;
            rect.Height = tile;
            Canvas.SetLeft(rect, width);
            Canvas.SetTop(rect, height);
            canBoard.Children.Add(rect);
        }

        private async void drawPathStepByStep(List<Tuple<int,int>> path)
        {
            
            foreach(var elem in path)
            {
                int y = elem.Item1 * tile;
                int x = elem.Item2 * tile;
                drawRectanglesOnBoard(Color.FromArgb(255, 0, 0, 255), x, y);
                await Task.Delay(100);
            }
            
        }

        
        private void drawingMode(object sender, RoutedEventArgs args)
        {
            group.setButtonToActiveOrDeactive((Button)sender);
        }

        private void drawOnCanvasWall(object sender, MouseEventArgs e)
        {
            if (group.CurrentActive == btnWall)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    double x_pos = e.GetPosition(canBoard).X;
                    double y_pos = e.GetPosition(canBoard).Y;
                    
                    int x = Convert.ToInt32(x_pos / tile) * tile ;
                    int y = Convert.ToInt32(y_pos / tile) * tile ;
                    if (x_pos > x && x_pos < x + tile && y_pos > y && y_pos < y + tile)
                    {
                        board.addPointToBoard(new Point(x, y, TypeOfPoint.WALL));
                        drawRectanglesOnBoard(Color.FromArgb(255, 0, 0, 0), x, y);
                    }
                }
            }
        }
        private void drawOnCanvasStartAndEnd(object sender, MouseButtonEventArgs e)
        {
            if (group.CurrentActive == btnStart && board.Start_state==true)
            {
                SolidColorBrush brush = new SolidColorBrush();
                double x_pos = e.GetPosition(canBoard).X;
                double y_pos = e.GetPosition(canBoard).Y;
                int x= Convert.ToInt32(x_pos / tile) * tile;
                int y= Convert.ToInt32(y_pos / tile) * tile;
                if (x_pos > x && x_pos < x + tile && y_pos > y && y_pos < y + tile)
                {
                    board.addPointToBoard(new Point(x, y, TypeOfPoint.START));
                    drawRectanglesOnBoard(Color.FromArgb(255, 0, 255, 0), x, y);
                }
            }
            if (group.CurrentActive == btnEnd && board.End_state==true)
            {
                SolidColorBrush brush = new SolidColorBrush();
                double x_pos = e.GetPosition(canBoard).X;
                double y_pos = e.GetPosition(canBoard).Y;
                int x = Convert.ToInt32(x_pos / tile) * tile;
                int y = Convert.ToInt32(y_pos / tile) * tile;
                if (x_pos > x && x_pos < x + tile && y_pos > y && y_pos < y + tile)
                {
                    board.addPointToBoard(new Point(x, y, TypeOfPoint.END));
                    drawRectanglesOnBoard(Color.FromArgb(255, 255, 0, 0), x, y);
                }
            }
            
        }
    }
}
