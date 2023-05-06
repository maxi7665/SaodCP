using SaodCP.DataStructures;

namespace SaopCPTest
{
    [TestClass]
    public class TreeTest
    {
        [TestMethod]
        public void CreateTest()
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
        }
    }
}
