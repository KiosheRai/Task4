using ConsoleTables;
using System;
using System.Text;

namespace Task4
{
    static class Table
    {
        public static void ShowTable(string[] args)
        {
            var table = new ConsoleTable(args);
            for(int i = 0; i < args.Length; i++)
            {
                string[] status = new string[args.Length];
                for (int j = 0; j < args.Length; j++)
                {
                    status[j] = Winner.GetStatus(args, i, j);
                }
                table.AddRow(status);
            }
            
            Console.WriteLine(table);
        } 

        //static string[,] MakeTable(string[] args)
        //{
        //    int len = args.Length;
        //    string[,] table = new string[len, len];

        //    for (int i = 0; i < len; i++)
        //    {
        //        for (int j = 0; j < len; j++)
        //        {
        //            if (i == 0 && j != 0)
        //            {
        //                table[i, j] = args[j-1];
        //            }
        //            if (j == 0 && i != 0)
        //            {
        //                table[i, j] = args[i-1];
        //            }
        //        }
        //    }

        //    return table;
        //}
    }
}
