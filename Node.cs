using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{

    abstract class TreeNode
    {
        public readonly int freq;

        public TreeNode(int freq)
        {
            this.freq = freq;
        }
    }

    class Node : TreeNode
    {
        public readonly byte symbol;
        public readonly Node bit0;
        public readonly Node bit1;

        public Node(byte symbol, int freq) : base(freq)
        {
            this.symbol = symbol;
        }

        public Node(Node bit0, Node bit1, int freq) : base(freq)
        {
            this.bit0 = bit0;
            this.bit1 = bit1;
        }
    }
}
