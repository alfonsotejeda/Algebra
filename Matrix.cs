namespace Algera.Matrix
{
    public class Matrix
    {
        public double[,] matrix;
        private int rows;
        private int columns;

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrix = new double[rows, columns];
        }
        

        public void GetMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine($"Enter the value for row {i+1} and column {j+1}");
                    string input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                    {
                        matrix[i, j] = double.Parse(input);
                    }
                    else
                    {
                        throw new ArgumentNullException("Input cannot be null or empty");
                    }
                }
            }
        }

        public double CalculateTheDeterminant(double [,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException("The matrix must be square");
            }
            if (matrix.GetLength(0) == 1)
            {
                return matrix[0, 0];
            }
            if (matrix.GetLength(0) == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            double[] determinat = new double[matrix.GetLength(1)];
            for(int i = 0 ; i < matrix.GetLength(1);i++)
            {
                determinat[i] = Math.Pow(-1,i) * matrix[i,0] * CalculateTheDeterminant(GetCofactors(matrix , i , 0));
            }
            return determinat.Sum();
        }
        private double[,] GetCofactors(double[,] matrix, int row, int column)
        {
            int rows = matrix.GetLength(0) - 1;
            int columns =  matrix.GetLength(1) - 1;
            double[,] newMatrix = new double[rows,columns];
            for (int i = 0; i < rows+1; i++)
            {
                if (i == row)
                {
                    continue;
                }
                for (int j = 0; j < columns+1; j++)
                {
                    if(j == column)
                    {
                        continue;
                    }
                    newMatrix[i > row ? i - 1 : i, j > column ? j - 1 : j] = matrix[i, j];
                }
                
            }
            return newMatrix;
        }
    }
    
    
}