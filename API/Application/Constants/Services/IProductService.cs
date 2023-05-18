using API.Application.Constants.Requests.Products;
using API.Application.Constants.Responses.Products;

namespace API.Application.Constants.Services;

public interface IProductService
{
    void CreateProduct(CreateProductRequest request);
    void UpdateProduct(Guid id, UpdateProductRequest request);
    void DeleteProduct(Guid id);
    ProductResponse GetProductById(Guid id);
    List<ProductResponse> GetAllProducts();
}