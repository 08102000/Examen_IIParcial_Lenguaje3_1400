using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Datos.Entidades
{
   public class Pedido
    {
        public int Id { get; set; }
        public string IdentidadCliente { get; set; }
        public string Cliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }

        public Pedido()
        {
        }

        public Pedido(int id, string identidadCliente, string cliente, decimal subTotal, decimal impuesto, decimal total)
        {
            Id = id;
            IdentidadCliente = identidadCliente;
            Cliente = cliente;
            SubTotal = subTotal;
            Impuesto = impuesto;
            Total = total;
        }
    }
}
