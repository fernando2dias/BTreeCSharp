using System;
using System.Collections;
using System.Collections.Generic;

namespace ExercArvore
{
    public class Node
    {
        private int info, level;
        private Node left, right, father;

        public Node(int x, Node p)
        {
            info = x;
            father = p;
            left = null;
            right = null;

        }

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

    public class BTree
    {
        private Node root;
        public Node Root
        {
            get { return root; }
            set { root = value; }
        }

        public BTree()
        {
            root = null;
        }

        public void Insert(int x)
        {
            Node novo = new Node(x, null);
            if (root == null)
            {
                root = novo;
            }
            else
            {
                root = Insert(root, novo);
            }
        }

        private Node Insert(Node current, Node novo)
        {
            if (current == null)
            {
                current = novo;
                return current;
            }
            else if (novo.Info < current.Info)
            {
                current.Left = Insert(current.Left, novo);
                current = Balance_tree(current);
            }
            else if (novo.Info >= current.Info)
            {
                current.Right = Insert(current.Right, novo);
                current = Balance_tree(current);
            }
            return current;
        }

        private Node Balance_tree(Node n)
        {
            int fb = FBalance(n);
            if (fb > 1)
            {
                if (FBalance(n.Left) > 0)
                {
                    n = RotateLeft(n);
                }
                else
                {
                    n = RotateLeftRight(n);
                }
            }
            else if (fb < -1)
            {
                if (FBalance(n.Right) > 0)
                {
                    n = RotateRightLeft(n);
                }
                else
                {
                    n = RotateRight(n);
                }
            }
            return n;
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

        private int FBalance(Node current)
        {
            int l = getHeight(current.Left);
            int r = getHeight(current.Right);
            int b_factor = l - r;
            return b_factor;
        }

        private Node RotateRight(Node father)
        {
            Node aux = father.Right;
            father.Right = aux.Left;
            aux.Left = father;
            return aux;
        }

        //Rotação para Esquerda
        private Node RotateLeft(Node father)
        {
            Node aux = father.Left;
            father.Left = aux.Right;
            aux.Right = father;
            return aux;
        }

        //Rotação Esquerda Direita
        private Node RotateLeftRight(Node father)
        {
            Node aux = father.Left;
            father.Left = RotateRight(aux);
            return RotateLeft(father);
        }

        //Rotação Direita Esquerda
        private Node RotateRightLeft(Node father)
        {
            Node aux = father.Right;
            father.Right = RotateLeft(aux);
            return RotateRight(father);
        }

        // Pesquisa na árvore
        public Node Find(int x)
        {
            return Find(Root, x);
        }
        private Node Find(Node current, int x)
        {
            if (current == null || current.Info == x)
            {
                return current;
            }
            if (x < current.Info)
            {
                return Find(current.Left, x);
            }
            else
            {
                return Find(current.Right, x);
            }
        }

        // Função para excluir nó
        public void Remove(int x)
        {
            Root = Remove(Root, x);
        }
        private Node Remove(Node current, int x)
        {
            Node father;
            if (current == null)
            {
                return null;
            }
            else
            {
                //SubArvore Esquerda
                if (x < current.Info)
                {
                    current.Left = Remove(current.Left, x);
                    if (FBalance(current) == -2)
                    {
                        if (FBalance(current.Right) <= 0)
                        {
                            current = RotateRight(current);
                        }
                        else
                        {
                            current = RotateRightLeft(current);
                        }
                    }
                }
                //SubArvore Direita
                else if (x > current.Info)
                {
                    current.Right = Remove(current.Right, x);
                    if (FBalance(current) == 2)
                    {
                        if (FBalance(current.Left) >= 0)
                        {
                            current = RotateLeft(current);
                        }
                        else
                        {
                            current = RotateLeftRight(current);
                        }
                    }
                }
                //Se o valor for encontrado
                else
                {
                    if (current.Right != null)
                    {
                        //Exclui o proximo
                        father = current.Right;
                        while (father.Left != null)
                        {
                            father = father.Left;
                        }
                        current.Info = father.Info;
                        current.Right = Remove(current.Right, father.Info);
                        if (FBalance(current) == 2)
                        {
                            if (FBalance(current.Left) >= 0)
                            {
                                current = RotateLeft(current);
                            }
                            else
                            {
                                current = RotateLeftRight(current);
                            }
                        }
                    }
                    else
                    {
                        // Se atual.Esq != null
                        return current.Left;
                    }
                }
            }
            return current;
        }

        //imprimir em ordem (Esq, Raiz, Dir)
        public List<Node> InOrder()
        {
            List<Node> x = new List<Node>();
            return InOrder(Root, x);
        }
        private List<Node> InOrder(Node current, List<Node> x)
        {
            if (current != null)
            {
                InOrder(current.Left, x);
                x.Add(current);
                InOrder(current.Right, x);
            }
            return x;
        }

        //imprimir pré-Ordem (Raiz, Esq, Dir)
        public List<Node> PreOrder()
        {
            List<Node> x = new List<Node>();
            return PreOrder(Root, x);
        }

        private List<Node> PreOrder(Node current, List<Node> x)
        {
            if (current != null)
            {
                x.Add(current);
                PreOrder(current.Left, x);
                PreOrder(current.Right, x);
            }

            return x;
        }

        //imprimir PosOrder(Esq, Dir, Raiz)
        public List<Node> PosOrder()
        {
            List<Node> x = new List<Node>();
            return PosOrder(Root, x);
        }

        private List<Node> PosOrder(Node current, List<Node> x)
        {
            if (current != null)
            {
                PosOrder(current.Left, x);
                PosOrder(current.Right, x);
                x.Add(current);
            }
            return x;
        }

        // Imprimir em level
        public List<Node> InLevel()
        {
            List<Node> x = new List<Node>();
            return InLevel(Root, x);
        }
        private List<Node> InLevel(Node current, List<Node> x)
        {
            if (current != null)
            {
                Queue q = new Queue();
                q.Enqueue(current);
                while (q.Count > 0)
                {
                    Node aux = (Node)q.Dequeue();
                    x.Add(aux);
                    if (aux.Left != null)
                    {
                        q.Enqueue(aux.Left);
                    }
                    if (aux.Right != null)
                    {
                        q.Enqueue(aux.Right);
                    }
                }
            }
            return x;
        }
    }
}


