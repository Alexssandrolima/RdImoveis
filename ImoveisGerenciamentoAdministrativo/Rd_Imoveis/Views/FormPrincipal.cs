using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rd_Imoveis.Views.Clientes;
using Rd_Imoveis.Views.Imoveis;

namespace Rd_Imoveis.Views
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void toolStripButtonSair_Click(object sender, EventArgs e)
        {

        }

        private void clientesFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mostrarClientes = new FormClientes();
            DialogResult dialogResult = mostrarClientes.ShowDialog();
        }

        private void imoveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mostrarImoveis = new FormImoveis();
            DialogResult dialogResult = mostrarImoveis.ShowDialog();

        }

        private void vaziosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
