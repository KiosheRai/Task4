using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
     static class Winner
    {
        public static void ShowWinner(string[] args, int movePc, int movePerson)
        {
            if (isDraw(movePc, movePerson))
            {
                Console.WriteLine("Is Draw.");
            }
            else if (isPersonWin(args, movePc, movePerson))
            {
                Console.WriteLine("Person is Win.");
            }
            else
            {
                Console.WriteLine("PC is Win.");
            }

            ShowMoves(args, movePc, movePerson);
        }

        public static void ShowMoves(string[] args, int movePc, int movePerson)
        {
            Console.WriteLine($"Person move: {args[movePerson]}");
            Console.WriteLine($"PC move: {args[movePc]}");
        }

        static bool isDraw(int movePc, int movePerson)
        {
            if (movePc == movePerson)
                return true;
            return false;
        }

        static bool isPersonWin(string[] args, int movePc, int movePerson)
        {
            for (int i = movePerson, j = 0; j < args.Length / 2; i++, j++)
            {
                if (i == args.Length - 1)
                    i = 0;

                if (j <= args.Length / 2 && i == movePc)
                    return true;
            }
            return false;
        }
    }
}
