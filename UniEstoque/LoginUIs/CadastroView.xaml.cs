using System;
using System.Windows;
using System.Windows.Input;
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


        private void goToLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }

        private void keyUpNome(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                txtCpf.Focus();
        }

        private void KeyUpCpf(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                txtSenha.Focus();
        }

        private void keyUpSenha(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                txtConfirmarSenha.Focus();
        }

        private void KeyUpConfirmaSenha(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                btnConfirmar.Focus();
        }

        private void cadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtNome.Text.Equals("") || txtCpf.Text.Equals("") || txtSenha.Password.Equals("") || txtConfirmarSenha.Password.Equals(""))
                    throw new Exception("Preencha todos os campos!");
                else if (txtCpf.Text.Length < 11)
                    throw new Exception("O CPF deve conter 11 dígitos!");
                else if (txtSenha.Password != txtConfirmarSenha.Password)
                    throw new Exception("As senhas não conferem!");
                else
                {
                    FuncionarioDB.addFuncionario(txtNome.Text, txtCpf.Text, txtSenha.Password);
                    LoginView loginView = new LoginView();
                    loginView.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
