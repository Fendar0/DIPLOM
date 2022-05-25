using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DIPLOM
{
    public partial class Menu : Form
    {
        System.Timers.Timer timer;
        System.Timers.Timer timer2;
        Thread thread;
        Thread thread2;

        public Menu()
        {
            InitializeComponent();

            getID();
            Program.ping.MyID = tb_my_id.Text;
            Program.Fun.MyID = tb_my_id.Text;

            timer = new System.Timers.Timer(2000);
            timer2 = new System.Timers.Timer(5000);
            timer.Elapsed += HandleTimerElapsed;
            timer2.Elapsed += HandleTimerElapsed2;
            timer.Start();
            timer2.Start();
        }

        private void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (Program.ping.Check)
            {
                timer2.Stop();
                timer.Stop();
                Program.ping.Check = false;
                Program.Fun.exti2 = true;
                thread = new Thread(Program.Fun.SendMessage);
                thread2 = new Thread(Program.image.sendByteArray);
                thread2.Start();
                thread.Start();
            }
            else
            {
                timer2.Start();
                var factory = new ConnectionFactory()
                {
                    HostName = "194.87.68.95",
                    UserName = "diplom",
                    Password = "diplom",
                };

                using (var connection = factory.CreateConnection())

                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: tb_my_id.Text,
                                                                    durable: false,
                                                                    exclusive: false,
                                                                    autoDelete: false,
                                                                    arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        try
                        {
                            Program.ping.Check = Convert.ToBoolean(message);
                            connection.Close();
                        }
                        catch { }
                    };
                    channel.BasicConsume(queue: tb_my_id.Text,
                    autoAck: false,
                    consumer: consumer);
                }
                
            }
        }

        private void HandleTimerElapsed2(object sender, ElapsedEventArgs e)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "194.87.68.95",
                UserName = "diplom",
                Password = "diplom",
            };

            using (var connection = factory.CreateConnection())
            
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Check",
                                                        durable: false,
                                                        exclusive: false,
                                                        autoDelete: false,
                                                        arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    try
                    {
                        Program.ping.closeSessions = Convert.ToBoolean(message);
                        if (!Program.ping.closeSessions)
                        {
                            thread2.Abort();
                            thread.Abort();
                            Program.Fun.exti2 = false;
                        }
                    }
                    catch { }
                };
                channel.BasicConsume(queue: "Check",
                autoAck: true,
                consumer: consumer);
            }                               
            
        }

        private void getID()
        {
            ManagementObjectCollection mbsList = null;
            var mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorID"].ToString();
            }
            tb_my_id.Text = id;
        }

        private async void bt_connect_Click(object sender, EventArgs e)
        {
            Program.ping.SenderID = tb_id.Text;
            Program.Fun.SenderID = tb_id.Text;
            Program.Fun.exit = true;
            Program.ping.SendCheck();

            /*var j = await Task.Run(() =>
            {
                while (!Program.ping.Check)
                {

                }
                return true;
            });*/

            timer.Stop();
            var rem = new Remote();
            Hide();
            rem.ShowDialog();
            Show();
            Program.ping.Check = false;
            timer.Start();
            timer2.Start();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.ping.Delete();
            Program.ping.DeleteCheck();
            thread2.Abort();
            thread.Abort();

        }
    }
}
