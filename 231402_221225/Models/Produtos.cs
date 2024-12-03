using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _231402_221225.Models
{
        public class Produto
        {
            public int id { get; set; }
            public string descricao { get; set; }
            public int idCategoria { get; set; }
            public int idMarca { get; set; }
            public double valor { get; set; }
            public double estoque { get; set; }
            public string foto { get; set; }

            public void Incluir()
            {
                try
                {
                    Banco.Conexao.Open();
                    Banco.Comando = new MySqlCommand
                        ("INSERT INTO produtos (descricao, idCategoria, idMarca, valorVenda, estoque, foto) " +
                        "VALUES (@descricao, @idCategoria, @idMarca, @valorVenda, @estoque, @foto)", Banco.Conexao);
                    Banco.Comando.Parameters.AddWithValue("@descricao", descricao);
                    Banco.Comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                    Banco.Comando.Parameters.AddWithValue("@idMarca", idMarca);
                    Banco.Comando.Parameters.AddWithValue("@valorVenda", valor);
                    Banco.Comando.Parameters.AddWithValue("@estoque", estoque);
                    Banco.Comando.Parameters.AddWithValue("@foto", foto);
                    Banco.Comando.ExecuteNonQuery();
                    Banco.Conexao.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public void Alterar()
            {
                try
                {
                    Banco.Conexao.Open();
                    Banco.Comando = new MySqlCommand
                        ("UPDATE Produtos SET descricao = @descricao, idCategoria = @idCategoria, idMarca = @idMarca, " +
                        "valorVenda = @valorVenda, estoque = @estoque, foto = @foto where id =@id", Banco.Conexao);
                    Banco.Comando.Parameters.AddWithValue("@descricao", descricao);
                    Banco.Comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                    Banco.Comando.Parameters.AddWithValue("@idMarca", idMarca);
                    Banco.Comando.Parameters.AddWithValue("@valorVenda", valor);
                    Banco.Comando.Parameters.AddWithValue("@estoque", estoque);
                    Banco.Comando.Parameters.AddWithValue("@foto", foto);
                    Banco.Comando.Parameters.AddWithValue("@id", id);
                    Banco.Comando.ExecuteNonQuery();
                    Banco.Conexao.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public void Excluir()
            {
                try
                {
                    Banco.Conexao.Open();
                    Banco.Comando = new MySqlCommand("delete from produtos where id = @id", Banco.Conexao);
                    Banco.Comando.Parameters.AddWithValue("@id", id);
                    Banco.Comando.ExecuteNonQuery();
                    Banco.Conexao.Close();
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
                    Banco.Comando = new MySqlCommand
                        ("SELECT p.*, m.marca, ct.categoria FROM " +
                        "Produtos p inner join Marcas m on (m.id = p.idMarca) " +
                        "inner join Categorias ct on (c.id = p.idCategoria) " +
                        "where p.descricao like @descricao order by p.descricao", Banco.Conexao);
                    Banco.Comando.Parameters.AddWithValue("@descricao", descricao + "%");
                    Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                    Banco.datTabela = new DataTable();
                    Banco.Adaptador.Fill(Banco.datTabela);
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
