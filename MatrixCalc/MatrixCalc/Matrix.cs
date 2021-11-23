using System;
namespace MatrixCalc
{
    public class Matrix<T> : IEquatable<Matrix<T>>
    {
        public readonly int Columns;
        public readonly int Rows;
        public (int, int) Dimension => new(Columns, Rows);
        private T[,] Values;
        public Matrix(int columns, int rows)
        {
            if (columns <= 0 || rows <= 0) { throw new Exception($"Columns and Rows can't be 0 or negative. Input: columns = {columns}; rows = {rows}"); }
            Columns = columns;
            Rows = rows;
            Values = new T[Columns, Rows];
            TestTOperations<T>();
        }
        public Matrix(int columns, int rows, T[,] values) : this(columns, rows)
        {
            if (values.GetLength(0) != columns || values.GetLength(1) != rows)
            {
                throw new Exception("The length of the input array needs to be the same size as the matrix");
            }
            var res = new T[columns, rows];
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
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
            var result = new Matrix<T>(left.Columns, left.Rows);
            for (int i = 0; i < left.Columns; i++)
            {
                for (int j = 0; j < left.Rows; j++)
                {
                    result.Values[i, j] = Plus(left.Values[i, j], right.Values[i, j]);
                }
            }
            return result;
        }
        public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
        {
            if (left.Columns != right.Columns || left.Rows != right.Rows)
            { throw new Exception($"For multipling two matrices, the rows of the left one needs to be the same as the columns of the right one. Input dimensions: left = {left.Columns}, {left.Rows}; right = {right.Columns}, {right.Rows}"); }
            var result = new Matrix<T>(left.Rows, right.Columns);
            for (int column = 0; column < result.Columns; column++)
            {
                for (int row = 0; row < result.Rows; row++)
                {
                    result.Values[column, row] = Sum(column, row);
                }
            }
            T Sum(int column, int row)
            {
                T res = default;
                int i = 0;
                for (int j = 0; j < right.Columns && i < left.Rows; j++)
                {
                    res = Plus(res, Multiply(left.Values[column, i], right.Values[j, row]));
                    i++;
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
        private static void TestTOperations<Type>()
        {
            try
            {
                Type test1 = default;
                Type test2 = default;
                dynamic test1d = test1;
                dynamic test2d = test2;
                Type result = test1d + test2d;
                result = test1d * test2d;
            }
            catch
            {
                throw new Exception($"The Type {nameof(Type)} can't be used for matrices");
            }
        }
        private static T Plus(T item1, T item2)
        {
            dynamic d1 = item1;
            dynamic d2 = item2;
            return d1 + d2;
        }
        private static T Multiply(T item1, T item2)
        {
            dynamic d1 = item1;
            dynamic d2 = item2;
            return d1 * d2;
        }
        public override string ToString()
        {
            string res = "{";
            for (int i = 0; i < Columns; i++)
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
                for (int j = 1; j < Rows; j++)
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