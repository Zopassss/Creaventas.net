using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ventas_Creasistemas.Dtos;
using Ventas_Creasistemas.Models;
using Ventas_Creasistemas.Services;

namespace Ventas_Creasistemas.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
		private readonly ProductService _productService;

		public ProductController(ProductService productService)
		{
            _productService = productService;
        }

        [HttpGet]
        public ObjectResult GetAllProducts()
        {
            var products = _productService.GetProducts();
            return this.StatusCode(StatusCodes.Status200OK, products);
        }


        [HttpGet]
        [Route("/{id}")]
        public ObjectResult GetProductById(int id)
        {
            var product = _productService.FindProductById(id);
            return this.StatusCode(StatusCodes.Status200OK, product);

        }


        [HttpPost]
        public ObjectResult CreateProduct([FromBody] ProductDto productDto)
        {
            var productId = _productService.CreateProduct(productDto);
            return this.StatusCode(StatusCodes.Status201Created, productId);
        }


        [HttpPut]
        public ObjectResult UpdateProduct([FromBody] ProductDto productDto)
        {
            var productId = _productService.UpdateProduct(productDto);
            return this.StatusCode(StatusCodes.Status200OK, productId);
        }


        [HttpDelete]
        [Route("/{id}")]
        public ObjectResult DeleteProductById(int id)
        {
            _productService.DeleteProduct(id);
            return this.StatusCode(StatusCodes.Status200OK, "Product with id "+id+" was deleted successfully");
        }
    }
}

