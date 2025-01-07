using Algera.Matrix;
namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Matrix matrix = new Matrix(3, 3);
            matrix.GetMatrix();
            double determinant = matrix.CalculateTheDeterminant(matrix.matrix , 0 , 0);
            double[,] adjoinMatrix = matrix.CalculateAdjointMatrix(matrix.matrix);

            Console.WriteLine($"The determinant of the matrix is {determinant}");
            Console.WriteLine("The adjoint matrix is : ");
            for (int i = 0; i < adjoinMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjoinMatrix.GetLength(1); j++)
                {
                    Console.Write(adjoinMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}