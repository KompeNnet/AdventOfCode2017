using System.Text.RegularExpressions;

namespace AdventOfCode2017.Day
{
    class Day2_CorruptionChecksum : IDay
    {
        private int[,] Num { get; set; }

        public Day2_CorruptionChecksum() { }

        public void SetInp(string inp)
        {
            inp = Regex.Replace(inp, "[ \t]+", " ");
            Num = ParseMas(inp);
        }

        public string FirstTask()
        {
            int result = 0;
            for (int i = 0; i < Num.Length / (Num.GetUpperBound(0) + 1); i++)
            {
                int max, min;
                max = min = Num[i,0];
                for (int j = 1; j < Num.GetUpperBound(0) + 1; j++)
                {
                    int num = Num[i,j];
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
            for (int i = 0; i < Num.Length / (Num.GetUpperBound(0) + 1); i++)
            {
                int first = 0, second = 0;
                for (int j = 0; j < Num.GetUpperBound(0); j++)
                {
                    int a = Num[i,j], b;
                    for (int k = j + 1; k < Num.GetUpperBound(0) + 1; k++)
                    {
                        b = Num[i, k];
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

        private int[,] ParseMas(string inp)
        {
            string[] row = inp.Split("\n");
            string[][] str = new string[16][];
            for (int i = 0; i < row.Length; i++)
            {
                str[i] = row[i].Split(" ");
            }
            int[,] mas = new int[16,16];
            for (int i = 0; i < str.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < str.Length; j++)
                    mas[i,j] = int.Parse(str[i][j]);
            }
            return mas;
        }
    }
}