using PasswordManager.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.Services.File
{
    public interface IJsonService
    {
        public void WriteToFile(Account account, string path);
        public List<Account> LoadFromFile(string path);
    }
}
