using NUnit.Framework;
using MathExtentions;
using System;

namespace MathExtentionsTests
{
    public class RationalTests
    {
        private Rational RandomRational()
        {
            Random rng = new Random();
            int nomi = rng.Next(-10, 10);
            int denom = rng.Next(-10, 10);
            denom = denom != 0 ? denom : 1;
            return new Rational(nomi, denom);
        }
        [Test]
        public void TestSimple()
        {
            var zero = new Rational(0);
            var one = new Rational(1);
            var two = new Rational(2);
            Assert.True(one * one == one);
            Assert.True(one + one == two * one);
            Assert.True(one - one == zero);
            Assert.True(one / one == one);
            Assert.True(one / one == one);
            Assert.True(two / two == one);
        }
        [Test]
        public void Associativity()
        {
            for (int i = 0; i < 10; i++)
            {
                var r0 = RandomRational();
                var r1 = RandomRational();
                var r2 = RandomRational();
                Assert.True((r0 + r1) + r2 == r0 + (r1 + r2));
                Assert.True((r0 * r1) * r2 == r0 * (r1 * r2));
            }
        }
        [Test]
        public void Commutativity()
        {
            for (int i = 0; i < 10; i++)
            {
                var r0 = RandomRational();
                var r1 = RandomRational();
                Assert.True(r0 + r1 == r1 + r0);
                Assert.True(r0 * r1 == r1 * r0);
            }
        }
    }
}