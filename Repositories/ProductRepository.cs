using Microsoft.EntityFrameworkCore;
using RadzenPOC.Data;

namespace RadzenPOC.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAll(int pageInex = 0, int pageSize = 5);
    Task<Product> GetById(int id);
    Task Add(Product product);
    Task Update(Product product);
    Task Delete(int id);
    Task<int> GetProductCount();
}

public class ProductRepository : IProductRepository
{
    private readonly RadzenPOCContext _context;

    public ProductRepository(RadzenPOCContext context) { _context = context; }

    public async Task<List<Product>> GetAll(int pageInex = 0, int pageSize = 5)
    {
        var data = await _context.Products.OrderBy(p => p.Id).Skip(pageInex * pageSize).Take(pageSize).ToListAsync();
        return data;
    }

    public async Task<Product> GetById(int id) => await _context.Products.FindAsync(id);

    public async Task<int> GetProductCount() => await _context.Products.CountAsync();

    public async Task Add(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var product = await GetById(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}

