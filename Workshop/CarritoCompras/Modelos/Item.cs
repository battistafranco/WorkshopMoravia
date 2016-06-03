using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Modelos
{
    public class Item
    {
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }

        public decimal TotalItem
        {
            get
            {
                return Articulo.Precio * Cantidad;
            }
        }
    }
}
