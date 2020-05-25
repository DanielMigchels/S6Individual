using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.RabbitMQ
{
    public class RabbitMqEventArgs : EventArgs
    {
        public RabbitMqEventArgs(RabbitMqMessage message)
        {
            this.Message = message;
        }

        public RabbitMqMessage Message;
    }
}
