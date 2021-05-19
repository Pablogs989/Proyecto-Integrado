using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace crearClases
{
    class Tipo
    {
        private int id;
        private string descripcion;
        
        public int Id { get { return id; } }
        public string Descripcion { get { return descripcion; } }

        public Tipo(int id, string desc)
        {
            this.id = id;
            descripcion = desc;
        }

        public static Tipo GetTipo(MySqlConnection conexion, int id)
        {
            string consulta = string.Format("SELECT * FROM tipo WHERE id = ", id);
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            Tipo tipo = null;
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    tipo = new Tipo(id, reader.GetString(1));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tipo;
        }
    }
}
