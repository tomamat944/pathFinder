using System;
using System.Collections.Generic;
using System.Text;

namespace cPathFinder
{
    static class Algorithms
    {
        static public List<Tuple<int,int>> DepthFirstSearch(BoardStates board)
        {
            
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            List<Tuple<int, int>> visited = new List<Tuple<int, int>>();
            if (board.getStartLocation().Equals(board.getEndLocation()))
            {
                throw new Exception("Nowhere to go");
            }
            stack.Push(board.getStartLocation());
            while (stack.Count != 0)
            {
                var temp = stack.Pop();

                if (temp.Equals(board.getEndLocation()))
                {
                    break;
                }
                if (visited.Contains(temp) == false)
                {
                    visited.Add(temp);
                }
                foreach(var elem in board.getNeighbourLocations(temp))
                {
                    
                    
                    if (visited.Contains(elem)==false)
                    {
                        stack.Push(elem);
                    }
                }
                
            }
            visited.RemoveAt(0);
            foreach (var elem in visited)
            {
                board.setBoard(elem, TypeOfPoint.PATH);
            }
            return visited;
        }
        static public List<Tuple<int, int>> BreadthFirstSearch(BoardStates board)
        {
            Queue<Tuple<int,int>> queue = new Queue<Tuple<int, int>>();
            List<Tuple<int, int>> visited = new List<Tuple<int, int>>();
            if (board.getStartLocation().Equals(board.getEndLocation()))
            {
                throw new Exception("Nowhere to go");
            }
            queue.Enqueue(board.getStartLocation());
            while (queue.Count != 0)
            {
                var temp = queue.Dequeue();
                
                if (temp.Equals(board.getEndLocation()))
                {
                    break;
                }
                if (visited.Contains(temp) == false)
                {
                    visited.Add(temp);
                }
                foreach (var elem in board.getNeighbourLocations(temp))
                {


                    if (visited.Contains(elem) == false)
                    {
                        queue.Enqueue(elem);
                    }
                }

            }
            visited.RemoveAt(0);
            foreach (var elem in visited)
            {
                board.setBoard(elem, TypeOfPoint.PATH);
            }
            return visited;
        }
        static public List<Tuple<int,int>> AStarSearch(BoardStates board)
        {
            PriorityQueue<Tuple<int, int>, int> priority_queue = new PriorityQueue<Tuple<int, int>, int>();
            List<Tuple<int, int>> visited = new List<Tuple<int, int>>();
            if (board.getStartLocation().Equals(board.getEndLocation()))
            {
                throw new Exception("Nowhere to go");
            }
            priority_queue.Enqueue(board.getStartLocation(), 
                EuclideanDistance(board.getStartLocation(), board.getEndLocation()));
            while (priority_queue.Count() != 0)
            {
                var temp = priority_queue.Dequeue();

                if (temp.Equals(board.getEndLocation()))
                {
                    break;
                }
                if (visited.Contains(temp) == false)
                {
                    visited.Add(temp);
                }
                foreach (var elem in board.getNeighbourLocations(temp))
                {


                    if (visited.Contains(elem) == false)
                    {
                        priority_queue.Enqueue(elem, EuclideanDistance(elem, board.getEndLocation()));
                    }
                }

            }
            visited.RemoveAt(0);
            foreach (var elem in visited)
            {
                board.setBoard(elem, TypeOfPoint.PATH);
            }
            return visited;
        }
        static public int EuclideanDistance(Tuple<int,int> t1, Tuple<int,int> t2)
        {
            return Convert.ToInt32(Math.Sqrt(Math.Pow(t2.Item1 - t1.Item1, 2) + Math.Pow(t2.Item2 - t1.Item2, 2)));
        }
    }
}
