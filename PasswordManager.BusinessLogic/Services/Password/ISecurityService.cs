using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.Services.Password
{
    public interface ISecurityService
    {
        public string EncryptAES(string text);
        public string DecryptAES(string encrypted);
    }
}
