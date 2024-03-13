using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Utilis
{
    public class AppEncryption
    {
        public static string GenerateSalt()
        {
            var bytes = RandomNumberGenerator.GetBytes(36);
            return Convert.ToBase64String(bytes);
        }


        public static string GenerateHashedPassword(string salt, string password)
        {
            var mixedPassword = string.Concat(salt, password);
            var bytes = Encoding.UTF8.GetBytes(mixedPassword);
            var baseString = Convert.ToBase64String(bytes);
            var baseBytes = Encoding.UTF8.GetBytes(baseString);
            var shah = SHA256.Create();
            return Convert.ToBase64String(shah.ComputeHash(baseBytes));
        }

        public static bool ComparePassword(string dbPassword,string salt,string password)
        {
            return dbPassword == GenerateHashedPassword(salt, password);
        }
    }
}
