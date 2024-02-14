using System;
using System.Globalization;
using System.IO;

class MatrixOperations
{
    static void Main()
    {
        int[,] matrixA, matrixB;
        int rowsA, columnsA, rowsB, columnsB;

        
        ReadMatrixFromFile("matrixA.txt", out matrixA, out rowsA, out columnsA);
        
        ReadMatrixFromFile("matrixB.txt", out matrixB, out rowsB, out columnsB);

        if (rowsA != rowsB || columnsA != columnsB)
        {
            Console.WriteLine("Невозможно выполнить операции: размеры матриц не совпадают.");
            return;
        }

        Console.WriteLine("Матрица A:");
        PrintMatrix(matrixA);
        Console.WriteLine("Матрица B:");
        PrintMatrix(matrixB);

        Console.WriteLine("Сумма матриц:");
        PrintMatrix(AddMatrices(matrixA, matrixB, rowsA, columnsA));

        Console.WriteLine("Разность матриц:");
        PrintMatrix(SubtractMatrices(matrixA, matrixB, rowsA, columnsA));

        if (columnsA != rowsB)
        {
            Console.WriteLine("Невозможно выполнить умножение матриц: количество столбцов матрицы A не совпадает с количеством строк матрицы B.");
            return;
        }

        Console.WriteLine("Произведение матриц:");
        PrintMatrix(MultiplyMatrices(matrixA, matrixB, rowsA, columnsA, columnsB));
    }

    static void ReadMatrixFromFile(string filename, out int[,] matrix, out int rows, out int columns)
    {
        string[] lines = File.ReadAllLines(filename);
        rows = lines.Length;
        columns = lines[0].Split(' ').Length;
        matrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            string[] elements = lines[i].Split(' ');
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = int.Parse(elements[j]);
            }
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static int[,] AddMatrices(int[,] matrixA, int[,] matrixB, int rows, int columns)
    {
        int[,] result = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }

        return result;
    }

    static int[,] SubtractMatrices(int[,] matrixA, int[,] matrixB, int rows, int columns)
    {
        int[,] result = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = matrixA[i, j] - matrixB[i, j];
            }
        }

        return result;
    }

    static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB, int rowsA, int columnsA, int columnsB)
    {
        int[,] result = new int[rowsA, columnsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < columnsB; j++)
            {
                for (int k = 0; k < columnsA; k++)
                {
                    result[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }

        return result;
    }
}