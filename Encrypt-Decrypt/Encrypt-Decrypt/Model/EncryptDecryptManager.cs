

using System.Security.Cryptography;
using System.Text;

namespace Encrypt_Decrypt.Model
{
    public class EncryptDecryptManager
    {
        private readonly static string key = "TestEncryptionAndDecryption";
        public static string Encryption(string text){
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key= pdb.GetBytes(32);
                aes.IV= pdb.GetBytes(16);
                ICryptoTransform ct = aes.CreateEncryptor(aes.Key,aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms,ct,CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs)) { 
                            sw.Write(text);
                        
                        }       
                        array= ms.ToArray();

                    }
                }
                return Convert.ToBase64String(array);
            }
          
        }
        public static string Decryption(string text)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(text);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = pdb.GetBytes(32);
                aes.IV = pdb.GetBytes(16);
                ICryptoTransform cs = aes.CreateDecryptor(aes.Key,aes.IV);
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(ms, cs, CryptoStreamMode.Read))
                    {
                        using(StreamReader sr = new StreamReader(cryptoStream))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
           
            
        }
    }
}
