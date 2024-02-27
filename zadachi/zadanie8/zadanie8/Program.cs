using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Запросить у пользователя число N
        Console.Write("Введите число N: ");
        int n = int.Parse(Console.ReadLine());

        // Чтение содержимого файла
        string filePath = "C:\\Users\\Ray_Gek\\Desktop\\экзамен\\zadanie8\\input.txt"; // путь к файлу
        string[] lines = File.ReadAllLines(filePath);

        // Формирование нового списка чисел без чисел, кратных N
        var filteredNumbers = RemoveMultiples(lines, n);

        // Запись нового списка чисел в файл
        string outputFilePath = "C:\\Users\\Ray_Gek\\Desktop\\экзамен\\zadanie8\\output.txt"; // путь к выходному файлу
        File.WriteAllLines(outputFilePath, filteredNumbers);

        Console.WriteLine("Числа, кратные N, были удалены из файла.");
    }

    static string[] RemoveMultiples(string[] lines, int n)
    {
        // Фильтрация чисел, не кратных N
        var filteredNumbers = Array.FindAll(lines, line =>
        {
            short number;
            if (short.TryParse(line, out number))
            {
                if (number % n != 0)
                    return true;
            }
            return false;
        });

        return filteredNumbers;
    }
}
