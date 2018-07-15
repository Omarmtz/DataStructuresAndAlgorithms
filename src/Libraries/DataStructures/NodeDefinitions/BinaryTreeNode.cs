using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.NodeDefinitions
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> Parent { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public int Height { get; set; }
        public T Data { get; set; }

        public BinaryTreeNode(T item)
        {
            Data = item;
        }

        public BinaryTreeNode(BinaryTreeNode<T> node)
        {
            this.Parent = node.Parent;
            this.Left = node.Left;
            this.Right = node.Right;
            this.Height = node.Height;
            this.Data = node.Data;
        }

        public int RightHeight => (Right == null) ? 0 : Right.Height;

        public int LeftHeight => (Left == null) ? 0 : Left.Height;


    }
}
