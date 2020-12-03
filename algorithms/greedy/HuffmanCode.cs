using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmProject.algorithms.greedy
{
    class HuffmanCode : AbstractAlgorithm
    {
        public HuffmanCode(IExecuteObserver executeObserver) : base(executeObserver)
        {
        }

        public override string GetAlgorithmName()
        {
            return "Huffman Code";
        }
        /**
         * input file sample
         * 5                  // denote the size of input
         * A,122              // char, frequency
         * B,23
         * C,1000
         * D,12
         * E,123
         */
        protected override string createInputFile(string fileName, long n)
        {
            int[,] inputMatrix = new int[n, n];
            Random rand = new Random();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                file.WriteLine(n);
                (char, int)[]  inputs = RandomString(n);
                for (int i = 0; i < n; i++)
                {
                    (char c,int f)= inputs[i];
                    file.WriteLine(c+","+f);
                }
            }

            return fileName;
        }

        private (char, int)[] readInput(IAlgorithmInput input)
        {
            string[] lines = System.IO.File.ReadAllLines(input.GetInputFilePath());
            int n = int.Parse(lines[0]);
            input.setN(n);
            (char, int)[] res = new (char, int)[n];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splits = lines[i].Split(',');
                res[i - 1] = (splits[0][0], int.Parse(splits[1]));

            }
            return res;
        }

        protected override (string, long) doExecute(IAlgorithmInput input)
        {
            (char, int)[] inputs = readInput(input);
            SortedSet<Node> heap = new SortedSet<Node>();
            foreach ((char c, int f) item in inputs) {
                Node node = new Node();
                node.c = item.c;
                node.frequency = item.f;
                heap.Add(node);
            }
            while (heap.Count > 1) {
                Node kidNode1 = heap.Pop();
                Node kidNode2 = heap.Pop();
                Node parentNode = new Node();
                parentNode.frequency = kidNode1.frequency + kidNode1.frequency;
                if (kidNode1.frequency < kidNode2.frequency)
                {
                    parentNode.left = kidNode1;
                    parentNode.right = kidNode2;
                }
                else {
                    parentNode.left = kidNode2;
                    parentNode.right = kidNode1;
                }
                heap.Add(parentNode);
            }

            Node root = heap.Pop();
            HuffmanTree huffmanTree = new HuffmanTree(root);
            StringBuilder sb = new StringBuilder();
            huffmanTree.printEncoding(message => sb.Append(message).Append(Environment.NewLine), root, new Stack<char>());

            return (sb.ToString(), 1);
        }


        private (char, int)[] RandomString(long length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-={}:\";'<>?,./~`")
        {
            (char, int)[] result = new (char, int)[length];
            if (length < 0) 
            { 
                throw new ArgumentOutOfRangeException("length", "length cannot be less than zero."); 
            }
            if (length > allowedChars.Length)
            {
                throw new ArgumentOutOfRangeException("length", "length is greater then allowed Chars.");
            }
            char[] chars = allowedChars.ToCharArray();
            Random r = new Random();
            for (int i = 0; i < length; i ++) {
                result[i] = (chars[i], r.Next());
            }
            return result;
        }
    }

    public class HuffmanTree {

        public HuffmanTree(Node root) {
            this.root = root;
        }
        public Node root;

        public delegate void printFuntion(string result);
        public void printEncoding(printFuntion printf,Node node, Stack<char> stack) {
            if (node.left!= null) {
                stack.Push('0');
                printEncoding(printf, node.left, stack);
            }
            if (node.right != null)
            {
                stack.Push('1');
                printEncoding(printf, node.right, stack);
            }
            if (node.c != null)
            {
                char[] charArr = stack.ToArray();
                Array.Reverse(charArr);
                string code = node.c + ":" + new string(charArr);
                printf(code);
                
            }
            if (stack.Count > 1) {
                stack.Pop();
            }
            


        }
    }

    public static class Heap {
        public static T Pop<T>(this SortedSet<T> sortedSet) {
            T t = sortedSet.Min();
            sortedSet.Remove(t);
            return t;
        }
    }

    public class Node: IComparable<Node>
    {
        public char? c;
        public long frequency;
        public Node left;
        public Node right;

        public int CompareTo(Node other)
        {
            return frequency - other.frequency >0?1:(frequency == other.frequency?0:-1);
        }
    }
}
