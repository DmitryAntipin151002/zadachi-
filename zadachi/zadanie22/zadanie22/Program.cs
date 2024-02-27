using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Запросить у пользователя число N
        Console.Write("Введите длину серии N: ");
        int n = int.Parse(Console.ReadLine());

        // Чтение содержимого файла
        string filePath = "input.txt"; // путь к файлу
        string[] lines = File.ReadAllLines(filePath);

        // Преобразование строк в числа
        long[] numbers = Array.ConvertAll(lines, long.Parse);

        // Увеличение каждой серии длины N на один элемент
        IncreaseSeriesLength(numbers, n);

        // Формирование обновленного списка чисел
        List<long> updatedNumbers = new List<long>(numbers);

        // Запись обновленного списка чисел в файл
        string outputFilePath = "output.txt"; // путь к выходному файлу
        File.WriteAllLines(outputFilePath, Array.ConvertAll(updatedNumbers.ToArray(), x => x.ToString()));

        Console.WriteLine("Каждая серия длины N была увеличена на один элемент и сохранена в файл.");
    }

    static void IncreaseSeriesLength(long[] numbers, int n)
    {
        int count = 0; // Счетчик элементов в текущей серии
        long prev = numbers[0]; // Предыдущий элемент

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == prev)
            {
                count++;
                if (count == n)
                {
                    // Увеличить серию на один элемент
                    Array.Resize(ref numbers, numbers.Length + 1);
                    Array.Copy(numbers, i, numbers, i + 1, numbers.Length - i - 1);
                    numbers[i] = prev;
                    count = 0; // Сбросить счетчик
                    i++; // Пропустить добавленный элемент
                }
            }
            else
            {
                count = 0; // Сбросить счетчик
            }

            prev = numbers[i]; // Обновить предыдущий элемент
        }
    }
}
