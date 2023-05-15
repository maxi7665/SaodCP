using System.Collections;

namespace SaodCP.DataStructures
{
    /// <summary>
    /// Односвязный циклический список
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OneWayCycledList<T> : ICollection<T>, IEnumerator<T>
    {
        protected OneWayLinkedListElement<T>? _first;
        protected OneWayLinkedListElement<T>? _last;
        protected OneWayLinkedListElement<T>? _current;

        private bool _isDisposed = false;

        public int Count { get; protected set; } = 0;

        public bool IsReadOnly => false;

        public T Current
        {
            get 
            {
                if (_current == null)
                {
                    throw new NullReferenceException();
                }

                return _current.Value;
            }
        }

        object IEnumerator.Current => Current;

        public void Add(T item)
        {
            if (_last != null)
            {
                _last.Next = new (item);

                _last = _last.Next;

                _last.Next = _first;
            }
            else
            {
                _first = new(item);
                _last = _first;
                _first.Next = _last;
            }

            Count++;
        }

        public void Clear()
        {
            _first = null;
            _last = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var cnt = 0;            

            if (_first == null)
            {
                return false;
            }

            OneWayLinkedListElement<T> element = _first;

            while (cnt < Count)
            {
                if (element.Value?.Equals(item) ?? false)
                {
                    return true;
                }

                cnt++;

                if (element.Next == null)
                {
                    return false;
                }

                element = element.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int pos = arrayIndex;

            foreach(var element in this)
            {
                array[pos] = element;

                pos++;
            }
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }

            _isDisposed = true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            _isDisposed = false;            
            _current = null;
            
            return this;
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                _current = _first;

                return _current != null;
            }

            if (object.ReferenceEquals(_current, _last))
            {
                return false;
            }

            _current = _current.Next;            

            return true;
        }

        public bool Remove(T item)
        {            
            if (Count < 1)
            {
                return false;
            }
            
            if (_first == null)
            {
                return false;
            }

            if (_last == null)
            {
                return false;
            }

            var current = _first;
            OneWayLinkedListElement<T> prev = _last;

            do
            {
                if (current.Value?.Equals(item) ?? false)
                {
                    prev.Next = current.Next;

                    if (object.ReferenceEquals(_first, current))
                    {
                        _first = current.Next;
                    }

                    Count--;

                    if (Count < 1)
                    {
                        _first = null;
                        _last = null;
                    }

                    return true;
                }

                prev = current;

                current = current.Next;
            }
            while (current != null);

            return false;
        }

        public void Reset()
        {
            _current = null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Отсортировать элементы списка
        /// </summary>
        /// <param name="comparer"></param>
        public void Sort(Comparison<T>? comparer = null)
        {
            if (_first == null)
            {
                return;
            }

            if (_first.Value == null)
            {
                return;
            }

            T[] source = new T[Count];

            CopyTo(source, 0);

            var dest = Utils.Utils.MergeSort(source, comparer);

            Clear();

            foreach (var item in dest)
            {
                Add(item);
            }            
        }
    }

    /// <summary>
    /// Элемент односвязного списка
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OneWayLinkedListElement<T> : ICloneable
    {
        private readonly T _value;

        public OneWayLinkedListElement(T value)
        {
            _value = value;
        }

        public T Value { get => _value; }

        public OneWayLinkedListElement<T>? Next { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
