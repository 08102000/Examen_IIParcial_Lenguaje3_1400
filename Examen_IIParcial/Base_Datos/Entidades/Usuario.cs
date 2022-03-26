using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Datos.Entidades
{
    public class Usuario
    {
        public string CodigoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string UsuarioRol { get; set; }

        public Usuario()
        {
        }

        public Usuario(string codigoUsuario, string nombre, string clave, string usuarioRol)
        {
            CodigoUsuario = codigoUsuario;
            Nombre = nombre;
            Clave = clave;
            UsuarioRol = usuarioRol;
        }
    }
}
