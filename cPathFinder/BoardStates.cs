using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace cPathFinder
{

    class BoardStates
    {

        private int number_of_rows;
        private int number_of_cols;
        private int tile;
        public bool Start_state { get; set; }
        public bool End_state { get; set; }
        private Point[,] board_states;
        public BoardStates(int width, int height, int t)
        {
            tile = t;
            number_of_cols = width / tile;
            number_of_rows = height / tile;
            board_states = new Point[number_of_rows, number_of_cols];
            clearEntireBoard();
            Start_state = true;
            End_state = true;
        }

        public void addPointToBoard(Point p)
        {
            int y = p.X_coords / tile;
            int x = p.Y_coords / tile;
            if (Start_state == true && p.Type == TypeOfPoint.START)
            {
                Start_state = false;
                board_states[x, y] = p;
            }
            else if (End_state == true && p.Type == TypeOfPoint.END)
            {
                End_state = false;
                board_states[x, y] = p;
            }
            else if (p.Type == TypeOfPoint.WALL)
            {
                board_states[x, y] = p;
            }
        }

        public void clearEntireBoard()
        {
            for (int i = 0; i < number_of_rows; i++)
            {
                for (int j = 0; j < number_of_cols; j++)
                {
                    board_states[i, j] = new Point(i * tile, j * tile, TypeOfPoint.NONE);
                }
            }
        }

        public int lengthOfBoard()
        {
            return board_states.Length;
        }

        public string displayBoardAsString()
        {
            string array = "";
            for (int i = 0; i < number_of_rows; i++)
            {
                for (int j = 0; j < number_of_cols; j++)
                {
                    array += board_states[i, j].Type + " ";
                }
                array += "\n";
            }
            return array;
        }
        public void setBoard(Tuple<int,int> p, TypeOfPoint t)
        {
            board_states[p.Item1, p.Item2].Type = t;
        }
        public Point[,] getBoard()
        {
            return board_states;
        }

        public int getNumberOfRows()
        {
            return number_of_rows;
        }
        public int getNumberOfCols()
        {
            return number_of_cols;
        }

        public List<Tuple<int,int>> getNeighbourLocations(Tuple<int, int> loc)
        {
            List<Tuple<int, int>> neighbours = new List<Tuple<int, int>>();
            if (loc.Item2 + 1 < number_of_cols && board_states[loc.Item1,loc.Item2+1].Type!=TypeOfPoint.WALL)
            {
                neighbours.Add(new Tuple<int, int>(loc.Item1, loc.Item2 + 1));
            }
            if (loc.Item2 - 1 >=0 && board_states[loc.Item1, loc.Item2 -1].Type != TypeOfPoint.WALL)
            {
                neighbours.Add(new Tuple<int, int>(loc.Item1, loc.Item2 - 1));
            }
            if (loc.Item1 + 1 < number_of_rows && board_states[loc.Item1+1, loc.Item2].Type != TypeOfPoint.WALL)
            {
                neighbours.Add(new Tuple<int, int>(loc.Item1+1, loc.Item2));
            }
            if (loc.Item1 - 1 >=0 && board_states[loc.Item1 -1, loc.Item2].Type != TypeOfPoint.WALL)
            {
                neighbours.Add(new Tuple<int, int>(loc.Item1 - 1, loc.Item2));
            }


            return neighbours;

        }
        public Tuple<int, int> getStartLocation()
        {
            for (int i = 0; i < number_of_rows; i++)
            {
                for (int j = 0; j < number_of_cols; j++)
                {
                    if (board_states[i, j].Type == TypeOfPoint.START)
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }
            return null;
        }

        public Tuple<int, int> getEndLocation()
        {
            for (int i = 0; i < number_of_rows; i++)
            {
                for (int j = 0; j < number_of_cols; j++)
                {
                    if (board_states[i, j].Type == TypeOfPoint.END)
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }
            return null;
        }
    }
}
