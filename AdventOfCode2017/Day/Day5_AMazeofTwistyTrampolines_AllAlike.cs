using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017.Day
{
    internal class Day5_AMazeofTwistyTrampolines_AllAlike : IDay
    {
        delegate (int, int) CountDelegate(int i, int fromList);
        StreamReader fReader;

        internal Day5_AMazeofTwistyTrampolines_AllAlike() { }

        public string FirstTask()
        {
            return GetCount(ByOnlyGrowing);
        }

        public string SecondTask()
        {
            return GetCount(By3InMiddle);
        }

        public void SetFile(string path)
        {
            fReader = new StreamReader(path);
        }

        private string GetCount(CountDelegate func)
        {
            int result = 0;
            List<int> instructList = ParseInstruction();
            int i = 0;
            while (i < instructList.Count && i >= 0)
            {
                int temp = i;
                (i, instructList[temp]) = func(i, instructList[i]);
                result++;
            }
            fReader.BaseStream.Position = 0;
            return result.ToString();
        }

        private (int, int) ByOnlyGrowing(int i, int fromList)
        {
            return (i + fromList, ++fromList);
        }

        private (int, int) By3InMiddle(int i, int fromList)
        {
            return (i + fromList, fromList < 3 ? ++fromList : --fromList);
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
