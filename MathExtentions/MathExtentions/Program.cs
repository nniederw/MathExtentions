using MathExtentions;
using System;
class Program
{
    static void Main(string[] args)
    {
        for (int modulo = 3; modulo < 21; modulo++)
        {
            Console.WriteLine($"modulo {modulo}");
            for (int i = 2; i < modulo; i++)
            {
                Console.Write($"{new ModuloNumber(modulo,i).MultInverse()} ");
            }
            Console.WriteLine();
        }
        var m = new ModuloNumber(5,1);
    }
}