using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    enum MemoryType
    {
        DDR,
        DDR2,
        DDR3
    }
    class MemoryModule : Component
    {
        public int SizeMB { get; set; }
        public MemoryType Type { get; set; }
        public int Frequency { get; set; }
        public YesNo SupportsECC { get; set; }

        public override void Input()
        {
            base.Input();

            Console.WriteLine("Введите объем памяти в Мб:");
            SizeMB = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите тип памяти (DDR, DDR2, DDR3):");
            Type = (MemoryType)Enum.Parse(typeof(MemoryType), Console.ReadLine(), true);

            Console.WriteLine("Введите частоту памяти:");
            Frequency = int.Parse(Console.ReadLine());

            Console.WriteLine("Поддержка ECC (да/нет):");
            SupportsECC = (YesNo)Enum.Parse(typeof(YesNo), Console.ReadLine(), true);
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Объем памяти в Мб: {SizeMB}");
            Console.WriteLine($"Тип памяти: {Type}");
            Console.WriteLine($"Частота памяти: {Frequency}");
            Console.WriteLine($"Поддержка ECC: {SupportsECC}");
        }
    }
}
