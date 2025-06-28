using System;

namespace ListaAsignaturas
{
    // Nodo que representa una asignatura
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

    // Lista enlazada simple para almacenar asignaturas
    public class ListaAsignaturas
    {
        private NodoAsignatura cabeza;

        public ListaAsignaturas()
        {
            cabeza = null;
        }

        // Método para insertar una asignatura
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

        // Método para mostrar todas las asignaturas
        public void Mostrar()
        {
            Console.WriteLine("Asignaturas del curso:");
            NodoAsignatura actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine($"- {actual.Nombre}");
                actual = actual.Siguiente;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ListaAsignaturas curso = new ListaAsignaturas();

            // Agregamos asignaturas como en el ejemplo
            curso.Insertar("Matemáticas");
            curso.Insertar("Física");
            curso.Insertar("Química");
            curso.Insertar("Historia");
            curso.Insertar("Lengua");

            // Mostramos las asignaturas
            curso.Mostrar();
        }
    }
}
