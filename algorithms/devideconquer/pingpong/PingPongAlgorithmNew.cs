using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace algorithmProject.algorithms.devideconquer.pingpong
{
    public class PingPongAlgorithmNew : AbstractAlgorithm
    {
        /**
         * Task cancellation token for stop the algorithm. 
         */
        public static CancellationToken current_token = CancellationToken.None;

        public PingPongAlgorithmNew(IExecuteObserver executeObserve) : base(executeObserve)
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
            int[,] A = readInput(input);
            int[,] A_seq;
            if (input.ExecuteCompairAlgorithm)
            {
                A_seq = A.NaiveMultiplication(A);
            }
            else
            {
                A_seq = A.Multiply(A);
            }

            int[,] ResM = A.Add(A_seq);
            List<int> result = new List<int>();
            for (int i = 0; i < A.GetLength(0); i++)
            {
                bool hasX = true;
                for (int j = 0; j < A.GetLength(1); j++)
                {

                    if (i != j && ResM[i, j] == 0)
                    {
                        hasX = false;
                    }
                }
                if (hasX)
                {
                    result.Add(i);
                }
            }
            return string.Join(",", result.ToArray());
            
            
        }

        

        

        public override bool supportCompairAlogirthm()
        {
            return true;
        }

        /**
         * read input file to a Matrix
         */
        private int[,] readInput(IAlgorithmInput input) {
            string[] lines = System.IO.File.ReadAllLines(input.InputFilePath);
            int n = int.Parse(lines[0]);
            input.N = n;
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
        
    }


    public static class MatrixExtention
    {
        public static int[,] NaiveMultiplication(this int[,] A, int[,] B)
        {
            int Size = A.GetLength(0);
            int[,] data = new int[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    int val = 0;
                    for (int k = 0; k < Size; k++)
                    {
                        val = val + A[i, k] * B[k, j];
                    }
                    data[i, j] = val;
                }
            }
            return data;
        }


        public static int[,] Multiply(this int[,] a, int[,] b)
        {
            // check if the task canceled from UI
            //if (pingpongalgorithmnew.current_token.iscancellationrequested)
            //{
            //    throw new taskcanceledexception("task canceled");
            //}
            //if (a.GetLength(0) == 2)
            //{
            //    int[,] data = new int[2, 2];
            //    data[0, 0] = a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0];
            //    data[0, 1] = a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1];
            //    data[1, 0] = a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0];
            //    data[1, 1] = a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1];
            //    return data;
            //}
            if (a.GetLength(0) <64) {
                return a.NaiveMultiplication(b);
            }

             (int[,] A11, int[,] A12, int[,] A21, int[,] A22) = a.divide();
            (int[,] B11, int[,] B12, int[,] B21, int[,] B22) = b.divide();
            //M1 = multiplication((A11 + A22), (B11 + B22))
            int[,] M1 = (A11.Add(A22)).Multiply(B11.Add(B22));
            //M2 = multiplication((A21 + A22), B11)
            int[,] M2 = (A21.Add(A22)).Multiply(B11);
            //M3 = multiplication(A11, (B12 - B22))
            int[,] M3 = A11.Multiply(B12.Subtrac(B22));
            //M4 = multiplication(A22, (B21 - B11))
            int[,] M4 = A22.Multiply(B21.Subtrac(B11));
            //M5 = multiplication((A11 + A12), B22)
            int[,] M5 = (A11.Add(A12)).Multiply( B22);
            //M6 = multiplication((A21 - A11), (B11 + B12))
            int[,] M6 = (A21.Subtrac(A11)).Multiply(B11.Add(B12));
            //M7 = multiplication((A12 - A22), (B21 + B22))
            int[,] M7 = (A12.Subtrac( A22)) .Multiply(B21.Add(B22));

            //C11 = M1 + M4 - M5 + M7
            int[,] C11 = M1.Add(M4).Subtrac(M5) .Add(M7);
            //C12 = M3 + M5
            int[,] C12 = M3.Add(M5);
            //C21 = M2 + M4
            int[,] C21 = M2.Add(M4);
            //C22 = M1 - M2 + M3 + M6
            int[,] C22 = M1.Subtrac(M2).Add( M3).Add (M6);
            return combine(C11, C12, C21, C22, a.GetLength(0));
        }

        public static int[,] Add(this int[,] a, int[,] b)
        {
            int[,] data = new int[a.GetLength(0), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    data[i, j] = a[i, j] + b[i, j];
                }
            }
            return data;
        }

        public static int[,] Subtrac(this int[,] a,  int[,] b)
        {
            int[,] data = new int[a.GetLength(0), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    data[i, j] = a[i, j] - b[i, j];
                }
            }
            return data;
        }

        /**
         * divide a matrix into 4 small matrix
         */
        public static (int[,], int[,], int[,], int[,]) divide(this int[,] a)
        {

            int size = a.GetLength(0);
            bool append = false;
            // if the size is odd, need to append 0 to the last row and the last column
            if (size % 2 == 1)
            {
                size = size + 1;
                append = true;
            }
            int halfSize = size / 2;

            int[,] data11 = new int[halfSize, halfSize];
            int[,] data12 = new int[halfSize, halfSize];
            int[,] data21 = new int[halfSize, halfSize];
            int[,] data22 = new int[halfSize, halfSize];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // A11
                    if (i < halfSize && j < halfSize)
                    {
                        data11[i, j] = a[i, j];
                    }
                    // A21
                    else if (i >= halfSize && j < halfSize)
                    {
                        // append 0 to the last row
                        if (append && i == size - 1)
                        {
                            data21[i - halfSize, j] = 0;
                        }
                        else
                        {
                            data21[i - halfSize, j] = a[i, j];
                        }

                    }
                    // A12
                    else if (i < halfSize && j >= halfSize)
                    {
                        // append 0 to the last column
                        if (append && j == size - 1)
                        {
                            data12[i, j - halfSize] = 0;
                        }
                        else
                        {
                            data12[i, j - halfSize] = a[i, j];
                        }
                    }
                    // A22
                    else if (i >= halfSize && j >= halfSize)
                    {
                        // append 0 to the last row and the last column
                        if (append && (i == size - 1 || j == size - 1))
                        {
                            data22[i - halfSize, j - halfSize] = 0;
                        }
                        else
                        {
                            data22[i - halfSize, j - halfSize] = a[i, j];
                        }

                    }
                }

            }
            return (data11, data12, data21, data22);
        }

        /**
         * calculate the half size of a matrix
         * and return if the size is a odd number
         */
        private static (int, bool) getHalfSize(int size)
        {
            bool odd = false;
            if (size % 2 == 1)
            {
                size = size + 1;
                odd = true;
            }
            int halfSize = size / 2;
            return (halfSize, odd);
        }

        /**
         * combine 4 small matrix into a big matrix
         */
        public static int[,] combine(int[,] a11, int[,] a12, int[,] a21, int[,] a22, int size)
        {
            int[,] data = new int[size, size];
            (int halfSize, bool odd) = getHalfSize(size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i < halfSize && j < halfSize)
                    {
                        data[i, j] = a11[i, j];
                    }
                    else if (i >= halfSize && j < halfSize)
                    {
                        data[i, j] = a21[i - halfSize, j];

                    }
                    else if (i < halfSize && j >= halfSize)
                    {
                        data[i, j] = a12[i, j - halfSize];
                    }
                    else if (i >= halfSize && j >= halfSize)
                    {
                        data[i, j] = a22[i - halfSize, j - halfSize];
                    }
                }

            }
            return data;
        }

    }
}
