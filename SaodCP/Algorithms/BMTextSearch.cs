using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaodCP.Algorithms
{
    public static class BMTextSearch
    {
        /// <summary>
        /// Поиск строки в тексте
        /// </summary>
        /// <param name="text">Текст, в котором производить поиск</param>
        /// <param name="search">Строка для поиска</param>
        /// <returns>Номер начала первого вхождения строки в текст</returns>
        public static int TextSearch(
            string text, 
            string search)
        {
            if (text.Length == 0
                || search.Length == 0)
            {
                return 0;
            }

            int[] shiftArray = FillShiftArray(text, search);

            int startSearch = 0;
            int foundPosition = 0;

            while (startSearch + search.Length <= text.Length)
            {
                bool hasDifferences = false;

                int textCharInSearchPosition = -1;

                for (int i = search.Length - 1; i >= 0; i --)
                {
                    var textIndex = startSearch + i;

                    if (search[i] != text[textIndex])
                    {
                        hasDifferences = true;

                        for (int j = 0; j < search.Length; j ++)
                        {
                            if (search[j] == text[textIndex])
                            {
                                textCharInSearchPosition = j;
                            }
                        }

                        break;
                    }
                }

                int offset;

                if (textCharInSearchPosition == -1)
                {
                    offset = search.Length;
                }
                else
                {
                    offset = shiftArray[textCharInSearchPosition];
                }

                // если найдено расхождение
                // позиция поиска смещается на значение из таблицы сдвигов
                if (hasDifferences == true)
                {
                    startSearch += offset;
                }
                else
                {
                    // иначе - найдено вхождение подстроки
                    foundPosition = startSearch + 1;

                    break;
                }
            }

            return foundPosition;
        }

        private static int[] FillShiftArray(string text, string search)
        {
            var shiftArray = new int[search.Length];

            for (int i = 0; i < search.Length; i++)
            {
                int lastOccurenceIdx = 0;

                var c = search[i];

                shiftArray[i] = search.Length;

                for (int j = text.Length - 1; j >= 0; j--)
                {
                    if (c == text[j])
                    {
                        lastOccurenceIdx = j;

                        shiftArray[i] = text.Length - j - 1;

                        break;
                    }
                }
            }

            return shiftArray;
        }
    }
}
