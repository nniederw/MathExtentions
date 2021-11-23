using System;
using System.Collections.Generic;
using System.Numerics;

namespace MatrixCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            while (true)
            {
                if (count % 1000 == 0)
                {
                    Console.WriteLine(count);
                }
                Implication(GetRandomMatrix(), GetRandomMatrix());
                count++;
            }
        }
        private static Matrix<int> GetRandomMatrix()
        {
            Random random = new Random();
            var ints = new int[,] { { random.Next(0, 10), random.Next(0, 10) }, { random.Next(0, 10), random.Next(0, 10) } };
            return new Matrix<int>(2, 2, ints);
        }
        private static void Implication(Matrix<int> a, Matrix<int> b)
        {
            if (a * b != b * a)
            {
                if (a * a * b == a * b * a)
                {
                    Console.WriteLine($"Works: a = {a} b = {b}, ab = {a * b}, ba = {b * a}, aab = {a * a * b}, aba = {a * b * a}");
                }
            }
        }
    }
}