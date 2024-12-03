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
    public partial class FrmProdutos : Form
    {
        Produto p;
        Categoria ct;
        Marca m;
        public FrmProdutos()
        {
            InitializeComponent();
        }
        void limpaControles()
        {
            txtID.Clear();
            txtDesc.Clear();
            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            txtEst.Clear();
            txtVenda.Clear();
            picFoto.ImageLocation = "";
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {
                txtID.Text = dgvProdutos.CurrentRow.Cells["id"].Value.ToString();
                txtDesc.Text = dgvProdutos.CurrentRow.Cells["descricao"].Value.ToString();
                cboCategoria.Text = dgvProdutos.CurrentRow.Cells["categoria"].Value.ToString();
                cboMarca.Text = dgvProdutos.CurrentRow.Cells["marca"].Value.ToString();
                txtEst.Text = dgvProdutos.CurrentRow.Cells["estoque"].Value.ToString();
                txtVenda.Text = dgvProdutos.CurrentRow.Cells["valor"].Value.ToString();
                picFoto.ImageLocation = dgvProdutos.CurrentRow.Cells["foto"].Value.ToString();
            }
        }
        void carregarGrid(string pesquisa)
        {
            p = new Produto()
            {
                descricao = pesquisa
            };
            dgvProdutos.DataSource = p.Consultar();

        }
        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            // Cria um objeto do tipo categoria e marca
            // E alimenta o comboBox
            ct = new Categoria();
            cboCategoria.DataSource = ct.Consultar();
            cboCategoria.DisplayMember = "categoria";
            cboCategoria.ValueMember = "id";

            m = new Marca();
            cboMarca.DataSource = m.Consultar();
            cboMarca.DisplayMember = "marca";
            cboMarca.ValueMember = "id";

            limpaControles();
            carregarGrid("");

            // Deixa invisível colunas do Grid
            dgvProdutos.Columns["idCategoria"].Visible = false;
            dgvProdutos.Columns["idMarca"].Visible = false;
            dgvProdutos.Columns["foto"].Visible = false;
            limpaControles();
            carregarGrid("");
        }
        private void btnInserir_Click(object sender, EventArgs e)
        {

            if (txtDesc.Text == "") return;

            p = new Produto()
            {
                descricao = txtDesc.Text,
                idCategoria = (int)cboCategoria.SelectedValue,
                idMarca = (int)cboMarca.SelectedValue,
                valor = double.Parse(txtVenda.Text),
                estoque = double.Parse(txtEst.Text),
                foto = picFoto.ImageLocation,
            };
            p.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;
            p = new Produto()
            {
                id = int.Parse(txtID.Text),
                descricao = txtDesc.Text,
                idCategoria = (int)cboCategoria.SelectedValue,
                idMarca = (int)cboMarca.SelectedValue,
                valor = double.Parse(txtVenda.Text),
                estoque = double.Parse(txtEst.Text),
                foto = picFoto.ImageLocation,
            };
            p.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoria.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCategoria.SelectedItem;
            }
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMarca.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboMarca.SelectedItem;
            }
        }
    }
}
