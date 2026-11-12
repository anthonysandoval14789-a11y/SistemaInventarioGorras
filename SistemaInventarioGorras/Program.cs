

using System.ComponentModel.Design;

Console.WriteLine("================================");
Console.WriteLine("   CONTROL DE INVENTARIO");
Console.WriteLine("       TIENDA DE GORRAS");
Console.WriteLine("================================");

int opcion = 0;

// These lists keep all the cap information organized,
// making it easier to manage the inventory.

List<int> codigos = new List<int>();
List<string> nombres = new List<string>();
List<string> marcas = new List<string>();
List<string> colores = new List<string>();
List<decimal> precios = new List<decimal>();
List<int> cantidades = new List<int>();


List<string> listamarcas = new List<string>();

listamarcas.Add("Nike");
listamarcas.Add("Adidas");
listamarcas.Add("New era");

// Here we define the brands available in the store,
// giving users different options when adding a cap.

List<string> listacolores = new List<string>();

listacolores.Add("Negro");
listacolores.Add("Blanco");
listacolores.Add("Azul");


Console.WriteLine("\n--- MARCAS DISPONIBLES --");
int numeroMarca = 1;
foreach (string marca in listamarcas)
{

    Console.WriteLine(numeroMarca + "." + marca);
    numeroMarca++;


}


Console.WriteLine("\n--- COLORES DISPONIBLES ---");
int numeroColor = 1;

// This section displays the available brands,
// so users can check their options before selecting one.

foreach (string color in listacolores)
{

    Console.WriteLine(numeroColor + "." + color);
    numeroColor++;
}

 ///The main menu keeps the system running and allows users to choose,
 ///between the different inventory operations.
