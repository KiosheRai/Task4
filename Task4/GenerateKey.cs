using System;
using System.Security.Cryptography;
using System.Text;


namespace Task4
{
    static class GenerateKey
    {
        public static byte[] CreateKey(int keyBytes)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            byte[] key = new byte[keyBytes];
            rng.GetBytes(key);
            return key;
        }

        public static void ShowHMAC(byte[] a)
        {
            Console.WriteLine("PC HMAC:" + BitConverter.ToString(a, 0));
        }
    }
}
