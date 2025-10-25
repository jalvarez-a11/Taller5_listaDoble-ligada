using System;
using System.Collections.Generic;
using System.Linq;

namespace DoubleLinkedList
{
    public class DoubleLinkedList<T>
    {
        private class Node
        {
            public T Data;
            public Node? Next;
            public Node? Prev;

            public Node(T data)
            {
                Data = data;
            }
        }
        private Node? head;
        private Node? tail;
        public bool IsEmpty => head == null;
        private int Compare(T a, T b)
        {
            if (a == null || b == null) return 0;

            // Si son números
            if (double.TryParse(a.ToString(), out double da) &&
                double.TryParse(b.ToString(), out double db))
            {
                if (da < db) return -1;
                if (da > db) return 1;
                return 0;
            }
            // Si son texto
            return string.Compare(a.ToString(), b.ToString(), StringComparison.OrdinalIgnoreCase);
        }
        public void Add(T data)
        {
            var newNode = new Node(data);

            if (IsEmpty)
            {
                head = tail = newNode;
                return;
            }
            Node? current = head;
            while (current != null && Compare(current.Data, data) < 0)
                current = current.Next;

            if (current == null)
            {
                // Insertar al final
                tail!.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            else if (current == head)
            {
                // Insertar al inicio
                newNode.Next = head;
                head!.Prev = newNode;
                head = newNode;
            }
            else
            {
                // Insertar en medio
                newNode.Next = current;
                newNode.Prev = current.Prev;
                if (current.Prev != null)
                    current.Prev.Next = newNode;
                current.Prev = newNode;
            }
        }
        public void PrintForward()
        {
            if (IsEmpty)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }
            var current = head;
            Console.Write("Lista (adelante): ");
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
        public void PrintBackward()
        {
            if (IsEmpty)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            var current = tail;
            Console.Write("Lista (atrás): ");
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Prev;
            }
            Console.WriteLine();
        }
        public void SortDescending()
        {
            if (IsEmpty) return;

            var items = new List<T>();
            var current = head;
            while (current != null)
            {
                items.Add(current.Data);
                current = current.Next;
            }
            // Revertir el orden actual
            items.Reverse();
            // Vaciar y volver a llenar
            head = tail = null;
            foreach (var item in items)
                Add(item);
        }
        public bool Exists(T value)
        {
            var current = head;
            while (current != null)
            {
                if (current.Data!.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public void RemoveOne(T value)
        {
            if (IsEmpty)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }
            var current = head;
            while (current != null)
            {
                if (Equals(current.Data, value))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        head = current.Next;
                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                    else
                        tail = current.Prev;
                    Console.WriteLine($"Elemento '{value}' eliminado.");
                    return;
                }
                current = current.Next;
            }
            Console.WriteLine($"Elemento '{value}' no encontrado.");
        }
        public void RemoveAll(T value)
        {
            if (IsEmpty)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }
            var current = head;
            bool found = false;
            while (current != null)
            {
                if (Equals(current.Data, value))
                {
                    var toDelete = current;
                    if (toDelete.Prev != null)
                        toDelete.Prev.Next = toDelete.Next;
                    else
                        head = toDelete.Next;
                    if (toDelete.Next != null)
                        toDelete.Next.Prev = toDelete.Prev;
                    else
                        tail = toDelete.Prev;
                    found = true;
                }
                current = current.Next;
            }
            if (found)
                Console.WriteLine($"Se eliminaron todas las ocurrencias de '{value}'.");
            else
                Console.WriteLine($"No se encontraron ocurrencias de '{value}'.");
        }
        // Mostrar moda(s)
        public void ShowModes()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Lista vacía.");
                return;
            }

            var counts = new Dictionary<T, int>();
            var current = head;
            while (current != null)
            {
                if (counts.ContainsKey(current.Data))
                    counts[current.Data]++;
                else
                    counts[current.Data] = 1;
                current = current.Next;
            }

            int max = counts.Values.Max();
            var modes = counts.Where(kv => kv.Value == max).Select(kv => kv.Key);

            Console.WriteLine("Moda(s): " + string.Join(", ", modes));
        }
        // Mostrar gráfico de ocurrencias
        public void ShowGraph()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Lista vacía.");
                return;
            }

            var counts = new Dictionary<T, int>();
            var current = head;
            while (current != null)
            {
                if (counts.ContainsKey(current.Data))
                    counts[current.Data]++;
                else
                    counts[current.Data] = 1;
                current = current.Next;
            }

            Console.WriteLine("\nGráfico de ocurrencias:");
            foreach (var kv in counts)
            {
                Console.Write($"{kv.Key}: ");
                Console.WriteLine(new string('*', kv.Value));
            }
        }
    }
}
