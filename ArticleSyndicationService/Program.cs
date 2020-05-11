using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared.RabbitMQ;

namespace ArticleSyndicationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Initialize RabbitMQ");
            //Consumer.current = new Consumer();
            //Consumer.current.Setup("ArticleSyndication");

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
