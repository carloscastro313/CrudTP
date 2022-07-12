using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace CrudTP.Componentes
{
    /// <summary>
    /// Lógica de interacción para FormProducto.xaml
    /// </summary>
    public partial class FormProducto : UserControl
    {
        public FormProducto()
        {
            InitializeComponent();
        }

        private void isNumber(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void isFloat(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            e.Handled = !regex.IsMatch(e.Text);
        }


    }
}
