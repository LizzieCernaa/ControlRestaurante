using System;
using System.IO;

namespace SistemaControlRestaurante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"********** MENU DEL DIA **********");
            menuPrincipal();

            int dayOfWeek = (int)DateTime.Now.DayOfWeek;
           // ImprimirMenuDia(dayOfWeek);
            Console.ReadKey();
        }

        static void ImprimirMenuDia( int dayOfWeek) 
        {
            string ruta = "menu.csv";
            StreamReader leactor = new StreamReader(ruta);
            String[] plato;

            string linea = string.Empty;

            Console.WriteLine($"********** MENU DEL DIA **********");

            while ((linea = leactor.ReadLine()) != null) 
            {
                plato = linea.Split(',');
                 
                if (plato[4].Equals ("dia") || dayOfWeek == int.Parse(plato[4])) 
                {
                    Console.WriteLine($"{plato[1]}    {plato[2]}     {plato[3]} ");
                    Console.WriteLine($"--------------------------------------------------------");

                }
            }

            Console.WriteLine($" ************************************************ ");
            leactor.Close();
        }

        static void MenuControlOrden() 
        {
            string ruta = "Ordenes.csv";
            StreamReader leactor = new StreamReader(ruta);
            String[] orden;

            string linea = string.Empty;


            Console.WriteLine($"**********MENU CONTROL ORDENES **********");

        }

        static void menuPrincipal() 
        {
            Console.WriteLine("1. Ver Menu  ");
            Console.WriteLine("2. Control de Orden");
            Console.WriteLine("3. Salir");
        }

    }
}
