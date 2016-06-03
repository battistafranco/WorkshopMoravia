using CarritoCompras.Modelos;
using CarritoCompras.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Program
    {

        public static List<Articulo> articulosDisponibles = FillArticulos();

        static void Main(string[] args)
        {            
            Compra compra = new Compra();
            Console.WriteLine("Bienvenido al carrito de compras de Moravia!");
            Console.WriteLine("-----------------------------------------");
            var operacion = 1;
            while (operacion != 0)
            {
                if (compra.ItemsCompra.Count > 0)
                {
                    
                    switch (ShowMenu(compra))
                    {
                        case 1:
                            Console.Clear();
                            Agregar(compra);
                            break;
                        case 2:
                            Eliminar(compra);
                            break;
                        case 4:
                            if (Finalizar(compra))
                            {
                                //operacion = 0;
                            }                           
                            break;
                        case 3:
                            MostrarArticulosAgregados(compra);
                            break;
                        case 0:
                            operacion = 0;
                            break;
                        default:
                            ShowMenu(compra);
                            break;
                    }

                }
                else
                {
                    Agregar(compra);
                }
                
            }
           

        }

        private static bool Finalizar(Compra compra)
        {
            Console.Clear();
            MostrarArticulosAgregados(compra);
            
            Console.WriteLine("Desea finalizar la compra? (S/N)");
            var opcion = Console.ReadLine();
            if (opcion.ToLower().Trim() == "s")
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Compra finalizada con éxito! Gracias por su visita.");
                Console.WriteLine("-----------------------------------------");
                return true;
                
            }
            else
            {
                ShowMenu(compra);
                return true;
            }
        }

        private static void Eliminar(Compra compra)
        {
            Console.Clear();
            Console.WriteLine("2 - ELIMINAR");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Que articulo desea eliminar?");
            Console.WriteLine("-----------------------------------------");
            MostrarArticulosAgregados(compra);
            var artEliminar = int.Parse(Console.ReadLine());
            compra.ItemsCompra.RemoveAll(a => a.Articulo.Id == artEliminar);
            Console.Clear();
            MostrarArticulosAgregados(compra);
        }

        private static void Agregar(Compra compra)
        {

            ComprasServicios _comprasServicios = new ComprasServicios();
            Console.WriteLine("1 - AGREGAR");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Que articulo desea agregar al carrito?");

            foreach (var a in articulosDisponibles)
            {
                Console.WriteLine(a.NombreCompleto);
            }

            int artAgregar = int.Parse(Console.ReadLine());
            var artSeleccionado = articulosDisponibles.Find(a => a.Id == artAgregar);
            Console.WriteLine("Que cantidad de " + artSeleccionado.Nombre + " desea?");
            int cantAgregar = int.Parse(Console.ReadLine());

            compra = _comprasServicios.AgregarItem(artSeleccionado, cantAgregar, compra);
            Console.Clear();
            MostrarArticulosAgregados(compra);

        }
        
        private static void MostrarArticulosAgregados(Compra compra)
        {
            Console.WriteLine("Articulos agregados hasta el momento: " + compra.ItemsCompra.Count);
            Console.WriteLine("-----------------------------------------");
            foreach (var item in compra.ItemsCompra.OrderBy(a=>a.Articulo.Id))
            {
                Console.WriteLine("Id:" + item.Articulo.Id + " / Art: " + item.Articulo.Nombre + " / Cantidad: " + item.Cantidad + " / $ Total: " + item.TotalItem);             
            }
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Total de la compra: $" + compra.TotalCompra);
            Console.WriteLine("-----------------------------------------");
        }

        private static int ShowMenu(Compra compra)
        {            
            Console.WriteLine("Que operación desea realizar ahora?");
            Console.WriteLine("1 - Agregar Articulo al carrito");
            Console.WriteLine("2 - Eliminar Articulo del carrito");
            Console.WriteLine("3 - Mostrar artículos en carrito");
            Console.WriteLine("4 - Finalizar Compra");
            Console.WriteLine("0 - Cerrar programa");
            var opcion = int.Parse(Console.ReadLine());
            return opcion;
        }

        private static List<Articulo> FillArticulos()
        {
            List<Articulo> articulosDisponibles = new List<Articulo>();
            articulosDisponibles.Add(new Articulo { Nombre = "Zapatillas", Id = 1, Precio = 50.50m });
            articulosDisponibles.Add(new Articulo { Nombre = "Remeras", Id = 2, Precio = 10.00m });
            articulosDisponibles.Add(new Articulo { Nombre = "Jeans", Id = 3, Precio = 450.00m });
            articulosDisponibles.Add(new Articulo { Nombre = "Buzos", Id = 4, Precio = 100.50m });

            return articulosDisponibles;
        }
    }
}
