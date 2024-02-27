using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    enum TruckBodyType
    {
        Бортовой,
        Самосвал,
        Рефрижератор,
        Фургон
    }
    // Производный класс Грузовая машина
    class Truck : Car
    {
        public double LoadCapacity { get; set; }
        public int NumberOfAxles { get; set; }
        public TruckBodyType BodyType { get; set; }

        public override void Input()
        {
            base.Input();

            Console.WriteLine("Введите грузоподъемность в тоннах:");
            LoadCapacity = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество осей (2 или 3):");
            NumberOfAxles = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите тип кузова (Бортовой, Самосвал, Рефрижератор, Фургон):");
            BodyType = (TruckBodyType)Enum.Parse(typeof(TruckBodyType), Console.ReadLine(), true);
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Грузоподъемность: {LoadCapacity} тонн");
            Console.WriteLine($"Количество осей: {NumberOfAxles}");
            Console.WriteLine($"Тип кузова: {BodyType}");
        }
    }
}
