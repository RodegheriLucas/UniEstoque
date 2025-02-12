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
    /// Interaction logic for EstoqueTela.xaml
    /// </summary>
    public partial class EstoqueTela : Window
    {
        public EstoqueTela()
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

        }
        private void Relatorio_Click(object sender, RoutedEventArgs e)
        {
            Window Relatorio = new RelatorioTela();
            Relatorio.Show();
            this.Close();
        }
    }
}
