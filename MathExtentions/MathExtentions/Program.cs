using MathExtentions;
using System;
class Program
{
    static void Main(string[] args)
    {
        new Rational(1, -10);
        new Rational(-1, 1);
        var r = RandomRational();
        Console.WriteLine(r);
        var r2 = RandomRational();
        Console.WriteLine(r2);
        Console.WriteLine(r*r2);
        Console.WriteLine(r+r2);
    }
    private static Rational RandomRational()
    {
        Random rng = new Random();
        int nomi = rng.Next(-10, 10);
        int denom = rng.Next(-10, 10);
        denom = denom != 0 ? denom : 1;
        return new Rational(nomi, denom);
    }
}