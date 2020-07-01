using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using My.NetCore.Framework.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My.NetCore.Framework.RabbitMQ
{
    public class RabbitListener : IHostedService
    {
        private readonly IConnection connection;
        private readonly IModel channel;

        public RabbitListener(IOptions<AppSettingOption> option)
        {
            if(option == null)
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
                this.connection = factory.CreateConnection();
                this.channel = connection.CreateModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RabbitListener init error,ex:{ex.Message}");
            }
        }

        protected string RouteKey;
        protected string QueueName;

        // 注册消费者监听在这里
        public void Register()
        {
            Console.WriteLine($"RabbitListener register,routeKey:{RouteKey}");
            channel.ExchangeDeclare(exchange: "message", type: "topic");
            channel.QueueDeclare(queue: QueueName, exclusive: false);
            channel.QueueBind(queue: QueueName, exchange: "message", routingKey: RouteKey);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var result = Process(message);
                if (result)
                {
                    channel.BasicAck(ea.DeliveryTag, false);
                }
            };

            channel.BasicConsume(queue: QueueName, consumer: consumer);
        }

        public void DeRegister()
        {
            this.connection.Close();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Register();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.connection.Close();
            return Task.CompletedTask;
        }

        // 处理消息的方法
        public virtual bool Process(string message)
        {
            throw new NotImplementedException();
        }
    }
}
