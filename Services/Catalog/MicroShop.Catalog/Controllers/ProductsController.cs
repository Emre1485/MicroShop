using MicroShop.Catalog.DTOs.ProductDTOs;
using MicroShop.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var value = await _productService.GetByIdProuctAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createproductDTO)
        {
            await _productService.CreateProductAsync(createproductDTO);
            return Ok("Product Added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Product Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateproductDTO)
        {
            await _productService.UpdateProductAsync(updateproductDTO);
            return Ok("Product Updated");
        }
    }
}
