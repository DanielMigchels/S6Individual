﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleSyndicationService.RabbitMQ
{
    public class RabbitMqMessage
    {
        public string Action { get; set; }

        public object Data { get; set; }
    }
}
