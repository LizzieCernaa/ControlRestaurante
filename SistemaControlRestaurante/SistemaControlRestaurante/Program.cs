using System;
using System.IO;

namespace SistemaControlRestaurante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            imprimirMenu();
            int menu = int.Parse(Console.ReadLine());

            if (menu == 1) 
            {
                menuDia();
            }
            


            Console.ReadKey();
        }

        static void imprimirMenu()
        {

            Console.WriteLine("---- MENU ----");
            Console.WriteLine("1. Mostrar menu del dia");
            Console.WriteLine("10. SALIR");

        }
        static void menuDia() 
        {
            DateTime hoy = DateTime.Now;
            Console.WriteLine((int)hoy.DayOfWeek);
           /// Console.ReadKey();
           
            Console.WriteLine("El menu de este dia es: ");
            Console.ReadLine();
            int menu;

            using (var fileSream = new FileStream("Menu.cvs", FileMode.Append)) 
            {
                
            }
        }
    }
}
