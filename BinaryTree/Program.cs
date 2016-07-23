using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinTree
{

    public class StrComparer : IComparer<string>
    {
        int Compare(string a, string b)
        {

            if (a.Length > b.Length)
                return 1;

            if (a.Length < b.Length)
                return -1;

            else
                return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            StrComparer comparer = new StrComparer();
            BinaryTree<string> tree = new BinaryTree<string>("abc", comparer);

        }
    }
}
