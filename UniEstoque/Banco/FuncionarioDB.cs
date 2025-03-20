using System;
using System.Data;
using System.Data.SQLite;
using System.Net;
using System.Xml.Serialization.Configuration;
using UniEstoque.Classes;

namespace UniEstoque.Banco
{
    public class FuncionarioDB
    {
        public static void createTabelaFuncionario()
        {
            try
            {
                using (var cmd = DatabaseInit.dbConnection().CreateCommand())
                {
                    cmd.CommandText = $@"CREATE TABLE IF NOT EXISTS Funcionario(
                                        id integer not null primary key,
                                        nome varchar(50),
                                        cpf varchar(11),
                                        senha char(60),
                                        cargo varchar(50)
                                        status int not null default(0))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable getFuncionarioTable()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = DatabaseInit.dbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Funcionario";
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
        public static DataTable getFuncionario(int id) // Fazer com que retorne um Funcionario 
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = DatabaseInit.dbConnection().CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM Funcionario WHERE id = {id}";
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
        public static void addFuncionario(Funcionario funcionario)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DatabaseInit.dbConnection()))
                {
                    if (funcionario.Id != null)
                    {
                        cmd.CommandText = "INSERT INTO Funcionario (id, nome, cpf, senha, status) VALUES (@id, @nome, @cpf, @senha, @cargo, @stauts)"; //Verificar se posso usar o $ e {}
                        cmd.Parameters.AddWithValue("@id", funcionario.Id);
                        cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                        cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                        cmd.Parameters.AddWithValue("@senha", funcionario.Senha);
                        cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                        cmd.Parameters.AddWithValue("@status", funcionario.Status);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void updateFuncionario(Funcionario funcionario)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DatabaseInit.dbConnection()))
                {
                    if (funcionario.Id != null)
                    {
                        cmd.CommandText = "UPDATE Funcionario SET nome= @nome, cpf= @cpf, senha= @senha";
                        cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                        cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                        cmd.Parameters.AddWithValue("@senha", funcionario.Senha);
                        cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void deleteFuncionario(int id) 
        {
            try
            {
                using (var cmd = new SQLiteCommand(DatabaseInit.dbConnection()))
                {
                    cmd.CommandText = "UPDATE Funcionario SET status= @status WHERE id= @id";
                    cmd.Parameters.AddWithValue("@status", -1); // Criar um enum dos status
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}