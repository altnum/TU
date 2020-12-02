using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SubOptimal_Assignment
{
    class Program
    {
        public static int Knapsack(
            int[] w,
            int[] p,
            int item,
            int maxWeight,
            out string path)
        {
            path = "";
            if (item == 0)
                return 0;

            string exclPath;
            var excl = Knapsack(w, p, item - 1, maxWeight, out exclPath);

            if (maxWeight >= w[item - 1])
            {
                string inclPath;
                var incl = p[item - 1] + Knapsack(w, p, item - 1, maxWeight - w[item - 1], out inclPath);

                if (incl > excl)
                {
                    path = inclPath + "1";
                    return incl;
                }
            }

            path = exclPath + "0";                                                                                      
            return excl;
        }

        static int Evaluate(int[] w, int[] p, int maxWeight, int[] solution)
        {
            var result = 0;
            for (int i = 0; i < solution.Length; i++)
            {
                if (solution[i] == 1)
                {
                    maxWeight -= w[i];
                    if (maxWeight < 0)
                        return -1;
                    else
                        result += p[i];
                }
            }

            return result;
        }

        static int[] RandomSolution(Random r, int size)
        {
            var result = new int[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = r.Next(2);
            }

            return result;
        }

        static int[] NextSolution(int[] w, int[] p, int maxWeight, int[] solution)
        {
            var result = solution.ToArray();

            var bestIdx = -1;
            var bestVal = int.MinValue;

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Abs(result[i] - 1);
                var val = Evaluate(w, p, maxWeight, result);
                if(val > bestVal)
                {
                    bestVal = val;
                    bestIdx = i;
                }
                result[i] = Math.Abs(result[i] - 1);
            }

            result[bestIdx] = Math.Abs(result[bestIdx] - 1);
            return result;
        }

        static int[] HCSARR(Random r, int[] w, int[] p, int maxWeight, DateTime deadline)
        {
            var bestVal = int.MinValue;
            var bestSol = RandomSolution(r, w.Length);
            var currentVal = bestVal;
            var currentSol = bestSol;

            while (DateTime.Now < deadline)
            {
                var newSol = NextSolution(w, p, maxWeight, currentSol);
                var newVal = Evaluate(w, p, maxWeight, newSol);

                if (newVal > currentVal)
                {
                    currentSol = newSol;
                    currentVal = newVal;
                }
                else
                {
                    if (currentVal > bestVal)
                    {
                        bestVal = currentVal;
                        bestSol = currentSol;
                    }
                    currentSol = RandomSolution(r, w.Length);
                    currentVal = Evaluate(w, p, maxWeight, currentSol);
                }
            }

            return bestSol;
        }
        static void Main(string[] args)
        {
            var r = new Random();

            var n = 1;

            Console.WriteLine("Machines count: " + n);

            var m = 27;
            Console.WriteLine("Tasks count: " + m);

            var w = new int[m];
            var p = new int[m];
            
            for (int i = 0; i < m; i++)
            {
                w[i] = r.Next(10);
                p[i] = r.Next(10);

                Console.WriteLine("Task " + i + " time: " + w[i] + " price: " + p[i]);
            }

            var T = (int)(w.Sum() * 0.75);
            Console.WriteLine("Hiring time: " + T);

            var o = new Object();

            new Thread(() =>
            {
                string optimalSolutionPath;
                var optimalSolution = Knapsack(w, p, m, T, out optimalSolutionPath);

                lock (o)
                    Console.WriteLine("o solution: " + optimalSolutionPath + " = " + optimalSolution);
            }).Start();

            new Thread(() =>
            {
                var suboptimalSolution = HCSARR(r, w, p, T, DateTime.Now.AddSeconds(5));

                string suboptimalSolutionPath = "";

                for (int i = 0; i < suboptimalSolution.Length; i++)
                {
                    suboptimalSolutionPath += suboptimalSolution[i];
                }

                lock(o)
                    Console.WriteLine("s solution: " + suboptimalSolutionPath + " = " + Evaluate(w, p, T, suboptimalSolution));
            }).Start();

            Console.ReadLine();
        }
    }
}
