using System;
using System.Collections.Generic;
using System.Linq;
using Ventas_Creasistemas.Models;
using Microsoft.EntityFrameworkCore;
namespace Ventas_Creasistemas.Repositories
{
	public class ProductRepository
	{
		public List<Producto> findAll()
		{
			using (Ventas_CreasistemasContext db = new Ventas_CreasistemasContext())
			{
				var products = (from p in db.Producto select new Producto()).ToList();
				return products;
			}
		}

        public Producto findById(int id)
        {
            using (Ventas_CreasistemasContext db = new Ventas_CreasistemasContext())
            {
                var product = db.Producto.Find(id);
                return product;
            }
        }

        public int save(Producto newProduct)
        {
            try
            {
                using (Ventas_CreasistemasContext db = new Ventas_CreasistemasContext())
                {
                    db.Add(newProduct);
                    db.SaveChanges();
                    return newProduct.IdProducto;
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public int update(Producto product)
        {
            try
            {
                using (Ventas_CreasistemasContext db = new Ventas_CreasistemasContext())
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return product.IdProducto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void deleteById(int id)
        {
            try
            {
                using (Ventas_CreasistemasContext db = new Ventas_CreasistemasContext())
                {
                    var product = db.Producto.Find(id);
                    db.Remove(product);
                    db.SaveChanges();
                }

            }
                catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



    }
}

