using System.Windows;
using System;
using System.Data;
using static UniEstoque.Banco.DatabaseInit;

namespace UniEstoque
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void app_Startup(object sender, StartupEventArgs e)
        {
            createBancoSqlite();
        }
    }
}
