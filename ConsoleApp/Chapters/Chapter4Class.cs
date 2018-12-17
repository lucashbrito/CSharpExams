using Chapter4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Chapters
{
    public class Chapter4Class
    {
        private DirectoriesClass _directoriesClass;
        private DriveInformation _driveInformation;
        private AsynchronouslyClass _asynchronously;
        private WebRequestAndWebResponse _requestAndWebResponse;
        private FileStreamClass _fileStream;


        public Chapter4Class()
        {
            _directoriesClass = new DirectoriesClass();
            _driveInformation = new DriveInformation();
            _asynchronously = new AsynchronouslyClass();
            _requestAndWebResponse = new WebRequestAndWebResponse();
            _fileStream = new FileStreamClass();
        }

        public void UsingDirectoryClass()
        {
            var directoryInfo = new DirectoryInfo(@"C:\Program Files");
            _directoriesClass.UsingCreatingDirectory();

            DirectoriesClass.ListDirectories(directoryInfo, "*a", 5, 0);
        }

        public void UsingDriveInformation()
        {
            _driveInformation.UsingDriveInformation();
        }

        public void UsingAsynchronous()
        {
            var file = _asynchronously.CreateAndWriteAsyncToFile();
            Console.WriteLine(file);

            var reuslt = _asynchronously.ReadAsyncHttpRequest();

            Console.WriteLine(reuslt);
        }

        public void UsingWebRequestAndWebResponse()
        {
            _requestAndWebResponse.RequestMicrofsoft();
        }

        public void UsingFileStream()
        {
            _fileStream.CompressingDataWithGZipStream();
            _fileStream.CreateFileStream();
            _fileStream.CreateFileUsingStreamWriter();
            _fileStream.OpenFileAndDecodeTheByteToString();
            _fileStream.ReadAllDocument();
            _fileStream.ReadWithBufferedStream();
            _fileStream.UsingExceptionHandlingWhenOpenFile();
        }
    }
}
