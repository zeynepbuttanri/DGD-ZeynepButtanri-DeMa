using System;
using System.Collections.Generic;

namespace MapAdventureGame
{
    public class Map
    {
        private int Width;
        private int Height;
        private char[,] Grid;
        public (int, int) RestPoint { get; private set; }
        private List<Item> Items;
        private List<Location> Locations;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new char[width, height];
            Items = new List<Item>();
            Locations = new List<Location>();
            InitializeMap();
        }

        private void InitializeMap()
        {
            // Haritayı boşluk karakteri ile doldur
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Grid[x, y] = '.';
                }
            }

            // Duraklama noktasını belirle
            RestPoint = (Width / 2, Height / 2);
            Grid[RestPoint.Item1, RestPoint.Item2] = 'R';

            // Eşyaları ve lokasyonları haritaya ekle
            AddItems();
            AddLocations();
        }

        private void AddItems()
        {
            Random rand = new Random();
            Items.Add(new Item("Junk", 'J', rand.Next(Width), rand.Next(Height)));
            Items.Add(new Item("Junk", 'J', rand.Next(Width), rand.Next(Height)));
            Items.Add(new Item("Dynamite", 'D', rand.Next(Width), rand.Next(Height)));
            Items.Add(new Item("Lighter", 'L', rand.Next(Width), rand.Next(Height)));
            Items.Add(new Item("TNT", 'T', rand.Next(Width), rand.Next(Height)));
            Items.Add(new Item("TNT", 'T', rand.Next(Width), rand.Next(Height)));
            Items.Add(new Item("TNT", 'T', rand.Next(Width), rand.Next(Height)));

            foreach (var item in Items)
            {
                Grid[item.X, item.Y] = item.Icon;
            }
        }

        private void AddLocations()
        {
            Locations.Add(new Location("Maya", 'M', Width / 3, Height / 3));
            Locations.Add(new Location("Aseprite", 'A', 2 * Width / 3, Height / 3));
            Locations.Add(new Location("Adobe", 'O', Width / 3, 2 * Height / 3));
            Locations.Add(new Location("Procreate", 'P', 2 * Width / 3, 2 * Height / 3));

            foreach (var location in Locations)
            {
                Grid[location.X, location.Y] = location.Icon;
            }
        }

        public void Display(Player player)
        {
            Console.Clear();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (player.X == x && player.Y == y)
                    {
                        Console.Write('P'); // Player karakteri
                    }
                    else
                    {
                        Console.Write(Grid[x, y]);
                    }
                }
                Console.WriteLine();
            }
        }

        public bool IsPositionValid(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public Item GetItem(int x, int y)
        {
            foreach (var item in Items)
            {
                if (item.X == x && item.Y == y)
                {
                    return item;
                }
            }
            return null;
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
            Grid[item.X, item.Y] = '.';
        }

        public Location GetLocation(int x, int y)
        {
            foreach (var location in Locations)
            {
                if (location.X == x && location.Y == y)
                {
                    return location;
                }
            }
            return null;
        }

        public void RemoveLocation(Location location)
        {
            Locations.Remove(location);
            Grid[location.X, location.Y] = '.';
        }
    }

    public class Item
    {
        public string Name { get; }
        public char Icon { get; }
        public int X { get; set; }
        public int Y { get; set; }

        public Item(string name, char icon, int x, int y)
        {
            Name = name;
            Icon = icon;
            X = x;
            Y = y;
        }
    }

    public class Location
    {
        public string Name { get; }
        public char Icon { get; }
        public int X { get; set; }
        public int Y { get; set; }

        public Location(string name, char icon, int x, int y)
        {
            Name = name;
            Icon = icon;
            X = x;
            Y = y;
        }
    }
}