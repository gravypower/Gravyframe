using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace WebsiteKernel.Logging
{
    public class LoggerInformation
    {
        private static readonly Random Random;
        public string ErrorCode { get; set; }
        public string GroupErrorCode { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
        public string ServerName { get; set; }
        public int RandomNumber { get; set; }
        public string PathAndQuery { get; set; }

        static LoggerInformation()
        {
            Random = new Random();
        }

        public LoggerInformation(string message, string errorGroup)
        {
            ServerName = Environment.MachineName;
            RandomNumber = Random.Next();
            PathAndQuery = System.Web.HttpContext.Current.Request.Url.PathAndQuery;
            GroupErrorCode = EncryptString(String.Format("{0}-{1}-{2}-{3}", ServerName, PathAndQuery, RandomNumber, errorGroup));
            ErrorCode = EncryptString(String.Format("{0}-{1}-{2}", ServerName, PathAndQuery, RandomNumber));
            Message = message;
            StackTrace = Environment.StackTrace;
        }

        public static string EncryptString(string clearText)
        {
            byte[] clearTextBytes = Encoding.UTF8.GetBytes(clearText);

            SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();

            var ms = new MemoryStream();
            var rgbIV = Encoding.ASCII.GetBytes("ryojvlzmdalyglrj");
            var key = Encoding.ASCII.GetBytes("hcxilkqbbhczfeultgbskdmaunivmfuo");
            var cs = new CryptoStream(ms, rijn.CreateEncryptor(key, rgbIV), CryptoStreamMode.Write);

            cs.Write(clearTextBytes, 0, clearTextBytes.Length);

            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string DecryptString(string encryptedText)
        {
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);

            var ms = new MemoryStream();

            var rijn = SymmetricAlgorithm.Create();


            byte[] rgbIV = Encoding.ASCII.GetBytes("ryojvlzmdalyglrj");
            byte[] key = Encoding.ASCII.GetBytes("hcxilkqbbhczfeultgbskdmaunivmfuo");

            var cs = new CryptoStream(ms, rijn.CreateDecryptor(key, rgbIV), CryptoStreamMode.Write);

            cs.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);

            cs.Close();

            return Encoding.UTF8.GetString(ms.ToArray());

        }
    }
}
