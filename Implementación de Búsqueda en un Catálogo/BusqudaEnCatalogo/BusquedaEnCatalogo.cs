using System;
using System.Collections.Generic;

namespace CatalogoRevistas
{
    class Program
    {
        // Catálogo de revistas
        static List<string> catalogoRevistas = new List<string>
        {
            "National Geographic",
            "Science",
            "Time",
            "Forbes",
            "Nature",
            "Wired",
            "Popular Science",
            "The Economist",
            "Scientific American",
            "PC Magazine"
        };

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== CATÁLOGO DE REVISTAS ===");
                Console.WriteLine("1. Buscar revista");
                Console.WriteLine("2. Mostrar catálogo");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        BuscarRevista();
                        break;
                    case 2:
                        MostrarCatalogo();
                        break;
                    case 0:
                        Console.WriteLine("Gracias por usar el sistema.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 0);
        }

        // Mostrar catálogo completo
        static void MostrarCatalogo()
        {
            Console.WriteLine("\n--- Catálogo de Revistas ---");
            foreach (string revista in catalogoRevistas)
            {
                Console.WriteLine("- " + revista);
            }
            Console.WriteLine("\nPresione una tecla para volver al menú.");
            Console.ReadKey();
        }

        // Buscar título en el catálogo
        static void BuscarRevista()
        {
            Console.Write("\nIngrese el título de la revista a buscar: ");
            string titulo = Console.ReadLine();

            // Se usa búsqueda iterativa
            bool encontrado = BuscarIterativo(catalogoRevistas, titulo);

            if (encontrado)
            {
                Console.WriteLine("\nResultado: ¡Encontrado!");
            }
            else
            {
                Console.WriteLine("\nResultado: No encontrado.");
            }

            Console.WriteLine("\nPresione una tecla para volver al menú.");
            Console.ReadKey();
        }

        // Algoritmo de búsqueda iterativa
        static bool BuscarIterativo(List<string> lista, string valor)
        {
            foreach (string item in lista)
            {
                if (item.Equals(valor, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
