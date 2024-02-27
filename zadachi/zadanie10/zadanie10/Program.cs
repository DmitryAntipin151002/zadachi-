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

        // Поиск максимального и минимального значения
        double maxNumber = numbers[0];
        double minNumber = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > maxNumber)
            {
                maxNumber = numbers[i];
            }
            else if (numbers[i] < minNumber)
            {
                minNumber = numbers[i];
            }
        }

        // Фильтрация чисел, не находящихся между максимальным и минимальным значением
        List<double> filteredNumbers = new List<double>();

        bool deleteMode = false;
        foreach (var number in numbers)
        {
            if (number == minNumber)
            {
                deleteMode = true;
            }
            else if (number == maxNumber)
            {
                deleteMode = false;
            }

            if (!deleteMode)
            {
                filteredNumbers.Add(number);
            }
        }

        // Запись обновленного списка чисел в файл
        string outputFilePath = "output.txt"; // путь к выходному файлу
        File.WriteAllLines(outputFilePath, Array.ConvertAll(filteredNumbers.ToArray(), x => x.ToString()));

        Console.WriteLine("Числа, расположенные между максимальным и минимальным значением, были удалены из файла.");
    }
}
