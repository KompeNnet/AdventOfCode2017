using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day
{
    internal class Day4_HighEntropyPassphrases : IDay
    {
        delegate string[] FormattingDelegate(string s);
        StreamReader fReader;

        internal Day4_HighEntropyPassphrases() { }

        public void SetFile(string path)
        {
            fReader = new StreamReader(path);
        }

        public string FirstTask()
        {
            return CountValid(SplitWords);
        }

        public string SecondTask()
        {
            return CountValid(SortLetter);
        }

        private string CountValid(FormattingDelegate func)
        {
            int result = 0;
            string pass = fReader.ReadLine();

            while (pass != null)
            {
                if (pass == "") continue;
                string[] word = func(pass);
                bool valid = true;
                foreach (string w in word)
                {
                    if (word.Where(x => x.Equals(w)).Count() > 1)
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid) result++;
                pass = fReader.ReadLine();
            }
            fReader.BaseStream.Position = 0;
            return result.ToString();
        }

        private string[] SplitWords(string pass)
        {
            return pass.Split(" ");
        }

        private string[] SortLetter(string pass)
        {
            string[] result = SplitWords(pass);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = String.Concat(result[i].OrderBy(x => x).ToArray());
            }
            return result;
        }
    }
}
