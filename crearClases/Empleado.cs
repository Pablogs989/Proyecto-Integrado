using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace crearClases
{
    class Empleado
    {
        private string nombre;
        private string passwd;
        private int tipoEmpleado;

        public string Nombre { get { return nombre; } }
        public string Passwd { get { return passwd; } }
        public int TipoEmpleado { get { return tipoEmpleado; } }

        public Empleado(string nom, string pass, int tipoEmp)
        {
            nombre = nom;
            passwd = pass;
            tipoEmpleado = tipoEmp;
        }

        public static int GetTipo(string nombre, MySqlConnection conexion)
        {
            string consulta = string.Format("SELECT tipoEmpleado FROM empleado WHERE nombre = '{0}'", nombre);
            int tipo = -1;
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                tipo = reader.GetInt32(0);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tipo;
        }
    }
}
