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
            sqliteConnection = new SQLiteConnection("Data Source=c:\\dados\\UniEstoqueDB.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void createBancoSqlite()
        {
            try
            {
                string dbFilePath = @"f:\dados\UniEstoqueDB.sqlite";
                if (!File.Exists(dbFilePath))
                    SQLiteConnection.CreateFile(@"f:\dados\UniEstoqueDB.sqlite"); // PADRONIZAR UM CAMINHO PADRÃO, DEVEMOS MARCAR UMA REUNIÃO PAR DEFINIR ISSO
            }
            catch
            {
                MessageBox.Show("Erro ocorreu durante a criação do banco", "ERROR", MessageBoxButton.OK);
            }
        }
    }
}
