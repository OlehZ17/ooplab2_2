using System;

class Program
{
    static void Main(string[] args)
    {
        // Завдання 1
        int[] array = GenerateRandomArray(22, -10, 35);
        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        Array.Sort(array);
        Console.WriteLine("Вiдсортований масив:");
        PrintArray(array);

        int positiveNonMultipleOfThreeCount, positiveNonMultipleOfThreeSum;
        ReplacePositiveNonMultipleOfThreeWithZeros(array, out positiveNonMultipleOfThreeCount, out positiveNonMultipleOfThreeSum);

        Console.WriteLine("Кiлькiсть додатних некратних 3: {0}", positiveNonMultipleOfThreeCount);
        Console.WriteLine("Сума додатних некратних 3: {0}", positiveNonMultipleOfThreeSum);
        Console.WriteLine("Модифiкований масив:");
        PrintArray(array);


        // Завдання 2
        int[,] matrix = GenerateRandomMatrix(7, 9, -41, 23);
        Console.WriteLine("Початкова матриця:");
        PrintMatrix(matrix);

        SortMatrix(matrix);
        Console.WriteLine("Модифiкована матриця:");
        PrintMatrix(matrix);

        int positiveNonEvenIndexCount, positiveNonEvenIndexSum;
        CountPositiveNonEvenIndexElements(matrix, out positiveNonEvenIndexCount, out positiveNonEvenIndexSum);

        Console.WriteLine("Кiлькiсть елементiв, що задовольняють критерiй: {0}", positiveNonEvenIndexCount);
        Console.WriteLine("Сума елементiв, що задовольняють критерiй: {0}", positiveNonEvenIndexSum);
    }

    // Завдання 1: Функції для масиву

    static int[] GenerateRandomArray(int size, int minValue, int maxValue)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(minValue, maxValue + 1);
        }
        return array;
    }

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    static void ReplacePositiveNonMultipleOfThreeWithZeros(int[] array, out int count, out int sum)
    {
        count = 0;
        sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > 0 && array[i] % 3 != 0)
            {
                count++;
                sum += array[i];
                array[i] = 0;
            }
        }
    }

    // Завдання 2: Функції для матриці

    static int[,] GenerateRandomMatrix(int rows, int columns, int minValue, int maxValue)
    {
        Random random = new Random();
        int[,] matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }
        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }

    static void SortMatrix(int[,] matrix)
    {
        Array.Sort(GetRows(matrix), CompareRows);
    }

    static int[][] GetRows(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        int[][] rowsArray = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            rowsArray[i] = new int[columns];
            for (int j = 0; j < columns; j++)
            {
                rowsArray[i][j] = matrix[i, j];
            }
        }
        return rowsArray;
    }

    static int CompareRows(int[] row1, int[] row2)
    {
        if (HasDuplicates(row1) || HasDuplicates(row2))
        {
            return CompareRowsWithDuplicates(row1, row2);
        }
        return CompareRowsWithoutDuplicates(row1, row2);
    }

    static bool HasDuplicates(int[] row)
    {
        for (int i = 0; i < row.Length - 1; i++)
        {
            for (int j = i + 1; j < row.Length; j++)
            {
                if (row[i] == row[j])
                {
                    return true;
                }
            }
        }
        return false;
    }

    static int CompareRowsWithDuplicates(int[] row1, int[] row2)
    {
        int duplicatesInColumnCount = 0;
        for (int i = 0; i < row1.Length; i++)
        {
            if (row1[i] == row2[i])
            {
                duplicatesInColumnCount++;
            }
        }
        return duplicatesInColumnCount;
    }

    static int CompareRowsWithoutDuplicates(int[] row1, int[] row2)
    {
        for (int i = 0; i < row1.Length; i++)
        {
            if (row1[i] != row2[i])
            {
                return row1[i] - row2[i];
            }
        }
        return 0;
    }

    static void CountPositiveNonEvenIndexElements(int[,] matrix, out int count, out int sum)
    {
        count = 0;
        sum = 0;
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i, j] > 0 && j % 2 != 0)
                {
                    count++;
                    sum += matrix[i, j];
                }
            }
        }
    }
}


