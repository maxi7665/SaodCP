using SaodCP.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaopCPTest
{
    [TestClass]
    public class OpenHashTableTest
    {
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

            foreach(KeyValuePair<string, string> pair in pairs)
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
    }
}
