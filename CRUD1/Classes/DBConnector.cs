using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

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
        private AccountsList _accounts;
        #endregion

        #region CONSTRUCTORS
        public DBExecuter(AccountsList accounts)
        {
            _accounts = accounts;
        }
        #endregion

        #region BEHAVIOURS
        public void Create(IAccount account)
        {
            string _create = string.Format("INSERT INTO {0} VALUES ({1}, '{2}', '{3}', {4}, '{5}');"
                , _use_tb, account.Id, account.FirstName, account.LastName, account.Age, account.Gender.ToString().ToUpper());
            SqlCommand command = new SqlCommand();
            command.CommandText = _create;
            command.Connection = DBConnector.conn;
            command.ExecuteNonQuery();
            _accounts.List = Read();
        }
        public List<Account> Read()
        {
            string _read = string.Format("SELECT * FROM {0}", _use_tb);
            SqlCommand command = new SqlCommand();
            command.CommandText = _read;
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
            return accounts;
        }

        public List<IAccount> Update()
        {
            return null;
        }

        public bool Delete(int id)
        {
            return true;
        }

        #endregion
    }
}
