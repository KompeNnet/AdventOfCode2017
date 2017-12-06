using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day
{
    internal class Day6_MemoryReallocation : IDay
    {
        private delegate int CountDelegate(List<string> list);
        private StreamReader fReader;

        public string FirstTask()
        {
            return GetCycleCount(CycleNumber);
        }

        public string SecondTask()
        {
            return GetCycleCount(CountBetweenCycle);
        }

        public void SetFile(string path)
        {
            fReader = new StreamReader(path);
        }

        private string GetCycleCount(CountDelegate func)
        {
            string inp = fReader.ReadLine();
            int[] block = ParseMas(inp);
            List<string> stepList = new List<string>
            {
                string.Join(" ", block)
            };
            while (stepList.Where(x => x.Equals(stepList[stepList.Count - 1])).ToList().Count < 2)
            {
                int num = block.Max();
                int i = Array.IndexOf(block, num);
                block[i] = 0;
                while (num > 0)
                {
                    i = i < block.Length - 1 ? ++i : 0;
                    block[i]++;
                    num--;
                }
                stepList.Add(string.Join(" ", block));
            }
            fReader.BaseStream.Position = 0;
            return func(stepList).ToString();
        }

        private int CycleNumber(List<string> list)
        {
            return list.Count - 1;
        }

        private int CountBetweenCycle(List<string> list)
        {
            return list.Count - 1 - list.IndexOf(list[list.Count - 1]);
        }

        private int[] ParseMas(string inp)
        {
            string[] str = inp.Split("\t");
            int[] num = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                num[i] = int.Parse(str[i].ToString());
            }
            return num;
        }
    }
}
