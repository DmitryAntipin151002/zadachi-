using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    enum BusType
    {
        Городской,
        Рейсовый,
        Туристический
    }
    class Bus : Car
    {
        public int SeatingCapacity { get; set; }
        public int TotalCapacity { get; set; }
        public BusType Type { get; set; }

        public override void Input()
        {
            base.Input();

            Console.WriteLine("Введите количество сидячих мест:");
            SeatingCapacity = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите общее количество мест:");
            TotalCapacity = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите тип автобуса (Городской, Рейсовый, Туристический):");
            Type = (BusType)Enum.Parse(typeof(BusType), Console.ReadLine(), true);
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Количество сидячих мест: {SeatingCapacity}");
            Console.WriteLine($"Общее количество мест: {TotalCapacity}");
            Console.WriteLine($"Тип автобуса: {Type}");
        }
    }
}
