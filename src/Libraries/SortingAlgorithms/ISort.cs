using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    public interface ISort<T> where T: IComparable
    {
        void Sort(T[] array, Comparison<T> comparable);
        void Sort(T[] array);
    }
}
