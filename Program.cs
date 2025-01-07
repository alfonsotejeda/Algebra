using Algera.Matrix;
namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Matrix matrix = new Matrix(4, 4);
            matrix.GetMatrix();
            double determinant = matrix.CalculateTheDeterminant(matrix.matrix);
            Console.WriteLine($"The determinant of the matrix is {determinant}");
        }
    }
}