using SaodCP.DataStructures;

namespace SaopCPTest
{
    /// <summary>
    /// Тестирование хеш-таблицы
    /// </summary>
    [TestClass]
    public class OpenHashTableTest
    {
        /// <summary>
        /// Создать, добавить, получить
        /// </summary>
        [TestMethod]
        public void CreateAddGetTest()
        {
            OpenHashTable<string, string> hashTable = new();

            Assert.AreEqual(0, hashTable.Count);

            hashTable.Add("1", "2");

            Assert.AreEqual(1, hashTable.Count);

            var value = hashTable["1"];

            Assert.AreEqual("2", value);
        }

        /// <summary>
        /// Нагрузочное тестирование - добавление 1000000 элементов
        /// Тестирование удаление элементов
        /// Тестирование перечисления элементов
        /// </summary>
        [TestMethod]
        public void RebalanceRemoveTest()
        {
            Random rnd = new Random();

            // на 1000000 отрабатывает за 6с на i7-10610U
            int cnt = 1000000;

            Dictionary<string, string> pairs = new();

            for (int i = 0; i < cnt; i++)
            {
                var key = rnd.Next().ToString();

                if (!pairs.ContainsKey(key))
                {
                    pairs.Add(key, rnd.Next().ToString());
                }
            }

            OpenHashTable<string, string> hashTable = new();

            int count = 0;

            foreach (KeyValuePair<string, string> pair in pairs)
            {
                hashTable.Add(pair.Key, pair.Value);

                count++;

                Assert.AreEqual(count, hashTable.Count);
            }

            Console.WriteLine("Вставка пройдена");

            Assert.AreEqual(count, hashTable.Count);

            foreach (KeyValuePair<string, string> pair in pairs)
            {
                Assert.AreEqual(hashTable[pair.Key], pair.Value);
            }

            Console.WriteLine("Сверка элементов пройдена");

            foreach (KeyValuePair<string, string> pair in pairs)
            {
                count--;

                hashTable.Remove(pair.Key);

                Assert.AreEqual(hashTable.Count, count);
            }

            Assert.AreEqual(hashTable.Count, 0);

            Console.WriteLine("Удаление элементов пройдено");
        }

        /// <summary>
        /// Тестирование корректной работы с хеш-значениями
        /// </summary>
        [TestMethod]
        public void CustomHashTest()
        {
            var hashTable = new OpenHashTable<HashString, string>();

            int cnt = 10000;

            Random rnd = new Random();

            Dictionary<HashString, string> pairs = new();

            for (int i = 0; i < cnt; i++)
            {
                var key = rnd.Next().ToString();

                if (!pairs.ContainsKey(key))
                {
                    pairs.Add(key, rnd.Next().ToString());
                }
            }

            foreach (var (key, value) in pairs)
            {
                hashTable.Add(key, value);
            }

            var keys = new HashSet<HashString>();

            var enumerator = hashTable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                keys.Add(enumerator.Current.Key);
            }

            //Assert.AreEqual(pairs.Keys.ToHashSet(), keys.ToHashSet());

            var except = pairs.Keys.ToHashSet().Except(hashTable.Keys);

            Assert.AreEqual(except.Count(), 0);
            Assert.IsTrue(pairs.Values.ToHashSet().SetEquals(hashTable.Values.ToHashSet()));
            Assert.AreEqual(pairs.Count, hashTable.Count);
        }
    }
}