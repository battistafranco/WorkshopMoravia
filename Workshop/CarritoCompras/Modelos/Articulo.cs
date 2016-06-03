using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Modelos
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public string NombreCompleto
        {
            get
            {
                return Id + " - " + Nombre + " ($" + Precio + ")";
            }
        }
    }
}
