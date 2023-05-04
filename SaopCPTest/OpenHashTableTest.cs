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
    }
}
