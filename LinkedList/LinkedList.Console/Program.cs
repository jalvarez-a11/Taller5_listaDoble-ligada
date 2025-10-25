using DoubleLinkedList;
using System.ComponentModel.Design;

var list = new DoubleLinkedList<string>();
int option;

do
{
    Console.WriteLine("\n===== MENÚ LISTA DOBLEMENTE LIGADA =====");
    Console.WriteLine("1. Adicionar");
    Console.WriteLine("2. Mostrar hacia adelante");
    Console.WriteLine("3. Mostrar hacia atrás");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar moda(s)");
    Console.WriteLine("6. Mostrar gráfico");
    Console.WriteLine("7. Existe");
    Console.WriteLine("8. Eliminar una ocurrencia");
    Console.WriteLine("9. Eliminar todas las ocurrencias");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");

    option = int.Parse(Console.ReadLine() ?? "0");

    switch (option)
    {
        case 1:
            Console.Write("Ingrese un elemento: ");
            list.Add(Console.ReadLine()!);
            break;
        case 2:
            list.PrintForward();
            break;
        case 3:
            list.PrintBackward();
            break;
        case 4:
            list.SortDescending();
            Console.WriteLine("Lista ordenada descendentemente.");
            break;
        case 5:
            list.ShowModes();
            break;
        case 6:
            list.ShowGraph();
            break;
        case 7:
            Console.Write("Elemento a buscar: ");
            Console.WriteLine(list.Exists(Console.ReadLine()!) ? "Existe" : "No existe");
            break;
        case 8:
            Console.Write("Elemento a eliminar: ");
            list.RemoveOne(Console.ReadLine()!);
            break;
        case 9:
            Console.Write("Elemento a eliminar todas las ocurrencias: ");
            list.RemoveAll(Console.ReadLine()!);
            break;
        case 0:
            Console.WriteLine("Saliendo...");
            break;
        default:
            Console.WriteLine("Opción inválida.");
            break;
    }

} while (option != 0);
