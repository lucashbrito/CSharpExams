using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chapter4
{
    public class AsynchronouslyClass
    {
        public async Task CreateAndWriteAsyncToFile()
        {
            using (FileStream stream = new FileStream("c:\temp\text.txt", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                byte[] data = new byte[100000];
                new Random().NextBytes(data);

                await stream.WriteAsync(data, 0, data.Length);
            }
        }

        public async Task ReadAsyncHttpRequest()
        {
            var client = new HttpClient();
            string result = await client.GetStringAsync("http://www.microsoft.com");
        }

        public async Task ExecuteMultipleRequests()
        {
            HttpClient client = new HttpClient();

            string microsoft = await client.GetStringAsync("http://wwww.microsoft.com");
            string msdn = await client.GetStringAsync("http://msdn.microsoft.com");
            string globo = await client.GetStringAsync("http://globo.com");
        }

        public async Task ExecuteMultipleRequestsInParallel()
        {
            HttpClient client = new HttpClient();

            Task microsoft = client.GetStringAsync("http://wwww.microsoft.com");
            Task msdn = client.GetStringAsync("http://msdn.microsoft.com");
            Task globo = client.GetStringAsync("http://globo.com");

            await Task.WhenAll(microsoft, msdn, globo);
        }

    }
}
