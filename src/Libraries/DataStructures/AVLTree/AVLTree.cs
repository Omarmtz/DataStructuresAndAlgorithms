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
                var parentNode = node.Parent;
                Rebalance(parentNode);
            }
        }

        private void RebalanceRight(BinaryTreeNode<T> node)
        {
            if (node.Left.Right != null)
            {
                RotateLeft(node.Left);
            }
            RotateRight(node);
        }

        private void RebalanceLeft(BinaryTreeNode<T> node)
        {
            if (node.Right.Left != null)
            {
                RotateRight(node.Right);
            }
            RotateLeft(node);
        }

        private void RotateLeft(BinaryTreeNode<T> node)
        {

        }

        private void RotateRight(BinaryTreeNode<T> node)
        {

        }

        private bool IsBalancedNode(BinaryTreeNode<T> node)
        {
            var balanceFactor = node.LeftHeight - node.RightHeight;
            return balanceFactor >= -1 && balanceFactor <= 1;
        }
    }
}
