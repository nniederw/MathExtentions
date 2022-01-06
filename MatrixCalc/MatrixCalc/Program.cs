using System;
namespace MatrixCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var im = MatrixType.Int(2, 2);
            var im2 = new Matrix<int>().New(2, 2);
            var lm = new Matrix<long>().New(2, 2);
        }
    }
}