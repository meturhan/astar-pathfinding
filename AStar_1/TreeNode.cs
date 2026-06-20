using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AStar_1
{
    public class TreeNode
    {
        public int X;
        public int Y;
        public TreeNode geldigiYer;
        public int f;
        public int h;
        public int g;

        public TreeNode ust, alt, sag, sol;

        public TreeNode(int _X, int _Y, TreeNode _geldigiYer, int _h, int _g, TreeNode _ust, TreeNode _alt, TreeNode _sag, TreeNode _sol)
        {
            X = _X;
            Y = _Y;
            geldigiYer = _geldigiYer;
            f = _h + _g;
            h = _h;
            g = _g;
            ust = _ust;
            alt = _alt;
            sag = _sag;
            sol = _sol; 
        }
                                                                                                                        
    }
}
