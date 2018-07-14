using DataStructures.NodeDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.BinaryTree
{
    public class BinaryTree<T> : IDisposable where T : IComparable
    {
        protected BinaryTreeNode<T> root;
        protected int size;

        public BinaryTree()
        {
            root = null;
            size = 0;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public int Count
        {
            get { return size; }
        }

        public virtual void Insert(T item)
        {
            if (root == null)
            {
                root = new BinaryTreeNode<T>(item);
                size++;
                return;
            }

            Insert(root, item);
        }

        protected virtual void Insert(BinaryTreeNode<T> node, T item)
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
                    BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(item);
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
                    BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(item);
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

        public virtual void Clear()
        {
            Dispose();
        }

        public virtual void Dispose()
        {
            this.root = null;
            size = 0;
        }

        public bool Contains(T item)
        {
            return FindNode(root, item) != null;
        }

        public virtual void Remove(T item)
        {
            BinaryTreeNode<T> node = FindNode(root, item);
            if (node == null)
            {
                return;
            }

            if (node.Left == null && node.Right == null)
            {
                FirstDeletionCase(node);
            }
            else if (node.Left != null && node.Right == null)
            {
                SecondDeletionCaseLeft(node);
            }
            else if (node.Left == null && node.Right != null)
            {
                SecondDeletionCaseRight(node);
            }
            else
            {
                ThirdDeletionCase(node);
            }
            size--;
        }

        private void ThirdDeletionCase(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> nextNode = FindNextNode(node);
            node.Data = nextNode.Data;
            if (nextNode == nextNode.Parent.Left)
            {
                nextNode.Parent.Left = null;
            }
            else
            {
                nextNode.Parent.Right = null;
            }
        }

        private void SecondDeletionCaseRight(BinaryTreeNode<T> node)
        {
            if (node == node.Parent.Left)
            {
                node.Parent.Left = node.Right;
            }
            else
            {
                node.Parent.Right = node.Right;
            }
        }

        private void SecondDeletionCaseLeft(BinaryTreeNode<T> node)
        {
            if (node == node.Parent.Left)
            {
                node.Parent.Left = node.Left;
            }
            else
            {
                node.Parent.Right = node.Left;
            }
        }

        private void FirstDeletionCase(BinaryTreeNode<T> node)
        {
            if (node.Parent != null && node == node.Parent.Left)
            {
                node.Parent.Left = null;
            }
            else if (node.Parent != null)
            {
                node.Parent.Right = null;
            }
            else
            {
                root = null;
            }
        }

        protected BinaryTreeNode<T> FindNextNode(BinaryTreeNode<T> node)
        {
            if (node.Right != null)
            {
                return LeftDescendant(node.Right);
            }
            else
            {
                return RightAncestor(node);
            }
        }

        private BinaryTreeNode<T> RightAncestor(BinaryTreeNode<T> node)
        {
            if(node.Parent == null)
            {
                return null;
            }
            if(node.Data.CompareTo(node.Parent.Data) == -1)
            {
                return node.Parent;
            }
            return RightAncestor(node.Parent);
        }

        private BinaryTreeNode<T> LeftDescendant(BinaryTreeNode<T> node)
        {
            if(node == null)
            {
                return null;
            }
            if(node.Left == null)
            {
                return node;
            }
            return LeftDescendant(node.Left);
        }

        protected BinaryTreeNode<T> FindNode(BinaryTreeNode<T> node, T item)
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

        private void PreOrderList(BinaryTreeNode<T> node, List<T> list)
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

        private void InOrderList(BinaryTreeNode<T> node, List<T> list)
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

        private void PostOrderList(BinaryTreeNode<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            PostOrderList(node.Left, list);
            PostOrderList(node.Right, list);
            list.Add(node.Data);
        }

        public virtual T this[int index]
        {
            get
            {
                return GetInOrderList()[index];
            }            
        }

        #endregion

        #region Min,Max and Range

        public T Max()
        {
            return Max(root);
        }

        private T Max(BinaryTreeNode<T> root)
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

        private T Min(BinaryTreeNode<T> root)
        {
            if (root.Left == null)
            {
                return root.Data;
            }
            return Min(root.Left);
        }

        public List<T> GetRange(T min, T max)
        {
            var rangeList = new List<T>();

            if(IsEmpty())
            {
                return rangeList;
            }

            var nodeTmp = FindNextCloseNode(root, min);

            while(nodeTmp != null && nodeTmp.Data.CompareTo(max) != 1)
            {
                rangeList.Add(nodeTmp.Data);
                nodeTmp = FindNextNode(nodeTmp);
            }

            return rangeList;
        }

        private BinaryTreeNode<T> FindNextCloseNode(BinaryTreeNode<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Data.CompareTo(item) == 1)
            {
                var nodeCompare = FindNextCloseNode(node.Left, item);
                return nodeCompare ?? node;
            }
            else if (node.Data.CompareTo(item) == -1)
            {
                var nodeCompare = FindNextCloseNode(node.Right, item);
                return nodeCompare ?? node;
            }
            else
            {
                return node;
            }
        }

        #endregion

    }
}
