using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Day
{
    internal class Day4_HighEntropyPassphrases : IDay
    {
        StreamReader fStream;

        internal Day4_HighEntropyPassphrases() { }

        public void SetInp(string inp)
        {
            fStream = new StreamReader(inp);
        }

        public string FirstTask()
        {
            int result = 0;
            string pass = fStream.ReadLine();

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
                pass = fStream.ReadLine();
            }

            return result.ToString();
        }

        public string SecondTask()
        {
            throw new NotImplementedException();
        }
    }
}
