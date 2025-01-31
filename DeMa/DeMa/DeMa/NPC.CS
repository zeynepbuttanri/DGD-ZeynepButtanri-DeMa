using System;

namespace MapAdventureGame
{
    public class NPC
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Name { get; private set; }

        public NPC(int startX, int startY, string name)
        {
            X = startX;
            Y = startY;
            Name = name;
        }

        public void MoveRandomly(Map map)
        {
            Random rand = new Random();
            int direction = rand.Next(4);

            int newX = X;
            int newY = Y;

            switch (direction)
            {
                case 0: newY--; break; // Yukarı
                case 1: newX--; break; // Sol
                case 2: newY++; break; // Aşağı
                case 3: newX++; break; // Sağ
            }

            if (map.IsPositionValid(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }
    }
}