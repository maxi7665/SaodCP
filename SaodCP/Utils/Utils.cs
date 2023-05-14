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
        static readonly char[] NUMBER_CHARS = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static readonly char[] ROOM_NUMBER_FIRST_LITERAL = new char[] { 'Л', 'П', 'О', 'М' };

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

        public static bool ValidateRoomNumberId(
            string? roomNumber)
        {
            var str = string.Empty;

            return ValidateRoomNumberId(
                roomNumber,
                ref str);
        }

        /// <summary>
        /// Проверка формата номера комнаты
        /// </summary>
        /// <param name="passportId">Номер комнаты</param>
        /// <param name="error">Описание ошибки</param>
        public static bool ValidateRoomNumberId(
        string? roomNumber,
        ref string? error)
        {
            bool ret = true;

            var description = "Номер комнаты должен соответствовать формату «ANNN», " +
                "где A –\r\nбуква, обозначающая тип номера\r\n " +
                "(Л – люкс, П – полулюкс, О – одноместный, М – многоместный);\r\n " +
                "NNN – порядковый номер (цифры)";

            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                ret = false;
            }

            string number = roomNumber ?? string.Empty;

            if (number.Length != 4)
            {
                ret = false;

                error = description;

                return ret;
            }

            var firstLiteral = number[0];

            for (int i = 0; i < ROOM_NUMBER_FIRST_LITERAL.Length; i++)
            {
                if (firstLiteral == ROOM_NUMBER_FIRST_LITERAL[i])
                {
                    break;
                }

                if (i == ROOM_NUMBER_FIRST_LITERAL.Length - 1)
                {
                    ret = false;
                }
            }

            for (int i = 1; i < number.Length; i++)
            {
                for (int j = 0; j < NUMBER_CHARS.Length; j++)
                {
                    if (number[i] == NUMBER_CHARS[j])
                    {
                        break;
                    }

                    if (j == NUMBER_CHARS.Length - 1)
                    {
                        ret = false;
                    }
                }

                if (!ret)
                {
                    break;
                }
            }

            if (!ret)
            {
                error = description;
            }

            return ret;
        }

        public static string GenerateRandomPassportId()
        {
            var passportIdCharArray = new char[11];

            var random = new Random();

            for (int i = 0; i < passportIdCharArray.Length; i++)
            {
                if (i == 4)
                {
                    passportIdCharArray[i] = '-';

                    continue;
                }

                passportIdCharArray[i] = NUMBER_CHARS[random.Next(NUMBER_CHARS.Length - 1)];
            }

            return new string(passportIdCharArray);
        }

        /// <summary>
        /// Генерация случайного номера комнаты
        /// </summary>
        public static string GenerateRandomRoomNumber()
        {
            var random = new Random();

            char[] ret = new char[4];

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    ret[i] = ROOM_NUMBER_FIRST_LITERAL[random.Next(ROOM_NUMBER_FIRST_LITERAL.Length - 1)];
                }
                else
                {
                    ret[i] = NUMBER_CHARS[random.Next(NUMBER_CHARS.Length - 1)];
                }
            }

            return new string(ret);
        }

        public static string GetNextRoomNumber(string roomNumber)
        {
            if (!ValidateRoomNumberId(roomNumber))
            {
                throw new ArgumentException(null, nameof(roomNumber));
            }

            int number = 0;

            int multiplexor = 1;

            for (int i = 3; i > 0; i--)
            {
                number += NumCharToInt(roomNumber[i]) * multiplexor;

                multiplexor *= 10;
            }

            char[] ret = new char[4];

            ret[0] = roomNumber[0];

            var newNumberString = string.Format("{0}", number);

            ret[1] = newNumberString[0];
            ret[2] = newNumberString[1];
            ret[3] = newNumberString[2];

            return new string(ret);
        }

        public static int NumCharToInt(char c)
        { 
            for (int i = 0; i < NUMBER_CHARS.Length; i++)
            {
                if (c == NUMBER_CHARS[i])
                {
                    return i;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(c));
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

        public static T[] MergeSort<T>(
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
        }
    }
}
