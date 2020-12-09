using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmProject.algorithms.devideconquer
{
    public class CloestPairPoints : AbstractAlgorithm
    {
        public CloestPairPoints(IExecuteObserver executeObserver) : base(executeObserver,"100,500,1000,5000,10000,50000")
        {
        }

        public override string GetAlgorithmName()
        {
            return "Closest Pair of Points";
        }

        protected override string createInputFile(string fileName, long n)
        {

            Random random = new Random();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                file.WriteLine(n);

                for (int i = 0; i < n; i++)
                {
                    file.WriteLine(random.Next() + "," + random.Next());
                }
            }

            return fileName;
        }

        protected override string doExecute(IAlgorithmInput input)
        {
            List<Point> inputs = readInput(input);
            inputs.Sort(Comparer<Point>.Create((Point a, Point b) => a.X - b.X));
            Point[] X = inputs.ToArray();

            inputs.Sort(Comparer<Point>.Create((Point a, Point b) => a.Y - b.Y));
            Point[] Y = inputs.ToArray();
            (double distance, Point a, Point b)  result = CloestedDistance(X, Y);
            return string.Format("point {0} and {1} has the mini distance of {2}", result.a, result.b, result.distance);
        }

        private static int ByY(Point a, Point b)
        {
            return a.Y - b.Y;
        }


        private (double distance,Point a, Point b) CloestedDistance(Point[] X, Point[] Y) {

            int count = X.Count();

            if (count <= 3) {
                double miniDistance = double.MaxValue;
                Point p1 = X[0];
                Point p2 = X[1];
                for (int i = 0; i <count-1; i ++) {
                    for (int j = i+1; j < count; j++)
                    {
                        double distance = Distance(X[i],X[j]);
                        if (distance < miniDistance) {
                            miniDistance = distance;
                            p1 = X[i];
                            p2 = X[j];
                        }
                    }
                }

                return (miniDistance, p1, p2);
            }
            int halfCount = count / 2;

            // devide
            // X left
            Point[] XLeft = new Point[halfCount];

            Point[] XRight = new Point[count -halfCount];

            Point[] YLeft = new Point[halfCount];

            Point[] YRight = new Point[count - halfCount];

            for (int i = 0; i < count; i ++) {
                if (i < halfCount) {
                    X[i].Right = false;
                    XLeft[i] = X[i];

                } else {
                    X[i].Right = true;
                    XRight[i - halfCount] = X[i];
                }
            }

            int middle_x = XLeft[halfCount - 1].X;

            int y_index_left = 0;
            int y_index_right = 0;
            for (int i = 0; i < count; i++)
            {
                if (Y[i].Right == false)
                {
                    YLeft[y_index_left] = Y[i];
                    y_index_left++;
                }
                else {
                    YRight[y_index_right] = Y[i];
                    y_index_right++;
                }
            }
            (double distance, Point a, Point b) leftRes = CloestedDistance(XLeft, YLeft);
            (double distance, Point a, Point b) rightRes = CloestedDistance(XRight, YRight);

            double miniDisc = leftRes.distance;
            Point a = leftRes.a;
            Point b = leftRes.b;
            if (rightRes.distance < miniDisc) {
                miniDisc = rightRes.distance;
                a = rightRes.a;
                b = rightRes.b;
            }

            List<Point> Y_PRIME = new List<Point>();
            for (int i = halfCount-1; i == 0; i --) {
                if (XLeft[i].X > middle_x - miniDisc)
                {
                    Y_PRIME.Add(XLeft[i]);
                }
                else {
                    break;
                }
                
            }
            for (int i = halfCount ; i < count; i++)
            {
                int index = i - halfCount;
                if (YRight[index].X < middle_x + miniDisc)
                {
                    Y_PRIME.Add(YRight[index]);
                }
                else
                {
                    break;
                }

            }
            Y_PRIME.Sort(ByY);
            for (int i = 0; i < Y_PRIME.Count -1 ; i ++) {
                for (int j = i +1; j < i+ 7; j++ ) {
                    if (j >= Y_PRIME.Count) {
                        break;
                    }
                    double distance = Distance(Y_PRIME[i], Y_PRIME[j]);
                    if (distance < miniDisc) {
                        miniDisc = distance;
                        a = Y_PRIME[i];
                        b = Y_PRIME[j];
                    }


                }

            }
            return (miniDisc, a, b);

        }

        private double Distance(Point a, Point b) {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        private List<Point> readInput(IAlgorithmInput input)
        {
            string[] lines = System.IO.File.ReadAllLines(input.GetInputFilePath());
            int n = int.Parse(lines[0]);
            input.setN(n);
            List<Point> result = new List<Point>(n);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splits = lines[i].Split(',');
                result.Add(new Point(splits[0], splits[1]));
            }
            return result;
        }

        private class Point
        {

            private bool right;

            private int x;

            private int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
                right = false;
            }

            public Point(string x, string y)
            {
                this.x = int.Parse(x);
                this.y = int.Parse(y);
                right = false;
            }

            public int X { get => x; set => x = value; }

            public int Y { get => y; set => y = value; }

            public bool Right { get => right; set => right = value; }

            public override string ToString()
            {
                return $"({X},{Y})";
            }
        }
    }
}
