using MathExtentions;
using System;
class Program
{
    static void Main(string[] args)
    {
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