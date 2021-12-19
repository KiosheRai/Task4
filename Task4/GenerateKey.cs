using System;
using System.Security.Cryptography;


namespace Task4
{
     class GenerateKey
    {
        byte[] key;

        public byte[] CreateKey(int keyBytes)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            key = new byte[keyBytes];
            rng.GetBytes(key);
            return key;
        }

        public void ShowHMAC(byte[] a, byte[] move)
        {
            var hmac = new HMACSHA256(a);

            var hash = hmac.ComputeHash(move);

            Console.WriteLine("PC HMAC:" + BitConverter.ToString(hash, 0));
        }

        public int GetNumber(byte[] number, int l)
        {
            return Math.Abs(BitConverter.ToInt32(number, 0) % l);
        }
    }
}
