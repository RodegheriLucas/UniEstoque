﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Net.NetworkInformation;
using UniEstoque.Classes;
using UniEstoque.Util;

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
                                        id integer not null primary key autoincrement,
                                        nome varchar(50),
                                        cpf varchar(11),
                                        senha char(60),
                                        cargo varchar(50),
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

        /// <summary>
        /// Este método irá verificar o login do funcionário, e retornará um funcionario com os dados dele.
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static Funcionario getFuncionarioLogin(string cpf, string senha)
        {
            using (var cmd = DatabaseInit.dbConnection().CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Funcionario WHERE cpf = @cpf";
                cmd.Parameters.AddWithValue("@cpf", cpf);
                SQLiteDataReader dr = cmd.ExecuteReader();
                Funcionario funcionario = new Funcionario();
                if (dr.Read())
                {
                    string senhaBanco = dr.GetString(3);
                    string senhaInformada = PasswordHelper.HashPassword(senha);

                    if (senhaBanco.Equals(senhaInformada))
                    {
                        funcionario.Id = dr.GetInt32(0);
                        funcionario.Nome = dr.GetString(1);
                        funcionario.Cpf = dr.GetString(2);
                        funcionario.Senha = dr.GetString(3);
                        funcionario.Status = (Funcionario.StatusEnum)dr.GetInt32(5);
                        return funcionario;
                    }
                    else
                        throw new Exception("Login incorreto"); // Melhorar esta mensagem, ta paia
                }
                else
                {
                    throw new Exception("Impossível de gerar Funcionário");
                }
            }
        }

        public static void addFuncionario(string nome, string cpf, string senha)
        {
            try
            {
                Funcionario funcionario = new Funcionario(); // é necessário criar um novo funcionario para pegar o id
                funcionario.Nome = nome;
                funcionario.Cpf = cpf;
                funcionario.Senha = senha;
                using (var cmd = DatabaseInit.dbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Funcionario (nome, cpf, senha, cargo, status) VALUES (@nome, @cpf, @senha, @cargo, @status)"; //Verificar se posso usar o $ e {}
                    cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                    cmd.Parameters.AddWithValue("@senha", funcionario.Senha);
                    cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                    cmd.Parameters.AddWithValue("@status", funcionario.Status);
                    cmd.ExecuteNonQuery();
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