// See https://aka.ms/new-console-template for more information
using proyecto_Practica01_.Domain;
using proyecto_Practica01_.Services;

ArticuloManager articuloManager = new ArticuloManager();

var oArticulo = new Articulo("articulo nuevo 1", 3000);
if (articuloManager.SaveArticulo(oArticulo))
{
    Console.WriteLine("Articulo Creado");
}

List<Articulo> lst= articuloManager.GetArticulos();
if (lst.Count == 0)
{
    Console.WriteLine("No hay articulos");

}
else
{
    foreach (var oArt in lst)
    {
        Console.WriteLine(oArt);
    }
}

if (articuloManager.DeleteArticulo(1))
    Console.WriteLine("Articulo Eliminado");

FacturaManager facturamanager = new FacturaManager();
var facturas = facturamanager.GetFacturas();
var factura1 = facturamanager.GetFacturaById(1);

