using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDistributionToMachines
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[,]
            {
                {8, 2, 9, 7},
                {9, 4, 3, 7},
                {5, 8, 1, 8},
                {7, 6, 9, 4}
            };

            var bestTime = int.MaxValue;
            var currentSolution = new int[arr.GetLength(0)];

            for (int i = currentSolution.Length - 1; i >= 0; i--)
            {
                currentSolution[i] = i;
            }

            var bestSolution = currentSolution
                .ToArray();

            do
            {
                var currentTime = 0;
                for (int i = 0; i < currentSolution.Length; i++)
                {
                    currentTime += arr[i, currentSolution[i]];
                }
                if (currentTime < bestTime)
                {
                    bestSolution = currentSolution
                        .ToArray();

                    bestTime = currentTime;
                }
            }
            while (Next(currentSolution));

            for (int i = 0; i < bestSolution.Length; i++)
            {
                Console.WriteLine((char)('A' + i) + ":" + (bestSolution[i] + 1));
            }
            Console.WriteLine("=" + bestTime);
            Console.ReadLine();
        }

        static bool Next(int[] vals)
        {
            int i = vals.Length - 1;
            while (i > 0 && vals[i - 1] >= vals[i])
                i--;

            if (i <= 0)
                return false;

            int j = vals.Length - 1;
            while (vals[j] <= vals[i - 1])
                j--;

            Swap(ref vals[i - 1], ref vals[j]);

            j = vals.Length - 1;
            
            while (i < j)
            {
                Swap(ref vals[i], ref vals[j]);
                i++;
                j--;
            }

            return true;
        }

        static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
