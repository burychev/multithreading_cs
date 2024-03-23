using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsAppLabaOS
{
    public partial class Form1 : Form
    {
        private WorkerThread worker = new WorkerThread();
        private WorkerThread1 worker1 = new WorkerThread1();

        public Form1()
        {
            InitializeComponent();
            worker.Myau += MyauHandler;
            worker1.Mur += MurHandler;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            worker.Execute();
            worker1.Execute();
        }

        private void MyauHandler(object sender, string e)
        {
            if (listBox2.InvokeRequired)
            {
                listBox2.Invoke(new Action(() => listBox2.Items.Add(e)));
            }
            else
            {
                listBox2.Items.Add(e);
            }
        }

        private void MurHandler(object sender, string e)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action(() => listBox1.Items.Add(e)));
            }
            else
            {
                listBox1.Items.Add(e);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StopWorkerThread1()
        {
            Thread stopThread = new Thread(() =>
            {
                worker1.Stop();
            });
            stopThread.Start();
        }

        private void StopWorkerThread()
        {
            Thread stopThread = new Thread(() =>
            {
                worker.Stop();
            });
            stopThread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            worker.Execute();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StopWorkerThread();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            worker1.Execute();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StopWorkerThread1();
        }
    }
}