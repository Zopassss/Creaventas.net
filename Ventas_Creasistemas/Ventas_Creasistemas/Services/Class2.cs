using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas_Creasistemas.Services
{
    public class Class2
    {
        public Class2()
        {

            using (Models.Ventas_CreasistemasContext DB = new Models.Ventas_CreasistemasContext())
            { //conexion
                DB.Ventas.Add(new Models.Ventas()); // cargar modelo al contexto
                DB.SaveChanges(); //guardar los cambios

                //EDITAR
                DB.Entry(new Models.Ventas()).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                DB.SaveChanges();//guardar cambios

                //Listar

                var products = (from producto in DB.Ventas
                                select new Models.Ventas()).ToList();




            }
        }
    }
}
