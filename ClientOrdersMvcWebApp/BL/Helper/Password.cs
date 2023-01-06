using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClientOrdersMvcWebApp.BL.Helper
{
    public class Password
    {
        public static byte[] hashPassword(string password)
        {
            var sha = SHA256.Create();
            //convert password into byte[]
            var asByteArr = Encoding.Default.GetBytes(password);
            
            var hashedPassword = sha.ComputeHash(asByteArr);
            return hashedPassword;
        }
    }
}
