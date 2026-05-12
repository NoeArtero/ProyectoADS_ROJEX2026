using ProyectoADS_ROJEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoADS_ROJEX.ConexionDB
{

    public static class GestorCarrito
    {
        public static List<CarritoItem> ListaProductos { get; set; } = new List<CarritoItem>();

        public static void AgregarProducto(CarritoItem nuevoItem)
        {
            var itemExistente = ListaProductos.FirstOrDefault(item => item.Codigo == nuevoItem.Codigo);
            if (itemExistente != null)
            {
                itemExistente.Cantidad += nuevoItem.Cantidad; 
            }
            else
            {
                ListaProductos.Add(nuevoItem); // Si es nuevo, lo mete a la lista
            }
        }

        // Para que la tarjeta recuerde cuántos habías agregado
        public static int ObtenerCantidadProducto(string codigo)
        {
            var item = ListaProductos.FirstOrDefault(i => i.Codigo == codigo);
            return item != null ? item.Cantidad : 0;
        }

        // Para descontar del carrito cuando le das al botón '-'
        public static void RestarProducto(string codigo)
        {
            var item = ListaProductos.FirstOrDefault(i => i.Codigo == codigo);
            if (item != null)
            {
                item.Cantidad--;
                if (item.Cantidad <= 0)
                {
                    ListaProductos.Remove(item); // Si llega a 0, lo borra del carrito
                }
            }
        }

        public static int ObtenerTotalDeUnidades()
        {
            return ListaProductos.Sum(item => item.Cantidad);
        }

        public static void EliminarProducto(string codigo)
        {
            var item = ListaProductos.FirstOrDefault(i => i.Codigo == codigo);
            if (item != null) ListaProductos.Remove(item);
        }
    }
}




