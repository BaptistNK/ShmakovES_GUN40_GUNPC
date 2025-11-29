using System;
using System.Collections;

namespace ShmakovES_GUN40_GUNPC
{
    public class DuplexLinkedList<T> : IEnumerable<T>
    {
        public DuplexItem<T> Head { get; set; }
        public DuplexItem<T> Tail { get; set; }
        public int Count { get; set; }

        public DuplexLinkedList() { }
        public DuplexLinkedList(T Data)
        {
            var item = new DuplexItem<T>(Data);
            Head = item;
            Tail = item;
            Count = 1;
        }
        public void Add(T Data)
        {
            var item = new DuplexItem<T>(Data);
            if (Count == 0)
            {
                Head = item;
                Tail = item;
                Count = 1;
                return;
            }
            
            Tail.Next = item;
            item.Previous = Tail;
            Tail = item;
            Count++;
        }
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();

        }
        public DuplexLinkedList<T> Reverse()
        {
            var result = new DuplexLinkedList<T>();

            var current = Tail;
            
            while (current != null)
            {
                result.Add(current.Data);
                current = current.Previous;
            }
            return result;
        }
    }
}
