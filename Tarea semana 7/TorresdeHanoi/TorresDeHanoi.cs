using System;
using System.Collections.Generic;

namespace StackExercises
{
    /// <summary>
    /// Demo de ejercicios con Pilas (Stacks) en C#:
    /// 1) Verificación de paréntesis balanceados.
    /// 2) Resolución de Torres de Hanoi usando pilas y recursividad.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 1) Paréntesis balanceados
            string expression = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
            Console.WriteLine("Expresión: " + expression);
            bool balanced = AreBracketsBalanced(expression);
            Console.WriteLine(balanced ? "Fórmula balanceada." : "Fórmula NO balanceada.");

            Console.WriteLine(new string('-', 50));

            // 2) Torres de Hanoi
            int diskCount = 3;
            Console.WriteLine($"Resolución de Torres de Hanoi para {diskCount} discos:");
            // Inicializar torres como pilas
            var source = new Stack<int>();
            var auxiliary = new Stack<int>();
            var target = new Stack<int>();

            // Llenar la torre origen
            for (int i = diskCount; i >= 1; i--)
                source.Push(i);

            PrintTowers(source, auxiliary, target);
            SolveHanoi(diskCount, source, "A", auxiliary, "B", target, "C");
        }

        /// <summary>
        /// Verifica si en la cadena los paréntesis, llaves y corchetes están balanceados.
        /// </summary>
        /// <param name="input">Cadena con la expresión matemática.</param>
        /// <returns>True si están balanceados, false en caso contrario.</returns>
        static bool AreBracketsBalanced(string input)
        {
            var stack = new Stack<char>();
            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                        return false;

                    char open = stack.Pop();
                    if (!IsMatchingPair(open, c))
                        return false;
                }
            }
            // Si quedan aberturas sin cerrar, no está balanceado
            return stack.Count == 0;
        }

        /// <summary>
        /// Determina si los caracteres de apertura y cierre coinciden.
        /// </summary>
        static bool IsMatchingPair(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '{' && close == '}') ||
                   (open == '[' && close == ']');
        }

        /// <summary>
        /// Muestra el contenido actual de las tres torres.
        /// </summary>
        static void PrintTowers(Stack<int> source, Stack<int> aux, Stack<int> target)
        {
            Console.WriteLine("Torre A: [{0}]", string.Join(", ", source));
            Console.WriteLine("Torre B: [{0}]", string.Join(", ", aux));
            Console.WriteLine("Torre C: [{0}]", string.Join(", ", target));
            Console.WriteLine();
        }

        /// <summary>
        /// Resuelve el problema de las Torres de Hanoi moviendo n discos
        /// de la torre 'source' a la torre 'target' usando 'auxiliary'.
        /// </summary>
        /// <param name="n">Número de discos.</param>
        /// <param name="source">Pila origen.</param>
        /// <param name="srcName">Nombre de la torre origen.</param>
        /// <param name="aux">Pila auxiliar.</param>
        /// <param name="auxName">Nombre de la torre auxiliar.</param>
        /// <param name="target">Pila destino.</param>
        /// <param name="tgtName">Nombre de la torre destino.</param>
        static void SolveHanoi(int n, Stack<int> source, string srcName,
                               Stack<int> aux, string auxName,
                               Stack<int> target, string tgtName)
        {
            if (n <= 0) return;

            // Mover n-1 discos de source a aux
            SolveHanoi(n - 1, source, srcName, target, tgtName, aux, auxName);

            // Mover el disco restante de source a target
            int disk = source.Pop();
            target.Push(disk);
            Console.WriteLine($"Mover disco {disk} de {srcName} a {tgtName}");
            PrintTowers(source, aux, target);

            // Mover los discos de aux a target
            SolveHanoi(n - 1, aux, auxName, source, srcName, target, tgtName);
        }
    }
}

