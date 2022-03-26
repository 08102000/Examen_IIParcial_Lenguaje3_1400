using Base_Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Datos.Accesos
{
    public class UsarioBDA
    {
        readonly string conexion = "Server=localhost; Port=3306; Database=programacion; Uid=root; Pwd=15082000;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuario Login(string CodigoUsuario, string Clave)

        {
            Usuario user = null;

            try
            {
                string sql = "SELECT * FROM usuario WHERE  CodigoUsuario = @CodigoUsuario AND Clave=@Clave;";
                conn = new MySqlConnection(conexion);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
                cmd.Parameters.AddWithValue("@Clave", Clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new Usuario();
                    user.CodigoUsuario = reader[0].ToString();
                    user.Nombre = reader[1].ToString();
                    user.Clave = reader[2].ToString();
                    user.UsuarioRol = reader[3].ToString();
                   
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return user;
        }

    }
}
