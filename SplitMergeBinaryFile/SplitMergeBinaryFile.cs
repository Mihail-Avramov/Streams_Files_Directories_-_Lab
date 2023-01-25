using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using FileStream stream = new FileStream(sourceFilePath, FileMode.Open);
            
            if (stream.Length % 2 == 1)
            {
                long sizePart1 = stream.Length / 2 + 1;

                using FileStream partStream1 = new FileStream(partOneFilePath, FileMode.OpenOrCreate);
                byte[] buffer = new byte[sizePart1];
                stream.Read(buffer, 0, (int)sizePart1);
                partStream1.Write(buffer, 0, buffer.Length);

                long sizePart2 = stream.Length / 2;

                using FileStream partStream2 = new FileStream(partTwoFilePath, FileMode.OpenOrCreate);
                buffer = new byte[sizePart2];
                stream.Read(buffer, 0, (int)sizePart2);
                partStream2.Write(buffer, 0, buffer.Length);
            }
            else
            {
                long sizePart1 = stream.Length / 2;

                using FileStream partStream1 = new FileStream(partOneFilePath, FileMode.OpenOrCreate);
                byte[] buffer = new byte[sizePart1];
                stream.Read(buffer, 0, (int)sizePart1);
                partStream1.Write(buffer, 0, buffer.Length);

                long sizePart2 = stream.Length / 2;

                using FileStream partStream2 = new FileStream(partTwoFilePath, FileMode.OpenOrCreate);
                buffer = new byte[sizePart2];
                stream.Read(buffer, 0, (int)sizePart2);
                partStream2.Write(buffer, 0, buffer.Length);
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using FileStream stream1 = new FileStream(partOneFilePath, FileMode.Open);
            using FileStream stream2 = new FileStream(partTwoFilePath, FileMode.Open);

            using FileStream joinFileStream = new FileStream(joinedFilePath, FileMode.OpenOrCreate);

            byte[] buffer1 = new byte[stream1.Length];
            stream1.Read(buffer1, 0, buffer1.Length);
            joinFileStream.Write(buffer1, 0, buffer1.Length);

            byte[] buffer2 = new byte[stream2.Length];
            stream2.Read(buffer2, 0, buffer2.Length);
            joinFileStream.Write(buffer2, 0, buffer2.Length);
        }
    }
}