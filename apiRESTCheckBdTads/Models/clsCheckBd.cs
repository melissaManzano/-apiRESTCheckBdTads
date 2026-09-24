using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace apiRESTCheckBdTads.Models
{
    public class clsCheckBd
    {
        // Atributos
        public int ban;
        public string statusMsg;

        // Definición de métodos (chequeo de conexión a MySql)
        public void checkBd()
        {
            try
            {
                // Lectura de la cadena de conexión (dentro del try para capturar errores)
                string cadConn = ConfigurationManager.ConnectionStrings["control_acceso"].ConnectionString;

                // Prueba de conexión a MySql
                // "using" cierra la conexión automáticamente, aunque ocurra un error
                using (MySqlConnection cnn = new MySqlConnection(cadConn))
                {
                    cnn.Open();
                }

                // Conexión exitosa
                // configuración de bandera y mensaje de salida
                ban = 1;
                statusMsg = "Conexion exitosa (MySql) control_acceso";
            }
            catch (Exception ex)
            {
                // Conexión fallida
                // configuración de bandera y mensaje de salida
                ban = 0;
                statusMsg = ex.Message;
            }
        }
    }
}