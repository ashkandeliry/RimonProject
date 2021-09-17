using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SharedMethodsLib.Encryption
{
    public class Encryption
    {
        public static string EncodePasswordMd5(string StringInput)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(StringInput);
            encodedBytes = md5.ComputeHash(originalBytes);
            string encode = null;
            for (int i = 0; i < encodedBytes.Length; i++)
            {
                encode = encode + encode[i].ToString();
            }
            return encode;
        }
    }
}
