using System;

class Node
{
    public string Value;
    public Node Left, Right;

    public Node(string value)
    {
        Value = value;
        Left = Right = null;
    }
}

class BinaryTree
{
    public Node Root;

    public void Insert(string value)
    {
        Root = InsertRec(Root, value);
    }

    private Node InsertRec(Node root, string value)
    {
        if (root == null)
            return new Node(value);

        if (string.Compare(value, root.Value) < 0)
            root.Left = InsertRec(root.Left, value);
        else
            root.Right = InsertRec(root.Right, value);

        return root;
    }

    public void InOrder(Node node)
    {
        if (node != null)
        {
            InOrder(node.Left);
            Console.Write(node.Value + " ");
            InOrder(node.Right);
        }
    }

    public void PreOrder(Node node)
    {
        if (node != null)
        {
            Console.Write(node.Value + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }
    }

    public void PostOrder(Node node)
    {
        if (node != null)
        {
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.Write(node.Value + " ");
        }
    }

    public Node Search(Node root, string value)
    {
        if (root == null || root.Value == value)
            return root;

        if (string.Compare(value, root.Value) < 0)
            return Search(root.Left, value);
        else
            return Search(root.Right, value);
    }

    public Node Delete(Node root, string value)
    {
        if (root == null) return root;

        if (string.Compare(value, root.Value) < 0)
            root.Left = Delete(root.Left, value);
        else if (string.Compare(value, root.Value) > 0)
            root.Right = Delete(root.Right, value);
        else
        {
            if (root.Left == null) return root.Right;
            if (root.Right == null) return root.Left;

            root.Value = MinValue(root.Right);
            root.Right = Delete(root.Right, root.Value);
        }

        return root;
    }

    private string MinValue(Node root)
    {
        string minv = root.Value;
        while (root.Left != null)
        {
            minv = root.Left.Value;
            root = root.Left;
        }
        return minv;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        int option;

        do
        {
            Console.WriteLine("\n--- MENÚ ÁRBOL BINARIO ---");
            Console.WriteLine("1. Insertar nodo");
            Console.WriteLine("2. Recorrido In-Orden");
            Console.WriteLine("3. Recorrido Pre-Orden");
            Console.WriteLine("4. Recorrido Post-Orden");
            Console.WriteLine("5. Buscar valor");
            Console.WriteLine("6. Eliminar nodo");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Ingrese valor a insertar: ");
                    string val = Console.ReadLine();
                    tree.Insert(val);
                    Console.WriteLine("Nodo insertado.");
                    break;
                case 2:
                    Console.WriteLine("Recorrido In-Orden:");
                    tree.InOrder(tree.Root);
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Recorrido Pre-Orden:");
                    tree.PreOrder(tree.Root);
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("Recorrido Post-Orden:");
                    tree.PostOrder(tree.Root);
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Write("Ingrese valor a buscar: ");
                    string buscar = Console.ReadLine();
                    var encontrado = tree.Search(tree.Root, buscar);
                    Console.WriteLine(encontrado != null ? $"Valor '{buscar}' encontrado." : "Valor no encontrado.");
                    break;
                case 6:
                    Console.Write("Ingrese valor a eliminar: ");
                    string eliminar = Console.ReadLine();
                    tree.Root = tree.Delete(tree.Root, eliminar);
                    Console.WriteLine("Nodo eliminado si existía.");
                    break;
                case 0:
                    Console.WriteLine("Programa finalizado.");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (option != 0);
    }
}
