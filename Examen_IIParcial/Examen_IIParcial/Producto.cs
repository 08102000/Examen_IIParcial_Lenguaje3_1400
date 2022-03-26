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
    public partial class Producto : Form
    {
        public Producto()
        {
            InitializeComponent();
        }

        string operacion = string.Empty;

        ProductoBDA productoBDA = new ProductoBDA();
        Clase_Producto ObjProducto = new Clase_Producto();

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            operacion = "Nuevo";
            HabilitarControles();
        }
        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            DescripcionTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
            ExistenciaTextBox.Enabled = true;

            NuevoButton.Enabled = false;
            GuardarButton.Enabled = true;
            EliminarButton.Enabled = true;
        }

        private void DesHabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            DescripcionTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            ExistenciaTextBox.Enabled = false;

            NuevoButton.Enabled = true;
            GuardarButton.Enabled = false;
            EliminarButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            DescripcionTextBox.Clear();
            PrecioTextBox.Clear();
            ExistenciaTextBox.Clear();
        }
        private void ListarProductos()
        {
            ProductoDataGridView.DataSource = productoBDA.ListarProductos();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese el código");
                    CodigoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DescripcionTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionTextBox, "Ingrese una descripción");
                    DescripcionTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(PrecioTextBox.Text))
                {
                    errorProvider1.SetError(PrecioTextBox, "Ingrese un precio");
                    PrecioTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(ExistenciaTextBox.Text))
                {
                    errorProvider1.SetError(ExistenciaTextBox, "Ingrese una existencia");
                    ExistenciaTextBox.Focus();
                    return;
                }

                ObjProducto.Codigo = CodigoTextBox.Text;
                ObjProducto.Descripcion = DescripcionTextBox.Text;
                ObjProducto.Precio = Convert.ToDecimal(PrecioTextBox.Text);
                ObjProducto.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);

                if (operacion == "Nuevo")
                {
                    bool inserto = productoBDA.NuevoProducto(ObjProducto);

                    if (inserto)
                    {
                        DesHabilitarControles();
                        LimpiarControles();
                        ListarProductos();
                        MessageBox.Show("Producto insertado");
                    }
                }
                else if (operacion == "Modificar")
                {
                    bool modifico = productoBDA.EditarProducto(ObjProducto);
                    if (modifico)
                    {
                        LimpiarControles();
                        DesHabilitarControles();
                        ListarProductos();
                        MessageBox.Show("Producto Modificado");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        
          
        
        }

        private void EditarButton_Click(object sender, EventArgs e)
        {
            operacion = "Modificar";

            if (ProductoDataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = ProductoDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                DescripcionTextBox.Text = ProductoDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                PrecioTextBox.Text = ProductoDataGridView.CurrentRow.Cells["Precio"].Value.ToString();
                ExistenciaTextBox.Text = ProductoDataGridView.CurrentRow.Cells["Existencia"].Value.ToString();
                HabilitarControles();
                CodigoTextBox.Focus();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto");
            }
       
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ProductoDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = productoBDA.EliminarProducto(ProductoDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());

                if (elimino)
                {
                    ListarProductos();
                    MessageBox.Show("Producto Eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }
    }   
}
    
