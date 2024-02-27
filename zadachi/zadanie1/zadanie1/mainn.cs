using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание списка объектов различных классов
            List<Car> cars = new List<Car>();

            while (true)
            {
                Console.WriteLine("Выберите тип машины для добавления (1 - Легковая, 2 - Грузовая, 3 - Автобус, 0 - Завершить):");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 0)
                    break;

                Car car;

                switch (choice)
                {
                    case 1:
                        car = new PassengerCar();
                        break;
                    case 2:
                        car = new Truck();
                        break;
                    case 3:
                        car = new Bus();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, попробуйте еще раз.");
                        continue;
                }

                car.Input();
                cars.Add(car);
            }

            Console.WriteLine("Выберите фильтр вывода (1 - Все классы, 2 - Один класс):");
            int filterChoice = int.Parse(Console.ReadLine());

            if (filterChoice == 1)
            {
                // Вывод всех объектов
                foreach (Car car in cars)
                {
                    car.Print();
                    Console.WriteLine();
                }
            }
            else if (filterChoice == 2)
            {
                // Вывод одного класса
                Console.WriteLine("Выберите класс для вывода (1 - Легковая, 2 - Грузовая, 3 - Автобус):");
                int classChoice = int.Parse(Console.ReadLine());

                Type selectedType;

                switch (classChoice)
                {
                    case 1:
                        selectedType = typeof(PassengerCar);
                        break;
                    case 2:
                        selectedType = typeof(Truck);
                        break;
                    case 3:
                        selectedType = typeof(Bus);
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, попробуйте еще раз.");
                        return;
                }

                // Вывод объектов выбранного класса
                foreach (Car car in cars)
                {
                    if (car.GetType() == selectedType)
                    {
                        car.Print();
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный выбор фильтра вывода.");
            }
        }
    }
}
