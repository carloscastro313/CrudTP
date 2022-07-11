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
            string query = "SELECT * FROM PRODUCTO";

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
                Categoria = row.Field<int>("categoria")
            }).ToList();
        }
    }
}
