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

            datosCategoria = new DatosCategoria();
            datosProducto = new DatosProducto();
            ActualizarListaCategoria();
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
            List<Categoria> categorias = datosCategoria.GetCategorias();

            cmbCategoria.DisplayMemberPath = "Nombre";
            cmbCategoria.SelectedValuePath = "Id";
            cmbCategoria.ItemsSource = categorias;

            cmbCategoria.SelectedIndex = 0;
        }

        private void ActualizarListaProductos()
        {
            var productos = datosProducto.GetProductos((int)cmbCategoria.SelectedValue);
            dgProducto.ItemsSource = productos;
        }

    }
}
