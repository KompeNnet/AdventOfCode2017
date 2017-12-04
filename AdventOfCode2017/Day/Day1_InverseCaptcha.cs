using System.Reflection;

namespace AdventOfCode2017.Day
{
    internal class Day1_InverseCaptcha : IDay
    {
        private int[] num;

        internal Day1_InverseCaptcha(string inp = "138962597235")
        {
            SetInp(inp);
        }

        public void SetInp(string inp)
        {
            inp += inp[0];
            num = ParseMas(inp);
        }
                
        public string FirstTask()
        {
            int sum = 0;
            for (int i = 0; i < num.Length - 1; i++)
            {
                if (num[i] == num[i + 1]) sum += num[i];
            }
            return sum.ToString();
        }

        public string SecondTask()
        {
            int sum = 0;
            for (int i = 0; i < num.Length / 2; i++)
            {
                if (num[i] == num[i + num.Length / 2]) sum += num[i] * 2;
            }
            return sum.ToString();
        }

        private int[] ParseMas(string inp)
        {
            int[] num = new int[inp.Length];
            for (int i = 0; i < inp.Length; i++)
            {
                num[i] = int.Parse(inp[i].ToString());
            }
            return num;
        }
    }
}
