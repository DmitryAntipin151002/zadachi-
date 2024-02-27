using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
  public  class Component
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public virtual void Input()
        {
            Console.WriteLine("Введите производителя:");
            Manufacturer = Console.ReadLine();

            Console.WriteLine("Введите модель:");
            Model = Console.ReadLine();

            Console.WriteLine("Введите год начала выпуска:");
            Year = int.Parse(Console.ReadLine());
        }

        public virtual void Print()
        {
            Console.WriteLine($"Производитель: {Manufacturer}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Год начала выпуска: {Year}");
        }
    }
}
