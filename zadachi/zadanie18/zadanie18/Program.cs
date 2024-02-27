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

        // Вставка нулевых значений перед каждой серией
        List<short> modifiedNumbers = InsertZeroesBeforeSeries(numbers);

        // Преобразование чисел обратно в строки
        string[] modifiedLines = Array.ConvertAll(modifiedNumbers.ToArray(), x => x.ToString());

        // Запись модифицированных чисел в файл
        string outputFilePath = "output.txt"; // путь к выходному файлу
        File.WriteAllLines(outputFilePath, modifiedLines);

        Console.WriteLine("Нулевые значения были вставлены перед каждой серией чисел в файле.");
    }

    static List<short> InsertZeroesBeforeSeries(short[] numbers)
    {
        List<short> modifiedNumbers = new List<short>();

        for (int i = 0; i < numbers.Length; i++)
        {
            modifiedNumbers.Add(0);

            while (i < numbers.Length && numbers[i] != 0)
            {
                modifiedNumbers.Add(numbers[i]);
                i++;
            }

            modifiedNumbers.Add(numbers[i]); // Добавить текущее число
        }

        return modifiedNumbers;
    }
}
