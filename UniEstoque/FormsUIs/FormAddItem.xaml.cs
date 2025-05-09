using System;
using System.Windows;
using UniEstoque.Classes;

namespace UniEstoque.FormsUIs
{
    /// <summary>
    /// Interaction logic for FormAddItem.xaml
    /// </summary>
    public partial class FormAddItem : Window
    {
        public FormAddItem()
        {
            InitializeComponent();
        }
        public void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string NameBox = ItemNameBox.Text;
                double PriceBox;
                string SizeBox = ItemSizeBox.Text;
                if (!double.TryParse(ItemPriceBox.Text, out PriceBox))
                {
                    MessageBox.Show("Preço inválido.");
                    return;
                }
                string SupplierBox = ItemSupplierBox.Text;
                Itens novoItem = new Itens()
                {
                    Item = NameBox,
                    Tamanho = SizeBox,
                    Valor = PriceBox,
                    Fornecedor = SupplierBox,
                };
                Banco.ItensDB.ItemRepository.Itens.Add(novoItem);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao incluir o item: " + ex.Message);
            }
            Close();
        }
    }
}
