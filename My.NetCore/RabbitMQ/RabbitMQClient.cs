using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;
using My.NetCore.Options;

namespace My.NetCore.RabbitMQ
{
    public class RabbitMQClient
    {
        private readonly IModel _channel;
        private readonly ILogger _logger;

        public RabbitMQClient(IOptions<AppSettingOption> option, ILogger<RabbitMQClient> logger)
        {
            if (option == null)
                throw new ArgumentNullException(nameof(option));
            if (option.Value.RabbitMQ == null)
                throw new ArgumentNullException(nameof(option.Value.RabbitMQ));
            if (string.IsNullOrEmpty(option.Value.RabbitMQ.Host) || option.Value.RabbitMQ.Port == 0)
                throw new ArgumentNullException(nameof(option.Value.RabbitMQ.Host));
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = option.Value.RabbitMQ.Host,
                    Port = option.Value.RabbitMQ.Port,
                    UserName = option.Value.RabbitMQ.UserName,
                    Password = option.Value.RabbitMQ.Password,
                };
                var connection = factory.CreateConnection();
                _channel = connection.CreateModel();
            }
            catch (Exception ex)
            {
                logger.LogError(-1, ex, "RabbitMQClient init fail", "", "", "");
            }
            _logger = logger;
        }

        public virtual void PushMessage(string routingKey, object message)
        {
            _logger.LogInformation($"PushMessage,routingKey:{routingKey}");
            _channel.QueueDeclare(queue: "message",durable: false,exclusive: false,autoDelete: false,arguments: null);
            string msgJson = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(msgJson);
            _channel.BasicPublish(exchange: "message",routingKey: routingKey, basicProperties: null,body: body);
        }
    }
}
