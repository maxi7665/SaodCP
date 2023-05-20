namespace SaodCP.Algorithms
{
    /// <summary>
    /// Алгоритм поиска подстроки в строке Боуэра и Мура
    /// </summary>
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

            int[] shiftArray = FillShiftArray(search);

            int startSearch = 0;
            int foundPosition = 0;

            /// поиск в строке, пока подстрока не выходит за её пределы
            while (startSearch + search.Length <= text.Length)
            {
                bool hasDifferences = false;

                int textCharInSearchPosition = -1;

                // посимвольное сравнение с конца подстроки
                for (int i = search.Length - 1; i >= 0; i--)
                {
                    var textIndex = startSearch + i;

                    if (search[i] != text[textIndex])
                    {
                        // найдено расхождение
                        hasDifferences = true;

                        // поиск несовпадшего символа в подстроке
                        for (int j = 0; j < search.Length; j++)
                        {
                            if (search[j] == text[textIndex])
                            {
                                // индекс несовпадшего символа из строки в подстроке
                                // начиная с начала подстроки
                                textCharInSearchPosition = j;
                            }
                        }

                        break;
                    }
                }

                int offset;

                if (textCharInSearchPosition == -1)
                {
                    // несовпадший символ не содержится в подстроке - 
                    // сдвигаем подстроку на всю её длину вправо
                    offset = search.Length;
                }
                else
                {
                    // количество символов для сдвига равно расстоянию от последнего
                    // вхождения несовпадшего символа в подстроку до конца подстроки
                    offset = shiftArray[textCharInSearchPosition];
                }

                // если найдено расхождение
                // позиция поиска смещается, поиск повторяется
                if (hasDifferences == true)
                {
                    startSearch += offset;
                }
                else
                {
                    // иначе - найдено вхождение подстроки, поиск завершен
                    foundPosition = startSearch + 1;

                    break;
                }
            }

            return foundPosition;
        }

        /// <summary>
        /// Заполнение сдвигов для символов в подстроке
        /// </summary>
        /// <param name="search">Подстрока</param>
        /// <returns></returns>
        private static int[] FillShiftArray(string search)
        {
            // размер таблицы сдвигов равен длине подстроки
            var shiftArray = new int[search.Length];

            // для каждого символа в строке вычисляется расстояние от конца
            // подстроки до последнего вхождения аналогичного символа
            for (int i = 0; i < search.Length; i++)
            {
                var c = search[i];

                shiftArray[i] = search.Length;

                for (int j = search.Length - 1; j >= 0; j--)
                {
                    if (c == search[j])
                    {
                        int lastOccurenceIdx = j;
                        shiftArray[i] = search.Length - j - 1;

                        break;
                    }
                }
            }

            return shiftArray;
        }
    }
}