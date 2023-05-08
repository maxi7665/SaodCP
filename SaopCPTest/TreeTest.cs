using SaodCP.DataStructures;

namespace SaopCPTest
{
    /// <summary>
    /// Тесты для АВЛ-дерева поиска
    /// </summary>
    [TestClass]
    public class TreeTest
    {
        /// <summary>
        /// Создание, добавление, удаление элементов
        /// </summary>
        [TestMethod]
        public void CreateAddRemoveTest()
        {
            var tree = new Tree<string, object>();

            tree.Add("1");
            tree.Add("2");
            tree.Add("3");
            tree.Add("4");
            tree.Add("5");

            Assert.AreEqual(5, tree.Count);

            var intTree = new Tree<int, string>();

            for (int i = 0; i< 100; i++)
            {
                intTree.Add(i, i.ToString());
            }

            Assert.AreEqual(100, intTree.Count);

            var treeSet = intTree
                .Select(kv => kv.Key)
                .ToHashSet();

            var rangeSet = Enumerable.Range(0, 100).ToHashSet();

            Assert.IsTrue(treeSet.SetEquals(rangeSet));

            var count = intTree.Count;

            // проверка удаления
            var removed = intTree.Remove(100);

            Assert.IsFalse(removed);
            Assert.AreEqual(intTree.Count, count);

            foreach (var i in treeSet)
            {
                removed = intTree.Remove(i);

                // удаление успешно
                Assert.IsTrue(removed);

                // элемента больше не содержится в дереве
                Assert.IsFalse(intTree.Any(kv => kv.Key == i));

                // проверка корректности счетчика
                Assert.AreEqual(intTree.Count, --count);
            }
        }
    }
}
