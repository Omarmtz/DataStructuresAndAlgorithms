using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.NodeDefinitions
{
    internal class NodeTree<T>
    {
        public NodeTree<T> Parent { get; set; }
        public NodeTree<T> Left{ get; set; }
        public NodeTree<T> Right { get; set; }

        public int Height { get; set; }
        public T Data { get; set; }

        public NodeTree(T item)
        {
            Height = 0;
            Data = item;
        }
    }
}
