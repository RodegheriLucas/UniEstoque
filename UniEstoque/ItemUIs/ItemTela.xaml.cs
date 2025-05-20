using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows;
using UniEstoque.Banco;
using UniEstoque.FormsUIs;

namespace UniEstoque
{
    /// <summary>
    /// Interaction logic for ItemTela.xaml
    /// </summary>
    public partial class ItemTela : Window
    {
        public ItemTela()
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
        public void AdicionarItem_Click(object sender, RoutedEventArgs e)
        {
            Window CreateItemForm = new FormAddItem();
            CreateItemForm.Show();
        }

        public void ExibirItens()
        {
            try
            {
                DataTable itensTable = ItensDB.getItensTable();
                dataGridItens.ItemsSource = itensTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

    }
}

