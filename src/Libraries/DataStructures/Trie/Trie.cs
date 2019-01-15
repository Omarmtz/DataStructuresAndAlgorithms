using DataStructures.NodeDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Trie
{
    public class Trie
    {
        private TrieTreeNode root;

        public Trie()
        {
            root = new TrieTreeNode(' ');
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Insert(string word)
        {
            if (String.IsNullOrEmpty(word))
                return;

            TrieTreeNode tmpNode = root;

            for (int i = 0; i < word.Length; i++)
            {
                if (!tmpNode.ContainsCharacter(word[i]))
                {
                    tmpNode.AddCharacter(word[i]);
                }

                tmpNode = tmpNode.GetCharacterNode(word[i]);
                tmpNode.IsEndOfWord = (i == word.Length - 1);
            }
        }

        public bool Find(string word)
        {
            if (String.IsNullOrEmpty(word))
                return false;

            TrieTreeNode tmpNode = root;

            for (int i = 0; i < word.Length; i++)
            {
                tmpNode = tmpNode.GetCharacterNode(word[i]);
                if (tmpNode == null)
                {
                    return false;
                }
            }

            return tmpNode != null && tmpNode.IsEndOfWord;
        }
    }
}