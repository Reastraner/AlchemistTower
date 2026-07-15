namespace AlchemistTower
{
    internal class MainMenu
    {
        private bool menuRunning;
        private int ReadNumber(int min, int max)
        {
            while (true)
            {
                int num;
                bool isInt = int.TryParse(Console.ReadLine(), out num);
                if (!isInt) Console.WriteLine("Введите число!!!");
                else if (num < min || num > max) Console.WriteLine("Выберите вариант из списка!");
                else return num;
            }
        }

        public void RunMenu()
        {
            menuRunning = true;
            while (menuRunning)
            {
                ShowMenu();
                int userChoice = ReadNumber(0, 3);
                if (userChoice == 0)
                    ExitMenu();
                else if (userChoice == 1)
                    StartGame();
                else if (userChoice == 2)
                    LoadGame();
                else if (userChoice == 3)
                    Credits();
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
            Game game = new Game();
            game.Start();
        }

        private void Credits()
        {
            Console.WriteLine("Игру для вас сделали: ");
            Console.WriteLine();
            Console.WriteLine("Программист и сценарист - Reastraner");
            Console.WriteLine();
            Console.WriteLine("Главный помощник - ChatGPT");
            Console.WriteLine();
        }

        private void LoadGame()
        {
            Console.WriteLine("Функция в разработке...");
            Console.WriteLine();
        }

        private void ExitMenu()
        {
            menuRunning = false;
        } 
    }
}
