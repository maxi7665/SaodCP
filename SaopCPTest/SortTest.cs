﻿using SaodCP.DataStructures;
using SaodCP.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaopCPTest
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        public void ArraySortTest()
        {
            Random randNum = new Random();

            int[] source = Enumerable
                .Repeat(0, 50)
                .Select(i => randNum.Next(100))
                .ToArray();

            // сортировка по умолчанию (возрастанию)
            var testDest = source.MergeSort();

            var trustList = source.ToList();

            trustList.Sort();

            var trustDest = trustList.ToArray();

            Assert.AreEqual(trustDest.Length, testDest.Length);
            
            for (int i = 0; i < trustDest.Length; i++)
            {
                Assert.AreEqual(trustDest[i], testDest[i]);
            }

            // сортировка по убыванию
            Comparison<int> comparison = (f, s) => - f.CompareTo(s);

            testDest = source.MergeSort(comparison);

            trustList = source.ToList();

            trustList.Sort(comparison);

            trustDest = trustList.ToArray();

            Assert.AreEqual(trustDest.Length, testDest.Length);

            for (int i = 0; i < trustDest.Length; i++)
            {
                Assert.AreEqual(trustDest[i], testDest[i]);
            }
        }

        [TestMethod]
        public void SortedListTest()
        {
            Random randNum = new Random();

            int[] source = Enumerable
                .Repeat(0, 50)
                .Select(i => randNum.Next(100))
                .ToArray();

            var trustList = source.ToList();

            trustList.Sort();

            var trustDest = trustList.ToArray();

            var sortedList = new SortedOneWayCycledList<int>();

            foreach (int i in source)
            {
                sortedList.Add(i);
            }

            int cnt = 0;

            foreach(int element in sortedList)
            {
                Assert.AreEqual(element, trustDest[cnt]);

                cnt++;
            }
        }
    }
}
