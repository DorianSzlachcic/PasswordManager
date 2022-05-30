﻿using PasswordManager.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.Services.Database
{
    public interface ISqliteService
    {
        public void SaveAccount(Account account);
        public List<Account> LoadAccounts();
    }
}