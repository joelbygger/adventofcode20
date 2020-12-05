using System;
using System.Collections;
using System.Collections.Generic;

namespace Day3
{

    // Inspiration taken from https://github.com/joaoportela/CircullarBuffer-CSharp
    internal class CircBuff<T> : IEnumerable<T>
    {
        private readonly T[] _buffer;
        private readonly int _size;
        private readonly int _start;
        private readonly int _end;

        public CircBuff(int capacity) :
            this(capacity, new T[] { })
        {

        }

        public CircBuff(int capacity, T[] items)
        {
            if (capacity < 1) {
                throw new ArgumentException(
                    "Circular buffer cannot have negative or zero capacity.", nameof(capacity));
            }
            else if (items == null) {
                throw new ArgumentNullException(nameof(items));
            }
            else if (items.Length > capacity) {
                throw new ArgumentException(
                    "Too many items to fit cicrular buffer.", nameof(items));
            }

            _buffer = new T[capacity];
            Array.Copy(items, _buffer, items.Length);
            _size = items.Length;
            _start = 0;
            _end = _size == capacity ? 0 : _size;
        }

        public int Capacity { get { return _buffer.Length; } }

        public bool IsEmpty
        {
            get {
                return Size == 0;
            }
        }
        public int Size { get { return _size; } }

        public T this[int index]
        {
            get {
                if (IsEmpty) {
                    throw new IndexOutOfRangeException(string.Format("Cannot access index {0}. Buffer is empty", index));
                }
                if (index >= _size) {
                    throw new IndexOutOfRangeException(string.Format("Cannot access index {0}. Buffer size is {1}", index, _size));
                }
                int actualIndex = InternalIndex(index);
                return _buffer[actualIndex];
            }
            set {
                if (IsEmpty) {
                    throw new IndexOutOfRangeException(string.Format("Cannot access index {0}. Buffer is empty", index));
                }
                if (index >= _size) {
                    throw new IndexOutOfRangeException(string.Format("Cannot access index {0}. Buffer size is {1}", index, _size));
                }
                int actualIndex = InternalIndex(index);
                _buffer[actualIndex] = value;
            }
        }

        #region IEnumerable<T> implementation
        public IEnumerator<T> GetEnumerator()
        {
            var segments = new ArraySegment<T>[2] { ArrayOne(), ArrayTwo() };
            foreach (ArraySegment<T> segment in segments) {
                for (int i = 0; i < segment.Count; i++) {
                    yield return segment.Array[segment.Offset + i];
                }
            }
        }
        #endregion
        #region IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        #endregion

        private void Increment(ref int index)
        {
            if (++index == Capacity) {
                index = 0;
            }
        }
        private void Decrement(ref int index)
        {
            if (index == 0) {
                index = Capacity;
            }
            index--;
        }

        private int InternalIndex(int index)
        {
            return _start + (index < (Capacity - _start) ? index : index - Capacity);
        }
        public int PlaceIndexInBounds(int index)
        {
            return _start + (index < (Capacity - _start) ? index : index % Capacity);
        }

        // doing ArrayOne and ArrayTwo methods returning ArraySegment<T> as seen here: 
        // http://www.boost.org/doc/libs/1_37_0/libs/circular_buffer/doc/circular_buffer.html#classboost_1_1circular__buffer_1957cccdcb0c4ef7d80a34a990065818d
        // http://www.boost.org/doc/libs/1_37_0/libs/circular_buffer/doc/circular_buffer.html#classboost_1_1circular__buffer_1f5081a54afbc2dfc1a7fb20329df7d5b
        // should help a lot with the code.

        #region Array items easy access.
        // The array is composed by at most two non-contiguous segments, 
        // the next two methods allow easy access to those.

        private ArraySegment<T> ArrayOne()
        {
            if (IsEmpty) {
                return new ArraySegment<T>(new T[0]);
            }
            else if (_start < _end) {
                return new ArraySegment<T>(_buffer, _start, _end - _start);
            }
            else {
                return new ArraySegment<T>(_buffer, _start, _buffer.Length - _start);
            }
        }

        private ArraySegment<T> ArrayTwo()
        {
            if (IsEmpty) {
                return new ArraySegment<T>(new T[0]);
            }
            else if (_start < _end) {
                return new ArraySegment<T>(_buffer, _end, 0);
            }
            else {
                return new ArraySegment<T>(_buffer, 0, _end);
            }
        }
        #endregion
    }
}