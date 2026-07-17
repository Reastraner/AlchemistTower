namespace AlchemistTower
{
    internal class Game
    {
        private bool gameRunning;
        private bool passageFound = false;
        private string currentLocation = "Dungeon";

        public void Start()
        {
            Player player = new Player();
            gameRunning = true;
            ShowIntro();
            Room dungeon = new Room("Темница", "Темница встречает тебя холодом и тяжёлой сыростью.\r\n\r\nНеровные каменные стены блестят от воды, а в углах копится густая темнота. За проржавевшей решёткой тянется узкий проход, уходящий куда-то в глубь башни.\r\n\r\nНа полу лежат обломки старых цепей. Судя по слою пыли, ими давно никто не пользовался.\r\n\r\nОткуда-то сверху доносится едва слышный гул.");
            ShowRoom(dungeon);
            GameLoop();
        }

        private void GameLoop()
        {
            while (gameRunning)
            {
                if (currentLocation == "Dungeon")
                {
                    Dungeon();
                }               
                else if (currentLocation == "CaveEntrance")
                {
                    CaveEntrance();
                }
            }
        }

        private void ShowIntro()
        {
            Console.WriteLine("Сознание возвращается медленно, будто кто-то вытаскивает тебя из вязкой чёрной воды.");
            Console.WriteLine("Первое, что ты чувствуешь, — холод. Каменный пол под спиной промёрз настолько, что ломит кости. В висках глухо стучит, во рту пересохло, а последние воспоминания рассыпаются, стоит попытаться за них ухватиться.");
            Console.WriteLine("Где-то рядом размеренно падают капли.");
            Console.WriteLine("Ты открываешь глаза.");
            Console.WriteLine("Над тобой — низкий свод, покрытый трещинами и чёрной плесенью. В воздухе пахнет сыростью, ржавчиной и чем-то горьким, почти лекарственным.");
            Console.WriteLine("Ты не знаешь, как оказался здесь.");
            Console.WriteLine("Но одно понимаешь сразу: это место не было создано для гостей.");
        }
        private void ShowRoom(Room room)
        {
            Console.WriteLine();
            Console.WriteLine(room.Name);
            Console.WriteLine("=================");
            Console.WriteLine(room.Description);
            Console.WriteLine();
        }
        private void Dungeon()
        {
            Console.WriteLine("Что вы хотите сделать?: ");
            Console.WriteLine();
            Console.WriteLine("1 - Осмотреть замок");
            Console.WriteLine("2 - Осмотреть решётку");
            Console.WriteLine("3 - Осмотреть помещение");
            Console.WriteLine("4 - Попытаться выбраться");
            Console.WriteLine();
            Console.WriteLine("0 - Выйти в главное меню");

            int userChoice = ReadChoice(0, 4);
            if (userChoice == 0) gameRunning = false;

            else if (userChoice == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Ты осматриваешь замок и понимаешь, что вскрыть его нечем и вырвать силой его не получится...");
                Console.WriteLine();
            }

            else if (userChoice == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Решётка выглядит неприступной, прутья крепкие и через них не пробраться...");
                Console.WriteLine();
            }

            else if (userChoice == 3 && !passageFound)
            {
                Console.WriteLine();
                Console.WriteLine("Осматривая помещение внимательнее, ты замечаешь, что одна из стен частично скрыта под грудой старых камней и сгнивших досок.");
                Console.WriteLine("Разгребая мусор, ты обнаруживаешь узкий лаз.");
                Console.WriteLine("Такое ощущение, будто кто-то уже пытался выбраться отсюда задолго до тебя...");
                Console.WriteLine();
                passageFound = true;
            }

            else if (userChoice == 3 && passageFound)
            {
                Console.WriteLine();
                Console.WriteLine("Ты снова осматриваешь помещение.");
                Console.WriteLine("Ничего нового обнаружить не удаётся.");
                Console.WriteLine();
            }

            else if (userChoice == 4 && !passageFound)
            {
                Console.WriteLine();
                Console.WriteLine("Ты не находишь ни одного пути наружу. Нужно осмотреть помещение внимательнее.");
                Console.WriteLine();
            }

            else if (userChoice == 4 && passageFound)
            {
                Console.WriteLine();
                Console.WriteLine("Ты протискиваешься в найденный лаз и успешно покидаешь темницу!");
                Console.WriteLine("Продолжение следует...");
                Console.WriteLine();
                currentLocation = "CaveEntrance";
            }
        }

        private void CaveEntrance()
        {
            Console.Clear();

            Room cave = new Room("Пещера","Узкий тоннель выводит тебя в сырую подземную пещеру...");
            ShowRoom(cave);

            Console.WriteLine("Твой выбор: ");
            Console.WriteLine();
            Console.WriteLine("1 - Идти дальше");
            Console.WriteLine("2 - Осмотреться");
            Console.WriteLine();
            Console.WriteLine("0 - Выход");


            int userChoice = ReadChoice(0, 3);

            if (userChoice == 0)
            {
                gameRunning = false;
            }
            else if (userChoice == 1)
            {
                gameRunning = false;
            }
            else if (userChoice == 2)
            {
                gameRunning = false;
            }
            else if (userChoice == 3)
            {
                Console.WriteLine("Пасхалка, сука!");
                gameRunning = false;
            }
        }

        private int ReadChoice(int min, int max)
        {
            while (true) 
            {
                int choice;
                bool isInt = int.TryParse(Console.ReadLine(), out choice);
                if (!isInt) Console.WriteLine("Введите число!");
                else if (choice < min || choice > max) Console.WriteLine("Выберите вариант из списка!");
                else return choice;
            }
        }
    }

}
