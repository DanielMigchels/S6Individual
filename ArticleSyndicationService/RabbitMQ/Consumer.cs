using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSyndicationService.RabbitMQ
{
    public class Consumer
    {
        public static Consumer current;

        private const string UserName = "guest";
        private const string Password = "guest";
#if DEBUG
        private const string HostName = "127.0.0.1";
#else
        private const string HostName = "rabbitmq";
#endif
        public void Setup()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = HostName,
                UserName = UserName,
                Password = Password
            };

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare("articlesyndication.exchange", ExchangeType.Direct);
            Console.WriteLine("Creating Exchange");

            channel.QueueDeclare("articlesyndication.queue", true, false, false, null);
            Console.WriteLine("Creating Queue");

            channel.QueueBind("articlesyndication.queue", "articlesyndication.exchange", "key");

            channel.BasicQos(0, 1, false);
            MessageReceiver messageReceiver = new MessageReceiver(channel);
            channel.BasicConsume("articlesyndication.queue", false, messageReceiver);
        }

        public void Send(string exchange, string data)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = HostName,
                UserName = UserName,
                Password = Password
            };

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            var properties = channel.CreateBasicProperties();
            properties.Persistent = false;

            byte[] messagebuffer = Encoding.Default.GetBytes(data);
            channel.BasicPublish(exchange, "key", properties, messagebuffer);
            Console.WriteLine("Message Sent");
        }
    }
}
