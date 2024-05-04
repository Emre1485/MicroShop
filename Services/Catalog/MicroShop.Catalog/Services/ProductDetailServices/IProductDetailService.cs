using MicroShop.Catalog.DTOs.ProductDetailDTOs;

namespace MicroShop.Catalog.Services.ProductDetailDetailServices;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDTO>> GetAllProductDetailAsync();
    Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO);
    Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO);
    Task DeleteProductDetailAsync(string id);
    Task<GetByIdProductDetailDTO> GetByIdProuctDetailAsync(string id);
}
