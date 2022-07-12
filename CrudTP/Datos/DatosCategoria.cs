using CrudTP.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CrudTP.Datos
{
    public class DatosCategoria : Datos
    {

        public List<Categoria> GetCategorias()
        {
            DataTable categoriasTable = ExecuteDataAdapter("SELECT * FROM CATEGORIA");

            return categoriasTable.AsEnumerable().Select(row => new Categoria
            {
                Id = row.Field<int>("Id"),
                Nombre = row.Field<string>("nombre"),
            }).ToList(); ;
        }

        public bool CrearCategoria(Categoria categoria)
        {
            string query = "INSERT INTO CATEGORIA (nombre) VALUES (@nombre)";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre", categoria.Nombre);

            return ExecuteCommand(sqlCommand);
        }
    }
}
