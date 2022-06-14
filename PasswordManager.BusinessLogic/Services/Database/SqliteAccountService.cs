using PasswordManager.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace PasswordManager.BusinessLogic.Services.Database
{
    internal class SqliteAccountService : ISqliteAccountService
    {
        string databasePath = "db.sqlite3";

        public SqliteAccountService()
        {
            CreateIfNotExists();
        }

        public void CreateIfNotExists()
        {
            using (var connection = new SqliteConnection("DataSource=" + databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS accounts (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, login TEXT NOT NULL, password TEXT NOT NULL, groupid INT, FOREIGN KEY(groupid) REFERENCES group(id));";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void SaveAccount(Account account)
        {
            using(var connection = new SqliteConnection("DataSource="+databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO accounts(name, login, password) VALUES('{account.Name}','{account.Login}','{account.Password}');";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void UpdateAccount(Account account)
        {
            using (var connection = new SqliteConnection("DataSource=" + databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"UPDATE accounts SET name='{account.Name}', login='{account.Login}', password='{account.Password}' WHERE id={account.ID};";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public Account? GetAccountByID(int id)
        {
            Account? account = null;

            using (var connection = new SqliteConnection("DataSource=" + databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = $"SELECT * FROM accounts WHERE id={id};";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        account = new Account(reader.GetString(1), reader.GetString(2), reader.GetString(3), id: reader.GetInt32(0));
                    }
                }
            }

            return account;
        }

        public List<Account> LoadAccounts()
        {   
            List<Account> accounts = new List<Account>();

            using (var connection = new SqliteConnection("DataSource=" + databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM accounts ORDER BY name;";

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accounts.Add(new Account(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(0)));
                    }
                }
            }

            return accounts;
        }

        public void DeleteAccount(int id)
        {
            using (var connection = new SqliteConnection("DataSource=" + databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = $"DELETE FROM accounts WHERE id={id};";
                command.ExecuteNonQuery();
                
            }
        }
    }
}
