using zadanie2;

class Program
{
    static void Main(string[] args)
    {
        List<Component> components = new List<Component>();

        while (true)
        {
            Console.WriteLine("Выберите тип комплектующего для добавления:");
            Console.WriteLine("1. Видео-карта");
            Console.WriteLine("2. Звуковая карта");
            Console.WriteLine("3. Модуль памяти");
            Console.WriteLine("4. Завершить ввод");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        VideoCard videoCard = new VideoCard();
                        videoCard.Input();
                        components.Add(videoCard);
                        break;
                    }
                case 2:
                    {
                        SoundCard soundCard = new SoundCard();
                        soundCard.Input();
                        components.Add(soundCard);
                        break;
                    }
                case 3:
                    {
                        MemoryModule memoryModule = new MemoryModule();
                        memoryModule.Input();
                        components.Add(memoryModule);
                        break;
                    }
                case 4:
                    {
                        // Завершаем ввод
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Некорректный выбор. Пожалуйста, попробуйте еще раз.");
                        break;
                    }
            }

            if (choice == 4)
                break;
        }

        Console.WriteLine("Выберите фильтр вывода:");
        Console.WriteLine("1. Все комплектующие");
        Console.WriteLine("2. Одно комплектующее");

        int filterChoice = int.Parse(Console.ReadLine());

        if (filterChoice == 1)
        {
            foreach (Component component in components)
            {
                component.Print();
                Console.WriteLine();
            }
        }
        else if (filterChoice == 2)
        {
            Console.WriteLine("Введите индекс комплектующего:");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < components.Count)
            {
                Component component = components[index];
                component.Print();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Некорректный индекс. Пожалуйста, попробуйте еще раз.");
            }
        }
        else
        {
            Console.WriteLine("Некорректный выбор фильтра. Пожалуйста, попробуйте еще раз.");
        }
    }
}