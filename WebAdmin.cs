using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using MySql.Data.MySqlClient;

namespace Homi.Models
{
    public class WebAdmin
    {
        private Sha1 sh;
        public void InsertToDb(string username, string password)
        {
            sh = new Sha1(password);
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            try
            {
                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "SELECT COUNT(*) FROM admin";
                int length = Convert.ToInt32(objCommand.ExecuteScalar());
                objCommand.CommandText = "INSERT INTO admin (adminID, username, password) VALUES ('" + length + "', '" + username + "', '" + sh.get() + "')";
                objCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            objConnection.Close();
        }

        public void DeleteFromDb(string tableName)
        {
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            try
            {

                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "DELETE FROM admin";
                objCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            objConnection.Close();
        }

        public void UpdateDb(string condition, string ask)
        {
            sh = new Sha1(ask);
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            try
            {
                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "UPDATE admin SET password = '" + sh.get() + "'WHERE username = '" + condition + "'";
                objCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            objConnection.Close();
        }
        public bool webAdminAccessConfirm(string username, string password)
        {
            sh = new Sha1(password);
            bool confirm = false;
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            try
            {
                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "SELECT password FROM admin WHERE username = '" + username + "'";
                string o = objCommand.ExecuteScalar().ToString();
                if (objCommand.ExecuteScalar().ToString() == sh.get())
                {
                    confirm = true;
                }
                objCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            objConnection.Close();
            return confirm;
        }
        //public void createAccountForAgency(string name, string address, int phoneNumber, string username, string password)
        //{
        //    ag.InsertToDb(name, address, phoneNumber, username, password);    
        //}

        //public void updateAccountForAgency(string condition, string ask, string whichOne)
        //{
        //    ag.UpdateDb(condition, ask, whichOne);
        //}
    }
}
