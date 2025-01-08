using Algera.Matrix;
namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double[,] matrixValues = new double[,]
            {
                {1, 3, 5, 9},
                {1, 3, 1, 7},
                {4, 3, 9, 7},
                {5, 2, 0, 9}
            };
            int row= 0;
            int column = 0;
            Console.Write("Enter the number of rows for the matrix: ");
            row = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of columns for the matrix: ");
            column = int.Parse(Console.ReadLine());

            Matrix matrix = new Matrix(row, column);
            // matrix.GetMatrix();
            double determinant = matrix.CalculateTheDeterminant(matrixValues , 0 , 0);
            Console.WriteLine($"The determinant of the matrix is {determinant}");
            double[,] adjoinMatrix = matrix.CalculateAdjointMatrix(matrixValues);

            
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