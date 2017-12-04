using System;
using AdventOfCode2017.Day;
using System.IO;

namespace AdventOfCode2017
{
    class Program
    {
        static void Main(string[] args)
        {
            IDay day;

            //for (int i = 0; i < Manager.Count; i++)
            //{
            //    day = Manager.GetDay(i);
            //    day.SetInp(File.ReadAllText(".\\input\\" + (i + 1) + ".txt"));

            //    Console.WriteLine("Day {0}:", i + 1);
            //    Console.WriteLine("\t{0}", day.FirstTask());
            //    Console.WriteLine("\t{0}\n", day.SecondTask());
            //}

            int i = 3;
            day = Manager.GetDay(i);
            day.SetInp(".\\input\\" + (i + 1) + ".txt");
            Console.WriteLine("Day {0}:", i + 1);
            Console.WriteLine("\t{0}", day.FirstTask());
            //Console.WriteLine("\t{0}\n", day.SecondTask());

            Console.ReadLine();
        }
    }
}