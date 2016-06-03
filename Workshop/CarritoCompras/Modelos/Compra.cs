using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Modelos
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public List<Item> ItemsCompra { get; set; }
        public string Estado { get; set; }

        public decimal TotalCompra
        {
            get
            {
                return ItemsCompra.Sum(a => a.TotalItem);
            }
        }

        public Compra()
        {
            ItemsCompra = new List<Item>();
        }
    }
}
