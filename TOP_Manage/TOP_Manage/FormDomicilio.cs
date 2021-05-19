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
    public partial class FrmDomicilio : Form
    {
        string nCamarero;
        public FrmDomicilio(string nomCamarero)
        {
            InitializeComponent();
            nCamarero = nomCamarero;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            FrmPrincipal principal = new FrmPrincipal(lblNomCamarero.Text);
            principal.ShowDialog();
            this.Hide();
        }

        private void FrmDomicilio_Load(object sender, EventArgs e)
        {
            lblNomCamarero.Text = nCamarero;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            FrmProductos pedido = new FrmProductos(lblNomCamarero.Text);
            pedido.ShowDialog();
            this.Dispose();
        }
    }
}
