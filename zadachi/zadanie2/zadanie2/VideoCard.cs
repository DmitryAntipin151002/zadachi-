using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    enum InterfaceType
    {
        PCI,
        AGP,
        PCIExpress,
        PCIExpress2
    }
    class VideoCard : Component
    {
        public string VideoProcessor { get; set; }
        public int MemorySize { get; set; }
        public InterfaceType Interface { get; set; }

        public override void Input()
        {
            base.Input();

            Console.WriteLine("Введите видеопроцессор:");
            VideoProcessor = Console.ReadLine();

            Console.WriteLine("Введите количество встроенной памяти:");
            MemorySize = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите интерфейс подключения (PCI, AGP, PCIExpress, PCIExpress2):");
            Interface = (InterfaceType)Enum.Parse(typeof(InterfaceType), Console.ReadLine(), true);
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Видеопроцессор: {VideoProcessor}");
            Console.WriteLine($"Количество встроенной памяти: {MemorySize}");
            Console.WriteLine($"Интерфейс подключения: {Interface}");
        }
    }
}
