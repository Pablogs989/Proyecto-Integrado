using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace crearClases
{
    static class Mesa
    {
        public static bool ExisteMesa(MySqlConnection conexion, int nMesa)
        {
            string consulta = string.Format("SELECT * FROM mesas WHERE nMesa = {0}", nMesa);
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            bool existe = false;
            try
            {
                existe = Convert.ToBoolean(comando.ExecuteNonQuery());
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return existe;
        }
    }
}
