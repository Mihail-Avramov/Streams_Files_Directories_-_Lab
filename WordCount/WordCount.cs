using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            using StreamReader wordsReader = new StreamReader(wordsFilePath);
            using StreamReader textReader = new StreamReader(textFilePath);
            using StreamWriter textWriter = new StreamWriter(outputFilePath);

            string[] words = wordsReader.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(t => t.ToLower()).ToArray();

            Dictionary<string,int> wordCounts = new Dictionary<string,int>();

            foreach (string word in words)
            {
                wordCounts[word] = 0;
            }

            string line = string.Empty;

            while((line = textReader.ReadLine()) != null)
            {
                foreach (string word in words)
                {
                    if (line.ToLower().Contains(word))
                    {
                        wordCounts[word]++;
                    }
                }
            }

            foreach (var (word, count) in wordCounts.OrderByDescending(w => w.Value))
            {
                textWriter.WriteLine($"{word} - {count}");
            }
        }
    }
}
