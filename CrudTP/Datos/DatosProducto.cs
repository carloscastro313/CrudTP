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
            SqlCommand sqlCommand;

            if (idCategoria != -1)
            {
                sqlCommand = new SqlCommand("spGetProductosPorCategoria", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@IdCategoria", idCategoria);
            }
            else
            {
                sqlCommand = new SqlCommand("spGetProductos", sqlConnection);
            }

            sqlCommand.CommandType = CommandType.StoredProcedure;

            DataTable dataTable = ExecuteDataReader(sqlCommand);

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
            SqlCommand sqlCommand = new SqlCommand("spCreateProducto", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre", producto.Nombre);
            sqlCommand.Parameters.AddWithValue("@marca", producto.Marca);
            sqlCommand.Parameters.AddWithValue("@precio", producto.Precio);
            sqlCommand.Parameters.AddWithValue("@cantidad", producto.Cantidad);
            sqlCommand.Parameters.AddWithValue("@categoria", producto.Categoria);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            return ExecuteCommand(sqlCommand);
        }

        public bool EliminarProducto(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("spDeleteProducto", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id", id);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            return ExecuteCommand(sqlCommand);
        }

        public bool ModificarProducto(Producto producto)
        {
            SqlCommand sqlCommand = new SqlCommand("spUpdateProducto", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id", producto.Id);
            sqlCommand.Parameters.AddWithValue("@nombre", producto.Nombre);
            sqlCommand.Parameters.AddWithValue("@marca", producto.Marca);
            sqlCommand.Parameters.AddWithValue("@precio", producto.Precio);
            sqlCommand.Parameters.AddWithValue("@cantidad", producto.Cantidad);
            sqlCommand.Parameters.AddWithValue("@categoria", producto.Categoria);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            return ExecuteCommand(sqlCommand);
        }
    }
}
