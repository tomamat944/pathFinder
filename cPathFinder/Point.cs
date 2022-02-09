using System;
using System.Collections.Generic;
using System.Text;

namespace cPathFinder
{
    public enum TypeOfPoint
    {
        START,
        END,
        WALL,
        NONE,
        PATH
    }
    class Point
    {
        public int X_coords { get; set; }
        public int Y_coords { get; set; }
        public TypeOfPoint Type { get; set; }
        public Point(int x, int y, TypeOfPoint t) 
        {
            X_coords = x;
            Y_coords = y;
            Type = t;
        }

    }
}
