using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{
    string userBaseUrl = "";
    string userApiToken = "";
    
    HttpClient client = new HttpClient();

    public static void Main()
    {
        new Program();
    }

    public Program()
    {
      while (true)
        {
           MainMenu();
        }
    }

    public async Task MainMenu()
    {
        Console.WriteLine("--Churchtools Console Management--");
        Console.WriteLine("Choose an Action:");
        Console.WriteLine("(1) Set Churchtools API");
        Console.WriteLine("(2) Set OpenHAB API");
        Console.WriteLine("(3) Churchtools Auto Heating (Requires OpenHAB)");

        switch (Console.ReadLine())
        {
            case "1":
             SetDefaultChurchAPI();
             break;

            case "2":
             SetDefaultOpenHabAPI();
             break;

            case "3":
             await ChurchtoolsRessource();
             break;

            default:
             Console.WriteLine("Nicht legitime Eingabe.");
             break;
        }


    }
        

    public void SetDefaultOpenHabAPI()
    {
        Console.WriteLine("Paste your OpenHAB API Link:");
    }

    public void SetDefaultChurchAPI()
    {
        Console.WriteLine("Paste your Churchtools Base API Link here:");
        userBaseUrl = Console.ReadLine();
        Console.WriteLine("Paste your API Token here:");
        userApiToken = Console.ReadLine();
    }

    public async Task ChurchtoolsRessource()
    {
        while(true)
        {
         client.BaseAddress = new Uri(userBaseUrl);
         client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Login", $"token={userApiToken}");
         DateTime thisDay = DateTime.Today.Date;
         Console.WriteLine(thisDay.ToString("yyyy-MM-dd"));
         TimeSpan currentTime = DateTime.Now.TimeOfDay;
         HttpResponseMessage response = await client.GetAsync($"/api/resource/bookings?from={thisDay}&to={thisDay.AddDays(1)}");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                string errorMsg = await response.Content.ReadAsStringAsync();
                Console.WriteLine(errorMsg);
            }
            Thread.Sleep(1800);
        }
    }
}

