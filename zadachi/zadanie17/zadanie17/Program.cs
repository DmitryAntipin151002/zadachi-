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
        int[] numbers = Array.ConvertAll(lines, int.Parse);

        // Поиск возрастающей последовательности максимальной длины
        List<int> longestSequence = FindLongestIncreasingSequence(numbers);

        // Преобразование чисел обратно в строки
        string[] sequenceLines = Array.ConvertAll(longestSequence.ToArray(), x => x.ToString());

        // Запись найденной последовательности в конец файла
        string outputFilePath = "output.txt"; // путь к выходному файлу
        File.AppendAllLines(outputFilePath, sequenceLines);

        Console.WriteLine("Возрастающая последовательность максимальной длины была записана в конец файла.");
    }

    static List<int> FindLongestIncreasingSequence(int[] numbers)
    {
        int maxLength = 0;
        int maxIndex = -1;
        int currentLength = 1;
        int currentIndex = 0;

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                currentLength++;
            }
            else
            {
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxIndex = currentIndex;
                }

                currentIndex = i;
                currentLength = 1;
            }
        }

        if (currentLength > maxLength)
        {
            maxLength = currentLength;
            maxIndex = currentIndex;
        }

        // Формирование найденной последовательности
        List<int> longestSequence = new List<int>();
        for (int i = maxIndex; i < maxIndex + maxLength; i++)
        {
            longestSequence.Add(numbers[i]);
        }

        return longestSequence;
    }
}
