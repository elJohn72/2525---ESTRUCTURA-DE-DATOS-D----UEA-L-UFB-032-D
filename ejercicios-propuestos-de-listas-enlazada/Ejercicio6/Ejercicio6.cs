using System;

class Estudiante
{
    public string Cedula;
    public string Nombre;
    public string Apellido;
    public string Correo;
    public double Nota;
    public Estudiante Siguiente;

    public Estudiante(string cedula, string nombre, string apellido, string correo, double nota)
    {
        Cedula = cedula;
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        Nota = nota;
        Siguiente = null;
    }
}

class ListaEstudiantes
{
    private Estudiante cabeza;
    private Estudiante cola;

    public void AgregarEstudiante(string cedula, string nombre, string apellido, string correo, double nota)
    {
        Estudiante nuevo = new Estudiante(cedula, nombre, apellido, correo, nota);

        if (nota >= 7)
        {
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
            if (cola == null)
                cola = nuevo;
        }
        else
        {
            if (cabeza == null)
            {
                cabeza = cola = nuevo;
            }
            else
            {
                cola.Siguiente = nuevo;
                cola = nuevo;
            }
        }
    }

    public void BuscarPorCedula(string cedula)
    {
        Estudiante actual = cabeza;
        while (actual != null)
        {
            if (actual.Cedula == cedula)
            {
                Console.WriteLine($"Estudiante encontrado: {actual.Nombre} {actual.Apellido}, Nota: {actual.Nota}");
                return;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine("Estudiante no encontrado.");
    }

    public void EliminarEstudiante(string cedula)
    {
        Estudiante actual = cabeza;
        Estudiante anterior = null;

        while (actual != null)
        {
            if (actual.Cedula == cedula)
            {
                if (anterior == null)
                {
                    cabeza = actual.Siguiente;
                    if (actual == cola)
                        cola = null;
                }
                else
                {
                    anterior.Siguiente = actual.Siguiente;
                    if (actual == cola)
                        cola = anterior;
                }
                Console.WriteLine("Estudiante eliminado correctamente.");
                return;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }
        Console.WriteLine("Estudiante no encontrado.");
    }

    public void MostrarTotales()
    {
        int aprobados = 0, reprobados = 0;
        Estudiante actual = cabeza;
        while (actual != null)
        {
            if (actual.Nota >= 7)
                aprobados++;
            else
                reprobados++;
            actual = actual.Siguiente;
        }
        Console.WriteLine($"Total aprobados: {aprobados}");
        Console.WriteLine($"Total reprobados: {reprobados}");
    }

    public void MostrarLista()
    {
        Estudiante actual = cabeza;
        while (actual != null)
        {
            Console.WriteLine($"{actual.Cedula} - {actual.Nombre} {actual.Apellido} - {actual.Nota}");
            actual = actual.Siguiente;
        }
    }
}

class Programa
{
    static void Main(string[] args)
    {
        ListaEstudiantes lista = new ListaEstudiantes();

        lista.AgregarEstudiante("123", "Ana", "Gómez", "ana@gmail.com", 8.5);
        lista.AgregarEstudiante("124", "Luis", "Pérez", "luis@gmail.com", 6.2);
        lista.AgregarEstudiante("125", "Sofía", "Martínez", "sofia@gmail.com", 9.0);

        Console.WriteLine("\nLista de estudiantes:");
        lista.MostrarLista();

        Console.WriteLine("\nBuscar estudiante con cédula 124:");
        lista.BuscarPorCedula("124");

        Console.WriteLine("\nEliminar estudiante con cédula 123:");
        lista.EliminarEstudiante("123");

        Console.WriteLine("\nLista de estudiantes actualizada:");
        lista.MostrarLista();

        Console.WriteLine("\nTotales:");
        lista.MostrarTotales();
    }
}
