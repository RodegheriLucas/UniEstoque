using System;
using System.Windows;
using System.Windows.Input;
using UniEstoque.Banco;
using UniEstoque.Classes;

namespace UniEstoque.LoginUIs
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void goToCadastro_Click(object sender, RoutedEventArgs e)
        {
            CadastroView telaCadastro = new CadastroView(); 
            telaCadastro.Show();
            this.Close();
        }
        private void KeyUpCpf(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                txtSenha.Focus();
        }

        private void KeyUpConfirmaSenha(object sender, System.Windows.Input.KeyEventArgs e)
        {
           if (e.Key.Equals(Key.Enter))
                btnEntrar.Focus();
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e) // se aqui tem catch, n'ao precisa ter no db. Arrumar isso depois
        {
            try
            {
                if (txtCpf.Text == "" || txtSenha.Password == "")
                    throw new Exception("Preencha todos os campos");
                else if (txtCpf.Text.Length < 11)
                    throw new Exception("O CPF deve conter 11 dígitos");
                else
                {
                    Funcionario funcionario = FuncionarioDB.getFuncionarioLogin(txtCpf.Text, txtSenha.Password);
                    MessageBox.Show("Login realizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
    }
}
