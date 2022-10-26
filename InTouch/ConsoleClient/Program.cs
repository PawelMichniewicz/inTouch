using CommunicationWebApi;
using ConsoleClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

internal class Program
{
    private static HttpClient Client = new HttpClient();

    private static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        RunAsync().GetAwaiter().GetResult();
    }

    static async Task RunAsync()
    {
        Console.WriteLine("Hi There! Let's stay inTouch!");

        //Console.WriteLine("Provide your LOGIN:");
        //User u = new();
        //u.Login = Console.ReadLine()?.ToLower();
        //Console.WriteLine("Provide your Password:");
        //u.Password = Console.ReadLine()?.ToLower();
        //Console.WriteLine($"You are now logged in as {u.Login} with password {u.Password}");

        
        Console.WriteLine("Give me PORT:");
        string? port = Console.ReadLine()?.ToLower();

        Client.BaseAddress = new Uri($"https://localhost:{port}");
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        WeatherForecast? forecast = await GetForecastAsync();
        Console.WriteLine($"your forecast for {forecast?.Date}:");
        Console.WriteLine($"Temperature C: {forecast?.TemperatureC}");
        Console.WriteLine($"Temperature F: {forecast?.TemperatureF}");
        Console.WriteLine($"Summary: {forecast?.Summary}");
    }

    static async Task<WeatherForecast?> GetForecastAsync()
    {
        WeatherForecast? result = null;
        HttpResponseMessage response = await Client.GetAsync("/WeatherForecast");
        if (response.IsSuccessStatusCode)
        {
            result = await response.Content.ReadFromJsonAsync<WeatherForecast>();
        }
        return result;
    }

}