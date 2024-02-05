using MyAkademiECommerce.Services.Catalog.Dtos.CategoryDtos;
using MyAkademiECommerce.Services.Catalog.Dtos.ProductDtos;

namespace MyAkademiECommerce.Services.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();       
       Task CreateProductAsync(CreateProductDto createProductDto);
       Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id); 
        Task<ResultProductDto> GetProductById(string id);


    }
}
