namespace CrudTP.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public int Categoria { get; set; }
        public string NombreCategoria { get; set; }

        public Producto()
        {
            Id = -1;
            Precio = 0;
            Categoria = -1;
            Cantidad = 0;
        }

        public static implicit operator bool(Producto producto)
        {
            return !string.IsNullOrEmpty(producto.Nombre) && !string.IsNullOrEmpty(producto.Marca) && producto.Precio > 0 && producto.Cantidad > 0 && producto.Categoria > -1;
        }
    }
}
