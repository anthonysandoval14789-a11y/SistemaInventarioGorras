
using System;
using Microsoft.Data.SqlClient;

// This connection is used to access the database
// and work with the information stored in it.

string connectionString = "Server=localhost;Database=InventarioGorrasBD;Integrated Security=True;TrustServerCertificate=True;";

// Here we get the available brands and colors
// from the database and show them to the user.
void MostrarMarcas()
{
    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        conexion.Open();

        string consulta = "SELECT IdMarca, Nombre FROM Marca ORDER BY IdMarca";
        using (SqlCommand comando = new SqlCommand(consulta, conexion))
        using (SqlDataReader lector = comando.ExecuteReader())
        {
            Console.WriteLine("\n--- MARCAS DISPONIBLES ---");

            while (lector.Read())
            {
                Console.WriteLine(lector["IdMarca"] + ". " + lector["Nombre"]);
            }
        }
    }
}


void MostrarColores()
{
    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        conexion.Open();

        string consulta = "SELECT IdColor, Nombre FROM Color ORDER BY IdColor";
        using (SqlCommand comando = new SqlCommand(consulta, conexion))
        using (SqlDataReader lector = comando.ExecuteReader())
        {
            Console.WriteLine("\n--- COLORES DISPONIBLES ---");

            while (lector.Read())
            {
                Console.WriteLine(lector["IdColor"] + ". " + lector["Nombre"]);
            }
        }
    }
}


bool ExisteGorra(int codigo)
{
    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        conexion.Open();

        string consulta = "SELECT COUNT(*) FROM Gorra WHERE Codigo = @Codigo";

        using (SqlCommand comando = new SqlCommand(consulta, conexion))
        {
            comando.Parameters.AddWithValue("@Codigo", codigo);

            int cantidad = (int)comando.ExecuteScalar();

            return cantidad > 0;
        }
    }
}

bool ExisteMarca(int idMarca)
{
    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        conexion.Open();

        string consulta = "SELECT COUNT(*) FROM Marca WHERE IdMarca = @IdMarca";

        using (SqlCommand comando = new SqlCommand(consulta, conexion))
        {
            comando.Parameters.AddWithValue("@IdMarca", idMarca);

            return (int)comando.ExecuteScalar() > 0;
        }
    }
}


bool ExisteColor(int idColor)
{
    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        conexion.Open();

        string consulta = "SELECT COUNT(*) FROM Color WHERE IdColor = @IdColor";

        using (SqlCommand comando = new SqlCommand(consulta, conexion))
        {
            comando.Parameters.AddWithValue("@IdColor", idColor);

            return (int)comando.ExecuteScalar() > 0;
        }
    }
}

// This part displays the caps saved in the database
// along with their brand, color and other details.
void MostrarGorras()
{
    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        conexion.Open();

        string consulta = @"
            SELECT G.Codigo, G.Nombre, M.Nombre AS Marca,
                   C.Nombre AS Color, G.Precio, G.Cantidad
            FROM Gorra G
            INNER JOIN Marca M ON G.IdMarca = M.IdMarca
            INNER JOIN Color C ON G.IdColor = C.IdColor
            ORDER BY G.Codigo";

        using (SqlCommand comando = new SqlCommand(consulta, conexion))
        using (SqlDataReader lector = comando.ExecuteReader())
        {
            Console.WriteLine("\n--- LISTAR GORRAS ---");

            if (!lector.HasRows)
            {
                Console.WriteLine("No hay gorras registradas en el inventario.");
                return;
            }

            while (lector.Read())
            {
                Console.WriteLine("\n------------------------");
                Console.WriteLine("Codigo: " + lector["Codigo"]);
                Console.WriteLine("Nombre: " + lector["Nombre"]);
                Console.WriteLine("Marca: " + lector["Marca"]);
                Console.WriteLine("Color: " + lector["Color"]);
                Console.WriteLine("Precio: " + lector["Precio"]);
                Console.WriteLine("Cantidad: " + lector["Cantidad"]);
                Console.WriteLine("------------------------");
            }
        }
    }
}

