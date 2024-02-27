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
        short[] numbers = Array.ConvertAll(lines, short.Parse);

        // Фильтрация простых чисел
        List<short> nonPrimeNumbers = FilterPrimeNumbers(numbers);

        // Запись непростых чисел в файл
        string outputFilePath = "output.txt"; // путь к выходному файлу
        File.WriteAllLines(outputFilePath, Array.ConvertAll(nonPrimeNumbers.ToArray(), x => x.ToString()));

        Console.WriteLine("Простые числа были удалены из файла.");
    }

    static List<short> FilterPrimeNumbers(short[] numbers)
    {
        List<short> nonPrimeNumbers = new List<short>();

        foreach (short number in numbers)
        {
            if (!IsPrime(number))
            {
                nonPrimeNumbers.Add(number);
            }
        }

        return nonPrimeNumbers;
    }

    static bool IsPrime(short number)
    {
        if (number < 2)
        {
            return false;
        }

        for (short i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
