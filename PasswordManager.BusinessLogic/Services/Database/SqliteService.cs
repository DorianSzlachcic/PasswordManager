using PasswordManager.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace PasswordManager.BusinessLogic.Services.Database
{
    internal class SqliteService : ISqliteService
    {
        string databasePath = "db.sqlite3";
        public void SaveAccount(Account account)
        {
            using(var connection = new SqliteConnection("DataSource="+databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS accounts (id INT PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, login TEXT NOT NULL, password TEXT NOT NULL);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO accounts(name, login, password) VALUES('" + account.Name + "','" + account.Login + "','" + account.Password + "');";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Account> LoadAccounts()
        {   
            List<Account> accounts = new List<Account>();

            using (var connection = new SqliteConnection("DataSource=" + databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS accounts (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, login TEXT NOT NULL, password TEXT NOT NULL);";
                command.ExecuteNonQuery();

                command.CommandText = "SELECT name, login, password FROM accounts;";

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accounts.Add(new Account(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
                    }
                }
            }

            return accounts;
        }
    }
}
