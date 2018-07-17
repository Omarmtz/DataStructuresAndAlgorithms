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
            if (node.Parent == null)
            {
                return null;
            }
            if (node.Data.CompareTo(node.Parent.Data) == -1)
            {
                return node.Parent;
            }
            return RightAncestor(node.Parent);
        }

        private BinaryTreeNode<T> LeftDescendant(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Left == null)
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

        #region Insertion

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
                    AdjustHeight(newNode);
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
                    AdjustHeight(newNode);
                }
            }
            else
            {
                throw new Exception("Cannot have duplicated values");
            }
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

        #endregion

        #region Deletion

        public virtual void Remove(T item)
        {
            BinaryTreeNode<T> node = FindNode(root, item);
            Remove(node);                       
        }

        protected virtual BinaryTreeNode<T> Remove(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> replacedNode = null;
            if (node == null)
            {
                return replacedNode;
            }

            if (NodeHasNoChildrens(node))
            {
                replacedNode = DeleteCaseNoChildrens(node);
            }
            else if (NodeHasOneChildren(node))
            {
                replacedNode = DeleteCaseOneChildren(node);
            }
            else if (NodeHasTwoChildrens(node))
            {
                replacedNode = DeleteCaseTwoChildrens(node);
            }
            size--;
            return replacedNode;
        }

        private BinaryTreeNode<T> DeleteCaseTwoChildrens(BinaryTreeNode<T> node)
        {
            var nextNode = FindNextNode(node);

            node.Data = nextNode.Data;

            if (nextNode.Parent != null && nextNode.Parent.Left == nextNode)
            {
                nextNode.Parent.Left = null;
            }
            else if (nextNode.Parent != null && nextNode.Parent.Right == nextNode)
            {
                nextNode.Parent.Right = null;
            }
            AdjustHeight(nextNode.Parent);
            return nextNode.Parent;
        }

        private BinaryTreeNode<T> DeleteCaseOneChildren(BinaryTreeNode<T> node)
        {
            if (node.Left != null)
            {
                node.Data = node.Left.Data;
                node.Right = node.Left.Right;
                node.Left = node.Left.Left;
                node.Left = null;
            }
            else if (node.Right != null)
            {
                node.Data = node.Right.Data;
                node.Left = node.Right.Left;
                node.Right = node.Right.Right;
                node.Right = null;
            }
            AdjustHeight(node);

            return node;
        }

        private BinaryTreeNode<T> DeleteCaseNoChildrens(BinaryTreeNode<T> node)
        {
            if (node.Parent != null && node.Parent.Left == node)
            {
                node.Parent.Left = null;
            }
            else if (node.Parent != null && node.Parent.Right == node)
            {
                node.Parent.Right = null;
            }
            AdjustHeight(node.Parent);
            if (root == node)
            {
                root = null;
            }
            return node.Parent;
        }

        private bool NodeHasTwoChildrens(BinaryTreeNode<T> node)
        {
            return (node.Left != null && node.Right != null);
        }

        private bool NodeHasOneChildren(BinaryTreeNode<T> node)
        {
            return (node.Left == null && node.Right != null) || (node.Left != null && node.Right == null);
        }

        private bool NodeHasNoChildrens(BinaryTreeNode<T> node)
        {
            return node.Left == null && node.Right == null;
        }

        #endregion        

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

            if (IsEmpty())
            {
                return rangeList;
            }

            var nodeTmp = FindNextCloseNode(root, min);

            while (nodeTmp != null && nodeTmp.Data.CompareTo(max) != 1)
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
