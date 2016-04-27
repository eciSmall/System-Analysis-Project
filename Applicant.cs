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
    public class Applicant
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
                objCommand.CommandText = "SELECT COUNT(*) FROM applicant";
                int length = Convert.ToInt32(objCommand.ExecuteScalar());
                objCommand.CommandText = "INSERT INTO applicant (applicantID, username, password) VALUES ('" + length + "', '" + username + "', '" + sh.get() + "')";
                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            objConnection.Close();
        }

        public void DeleteFromDb()
        {
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            try
            {

                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "DELETE FROM applicant";
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
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            try
            {
                sh = new Sha1(ask);
                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "UPDATE applicant SET password = '" + sh.get() + "'WHERE username = '" + condition + "'";
                objCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            objConnection.Close();
        }
        public bool existCheck(string pKey)
        {
            bool exist = false;
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            try
            {
                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "SELECT username FROM applicant WHERE username = '" + pKey + "'";
                if (objCommand.ExecuteScalar().ToString() == pKey)
                {
                    exist = true;
                }
                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            objConnection.Close();
            return exist;
        }
        public bool applicantAccessConfirm(string username, string password)
        {
            sh = new Sha1(password);
            bool confirm = false;
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            try
            {
                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "SELECT password FROM applicant WHERE username = '" + username + "'";
                if (objCommand.ExecuteScalar().ToString() == sh.get())
                {
                    confirm = true;
                }
                objCommand.ExecuteNonQuery();

            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.ToString());
            }
            objConnection.Close();
            return confirm;
        }
    }
}