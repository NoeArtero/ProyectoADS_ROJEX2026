using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoADS_ROJEX.Models
{
    public class CarritoItem
    {
        public Image Fotografia { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }
        public decimal TotalProducto => Costo * Cantidad;

        public DateTime FechaAgregado { get; set; } = DateTime.Now;

        // Esta propiedad extra formatea la fecha para que se vea bonita en la tabla (ej. 12/05/2026)
        public string FechaFormateada => FechaAgregado.ToString("dd/MM/yyyy");
    }
}
