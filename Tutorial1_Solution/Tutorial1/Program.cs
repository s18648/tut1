using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Tutorial1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var websiteur1 = args[0];
            //Console.WriteLine("Hello World!");
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(websiteur1);

            if(response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z0-9]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach (var emailAddress in matches)
                {
                    Console.WriteLine(emailAddress.ToString());
                }

            }

            Console.ReadKey();
        }
    }
}
