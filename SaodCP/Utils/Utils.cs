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
                    var c = passportId[0];

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

                    for (var j = 1; j < allowedCharactersArray.Length; j++)
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
    }
}
