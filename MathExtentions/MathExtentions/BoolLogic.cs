namespace MathExtentions
{
    public static class BoolLogic
    {
        public static bool Implies(this bool b, bool other) => !(b && !other);
    }
}