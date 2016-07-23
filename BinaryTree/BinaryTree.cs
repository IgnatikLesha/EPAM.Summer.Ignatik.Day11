using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinTree
{


    class BinaryTree<T>: IEnumerable<T>, IEnumerable where T:IComparable<T>
    {
        private class TreeNode
        {
            public TreeNode LeftChild { get; set; }
            public TreeNode RightChild { get; set; }
            public TreeNode Parent { get; set; }
            public T Data { get; set; }
        }

        private TreeNode tnode;
        private IComparer<T> comparer;


        public BinaryTree(T data)
        {
            this.Insert(data);
        }

        public BinaryTree(T data, IComparer<T> comparer)
        {
            this.comparer = comparer;
            this.Insert(data);
        }



        public BinaryTree(IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException("comparer");

            this.comparer = comparer;
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in InOrder())
                yield return element;
        }





        public IEnumerable<T> PreOrder()
        {
            yield return tnode.Data;
            if (tnode.LeftChild != null)
                foreach (var element in PreOrder())
                    yield return element;
            if (tnode.RightChild != null)
                foreach (var element in PreOrder())
                    yield return element;
        }

        public IEnumerable<T> PostOrder()
        {
            if (tnode.LeftChild != null)
                foreach (var element in PostOrder())
                    yield return element;
            if (tnode.RightChild != null)
                foreach (var element in PostOrder())
                    yield return element;
            yield return tnode.Data;
        }

        public IEnumerable<T> InOrder()
        {
            if (tnode.LeftChild != null)
                foreach (var element in InOrder())
                    yield return element;
            yield return tnode.Data;
            if (tnode.RightChild != null)
                foreach (var element in InOrder())
                    yield return element;
        }




        public void Insert(T data)
        {
            if (tnode.Data == null || tnode.Data.Equals(data))
            {
                tnode.Data = data;
                return;
            }
            if (comparer.Compare(tnode.Data, data) == -1)
            {
                if (tnode.LeftChild == null)
                    tnode.LeftChild = new TreeNode();
                Insert(data, tnode.LeftChild, tnode);
            }
            else
            {
                if (tnode.RightChild == null) 
                    tnode.RightChild = new TreeNode();
                Insert(data, tnode.RightChild, tnode);
            }
        }


        private void Insert(T data, TreeNode node, TreeNode parent)
        {
 
            if (node.Data == null || node.Data.Equals(data))
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }
            if (comparer.Compare(tnode.Data, data) == -1)
            {
                if (node.LeftChild == null) node.LeftChild = new TreeNode();
                Insert(data, node.LeftChild, node);
            }
            else
            {
                if (node.RightChild == null) node.RightChild = new TreeNode();
                Insert(data, node.RightChild, node);
            }
        }


        private TreeNode Find(T data, TreeNode node)
        {
            if (node == null)
                throw new ArgumentException();

            if (node.Data.Equals(data)) return node;
            if (comparer.Compare(tnode.Data, data) == -1)
            {
                return Find(data, node.LeftChild);
            }
            return Find(data, node.RightChild);
        }


        public enum Side
        {
            Left,
            Right
        }


        private Side? MeForParent(TreeNode node)
        {
            if (node.Parent == null) return null;
            if (node.Parent.LeftChild == node) return Side.Left;
            if (node.Parent.RightChild == node) return Side.Right;
            return null;
        }


    }
}
