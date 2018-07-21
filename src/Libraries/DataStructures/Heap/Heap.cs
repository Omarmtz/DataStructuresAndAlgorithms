using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Heap
{
    public enum HeapType
    {
        MaxHeap,
        MinHeap
    }

    public class Heap<T> where T : IComparable<T>
    {
        private const int DEFAULT_CAPACITY = 1000;

        private readonly Comparison<T> comparisionMethod;
        private readonly Comparison<T> minComparision = (a, b) => a.CompareTo(b);
        private readonly Comparison<T> maxComparision = (a, b) => b.CompareTo(a);

        private T[] array;
        private int size;
        private int capacity;

        public Heap(HeapType heapType = HeapType.MinHeap,int capacity = DEFAULT_CAPACITY)
        {
            size = 0;            
            array = new T[size];
            this.capacity = capacity;

            switch (heapType)
            {
                case HeapType.MaxHeap:
                    comparisionMethod = maxComparision;
                    break;
                default:
                    comparisionMethod = minComparision;
                    break;
            }
        }

        public void Insert(T item)
        {
            if (size == capacity)
            {
                capacity *= 2;
                Array.Resize(ref array, capacity * 2);
            }
            array[size] = item;
            size++;
        }
        
        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void ChangePriority(T value, T newValue)
        {
            throw new NotImplementedException();
        }

        public void Heapify(ref T[] array)
        {
            throw new NotImplementedException();
        }

        private void SiftDown(int index)
        {
            throw new NotImplementedException();
        }

        private void SiftUp(int up)
        {
            throw new NotImplementedException();
        }

        private int GetParentIndex(int index)
        {
            throw new NotImplementedException();
        }

        private int GetLeftChildrenIndex(int index)
        {
            throw new NotImplementedException();
        }

        private int GetRightChildrenIndex(int index)
        {
            throw new NotImplementedException();
        }

    }
}
