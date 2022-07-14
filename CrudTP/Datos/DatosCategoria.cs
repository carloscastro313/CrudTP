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
            SqlCommand cmd = new SqlCommand("spGetCategoria", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable categoriasTable = ExecuteDataReader(cmd);

            return categoriasTable.AsEnumerable().Select(row => new Categoria
            {
                Id = row.Field<int>("Id"),
                Nombre = row.Field<string>("nombre"),
            }).ToList(); ;
        }

        public bool CrearCategoria(Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("spCreateCategoria", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);

            return ExecuteCommand(cmd);
        }
    }
}
