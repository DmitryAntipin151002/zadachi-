using System;
using System.Collections.Generic;

enum PaperFormat
{
    A4,
    A3,
    A2,
    A1,
    A0
}

enum PrinterType
{
    DotMatrix,
    Inkjet,
    Laser
}

enum LightSource
{
    LED,
    Lamp,
    LaserDiode
}

enum ScanningElement
{
    CCD,
    MatrixCCD,
    CIS
}

enum InterfaceType
{
    USB,
    LAN,
    LPT,
    COM,
    IEEE1394
}

class PeripheralDevice
{
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public int ReleaseYear { get; set; }
    public PaperFormat Format { get; set; }

    public virtual void Input()
    {
        Console.WriteLine("Введите производителя:");
        Manufacturer = Console.ReadLine();

        Console.WriteLine("Введите модель:");
        Model = Console.ReadLine();

        Console.WriteLine("Введите год начала выпуска:");
        ReleaseYear = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите рабочий формат (A4, A3, A2, A1, A0):");
        Format = (PaperFormat)Enum.Parse(typeof(PaperFormat), Console.ReadLine(), true);
    }

    public virtual void Print()
    {
        Console.WriteLine($"Производитель: {Manufacturer}");
        Console.WriteLine($"Модель: {Model}");
        Console.WriteLine($"Год начала выпуска: {ReleaseYear}");
        Console.WriteLine($"Рабочий формат: {Format}");
    }
}

class Printer : PeripheralDevice
{
    public PrinterType Type { get; set; }
    public bool ColorSupport { get; set; }
    public int PrintingSpeed { get; set; }

    public override void Input()
    {
        base.Input();

        Console.WriteLine("Введите тип принтера (матричный, струйный, лазерный):");
        Type = (PrinterType)Enum.Parse(typeof(PrinterType), Console.ReadLine(), true);

        Console.WriteLine("Цветной принтер (да/нет):");
        ColorSupport = bool.Parse(Console.ReadLine());

        Console.WriteLine("Введите скорость печати (количество страниц в минуту):");
        PrintingSpeed = int.Parse(Console.ReadLine());
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Тип принтера: {Type}");
        Console.WriteLine($"Цветной принтер: {ColorSupport}");
        Console.WriteLine($"Скорость печати: {PrintingSpeed} стр/мин");
    }
}

class Scanner : PeripheralDevice
{
    public int DPI { get; set; }
    public LightSource LightSource { get; set; }
    public ScanningElement ScanningElement { get; set; }

    public override void Input()
    {
        base.Input();

        Console.WriteLine("Введите чувствительность в dpi:");
        DPI = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите источник света (светодиод, лампа, лазерный диод):");
        LightSource = (LightSource)Enum.Parse(typeof(LightSource), Console.ReadLine(), true);

        Console.WriteLine("Введите сканирующий элемент (CCD, MatrixCCD, CIS):");
        ScanningElement = (ScanningElement)Enum.Parse(typeof(ScanningElement), Console.ReadLine(), true);
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Чувствительность: {DPI} dpi");
        Console.WriteLine($"Источник света: {LightSource}");
        Console.WriteLine($"Сканирующий элемент: {ScanningElement}");
    }
}

class Plotter : PeripheralDevice
{
    public int ColorCount { get; set; }
    public bool RollFeedSupport { get; set; }
    public InterfaceType Interface { get; set; }

    public override void Input()
    {
        base.Input();

        Console.WriteLine("Введите количество цветов:");
        ColorCount = int.Parse(Console.ReadLine());

        Console.WriteLine("Поддержка подачи рулона (да/нет):");
        RollFeedSupport = bool.Parse(Console.ReadLine());

        Console.WriteLine("Введите интерфейс (USB, LAN, LPT, COM, IEEE1394):");
        Interface = (InterfaceType)Enum.Parse(typeof(InterfaceType), Console.ReadLine(), true);
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Количество цветов: {ColorCount}");
        Console.WriteLine($"Поддержка подачи рулона: {RollFeedSupport}");
        Console.WriteLine($"Интерфейс: {Interface}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<PeripheralDevice> devices = new List<PeripheralDevice>();

        bool addMoreDevices = true;
        while (addMoreDevices)
        {
            Console.WriteLine("Выберите тип периферийного устройства (принтер, сканер, плоттер):");
            string deviceType = Console.ReadLine();

            PeripheralDevice device;
            switch (deviceType.ToLower())
            {
                case "принтер":
                    device = new Printer();
                    break;
                case "сканер":
                    device = new Scanner();
                    break;
                case "плоттер":
                    device = new Plotter();
                    break;
                default:
                    Console.WriteLine("Неверный тип устройства.");
                    continue;
            }

            device.Input();
            devices.Add(device);

            Console.WriteLine("Добавить еще устройство? (да/нет):");
            addMoreDevices = Console.ReadLine().ToLower() == "да";
        }

        Console.WriteLine("Выберите фильтр вывода (все устройства/только одно):");
        string filter = Console.ReadLine();

        if (filter.ToLower() == "все устройства")
        {
            foreach (var device in devices)
            {
                device.Print();
                Console.WriteLine();
            }
        }
        else if (filter.ToLower() == "только одно")
        {
            Console.WriteLine("Введите порядковый номер устройства (начиная с 1):");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < devices.Count)
            {
                devices[index].Print();
            }
            else
            {
                Console.WriteLine("Неверный порядковый номер устройства.");
            }
        }
        else
        {
            Console.WriteLine("Неверный фильтр вывода.");
        }
    }
}
