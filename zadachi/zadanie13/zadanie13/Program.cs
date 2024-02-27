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

        // Вычисление среднего арифметического
        double average = numbers.Average();

        // Увеличение значений меньше среднего арифметического в два раза
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < average)
            {
                numbers[i] *= 2;
            }
        }

        // Преобразование чисел обратно в строки
        string[] updatedLines = Array.ConvertAll(numbers, x => x.ToString());

        // Запись обновленных чисел в файл
        string outputFilePath = "output.txt"; // путь к выходному файлу
        File.WriteAllLines(outputFilePath, updatedLines);

        Console.WriteLine("Значения меньше среднего арифметического были увеличены в два раза и сохранены в файл.");
    }
}
