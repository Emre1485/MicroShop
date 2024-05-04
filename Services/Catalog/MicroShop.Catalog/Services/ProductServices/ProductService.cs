using AutoMapper;
using MicroShop.Catalog.DTOs.ProductDTOs;
using MicroShop.Catalog.Entities;
using MicroShop.Catalog.Settings;
using MongoDB.Driver;

namespace MicroShop.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Product> _productCollection;
    public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }
   

    public async Task CreateProductAsync(CreateProductDTO createProductDTO)
    {
        var values = _mapper.Map<Product>(createProductDTO);
        await _productCollection.InsertOneAsync(values);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productCollection.DeleteOneAsync(x => x.ProductID == id);
    }

    public async Task<List<ResultProductDTO>> GetAllProductAsync()
    {
        var values = await _productCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDTO>>(values);
    }

    public async Task<GetByIdProductDTO> GetByIdProuctAsync(string id)
    {
        var value = await _productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDTO>(value);
    }

    public async Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
    {
        var value = _mapper.Map<Product>(updateProductDTO);
        await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDTO.ProductID, value);
    }
}
