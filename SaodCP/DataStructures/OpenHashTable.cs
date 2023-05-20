using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace SaodCP.DataStructures
{
    /// <summary>
    /// Хеш-таблица, открытое хеширование
    /// </summary>
    public class OpenHashTable<T, O> : IDictionary<T, O>
    {
        // стартовое количество бакетов (размер таблицы)
        protected static readonly int START_BUCKETS_NUM = 2048;

        // таблица - массив связных списков, элементами
        // которых являются пары ключ-значение
        protected OneWayCycledList<KeyValuePair<T, O>>[] keyValuePairs =
            new OneWayCycledList<KeyValuePair<T, O>>[START_BUCKETS_NUM];

        protected void Init()
        {
            keyValuePairs = new OneWayCycledList<KeyValuePair<T, O>>[START_BUCKETS_NUM];
            Count = 0;
        }

        /// <summary>
        /// Расширение хеш-корзины в 2 раза
        /// </summary>
        protected void Expand()
        {
            var oldKeyValuePairs = keyValuePairs;

            keyValuePairs = new OneWayCycledList<KeyValuePair<T, O>>[keyValuePairs.Length * 2];
            Count = 0;

            foreach (var list in oldKeyValuePairs)
            {
                if (list == null)
                {
                    continue;
                }

                foreach (var pair in list)
                {
                    this.Add(pair);
                }
            }
        }

        /// <summary>
        /// Расчет ячейки таблицы для ключа
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected int GetBucketNumberByKey(T key)
        {
            var number = key?.GetHashCode() % keyValuePairs.Length
                ?? throw new ArgumentNullException(nameof(key));

            return number >= 0
                ? number
                : -number;
        }

        public O this[T key]
        {
            get
            {
                int bucket = GetBucketNumberByKey(key);

                var list = keyValuePairs[bucket];

                if (list == null)
                {
                    return default;
                }

                foreach (var pair in list)
                {
                    if (pair.Key?.Equals(key) ?? false)
                    {
                        return pair.Value;
                    }
                }

                return default;
            }
            set
            {
                Add(key, value);
            }
        }

        public ICollection<T> Keys => this.Select(kv => kv.Key).ToHashSet();

        public ICollection<O> Values => this.Select(kv => kv.Value).ToHashSet();

        public int Count { get; protected set; } = 0;

        public bool IsReadOnly => false;

        public void Add(T key, O value)
        {
            int bucket = GetBucketNumberByKey(key);

            if (keyValuePairs[bucket] == null)
            {
                keyValuePairs[bucket] = new();
            }

            var list = keyValuePairs[bucket];

            // если длина списка превышает допустимое значение
            // попытка учесть и плохое распределение, когда заполняется мало ячеек
            // и наоборот хорошее, когда элементы равномерно "размазываются" по всем спискам
            if (list.Count >= keyValuePairs.Length
                || Count > keyValuePairs.Length * 10)
            {
                Expand();

                Add(key, value);

                return;
            }

            KeyValuePair<T, O>? kv = null;

            foreach (var kvPair in list)
            {
                if (kvPair.Key?.Equals(key) ?? false)
                {
                    kv = kvPair;
                }
            }

            if (kv != null)
            {
                list.Remove((KeyValuePair<T, O>)kv);
            }

            list.Add(new(key, value));

            Count++;
        }

        public void Add(KeyValuePair<T, O> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Init();
        }

        public bool Contains(KeyValuePair<T, O> item)
        {
            var bucketNum = GetBucketNumberByKey(item.Key);

            var list = keyValuePairs[bucketNum];

            if (list == null)
            {
                return false;
            }

            foreach (var kv in list)
            {
                if (kv.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsKey(T key)
        {
            var bucketNum = GetBucketNumberByKey(key);

            var list = keyValuePairs[bucketNum];

            if (list == null)
            {
                return false;
            }

            foreach (var kv in list)
            {
                if (kv.Key?.Equals(key) ?? false)
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(KeyValuePair<T, O>[] array, int arrayIndex)
        {
            foreach (var kv in this)
            {
                array[arrayIndex++] = kv;
            }
        }

        public IEnumerator<KeyValuePair<T, O>> GetEnumerator()
        {
            return new OpenHashTableEnumerator(this);
        }

        /// <summary>
        /// Удалить пару из таблицы по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(T key)
        {
            var bucket = GetBucketNumberByKey(key);

            var list = keyValuePairs[bucket];

            if (list == null)
            {
                return false;
            }

            KeyValuePair<T, O>? keyValue = null;

            foreach (var kv in list)
            {
                if (kv.Key?.Equals(key) ?? false)
                {
                    keyValue = kv;
                }
            }

            if (keyValue != null)
            {
                var ret = list.Remove((KeyValuePair<T, O>)keyValue);

                if (ret)
                {
                    Count--;
                }

                return ret;
            }

            return false;
        }

        /// <summary>
        /// Удалить пару из таблицы
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<T, O> item)
        {
            var bucket = GetBucketNumberByKey(item.Key);

            var list = keyValuePairs[bucket];

            if (list == null)
            {
                return false;
            }

            KeyValuePair<T, O>? keyValue = null;

            foreach (var kv in list)
            {
                if (kv.Equals(item))
                {
                    keyValue = kv;
                }
            }

            if (keyValue != null)
            {
                var ret = list.Remove((KeyValuePair<T, O>)keyValue);

                if (ret)
                {
                    Count--;
                }

                return ret;
            }

            return false;
        }

        /// <summary>
        /// Получить значение
        /// </summary>
        public bool TryGetValue(T key, [MaybeNullWhen(false)] out O value)
        {
            if (!ContainsKey(key))
            {
                value = default;

                return false;
            }

            value = this[key];

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public class OpenHashTableEnumerator : IEnumerator<KeyValuePair<T, O>>
        {
            private readonly OpenHashTable<T, O> _table;

            private int _currentBucket = -1;

            private IEnumerator<KeyValuePair<T, O>>? _currentListEnumerator;

            private bool _isDisposed;

            public OpenHashTableEnumerator(OpenHashTable<T, O> table)
            {
                _table = table;
            }

            public KeyValuePair<T, O> Current => _currentListEnumerator?.Current ?? default;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                if (_isDisposed)
                {
                    throw new ObjectDisposedException(GetType().FullName);
                }

                _isDisposed = true;
            }

            public bool MoveNext()
            {
                // работа с текущим итератором списка
                if (_currentListEnumerator != null)
                {
                    if (_currentListEnumerator.MoveNext())
                    {
                        return true;
                    }
                    else
                    {
                        _currentListEnumerator = null;
                    }
                }

                OneWayCycledList<KeyValuePair<T, O>>? list = null;

                while (list == null
                    && _currentBucket < _table.keyValuePairs.Length - 1)
                {
                    list = _table.keyValuePairs[++_currentBucket];
                }

                if (list == null)
                {
                    return false;
                }
                else
                {
                    _currentListEnumerator = list.GetEnumerator();

                    if (_currentListEnumerator != null)
                    {
                        return MoveNext();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
