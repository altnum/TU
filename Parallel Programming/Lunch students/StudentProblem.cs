using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lunch_students
{
    public class ThreadParams
    {
        public ThreadParams(int name, bool eating)
        {
            this.Name = name;
            this.Eating = eating;

            if (this.Name == 4)
            {
                this.Next = -1;
            } 
            else
            {
                this.Next = this.Name + 1;
            }
            var length = Program.studentParams.Length;


            if (this.Name == 0)
            {
                this.Prev = -1;
            }
            else
            {
                this.Prev = this.Name - 1;
            }
            
        }
        public int Name { get; set; }
        
        public int Next
        {
            get; set;
        }
        public int Prev
        {
            get; set;
        }
        public bool Eating { get; set; }
    }
    public class StudentProblem
    {
        static Semaphore neighboursEating = new Semaphore(0, 1);
        static HashSet<int> threadsLearning = new System.Collections.Generic.HashSet<int>();
        static Semaphore toStartLearning = new Semaphore(0, 1);

        public static void Student(Object o)
        {
            var r = new Random();
            var thread = (ThreadParams)o;

            while (true)
            {
                if (!threadsLearning.Contains(thread.Name))
                {
                    Console.WriteLine(" Student " + thread.Name + " start learning.");
                    threadsLearning.Add(thread.Name);
                }

                try
                {
                    toStartLearning.Release();
                    neighboursEating.Release();
                } 
                catch
                {

                }

                Thread.Sleep(r.Next(2000, 3000));

                //проверка за свободни вилици (съседите преди и след него)
                //?
                //почва да яде
                //:
                //чака освобождаване на съсед (+1/-1)

                int next = thread.Next;
                if (next == -1)
                    next = 0;

                int prev = thread.Prev;
                if (prev == -1)
                    prev = Program.studentParams.Length - 1;

                ThreadParams nextThread = Program.studentParams[next];
                ThreadParams prevThread = Program.studentParams[prev];

                if (nextThread.Eating || prevThread.Eating)
                {
                    neighboursEating.WaitOne();
                } 
                else
                {
                    threadsLearning.Remove(thread.Name);
                    thread.Eating = true;
                    for (int i = 0; i < thread.Name; i++)
                        Console.Write("_");
                    Console.WriteLine("> Student " + thread.Name + " start eating.");

                    Thread.Sleep(r.Next(2000, 3000));

                    for (int i = 0; i < thread.Name; i++)
                        Console.Write("_");
                    Console.WriteLine("< Student " + thread.Name + " stop eating.");
                    thread.Eating = false;
                    toStartLearning.WaitOne();
                }
            }
        }
    }
}
