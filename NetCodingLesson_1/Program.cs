using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace NetCodingLesson_1
{
    class Program
    {




        static void Main(string[] args)
        {




            Example_04();
        }

        public static void Example_01()
        {
            WebClient client = new WebClient();

            Stream data = client
                .OpenRead(@"http://www.google.com");

            using (
                 StreamReader reader = new StreamReader(data))
            {
                string str = reader.ReadToEnd();

                Console.WriteLine(str);
            }





            data.Close();

        }

        private static void Example_02(string url, string data)
        {
            byte[] postArr = Encoding.ASCII.GetBytes(data);


            WebClient client = new WebClient();

            using (
                Stream stream = client.OpenWrite(url)
                )
            {
                stream.Write(postArr, 0, postArr.Length);
            }

        }

        private static void Example_03(string url, string data)
        {



            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.UploadString(url, data);

            Console.WriteLine(result);
        }


        public static void Example_04()
        {
            WebRequest request = WebRequest.Create(@"http://google.com");


            request.Timeout = 10000;
            request.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            Console.WriteLine(response.StatusDescription);
            StreamReader reader = new StreamReader(response.GetResponseStream());


            Console.WriteLine(reader.ReadToEnd());

            reader.Close();
        }

        public static void Example_05()
        {
            WebRequest request = WebRequest.Create(@"http://google.com");


            request.Timeout = 10000;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            Console.WriteLine(response.StatusDescription);
            StreamReader reader = new StreamReader(response.GetResponseStream());


            Console.WriteLine(reader.ReadToEnd());

            reader.Close();
        }
    }
}
