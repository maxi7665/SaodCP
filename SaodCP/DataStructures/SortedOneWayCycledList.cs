using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaodCP.DataStructures
{
    /// <summary>
    /// Отсортированный список
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortedOneWayCycledList<T> : OneWayCycledList<T>
    {
        private Comparison<T> _comparison;

        /// <summary>
        /// Делегат для сравнения элементов
        /// </summary>
        public Comparison<T> Comparison 
        { 
            get => _comparison; 
            set 
            { 
                _comparison = value; 

                if (Count > 1)
                {
                    Sort();
                }
            }
        }

        /// <summary>
        /// Создает список для типа, являющегося IComparable
        /// </summary>
        public SortedOneWayCycledList()
        {
            var type = typeof(T);

            if (!typeof(IComparable<T>).IsAssignableFrom(type))
            {
                throw new ApplicationException($"{nameof(T)} is not {nameof(IComparable)}"
                    + ", use constructor with a Comparison instead");
            }

            _comparison = (f, s) =>
            {
                if (f != null)
                {
                    return ((IComparable)f).CompareTo(s);
                }
                else
                {
                    throw new ArgumentNullException(nameof(f));
                }
            };
        }

        public SortedOneWayCycledList(Comparison<T> comparison)
        {
            _comparison = comparison;
        }

        /// <summary>
        /// Добавление элемента, затем сортировка списка
        /// Работает за O(n log(n))
        /// </summary>
        /// <param name="element"></param>
        public new void Add(T element)
        {
            base.Add(element);

            Sort(_comparison);
        }
    }
}
