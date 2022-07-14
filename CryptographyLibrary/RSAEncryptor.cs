using System;
using System.Security.Cryptography;
using System.Text;

namespace AESEncrypt
{
    public class RSAEncryptor
    {

        private static string sPublicKey =
            @"<RSAKeyValue><Modulus>z0jfodvy94YE4MTNH64jc3LabkupvPkRN2jXjtM40OjZfTyZ5PEjOc/KgocuyUJke2tjApbE1JsaAGvtAc2Rl1bsGRGmuJTMAszbhV6oiekphUYN5i79uiqcseYZYArpjUD+po/Vth2SVmfJWY5bx7s5b7od8P+DM79JWjtY+lk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";


        public static string Log(string logMessage)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(sPublicKey);

            string encryptString = Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(logMessage), false));

            return encryptString;
        }

    }

}