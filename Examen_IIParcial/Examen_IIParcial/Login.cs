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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
          
        }

        private void AcepatarButton_Click(object sender, EventArgs e)
        {
            UsarioBDA UsuarioBDA = new UsarioBDA();
            Usuario usuario = new Usuario();

            usuario = UsuarioBDA.Login(UsuarioTextBox.Text, ClaveTextBox.Text);

            MenuFrm menuFrm = new MenuFrm();
            menuFrm.Show();
            this.Hide();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
