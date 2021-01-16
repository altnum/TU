using System;
using System.Collections.Generic;

namespace OptimalPath
{
    class Program
    {
        static void Main(string[] args)
        {
            n = distancesBBTSP.GetLength(0);
            used = new char[n];
            minCycle = new int[n];
            cycle = new int[n];

            int k;
            for (k = 0; k < n; k++)
            {
                used[k] = (char)0;
            }
            minSum = int.MaxValue;
            curSum = 0;
            cycle[0] = 1;
            HamiltonCycle(0, 0);
            printCycle();
            Console.ReadKey();

            /*
            distances.RemoveAll(e => e == -1);
            distances.RemoveAll(e => e == 0);
            Console.WriteLine(distances.Min());
            Console.ReadKey();
            */
        }

        static int n;
        static int curSum, minSum;
        static char[] used;
        static int[] minCycle;
        static int[] cycle;

        static void printCycle()
        {
            Console.Write("Минимален Хамилтонов цикъл: 0");
            for (int i = 0; i < n - 1; i++) Console.Write(" " + minCycle[i]);
            Console.WriteLine(" 0, дължина " + minSum);
        }


        private static void HamiltonCycle(int i, int level)
        {
            if ((0 == i) && (level > 0))
            {
                if (level == n)
                {
                    minSum = curSum;
                    for (int k = 0; k < n; k++)
                        minCycle[k] = cycle[k];
                }
                return;
            }

            if (used[i] == 1)
                return;

            used[i] = (char)1;

            for (int k = 0; k < n; k++)
                if (distancesBBTSP[i, k] != 0 && k != i)
                {
                    cycle[level] = k;
                    curSum += distancesBBTSP[i, k];
                    if (curSum < minSum)
                        HamiltonCycle(k, level + 1);
                    curSum -= distancesBBTSP[i, k];
                }

            used[i] = (char)0;
        }

        static int[,] distancesBBTSP = new int[,]
            {
                {0, 1000, 72, 56, 20, 20},
{1000, 0, 44, 87, 20, 20},
{72, 44, 0, 67, 20, 20},
{56, 87, 67, 0, 20, 20},
{56, 87, 67, 20, 0, 20},
{56, 87, 67, 20, 20, 0}
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
