using MicroShop.Catalog.DTOs.ProductImageDTOs;

namespace MicroShop.Catalog.Services.ProductImageServices;

public interface IProductImageService
{
    Task<List<ResultProductImageDTO>> GetAllProductImageAsync();
    Task CreateProductImageAsync (CreateProductImageDTO createProductImageDTO);
    Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO);
    Task DeleteProductImageAsync(string id);
    Task <GetByIdProductImageDTO> GetByIdProductImageAsync (string id);
}
