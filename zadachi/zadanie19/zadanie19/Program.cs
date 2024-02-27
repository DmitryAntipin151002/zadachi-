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
        float[] numbers = Array.ConvertAll(lines, float.Parse);

        // Удаление локальных минимумов
        List<float> filteredNumbers = RemoveLocalMinima(numbers);

        // Преобразование чисел обратно в строки
        string[] filteredLines = Array.ConvertAll(filteredNumbers.ToArray(), x => x.ToString());

        // Запись отфильтрованных чисел в файл
        string outputFilePath = "output.txt"; // путь к выходному файлу
        File.WriteAllLines(outputFilePath, filteredLines);

        Console.WriteLine("Локальные минимумы были удалены из файла.");
    }

    static List<float> RemoveLocalMinima(float[] numbers)
    {
        List<float> filteredNumbers = new List<float>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (IsLocalMinimum(numbers, i))
            {
                i++; // Пропустить текущий минимум и перейти к следующему числу
            }
            else
            {
                filteredNumbers.Add(numbers[i]);
            }
        }

        return filteredNumbers;
    }

    static bool IsLocalMinimum(float[] numbers, int index)
    {
        int length = numbers.Length;

        if (length == 1)
        {
            // Если в файле только одно число, оно не является минимумом
            return false;
        }

        if (index == 0)
        {
            // Первое число может быть минимумом, если оно меньше второго числа
            return numbers[index] < numbers[index + 1];
        }
        else if (index == length - 1)
        {
            // Последнее число может быть минимумом, если оно меньше предыдущего числа
            return numbers[index] < numbers[index - 1];
        }
        else
        {
            // Число является минимумом, если оно меньше предыдущего и следующего чисел
            return numbers[index] < numbers[index - 1] && numbers[index] < numbers[index + 1];
        }
    }
}
