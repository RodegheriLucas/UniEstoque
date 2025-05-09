using System;
using System.Windows;
using System.Windows.Controls;

namespace UniEstoque
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DashboardTela : Window
    {
        public DashboardTela()
        {
            InitializeComponent();
        }
        public object Header { get; set; }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Navbar_Click(object sender, RoutedEventArgs e)
        {
            if (NavbarFrame.Content == null)
            {
                Uri Navbar = new Uri("ControladoresUIs/Navbar.xaml", UriKind.Relative);
                this.NavbarFrame.Navigate(Navbar);
            }
            else
            {
                NavbarFrame.Content = null;
            }
        }
    }
}
