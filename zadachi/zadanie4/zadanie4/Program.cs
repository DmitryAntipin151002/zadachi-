using System;
using System.Collections.Generic;

enum AircraftType
{
    Passenger,
    Cargo
}

enum HelicopterRotorScheme
{
    Classic,
    Coaxial,
    TwinRotor
}

enum GasType
{
    Hydrogen,
    Helium
}

class Aircraft
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public AircraftType Type { get; set; }
    public int CruiseSpeed { get; set; }

    public virtual void Input()
    {
        Console.WriteLine("Введите марку:");
        Brand = Console.ReadLine();

        Console.WriteLine("Введите модель:");
        Model = Console.ReadLine();

        Console.WriteLine("Введите тип (пассажирский или грузовой):");
        Type = (AircraftType)Enum.Parse(typeof(AircraftType), Console.ReadLine(), true);

        Console.WriteLine("Введите крейсерскую скорость в км/ч:");
        CruiseSpeed = int.Parse(Console.ReadLine());
    }

    public virtual void Print()
    {
        Console.WriteLine($"Марка: {Brand}");
        Console.WriteLine($"Модель: {Model}");
        Console.WriteLine($"Тип: {Type}");
        Console.WriteLine($"Крейсерская скорость: {CruiseSpeed} км/ч");
    }
}

class Airplane : Aircraft
{
    public int Ceiling { get; set; }
    public int Wingspan { get; set; }
    public int RunwayLength { get; set; }

    public override void Input()
    {
        base.Input();

        Console.WriteLine("Введите потолок в метрах:");
        Ceiling = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите размах крыльев в метрах:");
        Wingspan = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите необходимую длину взлетной полосы в метрах:");
        RunwayLength = int.Parse(Console.ReadLine());
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Потолок: {Ceiling} м");
        Console.WriteLine($"Размах крыльев: {Wingspan} м");
        Console.WriteLine($"Длина взлетной полосы: {RunwayLength} м");
    }
}

class Helicopter : Aircraft
{
    public HelicopterRotorScheme RotorScheme { get; set; }
    public double MainRotorDiameter { get; set; }
    public double PayloadCapacity { get; set; }

    public override void Input()
    {
        base.Input();

        Console.WriteLine("Введите схему винтов (классическая, соосная, двухвинтовая):");
        RotorScheme = (HelicopterRotorScheme)Enum.Parse(typeof(HelicopterRotorScheme), Console.ReadLine(), true);

        Console.WriteLine("Введите диаметр основного винта в метрах:");
        MainRotorDiameter = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите грузоподъемность в тоннах:");
        PayloadCapacity = double.Parse(Console.ReadLine());
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Схема винтов: {RotorScheme}");
        Console.WriteLine($"Диаметр основного винта: {MainRotorDiameter} м");
        Console.WriteLine($"Грузоподъемность: {PayloadCapacity} т");
    }
}

class Airship : Aircraft
{
    public double BalloonVolume { get; set; }
    public GasType UsedGas { get; set; }
    public int CrewSize { get; set; }

    public override void Input()
    {
        base.Input();

        Console.WriteLine("Введите объем баллона в м³:");
        BalloonVolume = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите используемый газ (водород или гелий):");
        UsedGas = (GasType)Enum.Parse(typeof(GasType), Console.ReadLine(), true);

        Console.WriteLine("Введите численность экипажа:");
        CrewSize = int.Parse(Console.ReadLine());
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Объем баллона: {BalloonVolume} м³");
        Console.WriteLine($"Используемый газ: {UsedGas}");
        Console.WriteLine($"Численность экипажа: {CrewSize}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Aircraft> aircraftList = new List<Aircraft>();

        bool addMoreAircraft = true;
        while (addMoreAircraft)
        {
            Console.WriteLine("Выберите тип летательного аппарата (самолет, вертолет, дирижабль):");
            string aircraftType = Console.ReadLine();

            Aircraft aircraft;
            switch (aircraftType.ToLower())
            {
                case "самолет":
                    aircraft = new Airplane();
                    break;
                case "вертолет":
                    aircraft = new Helicopter();
                    break;
                case "дирижабль":
                    aircraft = new Airship();
                    break;
                default:
                    Console.WriteLine("Неверный тип летательного аппарата.");
                    continue;
            }

            aircraft.Input();
            aircraftList.Add(aircraft);

            Console.WriteLine("Добавить еще летательный аппарат? (да/нет):");
            addMoreAircraft = Console.ReadLine().ToLower() == "да";
        }

        Console.WriteLine("Выберите фильтр вывода (все летательные аппараты/только один):");
        string filter = Console.ReadLine();

        if (filter.ToLower() == "все летательные аппараты")
        {
            foreach (var aircraft in aircraftList)
            {
                aircraft.Print();
                Console.WriteLine();
            }
        }
        else if (filter.ToLower() == "только один")
        {
            Console.WriteLine("Введите порядковый номер летательного аппарата (начиная с 1):");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < aircraftList.Count)
            {
                aircraftList[index].Print();
            }
            else
            {
                Console.WriteLine("Неверный порядковый номер летательного аппарата.");
            }
        }
        else
        {
            Console.WriteLine("Неверный фильтр вывода.");
        }
    }
}
