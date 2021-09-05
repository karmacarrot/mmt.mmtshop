using Mmt.MmtShop.ProductService.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Threading.Tasks;

namespace Mmt.MmtShop.ApiConsole
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Configuring client...");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "MMT Shop Console API Test App");

            Console.WriteLine("GET all categories...");
            await GetApiResponse(client, "Categories");
        }


        private static async Task GetApiResponse(HttpClient client, string path)
        {
            var getTask = client.GetStringAsync("https://localhost:44324/" + path);
            var jsonResponse = await getTask;
            Console.Write(jsonResponse);
        }
    }
}
