using DataStructures.BinaryTree;
using System;
using Xunit;

namespace DataStructuresTests
{
    public class BinaryTreeTests
    {
        [Fact]
        public void Insert_Empty_InsertsElement()
        {
            var binaryTree = new BinaryTree<int>();
            binaryTree.Insert(1);

            Assert.Equal(1, binaryTree.Max());
            Assert.Equal(1, binaryTree.Min());
            Assert.Equal(1, binaryTree.Count);
            Assert.Equal(1, binaryTree[0]);
        }
    }
}
