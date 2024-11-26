﻿using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using System.Security.Cryptography.X509Certificates;

namespace _231402_221225.Models
{
    public class Cliente
    {
        public int id { get; set; }

        public string nome { get; set; }
        
        public int idCidade { get; set; }

        public DateTime dataNasc {  get; set; }

        public double renda { get; set; }

        public string cpf { get; set; }

        public string foto { get; set; }

        public bool venda { get; set; }

    public void Incluir()
    {
        try
        {
            Banco.Conexao.Open();
            Banco.Comando = new MySqlCommand
                ("INSERT INTO clientes (nome, idCidade, dataNasc, renda, cpf, foto, venda) " +
                "VALUES (@nome, @idCidade, @dataNasc, @renda, @cpf, @foto, @venda)", Banco.Conexao);
            Banco.Comando.Parameters.AddWithValue("@nome", nome);
            Banco.Comando.Parameters.AddWithValue("@idCidade", idCidade);
            Banco.Comando.Parameters.AddWithValue("@dataNasc", dataNasc);
            Banco.Comando.Parameters.AddWithValue("@renda", renda);
            Banco.Comando.Parameters.AddWithValue("@cpf", cpf);
            Banco.Comando.Parameters.AddWithValue("@foto", foto);
            Banco.Comando.Parameters.AddWithValue("@nome", nome);
            Banco.Comando.Parameters.AddWithValue("@venda", venda);
            Banco.Comando.ExecuteNonQuery();
            Banco.Conexao.Close();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
    public void Alterar()
    {
            try
            {
                Banco.Conexao.Open();
                Banco.Comando = new MySqlCommand
                    ("UPDATE cliente SET nome = @nome, idCidade = @idCidade, dataNasc, = @dataNasc, " +
                    "renda = @renda, cpf = @cpf, foto = @foto, venda = @venda where id = @id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@idCidade", idCidade);
                Banco.Comando.Parameters.AddWithValue("@dataNasc", dataNasc);
                Banco.Comando.Parameters.AddWithValue("@renda", renda);
                Banco.Comando.Parameters.AddWithValue("@cpf", cpf);
                Banco.Comando.Parameters.AddWithValue("@foto", foto);
                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@venda", venda);
                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();
            }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        }
        public void Excluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("Delete from Clientes where id = @id", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@id", id);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("SELECT * from Clientes where nome like @nome " + " order by nome", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", nome + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                Banco.FecharConexao();
                return Banco.datTabela;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
