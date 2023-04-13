using System;
using System.Collections.Generic;

namespace Ventas_Creasistemas.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Stock { get; set; }
        public int Precio { get; set; }
        public int CodigoBarras { get; set; }

        public virtual Ventas IdProductoNavigation { get; set; }
    }
}
