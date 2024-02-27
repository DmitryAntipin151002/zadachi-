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
        float[] numbers = Array.ConvertAll(lines, float.Parse);

        // Поиск максимального и минимального значения
        float max = numbers.Max();
        float min = numbers.Min();

        // Запрос направления упорядочивания у пользователя
        Console.Write("Выберите направление упорядочивания (1 - по возрастанию, 2 - по убыванию): ");
        int direction = int.Parse(Console.ReadLine());

        // Отфильтровать числа между максимальным и минимальным значениями
        var filteredNumbers = numbers.Where(x => x > min && x < max).ToList();

        // Упорядочить числа в выбранном направлении
        if (direction == 1)
        {
            filteredNumbers.Sort();
        }
        else if (direction == 2)
        {
            filteredNumbers.Sort();
            filteredNumbers.Reverse();
        }
        else
        {
            Console.WriteLine("Некорректный выбор направления.");
            return;
        }

        // Обновление чисел в исходном массиве
        int index = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > min && numbers[i] < max)
            {
                numbers[i] = filteredNumbers[index];
                index++;
            }
        }

        // Преобразование чисел обратно в строки
        string[] updatedLines = Array.ConvertAll(numbers, x => x.ToString());

        // Запись обновленных чисел в файл
        string outputFilePath = "output.txt"; // путь к выходному файлу
        File.WriteAllLines(outputFilePath, updatedLines);

        Console.WriteLine("Числа между максимальным и минимальным значениями были упорядочены и сохранены в файл.");
    }
}
