using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public interface IPriorityQueue<T>
    {
        int Size();
        void Enqueue(int priority, T item);
        T Dequeue();
    }
    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        int size =0 ;
        SortedDictionary<int, Queue<T>> storage = new SortedDictionary<int, Queue<T>>();

        public int Size() => size;

        public void Enqueue(int priority, T item)
        {
            if (!storage.ContainsKey(priority))
                storage[priority] = new Queue<T>();
            storage[priority].Enqueue(item);
            size++;
        }

        public T Dequeue()
        {
            if (size == 0) throw new Exception("Queue is empty");
            foreach (var queue in storage.Values)
            {
                if (queue.Count > 0)
                {
                    size--;
                    return queue.Dequeue();
                }
            }
            throw new Exception("Queue error");
        }
    }




}
