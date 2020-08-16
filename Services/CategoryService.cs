using Microsoft.EntityFrameworkCore;
using EntityFrameworkBasic.Models.Entities;
using EntityFrameworkBasic.Data;
using System.Threading.Tasks;

namespace EntityFrameworkBasic.Services
{
    public class CategoryService
    {
        private AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }


        public async Task InsertAsync(Category c)
        {
            _context.Add(c);
            await _context.SaveChangesAsync();
        }
    }
    

    
}