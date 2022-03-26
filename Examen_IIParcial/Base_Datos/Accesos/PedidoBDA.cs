using Base_Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Datos.Accesos
{
    public class PedidoBDA
    {
        readonly string conexion = "Server=localhost; Port=3306; Database=programacion; Uid=root; Pwd=15082000;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public int NuevoPedido(Pedido pedido)
        {
            int IdPedido = 0;
            try
            {
                string sql = "INSERT INTO pedidos (IdentidadCliente, Cliente, SubTotal, Impuesto, Total) VALUES (@IdentidadCliente, @Cliente,  @SubTotal, @Impuesto, @Total); select last_insert_id();";

                conn = new MySqlConnection(conexion);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdentidadCliente", pedido.IdentidadCliente);
                cmd.Parameters.AddWithValue("@Cliente", pedido.Cliente);
                cmd.Parameters.AddWithValue("@SubTotal", pedido.SubTotal);
                cmd.Parameters.AddWithValue("@Impuesto", pedido.Impuesto);
                cmd.Parameters.AddWithValue("@Total", pedido.Total);
                IdPedido = Convert.ToInt32(cmd.ExecuteScalar());


                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return IdPedido;
        }

        public bool InsertarDetalle(DetallePedido detallePedido)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO detallepedido (IdPedido, CodigoProducto, Descripcion, Cantidad, Precio, Total) VALUES (@IdPedido, @CodigoProducto, @Descripcion, @Cantidad, @Precio, @Total);";

                conn = new MySqlConnection(conexion);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdPedido", detallePedido.IdPedido);
                cmd.Parameters.AddWithValue("@CodigoProducto", detallePedido.CodigoProducto);
                cmd.Parameters.AddWithValue("@Descripcion", detallePedido.Descripcion);
                cmd.Parameters.AddWithValue("@Cantidad", detallePedido.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", detallePedido.Precio);
                cmd.Parameters.AddWithValue("@Total", detallePedido.Total);
                cmd.ExecuteNonQuery();

                inserto = true;
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return inserto;
        }
    }
}
