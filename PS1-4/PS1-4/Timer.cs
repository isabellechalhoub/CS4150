// Written by Joe Zachary for CS 4150, January 2016

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PS1_4
{
    /// <summary>
    /// Provides a timing demo.
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// The number of repetitions used in versions 2 and 3
        /// </summary>
        public const int REPTS = 1000;

        /// <summary>
        /// The minimum duration of a timing eperiment (in msecs) in versions 4 and 5
        /// </summary>
        public const int DURATION = 1000;

        /// <summary>
        /// The size of the array in versions 1 through 5
        /// </summary>
        public const int SIZE = 1023;

        /// <summary>
        /// Drives the timing demo.
        /// </summary>
        public static void Main()
        {
            // Let's look at precise the Stopwatch is
            Console.WriteLine("Is high resolution: " + Stopwatch.IsHighResolution);
            Console.WriteLine("Ticks per second: " + Stopwatch.Frequency);
            Console.WriteLine();

            // Now do an experiment.
            //Console.Write("Enter choice (1-9): ");
            //int choice = Convert.ToInt32(Console.ReadLine());
            RunExperiment();
            //Console.Read();
        }

        /// <summary>
        /// Runs different experiments depending on the value of approach.
        /// </summary>
        public static void RunExperiment()
        {
            Console.WriteLine("Time: " + TimeAnagram1(SIZE).ToString("G3"));
        }

        /// <summary>
        /// Returns the number of milliseconds that have elapsed on the Stopwatch.
        /// </summary>
        public static double msecs(Stopwatch sw)
        {
            return (((double)sw.ElapsedTicks) / Stopwatch.Frequency) * 1000;
        }
        
        public static double TimeAnagram1(int size)
        {
            string filePath = "C:/Users/isabe/Desktop/anagrams.txt";
            List<string> dictionary = System.IO.File.ReadLines(filePath).ToList();

            // Get the process
            Process p = Process.GetCurrentProcess();

            // Keep increasing the number of repetitions until one second elapses.
            double elapsed = 0;
            long repetitions = 1;
            do
            {
                repetitions *= 2;
                TimeSpan start = p.TotalProcessorTime;
                for (int i = 0; i < repetitions; i++)
                {
                    for (int d = 0; d < size; d++)
                    {
                        findAnagrams(dictionary);
                       // BinarySearch(data, d);
                    }
                }
                TimeSpan stop = p.TotalProcessorTime;
                elapsed = stop.TotalMilliseconds - start.TotalMilliseconds;
            } while (elapsed < DURATION);
            double totalAverage = elapsed / repetitions / size;

            // Keep increasing the number of repetitions until one second elapses.
            elapsed = 0;
            repetitions = 1;
            do
            {
                repetitions *= 2;
                TimeSpan start = p.TotalProcessorTime;
                for (int i = 0; i < repetitions; i++)
                {
                    for (int d = 0; d < size; d++)
                    {
                    }
                }
                TimeSpan stop = p.TotalProcessorTime;
                elapsed = stop.TotalMilliseconds - start.TotalMilliseconds;
            } while (elapsed < DURATION);
            double overheadAverage = elapsed / repetitions / size;

            // Return the difference
            return totalAverage - overheadAverage;
        }

        public static void findAnagrams(List<string> dictionary)
        {
            HashSet<string> solutions = new HashSet<string>();
            HashSet<string> rejected = new HashSet<string>();

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
        }
    }
}




