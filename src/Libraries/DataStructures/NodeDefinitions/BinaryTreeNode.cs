using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.NodeDefinitions
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> Parent { get; set; }
        public BinaryTreeNode<T> Left{ get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public int Height { get; set; }
        public T Data { get; set; }

        public BinaryTreeNode(T item)
        {
            Height = 0;
            Data = item;
        }
    }
}
