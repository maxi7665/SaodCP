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
    }
}
