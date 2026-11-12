

using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("================================");
Console.WriteLine("   CONTROL DE INVENTARIO");
Console.WriteLine("       TIENDA DE GORRAS");
Console.WriteLine("================================");

int opcion = 0;

// This list stores the cap objects registered in the inventory,
// making it easier to access and manage their information.
List<Gorra> gorras = new List<Gorra>();


List<Marca> listamarcas = new List<Marca>();

listamarcas.Add(new Marca("Nike"));
listamarcas.Add(new Marca("Adidas"));
listamarcas.Add(new Marca("New Era"));

// Available colors
List<Color> listacolores = new List<Color>();

listacolores.Add(new Color("Negro"));
listacolores.Add(new Color("Blanco"));
listacolores.Add(new Color("Azul"));

// This section displays the available brands and colors,
// so users can easily see the options before using the system.

Console.WriteLine("\n--- MARCAS DISPONIBLES ---");

int numeroMarca = 1;

foreach (Marca marca in listamarcas)
{
    Console.WriteLine(numeroMarca + ". " + marca.Nombre);
    numeroMarca++;
}


Console.WriteLine("\n--- COLORES DISPONIBLES ---");

int numeroColor = 1;

foreach (Color color in listacolores)
{
    Console.WriteLine(numeroColor + ". " + color.Nombre);
    numeroColor++;
}

