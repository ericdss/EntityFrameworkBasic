using Microsoft.EntityFrameworkCore;
using EntityFrameworkBasic.Models.Entities;
using EntityFrameworkBasic.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EntityFrameworkBasic.Services
{
    public class ProductService
    {
        private AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }


        public async Task InsertAsync(Product p)
        {
            _context.Add(p);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Product.Include(x => x.Category).ToListAsync();
        }

        public async Task UpdateAsync(Product p)
        {
            _context.Update(p);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product p)
        {
            _context.Remove(p);
            await _context.SaveChangesAsync();
        }
    }
    

    
}