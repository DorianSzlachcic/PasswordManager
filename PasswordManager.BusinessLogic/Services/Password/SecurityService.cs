using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PasswordManager.BusinessLogic.Services.Password
{
    internal class SecurityService
    {
        private string key = "A!9HHhi%XjjYY4YP2@Nob009X";
        public string EncryptAES(string text)
        {
            if (text == null || text.Length <= 0)
                return "";

            using (MD5 md5 = MD5.Create())
            {
                using(Aes aes = Aes.Create())
                {
                    aes.Key = md5.ComputeHash(new UTF8Encoding().GetBytes(key));
                    aes.IV = md5.ComputeHash(new UTF8Encoding().GetBytes(key));
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.Zeros;

                    using (var aesEncryptor = aes.CreateEncryptor())
                    {
                        byte[] bytes = new UTF8Encoding().GetBytes(text);
                        byte[] encrypted = aesEncryptor.TransformFinalBlock(bytes, 0, bytes.Length);

                        return Convert.ToBase64String(encrypted);
                    }
                }
            }
        }

        public string DecryptAES(string encrypted)
        {
            if(encrypted == null || encrypted.Length <= 0)
                return "";

            using (MD5 md5 = MD5.Create())
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = md5.ComputeHash(new UTF8Encoding().GetBytes(key));
                    aes.IV = md5.ComputeHash(new UTF8Encoding().GetBytes(key));
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.Zeros;

                    using (var aesDecryptor = aes.CreateDecryptor())
                    {
                        byte[] bytes = Convert.FromBase64String(encrypted);
                        byte[] decrypted = aesDecryptor.TransformFinalBlock(bytes, 0, bytes.Length);

                        return new UTF8Encoding().GetString(decrypted);
                    }
                }
            }
        }
    }
}
