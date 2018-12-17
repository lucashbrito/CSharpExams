using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Chapter3
{
    public class EncrypterClass
    {
        public static void EncryptSomeText()
        {
            var original = "Passowrd23!@";

            using (SymmetricAlgorithm algorithm = new AesManaged())
            {
                byte[] encrypted = Encrypt(algorithm, original);
                string roundtrip = Decrypt(algorithm, encrypted);

                Console.WriteLine($"{encrypted}");
                Console.WriteLine($"{roundtrip}");
            }
        }

        public static byte[] Encrypt(SymmetricAlgorithm aesAlg, string password)
        {
            ICryptoTransform enCryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream memory = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memory, enCryptoTransform, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(password);
                    }
                    return memory.ToArray();
                }
            }
        }

        public static string Decrypt(SymmetricAlgorithm aesAlg, byte[] encryptedPassword)
        {
            ICryptoTransform decryCryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream memoryStream = new MemoryStream(encryptedPassword))
            {
                using (CryptoStream cryptoStreamDescrypt = new CryptoStream(memoryStream, decryCryptoTransform, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReaderDecrypt = new StreamReader(cryptoStreamDescrypt))
                    {
                        return streamReaderDecrypt.ReadToEnd();
                    }
                }
            }
        }

        public void ExportingAPublicKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKeyXML = rsa.ToXmlString(false);
            string privateKeyXML = rsa.ToXmlString(true);
            Console.WriteLine(publicKeyXML);
            Console.WriteLine(privateKeyXML);
        }

        public void UsingPublicAndPrivateKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKeyXML = rsa.ToXmlString(false);
            string privateKeyXML = rsa.ToXmlString(true);

            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] dataToEncrypt = Encoding.ASCII.GetBytes("My secrete data is 123Lucas@1");
            byte[] encrytedData;

            using (RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProvider.FromXmlString(publicKeyXML);
                encrytedData = rsaCryptoServiceProvider.Encrypt(dataToEncrypt, false);
            }

            byte[] decryptedData;
            using (RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProvider.FromXmlString(privateKeyXML);
                decryptedData = rsaCryptoServiceProvider.Decrypt(encrytedData, false);
            }

            string decryptedString = Convert.ToString(decryptedData);
            Console.WriteLine(decryptedString); // Displays: My Secret Data!

        }

        public void UsingKeyContainer()
        {
            string containerName = "SecretContainer";
            byte[] dataToEncrypt = Encoding.ASCII.GetBytes("My secrete data is 123Lucas@1");

            CspParameters csp = new CspParameters() { KeyContainerName = containerName };
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp))
            {
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }
        }

    }
}
