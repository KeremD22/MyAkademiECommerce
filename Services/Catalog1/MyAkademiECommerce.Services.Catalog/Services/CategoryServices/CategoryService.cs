using AutoMapper;
using MongoDB.Driver;
using MyAkademiECommerce.Services.Catalog.Dtos.CategoryDtos;
using MyAkademiECommerce.Services.Catalog.Models;
using MyAkademiECommerce.Services.Catalog.Settings;

namespace MyAkademiECommerce.Services.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
           var values=_mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(values);
        }

        public async Task DeleteCategoryAsync(string id)
        {
           _categoryCollection.DeleteOneAsync(x=>x.CategoryID == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values=await _categoryCollection.Find(x=>true).ToListAsync();
            return (_mapper.Map<List<ResultCategoryDto>>(values));
        }

        public async Task<ResultCategoryDto> GetCategoryById(string id)
        {
            var values=await _categoryCollection.Find<Category>(x=>x.CategoryID==id).FirstOrDefaultAsync();
            return _mapper.Map<ResultCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
           var values=_mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID, values);
        }
    }
}
