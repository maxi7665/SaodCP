using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Client;
using SaodCP.DataStructures;
using SaodCP.Models;
using SaodCP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaopCPTest
{
    [TestClass]
    public class CycledListTest
    {
        [TestMethod]
        public void CreateAddTest()
        {
            var list = new OneWayCycledList<Lodger>();

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count == 0);

            var lodgerArray = new Lodger[10];

            var rand = new Random();

            for (int i = 0; i < lodgerArray.Length; i++)
            {
                lodgerArray[i] = new Lodger();

                lodgerArray[i].PassportId = Utils.GenerateRandomPassportId();
                lodgerArray[i].Name = rand.GetHashCode().ToString();
            }

            for (int i = 0; i < lodgerArray.Length; i++)
            {
                list.Add(lodgerArray[i]);
            }

            Assert.AreEqual(lodgerArray.Length, list.Count);

            int pos = 0;
            
            foreach (var lodger in list)
            {
                Assert.AreEqual(lodger, lodgerArray[pos]);
                Assert.IsTrue(list.Contains(lodger));

                pos++;
            }

            Assert.IsTrue(list.Contains(lodgerArray[0]));

            list.Remove(lodgerArray[0]);

            Assert.IsFalse(list.Contains(lodgerArray[0]));
            Assert.AreEqual(list.Count, lodgerArray.Length - 1);

            list.Clear();

            Assert.AreEqual(0, list.Count);

            var found = false;

            foreach(var lodger in list)
            {
                found = true; 
            }

            Assert.IsFalse(found);
        }
    }
}
