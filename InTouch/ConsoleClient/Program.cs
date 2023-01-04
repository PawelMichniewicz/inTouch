//using Azure;
using CommunicationWebApi.Models;
using ConsoleClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

internal class Program
{

    private static void Main(string[] args)
    {
        Application app = new Application();

        app.RunAsync().GetAwaiter().GetResult();
    }


}