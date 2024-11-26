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
    public partial class FrmCategorias : Form
    {
        Categoria ct;

        public FrmCategorias()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            ct = new Categoria()
            {
                nome = pesquisa
            };
            dgvCategorias.DataSource = ct.Consultar();

        }
     
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;

            ct = new Categoria()
            {
                nome = txtNome.Text
            };
            ct.Incluir();

            limpaControles();
            carregarGrid("");
        }
        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }


    }
}
