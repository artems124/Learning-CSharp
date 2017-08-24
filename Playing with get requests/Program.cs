using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;


//Testing the get request feature using newsapi library

namespace Playing_with_get_requests
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://newsapi.org/v1/articles?source=the-next-web&sortBy=latest&apiKey={API_KEY}
            //Creating strings for important parts of HTTP url           
            string source = "techcrunch";
            string apiKey = "0392c544d8b147a4ae0ffb4e424a897c";
            string sortBy = "latest";

            //Creating http url
            string htmlData = string.Empty;
            string httpUrl = @"https://newsapi.org/v1/articles?source=" + source + "&sortBy="
                + sortBy + "&apiKey=" + apiKey;

            //Sending HTTP get request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpUrl);

            //Enabling decompression
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                htmlData = reader.ReadToEnd();
            }

            //Receiving JSON data as string
            //Console.WriteLine(htmlData);

            //Deserializing JSON string

            Console.ReadKey();
        }
    }
}
