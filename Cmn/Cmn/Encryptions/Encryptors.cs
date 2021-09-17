using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cmn.Encryptions
{
    public class Encryptor
    {
        /// <summary>
        /// رمز گذاری یک آرایه
        /// </summary>
        /// <param name="clearData">اطلاعات خام</param>
        /// <param name="Key">کد رمز</param>
        /// <param name="IV">وکتور آماده سازی</param>
        public byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms,
                alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearData, 0, clearData.Length);
            cs.Close();

            return ms.ToArray();
        }

        /// <summary>
        /// رمز گذاری یک رشته
        /// </summary>
        /// <param name="clearText">اطلاعات خام</param>
        /// <param name="Password">کد رمز</param>
        public string Encrypt(string clearText, string Password)
        {
            try
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

                PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                    new byte[] {(byte)'A', (byte)'-', (byte)'H', (byte)'.', (byte)'M',
                    (byte)'.', (byte)'O', (byte)'j', (byte)'v', (byte)'a', (byte)'r'});
                //Ivan Medvedev
                //{0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 

                byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

                return Convert.ToBase64String(encryptedData);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// رمز گذاری یک آرایه از بایت
        /// </summary>
        /// <param name="clearText">اطلاعات خام</param>
        /// <param name="Password">کد رمز</param>
        public byte[] Encrypt(byte[] clearData, string Password)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {(byte)'A', (byte)'-', (byte)'H', (byte)'.', (byte)'M',
                    (byte)'.', (byte)'O', (byte)'j', (byte)'v', (byte)'a', (byte)'r'});
            //Ivan Medvedev
            //{0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 

            return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        /// <summary>
        /// رمز گذاری یک فایل و ایجاد فایل رمز گذاری شده
        /// </summary>
        /// <param name="fileIn">فایل مبدا</param>
        /// <param name="fileOut">فایل مقصد</param>
        /// <param name="Password">کلمه عبور</param>
        public void Encrypt(string fileIn, string fileOut, string Password)
        {
            FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {(byte)'A', (byte)'-', (byte)'H', (byte)'.', (byte)'M',
                    (byte)'.', (byte)'O', (byte)'j', (byte)'v', (byte)'a', (byte)'r'});
            //Ivan Medvedev
            //{0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 
            Rijndael alg = Rijndael.Create();

            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            CryptoStream cs = new CryptoStream(fsOut, alg.CreateEncryptor(), CryptoStreamMode.Write);

            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;

            do
            {
                // Read a chunk of data from the input file 
                bytesRead = fsIn.Read(buffer, 0, bufferLen);

                // Encrypt it 
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            // Close everything 
            // This will also close the unrelying fsOut stream
            cs.Close();
            fsIn.Close();
        }

        /// <summary>
        /// رمز گشایی یک آرایه
        /// </summary>
        /// <param name="cipherData">اطلاعات رمز شده</param>
        /// <param name="Key">کد رمز</param>
        /// <param name="IV">وکتور آماده سازی</param>
        public byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();

            return ms.ToArray();
        }

        /// <summary>
        /// رمز گشایی یک رشته
        /// </summary>
        /// <param name="cipherText">اطلاعات رمز شده</param>
        /// <param name="Password">کد رمز</param>
        public string Decrypt(string cipherText, string Password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {(byte)'A', (byte)'-', (byte)'H', (byte)'.', (byte)'M',
                    (byte)'.', (byte)'O', (byte)'j', (byte)'v', (byte)'a', (byte)'r'});
            //Ivan Medvedev
            //{0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 
            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return Encoding.Unicode.GetString(decryptedData);
        }

        /// <summary>
        /// رمز گشایی یک آرایه بایت
        /// </summary>
        /// <param name="cipherData">اطلاعات رمز شده</param>
        /// <param name="Password">کد رمز</param>
        public byte[] Decrypt(byte[] cipherData, string Password)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {(byte)'A', (byte)'-', (byte)'H', (byte)'.', (byte)'M',
                    (byte)'.', (byte)'O', (byte)'j', (byte)'v', (byte)'a', (byte)'r'});
            //Ivan Medvedev
            //{0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 
            return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        /// <summary>
        /// رمز گشایی یک فایل و ایجاد فایل رمز گشایی شده
        /// </summary>
        /// <param name="fileIn">فایل مبدا</param>
        /// <param name="fileOut">فایل مقصد</param>
        /// <param name="Password">کلمه عبور</param>
        public void Decrypt(string fileIn, string fileOut, string Password)
        {
            FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {(byte)'A', (byte)'-', (byte)'H', (byte)'.', (byte)'M',
                    (byte)'.', (byte)'O', (byte)'j', (byte)'v', (byte)'a', (byte)'r'});
            //Ivan Medvedev
            //{0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 
            Rijndael alg = Rijndael.Create();

            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            CryptoStream cs = new CryptoStream(fsOut, alg.CreateDecryptor(), CryptoStreamMode.Write);

            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;

            do
            {
                bytesRead = fsIn.Read(buffer, 0, bufferLen);
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            cs.Close();
            fsIn.Close();
        }
    }
}
