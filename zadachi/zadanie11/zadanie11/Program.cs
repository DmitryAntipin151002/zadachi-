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
        int[] numbers = Array.ConvertAll(lines, int.Parse);

        // Фильтрация и сортировка положительных чисел
        List<int> positiveNumbers = numbers.Where(x => x > 0).ToList();

        // Запрос выбора направления сортировки
        Console.WriteLine("Выберите направление сортировки:");
        Console.WriteLine("1. По возрастанию");
        Console.WriteLine("2. По убыванию");
        Console.Write("Введите номер: ");
        int choice = int.Parse(Console.ReadLine());

        // Сортировка положительных чисел в выбранном направлении
        if (choice == 1)
        {
            positiveNumbers.Sort();
        }
        else if (choice == 2)
        {
            positiveNumbers.Sort((x, y) => y.CompareTo(x));
        }
        else
        {
            Console.WriteLine("Некорректный выбор. Программа будет завершена.");
            return;
        }

        // Запись отсортированных положительных чисел в файл
        string outputFilePath = "output.txt"; // путь к выходному файлу
        File.WriteAllLines(outputFilePath, positiveNumbers.Select(x => x.ToString()));

        Console.WriteLine("Отрицательные числа были удалены, а положительные числа были упорядочены и сохранены в файл.");
    }
}
