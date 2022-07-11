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

            if (_datosCategoria.CrearCategoria(_categoria)) MessageBox.Show("Se a creado la categoria con exito");
            else MessageBox.Show("No se pudo crear la categoria");

            Close();
        }
    }
}
