using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;

namespace CodeFoxxLibrary.CryptographyLibrary
{
    /// <summary>
    /// RSA 非對稱式加解密，加密使用公鑰(需保管，可任意給)，解密使用私鑰(需保管，不可給)
    /// 同一個公鑰(mPublicKey)必須對應同一個私鑰(mPrivateKey)
    /// </summary>
    public class RSA
    {
        private string mPublicKey = String.Empty; 
        private string mPrivateKey = String.Empty; 

        public void GenerateRSAKeys()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            mPublicKey = rsa.ToXmlString(false);
            mPrivateKey = rsa.ToXmlString(true);
        } 
        
        public string Encrypt(string publicKey, string content)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);

            var encryptString = Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(content), false));

            return encryptString;
        }
        
        public string Decrypt(string privateKey, string encryptedContent)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);

            var decryptString = Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(encryptedContent), false));

            return decryptString;
        }

        public string GetPublicKey()
        {
            return mPublicKey;
        }

        public string GetPrivateKey()
        {
            return mPrivateKey;
        }
    }
}