using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Coding
{
    public class Node
    {
        public Node left;
        public Node right;

        public int freq;
        public char letter;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text >");
            string text = Console.ReadLine();

            var nodes = new List<Node>();

            createNodes(nodes, text);

            var nodesSorted = new List<Node>();

            foreach (Node node in nodes)
                InsertNode(nodesSorted, node);

            while (nodesSorted.Count > 1)
            {
                var newNode = new Node
                {
                    left = nodesSorted[0],
                    right = nodesSorted[1],
                    freq = nodesSorted[0].freq + nodesSorted[1].freq
                };

                nodesSorted.RemoveAt(0);
                nodesSorted.RemoveAt(0);

                InsertNode(nodesSorted, newNode);
            }


            for (int i = 0; i < text.Length; i++)
            {
                string encode = EncodeLetter(nodesSorted[0], text[i]);

                Console.WriteLine(text[i] + ": " + encode);
            }

            Console.ReadKey();

        }

        private static string EncodeLetter(Node node, char letter) {
            if (node == null)
            {
                return null;
            }

            if (node.letter == letter)
                return "";

            string code;

            if ((code = EncodeLetter(node.left, letter)) != null)
                return code + "0";
            else if ((code = EncodeLetter(node.right, letter)) != null)
                return code + "1";

            return null;
        }

        private static void InsertNode(List<Node> nodesSorted, Node newNode)
        {
            int i = 0;
            for(; i < nodesSorted.Count; i++)
            {
                if (nodesSorted[i].freq >= newNode.freq)
                {
                    nodesSorted.Insert(i, newNode);
                    break;
                }
            }

            if (i == nodesSorted.Count)
                nodesSorted.Add(newNode);
        }

        private static void createNodes(List<Node> nodes, string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Node node = null;

                for (int j = 0; j < nodes.Count; j++)
                {
                    if (nodes[j].letter == text[i])
                    {
                        node = nodes[j];
                        break;
                    }

                }

                if (node == null)
                {
                    nodes.Add(new Node
                    {
                        letter = text[i],
                        freq = 1
                    });
                }
                else
                {
                    node.freq++;
                }
            }
        }
    }
}
