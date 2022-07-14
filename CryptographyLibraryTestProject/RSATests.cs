using System;
using CodeFoxxLibrary.CryptographyLibrary;
using NUnit.Framework;

namespace AESEncryptTestProject
{
    public class RSATests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_RSA_EncryptAndDecrypt()
        {
            var rsa = new RSA();
            rsa.GenerateRSAKeys();
            Console.WriteLine($" public key = {rsa.GetPublicKey()}\n");
            Console.WriteLine($" private key = {rsa.GetPrivateKey()}\n");

            string stringWantToEncrypt = "test content for rsa";
            
            string encryptResult = rsa.Encrypt(rsa.GetPublicKey(),stringWantToEncrypt );
            Console.WriteLine($" encryptResult = {encryptResult}\n" );

            string decryptResult = rsa.Decrypt(rsa.GetPrivateKey(), encryptResult);
            Console.WriteLine($" decryptResult = {decryptResult}\n");
        }

        [Test]
        public void TestDecrypt()
        {
            string encryptedResult =
                // @"fVqiWkTCHAnsNdJAI0+ZeI/hx6ehRDUpHTzlZLhUN2N6X2d05T8PfWSFlGWln6UlOByk43YHqadihykcG+5ot5zm6K1iHj1oeIqiiTyPxXqA4Zr7moAYqmQIzlS1PdoQ6zQUk5FYnZCgno63n0nKG6YujlWFkf1VEdvBXoHBwYU=";
                // @"NVUzVZD0lcHNrBTXfS5dXHczI3CLz0SirujbG0bxFlNZugtZx2nM4/f1gYN3JotztAJZ9emnqmvnt+98mpzjKlQnNyyRDg31arizU3cr0ENLamTmh40dZpfBTiMGTvFpYvXKT6QG9zPYHagTHCkcJUS0WRdiIuODGi1ch75+1mw=";
                @"DtGQGU1yviNGpT6/oLnaSXvfTyfEXX2q1O6MqP29LoO0cUT5OqgwDMYwKYkus8K7qUZtWNaHB0+T+mY8eysfuyd4K9sWlY0vezf6nDEQyEzOZtQPbsGjUsmt715E9MMsPaVHwDJ8T0awQ/WiCsKIiIpEo4Q9Umply/jOnZpIWPM=";
            
            string privateKey =
                @"<RSAKeyValue><Modulus>z0jfodvy94YE4MTNH64jc3LabkupvPkRN2jXjtM40OjZfTyZ5PEjOc/KgocuyUJke2tjApbE1JsaAGvtAc2Rl1bsGRGmuJTMAszbhV6oiekphUYN5i79uiqcseYZYArpjUD+po/Vth2SVmfJWY5bx7s5b7od8P+DM79JWjtY+lk=</Modulus><Exponent>AQAB</Exponent><P>2l4alVFmOtUqdm8P9tzn5UMQ6pTB8m9+NMRJ1kGYMH+o2Kl1P5lmFIm5cygaD7dny5J3p05lBHRgpc9pbAz6ew==</P><Q>8wHQtl59P6FBV1w899Ar07PK6YWoxTqEwlYP3mlMsL9fA0x9WrUfai8x/nse0pFxjxCPd0NqEQHlYpMyzM3AOw==</Q><DP>fxaRpiGPu+HgKrmMswHyPK4BpGUbU3usGg27Y2Udq+xAWoiVYoRmssFNG0ZVlJwLXqFJ3id0B1mr/hRuqKINDQ==</DP><DQ>dH/rSnL0QtwREkuzIu8XA9BPODMO3TcXzH8r7mm3DYlBiLhT5Heuzt4/bowiE7sMoRTEYt3b7Llm+iItmYgOXw==</DQ><InverseQ>PU9FEebrlg7JTYpcmGyhMzARzH4r3+QPAWvizpb3GqCKO9fVbEUaRMZAu+bM8KrljW0glZLKNM7sTybkRWexDQ==</InverseQ><D>UoAKof1Mwr+QiXVKvuUsLvLzhRqQQCpRc+BCixH+dwd2KKZKChj/kC7nxvPO50OJgqXHDmy7gnMI8koCVslevEm2hTFZgI+uqR5zckL/rpaYU2CLLATeSPgzVK637kUzHUyNHjMGz48psayumCpkjoPa2V+vcoAZDTPSuqV7YhE=</D></RSAKeyValue>";
            
            var rsa = new RSA();
            string decryptedResult = rsa.Decrypt(privateKey, encryptedResult);
            Console.WriteLine($"result = {decryptedResult}");
        }
    }
}