using System;

// Definición de la clase Estudiante
public class Estudiante
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string[] Telefonos { get; set; } = new string[3];

    public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
    {
        Id = id;
        Nombres = nombres;
        Apellidos = apellidos;
        Direccion = direccion;
        if (telefonos.Length == 3)
            Telefonos = telefonos;
        else
            throw new ArgumentException("Se deben proporcionar exactamente tres teléfonos.");
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nombre: {Nombres} {Apellidos}");
        Console.WriteLine($"Dirección: {Direccion}");
        Console.WriteLine("Teléfonos:");
        foreach (var tel in Telefonos)
            Console.WriteLine($" - {tel}");
    }
}

// Programa principal para ejecutar
class Program
{
    static void Main()
    {
        string[] telefonos = { "+593 99 123 4567", "+593 98 765 4321", "+593 97 555 0000" };
        Estudiante estudiante = new Estudiante(
            1, "John Jayro", "Miraba Nieves", "Av. Siempre Viva 742, Guayaquil, Ecuador", telefonos
        );
        estudiante.MostrarInformacion();
    }
}
