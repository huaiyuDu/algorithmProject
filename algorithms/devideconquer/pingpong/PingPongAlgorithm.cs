using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace algorithmProject.algorithms.devideconquer.pingpong
{
    public class PingPongAlgorithm : AbstractAlgorithm
    {

        protected static CancellationToken current_token = CancellationToken.None;
        public PingPongAlgorithm(): base(null) { 
        }
        public PingPongAlgorithm(IExecuteObserver executeObserve) : base(executeObserve)
        {
        }


        public override string GetAlgorithmName()
        {
            return "Ping-Pong project";
        }

        protected override string createInputFile(string fileName, long n)
        {

            int[,] inputMatrix = new int[n,n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++) {
                    if (i == j) {
                        inputMatrix[i, j] = 0;
                    } else {
                        int value = rand.Next() % 2;
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


        protected override (string,long) doExecute(IAlgorithmInput input)
        {
            // read input
            int[,] inputMatrix = readInput(input);
            var startTime = DateTime.Now;
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
            var endTime = DateTime.Now;
            return (string.Join(",", result.ToArray()), (long)(endTime-startTime).TotalMilliseconds );
        }

        private int[,] readInput(IAlgorithmInput input) {
            string[] lines = System.IO.File.ReadAllLines(input.GetInputFilePath());
            int n = int.Parse(lines[0]);
            input.setN(n);
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
                if (current_token.IsCancellationRequested){
                    throw new TaskCanceledException("task canceled");
                }
                if (a.Size == 2) {
                    int[,] data= new int[2, 2];
                    data[0, 0] = a.data[0, 0] * b.data[0, 0] + a.data[0, 1] * b.data[1, 0];
                    data[0, 1] = a.data[0, 0] * b.data[0, 1] + a.data[0, 1] * b.data[1, 1];
                    data[1, 0] = a.data[1, 0] * b.data[0, 0] + a.data[1, 1] * b.data[1, 0];
                    data[1, 1] = a.data[1, 0] * b.data[0, 1] + a.data[1, 1] * b.data[1, 1];
                    return new Matrix(data);
                }


                (Matrix A11, Matrix A12, Matrix A21, Matrix A22) = a.divide();
                (Matrix B11, Matrix B12, Matrix B21, Matrix B22) = b.divide();
                //M1 = multiplication((A11 + A22), (B11 + B22))
                Matrix M1 = (A11 + A22) * (B11 + B22);
                //M2 = multiplication((A21 + A22), B11)
                Matrix M2 = (A21 + A22) * (B11);
                //M3 = multiplication(A11, (B12 - B22))
                Matrix M3 = A11 * (B12 - B22);
                //M4 = multiplication(A22, (B21 - B11))
                Matrix M4 = A22 * (B21 - B11);
                //M5 = multiplication((A11 + A12), B22)
                Matrix M5 = (A11 + A12) * B22;
                //M6 = multiplication((A21 - A11), (B11 + B12))
                Matrix M6 = (A21 - A11) * (B11 + B12);
                //M7 = multiplication((A12 - A22), (B21 + B22))
                Matrix M7 = (A12 - A22) * (B21 + B22);

                //C11 = M1 + M4 - M5 + M7
                Matrix C11 = M1 + M4 - M5 + M7;
                //C12 = M3 + M5
                Matrix C12 = M3 + M5;
                //C21 = M2 + M4
                Matrix C21 = M2 + M4;
                //C22 = M1 - M2 + M3 + M6
                Matrix C22 = M1 - M2 + M3 + M6;
                return Matrix.combine(C11,C12, C21, C22, a.Size);
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

            public static Matrix operator -(Matrix a, Matrix b)
            {
                int[,] data = new int[a.Size, a.Size];
                for (int i = 0; i < a.Size; i++)
                {
                    for (int j = 0; j < a.Size; j++)
                    {
                        data[i, j] = a.data[i, j] - b.data[i, j];
                    }
                }
                return new Matrix(data);
            }

            public (Matrix, Matrix, Matrix, Matrix) divide()
            {

                int size = this.Size;
                bool append = false;
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
                            data11[i, j] = data[i, j];
                        }
                        else if (i >= halfSize && j < halfSize)
                        {
                            if (append && i == size - 1)
                            {
                                data21[i - halfSize, j] = 0;
                            }
                            else
                            {
                                data21[i - halfSize, j] = data[i, j];
                            }

                        }
                        else if (i < halfSize && j >= halfSize)
                        {
                            if (append && j == size - 1)
                            {
                                data12[i, j - halfSize] = 0;
                            }
                            else
                            {
                                data12[i, j - halfSize] = data[i, j];
                            }
                        }
                        else if (i >= halfSize && j >= halfSize)
                        {
                            if (append && (i == size - 1 || j == size - 1))
                            {
                                data22[i - halfSize, j - halfSize] = 0;
                            }
                            else
                            {
                                data22[i - halfSize, j - halfSize] = data[i, j];
                            }

                        }
                    }
                   
                }
                return (new Matrix(data11), new Matrix(data12), new Matrix(data21), new Matrix(data22));
            }

            private static (int,bool) getHalfSize(int size) {
                bool odd = false;
                if (size % 2 == 1)
                {
                    size = size + 1;
                    odd = true;
                }
                int halfSize = size / 2;
                return (halfSize,odd);
            }
            public static Matrix combine(Matrix a11, Matrix a12,Matrix a21, Matrix a22,int size)
            {
                int[,] data = new int[size, size];
                (int halfSize, bool odd) = getHalfSize(size);
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (i < halfSize && j < halfSize)
                        {
                            data[i, j] = a11.data[i, j];
                        }
                        else if (i >= halfSize && j < halfSize)
                        {
                            data[i, j] = a21.data[i- halfSize, j];

                        }
                        else if (i < halfSize && j >= halfSize)
                        {
                            data[i, j] = a12.data[i, j- halfSize];
                        }
                        else if (i >= halfSize && j >= halfSize)
                        {
                            data[i, j] = a22.data[i- halfSize, j- halfSize];
                        }
                    }

                }
                return new Matrix(data);
            }

        }
    }
}
