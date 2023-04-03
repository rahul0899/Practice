using System;
using System.Collections.Generic;

class PriorityQueue<T>
{
    private Dictionary<T, int> elements = new Dictionary<T, int>();
    private List<(int, T)> heap = new List<(int, T)>();

    public void Enqueue(T element, int priority)
    {
        elements[element] = priority;
        heap.Add((priority, element));
        int i = heap.Count - 1;
        while (i > 0)
        {
            int parent = (i - 1) / 2;
            if (heap[parent].Item1 <= heap[i].Item1) break;
            (heap[parent], heap[i]) = (heap[i], heap[parent]);
            i = parent;
        }
    }

    public T Dequeue()
    {
        int lastIndex = heap.Count - 1;
        (heap[0], heap[lastIndex]) = (heap[lastIndex], heap[0]);
        T element = heap[lastIndex].Item2;
        heap.RemoveAt(lastIndex);
        elements.Remove(element);
        int i = 0;
        while (true)
        {
            int leftChild = 2 * i + 1;
            int rightChild = 2 * i + 2;
            if (leftChild >= heap.Count) break;
            int minChild = (rightChild >= heap.Count || heap[leftChild].Item1 <= heap[rightChild].Item1) ? leftChild : rightChild;
            if (heap[i].Item1 <= heap[minChild].Item1) break;
            (heap[i], heap[minChild]) = (heap[minChild], heap[i]);
            i = minChild;
        }
        return element;
    }

    public T GetHighestPriority()
    {
        return heap[0].Item2;
    }

    public bool IsEmpty()
    {
        return heap.Count == 0;
    }
}
class Program
{
    static void Main(string[] args)
    {
        PriorityQueue<string> queue = new PriorityQueue<string>();

        while (true)
        {
            Console.WriteLine("Enter a command: (enqueue, dequeue, peek, contains, size, reverse, center, traverse, quit)");
            string command = Console.ReadLine().ToLower();

            try
            {
                switch (command)
                {
                    case "enqueue":
                        Console.WriteLine("Enter an item to add:");
                        string item = Console.ReadLine();
                        Console.WriteLine("Enter the item's priority (an integer):");
                        int priority = int.Parse(Console.ReadLine());
                        queue.Enqueue(item, priority);
                        Console.WriteLine("Item added to queue");
                        break;

                    case "dequeue":
                        string dequeued = queue.Dequeue();
                        Console.WriteLine("Dequeued item: {0}", dequeued);
                        break;
                    default:

                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: {0}", ex.Message);
            }
        }
    }
}