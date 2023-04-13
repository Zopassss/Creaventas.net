using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas_Creasistemas.Services
{
    public class Class
    {
        public Class() {

            using (Models.Ventas_CreasistemasContext DB = new Models.Ventas_CreasistemasContext())
            { //conexion
                DB.Producto.Add(new Models.Producto()); // cargar modelo al contexto
                DB.SaveChanges(); //guardar los cambios

                //EDITAR
                DB.Entry(new Models.Producto()).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                DB.SaveChanges();//guardar cambios

                //Listar

                var products = (from producto in DB.Producto 
                                select new Models.Producto()).ToList(); 




            }
        } 
     }
}