void BuscarGorra(int codigo)
{
    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        conexion.Open();

        string consulta = @"
            SELECT G.Codigo, G.Nombre, M.Nombre AS Marca,
                   C.Nombre AS Color, G.Precio, G.Cantidad
            FROM Gorra G
            INNER JOIN Marca M ON G.IdMarca = M.IdMarca
            INNER JOIN Color C ON G.IdColor = C.IdColor
            WHERE G.Codigo = @Codigo";

        using (SqlCommand comando = new SqlCommand(consulta, conexion))
        {
            comando.Parameters.AddWithValue("@Codigo", codigo);

            using (SqlDataReader lector = comando.ExecuteReader())
            {
                if (lector.Read())
                {
                    Console.WriteLine("\nGORRA ENCONTRADA");
                    Console.WriteLine("Codigo: " + lector["Codigo"]);
                    Console.WriteLine("Nombre: " + lector["Nombre"]);
                    Console.WriteLine("Marca: " + lector["Marca"]);
                    Console.WriteLine("Color: " + lector["Color"]);
                    Console.WriteLine("Precio: " + lector["Precio"]);
                    Console.WriteLine("Cantidad: " + lector["Cantidad"]);
                }
                else
                {
                    Console.WriteLine("No se encontro una gorra con ese codigo.");
                }
            }
        }
    }
}


void BuscarGorrasPorMarca(int idMarca)
{
    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        conexion.Open();

        string consulta = @"
            SELECT G.Codigo, G.Nombre, M.Nombre AS Marca,
                   C.Nombre AS Color, G.Precio, G.Cantidad
            FROM Gorra G
            INNER JOIN Marca M ON G.IdMarca = M.IdMarca
            INNER JOIN Color C ON G.IdColor = C.IdColor
            WHERE G.IdMarca = @IdMarca
            ORDER BY G.Codigo";

        using (SqlCommand comando = new SqlCommand(consulta, conexion))
        {
            comando.Parameters.AddWithValue("@IdMarca", idMarca);
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                int encontradas = 0;

                while (lector.Read())
                {
                    Console.WriteLine("\n------------------------");
                    Console.WriteLine("Codigo: " + lector["Codigo"]);
                    Console.WriteLine("Nombre: " + lector["Nombre"]);
                    Console.WriteLine("Marca: " + lector["Marca"]);
                    Console.WriteLine("Color: " + lector["Color"]);
                    Console.WriteLine("Precio: " + lector["Precio"]);
                    Console.WriteLine("Cantidad: " + lector["Cantidad"]);
                    Console.WriteLine("------------------------");

                    encontradas++;
                }

                if (encontradas == 0)
                {
                    Console.WriteLine("No hay gorras registradas de esta marca.");
                }
            }
        }
    }
}


Console.WriteLine("================================");
Console.WriteLine("   CONTROL DE INVENTARIO");
Console.WriteLine("       TIENDA DE GORRAS");
Console.WriteLine("================================");

int opcion = 0;

