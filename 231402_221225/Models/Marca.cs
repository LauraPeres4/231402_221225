using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace _231402_221225.Models
{
    public class Marca
    {
        public int id { get; set; }
        public string nome { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("INSERT INTO Marca (nome) VALUES (@nome)", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
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
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("Update Marca set nome = @nome where id = @id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@nome", nome);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
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
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("Delete from Marca where id = @id", Banco.Conexao);

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

                Banco.Comando = new MySqlCommand("SELECT * from Marca where nome like @nome " + " order by nome", Banco.Conexao);

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

