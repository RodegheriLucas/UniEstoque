using System.Windows;
using System.Windows.Controls;

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
            if (new DashboardTela().IsActive == true)
            {

            }
            else
            {
                Window Dashboard = new DashboardTela();
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
        private void Itens_Click(object sender, RoutedEventArgs e)
        {
            Window Itens = new ItemTela();
            Itens.Show();
        }
    }
}
