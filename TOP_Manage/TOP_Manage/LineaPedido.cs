using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace TOP_Manage
{
    class LineaPedido
    {
        private Producto producto;
        private int cant;
        private int nPed;
        private int id;
        private bool hecha = false;

        public bool Hecha { get { return hecha; } }
        public int Cant { get { return cant; } }
        public int NPed { get { return nPed; } }
        public int Id { get { return id; } }
        public Producto Producto { get { return producto; } }

        public LineaPedido(int canti, int numPed, Producto prod)
        {
            cant = canti;
            nPed = numPed;
            producto = prod;
        }

        public LineaPedido(int canti, int numPed, int ident, Producto prod, bool hch)
        {
            cant = canti;
            nPed = numPed;
            id = ident;
            producto = prod;
            hecha = hch;
        }

        public static bool SetHecha(MySqlConnection conex,  int id)
        {
            string consulta = string.Format("UPDATE lineapedido SET hecha = true WHERE id = {0}", id);
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            bool hecho = false;
            try
            {
                hecho = Convert.ToBoolean(comando.ExecuteNonQuery());
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hecho;
        }

        public static List<LineaPedido> GetLineas(MySqlConnection conexion, int nPed)
        {
            string consulta = string.Format("SELECT * FROM lineaPedido INNER JOIN producto ON lineaPedido.producto = producto.id INNER JOIN tipo ON producto.tipo = tipo.id WHERE lineaPedido.pedido = {0};", nPed);
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            List<LineaPedido> lineas = new List<LineaPedido>();
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tipo tipo = new Tipo(reader.GetInt32(9), reader.GetString(10));
                        Producto producto = new Producto(reader.GetInt32(5), reader.GetString(7), reader.GetDouble(8), tipo);
                        lineas.Add(new LineaPedido(reader.GetInt32(3), nPed, reader.GetInt32(0), producto, reader.GetBoolean(4)));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lineas;
        }

        public static List<LineaPedido> GetLineasNoHechas(MySqlConnection conex)
        {
            string consulta = string.Format("SELECT * FROM lineaPedido INNER JOIN producto ON lineaPedido.producto = producto.id INNER JOIN tipo ON producto.tipo = tipo.id WHERE lineaPedido.hecha = false;");
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            List<LineaPedido> lineas = new List<LineaPedido>();
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tipo tipo = new Tipo(reader.GetInt32(9), reader.GetString(10));
                        Producto producto = new Producto(reader.GetInt32(5), reader.GetString(7), reader.GetDouble(8), tipo);
                        lineas.Add(new LineaPedido(reader.GetInt32(3), reader.GetInt32(1), reader.GetInt32(0), producto, reader.GetBoolean(4)));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lineas;
        }
    }
}
