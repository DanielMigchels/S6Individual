using Models;
using Shared.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteService.Repositories;

namespace VoteService.Services
{
    public class MessageService
    {
        VoteRepository voteRepository;

        Consumer consumer;

        public void Run()
        {
            voteRepository = new VoteRepository();

            Console.WriteLine("TerminationService Thread Startup");

            Console.WriteLine("Initialize RabbitMQ");
            Consumer consumer = new Consumer();
            consumer.Setup("Vote");

        }

        private void Consumer_RabbitReceived(RabbitMqMessage message, string consumer)
        {
            switch (message.Action)
            {
                case RabbitMqAction.Delete:
                    int articleId = int.Parse(message.Data.ToString());
                    IEnumerable<Vote> votes = voteRepository.GetArticle(articleId);

                    foreach (Vote vote in votes)
                    {
                        voteRepository.Delete(vote.Id);
                    }

                    Console.WriteLine("RabbitMQ: " + votes.Count() + " votes Deleted.");
                    break;
                default:
                    Console.WriteLine("Unknown RabbitMQ Message.");
                    break;
            }
        }
    }
}
