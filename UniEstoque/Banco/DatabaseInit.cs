using System;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace UniEstoque.Banco
{
    public class DatabaseInit
    {
        private static SQLiteConnection sqliteConnection;

        public DatabaseInit() { }

        public static SQLiteConnection dbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=C:\\Users\\lucas\\source\\repos\\UniEstoque\\UniEstoque\\dados\\UniEstoqueDB.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void createBancoSqlite()
        {
            try
            {
                string dbFilePath = @"C:\Users\lucas\source\repos\UniEstoque\UniEstoque\dados\UniEstoqueDB.sqlite";
                if (!File.Exists(dbFilePath))
                {
                    SQLiteConnection.CreateFile(@"C:\Users\lucas\source\repos\UniEstoque\UniEstoque\dados\UniEstoqueDB.sqlite"); // PADRONIZAR UM CAMINHO PADRÃO, DEVEMOS MARCAR UMA REUNIÃO PAR DEFINIR ISSO
                    MessageBox.Show("Seu banco foi criado com sucesso");
                }
                    
            }
            catch
            {
                MessageBox.Show("Erro ocorreu durante a criação do banco", "ERROR", MessageBoxButton.OK);
            }
        }

    }
}
