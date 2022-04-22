using PasswordManager.BusinessLogic.Services.Password;

namespace PasswordManager.BusinessLogic.Models
{
    public class Account
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Account(string name, string login, string encryptedPassword)
        {
            Name = name;
            Login = login;
            Password = encryptedPassword;
        }
    }
}
