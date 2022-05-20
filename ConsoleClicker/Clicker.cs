using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleClicker
{
    internal class Clicker
    {
        //var game = new Clicker(ConsoleKeyInfo.T)

        //Properties
        public int Count { get; private set; }
        public int Combo { get; private set; }
        public char ComboChar { get; private set; }
        private readonly ConsoleKey _key;
        private readonly Random rnd = new Random();
        private static Timer timer;
        private DateTime startTime;


        //Constructor, ctor, ctorp
        public Clicker(ConsoleKey key) //heiPåDeg - camelCase / HeiPåDeg - PascalCase
        {
            _key = key;
            Count = 0;
        }

        //Methods
        public void Click(ConsoleKey key)
        {
            if (timer == null)
            {
                CreateTimer();
                startTime = DateTime.Now;

            }



            if (ComboChar == default)
            {
                if (key == _key)
                {
                    Count++;
                    Combo++;
                    ComboChar = (char)rnd.Next(65, 65 + 26);
                }
            }
            else if (key == (ConsoleKey)ComboChar)
            {
                Count += Combo * 2;
                Combo++;
                ComboChar = (char)rnd.Next(65, 65 + 26);
            }
            else
            {
                Combo = 0;
                ComboChar = default;
            }
        }

        private void CreateTimer()
        {
            timer = new Timer();
            timer.Elapsed += async (sender, e) => await HandleTimer(e);
            timer.Start();
        }

        private async Task HandleTimer(ElapsedEventArgs e)
        {
            if (Count > 10)
            {
                Console.SetCursorPosition(0, 1);
                Console.WriteLine(" You won in " + startTime - DateTime.Now);
                timer.Stop();
                timer.Dispose();
            }

        }

        public void Show()
        {
            //Key - Count
            Console.WriteLine($"Score: {Count} // Combo x{Combo}! ");
            Console.SetCursorPosition(rnd.Next(0, Console.WindowWidth), rnd.Next(2, Console.WindowHeight));
            Console.Write($"{ComboChar}");
            Console.SetCursorPosition(0, 0);
        }



    }
}
