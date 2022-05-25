using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DIPLOM
{
    internal class Ping
    {
        public string MyID;
        public string SenderID;
        public bool Check;
        public bool closeSessions = true;

        public void SendCheck()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "194.87.68.95",
                UserName = "diplom",
                Password = "diplom",
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            
                string message = "true";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: SenderID,
                                     basicProperties: null,
                                     body: body);
                                                                      
        }

        public void Delete()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "194.87.68.95",
                UserName = "diplom",
                Password = "diplom",
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDelete(queue: MyID,
                                 false,
                                 false);            
        }

        public void SendCheckFalse()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "194.87.68.95",
                UserName = "diplom",
                Password = "diplom",
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            
                channel.QueueDeclare(queue: "Check",
                                                    durable: false,
                                                    exclusive: false,
                                                    autoDelete: false,
                                                    arguments: null);

                string message = "false";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "Check",
                                     basicProperties: null,
                                     body: body);
            
        }

        public void DeleteCheck()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "194.87.68.95",
                UserName = "diplom",
                Password = "diplom",
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDelete(queue: "Check",
                                 false,
                                 false);
        }

    }
}
