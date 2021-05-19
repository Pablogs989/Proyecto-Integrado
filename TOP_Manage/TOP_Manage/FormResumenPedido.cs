using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOP_Manage
{
    public partial class FrmResumenPedido : Form
    {
        string nCamarero;
        public FrmResumenPedido(string nomCamarero)
        {
            InitializeComponent();
            nCamarero = nomCamarero;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            FrmVerPedido verPedido = new FrmVerPedido(lblNomCamarero.Text);
            verPedido.ShowDialog();
            this.Hide();
        }

        private void FrmResumenPedido_Load(object sender, EventArgs e)
        {
            lblNomCamarero.Text = nCamarero;
        }
    }
}
