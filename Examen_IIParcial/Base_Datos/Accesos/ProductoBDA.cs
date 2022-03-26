using Base_Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Datos.Accesos
{
   public  class ProductoBDA
    {
        readonly string conexion = "Server=localhost; Port=3306; Database=programacion; Uid=root; Pwd=15082000;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public DataTable ListarProductos()
        {
            DataTable lista = new DataTable();

            try
            {
                string sql = "SELECT * FROM productos;";
                conn = new MySqlConnection(conexion);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                lista.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public bool NuevoProducto(Clase_Producto producto)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO productos VALUES (@Codigo, @Descripcion, @Precio, @Existencia);";

                conn = new MySqlConnection(conexion);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Existencia", producto.Existencia);
                cmd.ExecuteNonQuery();
                inserto = true;

                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return inserto;
        }

        public bool EditarProducto(Clase_Producto producto)
        {
            bool modifico = false;
            try
            {
                string sql = "UPDATE productos SET Codigo = @Codigo, Descripcion = @Descripcion, " +
                             "Precio = @Precio, Existencia = @Existencia WHERE Codigo = @Codigo;";

                conn = new MySqlConnection(conexion);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Existencia", producto.Existencia);
                cmd.ExecuteNonQuery();
                modifico = true;
                conn.Close();
            }
            catch (Exception)
            {
            }
            return modifico;
        }

        public bool EliminarProducto(string codigo)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM productos WHERE Codigo = @Codigo;";

                conn = new MySqlConnection(conexion);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Codigo", codigo);

                cmd.ExecuteNonQuery();
                elimino = true;
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return elimino;
        }

        public Clase_Producto GetProductoPorCodigo(string codigo)
        {
            Clase_Producto producto = new Clase_Producto();
            try
            {
                string sql = "Select * from productos WHERE Codigo = @Codigo;";

                conn = new MySqlConnection(conexion);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Codigo", codigo);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    producto.Codigo = reader["Codigo"].ToString();
                    producto.Descripcion = reader["Descripcion"].ToString();
                    producto.Precio = Convert.ToDecimal(reader["Precio"]);
                    producto.Existencia = Convert.ToInt32(reader["Descripcion"].ToString());
                }

                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return producto;
        }
    }
}
