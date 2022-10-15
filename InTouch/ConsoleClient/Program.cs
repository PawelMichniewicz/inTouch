using ConsoleClient;
using System;

// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to inTouch communicator");
Console.WriteLine("Provide your LOGIN:");

User u = new();

u.Login = Console.ReadLine()?.ToLower();

Console.WriteLine("Provide your Password:");

u.Password = Console.ReadLine()?.ToLower();

Console.WriteLine($"You are now logged in as {u.Login} with password {u.Password}");