do
{
    Console.WriteLine("\n================================");
    Console.WriteLine("       MENU PRINCIPAL");
    Console.WriteLine("================================");
    Console.WriteLine("1. AGREGAR GORRA");
    Console.WriteLine("2. BUSCAR GORRA");
    Console.WriteLine("3. MODIFICAR GORRA");
    Console.WriteLine("4. ELIMINAR GORRA");
    Console.WriteLine("5. LISTAR GORRAS");
    Console.WriteLine("6. MOSTRAR MARCAS");
    Console.WriteLine("7. MOSTRAR COLORES");
    Console.WriteLine("8. BUSCAR GORRAS POR MARCA");
    Console.WriteLine("9. REGISTRAR NUEVA MARCA");
    Console.WriteLine("10. REGISTRAR NUEVO COLOR");
    Console.WriteLine("11. SALIR");


    
    Console.Write("\nSeleccione una opcion: ");

    int.TryParse(Console.ReadLine(), out opcion);

    switch (opcion)
    {

        case 1:

            {  
                try
                {
                    Console.WriteLine("\n--- REGISTRAR NUEVA GORRA ---");

                    int codigo;

                    Console.Write("Ingrese el codigo de la gorra: ");

                    if (!int.TryParse(Console.ReadLine(), out codigo) || codigo <= 0)
                    {
                        Console.WriteLine("Codigo no valido. Debe ingresar un numero mayor que cero.");
                        break;
                    }

                    if (codigos.Contains(codigo))
                    {
                        Console.WriteLine("Este codigo ya existe.");
                        break;
                    }

                    Console.Write("Ingrese el nombre de la gorra: ");
                    string nombre = Console.ReadLine() ?? "";

                    if (nombre == "")
                    {
                        Console.WriteLine("El nombre de la gorra no puede estar vacio.");
                        break;
                    }

                    Console.WriteLine("\nSeleccione una marca:");

                    for (int i = 0; i < listamarcas.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + listamarcas[i]);
                    }

                    int seleccionMarca;
                    Console.Write("Seleccione: ");
                    int.TryParse(Console.ReadLine(), out seleccionMarca);

                    if (seleccionMarca < 1 || seleccionMarca > listamarcas.Count)
                    {
                        Console.WriteLine("Marca no valida.");
                        break;
                    }

                    Console.WriteLine("\nSeleccione un color:");

                    for (int i = 0; i < listacolores.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + listacolores[i]);
                    }

                    int seleccionColor;
                    Console.Write("Seleccione: ");
                    int.TryParse(Console.ReadLine(), out seleccionColor);

                    if (seleccionColor < 1 || seleccionColor > listacolores.Count)
                    {
                        Console.WriteLine("Color no valido.");
                        break;
                    }

                    decimal precio;

                    Console.Write("Ingrese el precio: ");

                    if (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                    {
                        Console.WriteLine("Precio no valido. Debe ingresar un numero mayor que cero.");
                        break;
                    }

                    int cantidad;

                    Console.Write("Ingrese la cantidad disponible: ");

                    if (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 0)
                    {
                        Console.WriteLine("Cantidad no valida. No puede ser negativa.");
                        break;
                    }

                    codigos.Add(codigo);
                    nombres.Add(nombre);
                    marcas.Add(listamarcas[seleccionMarca - 1]);
                    colores.Add(listacolores[seleccionColor - 1]);
                    precios.Add(precio);
                    cantidades.Add(cantidad);

                    Console.WriteLine("\n¡Gorra registrada correctamente!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error al registrar la gorra: " + ex.Message);
                }

                break;
            }

        case 2:
            {
                try
                {
                    Console.WriteLine("\n--- BUSCAR GORRA ---");

                    int codigoBuscar;

                    Console.Write("Ingrese el codigo de la gorra: ");
                    int.TryParse(Console.ReadLine(), out codigoBuscar);

                    int posicion = codigos.IndexOf(codigoBuscar);

                    if (posicion != -1)
                    {
                        Console.WriteLine("\nGORRA ENCONTRADA");

                        Console.WriteLine("Codigo: " + codigos[posicion]);
                        Console.WriteLine("Nombre: " + nombres[posicion]);
                        Console.WriteLine("Marca: " + marcas[posicion]);
                        Console.WriteLine("Color: " + colores[posicion]);
                        Console.WriteLine("Precio: " + precios[posicion]);
                        Console.WriteLine("Cantidad: " + cantidades[posicion]);
                    }
                    else
                    {
                        Console.WriteLine("No se encontro una gorra con ese codigo.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error al buscar la gorra: " + ex.Message);
                }

                break;
            }

        case 3:
            {
                try
                {
                    Console.WriteLine("\n--- MODIFICAR GORRA ---");

                    int codigoModificar;

                    Console.WriteLine("Ingrese el codigo de la gorra: ");
                    int.TryParse(Console.ReadLine(), out codigoModificar);

                    int posicionModificar = codigos.IndexOf(codigoModificar);

                    if (posicionModificar != -1)
                    {
                        Console.WriteLine("\nGORRA ENCONTRADA");

                        Console.WriteLine("\nIngrese el nuevo nombre de la gorra: ");
                        string nombreNuevo = Console.ReadLine() ?? "";

                        if (nombreNuevo != "")
                        {
                            nombres[posicionModificar] = nombreNuevo;
                            Console.WriteLine("El nombre fue modificado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("El nombre no puede estar vacio.");
                        }

                        Console.WriteLine("\n--- MARCAS DISPONIBLES ---");

                        for (int i = 0; i < listamarcas.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + listamarcas[i]);
                        }

                        int seleccionMarcaNueva;

                        Console.Write("Seleccione la nueva marca: ");
                        int.TryParse(Console.ReadLine(), out seleccionMarcaNueva);

                        if (seleccionMarcaNueva >= 1 && seleccionMarcaNueva <= listamarcas.Count)
                        {
                            marcas[posicionModificar] = listamarcas[seleccionMarcaNueva - 1];

                            Console.WriteLine("La marca fue modificada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("La marca seleccionada no es valida.");
                        }

                        Console.WriteLine("\n--- COLORES DISPONIBLES ---");

                        for (int i = 0; i < listacolores.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + listacolores[i]);
                        }

                        int seleccionColorNueva;

                        Console.Write("\nSeleccione el nuevo color: ");
                        int.TryParse(Console.ReadLine(), out seleccionColorNueva);

                        if (seleccionColorNueva >= 1 && seleccionColorNueva <= listacolores.Count)
                        {
                            colores[posicionModificar] = listacolores[seleccionColorNueva - 1];

                            Console.WriteLine("El color fue modificado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("El color seleccionado no es valido.");
                        }

                        decimal precioNuevo;

                        Console.Write("\nIngrese el nuevo precio: ");

                        if (decimal.TryParse(Console.ReadLine(), out precioNuevo) && precioNuevo > 0)
                        {
                            precios[posicionModificar] = precioNuevo;
                            Console.WriteLine("El precio fue modificado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Precio no valido. Debe ingresar un numero mayor que cero.");
                        }

                        int cantidadNueva;

                        Console.Write("\nIngrese la nueva cantidad: ");

                        if (int.TryParse(Console.ReadLine(), out cantidadNueva) && cantidadNueva >= 0)
                        {
                            cantidades[posicionModificar] = cantidadNueva;
                            Console.WriteLine("La cantidad fue modificada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Cantidad no valida. No puede ser negativa.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No se encontro una gorra con ese codigo.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error al modificar la gorra: " + ex.Message);
                }

                break;
            }

        case 4:
            {
                Console.WriteLine("\n--- ELIMINAR GORRA --");

                int codigoEliminar;

                Console.WriteLine("Ingrese el codigo de la gorra");

                int.TryParse(Console.ReadLine(), out codigoEliminar);

                int posicionEliminar = codigos.IndexOf(codigoEliminar);

                if (posicionEliminar != -1)
                {

                    Console.WriteLine("\nGORRA ENCONTRADA");
                    codigos.RemoveAt(posicionEliminar);
                    nombres.RemoveAt(posicionEliminar);
                    marcas.RemoveAt(posicionEliminar);
                    colores.RemoveAt(posicionEliminar);
                    precios.RemoveAt(posicionEliminar);
                    cantidades.RemoveAt(posicionEliminar);

                    Console.WriteLine("La gorra fue eliminada correctamente");
                }
                else
                {
                    Console.WriteLine("No se encontro una gorra con ese codigo.");

                }

                break;
            }

        case 5:
            {
                Console.WriteLine("Listar gorras");

                Console.WriteLine("\n--- LISTAR GORRAS ---");

                if (codigos.Count == 0)
                {
                    Console.WriteLine("No hay gorras registradas en el inventario.");
                }
                else
                    for (int i = 0; i < codigos.Count; i++)
                    {

                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("Codigo: " + codigos[i]);
                        Console.WriteLine("Nombre: " + nombres[i]);
                        Console.WriteLine("Marca: " + marcas[i]);
                        Console.WriteLine("Color: " + colores[i]);
                        Console.WriteLine("Precio: " + precios[i]);
                        Console.WriteLine("Cantidad: " + cantidades[i]);
                        Console.WriteLine("------------------------");
                    }
                break;
            }

        case 6:
            {
                Console.WriteLine("\n--- MOSTRAR MARCAS --");

                for (int i = 0; i < listamarcas.Count; i++)
                {
                    Console.WriteLine((i + 1) + "." + listamarcas[i]);

                }

                break;
            }

        case 7:
            {
                Console.WriteLine("\n--- MOSTRAR COLORES ---");

                for (int i = 0; i < listacolores.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + listacolores[i]);
                }


                break;
            }

        case 8:
            {
                Console.WriteLine("\n--- BUSCAR GORRAS POR MARCA ---");

                for (int i = 0; i < listamarcas.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + listamarcas[i]);
                }

                int seleccionMarcaBuscar;

                Console.Write("\nSeleccione la marca: ");
                int.TryParse(Console.ReadLine(), out seleccionMarcaBuscar);

                if (seleccionMarcaBuscar >= 1 && seleccionMarcaBuscar <= listamarcas.Count)
                {
                    string marcaBuscar = listamarcas[seleccionMarcaBuscar - 1];

                    int encontradas = 0;

                    for (int i = 0; i < marcas.Count; i++)
                    {
                        if (marcas[i] == marcaBuscar)
                        {
                            Console.WriteLine("\n------------------------");
                            Console.WriteLine("Codigo: " + codigos[i]);
                            Console.WriteLine("Nombre: " + nombres[i]);
                            Console.WriteLine("Marca: " + marcas[i]);
                            Console.WriteLine("Color: " + colores[i]);
                            Console.WriteLine("Precio: " + precios[i]);
                            Console.WriteLine("Cantidad: " + cantidades[i]);
                            Console.WriteLine("------------------------");

                            encontradas++;
                        }
                    }

                    if (encontradas == 0)
                    {
                        Console.WriteLine("No hay gorras registradas de esta marca.");
                    }
                }
                else
                {
                    Console.WriteLine("Marca no valida.");
                }

                break;
            }

        case 9:
            {
                Console.WriteLine("\n--- REGISTRAR NUEVA MARCA ---");
                Console.Write("Ingrese el nombre de la nueva marca: ");
                string nuevaMarca = Console.ReadLine() ?? "";

                if (nuevaMarca == "")
                {
                    Console.WriteLine("El nombre de la marca no puede estar vacio.");
                }
                else if (listamarcas.Contains(nuevaMarca))
                {
                    Console.WriteLine("Esta marca ya existe.");
                }
                else
                {
                    listamarcas.Add(nuevaMarca);

                    Console.WriteLine("La marca fue registrada correctamente.");
                }

                break;
            }

        case 10:
            {
                Console.WriteLine("\n--- REGISTRAR NUEVO COLOR ---");

                Console.Write("Ingrese el nombre del nuevo color: ");
                string nuevoColor = Console.ReadLine() ?? "";

                if (nuevoColor == "")
                {
                    Console.WriteLine("El nombre del color no puede estar vacio.");
                }
                else if (listacolores.Contains(nuevoColor))
                {
                    Console.WriteLine("Este color ya existe.");
                }
                else
                {
                    listacolores.Add(nuevoColor);

                    Console.WriteLine("El color fue registrado correctamente.");
                }

                break;
            }

        case 11:
            {
                Console.WriteLine("\nGracias por utilizar el sistema de inventario.");
                break;
            }

        default:
            Console.WriteLine("Opcion no valida");
            break;
    }

} while (opcion != 11);
