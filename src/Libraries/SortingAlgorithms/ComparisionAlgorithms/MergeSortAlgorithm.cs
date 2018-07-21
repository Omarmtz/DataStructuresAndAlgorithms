using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.ComparisionAlgorithms
{
    public class MergeSortAlgorithm<T> : ISort<T> where T : IComparable
    {
        private readonly Comparison<T> _defaultCompareFunction = (a, b) => a.CompareTo(b);

        public void Sort(T[] array, Comparison<T> compareFunction)
        {
            MergeSort(array, 0, array.Length - 1, compareFunction);
        }

        public void Sort(T[] array)
        {
            MergeSort(array, 0, array.Length - 1, _defaultCompareFunction);
        }

        private void MergeSort(T[] array, int left, int right, Comparison<T> compareFunction)
        {
            if (right <= left)
            {
                return;
            }

            //Divide
            var mid = (int)Math.Floor((left + right) / 2f);            
            MergeSort(array, left, mid, compareFunction);
            MergeSort(array, mid + 1, right, compareFunction);
            //Merge (Conquer)                        
            Merge(array, left, mid, right, compareFunction);
        }

        private void Merge(T[] array, int left, int mid, int right, Comparison<T> compareFunction)
        {
            var leftArrayLength = (mid == left) ? 1 : (mid + 1 - left);
            var rightArrayLength = (mid + 1 == right) ? 1 : (right - mid);

            var tmpLeftArray = GetSubArray(array, left, leftArrayLength);
            var tmpRightArray = GetSubArray(array, mid + 1, rightArrayLength);

            int i = 0;
            int j = 0;
            int k = left;

            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (compareFunction(tmpLeftArray[i], tmpRightArray[j]) <= 0)
                {
                    array[k] = tmpLeftArray[i];
                    i++;
                }
                else
                {
                    array[k] = tmpRightArray[j];
                    j++;
                }
                k++;
            }

            while (i < leftArrayLength)
            {
                array[k] = tmpLeftArray[i];
                i++;
                k++;
            }

            while (j < rightArrayLength)
            {
                array[k] = tmpRightArray[j];
                j++;
                k++;
            }
        }

        private T[] GetSubArray(T[] data, int targetIndex, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, targetIndex, result, 0, length);
            return result;
        }
    }
}
