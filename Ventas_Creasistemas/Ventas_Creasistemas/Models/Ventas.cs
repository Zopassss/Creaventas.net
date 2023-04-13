using System;
using System.Collections.Generic;

namespace Ventas_Creasistemas.Models
{
    public partial class Ventas
    {
        public int IdVentas { get; set; }
        public int IdProducto { get; set; }
        public int IdUsuarios { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
