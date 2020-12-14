using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmProject.algorithms.greedy
{
    public class Matrix<T>
    {
        private T[,] data;

        public Matrix(T[,] data)
        {
            this.data = data;
        }
        public T this[int column, int row]
        {
            get
            {

                return (data[column - 1, row - 1]);


                
            }
            set
            {
                data[column - 1, row - 1] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {

                    sb.Append(data[i, j]);
                    if (j != data.GetLength(1) -1)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append(System.Environment.NewLine);
            }
            return sb.ToString();
        }
    }

    
}
