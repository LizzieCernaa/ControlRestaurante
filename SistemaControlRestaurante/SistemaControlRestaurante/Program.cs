using System;
using System.IO;

namespace SistemaControlRestaurante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            int opcionControlOrden = 0;
            int ordenes = 0;

            while (opcion != 3)
            {
                menuPrincipal();
                Console.WriteLine("Seleccione una opcion");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    int dayOfWeek = (int)DateTime.Now.DayOfWeek;
                    ImprimirMenuDia(dayOfWeek);
                }
                else if (opcion == 2) 
                {
                    MenuControlOrden();
                    Console.WriteLine("Seleccione una opcion");
                    opcionControlOrden = int.Parse(Console.ReadLine());
                    if (opcionControlOrden == 1) 
                    {
                       mostrarOrdenes();
                        ordenes = int.Parse(Console.ReadLine());

                    }
                    Console.ReadKey();
                }
            }
            //Console.ReadKey();
        }

        static void ImprimirMenuDia( int dayOfWeek) 
        {
            string ruta = "menu.csv";
            StreamReader lector = new StreamReader(ruta);
            String[] plato;

            string linea = string.Empty;

            Console.Clear();
            Console.WriteLine($"********** MENU DEL DIA **********");

            while ((linea = lector.ReadLine()) != null) 
            {
                plato = linea.Split(',');
                 
                if (plato[4].Equals ("dia") || dayOfWeek == int.Parse(plato[4])) 
                {
                    Console.WriteLine($"{plato[1]}    {plato[2]}     {plato[3]} ");
                    Console.WriteLine($"--------------------------------------------------------");

                }
            }

            Console.WriteLine($" ************************************************ ");
            lector.Close();
            Console.ReadKey();
        }

        static void MenuControlOrden() 
        {
            Console.Clear();
            Console.WriteLine($"**********MENU CONTROL ORDENES **********");
            Console.WriteLine("1. Ver todas las ordenes  ");
            Console.WriteLine("2. Buscar orden por fecha");
            Console.WriteLine("3. Regresar al menu principal");
        }

        static void menuPrincipal() 
        {
            Console.Clear();
            Console.WriteLine($"********** MENU PRINCIPAL **********");
            Console.WriteLine("1. Ver Menu  ");
            Console.WriteLine("2. Control de Orden");
            Console.WriteLine("3. Salir");
        }

        static void mostrarOrdenes()
        {
            string ruta = "Ordenes.csv";
            StreamReader lector = new StreamReader(ruta);
            String[] orden;

            string linea = string.Empty;

            Console.Clear();
            Console.WriteLine($"********** MENU DEL DIA **********");

            while ((linea = lector.ReadLine()) != null)
            {
                orden = linea.Split(',');

                    Console.WriteLine($"{orden[0].ToUpper()}              {orden[1].ToUpper()}             {orden[2].ToUpper()}         {orden[3].ToUpper()}       {orden[4].ToUpper()}        {orden[5].ToUpper()}        {orden[6].ToUpper()}        {orden[7].ToUpper()}");
                    Console.WriteLine($"--------------------------------------------------------");

            }

            Console.WriteLine($" ************************************************ ");
            lector.Close();
            Console.ReadKey();
        }

    }
}
