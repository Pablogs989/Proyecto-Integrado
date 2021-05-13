using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace TOP_Manage
{
    class CodigoDescuento
    {
        private string id;
        private int descuento;

        public string Id { get { return id; } }
        public int Descuento { get { return descuento; } }

        public CodigoDescuento(string id, int desc)
        {
            this.id = id;
            descuento = desc;
        }

        public static CodigoDescuento GetCodigoDescuento(string id, MySqlConnection conexion)
        {
            string consulta = string.Format("SELECT * FROM codigosdescuento WHERE idCodigo='{0}'", id);
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            CodigoDescuento codDesc = null;
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                codDesc = new CodigoDescuento(reader.GetString(0), reader.GetInt32(1));
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return codDesc;
        }

        public static bool ComprobarCodigoDescuento(string codigo, MySqlConnection conexion)
        {
            string consulta = string.Format("SELECT idCodigo FROM codigosdescuento WHERE idCodigo='{0}'", codigo);
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
