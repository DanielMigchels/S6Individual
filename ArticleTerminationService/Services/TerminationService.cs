using Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Shared.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArticleTerminationService.Services
{
    public class TerminationService
    {
        Consumer consumer;

        public void Run()
        {
            System.Threading.Thread.Sleep(5000);

            Console.WriteLine("TerminationService Thread Startup");

            Console.WriteLine("Initialize RabbitMQ");
            consumer = new Consumer();
            consumer.RabbitReceived += Consumer_RabbitReceived;
            consumer.Setup("ArticleTermination");

            RequestArticles();
        }

        public void RequestArticles()
        {
            Console.WriteLine("Requesting Articles");
            RabbitMqMessage message = new RabbitMqMessage()
            {
                Action = RabbitMqAction.GetAll
            };

            consumer.Send("Article.exchange", message);
        }

        private void Consumer_RabbitReceived(RabbitMqMessage message, string consumer)
        {
            try
            {
                switch (message.Action)
                {
                    case RabbitMqAction.Data:

                        Console.WriteLine("Articles Received");

                        HandleArticles(message.Data);

                        break;
                    default:
                        Console.WriteLine("Unknown RabbitMQ Message.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Consumer_RabbitReceived: " + e.Message);
            }
        }

        private async void HandleArticles(object ArticlesObject)
        {
            List<Article> articles = JsonConvert.DeserializeObject<List<Article>>(ArticlesObject.ToString());

            Console.WriteLine("Articles received: Count(" + articles.Count() + ")");

            int count = 0;
            foreach (Article article in articles)
            {
                count++;
                Console.Write("Testing " + count + "/" + articles.Count() + " - " + article.URI);

                try
                {
                    HttpClient client = new HttpClient();
                    var checkingResponse = await client.GetAsync(article.URI);
                    if (!checkingResponse.IsSuccessStatusCode)
                    {
                        Console.Write("   DOWN");
                        DeleteArticle(article);
                        Console.Write("   DELETE MESSAGE SENT");
                    }
                    Console.WriteLine("   UP");
                }
                catch
                {
                    Console.Write("   CRASH");
                    DeleteArticle(article);
                    Console.Write("   DELETE MESSAGE SENT");
                }
            }

            Console.WriteLine("Article check finished. 10s Delay...");
            Thread.Sleep(10000);
            RequestArticles();
        }

        private void DeleteArticle(Article article)
        {
            RabbitMqMessage message = new RabbitMqMessage()
            {
                Action = RabbitMqAction.Delete,
                Data = article
            };

            consumer.Send("Article.exchange", message);

            message = new RabbitMqMessage()
            {
                Action = RabbitMqAction.Delete,
                Data = article.Id
            };

            consumer.Send("Vote.exchange", message);
        }
    }
}
