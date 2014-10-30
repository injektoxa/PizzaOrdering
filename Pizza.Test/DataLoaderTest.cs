using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza.DataAccess;

namespace Pizza.Test
{
    [TestClass]
    public class DataLoaderTest
    {
        [TestMethod]
        public void LoadTestData()
        {
            SqlRepositoryTestLoader.Load();
        }
    }
}