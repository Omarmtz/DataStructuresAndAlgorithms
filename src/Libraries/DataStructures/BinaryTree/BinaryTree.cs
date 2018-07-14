using DataStructures.NodeDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.BinaryTree
{
    public class BinaryTree<T> : IDisposable where T : IComparable
    {
        private NodeTree<T> root;
        private int size;

        public BinaryTree()
        {
            root = null;
            size = 0;
        }

        public int Count
        {
            get { return size; }
        }

        public void Insert(T item)
        {
            if (root == null)
            {
                root = new NodeTree<T>(item);
                size++;
                return;
            }

            Insert(root, item);
        }

        private void Insert(NodeTree<T> node, T item)
        {
            if (node == null)
            {
                return;
            }

            if (node.Data.CompareTo(item) == 1)
            {
                Insert(node.Left, item);

                if (node.Left == null)
                {
                    NodeTree<T> newNode = new NodeTree<T>(item);
                    newNode.Parent = node;
                    node.Left = newNode;
                    size++;
                }
            }
            else if (node.Data.CompareTo(item) == -1)
            {
                Insert(node.Right, item);

                if (node.Right == null)
                {
                    NodeTree<T> newNode = new NodeTree<T>(item);
                    newNode.Parent = node;
                    node.Right = newNode;
                    size++;
                }
            }
            else
            {
                throw new Exception("Cannot have duplicated values");
            }
        }

        public void Remove(T item)
        {

        }

        public void Clear()
        {
            Dispose();
        }

        public void Dispose()
        {
            this.root = null;
            size = 0;
        }

        public bool Contains(T item)
        {
            return FindNode(root, item) != null;
        }

        private NodeTree<T> FindNode(NodeTree<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Data.CompareTo(item) == 1)
            {
                return FindNode(node.Left, item);
            }
            else if (node.Data.CompareTo(item) == -1)
            {
                return FindNode(node.Right, item);
            }
            else
            {
                return node;
            }
        }

        #region TreeTraversal
        public List<T> GetPreorderList()
        {
            List<T> list = new List<T>(size);
            PreOrderList(root, list);
            return list;
        }

        private void PreOrderList(NodeTree<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }
            list.Add(node.Data);
            PreOrderList(node.Left, list);
            PreOrderList(node.Right, list);
        }

        public List<T> GetInOrderList()
        {
            List<T> list = new List<T>(size);
            InOrderList(root, list);
            return list;
        }

        private void InOrderList(NodeTree<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            InOrderList(node.Left, list);
            list.Add(node.Data);
            InOrderList(node.Right, list);
        }

        public List<T> GetPostOrderList()
        {
            List<T> list = new List<T>(size);
            PostOrderList(root, list);
            return list;
        }

        private void PostOrderList(NodeTree<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            PostOrderList(node.Left, list);
            PostOrderList(node.Right, list);
            list.Add(node.Data);
        }
        #endregion

        #region Min,Max and Range
        public T Max()
        {
            return Max(root);
        }

        private T Max(NodeTree<T> root)
        {
            if (root.Right == null)
            {
                return root.Data;
            }
            return Max(root.Right);
        }

        public T Min()
        {
            return Min(root);
        }

        private T Min(NodeTree<T> root)
        {
            if (root.Left == null)
            {
                return root.Data;
            }
            return Min(root.Left);
        }

        public List<T> GetRange(T min, T max)
        {
            return null;
        }
        #endregion

    }
}
