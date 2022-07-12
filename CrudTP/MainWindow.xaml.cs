using CrudTP.Datos;
using CrudTP.Entidades;
using CrudTP.Vistas;
using System.Collections.Generic;
using System.Windows;

namespace CrudTP
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatosCategoria datosCategoria;
        DatosProducto datosProducto;

        public MainWindow()
        {
            InitializeComponent();
            try
            {

                datosCategoria = new DatosCategoria();
                datosProducto = new DatosProducto();
                ActualizarListaCategoria();
            }
            catch (System.Exception)
            {
                MessageBox.Show("ERROR - No se pudo conectar a la base de datos - ¡Cerrando aplicacion!");

                Close();
            }
        }

        private void btnCrearCategoria_Click(object sender, RoutedEventArgs e)
        {
            CrearCategoria crearCategoria = new CrearCategoria(datosCategoria);

            crearCategoria.ShowDialog();
            ActualizarListaCategoria();

        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbCategoria_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cmbCategoria.SelectedValue == null) return;

            ActualizarListaProductos();
        }

        private void ActualizarListaCategoria()
        {
            List<Categoria> categorias = new List<Categoria>(){
                    new Categoria()
                    {
                        Id = -1,
                        Nombre = "Todos"
                    }
                };

            try
            {
                categorias.AddRange(datosCategoria.GetCategorias());

                cmbCategoria.DisplayMemberPath = "Nombre";
                cmbCategoria.SelectedValuePath = "Id";
                cmbCategoria.ItemsSource = categorias;

                cmbCategoria.SelectedIndex = 0;
            }
            catch (System.Exception)
            {
                MessageBox.Show("ERROR - No se a podido conectar a la base de datos - Carga de categorias no efectuada");

                throw;
            }
        }

        private void ActualizarListaProductos()
        {
            try
            {
                var productos = datosProducto.GetProductos((int)cmbCategoria.SelectedValue);
                dgProducto.UnselectAll();
                dgProducto.ItemsSource = productos;
            }
            catch (System.Exception)
            {
                MessageBox.Show("ERROR - No se a podido conectar a la base de datos - Carga de producto no efectuada");

                throw;
            }
        }

        private void btnCrearProducto_Click(object sender, RoutedEventArgs e)
        {
            CrearProducto producto = new CrearProducto(datosCategoria, datosProducto);

            producto.ShowDialog();

            ActualizarListaProductos();
        }

        private void btnModificarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Se tiene que seleccionar un producto para modificar");
                return;
            }
            Producto producto = dgProducto.SelectedItem as Producto;

            ModificarProducto modificarProducto = new ModificarProducto(datosCategoria, datosProducto, producto);

            modificarProducto.ShowDialog();

            ActualizarListaProductos();
        }

        private void btnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Se tiene que seleccionar un producto para eliminar");
                return;
            }
            Producto producto = dgProducto.SelectedItem as Producto;
            MessageBoxResult result = MessageBox.Show($"¿Desea eliminar este producto? {producto.Nombre + " " + producto.Marca}", "Eliminar", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No) return;

            try
            {
                if (!datosProducto.EliminarProducto(producto.Id))
                {
                    MessageBox.Show("Hubo un error al eliminar");
                }

                ActualizarListaProductos();
            }
            catch (System.Exception)
            {
                MessageBox.Show("ERROR - No se a podido conectar a la base de datos - Eliminacion no efectuados");
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            ActualizarListaProductos();
        }
    }
}
