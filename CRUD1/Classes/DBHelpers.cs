using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Controls;

namespace CRUD1
{
    public static class DBConnector
    {
        private static string connString = @"Server=.\SOFT_SERVER;Database=Sample;Trusted_Connection=True;Initial Catalog=Sample";
        public static SqlConnection conn = new SqlConnection(connString);

        public static string Connect()
        {
            conn.Open();
            return conn.State.ToString();
        }

        public static void Disconnect()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
    }

    public class DBExecuter
    {
        #region FIELDS
        private string _use_tb = "dbo.Accounts";
        public AccountsList Accounts { get; set; }
        public Label LogSource { get; internal set; }
        #endregion

        #region CONSTRUCTORS
        public DBExecuter()
        {
            DBConnector.Connect();
        }
        #endregion

        #region BEHAVIOURS
        public bool CheckConnection()
        {
            if (DBConnector.conn.State == System.Data.ConnectionState.Open)
            {
                LogSource.Content = "Connected";
                return true;
            }
            else
            {
                LogSource.Content = "Not Connected";
                return false;
            }
        }

        public void Log(string logtxt) => LogSource.Content = logtxt;

        public void Create(Account account)
        {
            string create = string.Format("INSERT INTO {0} VALUES ({1}, '{2}', '{3}', {4}, '{5}');"
                , _use_tb, account.Id, account.FirstName, account.LastName, account.Age, account.Gender.ToString().ToUpper());
            SqlCommand command = new SqlCommand();
            command.CommandText = create;
            command.Connection = DBConnector.conn;
            command.ExecuteNonQuery();
            Read(); 
        }

        public void Read()
        {
            string read = string.Format("SELECT * FROM {0}", _use_tb);
            SqlCommand command = new SqlCommand();
            command.CommandText = read;
            command.Connection = DBConnector.conn;
            SqlDataReader reader = command.ExecuteReader();
            List<Account> accounts = new List<Account>();
            while (reader.Read())
            {
                accounts.Add(new Account(
                    int.Parse(reader.GetValue(0).ToString()),
                    reader.GetValue(1).ToString(),
                    reader.GetValue(2).ToString(),
                    int.Parse(reader.GetValue(3).ToString()),
                    bool.Parse(reader.GetValue(4).ToString().ToLower())));
            }
            reader.Close();
            Accounts.List = accounts;
        }

        public void Update(Account account)
        {
            string update = string.Format("UPDATE {0} SET {1} WHERE Id={2}", _use_tb, account.ToString(), account.Id);
            SqlCommand command = new SqlCommand();
            command.CommandText = update;
            command.Connection = DBConnector.conn;
            command.ExecuteNonQuery();
            Log($"Updated account with id {account.Id}");
            Read();
        }

        public void Delete(int id)
        {
            string delete = string.Format("DELETE FROM {0} WHERE {1}.Id = {2}", _use_tb, _use_tb, id);
            SqlCommand command = new SqlCommand();
            command.CommandText = delete;
            command.Connection = DBConnector.conn;
            command.ExecuteNonQuery();
            Log($"Deleted account with id {id}");
            Read();
        }
        #endregion
    }
}