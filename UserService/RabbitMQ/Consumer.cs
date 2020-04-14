using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.RabbitMQ
{
    public class Consumer
    {
        private const string UserName = "userservice";
        private const string Password = "userservice321";
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

            // accept only one unack-ed message at a time
            // uint prefetchSize, ushort prefetchCount, bool global

            channel.BasicQos(0, 1, false);
            MessageReceiver messageReceiver = new MessageReceiver(channel);
            channel.BasicConsume("user.queue", false, messageReceiver);
        }
    }
}
