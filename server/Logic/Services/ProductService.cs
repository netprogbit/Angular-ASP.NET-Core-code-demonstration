using AutoMapper;
using Logic.Interfaces;
using Logic.Interfaces.OutputInterfaces;
using Logic.Models.DTOs;
using Logic.Models.Entities;

namespace Logic.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GeAllAsync()
    {
        var products = await _unitOfWork.ProductRepository.FindAllAsync();
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        return productDtos;
    }

    public async Task<ProductDto> GeProductByIdAsync(int id)
    {
        var product = await _unitOfWork.ProductRepository.FindByIdAsync(id);
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    public async Task UpdateAsync(int id, ProductUpdateDto model)
    {
        Product product = await _unitOfWork.ProductRepository.FindByIdAsync(id);
        _mapper.Map(model, product);
        _unitOfWork.ProductRepository.Update(product);
        await _unitOfWork.SaveAsync();
    }
}
