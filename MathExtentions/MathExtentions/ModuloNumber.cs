using System;
namespace MathExtentions
{
    public struct ModuloNumber
    {
        public int Modulo { get; private set; }
        public int Value { get; private set; }
        public ModuloNumber(int modulo, int value)
        {
            Modulo = modulo;
            Value = value % modulo;
        }
        public ModuloNumber Set(int value)
        {
            Value = value % Modulo;
            return this;
        }
        public ModuloNumber MultInverse()
        {
            if (Value == Modulo - 1)
            {
                return new ModuloNumber(Modulo, Value);
            }
            var neutral = new ModuloNumber(Modulo, 1);
            var m = neutral;
            for (int i = 1; i < Modulo - 1; i++)
            {
                m.Value = i;
                if (this * m == neutral)
                {
                    return m;
                }
            }
            return new ModuloNumber(Modulo, 0);
        }
        public static bool operator ==(ModuloNumber m1, ModuloNumber m2)
        {
            AssertSameModuloType(m1, m2);
            return m1.Value == m2.Value;
        }
        public static bool operator !=(ModuloNumber m1, ModuloNumber m2)
        {
            AssertSameModuloType(m1, m2);
            return m1.Value != m2.Value;
        }
        public static ModuloNumber operator +(ModuloNumber m1, ModuloNumber m2)
        {
            AssertSameModuloType(m1, m2);
            return m1.Set(m1.Value + m2.Value);
        }
        public static ModuloNumber operator *(ModuloNumber m1, ModuloNumber m2)
        {
            AssertSameModuloType(m1, m2);
            return m1.Set(m1.Value * m2.Value);
        }
        public override bool Equals(object obj) => (ModuloNumber)obj == this;
        public override int GetHashCode() => HashCode.Combine(Value, Modulo);
        private static void AssertSameModuloType(ModuloNumber m1, ModuloNumber m2)
        { if (m1.Modulo != m2.Modulo) { throw new Exception(); } }
        public override string ToString() => Value.ToString();
    }
}