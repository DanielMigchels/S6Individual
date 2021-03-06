using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared.RabbitMQ;

namespace SiteService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Creates the database if not exists");
            SiteServiceContext.current = new SiteServiceContext();
            SiteServiceContext.current.Database.EnsureCreated();

            Console.WriteLine("Initialize RabbitMQ");
            Consumer consumer = new Consumer();
            consumer.Setup("Site");
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
