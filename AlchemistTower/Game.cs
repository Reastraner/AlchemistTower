namespace AlchemistTower
{
    internal class Game
    {
        private bool gameRunning;
        private bool passageFound = false;
        private bool keyFound = false;
        private string currentLocation = "Dungeon";
        private Player player;
        int alchemistDialogueStage = 0;
        bool weaknessFound;

        public void Start()
        {
            player = new Player();   
            gameRunning = true;
            ShowIntro();
            Pause();
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
                else if (currentLocation == "TowerEntrance") TowerEntrance();
                else if (currentLocation == "Tower") Tower();
                else if (currentLocation == "Spire") Spire();
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
            Console.Clear();

            Room dungeon = new Room("Темница", "Темница встречает тебя холодом и тяжёлой сыростью.\r\n\r\nНеровные каменные стены блестят от воды, а в углах копится густая темнота. За проржавевшей решёткой тянется узкий проход, уходящий куда-то в глубь башни.\r\n\r\nНа полу лежат обломки старых цепей. Судя по слою пыли, ими давно никто не пользовался.\r\n\r\nОткуда-то сверху доносится едва слышный гул.");
            ShowRoom(dungeon);

            Console.WriteLine("Что ты хочешь сделать?");
            Console.WriteLine();
            Console.WriteLine("1 - Осмотреть замок");
            Console.WriteLine("2 - Осмотреть решётку");
            Console.WriteLine("3 - Осмотреть помещение");
            Console.WriteLine("4 - Попытаться выбраться");
            Console.WriteLine();
            Console.WriteLine("9 - Инвентарь");
            Console.WriteLine("0 - Выйти в главное меню");

            int userChoice = ReadChoice(0, 4);
            if (userChoice == 0) gameRunning = false;

            else if (userChoice == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Ты осматриваешь замок и понимаешь, что вскрыть его нечем и вырвать силой его не получится...");
                Console.WriteLine();
                Pause();
            }

            else if (userChoice == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Решётка выглядит неприступной, прутья крепкие и через них не пробраться...");
                Console.WriteLine();
                Pause();
            }

            else if (userChoice == 3 && !passageFound)
            {
                Console.WriteLine();
                Console.WriteLine("Осматривая помещение внимательнее, ты замечаешь, что одна из стен частично скрыта под грудой старых камней и сгнивших досок.");
                Console.WriteLine("Разгребая мусор, ты обнаруживаешь узкий лаз.");
                Console.WriteLine("Такое ощущение, будто кто-то уже пытался выбраться отсюда задолго до тебя...");
                Console.WriteLine();
                passageFound = true;
                Pause();
            }

            else if (userChoice == 3 && passageFound)
            {
                Console.WriteLine();
                Console.WriteLine("Ты снова осматриваешь помещение.");
                Console.WriteLine("Ничего нового обнаружить не удаётся.");
                Console.WriteLine();
                Pause();
            }

            else if (userChoice == 4 && !passageFound)
            {
                Console.WriteLine();
                Console.WriteLine("Ты не находишь ни одного пути наружу. Нужно осмотреть помещение внимательнее.");
                Console.WriteLine();
                Pause();
            }

            else if (userChoice == 4 && passageFound)
            {
                Console.WriteLine();
                Console.WriteLine("Ты протискиваешься в найденный лаз и успешно покидаешь темницу!");
                Console.WriteLine();
                Pause();

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
            Console.WriteLine("9 - Инвентарь");
            Console.WriteLine("0 - Выход");


            int userChoice = ReadChoice(0, 3);

            if (userChoice == 0)
            {
                gameRunning = false;
            }
            else if (userChoice == 1)
            {
                Console.WriteLine("Ты долго идешь вперед, в конце пути тебя поджидает огромных размеров дверь, что же за ней...");
                Pause();
                currentLocation = "TowerEntrance";
            }
            else if (userChoice == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Кроме влажных стен, камней и следов давно высохшей воды ты ничего полезного не находишь.");
                Console.WriteLine();
                Pause();
            }
            else if (userChoice == 3)
            {
                Console.WriteLine("Пасхалка, сука!");
                Pause();
            }
        }

        private void TowerEntrance()
        {
            Console.Clear();

            Room towerEntrance = new Room("Вход в башню", "Свет слепит тебе глаза, ты стоишь возле нереальных размеров башни, шпиль которой уходит так высоко, что кажется, будто он пронзает сами небеса");
            ShowRoom(towerEntrance);

            Console.WriteLine("Твой выбор");
            Console.WriteLine();
            Console.WriteLine("1 - Зайти в башню");
            Console.WriteLine("2 - Осмотреться");
            Console.WriteLine();
            Console.WriteLine("9 - Инвентарь");
            Console.WriteLine("0 - Выход");

            int userChoice = ReadChoice(0,2);

            if (userChoice == 0)
            {
                gameRunning = false;
            }
            else if (userChoice == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Тяжёлая дверь поддаётся с протяжным скрежетом. Ты переступаешь порог башни.");
                Console.WriteLine();
                Pause();

                currentLocation = "Tower";
            }
            else if (userChoice == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Башня выглядит заброшенной, но изнутри доносится едва различимый металлический звон.");
                Console.WriteLine("Обойти её снаружи невозможно: отвесные скалы окружают строение со всех сторон.");
                Console.WriteLine();

                if (!keyFound)
                {
                    Item key = new Item("Ключ","Огромный ключ, на котором начертаны руны, от чего же он?");
                    player.Inventory.AddItem(key);
                    keyFound = true;
                    Console.WriteLine($"В кусте неподалёку ты находишь {key.Name}");
                }
                else
                {
                    Console.WriteLine("Ты осматриваешь другие кусты, но в них пусто");
                } 

                Pause();
            }
        }

        private void Tower()
        {
            Console.Clear();

            Room tower = new Room("Башня", "За массивной дверью скрывается круглый зал. Каменные ступени уходят вверх, теряясь во мраке.");
            ShowRoom(tower);

            Console.WriteLine("Твой выбор:");
            Console.WriteLine();
            Console.WriteLine("1 - Подняться к шпилю");
            Console.WriteLine("2 - Осмотреть зал");
            Console.WriteLine();
            Console.WriteLine("9 - Инвентарь");
            Console.WriteLine("0 - Выход");

            int userChoice = ReadChoice(0, 2);

            if (userChoice == 0)
            {
                gameRunning = false;
            }
            else if (userChoice == 1)
            {
                if (player.Inventory.HasItem("Ключ"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Ты вставляешь ключ в замочную скважину и повернув его попадаешь в лифт, который начинает медленно ползти вверх...");
                    Console.WriteLine();
                    Pause();

                    currentLocation = "Spire";
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Дверь, ведущая наверх, заперта. В замочной скважине виден необычный механизм.");
                    Console.WriteLine();
                    Pause();
                }
                
            }
            else if (userChoice == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Среди разрушенной мебели и пустых шкафов может скрываться что-то полезное.");
                Console.WriteLine();
                Pause();
            }
        }

        private void Spire()
        {
            Console.Clear();

            Room spire = new Room("Шпиль башни", "Высоко под сводами башни раскинулся просторный зал. Тусклый свет проникает сквозь узкие окна, выхватывая из полумрака столы, стеклянные сосуды и сложные механизмы. В глубине помещения стоит незнакомый мужчина, спокойно наблюдающий за тобой.\r\n");
            ShowRoom(spire);

            Console.WriteLine("Твой выбор:");
            Console.WriteLine();
            Console.WriteLine("1 - Поговорить");
            Console.WriteLine("2 - Осмотреть помещение");
            if (alchemistDialogueStage >= 7)
            {
                Console.WriteLine("3 - Остаться с алхимиком");
            }
            Console.WriteLine();
            Console.WriteLine("9 - Инвентарь");
            Console.WriteLine("0 - Выход");
            Console.WriteLine();

            int maxChoice = alchemistDialogueStage >= 7 ? 3 : 2;
            int userChoice = ReadChoice(0, maxChoice);
            
            if (userChoice == 0)
                gameRunning = false;
            else if (userChoice == 1) 
            {
                if (alchemistDialogueStage == 0)
                {
                    Console.WriteLine("Мужчина медленно откладывает инструмент и смотрит на тебя.");
                    Console.WriteLine("— Ты всё-таки добрался.");
                    Pause();
                    alchemistDialogueStage += 1;
                }
                else if (alchemistDialogueStage == 1)
                {
                    Console.WriteLine("- Судя по твоему взгляду, ты не помнишь меня?");
                    Console.WriteLine("Мужчина едва заметно усмехается");
                    Console.WriteLine("- Меня называют Алхимиком. Я хозяин этой башни и прилегающих территорий");
                    Pause();
                    alchemistDialogueStage++;
                }
                else if (alchemistDialogueStage == 2)
                {
                    Console.WriteLine("Алхимик замечает немой вопрос в твоих глазах.");
                    Console.WriteLine("- Да, это я тот, кто запер тебя внизу");
                    Pause();
                    alchemistDialogueStage++;
                }
                else if (alchemistDialogueStage == 3)
                {
                    Console.WriteLine("- И как всегда, ненадолго.");
                    Console.WriteLine("Алхимик медленно переводит взляд на механизм в глубине зала");
                    Console.WriteLine("- Ты всегда находишь чертов путь сюда.");
                    Pause();
                    alchemistDialogueStage++;
                }
                else if (alchemistDialogueStage == 4)
                {
                    Console.WriteLine("- Думаешь, ты почти выбрался, вот она свобода? Только руку протяни.");
                    Console.WriteLine("Алхимик смотрит на тебя почти с сожалением.");
                    Console.WriteLine("- Но уверен ли ты, что имено её ты ищешь?");
                    Pause();
                    alchemistDialogueStage++;
                }
                else if (alchemistDialogueStage == 5)
                {
                    Console.WriteLine("- Я мог бы снова запереть тебя внизу.");
                    Console.WriteLine("Алхимик ненадолго замолкает");
                    Console.WriteLine("- Но есть ли в этом смысл? Я дам этот выбор тебе.");
                    Pause();
                    alchemistDialogueStage++;
                }
                else if (alchemistDialogueStage == 6)
                {
                    Console.WriteLine("- Выбор за тобой остаться здесь или сгнить в темнице.");
                    Console.WriteLine("Алхимик отворачивается к механизму");
                    Console.WriteLine("- Я не позволю еще раз обнулить мир...");
                    Pause();
                    alchemistDialogueStage++;
                }
                else if (alchemistDialogueStage == 7)
                {
                    Console.WriteLine("- Мне больше нечего тебе сказать...");
                    Pause();
                }

            }
            else if (userChoice == 2)
            {
                Console.WriteLine("Ты внимательно осматриваешь помещение");
                Pause();
            }
            else if (userChoice == 3)
            {
                Console.Clear();
                GoodEnding();
                Pause();
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
                else if(choice == 9)
                {
                    player.Inventory.ShowInventory();
                    Pause();
                    continue;
                }
                else if (choice < min || choice > max) Console.WriteLine("Выберите вариант из списка!");
                else return choice;
            }
        }

        private void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey(true);
        }
        
        private void GoodEnding()
        {
            Console.WriteLine("Ты медленно отходишь от механизма.");
            Console.WriteLine("Алхимик наблюдает за тобой, словно до последнего ожидая знакомого движения — рывка к порталу, удара по стеклу, очередной попытки вырваться.");
            Console.WriteLine("Но ты остаёшься на месте");
            Console.WriteLine("Впервые его лицо меняется. Не улыбка и не облегчение — лишь едва заметно исчезнувшее напряжение.");
            Console.WriteLine("— Значит, в этот раз всё будет иначе, — тихо произносит Алхимик.");
            Console.WriteLine("Он поворачивается к механизму, и золотистый свет внутри сосудов постепенно гаснет.");
            Console.WriteLine("Где-то далеко за стенами башни раздаётся глухой грохот. Мир продолжает существовать — хрупкий, израненный, но всё ещё живой.");
            Console.WriteLine("Ты не вспомнил, кем был.");
            Console.WriteLine("Но впервые сам решил, кем не станешь.");
            Console.WriteLine();
            Console.WriteLine("Истинная концовка: Разорванный цикл");
        }
    }
}
