using CrudTP.Datos;
using CrudTP.Entidades;
using System.Windows;

namespace CrudTP.Vistas
{
    /// <summary>
    /// Lógica de interacción para CrearCategoria.xaml
    /// </summary>
    public partial class CrearCategoria : Window
    {
        public Categoria _categoria;
        private DatosCategoria _datosCategoria;
        public CrearCategoria(DatosCategoria datosCategoria)
        {
            InitializeComponent();

            _categoria = new Categoria();
            _datosCategoria = datosCategoria;
            frmCategoria.DataContext = _categoria;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_categoria.Nombre))
            {
                MessageBox.Show("Todos los campos son obligatorios");
                return;
            }

            try
            {
                _datosCategoria.CrearCategoria(_categoria);
            }
            catch (System.Exception)
            {
                MessageBox.Show("ERROR - No se a podido conectar a la base de datos - Creacion no efectuada");
            }

            Close();
        }
    }
}
