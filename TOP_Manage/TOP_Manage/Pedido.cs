using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace TOP_Manage
{
    class Pedido
    {
        private int numPedido, mesa;
        private string nombre = null;
        private CodigoDescuento codDesc = null;
        private Cliente cliente = null;
        private DateTime fecha;
        private double precio;
        private bool cancelado = false, pagado = false;
        private string nomCamarero;
        List<LineaPedido> lineasPedido;

        public int NumPedido { get { return numPedido; } }
        public string NomCamarero { get { return nomCamarero; } }
        public CodigoDescuento CodDesc { get { return codDesc; } set { codDesc = value; } }
        public DateTime Fecha { get { return fecha; } }
        public double Precio { get { return precio; } }
        public bool Cancelado { get { return cancelado; } }
        public bool Pagado { get { return pagado; } }
        public List<LineaPedido> LineasPedido { get { return lineasPedido; } }
        public Cliente Cliente { get { return cliente; } set { cliente = value; } }
        public int Mesa { get { return mesa; } set { mesa = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }

        public Pedido(string nomCam, List<LineaPedido> lineas)
        {
            nomCamarero = nomCam;
            fecha = DateTime.Now;
            lineasPedido = lineas;
            precio = GetPrecio(this);
        }

        public Pedido(int nPed, double prec, DateTime fech, bool canc, string nomCam, List<LineaPedido> lineasPed, bool pagdo)
        {
            numPedido = nPed;
            precio = prec;
            fecha = fech;
            cancelado = canc;
            nomCamarero = nomCam;            
            lineasPedido = lineasPed;
            pagado = pagdo;
        }

        public static void SetPagado(MySqlConnection conexion, int nPed)
        {
            string consulta = "UPDATE pedidos SET pagado = true WHERE numPedido = " + nPed;
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

        public static void SetCancelado(MySqlConnection conexion, int nPed)
        {
            string consulta = "UPDATE pedidos SET cancelado = true WHERE numPedido = " + nPed;
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


        public static Pedido GetPedido(MySqlConnection conexion, int nPed)
        {
            string consulta = string.Format("SELECT * FROM pedidos WHERE numPedido = {0}", nPed);
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            Pedido pedido = null;
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    pedido = new Pedido(reader.GetInt32(0), reader.GetDouble(6), reader.GetDateTime(2), reader.GetBoolean(8), reader.GetString(1), LineaPedido.GetLineas(conexion, nPed), reader.GetBoolean(9));
                    if (!reader.IsDBNull(3))
                    {
                        pedido.Mesa = reader.GetInt32(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        pedido.Cliente = Cliente.GetCliente(reader.GetString(4), conexion);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        pedido.Nombre = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        pedido.codDesc = CodigoDescuento.GetCodigoDescuento(reader.GetString(7), conexion);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pedido;
        }

        public static int GetUltNumPed(MySqlConnection conexion)
        {
            string consulta = "SELECT * FROM pedidos ORDER BY numPedido DESC;";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            int nPed = 0;
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    nPed = reader.GetInt32(0);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return nPed;
        }

        public static void AgregarPedido(MySqlConnection conexion, Pedido pedido)
        {
            string insertPedido = string.Format("INSERT INTO pedidos VALUES (null, '{0}', '{1}', {2}, '{3}', '{4}', {5}, '{6}', {7}, {8});", pedido.NomCamarero, pedido.Fecha.ToString("yyyy/MM/dd"), pedido.Mesa, pedido.Cliente, pedido.Nombre, pedido.precio.ToString("F"), pedido.CodDesc, pedido.Cancelado, pedido.Pagado);
            
            MySqlCommand insertPedCom = new MySqlCommand(insertPedido, conexion);
            try
            {
                insertPedCom.ExecuteNonQuery();
                if (pedido.Cliente != null)
                {
                    if (Cliente.GetCliente(pedido.Cliente.Tlf, conexion) == null)
                    {
                        string insertCli = string.Format("INSERT INTO clientes VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');", pedido.Cliente.Tlf, pedido.Cliente.Nombre, pedido.Cliente.Calle, pedido.Cliente.Bloque, pedido.Cliente.Escalera, pedido.Cliente.Portal, pedido.Cliente.Piso, pedido.Cliente.Puerta);
                        MySqlCommand insertCliente = new MySqlCommand(insertCli, conexion);
                        insertCliente.ExecuteNonQuery();
                    }
                    else if (!Cliente.SonClientesIguales(pedido.Cliente, Cliente.GetCliente(pedido.Cliente.Tlf, conexion)))
                    {
                        Cliente.Update(conexion, pedido.Cliente);
                    }
                }
                foreach (LineaPedido linea in pedido.LineasPedido)
                {
                    string insertLinea = string.Format("INSERT INTO lineapedido VALUES (NULL, {0}, {1}, {2}, {3});", GetUltNumPed(conexion), linea.Producto.Id, linea.Cant, linea.Hecha);
                    MySqlCommand comando = new MySqlCommand(insertLinea, conexion);
                    comando.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static double GetPrecio(Pedido pedido)
        {
            double prec = 0;
            foreach (LineaPedido linea in pedido.LineasPedido)
            {
                prec += linea.Cant * linea.Producto.Precio;
            }
            return prec;
        }

        public double GetPrecio(Pedido pedido, CodigoDescuento desc)
        {
            double prec = 0;
            foreach (LineaPedido linea in pedido.LineasPedido)
            {
                prec += linea.Cant * linea.Producto.Precio;
            }
            double porc = 1 - (desc.Descuento/100);
            return prec*porc;
        }

        public string GetDestino(Pedido pedido)
        {
            if (pedido.cliente != null)
            {
                return string.Format("DESTINO: {0}, {1}", pedido.Cliente.Calle, pedido.Cliente.Portal);
            }
            else if (pedido.Nombre != null)
            {
                return string.Format("DESTINO: {0}", pedido.Nombre);
            }
            else
            {
                return string.Format("DESTINO: Mesa {0}", pedido.Mesa);
            }
        }

        public static double GetCaja(MySqlConnection conexion, DateTime fecha)
        {
            string consulta = string.Format("SELECT numPedido FROM pedidos WHERE fecha = '{0}' AND pagado = true", fecha.ToString("yyyy/MM/dd"));
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            double caja = 0;
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                List<Pedido> pedidos = new List<Pedido>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pedidos.Add(GetPedido(conexion, reader.GetInt32(0)));
                    }
                }
                foreach (Pedido pedido in pedidos)
                {
                    caja += Pedido.GetPrecio(pedido);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return caja; 
        }

        public static List<Pedido> GetPedidosNoPagados(MySqlConnection conexion)
        {
            string consulta = string.Format("SELECT numPedido FROM pedidos WHERE pagado = false");
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            List<Pedido> pedidos = new List<Pedido>();
            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pedidos.Add(GetPedido(conexion, reader.GetInt32(0)));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pedidos;
        }
    }
}