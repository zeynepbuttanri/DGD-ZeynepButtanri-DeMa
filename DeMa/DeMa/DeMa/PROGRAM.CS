using System;

namespace MapAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowWelcomeScreen();

            // Oyunu başlat
            Game.Start();
        }

        static void ShowWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("************");
            Console.WriteLine("*        DeMa            *");
            Console.WriteLine("*          by Zeynep Buttanrı          *");
            Console.WriteLine("************");
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Credits");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    break;
                case "2":
                    ShowCredits();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ShowWelcomeScreen();
                    break;
            }
        }

        static void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("************");
            Console.WriteLine("*          Credits                 *");
            Console.WriteLine("*        Developed by:             *");
            Console.WriteLine("*          Zeynep Buttanrı             *");
            Console.WriteLine("************");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            ShowWelcomeScreen();
        }
    }
}
