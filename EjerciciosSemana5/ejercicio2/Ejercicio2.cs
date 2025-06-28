using System;

namespace ListaAsignaturasMensaje
{
    // Nodo para almacenar el nombre de la asignatura
    public class NodoAsignatura
    {
        public string Nombre { get; set; }
        public NodoAsignatura Siguiente { get; set; }

        public NodoAsignatura(string nombre)
        {
            Nombre = nombre;
            Siguiente = null;
        }
    }

    // Clase que representa la lista enlazada de asignaturas
    public class ListaAsignaturas
    {
        private NodoAsignatura cabeza;

        public ListaAsignaturas()
        {
            cabeza = null;
        }

        // Método para insertar asignaturas
        public void Insertar(string nombre)
        {
            NodoAsignatura nueva = new NodoAsignatura(nombre);

            if (cabeza == null)
            {
                cabeza = nueva;
            }
            else
            {
                NodoAsignatura actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nueva;
            }
        }

        // Método para mostrar los mensajes personalizados
        public void MostrarMensajes()
        {
            NodoAsignatura actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine($"Yo estudio {actual.Nombre}");
                actual = actual.Siguiente;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ListaAsignaturas curso = new ListaAsignaturas();

            curso.Insertar("Matemáticas");
            curso.Insertar("Física");
            curso.Insertar("Química");
            curso.Insertar("Historia");
            curso.Insertar("Lengua");

            curso.MostrarMensajes();
        }
    }
}
