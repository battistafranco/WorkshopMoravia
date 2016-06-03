using CarritoCompras.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Servicios
{
    public class ComprasServicios
    {
        public Compra AgregarItem(Articulo Articulo, int cantidad, Compra Compra)
        {
            if (Compra.ItemsCompra.Any(a => a.Articulo.Id == Articulo.Id))
            {
                //Sumo cantidad
                var item = Compra.ItemsCompra.Where(a=> a.Articulo.Id == Articulo.Id).First();
                item.Cantidad = item.Cantidad + cantidad;
                Compra.ItemsCompra.Remove(Compra.ItemsCompra.Where(a => a.Articulo.Id == Articulo.Id).First());
                Compra.ItemsCompra.Add(item);
            }
            else
            {
                //Item Nuevo
                Item i = new Item();
                i.Articulo = Articulo;
                i.Cantidad = cantidad;
                Compra.ItemsCompra.Add(i);
            }
            
            return Compra;
        }
    }
}
