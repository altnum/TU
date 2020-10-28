using System;
using System.Collections.Generic;

namespace FamilyTree
{
    class Program
    {
        static Node Find(Node node, string name)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Name == name)
            {
                return node;
            }

            return 
            Find(node.Father, name) ??
            Find(node.Mother, name);
        }

        static void Height(Node node, int level, ref int maxLevel)
        {
            if (node == null)
            {
                return;
            }

            if (maxLevel < level)
                maxLevel = level;

            Height(node.Father, level + 1, ref maxLevel);
            Height(node.Mother, level + 1, ref maxLevel);
        }

        static void Display(List<Node> levelNodes, int height)
        {
            double spaces = Math.Pow(2, height) - 1;
            var nextLevelNodes = new List<Node>();

            foreach (var node in levelNodes)
            {
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }

                if (node == null)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(node.Name);
                }

                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }

                Console.Write(" ");

                nextLevelNodes.Add(node != null ? node.Father : null);
                nextLevelNodes.Add(node != null ? node.Mother : null);
            }

            Console.WriteLine();
            if (height >= 0)
                Display(nextLevelNodes, height - 1);

        }
        static void Main(string[] args)
        {
            var root = new Node
            {
                Name = "a"
            };

            bool run = true;
            while (run)
            {
                Console.Clear();
                int  h = 0;
                Height(root, 0, ref h);
                Display(new List<Node>() { root }, h);

                Console.Write("\"A\"- add; \"F\"- find parents; \"Q\"- quit");
                char command = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (command)
                {
                    case 'q':
                        run = false;
                        break;
                    case 'a':
                        {
                            Console.WriteLine("Please, enter the child's name:");
                            var childName = Console.ReadLine();

                            Node child = Find(root, childName);
                            if (child == null)
                            {
                                Console.WriteLine("Child not found!");
                                Console.ReadLine();
                                break;
                            }
                            Console.WriteLine("Father's name:");
                            var fatherName = Console.ReadLine();
                            Console.WriteLine("Mother's name:");
                            var motherName = Console.ReadLine();

                            child.Father = new Node
                            {
                                Name = fatherName
                            };
                            child.Mother = new Node
                            {
                                Name = motherName
                            };
                        }
                        break;
                    case 'f':
                        {
                            Console.WriteLine("Please, enter the child's name:");
                            var childName = Console.ReadLine();

                            Node child = Find(root, childName);
                            if (child == null)
                            {
                                Console.WriteLine("Child not found!");
                                break;
                            }

                            string fName = "";
                            string mName;
                            Node n;
                            try
                            {
                                n = child.Father;
                                fName = "Father's name: " + n.Name;
                            } catch (Exception e)
                            {
                                fName = "";
                            }
                            Console.WriteLine(fName);

                            try
                            {
                                n = child.Mother;
                                mName = "Mother's name: " + child.Mother.Name;
                            } catch (Exception e)
                            {
                                mName = "";
                            }
                            Console.WriteLine(mName);

                            Console.ReadLine();
                        }
                        break;
                }
            }
        }
    }
}
