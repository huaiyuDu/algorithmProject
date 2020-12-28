using algorithmProject.algorithms.greedy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmProject.algorithms.dynamicprograming
{
    public class LongestCommonSequence : AbstractAlgorithm
    {

        public static Random r = new Random();
        private enum Direction { 
             LEFT_UP = 1,
             LEFT=4,
             UP = 2
        }

        public LongestCommonSequence(IExecuteObserver executeObserver) : base(executeObserver)
        {
        }

        public override string GetAlgorithmName()
        {
            return "Longest Commom Seqence";
        }

        /**
         * ABCDABC // Sequence X
         * CDAC // Sequence Y
         */
        protected override string createInputFile(string fileName, long n)
        {
            Random random = new Random();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {

                file.WriteLine(RandomString(n));
                file.WriteLine(RandomString((long)(n * 0.9)));
            }

            return fileName;
        }

        protected override string doExecute(IAlgorithmInput input)
        {
            (char[] X, char[] Y) = readInput(input);

            int m = X.Length;
            int n = Y.Length;
            input.N = m;
            int[,] C = new int[m + 1, n + 1];
            Matrix<Direction> L= new Matrix<Direction>(new Direction[m, n]);
            for (int i = 1; i <= m; i++)
            {
                C[i, 0] = 0;
            }

            for (int i = 1; i <= n; i++)
            {
                C[0, i] = 0;
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (X[i - 1] == Y[j - 1])
                    {
                        C[i, j] = C[i - 1, j - 1] + 1;
                        L[i, j] = Direction.LEFT_UP; // Left UP, 
                    }
                    else if (C[i - 1, j] >= C[i, j - 1])
                    {
                        C[i, j] = C[i - 1, j];
                        L[i, j] = Direction.UP; //  UP, 
                    }
                    else {
                        C[i, j] = C[i, j-1];
                        L[i, j] = Direction.LEFT; // Left, 
                    }

                }
            }

            int row = m;
            int column = n;
            List<char> result = new List<char>();
            while  (row > 0 && column > 0) {
                switch (L[row, column]) {
                    case Direction.LEFT_UP:
                        result.Add(X[row - 1]);
                        row--;
                        column--;
                        break;
                    case Direction.UP:
                        row--;
                        break;
                    case Direction.LEFT:
                        column--;
                        break;
                    default:
                        break;
                }
            }
            return input.FileName+ " : "+getResult(result);
        }

        private string RandomString(long length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            StringBuilder sb = new StringBuilder();

            char[] chars = allowedChars.ToCharArray();
            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[r.Next(chars.Length)]);
            }
            return sb.ToString();
        }

        public string getResult(List<char> result) {
            result.Reverse();
            return String.Join(", ", result.ToArray());

        }

        
        protected (char[] X, char[] Y) readInput(IAlgorithmInput input)
        {
            string[] lines = System.IO.File.ReadAllLines(input.InputFilePath);
            return (lines[0].ToCharArray(), lines[1].ToCharArray());
        }
    }
}
