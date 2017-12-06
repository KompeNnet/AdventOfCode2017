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

            for (int i = 0; i < Manager.Count; i++)
            {
                day = Manager.GetDay(i);
                day.SetFile(".\\input\\" + (i + 1) + ".txt");

                Console.WriteLine("Day {0}:", i + 1);
                Console.WriteLine("\t{0}", day.FirstTask());
                Console.WriteLine("\t{0}\n", day.SecondTask());
            }

            //int i = 5;
            //day = Manager.GetDay(i);
            //day.SetFile(".\\input\\" + (i + 1) + ".txt");
            //Console.WriteLine("Day {0}:", i + 1);
            //Console.WriteLine("\t{0}", day.FirstTask());
            //Console.WriteLine("\t{0}\n", day.SecondTask());

            Console.ReadLine();
        }
    }
}