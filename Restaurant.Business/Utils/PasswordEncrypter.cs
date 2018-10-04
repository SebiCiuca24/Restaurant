using System.Security.Cryptography;
using System.Text;

namespace Restaurant.Business.Utils
{
    public class PasswordEncrypter : IPasswordEncrypter
    {
        public string EncryptPassword(string password)
        {
            var encoding = Encoding.UTF8;
            var keyByte = encoding.GetBytes(Constants.EncryptKey);

            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                hmacsha256.ComputeHash(encoding.GetBytes(password));

                return ByteToString(hmacsha256.Hash);
            };
        }

        private string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2");
            }

            return sbinary;
        }
    }
}
