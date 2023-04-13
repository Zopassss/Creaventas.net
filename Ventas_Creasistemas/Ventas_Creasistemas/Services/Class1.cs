using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas_Creasistemas.Services
{
    public class Class1
    {
        public Class1()
        {

            using (Models.Ventas_CreasistemasContext DB = new Models.Ventas_CreasistemasContext())
            { //conexion
                DB.Usuarios.Add(new Models.Usuarios()); // cargar modelo al contexto
                DB.SaveChanges(); //guardar los cambios

                //EDITAR
                DB.Entry(new Models.Usuarios()).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                DB.SaveChanges();//guardar cambios

                //Listar

                var products = (from producto in DB.Usuarios
                                select new Models.Usuarios()).ToList();




            }
        }
    }
}
