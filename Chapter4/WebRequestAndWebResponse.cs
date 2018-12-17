using System;
using System.IO;
using System.Net;

namespace Chapter4
{
    public class WebRequestAndWebResponse
    {
        public void RequestMicrofsoft()
        {
            var request = WebRequest.Create("http://www.microsof.com");
            var response = request.GetResponse();

            var responseStream = new StreamReader(response.GetResponseStream());
            var responseText = responseStream.ReadToEnd();

            Console.WriteLine(responseText);

            response.Close();

        }
    }
}
