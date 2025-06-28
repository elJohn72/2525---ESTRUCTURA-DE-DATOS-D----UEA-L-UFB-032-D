using System;

namespace LoteriaListaEnlazada
{
    // Nodo que almacena un número de lotería
    public class NodoNumero
    {
        public int Numero { get; set; }
        public NodoNumero Siguiente { get; set; }

        public NodoNumero(int numero)
        {
            Numero = numero;
            Siguiente = null;
        }
    }

    // Lista enlazada para manejar los números
    public class ListaLoteria
    {
        private NodoNumero cabeza;

        public ListaLoteria()
        {
            cabeza = null;
        }

        // Inserta un nuevo número al final de la lista
        public void Insertar(int numero)
        {
            NodoNumero nuevo = new NodoNumero(numero);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                NodoNumero actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        // Ordena la lista de menor a mayor (burbuja)
        public void Ordenar()
        {
            if (cabeza == null) return;

            bool cambiado;
            do
            {
                cambiado = false;
                NodoNumero actual = cabeza;
                while (actual.Siguiente != null)
                {
                    if (actual.Numero > actual.Siguiente.Numero)
                    {
                        // Intercambiar valores
                        int temp = actual.Numero;
                        actual.Numero = actual.Siguiente.Numero;
                        actual.Siguiente.Numero = temp;
                        cambiado = true;
                    }
                    actual = actual.Siguiente;
                }
            } while (cambiado);
        }

        // Muestra los números en la lista
        public void Mostrar()
        {
            Console.WriteLine("\nNúmeros ordenados de la lotería:");
            NodoNumero actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine($"- {actual.Numero}");
                actual = actual.Siguiente;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ListaLoteria lista = new ListaLoteria();

            Console.WriteLine("Ingrese los 6 números ganadores de la lotería:");
            for (int i = 0; i < 6; i++)
            {
                Console.Write($"Número {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int numero))
                {
                    lista.Insertar(numero);
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Se insertará 0.");
                    lista.Insertar(0);
                }
            }

            lista.Ordenar();
            lista.Mostrar();
        }
    }
}
