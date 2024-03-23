using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsAppLabaOS
{

     public class WorkerThread1
    {
        private Thread murThread;
        private bool running;

        public event EventHandler<string> Mur;

        public void Execute()
        {
            running = true;
            murThread = new Thread(FuncMyau);
            murThread.Start();
        }

        public void Stop()
        {
            running = false;
            murThread.Join();
        }

        private void FuncMyau()
        {
            while (running)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (!running)
                        break; 

                    Mur?.Invoke(this, "Mur" + i);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
