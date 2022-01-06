using System;
namespace MatrixCalc
{
    public class Matrix<T> : IEquatable<Matrix<T>>
    {
        public readonly int Rows;
        public readonly int Columns;
        public (int, int) Dimension => new(Rows, Columns);
        private T[,] Values;
        private Func<T, T, T> Add;
        private Func<T, T, T> Multiply;
        public Matrix() { }
        public Matrix(int rows, int columns, Func<T, T, T> add, Func<T, T, T> multiply)
        {
            if (columns <= 0 || rows <= 0) { throw new Exception($"Columns and Rows can't be 0 or negative. Input: columns = {columns}; rows = {rows}"); }
            Columns = columns;
            Rows = rows;
            Values = new T[Rows, Columns];
            Add = add;
            Multiply = multiply;
        }
        public Matrix(T[,] values, Func<T, T, T> add, Func<T, T, T> multiply) : this(values.GetLength(0), values.GetLength(1), add, multiply)
        {
            var res = new T[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    res[i, j] = values[i, j];
                }
            }
            Values = res;
        }
        public static Matrix<T> operator +(Matrix<T> left, Matrix<T> right)
        {
            if (left.Columns != right.Columns || left.Rows != right.Rows)
            { throw new Exception($"For adding two matrices, they need to have the same dimensions. Input dimensions: left = {left.Columns}, {left.Rows}; right = {right.Columns}, {right.Rows}"); }
            var result = new Matrix<T>(left.Rows, left.Columns, left.Add, left.Multiply);
            for (int i = 0; i < left.Rows; i++)
            {
                for (int j = 0; j < left.Columns; j++)
                {
                    result.Values[i, j] = left.Add(left.Values[i, j], right.Values[i, j]);
                }
            }
            return result;
        }
        public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
        {
            if (left.Columns != right.Rows)
            { throw new Exception($"For multipling two matrices, the columns of the left one needs to be the same as the rows of the right one. Input dimensions: left = {left.Columns}, {left.Rows}; right = {right.Columns}, {right.Rows}"); }
            var result = new Matrix<T>(left.Rows, right.Columns, left.Add, left.Multiply);
            for (int column = 0; column < result.Columns; column++)
            {
                for (int row = 0; row < result.Rows; row++)
                {
                    result.Values[row, column] = Sum(row, column);
                }
            }
            T Sum(int row, int column)
            {
                T res = default;
                for (int i = 0, j = 0; i < left.Columns; j++, i++)
                {
                    res = left.Add(res, left.Multiply(left.Values[row, i], right.Values[j, column]));
                }
                return res;
            }
            return result;
        }
        public static bool operator ==(Matrix<T> left, Matrix<T> right)
        {
            if (left.Dimension != right.Dimension) { return false; }
            for (int i = 0; i < left.Columns; i++)
            {
                for (int j = 0; j < left.Rows; j++)
                {
                    if (!left.Values[i, j].Equals(right.Values[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator !=(Matrix<T> left, Matrix<T> right)
        {
            if (left.Dimension != right.Dimension) { return true; }
            for (int i = 0; i < left.Columns; i++)
            {
                for (int j = 0; j < left.Rows; j++)
                {
                    if (!left.Values[i, j].Equals(right.Values[i, j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override string ToString()
        {
            string res = "{";
            for (int i = 0; i < Rows; i++)
            {
                if (i != 0)
                {
                    res += ", {";
                }
                else
                {
                    res += "{";
                }
                res = $"{res}{Values[i, 0]}";
                for (int j = 1; j < Columns; j++)
                {
                    res = $"{res}, {Values[i, j]}";
                }
                res += "}";
            }
            res += "}";
            return res;
        }
        public T this[int i, int j]
        {
            get { return Values[i, j]; }
            set { Values[i, j] = value; }
        }
        public bool Equals(Matrix<T> other) => this == other;
        public override bool Equals(object obj) => this == (Matrix<T>)obj;
        public override int GetHashCode() => HashCode.Combine(Values.GetHashCode(), Columns, Rows);
    }
}