using System.Collections;
using System.Collections.Generic;

namespace Hybel.Tweener
{
    public class QueueStack<T> : IEnumerable<T>
    {
        private readonly List<T> _items;

        public QueueStack() => _items = new List<T>();

        public QueueStack(int capacity) => _items = new List<T>(capacity);

        public int Count => _items.Count;
        
        public void Enqueue(T item) => _items.Add(item);

        public T Dequeue()
        {
            T item = _items[0];
            _items.RemoveAt(0);
            return item;
        }

        public bool TryDequeue(out T item)
        {
            if (Count == 0)
            {
                item = default;
                return false;
            }

            item = Dequeue();
            return true;
        }

        public T QueuePeek() => _items[0];

        public bool QueueTryPeek(out T item)
        {
            if (Count == 0)
            {
                item = default;
                return false;
            }
            
            item = QueuePeek();
            return true;
        }
        
        public void Push(T item) => Enqueue(item);

        public T Pop()
        {
            T item = _items[Count - 1];
            _items.RemoveAt(Count - 1);
            return item;
        }

        public bool TryPop(out T item)
        {
            if (Count == 0)
            {
                item = default;
                return false;
            }
            
            item = Pop();
            return true;
        }

        public T StackPeek() => _items[Count - 1];
        
        public bool TryStackPeek(out T item)
        {
            if (Count == 0)
            {
                item = default;
                return false;
            }
            
            item = StackPeek();
            return true;
        }

        public bool Contains(T item) => _items.Contains(item);
        
        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
