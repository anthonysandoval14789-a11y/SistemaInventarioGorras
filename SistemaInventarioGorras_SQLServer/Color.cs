public class Color
{
    public int IdColor { get; set; }
    public string Nombre { get; set; }

    public Color(string nombre)
    {
        Nombre = nombre;
    }

    public Color(int idColor, string nombre)
    {
        IdColor = idColor;
        Nombre = nombre;
    }
}