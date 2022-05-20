using System;

namespace ConsoleClicker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * Klasse til Clicker / Console.Readkey() ConsoleKey
             * Combo counter. // Combo x10!
             */
            Console.CursorVisible = false;
            var game = new Clicker(ConsoleKey.A);
            Console.WriteLine("Press A to start.");

            game.Show();
            while (true)
            {
                var input = Console.ReadKey();
                game.Click(input.Key);
                Console.Clear();
                game.Show();
            }

        }
    }
}
