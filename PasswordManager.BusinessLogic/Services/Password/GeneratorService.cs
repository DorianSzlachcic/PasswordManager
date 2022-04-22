using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.Services.Password
{
    internal class GeneratorService
    {
        private static bool upperCase = true, lowerCase = true, specialChars = true, numbers = true;
        private static int lenght = 10;

        public string Generate()
        {
            string charSet = getCharSet();

            Random random = new Random();
            string pass = "";

            while (pass.Length < lenght)
            {
                int i = random.Next(0, charSet.Length);
                pass += charSet[i];
            }

            return pass;
        }

        private string getCharSet()
        {
            string charSet = "";

            if (upperCase)
                charSet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (lowerCase)
                charSet += "abcdefghijklmnopqrstuvwxyz";
            if (specialChars)
                charSet += "!#$%&()*+,-./:;<=>?@[]^_";
            if (numbers)
                charSet += "1234567890";

            return charSet;
        }

    }
}
