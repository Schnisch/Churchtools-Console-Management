using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
class Program {
    string apiUrl = "https://api.churchtools.de/v2.1/"; 
    string apiToken = "your_api_token_here";
    string userApiUrl = "";
    string userApiToken = "";
    HttpClient client = new HttpClient();

    static void Main()
    {
      
    }

    public void Menu()
    {
        Console.WriteLine("--Churchtools Console Management--");
        Console.WriteLine("Choose an Action:");
        Console.WriteLine("(1) Set Default API");
    }

    public void SetDefaultAPI()
    {
        Console.WriteLine("Paste your API Link:");

    }
}