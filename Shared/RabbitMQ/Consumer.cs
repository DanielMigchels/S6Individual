using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RabbitMQ
{
    public class Consumer
    {
        private const string UserName = "guest";
        private const string Password = "guest";
        private const string HostName = "192.168.99.100";

        public delegate void RabbitReceivedEvent(RabbitMqMessage message, string consumer);

        public event RabbitReceivedEvent RabbitReceived;

        private string _serviceName;

        public void Setup(string serviceName)
        {
            _serviceName = serviceName;

            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = HostName,
                UserName = UserName,
                Password = Password
            };

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(serviceName + ".exchange", ExchangeType.Direct);
            Console.WriteLine("Creating Exchange");

            channel.QueueDeclare(serviceName + ".queue", true, false, false, null);
            Console.WriteLine("Creating Queue");

            channel.QueueBind(serviceName + ".queue", serviceName + ".exchange", "key");

            channel.BasicQos(0, 1, false);
            MessageReceiver messageReceiver = new MessageReceiver(channel);
            messageReceiver.RabbitReceived += MessageReceiver_RabbitReceived;
            channel.BasicConsume(serviceName + ".queue", false, messageReceiver);
        }

        private void MessageReceiver_RabbitReceived(RabbitMqMessage message, string consumer)
        {
            OnRabbitReceived(message, consumer);
        }

        public void Send(string exchange, RabbitMqMessage message)
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

            message.Sender = _serviceName;

            string data = Newtonsoft.Json.JsonConvert.SerializeObject(message);

            byte[] messagebuffer = Encoding.Default.GetBytes(data);
            channel.BasicPublish(exchange, "key", properties, messagebuffer);
            Console.WriteLine("RabbitMq: Data Transmitted.");
        }

        private void OnRabbitReceived(RabbitMqMessage message, string consumer)
        {
            Console.WriteLine("RabbitMq: Data Received.");

            if (RabbitReceived != null)
            {
                RabbitReceived(message, consumer);
            }
        }
    }
}
