using System;
using System.Collections.Generic;

namespace ExercArvore
{
    // Classe com o n�
    public class Node
    {
        private int info, level;
        private Node left, right, father;

        // Construtor
        public Node(int x, Node p)
        {
            info = x;
            father = p;
            left = null;
            right = null;

            if (father != null)
            {
                level = father.level + 1;
            }
            else
            {
                level = 0;
            }
        }

        // Properties
        public int Info
        {
            get { return info; }
            set { info = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public Node Left
        {
            get { return left; }
            set { left = value; }
        }
        public Node Right
        {
            get { return right; }
            set { right = value; }
        }
        public Node Father
        {
            get { return father; }
            set { father = value; }
        }
    }

    // Classe com a �rvore
    public class BTree
    {
        // N� raiz
        private Node root;
        public Node Root
        {
            get { return root; }
            set { root = value; }
        }

        // Construtor
        public BTree()
        {
            root = null;
        }

        // Inserindo na �rvore
        public void Insert(int x)
        {
            if (root == null)
            {
                root = new Node(x, null);
            }
            else
            {
                Insert(root, x);
            }
        }

        private void Insert(Node n, int x)
        {
            if (x < n.Info)
            {
                if (n.Left == null)
                {
                    n.Left = new Node(x, n);
                }
                else
                {
                    Insert(n.Left, x);
                }
            }
            else
            {
                if (n.Right == null)
                {
                    n.Right = new Node(x, n);
                }
                else
                {
                    Insert(n.Right, x);
                }

            }
            //isso aqui eu inseri depois
            n = balance_tree(n);
        }


        // Pesquisa na �rvore
        public Node Find(int x)
        {
            return Find(root, x);
        }

        private Node Find(Node n, int x)
        {
            if ((n == null) || (n.Info == x))
            {
                return n;
            }

            if (x < n.Info)
            {
                return Find(n.Left, x);
            }
            else
            {
                return Find(n.Right, x);
            }
        }

        // Fun��o para excluir n�
        public void Remove(int x)
        {
            Remove(root, x);
        }

        public void Remove(Node n, int x)
        {
            Node f = Find(n, x);

            if (f == null)
            {
                return;
            }

            if (f.Left == null)
            {
                if (f.Father == null)
                {
                    root = f.Right;
                }
                else
                {
                    if (f.Father.Right == f)
                    {
                        f.Father.Right = f.Right;
                    }
                    else
                    {
                        f.Father.Left = f.Right;
                    }

                    if (f.Right != null)
                    {
                        f.Right.Father = f.Father;
                    }
                }
            }
            else
            {
                if (f.Right == null)
                {
                    if (f.Father == null)
                    {
                        root = f.Left;
                    }
                    else
                    {
                        if (f.Father.Right == f)
                        {
                            f.Father.Right = f.Left;
                        }
                        else
                        {
                            f.Father.Left = f.Left;
                        }

                        if (f.Left != null)
                        {
                            f.Left.Father = f.Father;
                        }
                    }
                }
                else
                {
                    Node p = KillMin(f.Right);
                    f.Info = p.Info;
                }
            }
            if (root != null)
            {
                root.Father = null;
            }

        }

        private Node KillMin(Node n)
        {
            if (n.Left == null)
            {
                Node t = n;

                if (n.Father.Right == n)
                {
                    n.Father.Right = n.Right;
                }
                else
                {
                    n.Father.Left = n.Right;
                }

                if (n.Right != null)
                {
                    n.Right.Father = n.Father;
                }

                return t;

            }
            else
            {
                return KillMin(n.Left);
            }

        }



        public List<Node> InOrder()
        {
            return null;
        }

        public List<Node> PreOrder()
        {
            return null;
        }

        public List<Node> PosOrder()
        {
            return null;
        }

        public List<Node> InLevel()
        {
            return null;
        }

        private Node balance_tree(Node n)
        {
            int b_factor = balance_factor(n);
            if (b_factor > 1)
            {
                if (balance_factor(n.Left) > 0)
                {
                    n = RotateLL(n);
                }
                else
                {
                    n = RotateLR(n);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(n.Right) > 0)
                {
                    n = RotateRL(n);
                }
                else
                {
                    n = RotateRR(n);
                }
            }
            return n;
        }

        private Node RotateRR(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }

        private int balance_factor(Node current)
        {
            int l = getHeight(current.Left);
            int r = getHeight(current.Right);
            int b_factor = l - r;
            return b_factor;
        }

        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.Left);
                int r = getHeight(current.Right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }


    }
}
