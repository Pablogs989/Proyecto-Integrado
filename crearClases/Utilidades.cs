using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace crearClases
{
    static class Utilidades
    {
        public static bool ValidaContra(MySqlConnection conexion, string nombre, string passwd)
        {
            string consulta = string.Format("SELECT nombre, passwd FROM empleado;");
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            bool valida = false;
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == nombre && reader.GetString(1) == passwd)
                        {
                            valida = true;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valida;
        }
    }
}