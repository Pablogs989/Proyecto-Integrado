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
    public partial class FrmPrincipal : Form
    {
        string nCamarero;
        public FrmPrincipal(string nomCamarero)
        {
            InitializeComponent();
            nCamarero = nomCamarero;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to back to start menu?",
                                     "Return confirmation",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();

            }
            else
            {

            }
        }



        private void btnCerrarPedido_Click(object sender, EventArgs e)
        {
            FrmCerrarPedido cerrarpedido = new FrmCerrarPedido(lblNomCamarero.Text);
            cerrarpedido.ShowDialog();
        }

        private void btnVerPedido_Click(object sender, EventArgs e)
        {
            FrmVerPedido verpedido = new FrmVerPedido(lblNomCamarero.Text);
            verpedido.ShowDialog();
            this.Hide();
        }

        private void btnComedor_Click(object sender, EventArgs e)
        {
            FrmComedor comedor = new FrmComedor(lblNomCamarero.Text);
            comedor.ShowDialog();
            this.Hide();
        }

        private void btnDomicilio_Click(object sender, EventArgs e)
        {
            FrmDomicilio domicilio = new FrmDomicilio(lblNomCamarero.Text);
            domicilio.ShowDialog();
            this.Hide();
        }

        private void btnParaLlevar_Click(object sender, EventArgs e)
        {
            FrmLlevar llevar = new FrmLlevar(lblNomCamarero.Text);
            llevar.ShowDialog();
            this.Hide();
        }

        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to go back?",
                                     "Return confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                this.Dispose();
                FrmContraseña contrasenya = new FrmContraseña();
                contrasenya.ShowDialog();
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblNomCamarero.Text = nCamarero;
        }
    }
}
