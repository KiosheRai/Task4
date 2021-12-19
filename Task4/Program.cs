using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Task4
{
    class Program
    {
        private byte[] key;

        static void Main(string[] args)
        {
            if (!isRightInput(args))
            {
                return;
            }

            var gen = new GenerateKey();

            var key = gen.CreateKey(32);

            var move = gen.CreateKey(4);

            var movePc = gen.GetNumber(move, args.Length);

            gen.ShowHMAC(key, move);

            ShowMenu(args);

            var movePerson = MoveOfPerson(args);

            if (movePerson == -1)
                return;

            Winner.ShowWinner(args, movePc, movePerson);

            Console.WriteLine($"HMAC Key: {BitConverter.ToString(key, 0)}");

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
                    else
                    {
                        ShowError("A number from the menu is required");
                        input = Console.ReadLine();
                    }
                }
            }

            return number - 1;
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
