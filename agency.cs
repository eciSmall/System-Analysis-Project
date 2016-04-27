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
    public class agency
    {
        Sha1 sh;
        public void InsertToDb(string name, string address, int phoneNumber, string username, string password)
        {
            sh = new Sha1(password);
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            //try
            //{
                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "SELECT COUNT(*) FROM agency";
                int length = Convert.ToInt32(objCommand.ExecuteScalar());
                objCommand.CommandText = "INSERT INTO agency (agencyID, username, password, phoneNumber, address, name) VALUES ('" + length + "', '" + username + "', '" + sh.get() + "', '" + phoneNumber + "', '" + address +"', '" + name + "')";
                objCommand.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            objConnection.Close();
        }

        public void DeleteFromDb()
        {
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            //try
            //{

                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "DELETE FROM agency";
                objCommand.ExecuteNonQuery();

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            objConnection.Close();
        }

        public void UpdateDb(string condition, string ask, string whichOne)
        {
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            //try
            //{
                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                if (whichOne == "password")
                {
                    sh = new Sha1(ask);
                    objCommand.CommandText = "UPDATE agency SET password = '" + sh.get() + "'WHERE username = '" + condition + "'";
                }
                else if(whichOne == "phoneNumber")
                {
                    objCommand.CommandText = "UPDATE agency SET phoneNumber = '" + ask + "'WHERE username = '" + condition + "'";
                }
                else if (whichOne == "address")
                {
                    objCommand.CommandText = "UPDATE agency SET address = '" + ask + "'WHERE username = '" + condition + "'";
                }
                else if (whichOne == "name")
                {
                    objCommand.CommandText = "UPDATE agency SET name = '" + ask + "'WHERE username = '" + condition + "'";
                }
                objCommand.ExecuteNonQuery();

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            objConnection.Close();
        }

        public bool existCheck(string username)
        {
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            //try
            //{
                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "SELECT username FROM agency WHERE username = '" + username + "'";
                if (objCommand.ExecuteScalar().ToString() == username)
                {
                    return true;
                }
                objCommand.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            objConnection.Close();
            return false;
        }
        public bool applicantAccessConfirm(string username, string password)
        {
            sh = new Sha1(password);
            bool confirm = false;
            MySqlConnection objConnection = new MySqlConnection("SERVER =127.0.0.1; " + "UserID=root;" + "password=ehsan;" + "DATABASE = homi; ");
            //try
            //{

                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "SELECT password FROM agency WHERE username = '" + username + "'";
                if (objCommand.ExecuteScalar().ToString() == sh.get())
                {
                    confirm = true;
                }
                objCommand.ExecuteNonQuery();

            //}
            //catch (Exception ex1)
            //{
            //    Console.WriteLine(ex1.ToString());
            //}
            objConnection.Close();
            return confirm;
        }
    }
}