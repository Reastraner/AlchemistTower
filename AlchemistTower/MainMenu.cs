namespace AlchemistTower
{
    internal class MainMenu
    {
        private bool menuRunning;
        
        public void RunMenu()
        {
            menuRunning = true;

            while (menuRunning)
            {
                Console.Clear();
                ShowMenu();

                int userChoice = ReadNumber(0, 3);
                switch (userChoice)
                {
                    case 0:
                        ExitMenu();
                        break;
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        LoadGame();
                        break;
                    case 3:
                        ShowCredits();
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("Добро пожаловать в башню алхимика!!!");
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.WriteLine("Выбери вариант:");
            Console.WriteLine();
            Console.WriteLine("1 - Новая игра");
            Console.WriteLine("2 - Загрузить игру");
            Console.WriteLine("3 - Авторы");
            Console.WriteLine();
            Console.WriteLine("0 - Выход");
            Console.WriteLine();
        }

        private void StartGame()
        {
            new Game().Start();
        }

        private void ShowCredits()
        {
            Console.Clear();

            Console.WriteLine("Игру для вас сделали: ");
            Console.WriteLine();
            Console.WriteLine("Программист и сценарист - Reastraner");
            Console.WriteLine("Главный помощник - ChatGPT");
            Pause();
            
        }

        private void LoadGame()
        {
            Console.Clear();

            Console.WriteLine("Функция в разработке...");
            
            Pause();
        }

        private void ExitMenu()
        {
            menuRunning = false;
        }

        private int ReadNumber(int min, int max)
        {
            while (true)
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out int number);
                if (!isNumber) Console.WriteLine("Введите число!");
                else if (number < min || number > max) Console.WriteLine("Выберите вариант из списка!");
                else return number;
            }
        }

        private void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey(true);
        }
    }
}
