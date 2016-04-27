using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homi.Models
{
    public class Models
    {
        private string adminUser;
        private string adminPass;
        public void setAdminUser(string username)
        {
            adminUser = username;
        }
        public void setAdminPass(string password)
        {
            adminPass = password;
        }
    }
}