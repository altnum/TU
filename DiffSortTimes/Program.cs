using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffSortTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[1000];

            InitializeArr(nums);

            GeneratePartlySort(nums);

            var nums1 = nums.ToArray();
            var nums2 = nums.ToArray();

            var n = DateTime.Now;
            Console.WriteLine(n.Second + " " + n.Millisecond);
            BubbleSort(nums);
            n = DateTime.Now;
            Console.WriteLine(n.Second + " " + n.Millisecond);

            n = DateTime.Now;
            Console.WriteLine(n.Second + " " + n.Millisecond);
            SelectionSort(nums1);
            n = DateTime.Now;
            Console.WriteLine(n.Second + " " + n.Millisecond);

            n = DateTime.Now;
            Console.WriteLine(n.Second + " " + n.Millisecond);
            InsertionSort(nums2);
            n = DateTime.Now;
            Console.WriteLine(n.Second + " " + n.Millisecond);

            Console.Read();
        }

        private static void InitializeArr(int[] nums)
        {
            Random random = new Random();

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = random.Next(0, 100);
            }
        }

        public static void GeneratePartlySort(int[] nums)
        {
            Random random = new Random();

            int v = random.Next(0, 1000);

            if(v >= 200 && v < 500)
            {
                for (int i = 1; i < nums.Length / 3; i++)
                {
                    int k = i;
                    int value = nums[i];

                    while (k > 0 && nums[k - 1] > value)
                    {
                        nums[k] = nums[k - 1];
                        k--;
                    }

                    nums[k] = value;
                }
            }
            else if (v >= 500 && v < 750)
            {
                for (int i = 1; i < nums.Length / 2; i++)
                {
                    int k = i;
                    int value = nums[i];

                    while (k > 0 && nums[k - 1] > value)
                    {
                        nums[k] = nums[k - 1];
                        k--;
                    }

                    nums[k] = value;
                }
            } 
            else
            {
                for (int i = 1; i < 250; i++)
                {
                    int k = i;
                    int value = nums[i];

                    while (k > 0 && nums[k - 1] > value)
                    {
                        nums[k] = nums[k - 1];
                        k--;
                    }

                    nums[k] = value;
                }
                for (int i = 750; i < nums.Length; i++)
                {
                    int k = i;
                    int value = nums[i];

                    while (k > 0 && nums[k - 1] > value)
                    {
                        nums[k] = nums[k - 1];
                        k--;
                    }

                    nums[k] = value;
                }
            }

        }

        public static void BubbleSort(int[] vs)
        {
            for (int i = 0; i < vs.Length; i++)
            {
                int element = vs[i];
                for (int j = i + 1; j < vs.Length; j++)
                {
                    int element2 = vs[j];
                    if (element > element2)
                    {
                        int temp = element;
                        vs[i] = vs[j];
                        vs[j] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(int[] vs)
        {
            for (int i = 0; i < vs.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < vs.Length; j++)
                {
                    if (vs[minIndex] > vs[j])
                    {
                        var temp = vs[minIndex];
                        vs[minIndex] = vs[j];
                        vs[j] = temp;
                    }
                }
            }
        }

        private static void InsertionSort(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                int k = i;
                int value = nums[i];

                while (k > 0 && nums[k - 1] > value)
                {
                    nums[k] = nums[k - 1];
                    k--;
                }

                nums[k] = value;
            }
        }
    }
}
