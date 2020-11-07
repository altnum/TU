using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lunch_students
{
    public class Program
    {
        public static Thread[] studentThreads = new Thread[5];
        public static ThreadParams[] studentParams = new ThreadParams[5];
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                studentThreads[i] = new Thread(StudentProblem.Student);
                //studentParams[i].Next = studentParams[i];
                //studentParams[i].Prev = studentParams[i];
                //studentParams[i].Eating = false;
                studentParams[i] = new ThreadParams(i, false);

                studentThreads[i].Start(studentParams[i]);
            }
        }
    }
}
