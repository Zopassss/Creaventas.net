using System;
using Ventas_Creasistemas.Models;

namespace Ventas_Creasistemas.Dtos
{
	public class ProductDto
	{
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Stock { get; set; }
        public int Precio { get; set; }
        public int CodigoBarras { get; set; }
        public virtual Ventas IdProductoNavigation { get; set; }
    }
}

