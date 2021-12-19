using ConsoleTables;
using System;
using System.Text;

namespace Task4
{
    static class Table
    {
        public static void ShowTable(string[] args)
        {

            var table = new ConsoleTable(GetRightTitle(args));

            for(int i = 0; i < args.Length; i++)
            {
                string[] status = new string[args.Length + 1];
                status[0] = args[i];
                for (int j = 0; j < args.Length; j++)
                {
                    status[j + 1] = Winner.GetStatus(args, i, j);
                }
                table.AddRow(status);
            }

            table.Write(Format.MarkDown);
        } 

        static string[] GetRightTitle(string[] args)
        {
            string[] a = new string[args.Length + 1];

            a[0] = " ";
            for(int i = 1, j = 0; i < args.Length + 1; i++, j++)
            {
                a[i] = args[j];
            }

            return a;
        }
    }
}
