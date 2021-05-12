using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace crearClases
{
    class Cliente
    {
        private string tlf;
        private string nombre;
        private string calle;
        private string bloque = null;
        private string escalera = null;
        private string portal;
        private string piso = null;
        private string puerta = null;

        public string Tlf { get { return tlf; } }
        public string Nombre { get { return nombre; } }
        public string Calle { get { return calle; } }
        public string Portal { get { return portal; } }
        public string Puerta { get { return puerta; } set { puerta = value; } }
        public string Bloque { get { return bloque; } set { bloque = value; } }
        public string Escalera { get { return escalera; } set { escalera = value; } }
        public string Piso { get { return piso; } set { piso = value; } }

        public Cliente() 
        {
            
        }

        public Cliente(string tlf, string nombre, string calle, string portal)
        {
            this.tlf = tlf;
            this.nombre = nombre;
            this.calle = calle;
            this.portal = portal;
        }

        public static Cliente GetCliente(string tlf, MySqlConnection conexion)
        {
            string consulta = string.Format("SELECT * FROM clientes WHERE tlf = '{0}'", tlf);
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            Cliente cliente = null;
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                cliente = new Cliente(tlf, reader.GetString(1), reader.GetString(2), reader.GetString(5));
                if (!reader.IsDBNull(3))
                {
                    cliente.Bloque = reader.GetString(3);
                }
                if (!reader.IsDBNull(4))
                {
                    cliente.Escalera = reader.GetString(4);
                }
                if (!reader.IsDBNull(6))
                {
                    cliente.Piso = reader.GetString(6);
                }
                if (!reader.IsDBNull(7))
                {
                    cliente.Puerta = reader.GetString(7);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cliente;
        }

        public static bool SonClientesIguales(Cliente c1, Cliente c2)
        {
            bool iguales = true;
            if (c1.Tlf != c2.Tlf)
            {
                iguales = false;
            }
            if (c1.Nombre != c2.Nombre)
            {
                iguales = false;
            }
            if (c1.Calle != c2.Calle)
            {
                iguales = false;
            }
            if (c1.Bloque != c2.Bloque)
            {
                iguales = false;
            }
            if (c1.Escalera != c2.Escalera)
            {
                iguales = false;
            }
            if (c1.Portal != c2.Portal)
            {
                iguales = false;
            }
            if (c1.Piso != c2.Piso)
            {
                iguales = false;
            }
            if (c1.Puerta != c2.Puerta)
            {
                iguales = false;
            }
            return iguales;
        }

        public static void Update(MySqlConnection conexion, Cliente cli)
        {
            string consulta = string.Format("UPDATE clientes SET tlf = '{0}', nombre = '{1}', calle = '{2}', bloque = '{3}', escalera = '{4}', portal = '{5}', piso = '{6}', puerta = '{7}' WHERE tlf = '{8}'", cli.Tlf, cli.Nombre, cli.Calle, cli.Bloque, cli.Escalera, cli.Portal, cli.Piso, cli.Puerta, cli.Tlf);
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
