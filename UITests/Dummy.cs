using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Scripts.Utilities;

namespace UITests
{
    class Dummy
    {
        static void Main(string[] args)
        {
            Dummy.run();
        }

        public static void run()
        {
            CommonOperations.TestFixturesetup();
            //RegressionTests.Search();
            CommonOperations.TestFixtureteardown();
        }
    }
}
