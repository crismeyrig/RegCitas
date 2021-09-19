using System.Windows;
using RegCitas.BLL;
using RegCitas.Entidades;
using RegCitas.DAL;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegCitas.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rCitas.xaml
    /// </summary>
    public partial class rCitas : Window
    {

        private Citas citas;

        public rCitas()
        {
            InitializeComponent();
            this.DataContext = citas;
        }
        private void Limpiar()
        {
            this.citas = new Citas();
            this.DataContext = citas;


        }
        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallidad", "Fallo");
            }
            return esValido;

        }
        public void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var citas = CitasBLL.Buscar(int.Parse(CitaIdTextBox.Text));

            if (citas != null)
                this.citas = citas;
            else
                this.DataContext = this.citas;

        }
        public void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();


        }
        public void GuardarButton_Click(object sender, RoutedEventArgs e)
        {


            if (!Validar())
                return;

            citas.Nombres = NombresTextBox.Text;
            citas.Apellidos = ApellidosTextBox.Text;
            citas.Descripcion = DescripcionTextBox.Text;
            citas.Telefono = TelefonoTextBox.Text;


            var paso = CitasBLL.Guardar(citas);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transacciones exitosa!", "Existo");
            }
            else
                MessageBox.Show("Transacciones Fallida", "Fallo");


        }
        public void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CitasBLL.Eliminar(int.Parse(CitaIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Existo");
            }
            else

                MessageBox.Show("No fue posible eliminar", "Fallo");

        }
    }
}
