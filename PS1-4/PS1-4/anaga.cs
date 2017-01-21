using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, k;
            string[] sizes = Console.ReadLine().Split();

            n = int.Parse(sizes[0]);
            k = int.Parse(sizes[1]);
            List<string> dictionary = new List<string>();

            HashSet<string> solutions = new HashSet<string>();
            HashSet<string> rejected = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                dictionary.Add(RandomString(k));
            }

            //string w;
            //while ((w = Console.ReadLine()) != null && (w != ""))
            //{
            //    dictionary.Add(w);
            //}

            char[] sortArray = new char[0];
            string sortedWord = "";

            foreach (string word in dictionary)
            {
                sortArray = word.ToCharArray();
                Array.Sort(sortArray);
                sortedWord = new string(sortArray);

                if (solutions.Contains(sortedWord))
                {
                    solutions.Remove(sortedWord);
                    rejected.Add(sortedWord);
                }
                else if (!rejected.Contains(sortedWord))
                {
                    solutions.Add(sortedWord);
                }
            }
            Console.Write(solutions.Count);
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "abcdefg";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
