using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Examen_IIParcial
{
    public partial class MenuFrm : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuFrm()
        {
            InitializeComponent();
        }
        Producto producto = null;
        FrmPedido frmPedido = null;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (producto == null)
            {
                producto = new Producto();
                producto.MdiParent = this;
                producto.FormClosed += Producto_FormClosed;
                producto.Show();
            }
            else
            {
                producto.Activate();
            }
        }

        private void Producto_FormClosed(object sender, FormClosedEventArgs e)
        {
            producto = null;
        }

        private void PedidosToolStripButton_Click(object sender, EventArgs e)
        {
            if (frmPedido == null)
            {
                frmPedido = new FrmPedido();
                frmPedido.MdiParent = this;
                frmPedido.FormClosed += FrmPedido_FormClosed;
                frmPedido.Show();
            }
            else
            {
                frmPedido.Activate();
            }
        }
        private void FrmPedido_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPedido = null;
        }
    }
}
