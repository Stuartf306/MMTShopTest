using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace MMTConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The following products are currently featured:");
            GetProducts().Wait();

            Console.WriteLine();

            Console.WriteLine("Enter a category ID to see all available products from one of following categories:");
            GetCategories().Wait();

            int catID = 0;
            while(catID == 0)
            {
                var catInput = Console.ReadLine();
                if (int.TryParse(catInput, out catID))
                {
                    GetProductsByCategory(catID).Wait();
                }
                else
                {
                    Console.WriteLine("Please enter a valid category ID.");
                }
            }
                
            Console.ReadLine();
        }

        static async System.Threading.Tasks.Task GetProducts()
        {
            string apiUrl = "http://localhost:44384/api/";
            string routeUrl = "products";

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiUrl);

                HttpResponseMessage response = await httpClient.GetAsync(routeUrl);
                httpClient.DefaultRequestHeaders.ExpectContinue = true;
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
            }
        }

        static async System.Threading.Tasks.Task GetCategories()
        {
            string apiUrl = "http://localhost:44384/api/";
            string routeUrl = "categories";

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiUrl);

                HttpResponseMessage response = await httpClient.GetAsync(routeUrl);
                httpClient.DefaultRequestHeaders.ExpectContinue = true;
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
            }
        }
        static async System.Threading.Tasks.Task GetProductsByCategory(int catID)
        {
            string apiUrl = "http://localhost:44384/api/";
            string routeUrl = "categories/" + catID;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiUrl);

                HttpResponseMessage response = await httpClient.GetAsync(routeUrl);
                httpClient.DefaultRequestHeaders.ExpectContinue = true;
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
            }
        }
    }
}
