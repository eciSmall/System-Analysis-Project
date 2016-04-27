using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Homi.Models
{
    public class modelLayOut
    {
        private WebAdmin wa = new WebAdmin();
        private Applicant app = new Applicant();
        private agency ag = new agency();
        private CurrentUser cU = new CurrentUser();
        //applicant
        public bool applicantExistCheck(string pKey)
        {
            return app.existCheck(pKey);
        }
        public void insertNewApplicant(string username, string password)
        {
            app.InsertToDb(username, password);
        }

        public bool applicantAccess(string username, string password)
        {
            return(app.applicantAccessConfirm(username, password));
        }

        //agency
        public bool agencyAccess(string username, string password)
        {
            return (ag.applicantAccessConfirm(username, password));
        }

        public bool agencyExistCheck(string username)
        {
            return ag.existCheck(username);
        }
        public void insertNewAgency(string name, string address, int phoneNumber, string username, string password)
        {
            ag.InsertToDb(name, address, phoneNumber, username, password);
        }
        //webAdmin
        public bool webAdminAccess(string username, string password)
        {
            return (wa.webAdminAccessConfirm(username, password));
        }

        //CurrentUser
        public void setCurrent(string currentUser)
        {
            cU.getUser(currentUser);
        }
        public string returnCurrent()
        {                       
            return cU.returnCurrentName();
        }
        //public void getAdminUsername(string username)
        //{
        //    m.setAdminUser(username);
        //    m.setAdminPass(username);
        //}
        //public void getAdminPassword(string password)
        //{
        //    m.setAdminPass(password);
        //}
        public void dod(string username)
        {
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
   
                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
            objCommand.CommandText = "SELECT COUNT(*) FROM dod";
            int length = Convert.ToInt32(objCommand.ExecuteScalar());
            if (username == "admin")
            {
                objCommand.CommandText = "INSERT INTO dod (iddod, username) VALUES ('" + length + "', '" + username + "')";
                objCommand.ExecuteNonQuery();
                objConnection.Close();
            }
            else
            {
                objCommand.CommandText = "INSERT INTO dod (iddod, username) VALUES ('0', '2')";
                objCommand.ExecuteNonQuery();
                objConnection.Close();
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "INSERT INTO dod (iddod, username) VALUES ('1', '3')";
                objCommand.ExecuteNonQuery();
                objConnection.Close();
            }
            
 
            
        }
        public string dod2()
        {
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            objConnection.Open();
            MySqlCommand objCommand2 = new MySqlCommand();
            objCommand2.Connection = objConnection;
            objCommand2.CommandText = "SELECT COUNT(*) FROM dod";
            int length = Convert.ToInt32(objCommand2.ExecuteScalar());
            if (length == 1)
            {
                objCommand2.CommandText = "DELETE FROM dod";
                objCommand2.ExecuteNonQuery();
                objConnection.Close();
                return "admin";
            }
            objCommand2.CommandText = "DELETE FROM dod";
            objCommand2.ExecuteNonQuery();
            objConnection.Close();
            return "o";

        }
    }
}