using System;
using System.Collections.Generic;

namespace GenericTest
{
    class MyTest<T>
    {
        private T[] items = new T[3];
        private int index = 0;
        //向数组中添加项
        public void Add(T t)
        {
            if (index < 3)
            {
                items[index] = t;
                index++;
            }
            else
            {
                Console.WriteLine("数组已满！");
            }
        }
        public  static void Add<S>(S a, S b)
        {
            double sum = double.Parse(a.ToString()) + double.Parse(b.ToString());
            Console.WriteLine(sum);
        }
        //读取数组中的全部项
        public void Show()
        {
            foreach (T t in items)
            {
                Console.WriteLine(t);
            }
        }
    }
    class Program
    {
        
    }
}
