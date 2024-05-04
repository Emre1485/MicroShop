using AutoMapper;
using MicroShop.Catalog.DTOs.ProductDTOs;
using MicroShop.Catalog.DTOs.ProductImageDTOs;
using MicroShop.Catalog.Entities;
using MicroShop.Catalog.Settings;
using MongoDB.Driver;

namespace MicroShop.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductImage> _productImageCollection;
    public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }
    public async Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO)
    {
        var values = _mapper.Map<ProductImage>(createProductImageDTO);
        await _productImageCollection.InsertOneAsync(values);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _productImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
    }

    public async Task<List<ResultProductImageDTO>> GetAllProductImageAsync()
    {
        var values = await _productImageCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductImageDTO>>(values);
    }

    public async Task<GetByIdProductImageDTO> GetByIdProductImageAsync(string id)
    {
        var value = await _productImageCollection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductImageDTO>(value);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO)
    {
        var value = _mapper.Map<ProductImage>(updateProductImageDTO);
        await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDTO.ProductImageID, value);
    }
}
