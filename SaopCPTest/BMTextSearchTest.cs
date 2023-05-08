using SaodCP.Algorithms;
using static SaodCP.Algorithms.BMTextSearch;

namespace SaopCPTest
{
    [TestClass]
    public class BMTextSearchTest
    {
        [TestMethod]
        public void SearchTest()
        {
            string text = string.Empty;
            string search = string.Empty;

            var found = TextSearch(text, search);

            Assert.AreEqual(0, found);

            text = "qwerty";
            search = "qwe";

            found = TextSearch(text, search);
            
            Assert.AreEqual(1, found);

            search = "werty";

            found = TextSearch(text, search);

            Assert.AreEqual(2, found);

            search = "y";

            found = TextSearch(text, search);

            Assert.AreEqual(6, found);

            search = "qwey";

            found = TextSearch(text, search);

            Assert.AreEqual(0, found);
        }
    }
}
