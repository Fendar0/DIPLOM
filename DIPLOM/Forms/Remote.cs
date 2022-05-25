using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM
{
    public partial class Remote : Form
    {
        Thread thread;
        Thread thread2;
        Thread thread3;

        public Remote()
        {
            InitializeComponent();
            Thread.Sleep(3000);
            //thread3 = new Thread(view);
            //thread3.Start();
        }

        private void view()
        {
           // while(Program.Fun.exit)
           // {
                image_remote.Image = Program.image.returnImage;
           // }            
        }

        private void CloseRemoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Fun.close = true;
            Program.Fun.exit = false;
            thread.Abort();
            thread2.Abort();
           // thread3.Abort();
            Program.ping.Check = false;
            Close();                      
        }

        private void Remote_FormClosing(object sender, FormClosingEventArgs e)
        {            
            thread.Abort();
            thread2.Abort();
            Program.Fun.CloseCon();
            Program.ping.SendCheckFalse();            
            //thread3.Abort();
        }

        private void Remote_Load(object sender, EventArgs e)
        {
            thread = new Thread(Program.Fun.ReceiveMessage);            
            thread2 = new Thread(view);
            thread2.Start();
            thread.Start();
        }        
    }
}
