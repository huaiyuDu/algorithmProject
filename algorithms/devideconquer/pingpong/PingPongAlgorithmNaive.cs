using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace algorithmProject.algorithms.devideconquer.pingpong
{
    public class PingPongAlgorithmNaive : AbstractAlgorithm
    {
        /**
         * Task cancellation token for stop the algorithm. 
         */
        protected static CancellationToken current_token = CancellationToken.None;

        public PingPongAlgorithmNaive(IExecuteObserver executeObserve) : base(executeObserve)
        {
        }


        public override string GetAlgorithmName()
        {
            return "Ping-Pong project";
        }

        /**
         * input file sample
         * 5                  // denote the size of matrix
         * 0,1,0,1,1          // matrix data
         * 0,0,0,0,1
         * 1,1,0,1,0
         * 0,1,0,0,0
         * 0,0,1,1,0
         */
        protected override string createInputFile(string fileName, long n)
        {

            int[,] inputMatrix = new int[n,n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++) {
                    if (i == j) {
                        // A [i,i] = 0
                        inputMatrix[i, j] = 0;
                    } else {
                        // value = 0 or 1
                        int value = rand.Next() % 2;
                        // if A [i,j] = 0, then A [j,i] =1, vice versa
                        inputMatrix[i, j] = value;
                        inputMatrix[j, i] = value == 1? 0: 1;
                    }
                }
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                file.WriteLine(n);
                for (int i = 0; i < n; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < n; j++)
                    {
                        
                        sb.Append(inputMatrix[i, j]);
                        if (j != n-1) {
                            sb.Append(",");
                        }
                    }
                    file.WriteLine(sb.ToString());
                }
            }

            return fileName;

        }


        protected override string doExecute(IAlgorithmInput input)
        {
            // read input
            int[,] inputMatrix = readInput(input);
            Matrix A = new Matrix(inputMatrix);
            Matrix A_seq = A * A;
            Matrix ResM = A + A_seq;
            List<int> result = new List<int>();
            for (int i = 0; i < A.Size; i++)
            {
                bool hasX = true;
                for (int j = 0; j < A.Size; j++)
                {
                    
                    if (i != j && ResM[i,j] == 0) {
                        hasX = false;
                    }
                }
                if (hasX) {
                    result.Add(i);
                }
            }
            return string.Join(",", result.ToArray());
        }

        /**
         * read input file to a Matrix
         */
        private int[,] readInput(IAlgorithmInput input) {
            string[] lines = System.IO.File.ReadAllLines(input.InputFilePath);
            int n = int.Parse(lines[0]);
            input.N=n;
            int[,] res = new int[n,n];
            for (int i = 1; i < lines.Length; i ++) {
                string[] splits= lines[i].Split(',');
                for (int j = 0; j < splits.Length; j ++) {
                    res[i - 1,j] = int.Parse(splits[j]);
                }
                
            }
            return res;
        }
        protected override void putCancellToken(CancellationToken token)
        {
            current_token = token;
        }

        /**
         * Matrix class to implis the fast multiplication
         */
        public class Matrix {
            private int[,] data;

            public int this[int i, int j] {
                get { return data[i,j]; }
                set { data[i,j] = value; }
            }

            public override string ToString()
            {
                return $"Matric values: \n{valuesToString()}";
            }

            private string valuesToString()
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.GetLength(0); i++)
                {

                    for (int j = 0; j < data.GetLength(1); j++)
                    {

                        sb.Append(data[i, j]).Append(",");
                    }
                    sb.Append("\n");
                }
                return sb.ToString();
            }

            public int Size { get => data.GetLength(0);  }
                  
            public Matrix(int[,] data) {
                this.data = data;
            }

            public static Matrix operator * (Matrix a, Matrix b) {
                int[,] data = new int[a.Size, a.Size];
                for (int i = 0; i < a.Size; i++)
                {
                    for (int j = 0; j < a.Size; j++)
                    {
                        int val = 0;
                        for (int k = 0; k < a.Size; k++)
                        {
                            val = val + a[i, k] * a[k, j];
                        }
                        data[i, j] = val;
                    }
                }
                return new Matrix(data);
            }

            public static Matrix operator + (Matrix a, Matrix b)
            {
                int[,] data = new int[a.Size, a.Size];
                for (int i = 0; i < a.Size; i++)
                {
                    for (int j = 0; j < a.Size; j++)
                    {
                        data[i, j] = a.data[i, j] + b.data[i, j];
                    }
                }
                return new Matrix(data);
            }
        }
    }
}