// These options allow the user to add, update
// and delete informationFrom the inventory.
do
{
    Console.WriteLine("\n============================");
    Console.WriteLine("       MENU PRINCIPAL");
    Console.WriteLine("==============================");
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
                    Console.WriteLine("\n---REGISTRAR NUEVA GORRA---");

                    int codigo;

                    Console.Write("Ingrese el codigo de la gorra: ");

                    if (!int.TryParse(Console.ReadLine(), out codigo) || codigo <= 0)
                    {
                        Console.WriteLine("Codigo no valido.");
                        break;
                    }

                    if (ExisteGorra(codigo))
                    {
                        Console.WriteLine("Este codigo ya existe.");
                        break;
                    }

                    Console.Write("Ingrese el nombre de la gorra: ");
                    string nombre = Console.ReadLine() ?? "";

                    if (nombre.Trim() == "")
                    {
                        Console.WriteLine("El nombre no puede estar vacio.");
                        break;
                    }

                    MostrarMarcas();

                    int idMarca;

                    Console.Write("\nIngrese el ID de la marca: ");

                    if (!int.TryParse(Console.ReadLine(), out idMarca) || !ExisteMarca(idMarca))
                    {
                        Console.WriteLine("Marca no valida.");
                        break;
                    }

                    MostrarColores();

                    int idColor;

                    Console.Write("\nIngrese el ID del color: ");

                    if (!int.TryParse(Console.ReadLine(), out idColor) || !ExisteColor(idColor))
                    {
                        Console.WriteLine("Color no valido.");
                        break;
                    }

                    decimal precio;

                    Console.Write("Ingrese el precio: ");

                    if (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                    {
                        Console.WriteLine("Precio no valido.");
                        break;
                    }

                    int cantidad;

                    Console.Write("Ingrese la cantidad disponible: ");

                    if (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 0)
                    {
                        Console.WriteLine("Cantidad no valida.");
                        break;
                    }

                    using (SqlConnection conexion = new SqlConnection(connectionString))
                    {
                        conexion.Open();

                        string consulta = @"
                            INSERT INTO Gorra
                            (Codigo, Nombre, IdMarca, IdColor, Precio, Cantidad)
                            VALUES
                            (@Codigo, @Nombre, @IdMarca, @IdColor, @Precio, @Cantidad)";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Codigo", codigo);
                            comando.Parameters.AddWithValue("@Nombre", nombre);
                            comando.Parameters.AddWithValue("@IdMarca", idMarca);
                            comando.Parameters.AddWithValue("@IdColor", idColor);
                            comando.Parameters.AddWithValue("@Precio", precio);
                            comando.Parameters.AddWithValue("@Cantidad", cantidad);

                            comando.ExecuteNonQuery();
                        }
                    }

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

                    BuscarGorra(codigoBuscar);
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

                    if (!ExisteGorra(codigoModificar))
                    {
                        Console.WriteLine("No se encontro una gorra con ese codigo.");
                        break;
                    }

                    Console.Write("Ingrese el nuevo nombre: ");
                    string nombreNuevo = Console.ReadLine() ?? "";

                    if (nombreNuevo.Trim() == "")
                    {
                        Console.WriteLine("El nombre no puede estar vacio.");
                        break;
                    }

                    MostrarMarcas();

                    int idMarcaNueva;

                    Console.Write("\nIngrese el nuevo ID de marca: ");

                    if (!int.TryParse(Console.ReadLine(), out idMarcaNueva) || !ExisteMarca(idMarcaNueva))
                    {
                        Console.WriteLine("Marca no valida.");
                        break;
                    }

                    MostrarColores();

                    int idColorNuevo;

                    Console.Write("\nIngrese el nuevo ID de color: ");

                    if (!int.TryParse(Console.ReadLine(), out idColorNuevo) || !ExisteColor(idColorNuevo))
                    {
                        Console.WriteLine("Color no valido.");
                        break;
                    }

                    decimal precioNuevo;

                    Console.Write("Ingrese el nuevo precio: ");

                    if (!decimal.TryParse(Console.ReadLine(), out precioNuevo) || precioNuevo <= 0)
                    {
                        Console.WriteLine("Precio no valido.");
                        break;
                    }

                    int cantidadNueva;

                    Console.Write("Ingrese la nueva cantidad: ");

                    if (!int.TryParse(Console.ReadLine(), out cantidadNueva) || cantidadNueva < 0)
                    {
                        Console.WriteLine("Cantidad no valida.");
                        break;
                    }

                    using (SqlConnection conexion = new SqlConnection(connectionString))
                    {
                        conexion.Open();

                        string consulta = @"
                            UPDATE Gorra
                            SET Nombre = @Nombre,
                                IdMarca = @IdMarca,
                                IdColor = @IdColor,
                                Precio = @Precio,
                                Cantidad = @Cantidad
                            WHERE Codigo = @Codigo";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Nombre", nombreNuevo);
                            comando.Parameters.AddWithValue("@IdMarca", idMarcaNueva);
                            comando.Parameters.AddWithValue("@IdColor", idColorNuevo);
                            comando.Parameters.AddWithValue("@Precio", precioNuevo);
                            comando.Parameters.AddWithValue("@Cantidad", cantidadNueva);
                            comando.Parameters.AddWithValue("@Codigo", codigoModificar);

                            comando.ExecuteNonQuery();
                        }
                    }

                    Console.WriteLine("La gorra fue modificada correctamente.");
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

                    using (SqlConnection conexion = new SqlConnection(connectionString))
                    {
                        conexion.Open();
                        string consulta = "DELETE FROM Gorra WHERE Codigo = @Codigo";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Codigo", codigoEliminar);

                            int filas = comando.ExecuteNonQuery();

                            if (filas > 0)
                            {
                                Console.WriteLine("La gorra fue eliminada correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("No se encontro una gorra con ese codigo.");
                            }
                        }
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
                try
                {
                    MostrarGorras();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error al listar las gorras: " + ex.Message);
                }

                break;
            }

        case 6:
            {
                try
                {
                    MostrarMarcas();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error al mostrar las marcas: " + ex.Message);
                }

                break;
            }

        case 7:
            {
                try
                {
                    MostrarColores();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error al mostrar los colores: " + ex.Message);
                }

                break;
            }

        case 8:
            {
                try
                {
                    Console.WriteLine("\n--- BUSCAR GORRAS POR MARCA ---");

                    MostrarMarcas();

                    int idMarcaBuscar;

                    Console.Write("\nSeleccione el ID de la marca: ");

                    if (!int.TryParse(Console.ReadLine(), out idMarcaBuscar) || !ExisteMarca(idMarcaBuscar))
                    {
                        Console.WriteLine("Marca no valida.");
                        break;
                    }

                    BuscarGorrasPorMarca(idMarcaBuscar);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error al buscar las gorras: " + ex.Message);
                }

                break;
            }

        case 9:
            {
                try
                {
                    Console.WriteLine("\n--- REGISTRAR NUEVA MARCA ---");

                    Console.Write("Ingrese el nombre de la nueva marca: ");
                    string nuevaMarca = Console.ReadLine() ?? "";

                    if (nuevaMarca.Trim() == "")
                    {
                        Console.WriteLine("El nombre de la marca no puede estar vacio.");
                        break;
                    }

                    using (SqlConnection conexion = new SqlConnection(connectionString))
                    {
                        conexion.Open();

                        string consultaExiste = "SELECT COUNT(*) FROM Marca WHERE Nombre = @Nombre";

                        using (SqlCommand comandoExiste = new SqlCommand(consultaExiste, conexion))
                        {
                            comandoExiste.Parameters.AddWithValue("@Nombre", nuevaMarca);

                            if ((int)comandoExiste.ExecuteScalar() > 0)
                            {
                                Console.WriteLine("Esta marca ya existe.");
                                break;
                            }
                        }

                        string consulta = "INSERT INTO Marca (Nombre) VALUES (@Nombre)";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Nombre", nuevaMarca);
                            comando.ExecuteNonQuery();
                        }
                    }

                    Console.WriteLine("La marca fue registrada correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error al registrar la marca: " + ex.Message);
                }

                break;
            }

        case 10:
            {
                try
                {
                    Console.WriteLine("\n--- REGISTRAR NUEVO COLOR ---");
                    Console.Write("Ingrese el nombre del nuevo color: ");
                    string nuevoColor = Console.ReadLine() ?? "";

                    if (nuevoColor.Trim() == "")
                    {
                        Console.WriteLine("El nombre del color no puede estar vacio.");
                        break;
                    }

                    using (SqlConnection conexion = new SqlConnection(connectionString))
                    {
                        conexion.Open();
                        string consultaExiste = "SELECT COUNT(*) FROM Color WHERE Nombre = @Nombre";

                        using (SqlCommand comandoExiste = new SqlCommand(consultaExiste, conexion))
                        {
                            comandoExiste.Parameters.AddWithValue("@Nombre", nuevoColor);

                            if ((int)comandoExiste.ExecuteScalar() > 0)
                            {
                                Console.WriteLine("Este color ya existe.");
                                break;
                            }
                        }

                        string consulta = "INSERT INTO Color (Nombre) VALUES (@Nombre)";
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Nombre", nuevoColor);
                            comando.ExecuteNonQuery();
                        }
                    }

                    Console.WriteLine("El color fue registrado correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error al registrar el color: " + ex.Message);
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

