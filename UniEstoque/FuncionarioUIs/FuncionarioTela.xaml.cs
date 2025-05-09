using System;
using System.Windows;

namespace UniEstoque
{
    /// <summary>
    /// Interaction logic for FuncionarioTela.xaml
    /// </summary>
    public partial class FuncionarioTela : Window
    {
        public FuncionarioTela()
        {
            InitializeComponent();
        }
        private void Navbar_Click(object sender, RoutedEventArgs e)
        {
            if (NavbarFrame.Content == null)
            {
                Uri Navbar = new Uri("ControladoresUIs/Navbar.xaml", UriKind.Relative);
                this.NavbarFrame.Navigate(Navbar); ;
            }
            else
            {
                NavbarFrame.Content = null;
            }
        }
    }
}
