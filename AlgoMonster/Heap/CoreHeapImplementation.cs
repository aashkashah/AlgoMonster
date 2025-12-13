namespace AlgoMonster.Heap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> where T : IComparable<T>
    {
        private readonly List<T> _data = new List<T>();
        public int Count => _data.Count;

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Heap is empty.");
            return _data[0];
        }

        public void Push(T item)
        {
            _data.Add(item);
            SiftUp(Count - 1);
        }

        public T Pop()
        {
            if (Count == 0) throw new InvalidOperationException("Heap is empty.");
            T root = _data[0];
            T last = _data[Count - 1];
            _data.RemoveAt(Count - 1);
            if (Count > 0)
            {
                _data[0] = last;
                SiftDown(0);
            }
            return root;
        }

        private void SiftUp(int i)
        {
            while (i > 0)
            {
                int p = (i - 1) / 2;
                if (_data[i].CompareTo(_data[p]) >= 0) break;
                Swap(i, p);
                i = p;
            }
        }

        private void SiftDown(int i)
        {
            while (true)
            {
                int left = 2 * i + 1, right = 2 * i + 2, smallest = i;
                if (left < Count && _data[left].CompareTo(_data[smallest]) < 0) smallest = left;
                if (right < Count && _data[right].CompareTo(_data[smallest]) < 0) smallest = right;
                if (smallest == i) break;
                Swap(i, smallest);
                i = smallest;
            }
        }

        private void Swap(int a, int b)
        {
            T t = _data[a]; _data[a] = _data[b]; _data[b] = t;
        }
    }

}
