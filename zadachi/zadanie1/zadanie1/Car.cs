using System;

// Базовый класс Машина
public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int MaxSpeed { get; set; }

    public virtual void Input()
    {
        Console.WriteLine("Введите марку машины:");
        Brand = Console.ReadLine();

        Console.WriteLine("Введите модель машины:");
        Model = Console.ReadLine();

        Console.WriteLine("Введите год выпуска:");
        Year = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите максимальную скорость:");
        MaxSpeed = int.Parse(Console.ReadLine());
    }

    public virtual void Print()
    {
        Console.WriteLine($"Марка: {Brand}");
        Console.WriteLine($"Модель: {Model}");
        Console.WriteLine($"Год выпуска: {Year}");
        Console.WriteLine($"Максимальная скорость: {MaxSpeed}");
    }
}
