using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace crearClases
{
    class Producto
    {
        private int id;
        private string detalle;
        private double precio;
        private Tipo tipo;

        public int Id { get { return id; } }
        public string Detalle { get { return detalle; } }
        public double Precio { get { return precio; } }
        public Tipo Tipo { get { return tipo; } }

        public Producto(int ident, string detall, double prec, Tipo tip)
        {
            id = ident;
            detalle = detall;
            precio = prec;
            tipo = tip;
        }

        public static int GetId(string detalle, MySqlConnection conexion)
        {
            string consulta = string.Format("SELECT id FROM producto WHERE detalle='{0}'", detalle);
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            int id = 0;
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                id = reader.GetInt32(0);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return id;
        }
    }
}
