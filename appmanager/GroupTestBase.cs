using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                var fromUi = app.GroupHelper.GetGroups();
                var fromDb = app.GroupHelper.GetGroupsFromDB();
                fromDb.Sort();
                fromUi.Sort();

                Assert.AreEqual(fromUi, fromDb);
            }
            
        }
    }
}
