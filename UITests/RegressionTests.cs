using log4net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UITests.Scripts.Utilities;

namespace UITests
{
    [TestFixture]
    class RegressionTests
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [OneTimeSetUp]
        public static void setup()
        {
            CommonOperations.TestFixturesetup();
        }

        [OneTimeTearDown]
        public static void teardown()
        {
            CommonOperations.TestFixtureteardown1();
        }

        [SetUp]
        public static void testSetup()
        {
            CommonOperations.testsetup();
        }

        [TearDown]
        public static void testTeardown()
        {
            CommonOperations.TestTeardown();
        }


    }
}
