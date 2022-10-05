using System.Diagnostics;
using System.Timers;
using System;
namespace Assignment3
{

    public class MyClock
    {
        public delegate void Clock();
        public event Clock EventClock = delegate { };
        public void ClockRunner()
        {
            EventClock();
        }
    }

    public class Program
    {
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now);
        }

        public static void Main(String[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var primes = GetPrimeNumbers(0, 100).Result;

            foreach (var prime in primes)
            {
                Console.WriteLine(prime);
            }

            sw.Stop();

            Console.WriteLine("Total prime numbers: {0} \nProcess time: {1}", primes.Count, sw.ElapsedMilliseconds);

            while (true)
            {
                Thread.Sleep(1000);
                MyClock clock = new MyClock();
                clock.EventClock += () => Console.WriteLine(DateTime.Now);
                clock.ClockRunner();
            }
        }

        static async Task<List<int>> GetPrimeNumbers(int minimum, int maximum)
        {
            var list = new List<int>();

            var result = await Task.Run(() =>
            {
                for (int i = minimum; i <= maximum; i++)
                {
                    if (IsPrimeNumber(i))
                    {
                        list.Add(i);
                    }
                }
                return list;
            });

            return result;
        }

        static bool IsPrimeNumber(int number)
        {
            int i;

            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            if (number == i)
            {
                return true;
            }

            return false;
        }
    }
}
