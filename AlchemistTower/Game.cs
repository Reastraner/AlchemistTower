namespace AlchemistTower
{
    internal class Game
    {
        private bool gameRunning;
        public void Start()
        {
            Player player = new Player();
            gameRunning = true;
            Console.WriteLine("Добро пожаловать в башню алхимика!");
            ShowIntro();
            Room dungeon = new Room("Темница", "Темница встречает тебя холодом и тяжёлой сыростью.\r\n\r\nНеровные каменные стены блестят от воды, а в углах копится густая темнота. За проржавевшей решёткой тянется узкий проход, уходящий куда-то в глубь башни.\r\n\r\nНа полу лежат обломки старых цепей. Судя по слою пыли, ими давно никто не пользовался.\r\n\r\nОткуда-то сверху доносится едва слышный гул.");
            ShowRoom(dungeon);
            GameLoop();
        }

        private void GameLoop()
        {
            while (gameRunning)
            {
                
                if (Convert.ToInt32(Console.ReadLine()) == 0)
                    gameRunning = false;
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
        }
    }

}
