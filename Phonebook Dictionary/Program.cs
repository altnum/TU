using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook_Dictionary
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

            SortedDictionary<string, string> phonebook1 = new SortedDictionary<string, string>();

            while (command != "0")
            {
                switch (command)
                {
                    case "1":
                        Console.WriteLine("Type the name and the phonenumber of the person in order to add them");
                        string info = Console.ReadLine();

                        Add(info, phonebook1);
                        break;
                    case "2":
                        Console.WriteLine("Type the name to search for the person");

                        string name = Console.ReadLine();

                        if (!phonebook1.ContainsKey(name))
                            Console.WriteLine("No such person found!");
                        else
                            Console.WriteLine("Name: " + name + " Phone: " + phonebook1[name]);

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

        private static void Add(string info, SortedDictionary<string, string> phonebook)
        {
            string[] tokens = info.Split(' ');

            phonebook.Add(tokens[0], tokens[1]);
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
