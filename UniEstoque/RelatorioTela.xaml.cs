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
using System.Windows.Shapes;

namespace UniEstoque
{
    /// <summary>
    /// Interaction logic for RelatorioTela.xaml
    /// </summary>
    public partial class RelatorioTela : Window
    {
        public RelatorioTela()
        {
            InitializeComponent();
        }
        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            Window Dashboard = new DashboardTela();
            Dashboard.Show();
            this.Close();
        }

        private void Funcionarios_Click(object sender, RoutedEventArgs e)
        {
            Window Funcionario = new FuncionarioTela();
            Funcionario.Show();
            this.Close();
        }

        private void Estoque_Click(object sender, RoutedEventArgs e)
        {
            Window Estoque = new EstoqueTela();
            Estoque.Show();
            this.Close();
        }
        private void Relatorio_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
