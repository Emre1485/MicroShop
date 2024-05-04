using AutoMapper;
using MicroShop.Catalog.DTOs.CategoryDTOs;
using MicroShop.Catalog.Entities;
using MicroShop.Catalog.Settings;
using MongoDB.Driver;

namespace MicroShop.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;
    public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        // connection
        // db
        // table
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
    {
        var value = _mapper.Map<Category>(createCategoryDTO);
        await _categoryCollection.InsertOneAsync(value);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _categoryCollection.DeleteOneAsync(x=>x.CategoryID == id);
    }

    public async Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
    {
        var values = await _categoryCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultCategoryDTO>>(values);
    }

    public async Task<GetByIdCategoryDTO> GetByIdCategoryAsync(string id)
    {
        var value = await _categoryCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdCategoryDTO>(value);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
    {
        var value = _mapper.Map<Category>(updateCategoryDTO);
        await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryID == updateCategoryDTO.CategoryID, value);
    }
}
