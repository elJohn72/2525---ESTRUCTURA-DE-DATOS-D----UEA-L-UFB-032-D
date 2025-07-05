// Definición de la clase Nodo que representa un elemento de la lista
using System;

class Nodo
{
    public int Dato; // Valor del nodo
    public Nodo Siguiente; // Referencia al siguiente nodo

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

// Clase que representa la lista enlazada
class ListaEnlazada
{
    private Nodo cabeza; // Referencia al primer nodo de la lista

    // Método para insertar un nuevo nodo al inicio de la lista
    public void InsertarInicio(int dato)
    {
        Nodo nuevoNodo = new Nodo(dato);
        nuevoNodo.Siguiente = cabeza; // El nuevo nodo apunta al anterior primer nodo
        cabeza = nuevoNodo; // La cabeza ahora es el nuevo nodo
    }

    // Método para invertir la lista enlazada
    public void Invertir()
    {
        Nodo anterior = null;
        Nodo actual = cabeza;
        Nodo siguiente = null;

        // Recorre la lista y va invirtiendo los punteros
        while (actual != null)
        {
            siguiente = actual.Siguiente; // Guarda la referencia al siguiente nodo
            actual.Siguiente = anterior; // Invierte el enlace
            anterior = actual; // Avanza el puntero anterior
            actual = siguiente; // Avanza el puntero actual
        }

        cabeza = anterior; // La nueva cabeza es el último nodo procesado
    }

    // Método para imprimir los elementos de la lista
    public void Imprimir()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Dato + " -> "); // Imprime el valor del nodo
            actual = actual.Siguiente;
        }
        Console.WriteLine("NULL"); // Fin de la lista
    }
}

// Clase principal que contiene el método Main
class Programa
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

        // Inserta elementos en la lista
        lista.InsertarInicio(10);
        lista.InsertarInicio(20);
        lista.InsertarInicio(30);

        Console.WriteLine("Lista original:");
        lista.Imprimir(); // Muestra la lista antes de invertir

        lista.Invertir(); // Invierte el orden de los nodos

        Console.WriteLine("Lista invertida:");
        lista.Imprimir(); // Muestra la lista después de invertir
    }
}
