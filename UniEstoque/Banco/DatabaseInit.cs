using System.Data.SQLite;

namespace UniEstoque.Banco
{
    public class DatabaseInit
    {
        private static SQLiteConnection sqliteConnection;

        public DatabaseInit() { }

        public static SQLiteConnection dbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=c\\dados\\UniEstoqueDB.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void createBancoSqlite()
        {
            try
            {
                SQLiteConnection.CreateFile(@"f:\dados\UniEstoqueDB.sqlite");
            }
            catch
            {
                throw;
            }
        }
    }
}
