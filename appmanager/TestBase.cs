using NUnit.Framework;
using System;
using System.Text;

namespace addressbook_tests
{
    public class TestBase
    {
        protected ApplicationManager app;

        // [SetUp] = Operation before each test:
        [SetUp]
        public void SetupAppManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() + max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 20)));
            }
            return builder.ToString();
        }

        public static Random rnd = new Random();


    }
}
