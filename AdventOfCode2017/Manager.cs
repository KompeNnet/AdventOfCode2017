using System.Collections.Generic;
using AdventOfCode2017.Day;

namespace AdventOfCode2017
{
    static class Manager
    {
        private static List<IDay> dayList = new List<IDay>();
        public static int Count
        {
            get
            {
                return dayList.Count;
            }
        }

        static Manager()
        {
            dayList.Add(new Day1_InverseCaptcha());
            dayList.Add(new Day2_CorruptionChecksum());
            dayList.Add(new Day3_SpiralMemory());
            dayList.Add(new Day4_HighEntropyPassphrases());
        }

        public static IDay GetDay(int i)
        {
            return dayList[i];
        }
    }
}
