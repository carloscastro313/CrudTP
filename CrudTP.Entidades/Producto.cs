namespace CrudTP.Entidades
{
    public class Producto
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public int Categoria { get; set; }
    }
}
