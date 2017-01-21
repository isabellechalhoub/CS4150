using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PS1
{
    class anaga
    {
        static void Main()
        {
            int n, k;
            string[] sizes = Console.ReadLine().Split();

            n = int.Parse(sizes[0]);
            k = int.Parse(sizes[1]);
            List<string> dictionary = new List<string>();

            HashSet<string> solutions = new HashSet<string>();
            HashSet<string> rejected = new HashSet<string>();

            string w;
            while ((w = Console.ReadLine()) != null && (w != ""))
            {
                dictionary.Add(w);
            }

            char[] sortedWord = new char[0];

            foreach (string word in dictionary)
            {
                sortedWord = word.ToCharArray();
                sortedWord.OrderBy(c => c);
            }
            Debug.WriteLine(sortedWord.ToString());
        }
    }
}
