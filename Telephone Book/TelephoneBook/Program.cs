using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TelephoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. For adding a person, 2. For searching, 0. for exit");

            string command = Console.ReadLine();

            while (command != "1" && command != "2" && command != "0")
            {
                Console.WriteLine("Invalid input! Please try again!");
                command = Console.ReadLine();
            }

            People[] phoneBook = new People[100];
            int freeId = 0;

            while (command != "0")
            {
                switch (command)
                {
                    case "1":
                        Console.WriteLine("Type the name and the phonenumber of the person in order to add them");
                        string info = Console.ReadLine();

                        Add(info, phoneBook, ref freeId);
                        break; 
                    case "2":
                        Console.WriteLine("Type the name to search for the person");
                        string name = Console.ReadLine();

                        int end = 0;

                        for (int i = 0; i < phoneBook.Length; i++)
                        {
                            if (phoneBook[i] == null)
                            {
                                end = i - 1;
                                break;
                            }
                        }

                        bool found = SearchBinary(name, phoneBook, 0, end, out int positionOfName);

                        if (!found)
                            Console.WriteLine("No such person found!");
                        else
                            Console.WriteLine(phoneBook[positionOfName].ToString());

                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Please, enter a valid command!");
                        break;
                }

                Console.WriteLine("1. For adding a person, 2. For searching, 0. for exit");

             
                command = Console.ReadLine();
            }

        }

        private static bool SearchBinary(string name, People[] phoneBook, int start, int end, out int position)
        {
            name = name.ToLower();

            if (end < start)
            {
                position = -1;
                return false;
            }

            int midPos = start + (end - start) / 2;

            if (phoneBook[midPos].Name.ToLower() == name)
            {
                position = midPos;
                return true;
            }

            string minLengthStr;

            if (phoneBook[midPos].Name.Length >= name.Length)
            {
                minLengthStr = name;
            }
            else
            {
                minLengthStr = phoneBook[midPos].Name.ToLower();
            }

            for (int i = 0; i < minLengthStr.Length; i++)
            {
                if (phoneBook[midPos].Name.ToLower()[i] > name[i])
                {
                    return SearchBinary(name, phoneBook, start, midPos - 1, out position);
                }
                else if (phoneBook[midPos].Name.ToLower()[i] < name[i])
                {
                    return SearchBinary(name, phoneBook, midPos + 1, end, out position);
                }
                else
                {
                    continue;
                }
            }

            position = -1;
            return false;
        }

        private static void Add(string info, People[] phonebook, ref int i)
        {
            string[] tokens = info.Split(' ');

            phonebook[i] = new People(tokens[0], tokens[1]);

            i++;

            if (i > 1)
                SelectionSort(phonebook, i);
                
        }

        private static void SelectionSort(People[] phonebook, int end)
        {
            int minIndex = 0;
            int i = 0;

            for (; i < end - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < end; j++)
                {
                    if (String.Compare(phonebook[j].Name, phonebook[minIndex].Name) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    var temp = phonebook[minIndex];
                    phonebook[minIndex] = phonebook[i];
                    phonebook[i] = temp;
                }
            }
        }

        private static void Search(string name, People[] phonebook)
        {
            bool derived = false;

            for (int i = 0; i < phonebook.Length; i++)
            {
                if (name == phonebook[i].Name)
                {
                    Console.WriteLine(phonebook[i].ToString());
                    derived = true;
                    break;
                }
            }

            if (!derived)
                Console.WriteLine("No such person found!");
        }
    }
}
