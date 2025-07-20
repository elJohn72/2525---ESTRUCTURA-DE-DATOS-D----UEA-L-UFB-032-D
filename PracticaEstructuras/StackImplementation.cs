using System;
using System.Collections.Generic;

namespace PracticaEstructuras
{
    public class CustomStack<T>
    {
        private readonly List<T> _elements = new();

        /// <summary> Número de elementos en la pila. </summary>
        public int Count => _elements.Count;

        /// <summary> Inserta un elemento en el tope de la pila. </summary>
        public void Push(T item) => _elements.Add(item);

        /// <summary> Retira y devuelve el elemento del tope; lanza si está vacía. </summary>
        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Pila vacía");
            T top = _elements[^1];
            _elements.RemoveAt(Count - 1);
            return top;
        }

        /// <summary> Devuelve el elemento del tope sin retirarlo; lanza si está vacía. </summary>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Pila vacía");
            return _elements[^1];
        }
    }
}
