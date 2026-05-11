using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoADS_ROJEX.Views.Perfil
{
  public static class SesionUsuario
    {
        // El ID es lo más importante para los SELECT y UPDATE
        public static int IdUsuario { get; set; }

        // El Nombre para mostrar "Bienvenido, Felix" en el menú
        public static string Nombre { get; set; }

        // El Rol para saber si habilitamos el botón de "Agregar Producto"
        public static bool EsAdmin { get; set; }
    }
}
