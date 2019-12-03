using System;
using System.Collections.Generic;

namespace ExercArvore
{
    // Classe com o nó
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

    // Classe com a árvore
    public class BTree
    {
        // Nó raiz
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

        // Inserindo na árvore
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
        }


        // Pesquisa na árvore
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

        // Função para excluir nó
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

    }
}
