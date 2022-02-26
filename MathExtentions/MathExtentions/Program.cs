using MathExtentions;
using System;
class Program
{
    static void Main(string[] args)
    {
        var r = new Rational(2, 4);
        var r2 = r * r;
        Console.WriteLine(r2);
        Console.WriteLine(r+r);

    }
}