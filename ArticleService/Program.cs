using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArticleService.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared.RabbitMQ;

namespace ArticleService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Creates the database if not exists");
            ArticleServiceContext.current = new ArticleServiceContext();
            ArticleServiceContext.current.Database.EnsureCreated();

            MessageService messageService = new MessageService();
            messageService.Run();

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
