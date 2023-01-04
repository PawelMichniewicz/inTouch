using CommunicationWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    internal class Application
    {
        private readonly HttpClient WebApi = new();
        private User? userProfile;

        private const string defaultLogin = "Joey Tribbiani";

        public Application()
        {
            InitHttpClient();
        }

        internal async Task RunAsync()
        {
            Console.WriteLine("Let's stay inTouch!");
            Console.WriteLine("Provide login");
            string? login = Console.ReadLine();

            if (login == null || login == string.Empty)
            {
                login = defaultLogin;
            }

            var loginResult = await SignInAsync(login);
            if (!loginResult)
            {
                Console.WriteLine("Login Failed! Exiting!");
                return;
            }

            Console.WriteLine($"Hi There {userProfile?.Name}!");
        }

        private void InitHttpClient()
        {
            WebApi.BaseAddress = new Uri("https://localhost:7269");
            WebApi.DefaultRequestHeaders.Accept.Clear();
            WebApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<bool> SignInAsync(string user)
        {
            bool result = false;
            HttpResponseMessage response = await WebApi.GetAsync($"api/User/{user}");
            if (response.IsSuccessStatusCode)
            {
                userProfile = await response.Content.ReadFromJsonAsync<User>() ?? new();
                result = true;
            }
            return result;
        }
    }
}
