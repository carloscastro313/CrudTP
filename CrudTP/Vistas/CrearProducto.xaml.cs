using CrudTP.Datos;
using CrudTP.Entidades;
using System.Collections.Generic;
using System.Windows;

namespace CrudTP.Vistas
{
    /// <summary>
    /// Lógica de interacción para CrearProducto.xaml
    /// </summary>
    public partial class CrearProducto : Window
    {
        DatosProducto _datosProducto;
        Producto producto;

        public CrearProducto(DatosCategoria datosCategoria, DatosProducto datosProducto)
        {
            InitializeComponent();
            producto = new Producto();
            List<Categoria> categorias = datosCategoria.GetCategorias();

            frmProducto.cmbCategoria.DisplayMemberPath = "Nombre";
            frmProducto.cmbCategoria.SelectedValuePath = "Id";
            frmProducto.cmbCategoria.ItemsSource = categorias;

            frmProducto.DataContext = producto;

            _datosProducto = datosProducto;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!producto)
            {
                MessageBox.Show("El producto no es valido");
                return;
            }

            try
            {
                _datosProducto.CrearProducto(producto);
            }
            catch (System.Exception)
            {
                MessageBox.Show("ERROR - No se a podido conectar a la base de datos - Creacion no efectuada");
            }
            finally
            {
                Close();
            }
        }
    }
}
