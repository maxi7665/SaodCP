using SaodCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaodCP.Utils
{
    public static class Utils
    {
        public static bool ValidateLodgerPassportId(
            string? passportId)
        {
            var refString = string.Empty;

            return ValidateLodgerPassportId(passportId, ref refString);
        }

        /// <summary>
        /// Проверка формата номера паспорта
        /// </summary>
        /// <param name="passportId">Номер паспорта</param>
        /// <param name="error">Описание ошибки</param>
        public static bool ValidateLodgerPassportId(
            string? passportId,
            ref string? error)
        {
            if (string.IsNullOrWhiteSpace(passportId))
            {
                error = "Номер паспорта должен быть заполнен";

                return false;
            }

            var ret = true;

            if (passportId.Length != 11)
            {
                ret = false;
            }

            var allowedCharactersArray = new char[]
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };

            var delimiter = '-';

            if (ret)
            {
                for (var i = 0; i < passportId.Length; i++)
                {
                    var c = passportId[i];

                    if (i == 4)
                    {
                        if (c == delimiter)
                        {
                            continue;
                        }
                        else
                        {
                            ret = false;

                            break;
                        }
                    }

                    var found = false;

                    for (var j = 0; j < allowedCharactersArray.Length; j++)
                    {
                        if (c == allowedCharactersArray[j])
                        {
                            found = true;

                            break;
                        }
                    }

                    if (!found)
                    {
                        ret = false;

                        break;
                    }
                }
            }

            if (!ret)
            {
                error = $"Номер паспорта должен соответствовать шаблону {Lodger.PassportIdPattern}";
            }

            return ret;
        }

        public static string GenerateRandomPassportId()
        {
            var chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            var passportIdCharArray = new char[11];

            var random = new Random();

            for (int i = 0; i < passportIdCharArray.Length; i++)
            {
                if (i == 4)
                {
                    passportIdCharArray[i] = '-';

                    continue;
                }

                passportIdCharArray[i] = chars[random.Next(chars.Length - 1)];
            }

            return new string(passportIdCharArray);
        }

        /// <summary>
        /// The hash code for a String object is computed as
        // s[0]*31^(n-1) + s[1]*31^(n-2) + ... + s[n-1]
        // using int arithmetic, 
        // where s[i] is the i-th character of the string, 
        // n is the length of the string, 
        // and ^ indicates exponentiation. 
        // (The hash value of the empty string is zero.)
        /// </summary>
        /// <param name="_key"></param>
        /// <returns></returns>
        public static int HashCode(this string _key)
        {
            int h = 0;

            if (_key.Length > 0)
            {
                char[] val = _key.ToCharArray();

                for (int i = 0; i < _key.Length; i++)
                {
                    h = 31 * h + val[i];
                }
            }

            return (h);
        }

        public static T[] MergeSort<T> (
            this T[] array, 
            Comparison<T>? comparer = null)
        {
            if (array.Length == 0
                || array.Length == 1)
            {
                return (T[])array.Clone();
            }

            Comparison<T> comp;

            if (comparer == null)
            {
                if (!(array[0] is IComparable))
                {
                    throw new ApplicationException(
                        $"Comparator is not found and type {nameof(T)} is not IComparable");
                }

                comp = (T f, T s) =>
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
            else
            {
                comp = comparer;
            }

            T[] ret = (T[])array.Clone();

            ret = SortArray(array, 0, array.Length - 1);

            return ret;

            T[] SortArray(T[] array, int left, int right)
            {
                if (left < right)
                {
                    int middle = left + (right - left) / 2;
                    SortArray(array, left, middle);
                    SortArray(array, middle + 1, right);
                    MergeArray(array, left, middle, right);
                }

                return array;
            }

            void MergeArray(T[] array, int left, int middle, int right)
            {
                var leftArrayLength = middle - left + 1;
                var rightArrayLength = right - middle;
                var leftTempArray = new T[leftArrayLength];
                var rightTempArray = new T[rightArrayLength];
                int i, j;

                for (i = 0; i < leftArrayLength; i++)
                {
                    leftTempArray[i] = array[left + i];
                }
                for (j = 0; j < rightArrayLength; j++)
                {
                    rightTempArray[j] = array[middle + 1 + j];
                }

                i = 0;
                j = 0;
                int k = left;

                while (i < leftArrayLength 
                    && j < rightArrayLength)
                {
                    var comparison = comp(leftTempArray[i], rightTempArray[j]);
                    
                    if (comparison <= 0)
                    {
                        array[k++] = leftTempArray[i++];
                    }
                    else
                    {
                        array[k++] = rightTempArray[j++];
                    }
                }

                while (i < leftArrayLength)
                {
                    array[k++] = leftTempArray[i++];
                }

                while (j < rightArrayLength)
                {
                    array[k++] = rightTempArray[j++];
                }
            }

            return ret;
        }
    }
}
