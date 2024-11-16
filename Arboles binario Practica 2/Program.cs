using System;
using System.Collections.Generic;

public class Nodo
{
    public string Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(string valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

public class ArbolBinario
{
    public Nodo Raiz;

    public ArbolBinario()
    {
        Raiz = null;
    }

    // Método para agregar un nodo al árbol
    // Método para agregar un nodo al árbol
public void AgregarNodo()
{
    Console.Write("Ingrese el valor del nodo raíz: ");
    Raiz = new Nodo(Console.ReadLine());

    Queue<Nodo> cola = new Queue<Nodo>();
    cola.Enqueue(Raiz);

    while (cola.Count > 0)
    {
        Nodo actual = cola.Dequeue();

        Console.Write($"¿Desea agregar un hijo izquierdo a {actual.Valor}? (s/n): ");
        string respuestaIzquierda = Console.ReadLine().ToLower();

        if (respuestaIzquierda == "s")
        {
            Console.Write($"Ingrese el valor del hijo izquierdo de {actual.Valor}: ");
            actual.Izquierdo = new Nodo(Console.ReadLine());
            cola.Enqueue(actual.Izquierdo);
        }
        else if (respuestaIzquierda != "n")
        {
            Console.WriteLine("Respuesta inválida. Continuando...");
        }

        Console.Write($"¿Desea agregar un hijo derecho a {actual.Valor}? (s/n): ");
        string respuestaDerecha = Console.ReadLine().ToLower();

        if (respuestaDerecha == "s")
        {
            Console.Write($"Ingrese el valor del hijo derecho de {actual.Valor}: ");
            actual.Derecho = new Nodo(Console.ReadLine());
            cola.Enqueue(actual.Derecho);
        }
        else if (respuestaDerecha != "n")
        {
            Console.WriteLine("Respuesta inválida. Continuando...");
        }
    }
}


    // Recorrido en amplitud (BFS)
    public void RecorridoAmplitud()
    {
        if (Raiz == null) return;

        Queue<Nodo> cola = new Queue<Nodo>();
        cola.Enqueue(Raiz);

        while (cola.Count > 0)
        {
            Nodo actual = cola.Dequeue();
            Console.Write(actual.Valor + " ");

            if (actual.Izquierdo != null)
                cola.Enqueue(actual.Izquierdo);

            if (actual.Derecho != null)
                cola.Enqueue(actual.Derecho);
        }
        Console.WriteLine();
    }

    // Recorrido en profundidad - Preorden
    public void RecorridoPreorden(Nodo nodo)
    {
        if (nodo == null) return;

        Console.Write(nodo.Valor + " ");
        RecorridoPreorden(nodo.Izquierdo);
        RecorridoPreorden(nodo.Derecho);
    }

    // Recorrido en profundidad - Inorden
    public void RecorridoInorden(Nodo nodo)
    {
        if (nodo == null) return;

        RecorridoInorden(nodo.Izquierdo);
        Console.Write(nodo.Valor + " ");
        RecorridoInorden(nodo.Derecho);
    }

    // Recorrido en profundidad - Postorden
    public void RecorridoPostorden(Nodo nodo)
    {
        if (nodo == null) return;

        RecorridoPostorden(nodo.Izquierdo);
        RecorridoPostorden(nodo.Derecho);
        Console.Write(nodo.Valor + " ");
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();

        // Construir el árbol ingresando los datos
        arbol.AgregarNodo();

        // Realizar los recorridos y mostrar los resultados
        Console.WriteLine("\nRecorrido en amplitud (BFS):");
        arbol.RecorridoAmplitud();

        Console.WriteLine("\nRecorrido en profundidad - Preorden (DFS):");
        arbol.RecorridoPreorden(arbol.Raiz);
        Console.WriteLine();

        Console.WriteLine("\nRecorrido en profundidad - Inorden (DFS):");
        arbol.RecorridoInorden(arbol.Raiz);
        Console.WriteLine();

        Console.WriteLine("\nRecorrido en profundidad - Postorden (DFS):");
        arbol.RecorridoPostorden(arbol.Raiz);
        Console.WriteLine();
    }
}
