using System;

namespace MapAdventureGame
{
    public static class Game
    {
        public static void Start()
        {
            Map map = new Map(20, 20); // 20x20 boyutunda bir harita oluştur
            Player player = new Player(0, 0); // Oyuncuyu başlangıç noktasına yerleştir

            while (true)
            {
                map.Display(player);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                player.Move(keyInfo, map);
            }
        }
    }
}