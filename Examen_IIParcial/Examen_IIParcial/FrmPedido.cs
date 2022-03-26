using Base_Datos.Accesos;
using Base_Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_IIParcial
{
    public partial class FrmPedido : Form
    {
        public FrmPedido()
        {
            InitializeComponent();
        }

        Pedido pedido = new Pedido();
        Clase_Producto producto;
        ProductoBDA productoBDA = new ProductoBDA();
        PedidoBDA pedidoBDA = new PedidoBDA();

        List<DetallePedido> detallePedidoLista = new List<DetallePedido>();
        decimal subTotal = decimal.Zero;
        decimal isv = decimal.Zero;
        decimal totalAPagar = decimal.Zero;

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            DetalleDataGridView1.DataSource = detallePedidoLista;
        }

        private void CodigoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                producto = new Clase_Producto();
                producto = productoBDA.GetProductoPorCodigo(CodigoProductoTextBox.Text);
                DescripcionTextBox.Text = producto.Descripcion;
                CantidadTextBox.Focus();
            }
            else
            {
                producto = null;
                DescripcionTextBox.Clear();
                CantidadTextBox.Clear();
            }
        }

        private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(CantidadTextBox.Text))
            {
                DetallePedido detallePedido = new DetallePedido();
                detallePedido.CodigoProducto = producto.Codigo;
                detallePedido.Descripcion = producto.Descripcion;
                detallePedido.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
                detallePedido.Precio = producto.Precio;
                detallePedido.Total = producto.Precio * Convert.ToInt32(CantidadTextBox.Text);

                subTotal += detallePedido.Total;
                isv = subTotal * 0.15M;
                totalAPagar = subTotal + isv;

                SubTotalTextBox.Text = subTotal.ToString();
                ISVTextBox.Text = isv.ToString();
                TotalTextBox.Text = totalAPagar.ToString();

                detallePedidoLista.Add(detallePedido);
                DetalleDataGridView1.DataSource = null;
                DetalleDataGridView1.DataSource = detallePedidoLista;

            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            pedido.IdentidadCliente = IdentidadClienteMaskedTextBox.Text;
            pedido.Cliente = NombreTextBox.Text;
            pedido.SubTotal = Convert.ToDecimal(SubTotalTextBox.Text);
            pedido.Impuesto = Convert.ToDecimal(ISVTextBox.Text);
            pedido.Total = Convert.ToDecimal(TotalTextBox.Text);

            int idPedido = 0;

            idPedido = pedidoBDA.NuevoPedido(pedido);

            if (idPedido != 0)
            {
                foreach (var item in detallePedidoLista)
                {
                    item.IdPedido = idPedido;
                    pedidoBDA.InsertarDetalle(item);
                }
            }
        }
    }
}
