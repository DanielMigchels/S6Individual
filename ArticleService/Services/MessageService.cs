using ArticleService.Repositories;
using Models;
using Newtonsoft.Json;
using Shared.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleService.Services
{
    public class MessageService
    {
        ArticleRepository articleRepository;
        Consumer consumer;

        public void Run()
        {
            articleRepository = new ArticleRepository();

            Console.WriteLine("TerminationService Thread Startup");

            Console.WriteLine("Initialize RabbitMQ");
            consumer = new Consumer();
            consumer.RabbitReceived += Consumer_RabbitReceived;
            consumer.Setup("Article");

        }

        private void Consumer_RabbitReceived(RabbitMqMessage message, string consumer)
        {
            switch (message.Action)
            {
                case RabbitMqAction.GetAll:

                    RabbitMqMessage getall = new RabbitMqMessage()
                    {
                        Action = RabbitMqAction.Data,
                        Data = articleRepository.Get()
                    };

                    this.consumer.Send(message.Sender + ".exchange", getall);
                    Console.WriteLine("RabbitMQ: Articles Returned.");
                    break;
                case RabbitMqAction.Delete:
                    Article article = JsonConvert.DeserializeObject<Article>(message.Data.ToString());
                    articleRepository.Delete(article.Id);
                    Console.WriteLine("RabbitMQ: Article Deleted.");
                    break;
                default:
                    Console.WriteLine("Unknown RabbitMQ Message.");
                    break;
            }
        }
    }
}
