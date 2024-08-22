// See https://aka.ms/new-console-template for more information
using InterfacePractica;
using InterfacePractica.Clases;
using InterfacePractica.Interfaces;

using InterfacePractica.Productos;

Console.WriteLine("Hello, World!");

// - Ejercicio Productos

//Producto[] arregloProductos = {new Pack(6,45,"Coca Cola", 1000), new Suelto(2,25,"Medialuna", 80) };

//float total=0;
//for (int i = 0; i < arregloProductos.Length; i++)
//{
//    total += arregloProductos[i].CalcularPrecio();
//};
//    Console.WriteLine("Total:" + total);

// - Ejercicio cola y pila

var cola = new Cola(3);
var pila = new Pila(5);


Console.WriteLine(cola.añadir(1));
Console.WriteLine(cola.añadir(2));
Console.WriteLine(cola.añadir(3));
Console.WriteLine("vacia: " + cola.estaVacia());
Console.WriteLine(cola.primero());
Console.WriteLine(cola.extraer());
Console.WriteLine(cola.primero());

Console.WriteLine(pila.añadir(1));
Console.WriteLine(pila.añadir(2));
Console.WriteLine(pila.añadir(3));
Console.WriteLine("vacia: " + cola.estaVacia());
Console.WriteLine(pila.primero());
Console.WriteLine(pila.extraer());
Console.WriteLine(pila.primero());

