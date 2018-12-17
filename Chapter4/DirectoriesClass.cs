using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    public class DirectoriesClass
    {
        public void UsingCreatingDirectory()
        {
            var directory = Directory.CreateDirectory(@"C:\Temp\CSharp");

            var directoryInfo = new DirectoryInfo(@"C:\Temp\Csharp");
            directoryInfo.Create();

            if (Directory.Exists(@"C:\Temp\CSharp"))
            {
                Directory.Delete(@"C:\Temp\CSharp");
            }

            if (directoryInfo.Exists)
            {
                directoryInfo.Delete();
            }

            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

            directorySecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.ReadAndExecute, AccessControlType.Allow));

            directoryInfo.SetAccessControl(directorySecurity);
        }

        public static void ListDirectories(DirectoryInfo directoryInfo, string searchPattern, int maxLevel, int currentLevel)
        {
            if (currentLevel >= maxLevel)
            {
                return;
            }

            string indent = new string('-', currentLevel);

            try
            {
                var subDirectories = directoryInfo.GetDirectories(searchPattern);

                foreach (var subDirectory in subDirectories)
                {
                    Console.WriteLine(indent + subDirectory.Name);
                    ListDirectories(subDirectory, searchPattern, maxLevel, currentLevel + 1);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(indent + "Can't access: " + directoryInfo.Name);
                throw;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(indent + " Can't find:" + directoryInfo.Name);
            }
        }

        public void UsingMoveDirectory()
        {
            Directory.Move(@"C:\source", @"C:\Destination");

            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\source");
            directoryInfo.MoveTo(@"C:\Destination");
        }

        public void ListAllFiles()
        {
            foreach (var file in Directory.GetFiles(@"C:\Windows"))
            {
                Console.WriteLine($"Using directory {file}");
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Windows");
            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                Console.WriteLine($"Using directoryInfo {fileInfo}");
            }
        }

        public void DeleteFile()
        {
            string path = @"c:\temp\test.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }

        public void MoveFile()
        {
            string path = @"c:\temp\test.txt";
            string destPath = @"c:\temp\destTest.txt";

            File.CreateText(path).Close();

            File.Move(path, destPath);

            FileInfo fileInfo = new FileInfo(path);
            fileInfo.MoveTo(destPath);
        }

        public void CopyFile()
        {
            string path = @"c:\temp\test.txt";
            string destPath = @"c:\temp\desTest.txt";

            File.CreateText(path).Close();
            File.Copy(path, destPath);

            FileInfo fileInfo = new FileInfo(path);
            fileInfo.CopyTo(destPath);
        }

        public void UsingPathCombine()
        {
            string folder = @"C:\Temp";
            string filerName = @"test.txt";

            var fullPath = Path.Combine(folder, filerName);

            Console.WriteLine(Path.GetDirectoryName(fullPath)); 
            Console.WriteLine(Path.GetExtension(fullPath)); 
            Console.WriteLine(Path.GetFileName(fullPath)); 
            Console.WriteLine(Path.GetPathRoot(fullPath)); 
        }
    }
}
