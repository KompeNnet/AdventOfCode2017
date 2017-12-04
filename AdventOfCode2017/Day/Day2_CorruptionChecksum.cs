using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Day
{
    internal class Day2_CorruptionChecksum : IDay
    {
        private StreamReader fReader;

        internal Day2_CorruptionChecksum() { }

        public void SetFile(string path)
        {
            fReader = new StreamReader(path);
        }

        public string FirstTask()
        {
            string str = fReader.ReadLine();
            int result = 0;

            while (str != null)
            {
                if (str == "") break;
                int[] num = ParseMas(str);
                int max, min;
                max = min = num[0];
                for (int i = 0; i < num.Length; i++)
                {
                    int curr = num[i];
                    min = curr < min ? curr : min;
                    max = curr > max ? curr : max;
                }
                result += max - min;
                str = fReader.ReadLine();
            }
            fReader.BaseStream.Position = 0;
            return result.ToString();
        }

        public string SecondTask()
        {
            string str = fReader.ReadLine();
            int result = 0;

            while (str != null)
            {
                if (str == "") break;
                int[] num = ParseMas(str);
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
                result += first > second ? first / second : second / first;
                str = fReader.ReadLine();
            }
            fReader.BaseStream.Position = 0;
            return result.ToString();
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