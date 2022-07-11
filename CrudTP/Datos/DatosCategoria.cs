using CrudTP.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CrudTP.Datos
{
    public class DatosCategoria : Datos
    {

        public List<Categoria> GetCategorias()
        {
            List<Categoria> categorias = new List<Categoria>(){
                    new Categoria()
                    {
                        Id = -1,
                        Nombre = "Todos"
                    }
                };

            DataTable categoriasTable = ExecuteDataAdapter("SELECT * FROM CATEGORIA");
            foreach (DataRow row in categoriasTable.Rows)
            {
                categorias.Add(new Categoria
                {
                    Id = (int)row["Id"],
                    Nombre = (string)row["nombre"]
                });
            }

            return categorias;
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
