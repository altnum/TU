using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CarMakerProblem
{
    class CarMakerProblem
    {
        const int CAPACITY = 2;
        static Random random = new Random();
        static int waiting = 0;
        static Queue<int> wRoom = new Queue<int>(CAPACITY); //чакалня
        static Semaphore exclude = new Semaphore(1, 1);
        static Semaphore emptyService = new Semaphore(0, 1);
        static Semaphore fullWaitingRoom = new Semaphore(0, CAPACITY);
        static Semaphore ready = new Semaphore(1, 1);


        public static void CarMaker()
        {
            while (true)
            {
                Thread.Sleep(random.Next(1000, 2000));
                ready.WaitOne();


                if (wRoom.Count() <= 0)
                {
                    //1
                    Console.WriteLine("CarMaker waiting..");
                }
                else
                {
                    //3
                    Console.WriteLine("  CarMaker working...");
                    Thread.Sleep(random.Next(1000, 2000));
                    Console.WriteLine("  CarMaker done.");
                    //Client done
                    exclude.WaitOne();

                    waiting = wRoom.Dequeue();

                    try
                    {
                        fullWaitingRoom.Release();
                    }
                    catch { }

                    exclude.Release();
                    
                    emptyService.Release();
                }
            }
        }

        public static void Client(Object o)
        {
            var n = (int)o;

            while (true)
            {
                Thread.Sleep(random.Next(1000, 2000));

                if (wRoom.Count() < CAPACITY)
                {
                    exclude.WaitOne();
                    //2
                    Console.WriteLine("  Client " + n + " waiting...");
                    wRoom.Enqueue(n);
                    try
                    {
                        ready.Release();
                    }
                    catch { }
                    exclude.Release();

                    if (wRoom.Count() > 0)
                        waiting = wRoom.Peek();

                    //CarMaker works
                    emptyService.WaitOne();

                    //4
                    Console.WriteLine("  Client " + waiting + " served.");

                    if (wRoom.Count() > 0)
                        waiting = wRoom.Peek();

                }
                else
                {
                    Console.WriteLine("  Client " + n + " no space.");
                    fullWaitingRoom.WaitOne();
                }                
            }
        }
    }
}
