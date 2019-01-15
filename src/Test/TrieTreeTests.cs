using DataStructures.Trie;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test
{
    public class TrieTreeTests
    {
        [Fact]
        public void Find_Test_ElementFound()
        {
            var trie = new Trie();

            trie.Insert("TEST");

            Assert.True(trie.Find("TEST"));
        }

        [Fact]
        public void Insert_Empty_InsertsElement()
        {
            var trie = new Trie();

            trie.Insert("TeSt");

            Assert.False(trie.Find("TEST"));
            Assert.True(trie.Find("TeSt"));
        }
    }
}