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

            if (!IsBalancedNode(node))
            {
                if (node.RightHeight > node.LeftHeight)
                {
                    RebalanceLeft(node);
                }
                else if (node.LeftHeight > node.RightHeight)
                {
                    RebalanceRight(node);
                }
            }

            if (node.Parent != null)
            {                
                Rebalance(node.Parent);
            }
        }

        private void RebalanceRight(BinaryTreeNode<T> node)
        {
            if (node.Left.Right != null)
            {
                RotateLeft(node.Left);
                node.Left = node.Left.Parent;
                AdjustHeight(node.Left);
            }
            RotateRight(node);
        }

        private void RebalanceLeft(BinaryTreeNode<T> node)
        {
            if (node.Right.Left != null)
            {                
                RotateRight(node.Right);
                node.Right = node.Right.Parent;
                AdjustHeight(node.Right);
            }
            RotateLeft(node);
        }

        private void RotateLeft(BinaryTreeNode<T> node)
        {
            node.Right.Left = node;
            node.Right.Parent = node.Parent;

            node.Parent = node.Right;
            node.Right = null;
            
            AdjustHeight(node);

            if (node == root)
            {
                root = node.Parent;
            }
            else
            {
                if (node.Parent != null && node.Parent.Left == node)
                {
                    node.Parent.Left = node;
                }
                else if (node.Parent != null && node.Parent.Right == node)
                {
                    node.Parent.Right = node;
                }
                node = node.Parent;
            }            
        }

        private void RotateRight(BinaryTreeNode<T> node)
        {
            node.Left.Right = node;
            node.Left.Parent = node.Parent;

            node.Parent = node.Left;
            node.Left = null;

            AdjustHeight(node);

            if (node == root)
            {
                root = node.Parent;
            }
            else
            {                
                if(node.Parent != null && node.Parent.Left == node)
                {
                    node.Parent.Left = node;
                }
                else if (node.Parent != null && node.Parent.Right == node)
                {
                    node.Parent.Right = node;
                }
                node = node.Parent;
            }
        }

        private bool IsBalancedNode(BinaryTreeNode<T> node)
        {
            var balanceFactor = node.LeftHeight - node.RightHeight;
            return balanceFactor >= -1 && balanceFactor <= 1;
        }
    }
}
