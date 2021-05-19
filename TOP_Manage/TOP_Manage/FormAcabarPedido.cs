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
    public partial class FrmAcabarPedido : Form
    {
        string nCamarero;

        public FrmAcabarPedido(string nomCamarero)
        {
            InitializeComponent();
            nCamarero = nomCamarero;
        }

        private void FrmAcabarPedido_Load(object sender, EventArgs e)
        {
            lblNomCamarero.Text = nCamarero;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmResumenPedido resumen = new FrmResumenPedido(lblNomCamarero.Text);
            resumen.ShowDialog();
            this.Hide();
        }
    }
}
