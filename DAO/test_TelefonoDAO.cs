using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Test_GISSA.Entidades;
using WebApplication27.DAO;

namespace WebApplication28.DAO
{
    public class test_TelefonoDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public test_TelefonoDAO()
        {
            this.conexion = Conexion.getConexion();
        }


        public void Insertar_Telefonos(List<string> list, string Fk_Usuario)
        {
            foreach (string numero in list) { 
           
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                comando.CommandText = "execute test_Insertar_Telefono @_P_Numero_Telefono,@_P_FK_Id_Usuario ";
                comando.Parameters.AddWithValue("@_P_Numero_Telefono", numero);
                comando.Parameters.AddWithValue("@_P_FK_Id_Usuario", Fk_Usuario);
             
               comando.ExecuteNonQuery();

                

            }
            catch (Exception e)
            {
               
            }
            }
        }


        public string Eliminar_Telefono(int id)
        {
            string result = "";
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                comando.CommandText = "execute test_Eliminar_Telefonos @P_Id";
                comando.Parameters.AddWithValue("@P_Id", id);


                comando.ExecuteNonQuery();

                comando.Dispose();

            }
            catch (Exception e)
            {
                //  Block of code to handle errors
            }
            return result;
        }


        public List<test_Telefono> Listar_Telefonos(int id)
        {
            List<test_Telefono> lista = new List<test_Telefono>();

            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                comando.CommandText = "exec test_Listar_Telefonos @P_FKf_Id";
                comando.Parameters.AddWithValue("@P_FKf_Id", id);

                SqlDataReader list = comando.ExecuteReader();
                while (list.Read())
                {
                    
                    test_Telefono model = new test_Telefono(list.GetInt32(0), list.GetString(1), list.GetInt32(2));


                    lista.Add(model);
                }
                list.Dispose();
                comando.Dispose();

            }
            catch (Exception e)
            {
                //  Block of code to handle errors
            }
            return lista;
        }
    }
}