using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication27.DAO
{
    public class Conexion
    {
        private static SqlConnection objConexion;
        private static string error;

        public Conexion() { }
        public static SqlConnection getConexion()
        {
            if (objConexion != null)
            {
                return objConexion;
            }
            objConexion = new SqlConnection();
            objConexion.ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            try
            {
                objConexion.Open();
                return objConexion;
            }
            catch (Exception e)
            {
                error = e.Message;
                return null;
            }
        }
        public static void cerrarConexion()
        {
            if (objConexion != null)
            {
                objConexion.Close();
            }
        }
    }
}