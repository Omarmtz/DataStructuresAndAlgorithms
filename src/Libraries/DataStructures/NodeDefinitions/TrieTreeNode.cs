using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.NodeDefinitions
{
    public class TrieTreeNode
    {
        public char Value { get; set; }
        public bool IsEndOfWord { get; set; }
        public List<TrieTreeNode> Nodes { get; set; }

        public TrieTreeNode(char value)
        {
            Value = value;
            Nodes = new List<TrieTreeNode>();
        }

        public bool ContainsCharacter(char character)
        {
            return Nodes.Any(e => e.Value == character);
        }

        public void AddCharacter(char character)
        {
            Nodes.Add(new TrieTreeNode(character));
        }

        public TrieTreeNode GetCharacterNode(char character)
        {
            return Nodes.FirstOrDefault(e => e.Value == character);
        }
    }
}