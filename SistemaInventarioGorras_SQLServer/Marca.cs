public class Marca
{
    public int IdMarca { get; set; }
    public string Nombre { get; set; }

    public Marca(string nombre)
    {
        Nombre = nombre;
    }

    public Marca(int idMarca, string nombre)
    {
        IdMarca = idMarca;
        Nombre = nombre;
    }
}