using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017.Day
{
    internal class Day5_AMazeofTwistyTrampolines_AllAlike : IDay
    {
        StreamReader fReader;

        internal Day5_AMazeofTwistyTrampolines_AllAlike() { }

        public string FirstTask()
        {
            int result = 0;
            List<int> instructList = ParseInstruction();
            int i = 0;            
            while (i < instructList.Count && i >= 0)
            {
                i += instructList[i]++;
                result++;
            }
            fReader.BaseStream.Position = 0;
            return result.ToString();
        }

        public string SecondTask()
        {
            throw new NotImplementedException();
        }

        public void SetFile(string path)
        {
            fReader = new StreamReader(path);
        }

        private List<int> ParseInstruction()
        {
            List<int> list = new List<int>();
            string str = fReader.ReadLine();
            while (str != null)
            {
                if (str == "") continue;
                list.Add(int.Parse(str));
                str = fReader.ReadLine();
            }
            return list;
        }
    }
}
