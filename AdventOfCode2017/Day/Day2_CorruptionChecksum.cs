using System.Text.RegularExpressions;

namespace AdventOfCode2017.Day
{
    class Day2_CorruptionChecksum : IDay
    {
        private int[] Num { get; set; }

        public Day2_CorruptionChecksum(string inp)
        {
            inp = Regex.Replace(inp, "[ \t]+", " ");
            Num = ParseMas(inp);
        }

        public string FirstTask()
        {
            int result = 0;
            for (int i = 0; i < Num.Length; i += 16)
            {
                int max, min;
                max = min = Num[i];
                for (int j = 1; j < 16; j++)
                {
                    int num = Num[i + j];
                    min = num < min ? num : min;
                    max = num > max ? num : max;
                }
                result += max - min;
            }
            return result.ToString();
        }

        public string SecondTask()
        {
            int result = 0;
            for (int i = 0; i < Num.Length; i += 16)
            {
                int first = 0, second = 0;
                for (int j = 0; j < 15; j++)
                {
                    int a = Num[i + j], b;
                    for (int k = j + 1; k < 16; k++)
                    {
                        b = Num[i + k];
                        if (a % b == 0 || b % a == 0)
                        {
                            first = a;
                            second = b;
                        }
                    }
                }
                result += first > second ? first / second : second / first;
            }
            return result.ToString();
        }

        private int[] ParseMas(string inp)
        {
            string[] str = inp.Split(" ");
            int[] mas = new int[256];
            for (int i = 0; i < str.Length; i++)
            {
                mas[i] = int.Parse(str[i]);
            }
            return mas;
        }
    }
}