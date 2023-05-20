using SaodCP.Models;
using SaodCP.Utils;
using System.Text.RegularExpressions;

namespace SaopCPTest
{
    [TestClass]
    public class LodgerTest
    {
        /// <summary>
        /// Тестирование генерации случайного Id паспорта
        /// </summary>
        [TestMethod]
        public void RandomPassportIdTest()
        {
            var pattern = @"\d\d\d\d-\d\d\d\d\d\d";

            for (int i = 0; i < 1000; i++)
            {
                var id = Utils.GenerateRandomPassportId();

                Assert.IsTrue(Regex.IsMatch(id, pattern));
            }
        }

        /// <summary>
        /// Тестирование функции проверки формата Id паспорта
        /// </summary>
        [TestMethod]
        public void PassportIdValidationTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var id = Utils.GenerateRandomPassportId();

                Assert.IsTrue(Utils.ValidateLodgerPassportId(id));
            }

            var passportId = string.Empty;

            Assert.IsFalse(Utils.ValidateLodgerPassportId(passportId));

            passportId = "0000-00000A";

            Assert.IsFalse(Utils.ValidateLodgerPassportId(passportId));

            passportId = "0000000000";

            Assert.IsFalse(Utils.ValidateLodgerPassportId(passportId));

            passportId = "0000-1231234";

            Assert.IsFalse(Utils.ValidateLodgerPassportId(passportId));

            passportId = "00001-231234";

            Assert.IsFalse(Utils.ValidateLodgerPassportId(passportId));
        }

        /// <summary>
        /// Тестирование создания постояльца и генерации ИД паспорта
        /// </summary>
        [TestMethod]
        public void CreateLodgerTest()
        {
            var lodger = new Lodger();

            Assert.IsNotNull(lodger);

            lodger.PassportId = Utils.GenerateRandomPassportId();

            Assert.IsTrue(Utils.ValidateLodgerPassportId(lodger.PassportId));
        }
    }
}