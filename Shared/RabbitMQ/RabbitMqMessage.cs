using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.RabbitMQ
{
    public class RabbitMqMessage
    {
        public RabbitMqAction Action { get; set; }

        public object Data { get; set; }

        public string Sender { get; set; }
    }
}
