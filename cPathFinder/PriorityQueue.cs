using System;
using System.Collections.Generic;
using System.Text;

namespace cPathFinder
{
    class PriorityQueue<T,V>
    {
        private LinkedList<Tuple<T,int>> pq;
        public PriorityQueue()
        {
            pq = new LinkedList<Tuple<T, int>>();
        }

        private bool addElementInSortedOrder(Tuple<T, int> elem)
        {
            
            if (pq.Count == 0)
            {
                pq.AddFirst(elem);
                return true;
            }
            var temp = pq.First;
            while(temp.Next!=null && temp.Next.Value.Item2<elem.Item2)
            {
                temp = temp.Next;
            }
            pq.AddAfter(temp, elem);
            return true;
        }
        public T Dequeue()
        {
            var temp = pq.First;
            pq.RemoveFirst();
            return temp.Value.Item1;
        }

        public void Enqueue(T elem, int value)
        {
            addElementInSortedOrder(Tuple.Create(elem, value));
        }

        public int Count()
        {
            return pq.Count;
        }
    }
}
