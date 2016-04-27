using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homi.Models
{
    public class CurrentUser
    {
        public string currentUser;
        public void getUser(string current)
        {
            currentUser = current;
            test();
        }
        public void test()
        {
            string o = currentUser;
        }
        public string returnCurrentName()
        {
            return currentUser;
        }
    }
}