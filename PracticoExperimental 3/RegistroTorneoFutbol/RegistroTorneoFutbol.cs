using System;
using System.Collections.Generic;
using System.Diagnostics;

/*
  ------------------------------------------------------------
  GUÍA DE PRÁCTICAS #03 – ESTRUCTURA DE DATOS
  Aplicación seleccionada: Registro de jugadores y equipos en un torneo de fútbol
  Estructuras utilizadas: 
    - HashSet<string> para asegurar unicidad de jugadores por equipo (conjuntos)
    - Dictionary<string, HashSet<string>> para asociar Equipo -> {Jugadores} (mapas)
  Reportería: Visualización y consulta de equipos/jugadores desde un menú por consola.
  Medición de tiempo: Se usa System.Diagnostics.Stopwatch en las operaciones clave.

  Agente de IA utilizado: Estudiante (GPT-5 Thinking)
  Porcentaje de código escrito con el agente: 30%.
  ------------------------------------------------------------
*/

namespace TorneoFutbol
{
    class Program
    {
        // Diccionario (mapa) que asocia nombre de equipo con el conjunto de sus jugadores
        private static readonly Dictionary<string, HashSet<string>> _equipos =
            new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            PrecargarDatosDemo(); // Carga opcional para probar más rápido

            while (true)
            {
                MostrarMenu();
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine()?.Trim();

                switch (opcion)
                {
                    case "1": AgregarEquipo(); break;
                    case "2": AgregarJugadorAEquipo(); break;
                    case "3": ListarEquiposYJugadores(); break;
                    case "4": ConsultarJugadoresDeEquipo(); break;
                    case "5": EliminarJugadorDeEquipo(); break;
                    case "6": EliminarEquipo(); break;
                    case "7": MostrarEstadisticas(); break;
                    case "0":
                        Console.WriteLine("Saliendo… ¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.\n");
                        break;
                }
            }
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("\n===== TORNEO DE FÚTBOL – Conjuntos y Mapas =====");
            Console.WriteLine("1) Agregar equipo");
            Console.WriteLine("2) Agregar jugador a equipo");
            Console.WriteLine("3) Listar equipos y jugadores");
            Console.WriteLine("4) Consultar jugadores de un equipo");
            Console.WriteLine("5) Eliminar jugador de un equipo");
            Console.WriteLine("6) Eliminar equipo");
            Console.WriteLine("7) Estadísticas (tiempos de operaciones y totales)");
            Console.WriteLine("0) Salir");
        }

        // =============== OPERACIONES PRINCIPALES ===============
        private static void AgregarEquipo()
        {
            Console.Write("Nombre del equipo: ");
            var nombre = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("❌ Nombre inválido.");
                return;
            }

            var sw = Stopwatch.StartNew();
            if (_equipos.ContainsKey(nombre))
            {
                sw.Stop();
                Console.WriteLine($"⚠️ El equipo '{nombre}' ya existe. (tiempo: {sw.Elapsed.TotalMilliseconds:F3} ms)");
                return;
            }

