using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Ventas_Creasistemas.Models;
using Ventas_Creasistemas.Repositories;
using Ventas_Creasistemas.Dtos;

namespace Ventas_Creasistemas.Services
{
	public class ProductService
	{
		private readonly ProductRepository _productRepository;

		public ProductService()
		{
			_productRepository = new ProductRepository();
        }

        public List<ProductDto> GetProducts()
        {
            var products = _productRepository.findAll();
            return products.Select(p => MapToDto(p)).ToList();
        }

        public ProductDto FindProductById(int id)
        {
            var product = _productRepository.findById(id);
            return MapToDto(product);
        }

        public int CreateProduct(ProductDto newProductDto)
        {
            var product = MapToModel(newProductDto);
            return _productRepository.save(product);
        }


        public int UpdateProduct(ProductDto productDto)
        {
            var product = MapToModel(productDto);
            return _productRepository.update(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.deleteById(id);
        }

        private ProductDto MapToDto(Producto product)
        {
            var productoDto = new ProductDto
            {
                CodigoBarras = product.CodigoBarras,
                NombreProducto = product.NombreProducto,
                Precio = product.Precio,
                Stock = product.Stock,
                IdProductoNavigation = product.IdProductoNavigation
            };
            return productoDto;
        }

        private Producto MapToModel(ProductDto product)
        {
            return new Producto
            {
                CodigoBarras = product.CodigoBarras,
                NombreProducto = product.NombreProducto,
                Precio = product.Precio,
                Stock = product.Stock,
            };
        }
    }
}

