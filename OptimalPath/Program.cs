using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalPath
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = costs.GetLength(0);

            int k;
            for (k = 0; k < n; k++) used[k] = (char)0;
            minSum = int.MaxValue;
            curSum = 0;
            cycle[0] = 1;
            HamiltonCycle(0, 0);
            printCycle();

            /*
            distances.RemoveAll(e => e == -1);
            distances.RemoveAll(e => e == 0);
            Console.WriteLine(distances.Min());
            Console.ReadKey();
            */
        }

        static int curSum, minSum;
        static char[] used = new char[5];
        static int[] minCycle = new int[5];
        static int[] cycle = new int[5];

        static void printCycle()
        {
            int i;
            Console.Write("Минимален Хамилтонов цикъл: 0");
            for (i = 0; i < 4; i++) Console.Write(" " + minCycle[i]);
            Console.WriteLine(" 0, дължина " + minSum);
        }


        private static void HamiltonCycle(int i, int level)
        {
            int k;
            if ((0 == i) && (level > 0))
            {
                if (level == 5)
                {
                    minSum = curSum;
                    for (k = 0; k < 5; k++)
                        minCycle[k] = cycle[k];
                }
                return;
            }
            if (used[i] == '1')
                return;
            used[i] = (char)1;
            for (k = 0; k < 5; k++)
                if (costs[i, k] != 0 && k != i && level < 5)
                {
                    cycle[level] = k;
                    curSum += costs[i, k];
                    if (curSum < minSum)
                        HamiltonCycle(k, level + 1);
                    curSum -= costs[i, k];
                }
            used[i] = (char)0;

        }

        static int[,] costs = new int[,]
            {
                {0, 1, 3, 0, 6},
                {1, 0, 2, 0, 8},
                {3, 2, 0, 8, 2},
                {0, 1, 8, 0, 1},
                {3, 8, 2, 1, 0}
            };

        static int[] pred = new int[5];

        static void printPath(int s, int j)
        {
                if (pred[j] != s)
                    printPath(s, pred[j]);
            Console.Write(j);
        }

        static List<int> distances = new List<int>();
        static List<int> paths = new List<int>();

        private static void findBestPath(int[,] costs, int node, int toNode, ref int distance, List<int> path)
        {
            if (node == toNode)
            {
                for (int i = 0; i < costs.GetLength(0); i++)
                {
                    if (!path.Contains(toNode))
                    {
                        path.Add(toNode);
                        findBestPath(costs, node, toNode, ref distance, path);
                    }
                }
            }


            if (node == costs.GetLength(0) - 1 && toNode == costs.GetLength(1))
            {
                distance += costs[node, 0];
                distances.Add(distance);
                return;
            }

            if (toNode == costs.GetLength(1))
            {
                toNode = 0;
                findBestPath(costs, node + 1, toNode, ref distance, path);
            }

            distance += costs[node, toNode];
            path.Add(toNode);
            findBestPath(costs, toNode, toNode + 1, ref distance, path);
            if (path.Count != 0)
                path.RemoveAt(path.Count - 1);
            distance -= costs[node, toNode];

        }
    }
}
