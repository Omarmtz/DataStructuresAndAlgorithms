using DataStructures.BinaryTree;
using DataStructures.NodeDefinitions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.AVLTree
{
    public class AVLTree<T> : BinaryTree<T> where T : IComparable
    {
        public AVLTree() :
            base()
        {
        }

        public override void Insert(T item)
        {
            base.Insert(item);

            var newNode = FindNode(root, item);
            AdjustHeight(newNode);
            Rebalance(newNode);
        }

        public override void Remove(T item)
        {
            base.Remove(item);
        }

        protected void AdjustHeight(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            node.Height = Math.Max(node.LeftHeight, node.RightHeight) + 1;
            AdjustHeight(node.Parent);
        }

        protected void Rebalance(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftHeight > node.RightHeight + 1)
            {
                RebalanceRight(node);
            }
            else if (node.RightHeight > node.LeftHeight + 1)
            {
                RebalanceLeft(node);
            }

            Rebalance(node.Parent);
        }

        private void RebalanceRight(BinaryTreeNode<T> node)
        {
            if (node.Left?.RightHeight > node.Left?.LeftHeight)
            {
                RotateLeft(node.Left);
            }
            RotateRight(node);
        }

        private void RebalanceLeft(BinaryTreeNode<T> node)
        {
            if (node.Left?.LeftHeight > node.Left?.RightHeight)
            {
                RotateRight(node.Right);
            }
            RotateLeft(node);
        }

        private void RotateLeft(BinaryTreeNode<T> A)
        {
            var B = A.Right;
            B.Parent = A.Parent;
            if (B.Parent != null)
            {
                if (B.Parent != null && B.Parent.Left == A)
                {
                    B.Parent.Left = B;
                }
                else if (B.Parent != null && B.Parent.Right == A)
                {
                    B.Parent.Right = B;
                }
            }

            A.Right = B.Left;
            if (A.Right != null)
            {
                A.Right.Parent = A;
            }

            B.Left = A;
            A.Parent = B;

            AdjustHeight(A);
            AdjustHeight(A.Right);

            if (B.Parent == null)
            {
                root = B;
            }
        }

        private void RotateRight(BinaryTreeNode<T> A)
        {
            var B = A.Left;
            B.Parent = A.Parent;
            if (B.Parent != null)
            {
                if (B.Parent != null && B.Parent.Left == A)
                {
                    B.Parent.Left = B;
                }
                else if (B.Parent != null && B.Parent.Right == A)
                {
                    B.Parent.Right = B;
                }
            }

            A.Left = B.Right;
            if (A.Left != null)
            {
                A.Left.Parent = A;
            }

            B.Right = A;
            A.Parent = B;

            AdjustHeight(A);
            AdjustHeight(A.Left);

            if (B.Parent == null)
            {
                root = B;
            }
        }
    }
}
