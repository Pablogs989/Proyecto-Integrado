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
    public partial class FrmCocina : Form
    {
        public FrmCocina()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            FrmContraseña contrasenya = new FrmContraseña();
            contrasenya.ShowDialog();
            this.Hide();
        }
    }
}
