using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Datos.Entidades
{
    public class Clase_Producto
    {
        public string  Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }

        public Clase_Producto()
        {
        }

        public Clase_Producto(string codigo, string descripcion, decimal precio, int existencia)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
            Existencia = existencia;
        }
    }
}
