using API.Application.Constants.Requests.Products;
using API.Application.Constants.Responses.Products;
using API.Domain.Entities;
using AutoMapper;

namespace API.Application.Constants.Mapper;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<UpdateProductRequest, Product>();
        CreateMap<Product, ProductResponse>();
    }
}