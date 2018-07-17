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
            Rebalance(newNode);
        }

        public override void Remove(T item)
        {
            BinaryTreeNode<T> node = FindNode(root, item);
            var referenceNode = Remove(node);
            Rebalance(referenceNode);
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

        private void RotateLeft(BinaryTreeNode<T> node)
        {
            var rightNode = node.Right;
            rightNode.Parent = node.Parent;
            if (rightNode.Parent != null)
            {
                if (rightNode.Parent != null && rightNode.Parent.Left == node)
                {
                    rightNode.Parent.Left = rightNode;
                }
                else if (rightNode.Parent != null && rightNode.Parent.Right == node)
                {
                    rightNode.Parent.Right = rightNode;
                }
            }

            node.Right = rightNode.Left;
            if (node.Right != null)
            {
                node.Right.Parent = node;
            }

            rightNode.Left = node;
            node.Parent = rightNode;

            AdjustHeight(node);
            AdjustHeight(node.Right);

            if (rightNode.Parent == null)
            {
                root = rightNode;
            }
        }

        private void RotateRight(BinaryTreeNode<T> node)
        {
            var leftNode = node.Left;
            leftNode.Parent = node.Parent;
            if (leftNode.Parent != null)
            {
                if (leftNode.Parent != null && leftNode.Parent.Left == node)
                {
                    leftNode.Parent.Left = leftNode;
                }
                else if (leftNode.Parent != null && leftNode.Parent.Right == node)
                {
                    leftNode.Parent.Right = leftNode;
                }
            }

            node.Left = leftNode.Right;
            if (node.Left != null)
            {
                node.Left.Parent = node;
            }

            leftNode.Right = node;
            node.Parent = leftNode;

            AdjustHeight(node);
            AdjustHeight(node.Left);

            if (leftNode.Parent == null)
            {
                root = leftNode;
            }
        }
    }
}
