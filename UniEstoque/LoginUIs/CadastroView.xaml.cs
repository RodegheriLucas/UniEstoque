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
using UniEstoque.Banco;

namespace UniEstoque.LoginUIs
{
    /// <summary>
    /// Interaction logic for CadastroView.xaml
    /// </summary>
    public partial class CadastroView : Window
    {
        public CadastroView()
        {
            FuncionarioDB.createTabelaFuncionario();
            InitializeComponent();
        }

        private void cadastrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void goToLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }

        private void keyUpNome(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                txtCPF.Focus();
        }
    }
}
