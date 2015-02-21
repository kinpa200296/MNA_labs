using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MathBase
{
    public abstract class Vector<T> : IEnumerable<T>
    {
        protected T[] _data = new T[10];

        public int Length
        {
            get { return _data.Length; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Vector index is out of range");
                }
                return _data[index];
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Vector index is out of range");
                }
                _data[index] = value;
            }
        }

        private class VectorEnumerator : IEnumerator<T>
        {
            private T[] _data;
            private int _index = -1;

            public VectorEnumerator(T[] data)
            {
                _data = new T[data.Length];
                data.CopyTo(_data, 0);
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _data.Length;
            }

            public void Reset()
            {
                _index = -1;
            }

            public T Current { get { return _data[_index]; } }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new VectorEnumerator(_data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
