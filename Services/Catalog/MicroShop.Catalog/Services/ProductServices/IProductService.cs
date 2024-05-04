using MicroShop.Catalog.DTOs.ProductDTOs;

namespace MicroShop.Catalog.Services.ProductServices;

public interface IProductService
{
    Task<List<ResultProductDTO>> GetAllProductAsync();
    Task CreateProductAsync(CreateProductDTO createProductDTO);
    Task UpdateProductAsync(UpdateProductDTO updateProductDTO);
    Task DeleteProductAsync(string id);
    Task<GetByIdProductDTO> GetByIdProuctAsync(string id);
}
