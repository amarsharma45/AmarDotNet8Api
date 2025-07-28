using AmarDotNet8Api.Models;

namespace AmarDotNet8Api.Services;

public class ProductService
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 85000 },
        new Product { Id = 2, Name = "Mouse", Price = 1500 }
    };

    public List<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product)
    {
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
    }

    public bool Update(int id, Product updated)
    {
        var product = GetById(id);
        if (product is null) return false;

        product.Name = updated.Name;
        product.Price = updated.Price;
        return true;
    }

    public bool Delete(int id)
    {
        var product = GetById(id);
        if (product is null) return false;

        _products.Remove(product);
        return true;
    }
}
