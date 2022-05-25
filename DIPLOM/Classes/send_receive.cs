using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DIPLOM
{
    internal class Function
    {
        public string MyID;
        public string SenderID;
        public bool close;
        public bool exit = true;
        public bool exti2 = true;

        public void ReceiveMessage()
        {
            while (exit)
            {
                Thread.Sleep(1000);
                var factory = new ConnectionFactory()
                {
                    HostName = "194.87.68.95",
                    UserName = "admin",
                    Password = "admin",
                };
                try
                {
                    using (var connection = factory.CreateConnection())
                    using (var channel = connection.CreateModel())
                    {
                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;
                            Program.image.byteArrayToImage(body.ToArray());
                            if (close)
                                channel.Close();
                        };
                        channel.BasicConsume(queue: SenderID,
                                             autoAck: true,
                                             consumer: consumer);
                    }
                }
                catch { }
            }
        }

        public void SendMessage()
        {
            while (exti2)
            {
                Thread.Sleep(1);
                var factory = new ConnectionFactory()
                {
                    HostName = "194.87.68.95",
                    UserName = "diplom",
                    Password = "diplom",
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {

                    channel.QueueDeclare(queue: MyID,
                                                    durable: false,
                                                    exclusive: false,
                                                    autoDelete: false,
                                                    arguments: null);

                    byte[] message = Program.image.buffer;
                    var body = message;

                    if (!Program.ping.closeSessions)
                        channel.Close();

                    channel.BasicPublish(exchange: "",
                                         routingKey: MyID,
                                         basicProperties: null,
                                         body: body);
                }

            }
        }

        public void CloseCon()
        {
            Program.Fun.close = true;
            Program.Fun.exit = false;
            Program.ping.Check = false;

            var factory = new ConnectionFactory()
            {
                HostName = "194.87.68.95",
                UserName = "diplom",
                Password = "diplom",
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.Close();
        }
    }
}
