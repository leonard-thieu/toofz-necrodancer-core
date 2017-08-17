using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace toofz.NecroDancer.Tests
{
    [TestClass]
    public class TestsSetup
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            XmlConfigurator.Configure();
        }
    }
}
