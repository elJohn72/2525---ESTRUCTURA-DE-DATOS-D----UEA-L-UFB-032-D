using System;
using System.Collections.Generic;

namespace PracticaEstructuras
{
    public class CustomQueue<T>
    {
        private readonly LinkedList<T> _elements = new();

        /// <summary> Número de elementos en la cola. </summary>
        public int Count => _elements.Count;

        /// <summary> Inserta un elemento al final de la cola. </summary>
        public void Enqueue(T item) => _elements.AddLast(item);

        /// <summary> Retira y devuelve el elemento del frente; lanza si está vacía. </summary>
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Cola vacía");
            T front = _elements.First.Value;
            _elements.RemoveFirst();
            return front;
        }

        /// <summary> Devuelve el elemento del frente sin retirarlo; lanza si está vacía. </summary>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Cola vacía");
            return _elements.First.Value;
        }
    }
}
