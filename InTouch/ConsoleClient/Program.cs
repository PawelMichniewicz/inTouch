using CommunicationWebApi.Models;
using System;
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
        Console.WriteLine();

        Client.BaseAddress = new Uri("https://localhost:7269");
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        Message? message = await GetChatRoomAsync(1);
        PrintMessage(message);

        message = await GetChatRoomAsync(2);
        PrintMessage(message);

        message = await GetChatRoomAsync(3);
        PrintMessage(message);

        message = await GetChatRoomAsync(4);
        PrintMessage(message);
    }

    private static void PrintMessage(Message? message)
    {
        Console.WriteLine($"{message?.Sender?.Name} writes in \"{message?.ChatRoom?.Name}\":");
        Console.WriteLine($"{message?.Timestamp.ToShortDateString()} {message?.Timestamp.ToShortTimeString()}");
        Console.WriteLine($"{message?.Sender?.Nickname}: {message?.Content}");
        Console.WriteLine();
    }

    static async Task<Message?> GetChatRoomAsync(int msgId)
    {
        Message? result = null;
        HttpResponseMessage response = await Client.GetAsync($"/api/Empty/{msgId}");
        if (response.IsSuccessStatusCode)
        {
            result = await response.Content.ReadFromJsonAsync<Message>();
        }
        return result;
    }

}