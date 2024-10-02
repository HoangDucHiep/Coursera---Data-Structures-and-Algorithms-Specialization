using System;

namespace Fibonacci
{
    class Program
    {

        public static int NthFibonacci(int n)
        {
            (int prev, int cur) tup= (0, 1);

            if(n <= 1)
            {
                return n;
            }

            for (int i = 0; i < n - 1; i++)
            {
                tup = (tup.cur, tup.cur + tup.prev);
            }

            return tup.cur;
        }


        static void Main(string[] args)
        {
            var input = Int32.Parse(Console.ReadLine());
            Console.Write(NthFibonacci(input));
        }
    }
}