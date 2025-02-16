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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DashboardTela : Window
    {
        public int BtnPos { get; set; }
        public string BtnAlign { get; set; }

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
                Uri Navbar = new Uri("Navbar.xaml", UriKind.Relative);
                this.NavbarFrame.Navigate(Navbar);;
            }
            else
            {                
                NavbarFrame.Content = null;                
            }
        }
    }
}
