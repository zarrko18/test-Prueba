using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Test_GISSA.Entidades;
using WebApplication27.DAO;

namespace WebApplication28.DAO
{
    public class test_UsuarioDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public test_UsuarioDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public string consultausuarioperfil(test_Usuario usuario)
        {
            string result = "";
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
            comando.CommandText = "execute test_Login @P_Nombre_usuario,@P_Clave";
            comando.Parameters.AddWithValue("@P_Nombre_usuario", usuario.Nombre_Usuario);
            comando.Parameters.AddWithValue("@P_Clave", usuario.Clave);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                result = list.GetString(0);
            }
            list.Dispose();
            comando.Dispose();
           
            }
            catch (Exception e)
            {
                //  Block of code to handle errors
            }
            return result;
        }

        public int Insertar_Usuario(test_Usuario usuario)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                comando.CommandText = "execute test_Insertar_Usuario @_P_Cedula,@_P_Tipo_Usuario ,@_P_Tipo_Identificacion ,@_P_Nombre,@_P_Nombre_Usuario ,@_P_Clave ,@_P_Correo";
                comando.Parameters.AddWithValue("@_P_Cedula", usuario.Cedula);
                comando.Parameters.AddWithValue("@_P_Tipo_Usuario", usuario.Tipo_Usuario);
                comando.Parameters.AddWithValue("@_P_Tipo_Identificacion", usuario.Tipo_Identificacion);
                comando.Parameters.AddWithValue("@_P_Nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@_P_Nombre_Usuario", usuario.Nombre_Usuario);
                comando.Parameters.AddWithValue("@_P_Clave", usuario.Clave);
                comando.Parameters.AddWithValue("@_P_Correo", usuario.Correo);

                result = Convert.ToInt32(comando.ExecuteScalar());
                return result;


            }
            catch (Exception e)
            {
                //  Block of code to handle errors
            }
            return result;
        }
        public int Editar_Usuario(test_Usuario usuario)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                comando.CommandText = "execute test_Editar_Usuario @_P_Id,@_P_Cedula,@_P_Tipo_Usuario ,@_P_Tipo_Identificacion ,@_P_Nombre,@_P_Nombre_Usuario ,@_P_Clave ,@_P_Correo";
                comando.Parameters.AddWithValue("@_P_Id", usuario.Id);
                comando.Parameters.AddWithValue("@_P_Cedula", usuario.Cedula);
                comando.Parameters.AddWithValue("@_P_Tipo_Usuario", usuario.Tipo_Usuario);
                comando.Parameters.AddWithValue("@_P_Tipo_Identificacion", usuario.Tipo_Identificacion);
                comando.Parameters.AddWithValue("@_P_Nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@_P_Nombre_Usuario", usuario.Nombre_Usuario);
                comando.Parameters.AddWithValue("@_P_Clave", usuario.Clave);
                comando.Parameters.AddWithValue("@_P_Correo", usuario.Correo);

                result = comando.ExecuteNonQuery();
                return result;


            }
            catch (Exception e)
            {
                //  Block of code to handle errors
            }
            return result;
        }

        public List<test_Usuario> Listar_Usuario()
        {
            List<test_Usuario> list_usuarios = new List<test_Usuario>();
           
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                comando.CommandText = "exec test_Listar_Usuarios";
                

                SqlDataReader list = comando.ExecuteReader();
                while (list.Read())
                {
                    test_Usuario user = new test_Usuario(list.GetInt32(0), list.GetString(1), list.GetString(2), list.GetString(3), list.GetString(4),
                        list.GetString(5), list.GetString(6));

                    list_usuarios.Add(user);
                }
                list.Dispose();
                comando.Dispose();

            }
            catch (Exception e)
            {
                //  Block of code to handle errors
            }
            return list_usuarios;
        }
        public test_Usuario Buscar_Usuario(int id)
        {
            test_Usuario usuario = new test_Usuario();

            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                comando.CommandText = "exec test_Buscar_Usuario @P_Id";
                comando.Parameters.AddWithValue("@P_Id", id);

                SqlDataReader list = comando.ExecuteReader();
                while (list.Read())
                {
                    test_Usuario user = new test_Usuario(list.GetInt32(0), list.GetString(1), list.GetString(2), list.GetString(3), list.GetString(4),
                        list.GetString(5), list.GetString(6));
                    usuario = user;
                   
                }
                list.Dispose();
                comando.Dispose();

            }
            catch (Exception e)
            {
                //  Block of code to handle errors
            }
            return usuario;
        }

        public string Eliminar_Usuario(int id)
        {
            string result = "";
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                comando.CommandText = "execute test_Eliminar_Usuario @P_Fk_Usuario";
                comando.Parameters.AddWithValue("@P_Fk_Usuario", id);
              

                comando.ExecuteNonQuery();
                
                comando.Dispose();

            }
            catch (Exception e)
            {
                //  Block of code to handle errors
            }
            return result;
        }

    }
}