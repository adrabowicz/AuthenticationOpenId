﻿using System;
using Microsoft.Owin.Hosting;
using Serilog;
using Configuration;

namespace ServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // logging
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .LiterateConsole(outputTemplate: "{Timestamp:HH:mm} [{Level}] ({Name:l}){NewLine} {Message}{NewLine}{Exception}")
                .CreateLogger();

            // hosting identityserver
            using (WebApp.Start<Startup>(Config.IdentityServerBaseIP))
            {
                Console.WriteLine("server running...");
                Console.ReadLine();
            }
        }
    }
}
