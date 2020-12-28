using algorithmProject.algorithms.greedy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmProject.algorithms.dynamicprograming
{
    public class MultiplicationSequenceMatrix : AbstractAlgorithm
    {
        private const int MAX_SIZE = 1000;

        public MultiplicationSequenceMatrix(IExecuteObserver executeObserver) : base(executeObserver)
        {
        }

        public override string GetAlgorithmName()
        {
            return "Multiplication of Squence of Matrices";
        }

        /**
         * 5 // matrices count n, n+1 rows below, p0, p1... p5
         * 3 // Matrix 1 (3*4)
         * 4 // Matrix 2 (4*8)
         * 8 // ...
         * 9
         * 9
         * 11
         */
        protected override string createInputFile(string fileName, long n)
        {
            Random random = new Random();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                file.WriteLine(n);

                for (int i = 0; i <= n; i++)
                {
                    file.WriteLine(random.Next(1, MAX_SIZE));
                }
            }

            return fileName;
        }

        protected override string doExecute(IAlgorithmInput input)
        {
            int[] p = readInput(input);
            int n = p.Length - 1;
            Matrix<int> m = new Matrix<int>(new int[n, n]);
            Matrix<int> s = new Matrix<int>(new int[n, n]);
            for (int i = 1; i <= n; i++)
            {
                m[i, i] = 0;
            }

            for (int len = 2; len <=n; len++) {
                for (int i = 1; i <= n - len + 1; i++) {
                    int j = i + len - 1;
                    m[i, j] = int.MaxValue;
                    for (int k = i; k < j; k++) {
                        int q = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];
                        if (q < m[i, j]) {
                            m[i, j] = q;
                            s[i, j] = k;
                        }
                    }

                }
            }

            //executeObserver.printConsole(string.Format("total activity count = {0}",c[0,n-1]));


            return input.FileName+ " : "+getResult(s,1, n);
        }

        public string getResult(Matrix<int> s, int i, int j) {
            if (j  == i) {
                return "M" + i;
            }
            return string.Format("({0}.{1})", getResult(s, i, s[i, j]), getResult(s, s[i, j] + 1, j));

        }

       
        protected int[] readInput(IAlgorithmInput input)
        {
            string[] lines = System.IO.File.ReadAllLines(input.InputFilePath);
            int n = int.Parse(lines[0]);
            input.N = n;
            int[] p = new int[n + 1];

            for (int i = 1; i < lines.Length; i++)
            {
                p[i - 1] = int.Parse(lines[i]);
            }
            return p;
        }
    }
}
