namespace AdventOfCode2017.Day
{
    class Day1_InverseCaptcha : IDay
    {
        private int[] Num { get; set; }

        public Day1_InverseCaptcha(string inp = "138962597235")
        {
            inp += inp[0];
            Num = ParseMas(inp);
        }

        public string FirstTask()
        {
            int sum = 0;
            for (int i = 0; i < Num.Length - 1; i++)
            {
                if (Num[i] == Num[i + 1]) sum += Num[i];
            }
            return sum.ToString();
        }

        public string SecondTask()
        {
            int sum = 0;
            for (int i = 0; i < Num.Length / 2; i++)
            {
                if (Num[i] == Num[i + Num.Length / 2]) sum += Num[i] * 2;
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