            _equipos[nombre] = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            sw.Stop();
            Console.WriteLine($"✅ Equipo '{nombre}' creado. (tiempo: {sw.Elapsed.TotalMilliseconds:F3} ms)");
        }

        private static void AgregarJugadorAEquipo()
        {
            Console.Write("Equipo: ");
            var equipo = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(equipo) || !_equipos.ContainsKey(equipo))
            {
                Console.WriteLine("❌ Equipo no encontrado. Use la opción 1 para crearlo.");
                return;
            }

            Console.Write("Nombre del jugador: ");
            var jugador = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(jugador))
            {
                Console.WriteLine("❌ Nombre de jugador inválido.");
                return;
            }

            var conjunto = _equipos[equipo];
            var sw = Stopwatch.StartNew();
            var agregado = conjunto.Add(jugador); // HashSet asegura unicidad O(1) promedio
            sw.Stop();

            if (agregado)
                Console.WriteLine($"✅ Jugador '{jugador}' agregado al equipo '{equipo}'. (tiempo: {sw.Elapsed.TotalMilliseconds:F3} ms)");
            else
                Console.WriteLine($"⚠️ El jugador '{jugador}' ya existe en el equipo '{equipo}'. (tiempo: {sw.Elapsed.TotalMilliseconds:F3} ms)");
        }

        private static void ListarEquiposYJugadores()
        {
            var sw = Stopwatch.StartNew();
            if (_equipos.Count == 0)
            {
                sw.Stop();
                Console.WriteLine($"(Sin equipos registrados) (tiempo: {sw.Elapsed.TotalMilliseconds:F3} ms)");
                return;
            }

            Console.WriteLine("\n📚 Listado general del torneo:\n");
            foreach (var kv in _equipos)
            {
                Console.WriteLine($"Equipo: {kv.Key}");
                if (kv.Value.Count == 0)
                {
                    Console.WriteLine("  (Sin jugadores)");
                }
                else
                {
                    foreach (var jugador in kv.Value)
                        Console.WriteLine($"  - {jugador}");
                }
                Console.WriteLine();
            }
            sw.Stop();
            Console.WriteLine($"(tiempo de listado: {sw.Elapsed.TotalMilliseconds:F3} ms)");
        }

        private static void ConsultarJugadoresDeEquipo()
        {
            Console.Write("Equipo a consultar: ");
            var equipo = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(equipo) || !_equipos.TryGetValue(equipo, out var jugadores))
            {
                Console.WriteLine("❌ Equipo no encontrado.");
                return;
            }

            var sw = Stopwatch.StartNew();
            Console.WriteLine($"\n🔎 Jugadores del equipo {equipo}:");
            if (jugadores.Count == 0)
            {
                Console.WriteLine("  (Sin jugadores)");
            }
            else
            {
                foreach (var j in jugadores)
                    Console.WriteLine($"  - {j}");
            }
            sw.Stop();
            Console.WriteLine($"(tiempo de consulta: {sw.Elapsed.TotalMilliseconds:F3} ms)\n");
        }

        private static void EliminarJugadorDeEquipo()
        {
            Console.Write("Equipo: ");
            var equipo = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(equipo) || !_equipos.TryGetValue(equipo, out var jugadores))
            {
                Console.WriteLine("❌ Equipo no encontrado.");
                return;
            }

            Console.Write("Jugador a eliminar: ");
            var jugador = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(jugador))
            {
                Console.WriteLine("❌ Nombre inválido.");
                return;
            }

            var sw = Stopwatch.StartNew();
            var eliminado = jugadores.Remove(jugador);
            sw.Stop();
            if (eliminado)
                Console.WriteLine($"🗑️ Jugador '{jugador}' eliminado de '{equipo}'. (tiempo: {sw.Elapsed.TotalMilliseconds:F3} ms)");
            else
                Console.WriteLine($"⚠️ El jugador '{jugador}' no existe en '{equipo}'. (tiempo: {sw.Elapsed.TotalMilliseconds:F3} ms)");
        }

        private static void EliminarEquipo()
        {
            Console.Write("Equipo a eliminar: ");
            var equipo = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(equipo))
            {
                Console.WriteLine("❌ Nombre inválido.");
                return;
            }

            var sw = Stopwatch.StartNew();
            var eliminado = _equipos.Remove(equipo);
            sw.Stop();
            if (eliminado)
                Console.WriteLine($"🗑️ Equipo '{equipo}' eliminado. (tiempo: {sw.Elapsed.TotalMilliseconds:F3} ms)");
            else
                Console.WriteLine($"⚠️ Equipo '{equipo}' no encontrado. (tiempo: {sw.Elapsed.TotalMilliseconds:F3} ms)");
        }

        private static void MostrarEstadisticas()
        {
            // Métricas básicas de reportería
            int totalEquipos = _equipos.Count;
            int totalJugadores = 0;
            int maxJugadores = 0;
            string equipoMax = "-";

            foreach (var kv in _equipos)
            {
                totalJugadores += kv.Value.Count;
                if (kv.Value.Count > maxJugadores)
                {
                    maxJugadores = kv.Value.Count;
                    equipoMax = kv.Key;
                }
            }

            Console.WriteLine("\n===== Estadísticas =====");
            Console.WriteLine($"Equipos registrados: {totalEquipos}");
            Console.WriteLine($"Jugadores totales:  {totalJugadores}");
            Console.WriteLine($"Equipo con más jugadores: {equipoMax} ({maxJugadores})\n");
        }

        // Precarga opcional para facilitar pruebas y capturas
        private static void PrecargarDatosDemo()
        {
            _equipos["Barcelona"] = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Messi", "Xavi"
            };
            _equipos["Real Madrid"] = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Benzema", "Modric", "Kroos"
            };
            _equipos["Independiente"] = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Rodríguez", "Díaz"
            };
        }
    }
}
