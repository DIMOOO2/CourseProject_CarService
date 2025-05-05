using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CarService.NewWebAPITEst
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            Console.WriteLine(await client.GetStringAsync("https://localhost:1488/AutoPart"));
            Console.WriteLine(await client.GetStringAsync("https://localhost:1488/Client"));
            Console.WriteLine(await client.GetStringAsync("https://localhost:1488/CorporateAccount"));
            Console.WriteLine(await client.GetStringAsync("https://localhost:1488/Manufacturer"));
            Console.WriteLine(await client.GetStringAsync("https://localhost:1488/Order"));
            Console.WriteLine(await client.GetStringAsync("https://localhost:1488/OrderedPart"));
            Console.WriteLine(await client.GetStringAsync("https://localhost:1488/Organization"));
            Console.WriteLine(await client.GetStringAsync("https://localhost:1488/Warehouse"));

            Console.ReadLine();
        }
    }
}
