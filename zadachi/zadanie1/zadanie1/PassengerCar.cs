using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    enum CarBodyType
    {
        Универсал,
        Хэтчбек,
        Седан,
        Минивен,
        Джип
    }
    enum TransmissionType
    {
        Автомат,
        Ручная
    }
    class PassengerCar : Car
    {
        public CarBodyType BodyType { get; set; }
        public int NumberOfDoors { get; set; }
        public TransmissionType Transmission { get; set; }
        public string Color { get; set; }

        public override void Input()
        {
            base.Input();

            Console.WriteLine("Введите тип корпуса (Универсал, Хэтчбек, Седан, Минивен, Джип):");
            BodyType = (CarBodyType)Enum.Parse(typeof(CarBodyType), Console.ReadLine(), true);

            Console.WriteLine("Введите количество дверей:");
            NumberOfDoors = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите тип коробки передач (Автомат, Ручная):");
            Transmission = (TransmissionType)Enum.Parse(typeof(TransmissionType), Console.ReadLine(), true);

            Console.WriteLine("Введите цвет машины:");
            Color = Console.ReadLine();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Тип корпуса: {BodyType}");
            Console.WriteLine($"Количество дверей: {NumberOfDoors}");
            Console.WriteLine($"Коробка передач: {Transmission}");
            Console.WriteLine($"Цвет: {Color}");
        }
    }
}
