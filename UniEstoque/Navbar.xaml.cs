using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UniEstoque
{
    /// <summary>
    /// Interaction logic for Navbar.xaml
    /// </summary>
    public partial class Navbar : Page
    {
        public void GetJanelaAberta(Window JanelaAnterior)
        {
            
        }
        public Navbar()
        {
            InitializeComponent();
        }
        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            Window Dashboard = new DashboardTela();
            if (Dashboard.IsActive == true)
            {
                return;
            }
            else
            {
                Dashboard.Show();
            }
        }

        private void Funcionarios_Click(object sender, RoutedEventArgs e)
        {
            Window Funcionario = new FuncionarioTela();
            Funcionario.Show();
        }

        private void Estoque_Click(object sender, RoutedEventArgs e)
        {
            Window Estoque = new EstoqueTela();
            Estoque.Show();
        }
        private void Relatorio_Click(object sender, RoutedEventArgs e)
        {
            Window Relatorio = new RelatorioTela();
            Relatorio.Show();
        }
    }
}
