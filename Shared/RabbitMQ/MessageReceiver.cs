using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Shared.RabbitMQ
{
    public class MessageReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;

        public delegate void RabbitReceivedEvent(RabbitMqMessage message, string consumer);

        public event RabbitReceivedEvent RabbitReceived;

        public MessageReceiver(IModel channel)
        {
            _channel = channel;
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            try
            {
                string message = Encoding.UTF8.GetString(body);

                RabbitMqMessage messageobject = Newtonsoft.Json.JsonConvert.DeserializeObject<RabbitMqMessage>(message);

                OnRabbitReceived(messageobject, messageobject.Sender);
            }
            catch(Exception e)
            {
                Console.WriteLine("RabbitMQ: " + e.Message);
            }
            

            _channel.BasicAck(deliveryTag, false);
        }

        private void OnRabbitReceived(RabbitMqMessage message, string consumer)
        {
            if (RabbitReceived != null)
            {
                RabbitReceived(message, consumer);
            }
        }
    }
}
