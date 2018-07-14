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
            CalculateHeight(newNode);

            BalanceTree(newNode);            
        }

        public override void Remove(T item)
        {
            base.Remove(item);
        }

        protected void CalculateHeight(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            if (node.Left != null && node.Right != null)
            {
                node.Height = Math.Max(node.Left.Height, node.Right.Height) + 1;
            }
            else if (node.Left != null && node.Right == null)
            {
                node.Height = node.Left.Height + 1;
            }
            else if (node.Left == null && node.Right != null)
            {
                node.Height = node.Right.Height + 1;
            }
            CalculateHeight(node.Parent);
        }

        protected void BalanceTree(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            BalanceTree(node.Parent);
        }

        private bool IsBalancedNode(BinaryTreeNode<T> node)
        {
            var leftHeight = (node.Left == null) ? 0 : node.Left.Height;
            var rightHeight = (node.Right == null) ? 0 : node.Right.Height;

            var balanceFactor = leftHeight - rightHeight;

            return balanceFactor >= -1 && balanceFactor <= 1;
        }
    }
}
