using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GrafosTransporte
{
    // Estructura de la arista con peso
    public record Edge(string To, int Weight);

    public class Graph
    {
        public bool Directed { get; }
        // Lista de adyacencia: Nodo -> lista de (vecino, peso)
        private readonly Dictionary<string, List<Edge>> _adj = new();

        public Graph(bool directed = false)
        {
            Directed = directed;
        }

        public IEnumerable<string> Vertices => _adj.Keys;

        public int EdgeCount => _adj.Values.Sum(l => l.Count) / (Directed ? 1 : 2);

        public void AddVertex(string v)
        {
            if (!_adj.ContainsKey(v))
                _adj[v] = new List<Edge>();
        }

        public void AddEdge(string from, string to, int weight = 1)
        {
            AddVertex(from);
            AddVertex(to);
            _adj[from].Add(new Edge(to, weight));
            if (!Directed)
                _adj[to].Add(new Edge(from, weight));
        }

        public IReadOnlyList<Edge> Neighbors(string v) => _adj.TryGetValue(v, out var list) ? list : new List<Edge>();

        public void Print()
        {
            Console.WriteLine("=== Lista de Adyacencia ===");
            foreach (var (v, edges) in _adj.OrderBy(p => p.Key))
            {
                var salidas = edges.Select(e => $"{e.To}({e.Weight})");
                Console.WriteLine($"{v} -> {string.Join(", ", salidas)}");
            }
            Console.WriteLine($"Vértices: {_adj.Count} | Aristas: {EdgeCount} | Dirigido: {Directed}");
            Console.WriteLine();
        }

        // BFS: camino más corto en cantidad de aristas (ignora pesos)
        public (List<string> path, int hops) ShortestPathBfs(string start, string end)
        {
            var prev = new Dictionary<string, string?>();
            var visited = new HashSet<string>();
            var q = new Queue<string>();

            q.Enqueue(start);
            visited.Add(start);
            prev[start] = null;

            while (q.Count > 0)
            {
                var u = q.Dequeue();
                if (u == end) break;

                foreach (var e in Neighbors(u))
                {
                    if (visited.Add(e.To))
                    {
                        prev[e.To] = u;
                        q.Enqueue(e.To);
                    }
                }
            }

            if (!prev.ContainsKey(end))
                return (new List<string>(), -1);

            var path = Reconstruct(prev, end);
            return (path, path.Count - 1);
        }

        // Dijkstra: camino de costo mínimo (considera pesos >= 0)
        public (List<string> path, int cost) ShortestPathDijkstra(string start, string end)
        {
            var dist = new Dictionary<string, int>();
            var prev = new Dictionary<string, string?>();
            var pq = new PriorityQueue<string, int>();

            foreach (var v in Vertices)
            {
                dist[v] = int.MaxValue;
                prev[v] = null;
            }
            if (!dist.ContainsKey(start))
                throw new ArgumentException($"El vértice de inicio '{start}' no existe en el grafo.");
            if (!dist.ContainsKey(end))
                throw new ArgumentException($"El vértice destino '{end}' no existe en el grafo.");

            dist[start] = 0;
            pq.Enqueue(start, 0);

            while (pq.Count > 0)
            {
                pq.TryDequeue(out var u, out var du);
                if (du > dist[u]) continue;            // Entrada obsoleta
                if (u == end) break;                   // Ya encontramos el mejor costo a 'end'

                foreach (var e in Neighbors(u))
                {
                    var alt = dist[u] + e.Weight;
                    if (alt < dist[e.To])
                    {
                        dist[e.To] = alt;
                        prev[e.To] = u;
                        pq.Enqueue(e.To, alt);
                    }
                }
            }

            if (dist[end] == int.MaxValue)
                return (new List<string>(), int.MaxValue);

            var path = Reconstruct(prev, end);
            return (path, dist[end]);
        }

        private static List<string> Reconstruct(Dictionary<string, string?> prev, string end)
        {
            var path = new List<string>();
            string? cur = end;
            while (cur != null)
            {
                path.Add(cur);
                cur = prev[cur];
            }
            path.Reverse();
            return path;
        }
    }

    internal class Program
    {
        private static void Main()
        {
            // 1) Construcción del grafo de ejemplo (no dirigido)
            var g = new Graph(directed: false);

            // Paradas y tiempos (minutos)
            g.AddEdge("A", "B", 5);
            g.AddEdge("A", "C", 3);
            g.AddEdge("B", "D", 4);
            g.AddEdge("C", "D", 2);
            g.AddEdge("D", "E", 1);

            // 2) Reportería básica
            g.Print();

            // 3) BFS: camino con menor número de paradas (A -> E)
            var swBfs = Stopwatch.StartNew();
            var (pathBfs, hops) = g.ShortestPathBfs("A", "E");
            swBfs.Stop();

            Console.WriteLine("=== BFS: Camino con menor número de paradas (A -> E) ===");
            if (hops >= 0)
            {
                Console.WriteLine($"Ruta: {string.Join(" -> ", pathBfs)}");
                Console.WriteLine($"Paradas (hops): {hops}");
            }
            else
            {
                Console.WriteLine("No existe ruta entre A y E.");
            }
            Console.WriteLine($"Tiempo de ejecución BFS: {swBfs.ElapsedTicks} ticks ({swBfs.Elapsed.TotalMilliseconds:F6} ms)");
            Console.WriteLine();

            // 4) Dijkstra: camino de menor tiempo (A -> E)
            var swDij = Stopwatch.StartNew();
            var (pathDij, cost) = g.ShortestPathDijkstra("A", "E");
            swDij.Stop();

            Console.WriteLine("=== Dijkstra: Camino mínimo por tiempo (A -> E) ===");
            if (cost != int.MaxValue)
            {
                Console.WriteLine($"Ruta: {string.Join(" -> ", pathDij)}");
                Console.WriteLine($"Tiempo total: {cost} minutos");
            }
            else
            {
                Console.WriteLine("No existe ruta entre A y E.");
            }
            Console.WriteLine($"Tiempo de ejecución Dijkstra: {swDij.ElapsedTicks} ticks ({swDij.Elapsed.TotalMilliseconds:F6} ms)");
            Console.WriteLine();

            // 5) Comparativa simple
            Console.WriteLine("=== Comparativa ===");
            Console.WriteLine($"BFS -> hops: {hops}, tiempo: (no aplica, ignora pesos)");
            Console.WriteLine($"Dijkstra -> costo: {cost} minutos (usa pesos)");
            Console.WriteLine();

            // 6) Nota sobre complejidad (para el informe)
            Console.WriteLine("Complejidad teórica:");
            Console.WriteLine(" - BFS: O(V + E)");
            Console.WriteLine(" - Dijkstra (cola prioridad binaria): O((V + E) log V)");
            Console.WriteLine();

            Console.WriteLine("Presiona ENTER para salir...");
            Console.ReadLine();
        }
    }
}
