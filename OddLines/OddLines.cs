using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFile)
        {
            using StreamReader reader = new StreamReader(inputFilePath);
            using StreamWriter writer = new StreamWriter(outputFile);

            int n = 0;
            string input = string.Empty;

            while ((input = reader.ReadLine()) != null)
            {
                if (n % 2 == 1)
                {
                    writer.WriteLine(input);
                }

                n++;
            }

        }
    }
}
