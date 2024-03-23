using System;
using System.Threading;

namespace WindowsFormsAppLabaOS
{
    public class WorkerThread
    {
        private Thread myauThread;
        private bool running;
        public event EventHandler<string> Myau;

        public void Execute()
        {
            running = true;
            myauThread = new Thread(FuncMyau);
            myauThread.Start();
        }

        public void Stop()
        {
            running = false;
            myauThread.Join(); 
        }


        private void FuncMyau()
        {
            while (running)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (!running)
                        break;

                    Myau?.Invoke(this, "Мяу" + i);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}