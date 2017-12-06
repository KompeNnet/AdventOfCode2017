using System.IO;

namespace AdventOfCode2017.Day
{
    internal class Day1_InverseCaptcha : IDay
    {
        private delegate int SumDelegate(int[] mas);
        private StreamReader fReader;

        internal Day1_InverseCaptcha() { }
                
        public string FirstTask()
        {
            return GetSum(SumOfSameNext);
        }

        public string SecondTask()
        {
            return GetSum(SumOfSameInHalf);
        }
        
        public void SetFile(string path)
        {
            fReader = new StreamReader(path);
        }

        private string GetSum(SumDelegate funk)
        {
            string inp = fReader.ReadLine();
            inp += inp[0];
            int[] num = ParseMas(inp);
            fReader.BaseStream.Position = 0;
            return funk(num).ToString();
        }

        private int SumOfSameNext(int[] num)
        {
            int sum = 0;
            for (int i = 0; i < num.Length - 1; i++)
            {
                if (num[i] == num[i + 1]) sum += num[i];
            }
            return sum;
        }

        private int SumOfSameInHalf(int[] num)
        {
            int sum = 0;
            for (int i = 0; i < num.Length / 2; i++)
            {
                if (num[i] == num[i + num.Length / 2]) sum += num[i] * 2;
            }
            return sum;
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
