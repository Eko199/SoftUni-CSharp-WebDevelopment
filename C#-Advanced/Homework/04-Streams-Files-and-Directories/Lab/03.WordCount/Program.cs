using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var wordCount = new Dictionary<string, int>();

            using (var reader = new StreamReader(wordsFilePath))
            {
                string[] words = reader.ReadToEnd().Split();

                foreach (string word in words)
                {
                    wordCount.Add(word.ToLower(), 0);
                }
            }

            using (var reader = new StreamReader(textFilePath))
            {
                var regex = new Regex(@"[^\w]");
                string[] words = regex.Split(reader.ReadToEnd().ToLower());

                foreach (string word in words)
                {
                    if (wordCount.ContainsKey(word))
                        wordCount[word]++;
                }
            }

            using var writer = new StreamWriter(outputFilePath);
            foreach (var wordOccurrence in 
                     wordCount.OrderByDescending(word => word.Value))
            {
                writer.WriteLine($"{wordOccurrence.Key} - {wordOccurrence.Value}");
            }
        }
    }
}

