using PasswordManager.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.Services.Database
{
    public interface ISqliteAccountService
    {
        public void CreateIfNotExists();
        public void SaveAccount(Account account);
        public void UpdateAccount(Account account);
        public Account? GetAccountByID(int id);
        public List<Account> LoadAccounts();
        public void DeleteAccount(int id);
    }
}
