using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using UniEstoque.Classes;

namespace UniEstoque.Banco
{
    public class ItensDB
    {
        public static void createTableItens()
        {
            try
            {
                using (var cmd = DatabaseInit.dbConnection().CreateCommand())
                {
                    cmd.CommandText = $@"CREATE TABLE IF NOT EXISTS Itens(
                                        id integer not null primary key, 
                                        Item varchar(20), 
                                        Tamanho varchar(50),
                                        Valor double not null default (0.0),
                                        Fornecedor varchar(50),
                                        Status int not null default (0))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable getItensTable()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DatabaseInit.dbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Itens";
                    da = new SQLiteDataAdapter(cmd.CommandText, DatabaseInit.dbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable getItens(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DatabaseInit.dbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Itens Where Id=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, DatabaseInit.dbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void addItem(Itens item)
        {
            try
            {
                using (var cmd = DatabaseInit.dbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Itens (id, item, tamanho) values(@id, @Item, @Tamanho, @Valor, @Fornecedor, @Status)";
                    cmd.Parameters.AddWithValue("@id", item.Id);
                    cmd.Parameters.AddWithValue("@Item", item.Item);
                    cmd.Parameters.AddWithValue("@Tamanho", item.Tamanho);
                    cmd.Parameters.AddWithValue("@Valor", item.Valor);
                    cmd.Parameters.AddWithValue("@Fornecedor", item.Fornecedor);
                    cmd.Parameters.AddWithValue("@Status", item.Status);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void updateItem(Itens item)
        {
            try
            {
                using (var cmd = DatabaseInit.dbConnection().CreateCommand())
                {
                    if (item.PersistId != null)
                    {
                        cmd.CommandText = "UPDATE Itens SET Item=@item, Tamanho=@tamanho WHERE Id=@id";
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Item", item.Item);
                        cmd.Parameters.AddWithValue("@Tamanho", item.Tamanho);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void deleteItem(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DatabaseInit.dbConnection()))
                {
                    cmd.CommandText = "UPDATE Funcionario SET status = @status WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@Status", -1);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static class ItemRepository
        {
            public static List<Itens> Itens { get; set; } = new List<Itens>();
        }
    }
}
