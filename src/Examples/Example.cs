using DataStructures.BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    static class Example
    {
        public static void Main()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            

            binaryTree.Insert(45);
            binaryTree.Insert(65);
            binaryTree.Insert(34);
            binaryTree.Insert(84);
            binaryTree.Insert(24);
            binaryTree.Insert(3);
            binaryTree.Insert(5);
            binaryTree.Insert(45);

            var max = binaryTree.Max();
            var min = binaryTree.Min();
            var preorder = binaryTree.GetPreorderList();
            var inorder = binaryTree.GetInOrderList();
            var postorder = binaryTree.GetPostOrderList();

            Console.WriteLine("EXAMPLES!");
        }
    }
}
