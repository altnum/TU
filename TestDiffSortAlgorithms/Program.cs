using System;

namespace TestDiffSortAlgorithms
{
    class Program
    {
        public static Random random = new Random();
        static void Main(string[] args)
        {
            int[] nums = new int[10000];
            var num1 = nums;
            var num2 = nums;
            var num3 = nums;
            var num4 = nums;
            var num5 = nums;


            Initializer(nums);

            DateTime now = new DateTime();

            now = DateTime.Now;
            Console.WriteLine(now.Second + " " + now.Millisecond);
            InsertionSort(nums);
            now = DateTime.Now;
            Console.WriteLine(now.Second + " " + now.Millisecond);

            now = DateTime.Now;
            Console.WriteLine(now.Second + " " + now.Millisecond);
            SelectionSort(num1);
            now = DateTime.Now;
            Console.WriteLine(now.Second + " " + now.Millisecond);

            now = DateTime.Now;
            Console.WriteLine(now.Second + " " + now.Millisecond);
            BubbleSort(num2);
            now = DateTime.Now;
            Console.WriteLine(now.Second + " " + now.Millisecond);

            now = DateTime.Now;
            Console.WriteLine(now.Second + " " + now.Millisecond);
            QuickSort(num3, 0, num3.Length - 1);
            now = DateTime.Now;
            Console.WriteLine(now.Second + " " + now.Millisecond);

            now = DateTime.Now;
            Console.WriteLine(now.Second + " " + now.Millisecond);
            MergeSort(num4, 0, num4.Length - 1);
            now = DateTime.Now;
            Console.WriteLine(now.Second + " " + now.Millisecond);
            //
            /*
            var num5 = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                Insert(num5, i, nums[i]);
            } 
            */
            now = DateTime.Now;
            Console.WriteLine(now.Second + " " + now.Millisecond);
            HeapSort(num5);
            var temp = num5[0];
            num5[0] = num5[num5.Length - 1];
            num5[num5.Length - 1] = temp;
            now = DateTime.Now;
            Console.WriteLine(now.Second + " " + now.Millisecond);

            Console.ReadLine();

        }

        private static void HeapSort(int[] num4)
        {
            var root = num4[0];
            var lastElement = num4[num4.Length - 1];

            num4[0] = lastElement;
            DeleteRestore(num4, num4.Length, 0);
            num4[num4.Length - 1] = root;
        }

        private static void DeleteRestore(int[] num4, int n, int i)
        {
            var largest = i;
            var l = 2 * i + 1;
            var r = 2 * i + 2;

            if (l < n && num4[l] > num4[largest])
                largest = l;

            if (r < n && num4[r] > num4[largest])
                largest = r;

            if (largest != i)
            {
                var temp = num4[i];
                num4[i] = num4[largest];
                num4[largest] = temp;

                DeleteRestore(num4, n, largest);
            }
        }

        private static void MergeSort(int[] nums, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                MergeSort(nums, l, m);
                MergeSort(nums, m + 1, r);

                Merge(nums, l, m, r);
            }
        }

        private static void Merge(int[] nums, int l, int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;

            var L = new int[n1];
            for (i = 0; i < n1; i++)
                L[i] = nums[l + i];

            var R = new int[n2];
            for (j = 0; j < n2; j++)
                R[j] = nums[m + 1 + j];

            i = j = 0;
            k = l;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                    nums[k] = L[i++];
                else
                    nums[k] = R[j++];
                k++;
            }

            while (i < n1)
                nums[k++] = L[i++];

            while (j < n2)
                nums[k++] = R[j++];
        }

        private static void QuickSort(int[] nums, int l, int r)
        {
            if (l < r)
            {
                int pivot = Partition(nums, l, r);

                if (pivot > 1)
                {
                    QuickSort(nums, l, pivot - 1);
                }
                if (pivot + 1 < r)
                {
                    QuickSort(nums, pivot + 1, r);
                }
            }
        }

        private static int Partition(int[] nums, int l, int r)
        {
            int temp;
            int pivotIndex = l++;

            while (true)
            {
                while (nums[l] < nums[pivotIndex])
                    l++;

                while (nums[r] > nums[pivotIndex])
                    r--;

                if (l >= r)
                    break;

                if (nums[l] == nums[r])
                {
                    l++;
                    r--;
                }
                else
                {
                    temp = nums[l];
                    nums[l] = nums[r];
                    nums[r] = temp;
                }
            }

            temp = nums[r];
            nums[r] = nums[pivotIndex];
            nums[pivotIndex] = temp;

            return r;
        }

        private static void BubbleSort(int[] nums)
        {
            bool sorted = false;

            do
            {
                sorted = true;
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] < nums[i - 1])
                    {
                        sorted = false;
                        var temp = nums[i];
                        nums[i] = nums[i - 1];
                        nums[i - 1] = temp;
                    }
                }
            } while (!sorted);
        }

        private static void SelectionSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[minIndex])
                    {
                        minIndex = j;
                    }
                    if (minIndex != i)
                    {
                        var temp = nums[i];
                        nums[i] = nums[minIndex];
                        nums[minIndex] = temp;
                    }
                }
            }
        }

        private static void InsertionSort(int[] nums)
        {
            for (int i = 1; i < nums.Length; ++i)
            {
                int value = nums[i];
                int k = i;

                while (k > 0 && nums[k - 1] >= value)
                {
                    nums[k] = nums[k - 1];
                    --k;
                }
                nums[k] = value;
            }

        }

        private static void Initializer(int[] nums)
        {
            for (int i = 0; i  < nums.Length; i++)
            {
                nums[i] = random.Next(0, 10000);
            }
        }
    }
}
