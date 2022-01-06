namespace MatrixCalc
{
    public class MatrixType
    {
        public static Matrix<int> Int(int rows, int columns) => new Matrix<int>(rows, columns, (a, b) => a + b, (a, b) => a * b);
        public static Matrix<int> Int(int[,] values) => new Matrix<int>(values, (a, b) => a + b, (a, b) => a * b);
        public static Matrix<long> Long(int rows, int columns) => new Matrix<long>(rows, columns, (a, b) => a + b, (a, b) => a * b);
        public static Matrix<long> Long(long[,] values) => new Matrix<long>(values, (a, b) => a + b, (a, b) => a * b);
        public static Matrix<float> Float(int rows, int columns) => new Matrix<float>(rows, columns, (a, b) => a + b, (a, b) => a * b);
        public static Matrix<float> Float(float[,] values) => new Matrix<float>(values, (a, b) => a + b, (a, b) => a * b);
        public static Matrix<double> Double(int rows, int columns) => new Matrix<double>(rows, columns, (a, b) => a + b, (a, b) => a * b);
        public static Matrix<double> Double(double[,] values) => new Matrix<double>(values, (a, b) => a + b, (a, b) => a * b);
        public static Matrix<decimal> Decimal(int rows, int columns) => new Matrix<decimal>(rows, columns, (a, b) => a + b, (a, b) => a * b);
        public static Matrix<decimal> Decimal(decimal[,] values) => new Matrix<decimal>(values, (a, b) => a + b, (a, b) => a * b);
    }
}