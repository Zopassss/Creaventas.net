using System;
using System.Collections.Generic;

namespace Ventas_Creasistemas.Models
{
    public partial class Usuarios
    {
        public int IdUsuarios { get; set; }
        public string NombreUsuario { get; set; }
        public int NumeroIdentificacion { get; set; }

        public virtual Ventas IdUsuariosNavigation { get; set; }
    }
}
