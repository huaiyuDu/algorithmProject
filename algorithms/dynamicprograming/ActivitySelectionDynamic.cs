using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmProject.algorithms.dynamicprograming
{
    public class ActivitySelectionDynamic : AbstractAlgorithm
    {
        private const int MAX_ACTIVITY_LENGTH = 10;
        private const int ACTIVITY_DENSITY_PERCENT = 30;

        public ActivitySelectionDynamic(IExecuteObserver executeObserver) : base(executeObserver)
        {
        }

        public override string GetAlgorithmName()
        {
            return "Activity Seletion Problem(Dynamic)";
        }

        protected override string createInputFile(string fileName, long n)
        {
            Random random = new Random();
            long max_start_time = MAX_ACTIVITY_LENGTH * n * ACTIVITY_DENSITY_PERCENT / 100;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                file.WriteLine(n);

                for (int i = 0; i < n; i++)
                {
                    int start = random.Next(0, (int)max_start_time);
                    int end = start + random.Next(1, MAX_ACTIVITY_LENGTH);
                    file.WriteLine(start + "," + end);
                }
            }

            return fileName;
        }

        protected override string doExecute(IAlgorithmInput input)
        {
            List<Activity> inputs = readInput(input);
            inputs.Sort(Comparer<Activity>.Create((Activity x, Activity y)=> x.End - y.End));
            int n = inputs.Count;
            int?[,] c= new int?[n, n];

            int[,] z = new int[n, n];
            for (int i = 0; i < n; i ++) {
                for (int j = 0; j < n; j++)
                {
                    if (i >= j)
                    {
                        c[i, j] = 0;
                    }
                    else {
                        caculateMaxC(inputs,c, i, j,z);
                    }
                }
            }
            executeObserver.printConsole(string.Format("total activity count = {0}",c[0,n-1]));
            printResult(z,0,n-1, inputs);
            return string.Format("total activity count = {0}", c[0, n - 1]);
        }

        private void printResult(int[,] z, int i, int j, List<Activity> inputs) {
            int k = z[i, j];
            if (k >0) {
                printResult(z, i, k, inputs);
                executeObserver.printDebugToConsole(string.Format("Activity:({0}) start:{1}, end:{2}", k, inputs[k].Start, inputs[k].End));
                printResult(z, k, j, inputs);
            }


        }

        private int caculateMaxC(List<Activity> inputs,int?[,] c, int i, int j, int[,] z ) {
            if (c[i,j] ==null) {
                int c_max = 0;
                for (int k = i + 1; k < j; k++)
                {
                    if (inputs[k].Start >= inputs[i].End && inputs[k].End <= inputs[j].Start)
                    {
                        int c_k = caculateMaxC(inputs, c, i, k, z) + caculateMaxC(inputs, c, k, j, z) + 1;
                        if (c_k > c_max)
                        {
                            c_max = c_k;
                            z[i, j] = k;
                        }
                    }
                }
                c[i, j] = c_max;
            }
            return c[i, j].Value;
        }

        protected List<Activity> readInput(IAlgorithmInput input)
        {
            string[] lines = System.IO.File.ReadAllLines(input.InputFilePath);
            int n = int.Parse(lines[0]);
            input.N = n;
            List<Activity> result = new List<Activity>(n+2);
            result.Add(new Activity(0, 0));
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splits = lines[i].Split(',');
                result.Add(new Activity(splits[0], splits[1]));

            }
            result.Add(new Activity(int.MaxValue, int.MaxValue));
            return result;
        }

        protected struct Activity{

            
            private int start;

            private int end;

            public Activity(int start, int end)
            {
                this.start = start;
                this.end = end;
            }

            public Activity(string start, string end)
            {
                this.start = int.Parse(start);
                this.end = int.Parse(end);
            }

            public int Start { get => start; set => start = value; }

            public int End { get => end; set => end = value; }
        }
    }
}
