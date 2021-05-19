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
    public partial class FrmPostre : Form
    {
        string nCamarero;
        public FrmPostre(string nomCamarero)
        {
            InitializeComponent();
            nCamarero = nomCamarero;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            FrmProductos productos = new FrmProductos(lblNomCamarero.Text);
            productos.ShowDialog();
            this.Hide();
        }

        private void FrmPostre_Load(object sender, EventArgs e)
        {
            lblNomCamarero.Text = nCamarero;
        }
    }
}
