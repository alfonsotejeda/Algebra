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

        public double CalculateTheDeterminant(double [,] matrix , int row , int column)
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
            if(matrix.GetLength(0) == 3)
            {
                return matrix[0, 0] * matrix[1, 1] * matrix[2, 2] + matrix[0, 1] * matrix[1, 2] * matrix[2, 0] + matrix[0, 2] * matrix[1, 0] * matrix[2, 1] - matrix[0, 2] * matrix[1, 1] * matrix[2, 0] - matrix[0, 1] * matrix[1, 0] * matrix[2, 2] - matrix[0, 0] * matrix[1, 2] * matrix[2, 1];
            }
            double[] determinat = new double[matrix.GetLength(1)];
            for(int i = column ; i < matrix.GetLength(1);i++)
            {
                determinat[i] = Math.Pow(-1,i) * matrix[i,0] * CalculateTheDeterminant(GetMinors(matrix , i , column) , row , column);
            }
            return determinat.Sum();
        }
        private double[,] GetMinors(double[,] matrix, int elementrow, int elementcolumn)
        {
            int rows = matrix.GetLength(0) - 1;
            int columns =  matrix.GetLength(1) - 1;
            double[,] minorsMatrix = new double[rows,columns];
            for (int i = 0; i < rows+1; i++)
            {
                if (i == elementrow)
                {
                    continue;
                }
                for (int j = 0; j < columns+1; j++) 
                {
                    if(j == elementcolumn)
                    {
                        continue;
                    }
                    minorsMatrix[i > elementrow ? i - 1 : i, j > elementcolumn ? j - 1 : j] = matrix[i, j];
                }
                
            }
            return minorsMatrix;
        }
        
        public double[,] CalculateAdjointMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns =  matrix.GetLength(1);
            double[,] cofactorsMatrix = new double[rows , columns];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    cofactorsMatrix[i,j] = Math.Pow(-1,i+j) * CalculateTheDeterminant(GetMinors(matrix,i,j), i , j);
                }
            }
            double[,] adjoinMatrix = TransposeMatrix(cofactorsMatrix);
            return adjoinMatrix;
        }
        private double[,] TransposeMatrix(double[,] matrix)
        {
            double[,] transposeMatrix = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    transposeMatrix[i, j] = matrix[j, i];
                }
            }
            return transposeMatrix;
        }
    }    
}