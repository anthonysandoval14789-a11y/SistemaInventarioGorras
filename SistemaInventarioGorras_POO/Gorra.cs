using System;


public class Gorra
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public Marca Marca { get; set; }
    public Color Color { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }

    public Gorra(int codigo, string nombre, Marca marca, Color color, decimal precio, int cantidad)
    {
        this.Codigo = codigo;
        Nombre = nombre;
        Marca = marca;
        Color = color;
        this.Precio = precio;
        Cantidad = cantidad;
    }
}