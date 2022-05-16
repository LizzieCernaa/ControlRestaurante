using System;

namespace SistemaControlRestaurante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime hoy = DateTime.Now;
            Console.WriteLine((int)hoy.DayOfWeek);
            Console.ReadKey();

        }
    }
}
