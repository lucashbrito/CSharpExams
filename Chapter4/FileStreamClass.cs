using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Chapter4
{
    public class FileStreamClass
    {
        public void CreateFileStream()
        {
            string path = @"c:\temp\test.txt";

            using (FileStream fileStream = File.Create(path))
            {
                string myValue = "MyValue text, text, text, text ";
                byte[] data = Encoding.UTF8.GetBytes(myValue);
                fileStream.Write(data, 0, data.Length);
            }
        }

        public void CreateFileUsingStreamWriter()
        {
            string path = @"c:\temp\test.txt";

            using (StreamWriter streamWriter = File.CreateText(path))
            {
                string myValue = "«MyValue>>";
                streamWriter.Write(myValue);
            }
        }

        public void OpenFileAndDecodeTheByteToString()
        {
            string path = @"c:\temp\test.txt";

            using (FileStream fileStream = File.OpenRead(path))
            {
                var data = new byte[fileStream.Length];

                for (int index = 0; index < fileStream.Length; index++)
                {
                    data[index] = (byte)fileStream.ReadByte();
                }

                Console.WriteLine(Encoding.UTF8.GetString(data));
            }

            using (StreamReader streamWriter = File.OpenText(path))
            {
                Console.WriteLine(streamWriter.ReadLine());
            }
        }

        public void CompressingDataWithGZipStream()
        {
            string folder = @"c:\temp";
            string uncompressedFilePath = Path.Combine(folder, "uncompressed.dat");
            string compressedFilePath = Path.Combine(folder, "compressed.gz");
            byte[] dataToCompress = Enumerable.Repeat((byte)'a', 1024 * 1024).ToArray();

            using (FileStream uncompressedFileStream = File.Create(uncompressedFilePath))
            {
                uncompressedFileStream.Write(dataToCompress, 0, dataToCompress.Length);
            }

            using (FileStream compressedFileStream = File.Create(compressedFilePath))
            {
                using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                {
                    compressionStream.Write(dataToCompress, 0, dataToCompress.Length);
                }
            }

            FileInfo uncompressedFile = new FileInfo(uncompressedFilePath);
            FileInfo compressedFile = new FileInfo(compressedFilePath);

            Console.WriteLine(compressedFile.Length);
            Console.WriteLine(uncompressedFile.Length);

        }

        public void ReadWithBufferedStream()
        {
            string path = @"c:\temp\bufferedSteam.txt";

            using (FileStream fileStream = File.Create(path))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    using (StreamWriter streamWriter = new StreamWriter(bufferedStream))
                    {
                        streamWriter.WriteLine("A line of text.");
                    }
                }
            }
        }

        public string ReadAllDocument()
        {
            var path = @"c:\temp\test.txt";

            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }

            return string.Empty;
        }

        public string UsingExceptionHandlingWhenOpenFile()
        {
            var path = @"c:\temp\test.txt";

            try
            {
                return File.ReadAllText(path);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }

            return string.Empty;
        }
    }
}
