using System.Windows;

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
        private void entrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void goToCadastro_Click(object sender, RoutedEventArgs e)
        {
            CadastroView telaCadastro = new CadastroView(); 
            telaCadastro.Show();
            this.Close();
        }

    }
}
