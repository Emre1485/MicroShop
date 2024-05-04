using AutoMapper;
using MicroShop.Catalog.DTOs.ProductDetailDTOs;
using MicroShop.Catalog.Entities;
using MicroShop.Catalog.Services.ProductDetailDetailServices;
using MicroShop.Catalog.Services.ProductServices;
using MicroShop.Catalog.Settings;
using MongoDB.Driver;

namespace MicroShop.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductDetail> _productDetailCollection;
    public ProductDetailService(IMapper mapper, IDatabaseSettings _dbSettings)
    {
        var client = new MongoClient(_dbSettings.ConnectionString);
        var database = client.GetDatabase(_dbSettings.DatabaseName);
        _productDetailCollection = database.GetCollection<ProductDetail>(_dbSettings.ProductDetailCollectionName);
        _mapper = mapper;
    }

    
    public async Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO)
    {
        var value = _mapper.Map<ProductDetail>(createProductDetailDTO);
        await _productDetailCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailID == id);
    }

    public async Task<List<ResultProductDetailDTO>> GetAllProductDetailAsync()
    {
        var values = await _productDetailCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDTO>>(values);
    }

    public async Task<GetByIdProductDetailDTO> GetByIdProuctDetailAsync(string id)
    {
        var value = await _productDetailCollection.Find(x => x.ProductDetailID == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDetailDTO>(value);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO)
    {
        var value = _mapper.Map<ProductDetail>(updateProductDetailDTO);
        await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDTO.ProductDetailID, value);
    }
}
