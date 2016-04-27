using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Homi.Models
{
    public class Sha1
    {
        private string sh1;
        public Sha1(string password)
        {
            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] result = sh.Hash;
            StringBuilder sB = new StringBuilder();
            foreach(byte b in result)
            {
                sB.Append(b.ToString("x2"));
            }
            sh1 = sB.ToString();
        }
        public string get()
        {
            return sh1;
        }
    }
}