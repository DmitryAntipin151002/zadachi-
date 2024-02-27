using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Чтение содержимого файла
        string filePath = "C:\\Users\\Ray_Gek\\Desktop\\экзамен\\zadanie9\\input.txt"; // путь к файлу
        string[] lines = File.ReadAllLines(filePath);

        // Преобразование строк в числа
        long[] numbers = Array.ConvertAll(lines, long.Parse);

        // Поиск серий минимальной длины
        List<List<long>> series = FindMinLengthSeries(numbers);

        // Увеличение серий минимальной длины в два раза
        IncreaseSeriesLength(series);

        // Формирование обновленного списка чисел
        List<long> updatedNumbers = new List<long>();
        foreach (var numberList in series)
        {
            updatedNumbers.AddRange(numberList);
        }

        // Запись обновленного списка чисел в файл
        string outputFilePath = "C:\\Users\\Ray_Gek\\Desktop\\экзамен\\zadanie9\\output.txt"; // путь к выходному файлу
        File.WriteAllLines(outputFilePath, Array.ConvertAll(updatedNumbers.ToArray(), x => x.ToString()));

        Console.WriteLine("Серии минимальной длины были увеличены в два раза и сохранены в файл.");
    }

    static List<List<long>> FindMinLengthSeries(long[] numbers)
    {
        List<List<long>> series = new List<List<long>>();
        List<long> currentSeries = new List<long>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (currentSeries.Count == 0 || numbers[i] == currentSeries[currentSeries.Count - 1])
            {
                currentSeries.Add(numbers[i]);
            }
            else
            {
                series.Add(currentSeries);
                currentSeries = new List<long> { numbers[i] };
            }
        }

        series.Add(currentSeries); // Добавить последнюю серию в список

        return series;
    }

    static void IncreaseSeriesLength(List<List<long>> series)
    {
        int minLength = int.MaxValue;

        foreach (var numberList in series)
        {
            if (numberList.Count < minLength)
            {
                minLength = numberList.Count;
            }
        }

        foreach (var numberList in series)
        {
            if (numberList.Count == minLength)
            {
                for (int i = 0; i < minLength; i++)
                {
                    numberList.Add(numberList[i]);
                }
            }
        }
    }
}
