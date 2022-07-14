using System;
using System.Diagnostics;
using CodeFoxxLibrary.AESEncrypt;
using NUnit.Framework;

namespace AESEncryptTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string result = AES.aesEncryptBase64("110045");
            Console.WriteLine("d1, encryptResult = "+result);

            string result2 = AES.aesDecryptBase64(result);
            Console.WriteLine("d1, result2 = "+result2);
        }
    }
}