using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
namespace OSLab22
{
    class Sem
    {
        static void Main(string[] args)
        {

                 int seconds;
                int threadCount = 5;
                Console.WriteLine("Будет создано {0} потоков", threadCount);          
                MonteCarl[] calculators = new MonteCarl[threadCount];

                for (int i = 1; i <= threadCount; i++)
                {
                    Console.Write("Введите время выполнения {0} потока: ", i);
                    seconds = Convert.ToInt32(Console.ReadLine());
                    calculators[i - 1] = new MonteCarl(i, seconds);
                }
                foreach (MonteCarl calc in calculators)
                {
                    calc.Start();
                }                
                Console.ReadKey(true);
            }
        }


    class MonteCarl
    {

        public static Semaphore sem = new Semaphore(3, 3);
        Thread thread;
        int seconds;
        int ID;
        bool stopThread;


        public MonteCarl(int i, int seconds)
        {
            this.stopThread = false;
            this.ID = i;
            this.seconds = seconds;
            thread = new Thread(Integral);
            thread.Name = "Поток №" + i.ToString();
            Console.WriteLine("{0} создан и будет выполнятся {1} секунд", thread.Name, seconds);
        }

        public void Start()
        {
            thread.Start(100000);
        }
        public void Integral(object num_p)
        {
            sem.WaitOne();

            Timer timer = new Timer(new TimerCallback(Timeouter), null, this.seconds * 1000, Timeout.Infinite);

            Console.WriteLine("{0} начал выполнение", thread.Name);

            using (FileStream fstream = new FileStream(this.ID.ToString() + ".txt", FileMode.OpenOrCreate))
            {
                int n_point = (int)num_p;
                double s = 0;
                double x, integral;
                Random rand = new Random();
                int r = rand.Next();
                int  i;
                int a = 0;
                int b = 6;
                while (!this.stopThread)
                {
                    for (i = 1; i <= n_point; i++)
                    {
                        x = a + (b - a) * r / (1.0 * r);
                        s = s + x * x;
                    }
                

                integral = 9 - Math.Sqrt(s - 3);

                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(integral.ToString() + "\n");
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }

            Console.WriteLine("{0} завершил выполнение", thread.Name);
        }

        sem.Release();
        }

        private void Timeouter(object objec)
        {
            this.stopThread = true;
        }
    }
}
