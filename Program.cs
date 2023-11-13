

namespace kikkl
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using static System.Net.WebRequestMethods;

    public class Program
    {

        static async Task Main()
        {
            List<string> apiUrls = new List<string>
            {
                "https://www.geeksforgeeks.org/",
                "https://stackoverflow.com/questions/18830397/awaiting-a-non-async-method",
                "https://www.youtube.com/"
            };

            await Async(apiUrls);
            NonAsync(apiUrls);
        }



        static async Task Async(List<string> apiUrls)
        {

            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Console.WriteLine("TOTAL Asnyc => ");
                foreach (var apiUrl in apiUrls)
                {

                    try
                    {
                       HttpResponseMessage response = await client.GetAsync(apiUrl);

                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Sehv baş verdi: {ex.Message}");
                    }

                }
                stopwatch.Stop();
                Console.WriteLine($"Ümumi sorğu vaxti: {stopwatch.ElapsedMilliseconds} millisaniye");
            }
        }




        static void NonAsync(List<string> apiUrls)
        {
            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Console.WriteLine("Total Non-Asnyc => ");                                       
                foreach (var apiUrl in apiUrls)
                {
                    try
                    {
                       HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Səhv baş verdi: {ex.Message}");
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($"Ümumi sorğu vaxti: {stopwatch.ElapsedMilliseconds} millisaniye");
            }
        }

       
    }


}