using System;
using System.Data;
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
            ItensDG.ItemsSource = ItensDB.ItemRepository.Itens;
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
                DataTable listItens = new DataTable();
                listItens = ItensDB.getItensTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            ItensDG.ItemsSource = ItensDB.ItemRepository.Itens;
        }

    }
}

