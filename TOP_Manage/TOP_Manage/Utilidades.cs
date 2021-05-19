using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace TOP_Manage
{
    static class Utilidades
    {
        public static bool ValidaUsuario(MySqlConnection conexion, string usuario, string passwd)
        {
            string consulta = string.Format("SELECT nombre FROM empleado WHERE passwd = '{0}';", passwd);
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            bool valida = false;
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == usuario)
                        {
                            valida = true;
                        }
                    }
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valida;
        }
    }
}