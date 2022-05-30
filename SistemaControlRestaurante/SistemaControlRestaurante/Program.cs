using System;
using System.IO;

namespace SistemaControlRestaurante
{
    internal class Program
    {
        static int tableWidth = 100;
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
                        mostrarOrdenes(string.Empty);
                        ordenes = int.Parse(Console.ReadLine());

                    }
                    else if (opcionControlOrden == 2)
                    {
                        Console.WriteLine("Intruduce una fecha");
                        string fecha = Console.ReadLine();
                        mostrarOrdenes(fecha);
                    }
                    else if (opcionControlOrden == 3)
                    {
                        fecha();
                       
                    }



                    Console.ReadKey();
                }
                else if (opcion == 3)
                {
                    fracTuras();
                    Console.WriteLine("Las ventas de este dia son");
                    int fac = int.Parse(Console.ReadLine());
                }

            }
            //Console.ReadKey();
        }

        static void ImprimirMenuDia(int dayOfWeek)
        {
            string ruta = "menu.csv";
            StreamReader lector = new StreamReader(ruta);
            String[] plato;

            string linea = string.Empty;

            Console.Clear();
            PrintLine();
            PrintRow($"********** MENU DEL DIA **********");
            PrintLine();
            while ((linea = lector.ReadLine()) != null)
            {
                plato = linea.Split(',');

                if (plato[4].Equals("dia") || dayOfWeek == int.Parse(plato[4]))
                {
                    PrintRow(plato[1], plato[2], plato[3]);
                    PrintLine(); 

                }
            }

            lector.Close();
            Console.ReadKey();
        }

        static void MenuControlOrden() 
        {
            Console.Clear();
            Console.WriteLine($"**********MENU CONTROL ORDENES **********");
            Console.WriteLine("1. Ver todas las ordenes  ");
            Console.WriteLine("2. Buscar orden por fecha");
            Console.WriteLine("3. Ventas del dia");
            Console.WriteLine("4. Regresar al menu principal");
        }

        static void menuPrincipal() 
        {
            Console.Clear();
            Console.WriteLine($"********** MENU PRINCIPAL **********");
            Console.WriteLine("1. Ver Menu  ");
            Console.WriteLine("2. Control de Orden");
            Console.WriteLine("3. Crear una orden");
            Console.WriteLine("4. Salir");
        }

        static void mostrarOrdenes( string fecha)
        {
            string ruta = "Ordenes.csv";
            StreamReader lector = new StreamReader(ruta);
            String[] orden;

            string linea = string.Empty;

            Console.Clear();
            PrintLine();
            PrintRow("********** MENU DEL DIA **********");
            PrintLine();
            while ((linea = lector.ReadLine()) != null)
            {
                orden = linea.Split(',');
                if (fecha.Equals(string.Empty) || fecha.Equals(orden[2])) 
                { 
                PrintRow(orden[0].ToUpper(), orden[1].ToUpper(), orden[2].ToUpper(), orden[3].ToUpper(), orden[4].ToUpper(), orden[5].ToUpper(), orden[6].ToUpper(), orden[7].ToUpper());
                PrintLine();
                }

            }

            
            lector.Close();
            Console.ReadKey();
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        static void fracTuras() 
        {
            string ruta = "Facturas.csv";
            StreamReader lector = new StreamReader(ruta);
            String[] plato;

            string linea = string.Empty;

            Console.Clear();
            PrintLine();
            PrintRow($"********** MENU DEL DIA **********");
            PrintLine();
            while ((linea = lector.ReadLine()) != null)
            {
                plato = linea.Split(',');

                //if (plato[4].Equals("dia") || dayOfWeek == int.Parse(plato[4]))
                //{
                //    PrintRow(plato[1], plato[2], plato[3]);
                //    PrintLine();

                //}
            }


            lector.Close();
            Console.ReadKey();
        }

        static void fecha() 
        {
            // int DateTime.Now.ToString();
            string fecha = string.Empty;
            fecha = DateTime.Now.ToString("dd-MM-yyyy");
;
            string ruta = "Facturas.csv";
            StreamReader lector = new StreamReader(ruta);
            String[] fractura;

            string linea = string.Empty;

            Console.Clear();
            PrintLine();
            PrintRow($"********** VENTAS DEL DIA **********");
            PrintLine();
            while ((linea = lector.ReadLine()) != null)
            {
                fractura = linea.Split(',');

                if (fractura[2].Equals("fecha") || (fecha.Equals(fractura[2]) && fractura[7].Equals("pagado")))
                {
                    PrintRow(fractura[1], fractura[2], fractura[3], fractura[4], fractura[5], fractura[6], fractura[7]);
                    PrintLine();

                }
            }
        }

        

    }
}
