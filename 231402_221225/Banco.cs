﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;

namespace _231402_221225
{
    public class Banco
    {
        public static MySqlConnection Conexao;

        public static MySqlCommand Comando;

        public static MySqlDataAdapter Adaptador;

        public static DataTable datTabela;

        public static void AbrirConexao()
        {

            try
            {
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");

                Conexao.Open();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FecharConexao()
        {
            try
            {
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                AbrirConexao();

                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS Projeto;"+"USE Projeto", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("Use Projeto;" + "CREATE TABLE IF NOT EXISTS Cidade(id integer auto_increment primary key, nome char(40),uf char (02));CREATE TABLE IF NOT EXISTS Marca(id integer auto_increment primary key,nome char(40));CREATE TABLE IF NOT EXISTS Categoria(id integer auto_increment primary key, nome char(40)); CREATE TABLE IF NOT EXISTS Clientes(id integer auto_increment primary key, nome char(40), idCidade integer, dataNasc date, renda decimal(10,2), cpf char(14), foto varchar(100), venda boolean);CREATE TABLE IF NOT EXISTS Produtos(id integer auto_increment primary key, descricao varchar(2000), idCategoria integer, idMarca integer, estoque decimal(10,3), valorVenda decimal(10, 2), foto varchar(100))",
                                    Conexao);
                Comando.ExecuteNonQuery();

                
                  

                FecharConexao();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Banco.CriarBanco();
        }
    }
}
