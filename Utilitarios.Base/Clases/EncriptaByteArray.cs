﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Base
{
    public static class EncriptaByteArray
    {
        /// <summary>
        /// Método que encripta utilizando AES Symmetric key
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] input)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = input;

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// Método que desencripta utilizando AES Symmetric key
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] input)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = input;

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }

                    return ms.ToArray();
                }
            }
        }

    }
}
