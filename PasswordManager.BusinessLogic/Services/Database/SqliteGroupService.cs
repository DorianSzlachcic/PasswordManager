using Microsoft.Data.Sqlite;
using PasswordManager.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.Services.Database
{
    internal class SqliteGroupService : ISqliteGroupService
    {
        string databasePath = "db.sqlite3";

        public SqliteGroupService()
        {
            CreateIfNotExists();
        }

        public void CreateIfNotExists()
        {
            using (var connection = new SqliteConnection("DataSource=" + databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS group (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, color TEXT NOT NULL);";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void AddGroup(Group group)
        {
            using (var connection = new SqliteConnection("DataSource=" + databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO group(name, color) VALUES('{group.Name}','{ColorTranslator.ToHtml(group.ColorHex)}');";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void UpdateGroup(Group group)
        {
            using (var connection = new SqliteConnection("DataSource=" + databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"UPDATE accounts SET name='{group.Name}', color='{ColorTranslator.ToHtml(group.ColorHex)}' WHERE id={group.Id};";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<Group> LoadGroups()
        {
            List<Group> groups = new List<Group>();

            using (var connection = new SqliteConnection("DataSource=" + databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM groups ORDER BY name;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        groups.Add(new Group(reader.GetString(0), ColorTranslator.FromHtml(reader.GetString(1))));
                    }
                }
            }

            return groups;
        }

        public void DeleteGroup(int id)
        {
            using (var connection = new SqliteConnection("DataSource=" + databasePath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM group WHERE id={id};";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
