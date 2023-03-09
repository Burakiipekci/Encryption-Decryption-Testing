using Encrypt_Decrypt.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Encrypt_Decrypt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptDecryptController : ControllerBase
    {
        [HttpGet("Encryption")]
        public string Encrypt(string text)
        {
            var encryptString = EncryptDecryptManager.Encryption(text);
            return encryptString;
        }
        [HttpGet("Decryption")]
        public string Decrypt(string text)
        {
            var decryptString = EncryptDecryptManager.Decryption(text);
            return decryptString;
        }
    }
}
