using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    enum YesNo
    {
        Да,
        Нет
    }
    class SoundCard : Component
    {
        public string SoundChip { get; set; }
        public int SpeakerCount { get; set; }
        public YesNo HasSubwooferOutput { get; set; }
        public YesNo SupportsEAX { get; set; }

        public override void Input()
        {
            base.Input();

            Console.WriteLine("Введите звуковой чип:");
            SoundChip = Console.ReadLine();

            Console.WriteLine("Введите количество колонок:");
            SpeakerCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Наличие выхода на сабвуфер (да/нет):");
            HasSubwooferOutput = (YesNo)Enum.Parse(typeof(YesNo), Console.ReadLine(), true);

            Console.WriteLine("Поддержка EAX (да/нет):");
            SupportsEAX = (YesNo)Enum.Parse(typeof(YesNo), Console.ReadLine(), true);
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Звуковой чип: {SoundChip}");
            Console.WriteLine($"Количество колонок: {SpeakerCount}");
            Console.WriteLine($"Наличие выхода на сабвуфер: {HasSubwooferOutput}");
            Console.WriteLine($"Поддержка EAX: {SupportsEAX}");
        }
    }

}
