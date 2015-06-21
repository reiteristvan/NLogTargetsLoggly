using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;

namespace NLogTargetsLoggly.Tests
{
    [TestClass]
    public class NLogTargetsLogglyTest
    {
        [TestMethod]
        public void Test()
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Log(LogLevel.Debug, "This is a message");
        }
    }
}
