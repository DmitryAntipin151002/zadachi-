using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Чтение содержимого файла
        string filePath = "input.txt"; // путь к файлу
        string[] lines = File.ReadAllLines(filePath);

        // Преобразование строк в числа
        double[] numbers = Array.ConvertAll(lines, double.Parse);

        // Разделение чисел на положительные и отрицательные
        var positiveNumbers = new List<double>();
        var negativeNumbers = new List<double>();

        foreach (var number in numbers)
        {
            if (number >= 0)
                positiveNumbers.Add(number);
            else
                negativeNumbers.Add(number);
        }

        // Объединение положительных и отрицательных чисел в новом порядке
        var updatedNumbers = positiveNumbers.Concat(negativeNumbers);

        // Преобразование чисел обратно в строки
        string[] updatedLines = Array.ConvertAll(updatedNumbers.ToArray(), x => x.ToString());

        // Запись обновленных чисел в файл
        string outputFilePath = "output.txt"; // путь к выходному файлу
        File.WriteAllLines(outputFilePath, updatedLines);

        Console.WriteLine("Числа были переставлены в файле так, чтобы сначала располагались положительные значения, а затем отрицательные.");
    }
}
