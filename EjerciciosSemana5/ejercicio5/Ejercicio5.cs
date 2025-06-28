using System;

namespace ListaInversa
{
    // Nodo para almacenar un número entero
    public class Nodo
    {
        public int Valor { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }

    // Clase que maneja una lista enlazada simple
    public class ListaNumeros
    {
        private Nodo cabeza;

        public ListaNumeros()
        {
            cabeza = null;
        }

        // Insertar al inicio para lograr orden inverso directamente
        public void InsertarInicio(int valor)
        {
            Nodo nuevo = new Nodo(valor);
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
        }

        // Mostrar los números separados por comas
        public void Mostrar()
        {
            Nodo actual = cabeza;
            Console.Write("Números en orden inverso: ");
            while (actual != null)
            {
                Console.Write(actual.Valor);
                if (actual.Siguiente != null)
                    Console.Write(", ");
                actual = actual.Siguiente;
            }
            Console.WriteLine(); // salto de línea final
        }
    }

    class Program
    {
        static void Main()
        {
            ListaNumeros lista = new ListaNumeros();

            // Insertar del 1 al 10 al inicio para que se guarden en orden inverso
            for (int i = 1; i <= 10; i++)
            {
                lista.InsertarInicio(i);
            }

            lista.Mostrar();
        }
    }
}
