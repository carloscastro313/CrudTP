using CrudTP.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CrudTP.Datos
{
    public class DatosProducto : Datos
    {
        public List<Producto> GetProductos(int idCategoria = -1)
        {
            string query = "SELECT *, c.nombre as nombreCategoria FROM PRODUCTO p INNER JOIN CATEGORIA c ON p.categoria = c.Id";

            if (idCategoria != -1)
            {
                query += " WHERE categoria = @IdCategoria";
            }

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);


            if (idCategoria != -1)
            {
                sqlCommand.Parameters.AddWithValue("@IdCategoria", idCategoria);
            }

            DataTable dataTable = ExecuteDataAdapter(sqlCommand);

            return dataTable.AsEnumerable().Select(row => new Producto
            {
                Id = row.Field<int>("Id"),
                Nombre = row.Field<string>("nombre"),
                Marca = row.Field<string>("marca"),
                Precio = row.Field<double>("precio"),
                Cantidad = row.Field<int>("cantidad"),
                Categoria = row.Field<int>("categoria"),
                NombreCategoria = row.Field<string>("nombreCategoria")

            }).ToList();
        }

        public bool CrearProducto(Producto producto)
        {
            string query = "INSERT INTO PRODUCTO (nombre,marca,precio,cantidad,categoria) VALUES (@nombre,@marca,@precio,@cantidad,@categoria)";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre", producto.Nombre);
            sqlCommand.Parameters.AddWithValue("@marca", producto.Marca);
            sqlCommand.Parameters.AddWithValue("@precio", producto.Precio);
            sqlCommand.Parameters.AddWithValue("@cantidad", producto.Cantidad);
            sqlCommand.Parameters.AddWithValue("@categoria", producto.Categoria);

            return ExecuteCommand(sqlCommand);
        }

        public bool EliminarProducto(int id)
        {
            string query = "DELETE FROM PRODUCTO WHERE Id = @id";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id", id);

            return ExecuteCommand(sqlCommand);
        }

        public bool ModificarProducto(Producto producto)
        {
            string query = "UPDATE PRODUCTO SET nombre = @nombre, marca = @marca, precio = @precio, cantidad = @cantidad, categoria = @categoria WHERE Id = @id";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id", producto.Id);
            sqlCommand.Parameters.AddWithValue("@nombre", producto.Nombre);
            sqlCommand.Parameters.AddWithValue("@marca", producto.Marca);
            sqlCommand.Parameters.AddWithValue("@precio", producto.Precio);
            sqlCommand.Parameters.AddWithValue("@cantidad", producto.Cantidad);
            sqlCommand.Parameters.AddWithValue("@categoria", producto.Categoria);

            return ExecuteCommand(sqlCommand);
        }
    }
}
