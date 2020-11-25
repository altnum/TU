using System;
using System.Collections.Generic;
using System.Linq;

namespace Branch_And_Bound
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] table = new int [4, 4] {
                {9, 2, 7, 5},
                {10, 4, 3, 7},
                {5, 8, 1, 8},
                {7, 6, 9, 4}
            };

            Dictionary<int, string> map = new Dictionary<int, string>();
            map.Add(0, "A");
            map.Add(1, "B");
            map.Add(2, "C");
            map.Add(3, "D");

            int lowerTimeBound = 10 + 8 + 9 + 5;

            for (int i = 0; i < table.GetLength(1); i++)
            {
                List<int> visited = new List<int>();
                List<int> tasksTaken = new List<int>();
                
                int time = table[i, 0];
                tasksTaken.Add(0);
                TasksScheduleToMachines(table, i, visited, tasksTaken, time, ref lowerTimeBound);
            }

            Console.WriteLine("The best distribution of tasks between machines is the following: ");
            for (int i = 0; i < machines.Length; i++)
            {
                Console.WriteLine("Machine " + map[machines[i]] + " -> task " + (i + 1));
            }

            Console.ReadKey();
        }

        public static int[] machines = new int[4];

        private static void TasksScheduleToMachines(int[,] table, int machine, List<int> visited, List<int> tasksTaken, int time, ref int lowerTimeBound)
        {
            visited.Add(machine);

            if (visited.Count == table.GetLength(0) && lowerTimeBound > time)
            {
                lowerTimeBound = time;
                machines = visited.ToArray();
                return;
            }
            else
            {
                for (int newMachine = 0; newMachine < table.GetLength(0); newMachine++)
                {
                    for (int newTask = 0; newTask < table.GetLength(1); newTask++)
                    {
                        if (!visited.Contains(newMachine) && !tasksTaken.Contains(newTask))
                        {
                            if (lowerTimeBound < time + table[newMachine, newTask])
                                continue;

                            tasksTaken.Add(newTask);
                            TasksScheduleToMachines(table, newMachine, visited, tasksTaken, time + table[newMachine, newTask], ref lowerTimeBound);
                            visited.RemoveAt(visited.Count() - 1);
                            tasksTaken.RemoveAt(tasksTaken.Count() - 1);
                        }
                    }
                }
            }
        }
    }
}
