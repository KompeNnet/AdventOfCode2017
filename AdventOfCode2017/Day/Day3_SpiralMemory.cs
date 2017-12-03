using System;

namespace AdventOfCode2017.Day
{
    public class Day3_SpiralMemory : IDay
    {
        private int num;
        private int size;

        public Day3_SpiralMemory(string inp = "50" )
        {
            num = int.Parse(inp);
            size = ParceSize();
        }

        public string FirstTask()
        {
            int result = size / 2;
            int curr = (int)Math.Pow(size, 2);
            while (curr - size + 1 > num)
            {
                curr -= size + 1;
            }
            if (curr - size / 2 > num) curr -= size / 2;
            result += curr - num;
            return result.ToString();
        }

        public string SecondTask()
        {
            throw new NotImplementedException();
        }

        private int ParceSize()
        {
            int i = (int)Math.Ceiling(Math.Sqrt(num));
            if (i % 2 == 1) return i;
            return i + 1;
        }
    }
}