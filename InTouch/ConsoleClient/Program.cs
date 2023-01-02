//using Azure;
using CommunicationWebApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

internal class Program
{
    private static HttpClient WebApi = new();
    private static User userProfile;

    private static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information

        RunAsync().GetAwaiter().GetResult();
    }

    static async Task RunAsync()
    {
        InitHttpClient();

        var tempName = "Joey Tribbiani";
        var res = await SignInAsync(tempName);
        if (!res)
        {
            Console.WriteLine("Login Failed! Exiting!");
            return;
        }

        Console.WriteLine($"Hi There {userProfile.Name}!");
        Console.WriteLine("Let's stay inTouch!");
        Console.WriteLine();

        var temp = await GetChatRoomsAsync(userProfile.Name);

        if (temp is not null)
        {
            foreach (var chat in temp)
            {
                Console.WriteLine(chat);
            }
        }

        //Message? message = await GetChatRoomAsync(1);
        //PrintMessage(message);

        //message = await GetChatRoomAsync(2);
        //PrintMessage(message);
    }

    private static async Task<bool> SignInAsync(string user)
    {
        bool result = false;
        HttpResponseMessage response = await WebApi.GetAsync($"api/User/userName?userName={user}");
        if (response.IsSuccessStatusCode)
        {
            userProfile = await response.Content.ReadFromJsonAsync<User>();
            result = true;
        }
        return result;
    }

    private static void InitHttpClient()
    {
        WebApi.BaseAddress = new Uri("https://localhost:7269");
        WebApi.DefaultRequestHeaders.Accept.Clear();
        WebApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
        HttpResponseMessage response = await WebApi.GetAsync($"/api/Message/{msgId}");
        if (response.IsSuccessStatusCode)
        {
            result = await response.Content.ReadFromJsonAsync<Message>();
        }
        return result;
    }

    static async Task<ICollection<string>?> GetChatRoomsAsync(string name)
    {
        ICollection<string>? result = null;
        HttpResponseMessage response = await WebApi.GetAsync($"/api/User/{name}");
        if (response.IsSuccessStatusCode)
        {
            result = await response.Content.ReadFromJsonAsync<ICollection<string>>();
        }
        return result;
    }

}