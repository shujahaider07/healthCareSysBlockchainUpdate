using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace healthCareSysBlockchain
{
    internal class hash
    {


        public static string Sha512(string text)
        {

            
            SHA512CryptoServiceProvider sHA512 = new SHA512CryptoServiceProvider();
            byte[] encoded = Encoding.ASCII.GetBytes(text);
            byte[] computeHash = sHA512.ComputeHash(encoded);


            return Convert.ToBase64String(computeHash);

        }
    }
}
