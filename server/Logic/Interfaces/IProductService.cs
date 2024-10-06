using Logic.Models.DTOs;
using Logic.Models.Entities;

namespace Logic.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GeAllAsync();
        Task<ProductDto> GeProductByIdAsync(int id);
        Task UpdateAsync(int id, ProductUpdateDto model);
    }
}