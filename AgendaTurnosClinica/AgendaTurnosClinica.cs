// Agenda de Turnos para Pacientes - C# Console App
using System;
using System.Collections.Generic;

// Representación inmutable del paciente
public record Paciente(int Id, string Nombre, int Edad, string Telefono);

// Estructura que representa un turno médico
public struct Turno
{
    public DateTime FechaHora;
    public int PacienteId;

    public Turno(DateTime fechaHora, int pacienteId)
    {
        FechaHora = fechaHora;
        PacienteId = pacienteId;
    }
}

class ProgramaAgenda
{
    const int Dias = 5;  // Lunes a viernes
    const int Franjas = 16;  // De 9:00 a 16:30 en intervalos de 30 minutos
    static Turno?[,] calendario = new Turno?[Dias, Franjas];  // Matriz para almacenar los turnos
    static List<Paciente> pacientes = new List<Paciente>();  // Lista dinámica de pacientes

    static void Main()
    {
        int opcion;
        do
        {
            // Menú principal
            Console.WriteLine("\n--- Agenda de Turnos ---");
            Console.WriteLine("1. Registrar Paciente");
            Console.WriteLine("2. Agendar Turno");
            Console.WriteLine("3. Consultar Agenda");
            Console.WriteLine("4. Cancelar Turno");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            // Opciones del menú
            switch (opcion)
            {
                case 1: RegistrarPaciente(); break;
                case 2: AgendarTurno(); break;
                case 3: ConsultarAgenda(); break;
                case 4: CancelarTurno(); break;
            }

        } while (opcion != 5);
    }

    // Permite registrar un nuevo paciente
    static void RegistrarPaciente()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
        Console.Write("Nombre: "); string nombre = Console.ReadLine();
        Console.Write("Edad: "); int edad = int.Parse(Console.ReadLine());
        Console.Write("Teléfono: "); string telefono = Console.ReadLine();
        pacientes.Add(new Paciente(id, nombre, edad, telefono));
        Console.WriteLine("Paciente registrado correctamente.");
    }

    // Asigna un turno a un paciente registrado
    static void AgendarTurno()
    {
        Console.Write("ID del Paciente: "); int id = int.Parse(Console.ReadLine());
        Paciente? p = pacientes.Find(p => p.Id == id);
        if (p is null) { Console.WriteLine("Paciente no encontrado."); return; }

        Console.Write("Día (0=Lun ... 4=Vie): "); int dia = int.Parse(Console.ReadLine());
        Console.Write("Franja (0=9:00 ... 15=16:30): "); int franja = int.Parse(Console.ReadLine());

        // Verifica disponibilidad de la franja
        if (calendario[dia, franja] is null)
        {
            DateTime fecha = DateTime.Today.AddDays(dia);
            fecha = fecha.AddHours(9 + (franja * 0.5));
            calendario[dia, franja] = new Turno(fecha, id);
            Console.WriteLine("Turno agendado con éxito.");
        }
        else
        {
            Console.WriteLine("Franja horaria ocupada.");
        }
    }

    // Muestra la agenda completa con turnos ocupados y disponibles
    static void ConsultarAgenda()
    {
        for (int d = 0; d < Dias; d++)
        {
            Console.WriteLine($"\nDía {d}:");
            for (int f = 0; f < Franjas; f++)
            {
                var turno = calendario[d, f];
                string hora = $"{9 + f / 2}:{(f % 2 == 0 ? "00" : "30")}";
                if (turno is null)
                    Console.WriteLine($"  {hora} - Libre");
                else
                {
                    Paciente? paciente = pacientes.Find(p => p.Id == turno.Value.PacienteId);
                    Console.WriteLine($"  {hora} - {paciente?.Nombre} ({paciente?.Telefono})");
                }
            }
        }
    }

    // Cancela un turno previamente agendado
    static void CancelarTurno()
    {
        Console.Write("Día (0=Lun ... 4=Vie): "); int dia = int.Parse(Console.ReadLine());
        Console.Write("Franja (0=9:00 ... 15=16:30): "); int franja = int.Parse(Console.ReadLine());
        calendario[dia, franja] = null;
        Console.WriteLine("Turno cancelado.");
    }
}
