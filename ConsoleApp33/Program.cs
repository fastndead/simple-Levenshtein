using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace ConsoleApp15
{
    class Program
    {
        static class LevenshteinDistance
        {
            /// <summary>
            /// Compute the distance between two strings.
            /// </summary>
            public static int Compute(string s, string t)
            {
                int n = s.Length;
                int m = t.Length;
                int[,] d = new int[n + 1, m + 1];

                // Step 1
                if (n == 0)
                {
                    return m;
                }

                if (m == 0)
                {
                    return n;
                }

                // Step 2
                for (int i = 0; i <= n; d[i, 0] = i++)
                {
                }

                for (int j = 0; j <= m; d[0, j] = j++)
                {
                }

                // Step 3
                for (int i = 1; i <= n; i++)
                {
                    //Step 4
                    for (int j = 1; j <= m; j++)
                    {
                        // Step 5
                        int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                        // Step 6
                        d[i, j] = Math.Min(
                            Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                            d[i - 1, j - 1] + cost);
                    }
                }
                // Step 7
                return d[n, m];
            }
        }

        static string GetSimilarString(string input, StreamReader words)
        {
            string minDistWord = "ОШИБКА";
            using (words)
            {
                var minDist = 0;
                
                String line;
                do
                {
                    line = words.ReadLine();

                    var currentDist = LevenshteinDistance.Compute(input, line);
                    if (currentDist < minDist || minDist == 0)
                    {
                        minDist = currentDist;
                        minDistWord = line;
                    }

                } while (!words.EndOfStream);
            }

            return minDistWord;
        }

        static void Main()
        {
            StreamReader f = new StreamReader("input.txt", Encoding.GetEncoding("windows-1251"));
            
            StreamWriter g = new StreamWriter("output.txt");
            string s1 = f.ReadLine();//первая последовательность
            string s2 = f.ReadToEnd();//вторая последовательность

            string input = Console.ReadLine();

            
            string[] inputWords = input.Split(' ');


            for (int i = 0; i < inputWords.Length; i++)
            {
                Console.Write(GetSimilarString(inputWords[i], new StreamReader("words.txt")) + " ");
                
            }


            
            
        }
    }
}
