using MySql.Data.MySqlClient;

namespace TOP_Manage
{
    // Clase para gestionar las operaciones con la Base de Datos
    class ConexionBD
    {
        // atributo para gestionar la conexión
        private MySqlConnection conexion;

        // Propiedad para acceder a la conexión
        public MySqlConnection Conexion { get { return conexion; }}
        
        // Constructor que instancia la conexión, definiendo la cadena de conexión (ConnectionString)

        public ConexionBD()
        {
            // Conexión Local
            string server = "server=sql11.freesqldatabase.com;";
            string port = "port=3306;";
            string database = "database=sql11412006;";
            string usuario = "uid=sql11412006;";
            string password = "pwd=XNJclegJRi;";
            string connectionstring = server + port + database + usuario + password;

            // Ejemplo de Conexión remota: db4free.net
            //string server = "server=db4free.net;";
            //string oldguids = "oldguids=true;";
            //string database = "database=bdsalva;";
            //string usuario = "uid=salvador;";
            //string password = "pwd=;";
            //string connectionstring = server + oldguids + database + usuario + password;

            conexion = new MySqlConnection(connectionstring);
        }

        // Método que se encarga de abrir la conexión
        // Devuelve true/false dependiendo si la conexión se ha abierto con éxito o no
        public bool AbrirConexion()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (MySqlException ex)  // Inicialmente no es necesario utilizar el objeto ex
            {
                return false;                
            }
        }

        // Método que se encarga de cerrar la conexión (evitar dejar conexiones abiertas)
        // Devuelve true/false dependiendo si la conexión se ha cerrado con éxito
        public bool CerrarConexion()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch (MySqlException ex) // Inicialmente no es necesario utilizar el objeto ex
            {
                return false;
            }
        }

    }
}
