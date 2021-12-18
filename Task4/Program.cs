using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!isRightInput(args))
            {
                return;
            }

            var movePc = MoveOfPC(args);

            ShowMenu(args);

            var movePerson = MoveOfPerson(args);

            if (movePerson == 0)
                return;
            

        }

        static int MoveOfPerson(string[] args)
        {
            bool isInput = true;
            int number = 0;
            string input = Console.ReadLine();

            if (input == "?")
                ShowHelp();

            while (isInput)
            {
                if (Int32.TryParse(input, out number))
                {
                    if (0 <= number && number <= args.Length)
                    {
                        isInput = false;
                    }

                    ShowError("A number from the menu is required");
                    input = Console.ReadLine();
                }
            }

            return number;
        }

        static void ShowHelp()
        {
            Console.WriteLine("Enter a number to make a move.");
        }

        static void ShowMenu(string[] args)
        {
            for(int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {args[i]}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        static int MoveOfPC(string[] a)
        {
            var key = GenerateKey.CreateKey(32);
            var move = GenerateKey.CreateKey(4);

            int o = BitConverter.ToInt32(move, 0) / a.Length;

            var hmac = new HMACSHA256(key);

            var hash = hmac.ComputeHash(move);

            GenerateKey.ShowHMAC(hash);

            return o;
        }

        static bool isRightInput(string[] a)
        {
            if (a.Length < 3)
            {
                ShowError("String Length < 3");
                return false;
            }
            if (a.Length % 2 == 0)
            {
                ShowError("String Length is odd");
                return false;
            }
            if (a.Length > 9)
            {
                ShowError("String Length > 9");
                return false;
            }
            if (isRepeatElements(a))
            {
                ShowError("Elements are Repeat");
                return false;
            }
            return true;
        }
         
        static bool isRepeatElements(string[] a)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (string item in a)
                if (!set.Add(item))
                    return true;
            return false;
        }

        static void ShowError(string s)
        {
            Console.WriteLine($"Error: {s}.");
        }

    }
}
