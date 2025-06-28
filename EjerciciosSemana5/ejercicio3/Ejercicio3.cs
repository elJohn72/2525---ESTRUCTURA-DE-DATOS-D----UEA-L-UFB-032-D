using System;

namespace ListaAsignaturasNotas
{
    // Clase Nodo que representa una asignatura y su nota
    public class NodoAsignatura
    {
        public string Nombre { get; set; }       // Nombre de la asignatura
        public double Nota { get; set; }         // Nota correspondiente a la asignatura
        public NodoAsignatura Siguiente { get; set; } // Referencia al siguiente nodo

        // Constructor que recibe el nombre de la asignatura
        public NodoAsignatura(string nombre)
        {
            Nombre = nombre;
            Nota = 0.0;
            Siguiente = null;
        }
    }

    // Clase ListaAsignaturas que representa una lista enlazada de asignaturas
    public class ListaAsignaturas
    {
        private NodoAsignatura cabeza; // Nodo inicial de la lista

        // Constructor que inicializa la lista vacía
        public ListaAsignaturas()
        {
            cabeza = null;
        }

        // Método para insertar una nueva asignatura al final de la lista
        public void Insertar(string nombre)
        {
            NodoAsignatura nueva = new NodoAsignatura(nombre); // Crear nuevo nodo

            if (cabeza == null)
            {
                cabeza = nueva; // Si la lista está vacía, el nuevo nodo es la cabeza
            }
            else
            {
                NodoAsignatura actual = cabeza;
                while (actual.Siguiente != null) // Buscar el último nodo
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nueva; // Enlazar el nuevo nodo al final
            }
        }

        // Método para pedir al usuario que ingrese la nota de cada asignatura
        public void PedirNotas()
        {
            NodoAsignatura actual = cabeza;

            while (actual != null)
            {
                Console.Write($"Introduce la nota para {actual.Nombre}: ");
                
                // Leer y validar la entrada del usuario
                if (double.TryParse(Console.ReadLine(), out double nota))
                {
                    actual.Nota = nota;
                }
                else
                {
                    Console.WriteLine("Nota inválida. Se asignará 0.");
                    actual.Nota = 0.0;
                }

                actual = actual.Siguiente; // Pasar al siguiente nodo
            }
        }

        // Método para mostrar las asignaturas y sus notas
        public void MostrarNotas()
        {
            NodoAsignatura actual = cabeza;

            Console.WriteLine("\nResultados:");
            while (actual != null)
            {
                Console.WriteLine($"En {actual.Nombre} has sacado {actual.Nota}");
                actual = actual.Siguiente;
            }
        }
    }

    // Clase principal que ejecuta el programa
    class Program
    {
        static void Main()
        {
            ListaAsignaturas curso = new ListaAsignaturas();

            // Insertar asignaturas en la lista
            curso.Insertar("Matemáticas");
            curso.Insertar("Física");
            curso.Insertar("Química");
            curso.Insertar("Historia");
            curso.Insertar("Lengua");

            // Solicitar notas al usuario y mostrarlas
            curso.PedirNotas();
            curso.MostrarNotas();
        }
    }
}
