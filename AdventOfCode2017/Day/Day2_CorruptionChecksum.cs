using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Day
{
    internal class Day2_CorruptionChecksum : IDay
    {
        private delegate int CheckSumDelegate(int[] num);
        private StreamReader fReader;

        internal Day2_CorruptionChecksum() { }

        public string FirstTask()
        {
            return GetCheckSum(CheckSubSum);
        }

        public string SecondTask()
        {
            return GetCheckSum(CheckDivSum);
        }

        public void SetFile(string path)
        {
            fReader = new StreamReader(path);
        }

        private string GetCheckSum(CheckSumDelegate funk)
        {
            string str = fReader.ReadLine();
            int result = 0;

            while (str != null)
            {
                if (str == "") break;
                int[] num = ParseMas(str);                
                result += funk(num);
                str = fReader.ReadLine();
            }
            fReader.BaseStream.Position = 0;
            return result.ToString();
        }

        private int CheckSubSum(int[] num)
        {
            int max, min;
            max = min = num[0];
            for (int i = 0; i < num.Length; i++)
            {
                int curr = num[i];
                min = curr < min ? curr : min;
                max = curr > max ? curr : max;
            }
            return max - min;
        }

        private int CheckDivSum(int[] num)
        {
            int first = 0, second = 0;
            for (int i = 0; i < num.Length - 1; i++)
            {
                int a = num[i], b;
                for (int j = i + 1; j < num.Length; j++)
                {
                    b = num[j];
                    if (a % b == 0 || b % a == 0)
                    {
                        first = a;
                        second = b;
                    }
                }
            }
            return first > second ? first / second : second / first;
        }

        private int[] ParseMas(string inp)
        {
            inp = Regex.Replace(inp, "[ \t]+", " ");
            string[] str = inp.Split(" ");
            int[] num = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                num[i] = int.Parse(str[i]);
            }
            return num;
        }
    }
}