// The main menu brings together the different inventory,
// options and allows users to choose what they want to do.

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
            // This process collects the cap details,
            // checks that the information is valid, and creates a new object to add to the inventory.
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

                    if (gorras.Any(g => g.Codigo == codigo))
                    {
                        Console.WriteLine("Este codigo ya existe.");
                        break;
                    }

                    Console.Write("Ingrese el nombre de la gorra: ");
                    string nombre = Console.ReadLine() ?? "";

                    if (nombre.Trim() == "")
                    {
                        Console.WriteLine("El nombre de la gorra no puede estar vacio.");
                        break;
                    }

                    Console.WriteLine("\nSeleccione una marca:");

                    for (int i = 0; i < listamarcas.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + listamarcas[i].Nombre);
                    }

                    int seleccionMarca;

                    Console.Write("Seleccione: ");

                    if (!int.TryParse(Console.ReadLine(), out seleccionMarca) ||
                        seleccionMarca < 1 || seleccionMarca > listamarcas.Count)
                    {
                        Console.WriteLine("Marca no valida.");
                        break;
                    }

                    Marca marcaseleccionada = listamarcas[seleccionMarca - 1];

                    Console.WriteLine("\nSeleccione un color:");

                    for (int i = 0; i < listacolores.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + listacolores[i].Nombre);
                    }

                    int seleccionColor;

                    Console.Write("Seleccione: ");

                    if (!int.TryParse(Console.ReadLine(), out seleccionColor) ||
                        seleccionColor < 1 || seleccionColor > listacolores.Count)
                    {
                        Console.WriteLine("Color no valido.");
                        break;
                    }

                    Color colorseleccionado = listacolores[seleccionColor - 1];

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

                    Gorra nuevaGorra = new Gorra(codigo, nombre, marcaseleccionada, colorseleccionado, precio, cantidad);

                    gorras.Add(nuevaGorra);

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

                    if (!int.TryParse(Console.ReadLine(), out codigoBuscar))
                    {
                        Console.WriteLine("Codigo no valido.");
                        break;
                    }

                    Gorra gorraEncontrada = gorras.FirstOrDefault(g => g.Codigo == codigoBuscar);

                    if (gorraEncontrada != null)
                    {
                        Console.WriteLine("\nGORRA ENCONTRADA");

                        Console.WriteLine("Codigo: " + gorraEncontrada.Codigo);
                        Console.WriteLine("Nombre: " + gorraEncontrada.Nombre);
                        Console.WriteLine("Marca: " + gorraEncontrada.Marca.Nombre);
                        Console.WriteLine("Color: " + gorraEncontrada.Color.Nombre);
                        Console.WriteLine("Precio: " + gorraEncontrada.Precio);
                        Console.WriteLine("Cantidad: " + gorraEncontrada.Cantidad);
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

                    Console.Write("Ingrese el codigo de la gorra: ");

                    if (!int.TryParse(Console.ReadLine(), out codigoModificar))
                    {
                        Console.WriteLine("Codigo no valido.");
                        break;
                    }

                    Gorra gorraModificar = gorras.FirstOrDefault(g => g.Codigo == codigoModificar);

                    if (gorraModificar != null)
                    {
                        Console.WriteLine("\nGORRA ENCONTRADA");

                        Console.Write("\nIngrese el nuevo nombre de la gorra: ");
                        string nombreNuevo = Console.ReadLine() ?? "";

                        if (nombreNuevo.Trim() != "")
                        {
                            gorraModificar.Nombre = nombreNuevo;
                            Console.WriteLine("El nombre fue modificado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("El nombre no puede estar vacio.");
                        }

                        Console.WriteLine("\n--- MARCAS DISPONIBLES ---");

                        for (int i = 0; i < listamarcas.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + listamarcas[i].Nombre);
                        }

                        int seleccionMarcaNueva;

                        Console.Write("Seleccione la nueva marca: ");
                        if (int.TryParse(Console.ReadLine(), out seleccionMarcaNueva) &&
                            seleccionMarcaNueva >= 1 && seleccionMarcaNueva <= listamarcas.Count)
                        {
                            gorraModificar.Marca = listamarcas[seleccionMarcaNueva - 1];

                            Console.WriteLine("La marca fue modificada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("La marca seleccionada no es valida.");
                        }

                        Console.WriteLine("\n--- COLORES DISPONIBLES ---");
                        for (int i = 0; i < listacolores.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + listacolores[i].Nombre);
                        }

                        int seleccionColorNueva;

                        Console.Write("\nSeleccione el nuevo color: ");

                        if (int.TryParse(Console.ReadLine(), out seleccionColorNueva) &&
                            seleccionColorNueva >= 1 && seleccionColorNueva <= listacolores.Count)
                        {
                            gorraModificar.Color = listacolores[seleccionColorNueva - 1];

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
                            gorraModificar.Precio = precioNuevo;
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
                            gorraModificar.Cantidad = cantidadNueva;
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
                try
                {
                    Console.WriteLine("\n--- ELIMINAR GORRA ---");

                    int codigoEliminar;

                    Console.Write("Ingrese el codigo de la gorra: ");

                    if (!int.TryParse(Console.ReadLine(), out codigoEliminar))
                    {
                        Console.WriteLine("Codigo no valido.");
                        break;
                    }

                    Gorra gorraEliminar = gorras.FirstOrDefault(g => g.Codigo == codigoEliminar);

                    if (gorraEliminar != null)
                    {
                        gorras.Remove(gorraEliminar);

                        Console.WriteLine("La gorra fue eliminada correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontro una gorra con ese codigo.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error al eliminar la gorra: " + ex.Message);
                }

                break;
            }

        case 5:
            {
                Console.WriteLine("\n--- LISTAR GORRAS ---");

                if (gorras.Count == 0)
                {
                    Console.WriteLine("No hay gorras registradas en el inventario.");
                }
                else
                {
                    foreach (Gorra gorra in gorras)
                    {
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("Codigo: " + gorra.Codigo);
                        Console.WriteLine("Nombre: " + gorra.Nombre);
                        Console.WriteLine("Marca: " + gorra.Marca.Nombre);
                        Console.WriteLine("Color: " + gorra.Color.Nombre);
                        Console.WriteLine("Precio: " + gorra.Precio);
                        Console.WriteLine("Cantidad: " + gorra.Cantidad);
                        Console.WriteLine("------------------------");
                    }
                }

                break;
            }

        case 6:
            {
                Console.WriteLine("\n--- MOSTRAR MARCAS ---");

                for (int i = 0; i < listamarcas.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + listamarcas[i].Nombre);
                }

                break;
            }

        case 7:
            {
                Console.WriteLine("\n--- MOSTRAR COLORES ---");

                for (int i = 0; i < listacolores.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + listacolores[i].Nombre);
                }

                break;
            }

        case 8:
            {
                Console.WriteLine("\n--- BUSCAR GORRAS POR MARCA ---");

                for (int i = 0; i < listamarcas.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + listamarcas[i].Nombre);
                }

                int seleccionMarcaBuscar;

                Console.Write("\nSeleccione la marca: ");

                if (int.TryParse(Console.ReadLine(), out seleccionMarcaBuscar) &&
                    seleccionMarcaBuscar >= 1 && seleccionMarcaBuscar <= listamarcas.Count)
                {
                    Marca marcaBuscar = listamarcas[seleccionMarcaBuscar - 1];

                    int encontradas = 0;

                    foreach (Gorra gorra in gorras)
                    {
                        if (gorra.Marca.Nombre == marcaBuscar.Nombre)
                        {
                            Console.WriteLine("\n------------------------");
                            Console.WriteLine("Codigo: " + gorra.Codigo);
                            Console.WriteLine("Nombre: " + gorra.Nombre);
                            Console.WriteLine("Marca: " + gorra.Marca.Nombre);
                            Console.WriteLine("Color: " + gorra.Color.Nombre);
                            Console.WriteLine("Precio: " + gorra. Precio);
                            Console.WriteLine("Cantidad: " + gorra.Cantidad);
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

                if (nuevaMarca.Trim() == "")
                {
                    Console.WriteLine("El nombre de la marca no puede estar vacio.");
                }
                else if (listamarcas.Any(m => m.Nombre == nuevaMarca))
                {
                    Console.WriteLine("Esta marca ya existe.");
                }
                else
                {
                    Marca marcaNueva = new Marca(nuevaMarca);

                    listamarcas.Add(marcaNueva);

                    Console.WriteLine("La marca fue registrada correctamente.");
                }

                break;
            }

        case 10:
            {
                Console.WriteLine("\n--- REGISTRAR NUEVO COLOR ---");

                Console.Write("Ingrese el nombre del nuevo color: ");
                string nuevoColor = Console.ReadLine() ?? "";

                if (nuevoColor.Trim() == "")
                {
                    Console.WriteLine("El nombre del color no puede estar vacio.");
                }
                else if (listacolores.Any(c => c.Nombre == nuevoColor))
                {
                    Console.WriteLine("Este color ya existe.");
                }
                else
                {
                    Color colorNuevo = new Color(nuevoColor);

                    listacolores.Add(colorNuevo);

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
            Console.WriteLine("Opcion no valida.");
            break;
    }

} while (opcion != 11);

