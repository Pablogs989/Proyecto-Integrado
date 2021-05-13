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
    public partial class FrmContraseña : Form
    {
        public FrmContraseña()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ConexionBD conex = new ConexionBD();
            conex.AbrirConexion();
            if (Utilidades.ValidaUsuario(conex.Conexion, mtxtUsuario.Text, mtxtContrasenya.Text))
            {

                if (Empleado.GetTipo(mtxtUsuario.Text, conex.Conexion) == 0)
                {
                    FrmPrincipal principal = new FrmPrincipal(mtxtUsuario.Text);
                    principal.ShowDialog();
                    this.Hide();
                }
                else if (Empleado.GetTipo(mtxtUsuario.Text, conex.Conexion) == 1)
                {
                    FrmCocina cocina = new FrmCocina();
                    cocina.ShowDialog();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("WRONG USER OR PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conex.CerrarConexion();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure that you want to close this App?",
                                     "Confirm Delete!",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FrmContraseña_Load(object sender, EventArgs e)
        {
            mtxtContrasenya.UseSystemPasswordChar = true;
        }
    }
}
