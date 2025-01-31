using System;
using System.Collections.Generic;

namespace MapAdventureGame
{
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public List<Item> Inventory { get; private set; }
        private const int MaxInventorySize = 5;

        public Player(int startX, int startY)
        {
            X = startX;
            Y = startY;
            Inventory = new List<Item>();
        }

        public void Move(ConsoleKeyInfo keyInfo, Map map)
        {
            int newX = X;
            int newY = Y;

            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    newY--;
                    break;
                case ConsoleKey.A:
                    newX--;
                    break;
                case ConsoleKey.S:
                    newY++;
                    break;
                case ConsoleKey.D:
                    newX++;
                    break;
                case ConsoleKey.I: // 'I' tuşuna basıldığında envanteri göster
                    ShowInventory();
                    return; // Envanter gösterildiğinde hareket etme
            }

            if (map.IsPositionValid(newX, newY))
            {
                X = newX;
                Y = newY;
            }

            // Oyuncu duraklama noktasına geldiyse envanteri göster
            if (X == map.RestPoint.Item1 && Y == map.RestPoint.Item2)
            {
                ShowInventory();
            }

            // Oyuncu bir eşya toplarsa
            HandleItemInteraction(map);

            // Oyuncu bir lokasyona geldiyse
            HandleLocationInteraction(map);
        }

        private void HandleItemInteraction(Map map)
        {
            Item item = map.GetItem(X, Y);
            if (item != null)
            {
                Console.WriteLine($"You found a {item.Name}. Do you want to pick it up? (y/n)");
                var input = Console.ReadKey(true).Key;
                while (input != ConsoleKey.Y && input != ConsoleKey.N)
                {
                    Console.WriteLine("Invalid input. Please press 'y' to pick up the item or 'n' to leave it.");
                    input = Console.ReadKey(true).Key;
                }

                if (input == ConsoleKey.Y)
                {
                    if (Inventory.Count < MaxInventorySize)
                    {
                        Inventory.Add(item);
                        map.RemoveItem(item);
                        Console.WriteLine($"{item.Name} has been added to your inventory.");
                    }
                    else
                    {
                        Console.WriteLine("Your inventory is full. You cannot pick up any more items.");
                    }
                }
                else
                {
                    Console.WriteLine($"{item.Name} left on the ground.");
                }

                // Mesajın ekranda kalmasını sağla
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
        }

        private void HandleLocationInteraction(Map map)
        {
            Location location = map.GetLocation(X, Y);
            if (location != null)
            {
                Console.WriteLine($"You found {location.Name}. Do you want to blow it up? (y/n)");
                var input = Console.ReadKey(true).Key;
                while (input != ConsoleKey.Y && input != ConsoleKey.N)
                {
                    Console.WriteLine("Invalid input. Please press 'y' to blow it up or 'n' to leave it.");
                    input = Console.ReadKey(true).Key;
                }

                if (input == ConsoleKey.Y)
                {
                    if (HasRequiredItems())
                    {
                        if (location.Name == "Maya")
                        {
                            Console.WriteLine("You blew up Maya and won the game!");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine($"You blew up {location.Name} and lost the game.");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have the required items to blow this up.");
                    }
                }
                else
                {
                    Console.WriteLine($"{location.Name} left intact.");
                }

                // Mesajın ekranda kalmasını sağla
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
        }

        private bool HasRequiredItems()
        {
            int dynamiteCount = 0;
            int lighterCount = 0;
            int tntCount = 0;

            foreach (var item in Inventory)
            {
                if (item.Name == "Dynamite")
                {
                    dynamiteCount++;
                }
                else if (item.Name == "Lighter")
                {
                    lighterCount++;
                }
                else if (item.Name == "TNT")
                {
                    tntCount++;
                }
            }

            return dynamiteCount >= 1 && lighterCount >= 1 && tntCount >= 3;
        }

        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("Inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}