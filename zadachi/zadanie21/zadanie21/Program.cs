using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Запросить у пользователя число N
        Console.Write("Введите число N: ");
        byte n = byte.Parse(Console.ReadLine());

        // Чтение содержимого файла
        string filePath = "input.txt"; // путь к файлу
        byte[] numbers = File.ReadAllBytes(filePath);

        // Переписать в обратном порядке значения, кратные N
        ReverseMultiples(numbers, n);

        // Запись модифицированных чисел в файл
        File.WriteAllBytes(filePath, numbers);

        Console.WriteLine("Значения, кратные N, были переписаны в обратном порядке.");
    }

    static void ReverseMultiples(byte[] numbers, byte n)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % n == 0)
            {
                numbers[i] = ReverseByte(numbers[i]);
            }
        }
    }

    static byte ReverseByte(byte value)
    {
        return (byte)(((value & 0x01) << 7) |
                      ((value & 0x02) << 5) |
                      ((value & 0x04) << 3) |
                      ((value & 0x08) << 1) |
                      ((value & 0x10) >> 1) |
                      ((value & 0x20) >> 3) |
                      ((value & 0x40) >> 5) |
                      ((value & 0x80) >> 7));
    }
}
//Метод ReverseByte используется для переписывания значения в обратном порядке.