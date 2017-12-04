using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day
{
    internal class Day4_HighEntropyPassphrases : IDay
    {
        StreamReader fReader;

        internal Day4_HighEntropyPassphrases() { }

        public void SetFile(string path)
        {
            fReader = new StreamReader(path);
        }

        public string FirstTask()
        {
            int result = 0;
            string pass = fReader.ReadLine();

            while (pass != null)
            {
                if (pass == "") continue;
                string[] word = pass.Split(" ");
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

        public string SecondTask()
        {
            throw new NotImplementedException();
        }
    }
}
