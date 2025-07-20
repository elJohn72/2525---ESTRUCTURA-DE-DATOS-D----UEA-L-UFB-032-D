using System;
using PracticaEstructuras;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Prueba de CustomStack<T> (LIFO) ===");
        var stack = new CustomStack<string>();
        stack.Push("Paciente A");
        stack.Push("Paciente B");
        stack.Push("Paciente C");
        Console.WriteLine($"Pop:  {stack.Pop()}");   // Paciente C
        Console.WriteLine($"Peek: {stack.Peek()}");  // Paciente B
        Console.WriteLine($"Pop:  {stack.Pop()}");   // Paciente B
        Console.WriteLine($"Pop:  {stack.Pop()}");   // Paciente A

        Console.WriteLine("\n=== Prueba de CustomQueue<T> (FIFO) ===");
        var queue = new CustomQueue<int>();
        for (int i = 1; i <= 5; i++)
        {
            queue.Enqueue(i);
            Console.WriteLine($"Enqueued: {i}");
        }
        while (queue.Count > 0)
        {
            Console.WriteLine($"Dequeued: {queue.Dequeue()}");
        }

        // Manejo de excepciones
        try
        {
            stack.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"\nError pila: {ex.Message}");
        }

        try
        {
            queue.Dequeue();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error cola: {ex.Message}");
        }
    }
}
