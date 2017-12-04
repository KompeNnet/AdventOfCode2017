using System.IO;

namespace AdventOfCode2017.Day
{
    internal class Day1_InverseCaptcha : IDay
    {
        private StreamReader fReader;
        private int[] num;

        internal Day1_InverseCaptcha() { }
        
        public void SetFile(string path)
        {
            fReader = new StreamReader(path);
        }
                
        public string FirstTask()
        {
            string inp = fReader.ReadLine();
            inp += inp[0];
            num = ParseMas(inp);

            int sum = 0;
            for (int i = 0; i < num.Length - 1; i++)
            {
                if (num[i] == num[i + 1]) sum += num[i];
            }
            fReader.BaseStream.Position = 0;
            return sum.ToString();
        }

        public string SecondTask()
        {
            string inp = fReader.ReadLine();
            inp += inp[0];
            num = ParseMas(inp);

            int sum = 0;
            for (int i = 0; i < num.Length / 2; i++)
            {
                if (num[i] == num[i + num.Length / 2]) sum += num[i] * 2;
            }
            fReader.BaseStream.Position = 0;
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
