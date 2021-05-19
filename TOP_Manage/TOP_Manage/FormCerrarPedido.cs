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
    public partial class FrmCerrarPedido : Form
    {
        string nCamarero;

        public FrmCerrarPedido(string nomCamarero)
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

        private void FrmCerrarPedido_Load(object sender, EventArgs e)
        {
            lblNomCamarero.Text = nCamarero;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure that you want to close this App?",
                                                 "Confirm Delete!",
                                                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (confirmResult == DialogResult.Yes)
            {

            }
        }
    }
}
