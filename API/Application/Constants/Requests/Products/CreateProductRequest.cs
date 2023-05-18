namespace API.Application.Constants.Requests.Products;

public class CreateProductRequest : BaseRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}