using System;
using System.IO;


class Program
{
    public static string Encode_Transform(string message)
    {
        string output = "";
        int N = 1;
        int size = 0;

        foreach (char ch in message)
        {
            size++;
        }
        string[] arr = new string[size];

        int pos = 0;
        foreach (char ch in message)
        {
            arr[pos] = ch.ToString();
            pos++;
        }

        bool end = false;
        while (!end)
        {

            for (int k = 1; k <= N; k++)
            {
                if (k == arr.Length - 1)
                {
               //     end = true;
               //     break;
                }
                int v = k;
                string add = "";
                if (v >= arr.Length)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        add += arr[i];
                    }
                    end = true;
                    if (k % 2 != 0)
                    {
                        output = output + add;
                    }
                    else if (k % 2 == 0)
                    {
                        output = add + output;
                    }
                    break;
                }
                else if (v < arr.Length)
                {
                    for (int i = 0; i < v; i++)
                    {
                        add += arr[i];
                        arr[i] = null;

                    }
                    if (k % 2 != 0)
                    {
                        output = output + add;
                    }
                    else if (k % 2 == 0)
                    {
                        output = add + output;
                    }
                }

                int nulls = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == null)
                    {
                        nulls++;
                    }
                }
                int newSize = arr.Length - nulls;
                string[] arr1 = new string[newSize];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != null)
                    {
                        arr1[i - nulls] = arr[i];
                    }
                }

                arr = arr1;

                N++;
            }
        }
        return output;
    }
    public static string Decode_Original(string message, int N)
    {
        int count = 0;
        string output = "";
        foreach (char ch in message)
        {
            count++;
        }
        int[] arr = new int[count];

        string[] word = new string[count];
        int pos = 0;
        foreach (char ch in message)
        {
            word[pos] = ch.ToString();
            pos++;
        }

        for (int i = 1; i < arr.Length; i++)
        {
            count = count - i;
            if (count <= 0)
            {
                arr[i] = count + i;
                break;
            } else if (count > 0)
            {
                arr[i] = i;
            }
        }
        Array.Reverse(arr);
        
        int trans = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
                trans++;
        }
        ////
        int notNULL = 0;
        for (int o = 0; o < arr.Length; o++)
        {
            if (arr[o] != 0)
            {
                notNULL++;
            }
        }
        int[] arr2 = new int[notNULL];
        int p = 0;
        for (int o = 0; o < arr.Length; o++)
        {
            if (arr[o] != 0)
            {
                arr2[p] = arr[o];
                p++;
            }
        }
        arr = arr2;




        ///


        for (int x = 1; x <= N; x++)
        {
            bool end = false;
            output = "";
            int vzetiBroqch = 0;
            for (int i = trans; i > 0; i--)
            {
                string add = "";
                int broyvzeti = arr[vzetiBroqch];
                if (vzetiBroqch == arr.Length)
                {
                    end = true;
                    break;
                }
                if (i % 2 == 0)
                {
                    for (int k = 0; k < broyvzeti; k++)
                    {
                        add += word[k];
                        word[k] = null;
                    }
                }
                else if (i % 2 != 0)
                {
                    for (int k = 0; k < broyvzeti; k++)
                    {
                        add = word[word.Length - 1 - k] + add;
                        word[word.Length - 1 - k] = null;
                    }
                }
                output = add + output;
                vzetiBroqch++;
                //
                int nulls = 0;
                for (int c = 0; c < word.Length; c++)
                {
                    if (word[c] == null)
                    {
                        nulls++;
                    }
                }
                int newSize = word.Length - nulls;
                string[] arr1 = new string[newSize];
                int posArr1 = 0;
                for (int c = 0; c < word.Length; c++)
                {
                    if (word[c] != null)
                    {
                        arr1[posArr1] = word[c];
                        posArr1++;
                    }
                }
                word = arr1;
               
            }
            if (end == true)
                break;
            count = 0;
            foreach (char ch in output)
            {
                count++;
            }
            int position = 0;
            string[] newArr = new string[count];
            word = newArr;
            foreach (char ch in output)
            {
                word[position] = ch.ToString();
                position++;
            }

        }
        return output;
    }
    public static void Main(string[] args)
    { 
            int N = int.Parse(Console.ReadLine());
            string MESSAGE = Console.ReadLine();

        for (int i = 0; i < Math.Abs(N); i++)
        {
            if (N < 0)
            {
                MESSAGE = Encode_Transform(MESSAGE);
                
            }
            else
            {
                MESSAGE = Decode_Original(MESSAGE, N);
                break;
            }
        }

            Console.WriteLine(MESSAGE);
    }
    
}
