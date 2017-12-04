using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017.Day
{
    internal class Day3_SpiralMemory : IDay
    {
        private StreamReader fReader;

        internal Day3_SpiralMemory() { }

        public void SetFile(string path)
        {
            fReader = new StreamReader(path);
        }

        public string FirstTask()
        {
            int inp = ParseNum(fReader.ReadLine());
            int size = ParseSize(inp);
            int result = size / 2;
            int curr = (int)Math.Pow(size, 2);
            while (curr - size + 1 > inp)
            {
                curr -= size + 1;
            }
            if (curr - size / 2 > inp) curr -= size / 2;
            result += curr - inp;
            fReader.BaseStream.Position = 0;
            return result.ToString();
        }

        public string SecondTask()
        {
            int inp = ParseNum(fReader.ReadLine());
            List<int> num = new List<int>() { 1, 2, 4, 5, 10, 11, 23, 25 };
            int i = 0;
            int size = 5;
            while (num[num.Count - 1] < inp)
            {
                if (i == 0 || (i + 1) % (size - 1) == 0)
                {
                    if (i == Math.Pow(size, 2) - Math.Pow(size - 2, 2) - 1)
                    {
                        num.Add(num[0] + num[1] + num[num.Count - 1]);
                        num.RemoveAt(0);
                    }
                    else
                    {
                        num.Add(num[0] + num[num.Count - 1]);
                    }
                } else
                if (i == Math.Pow(size, 2) - Math.Pow(size - 2, 2) - 2 || (i + 2) % (size - 1) == 0)
                {
                    if (i == Math.Pow(size, 2) - Math.Pow(size - 2, 2) - 2)
                    {
                        num.Add(num[0] + num[1] + num[2] + num[num.Count - 1]);
                    }
                    else
                    {
                        num.Add(num[0] + num[1] + num[num.Count - 1]);
                    }
                    num.RemoveAt(0);
                } else
                if (i == 1 || i % (size - 1) == 0)
                {
                    num.Add(num[0] + num[1] + num[num.Count - 1] + num[num.Count - 2]);
                }
                else
                {
                    num.Add(num[0] + num[1] + num[2] + num[num.Count - 1]);
                    num.RemoveAt(0);
                }
                (i, size) = CheckSize(i, size);
            }
            fReader.BaseStream.Position = 0;
            return num[num.Count - 1].ToString();
        }

        private (int i, int size) CheckSize(int i, int size)
        {
            return (i + 1) % (Math.Pow(size, 2) - Math.Pow(size - 2, 2)) == 0 ? (0, size + 2) : (++i, size);
        }

        private int ParseNum(string s)
        {
            return int.Parse(s);
        }

        private int ParseSize(int inp)
        {
            int i = (int)Math.Ceiling(Math.Sqrt(inp));
            if (i % 2 == 1) return i;
            return i + 1;
        }
    }
}