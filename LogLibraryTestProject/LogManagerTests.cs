using LogLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogLibraryTestProject
{
    [TestClass]
    public class LogManagerTests
    {
        [TestMethod]
        public void Test_Debug_Normal()
        {
            LogManager.Debug("log by test project");
        }
    }
}
