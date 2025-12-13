using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.QueueStack
{
    public class MyQueue<T>
    {
        private readonly Stack<T> _in = new Stack<T>();
        private readonly Stack<T> _out = new Stack<T>();

        public void Enqueue(T x)
        {
            // push to _in
            _in.Push(x);
        }

        public T Dequeue()
        {
            // if _out empty, pour from _in to _out, then pop
            if( _out.Count == 0 )
            {
                while (_in.Count > 0)
                {
                    var temp = _in.Pop();
                    _out.Push(temp);
                }
            }
            return _out.Pop();
        }

        public T Peek()
        {
            // ensure _out has current front; return top of _out
            return default!;
        }

        public bool Empty() => _in.Count == 0 && _out.Count == 0;
    }
}
