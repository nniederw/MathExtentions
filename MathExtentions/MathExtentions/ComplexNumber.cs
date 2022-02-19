using System;
namespace MathExtentions
{
    public struct ComplexNumber
    {
        public double Real { get; }
        public double Imaginary { get; }
        public static ComplexNumber zero => new ComplexNumber();
        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public double GetLengthSqr() => Real * Real + Imaginary * Imaginary;
        public double GetLength() => Math.Sqrt(GetLengthSqr());
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b) => new ComplexNumber(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b) => new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
        public static bool operator ==(ComplexNumber a, ComplexNumber b) => a.Real == b.Real && a.Imaginary == b.Imaginary;
        public static bool operator !=(ComplexNumber a, ComplexNumber b) => a.Real != b.Real || a.Imaginary != b.Imaginary;
        public override bool Equals(object obj) => ((ComplexNumber)obj) == this;
        public override int GetHashCode() => (Real + Imaginary).GetHashCode();
    }
}