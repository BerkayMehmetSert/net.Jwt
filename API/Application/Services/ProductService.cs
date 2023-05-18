using API.Application.Constants.Repositories;
using API.Application.Constants.Requests.Products;
using API.Application.Constants.Responses.Products;
using API.Application.Constants.Services;
using API.Domain.Entities;
using API.Infrastructure.Exceptions.Types;
using AutoMapper;
using static API.Application.Constants.Messages.Products.ProductMessage;

namespace API.Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void CreateProduct(CreateProductRequest request)
    {
        var product = _mapper.Map<Product>(request);

        _unitOfWork.ProductRepository.Create(product);
        _unitOfWork.SaveChanges();
    }

    public void UpdateProduct(Guid id, UpdateProductRequest request)
    {
        var product = GetProduct(id);

        var updatedProduct = _mapper.Map(request, product);

        _unitOfWork.ProductRepository.Update(updatedProduct);
        _unitOfWork.SaveChanges();
    }

    public void DeleteProduct(Guid id)
    {
        var product = GetProduct(id);

        _unitOfWork.ProductRepository.Delete(product);
        _unitOfWork.SaveChanges();
    }

    public ProductResponse GetProductById(Guid id)
    {
        var product = GetProduct(id);

        return _mapper.Map<ProductResponse>(product);
    }

    public List<ProductResponse> GetAllProducts()
    {
        var products = _unitOfWork.ProductRepository.GetAll();

        return products is not null
            ? _mapper.Map<List<ProductResponse>>(products)
            : throw new NotFoundException(ProductsNotFound);
    }

    private Product GetProduct(Guid id)
    {
        var product = _unitOfWork.ProductRepository.Get(x => x.Id == id);

        return product ?? throw new NotFoundException(ProductNotFound);
    }
}