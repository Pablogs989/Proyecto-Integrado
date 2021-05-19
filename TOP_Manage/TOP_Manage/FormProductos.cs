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
    public partial class FrmProductos : Form
    {
        string nCamarero;
        public FrmProductos(string nomCamarero)
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

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            lblNomCamarero.Text = nCamarero;
        }

        private void btnPizza_Click(object sender, EventArgs e)
        {
            FrmPizza pizza = new FrmPizza(lblNomCamarero.Text);
            pizza.ShowDialog();
            this.Hide();

        }

        private void btnStarter_Click(object sender, EventArgs e)
        {
            FrmEntrante entrante = new FrmEntrante(lblNomCamarero.Text);
            entrante.ShowDialog();
            this.Hide();
        }

        private void btnDessert_Click(object sender, EventArgs e)
        {
            FrmPostre postre = new FrmPostre(lblNomCamarero.Text);
            postre.ShowDialog();
            this.Hide();
        }

        private void btnDrink_Click(object sender, EventArgs e)
        {
            FrmBebida bebida = new FrmBebida(lblNomCamarero.Text);
            bebida.ShowDialog();
            this.Hide();
        }
    }
}
