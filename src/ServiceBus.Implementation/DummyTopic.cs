﻿using LaDanse.ServiceBus.Abstractions;
using Serilog;

namespace LaDanse.ServiceBus.Implementation
{
    public class DummyTopic : ITopic
    {
        private readonly ILogger _logger = Log.ForContext<DummyQueue>();

        public void SendMessage(string content)
        {
            _logger.Debug($"Received message '{content}' on topic.");
        }
    }
}