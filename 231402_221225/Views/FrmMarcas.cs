using _231402_221225.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _231402_221225.Views
{
    public partial class FrmMarcas : Form
    {
        Marca m;
        public FrmMarcas()
        {
            InitializeComponent();
        }
        void limpaControles()
        {
            txtID.Clear();
            txtMarca.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            m = new Marca()
            {
                nome = pesquisa
            };
            dgvMarca.DataSource = m.Consultar();

        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir cidade?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m = new Marca()
                {
                    id = int.Parse(txtID.Text)
                };
                m.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == String.Empty) return;

            m = new Marca()
            {
                nome = txtMarca.Text
            }; 
            m.Incluir();

            limpaControles();
            carregarGrid("");

        }

        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarca.Rows.Count > 0)
            {
                txtID.Text = dgvMarca.CurrentRow.Cells["id"].Value.ToString();
                txtMarca.Text = dgvMarca.CurrentRow.Cells["nome"].Value.ToString();
            }
        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCidades_Load_1(object sender, EventArgs e)
        {

        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click_1(object sender, EventArgs e)
        {
            if (txtMarca.Text == String.Empty) return;

            m = new Marca()
            {
                nome = txtMarca.Text
            };
            m.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            m = new Marca()
            {
                id = int.Parse(txtID.Text),
                nome = txtMarca.Text
            };
            m.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
