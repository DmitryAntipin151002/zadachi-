using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Чтение содержимого файла
        string filePath = "input.txt"; // путь к файлу
        string[] lines = File.ReadAllLines(filePath);

        // Преобразование строк в числа
        double[] numbers = Array.ConvertAll(lines, double.Parse);

        // Вставка нулевых значений перед возрастающими последовательностями
        List<double> modifiedNumbers = InsertZerosBeforeIncreasingSequences(numbers);

        // Преобразование чисел обратно в строки
        string[] modifiedLines = Array.ConvertAll(modifiedNumbers.ToArray(), x => x.ToString());

        // Запись модифицированных чисел в файл
        string outputFilePath = "output.txt"; // путь к выходному файлу
        File.WriteAllLines(outputFilePath, modifiedLines);

        Console.WriteLine("Нули были вставлены перед возрастающими последовательностями чисел.");
    }

    static List<double> InsertZerosBeforeIncreasingSequences(double[] numbers)
    {
        List<double> modifiedNumbers = new List<double>();

        for (int i = 0; i < numbers.Length; i++)
        {
            modifiedNumbers.Add(numbers[i]);

            if (i < numbers.Length - 1 && numbers[i] < numbers[i + 1])
            {
                modifiedNumbers.Add(0); // Вставка нулевого значения перед возрастающей последовательностью
            }
        }

        return modifiedNumbers;
    }
}
