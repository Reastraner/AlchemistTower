using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

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
            GameLoop();
        }

        private void GameLoop()
        {
            while (gameRunning)
            {
                Console.WriteLine("Игровой цикл запущен!");
                gameRunning = false;
            }
        }
    }

}
