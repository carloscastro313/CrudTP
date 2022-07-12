using CrudTP.Datos;
using CrudTP.Entidades;
using System.Collections.Generic;
using System.Windows;

namespace CrudTP.Vistas
{
    /// <summary>
    /// Lógica de interacción para ModificarProducto.xaml
    /// </summary>
    public partial class ModificarProducto : Window
    {
        DatosProducto _datosProducto;
        Producto _producto;

        public ModificarProducto(DatosCategoria datosCategoria, DatosProducto datosProducto, Producto producto)
        {
            InitializeComponent();
            _producto = producto;
            List<Categoria> categorias = datosCategoria.GetCategorias();

            frmProducto.cmbCategoria.DisplayMemberPath = "Nombre";
            frmProducto.cmbCategoria.SelectedValuePath = "Id";
            frmProducto.cmbCategoria.ItemsSource = categorias;

            frmProducto.DataContext = _producto;

            _datosProducto = datosProducto;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!_producto)
            {
                MessageBox.Show("El producto no es valido");
                return;
            }

            try
            {
                if (!_datosProducto.ModificarProducto(_producto)) MessageBox.Show("Hubo un error al modificar el producto");
            }
            catch (System.Exception)
            {
                MessageBox.Show("ERROR - No se a podido conectar a la base de datos - Cambios no efectuados");
            }
            finally
            {
                Close();
            }
        }
    }
}
