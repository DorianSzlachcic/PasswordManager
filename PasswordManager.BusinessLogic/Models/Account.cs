using PasswordManager.BusinessLogic.Services.Password;

namespace PasswordManager.BusinessLogic.Models
{
    public class Account
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Group? Group { get; set; }

        public Account(string name, string login, string encryptedPassword, Group? group = null, int? id = null)
        {
            ID = id;
            Name = name;
            Login = login;
            Password = encryptedPassword;
            Group = group;
        }
    }
}
