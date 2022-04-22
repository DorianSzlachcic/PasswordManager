﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using PasswordManager.BusinessLogic.Models;

namespace PasswordManager.BusinessLogic.Services.File
{
    internal class JsonService
    {
        private string path;

        public JsonService(string filePath)
        {
            path = filePath;
        }

        public void WriteToFile(Account account)
        {
            List<Account> list = LoadFromFile();
            list.Add(account);
            System.IO.File.WriteAllText(path, JsonSerializer.Serialize(list));
        }

        public List<Account> LoadFromFile()
        {
            if(System.IO.File.Exists(path))
            {
                if(System.IO.File.ReadAllText(path) != "" && System.IO.File.ReadAllText(path) != null)
                    using (JsonDocument document = JsonDocument.Parse(System.IO.File.ReadAllText(path)))
                    {
                        List<Account> accountList = new List<Account>();
                        foreach(JsonElement account in document.RootElement.EnumerateArray())
                        {
                            accountList.Add(new Account(account.GetProperty("Name").ToString(), account.GetProperty("Login").ToString(),
                                account.GetProperty("Password").ToString()));
                        }
                        return accountList;
                    }
            }

            return new List<Account>();
        }
    }
}
